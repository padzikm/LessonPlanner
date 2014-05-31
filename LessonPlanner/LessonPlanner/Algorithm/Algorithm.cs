using System;
using System.Collections.Generic;

namespace LessonPlanner
{
    enum AlgorithmState
    {
        Userstopped,
        Criteriastopped,
        Running,
    }

    class Algorithm
    {
        // Population of chromosomes
        public List<Schedule> Chromosomes { get; set; }

        // Inidicates wheahter chromosome belongs to best chromosome group
        public List<bool> BestFlags { get; set; }

        // Indices of best chromosomes
        public List<int> BestChromosomes { get; set; }

        // Number of best chromosomes currently saved in best chromosome group
        public int CurrentBestSize { get; set; }

        // Number of chromosomes which are replaced in each generation by offspring
        public int ReplaceByGeneration { get; set; }

        // Prototype of chromosomes in population
        public Schedule Prototype { get; set; }

        // Current generation
        public int CurrentGeneration { get; set; }

        // State of execution of algorithm
        public AlgorithmState State { get; set; }

        // Tries to add chromosomes in best chromosome group
        private void AddToBest(int chromosomeIndex)
        {
            // don't add if new chromosome hasn't fitness big enough for best chromosome group
            // or it is already in the group?
            if ((CurrentBestSize == BestChromosomes.Count && Chromosomes[BestChromosomes[CurrentBestSize - 1]].Fitness >= Chromosomes[chromosomeIndex].Fitness) || BestFlags[chromosomeIndex])
                return;

            // find place for new chromosome
            int i = CurrentBestSize;
            for (; i > 0; i--)
            {
                // group is not full?
                if (i < BestChromosomes.Count)
                {
                    // position of new chromosomes is found?
                    if (Chromosomes[BestChromosomes[i - 1]].Fitness > Chromosomes[chromosomeIndex].Fitness)
                        break;

                    // move chromosomes to make room for new
                    BestChromosomes[i] = BestChromosomes[i - 1];
                }
                else
                    // group is full remove worst chromosomes in the group
                    BestFlags[BestChromosomes[i - 1]] = false;
            }

            // store chromosome in best chromosome group
            BestChromosomes[i] = chromosomeIndex;
            BestFlags[chromosomeIndex] = true;

            // increase current size if it has not reached the limit yet
            if (CurrentBestSize < BestChromosomes.Count)
                CurrentBestSize++;
        }

        // Returns TRUE if chromosome belongs to best chromosome group
        private bool IsInBest(int chromosomeIndex)
        {
            return BestFlags[chromosomeIndex];
        }

        // Clears best chromosome group
        private void ClearBest()
        {
            for (int i = 0; i < BestFlags.Count; ++i)
                BestFlags[i] = false;

            CurrentBestSize = 0;
        }

        public Algorithm(int numberOfChromosomes, int replaceByGeneration, int trackBest)
        {
            ReplaceByGeneration = replaceByGeneration;
            CurrentBestSize = 0;
            Prototype = new Schedule(2, 2, 80, 3);
            CurrentGeneration = 0;
            State = AlgorithmState.Userstopped;

            // there should be at least 2 chromosomes in population
            if (numberOfChromosomes < 2)
                numberOfChromosomes = 2;

            // and algorithm should track at least on of best chromosomes
            if (trackBest < 1)
                trackBest = 1;

            if (ReplaceByGeneration < 1)
                ReplaceByGeneration = 1;
            else if (ReplaceByGeneration > numberOfChromosomes - trackBest)
                ReplaceByGeneration = numberOfChromosomes - trackBest;

            // reserve space for population
            Chromosomes = new List<Schedule>(numberOfChromosomes);

            BestFlags = new List<bool>(numberOfChromosomes);
            BestChromosomes = new List<int>(trackBest);
            for (int i = 0; i < numberOfChromosomes; i++)
            {
                Chromosomes.Add(null);
                BestFlags.Add(false);

            }
            for (int i = 0; i < trackBest; i++) BestChromosomes.Add(0);

        }

        // Starts and executes algorithm
        public void Start()
        {
            if (Prototype == null)
                return;

            // do not run already running algorithm
            if (State == AlgorithmState.Running)
                return;

            State = AlgorithmState.Running;

            // clear best chromosome group from previous execution
            ClearBest();

            // initialize new population with chromosomes randomly built using prototype
            for (int i = 0; i < Chromosomes.Count; ++i)
            {
                // remove chromosome from previous execution
                //if (Chromosomes[i] != null)
                //    Chromosomes.RemoveAt(i);

                // add new chromosome to population
                Chromosomes[i] = Prototype.MakeNewFromPrototype();
                AddToBest(i);
            }

            Random random = new Random(12345);
            CurrentGeneration = 0;

            while (true)
            {
                // user has stopped execution?
                if (State != AlgorithmState.Running)
                    break;

                Schedule best = GetBestChromosome();

                // algorithm has reached criteria?
                if (best.Fitness >= 1)
                {
                    State = AlgorithmState.Criteriastopped;
                    break;
                }

                // produce offepsing
                List<Schedule> offspring = new List<Schedule>(ReplaceByGeneration);
                for(int i = 0; i < ReplaceByGeneration; ++i)
                    offspring.Add(null);

                for (int j = 0; j < ReplaceByGeneration; ++j)
                {
                    // selects parent randomly
                    Schedule p1 = Chromosomes[random.Next(1000) % Chromosomes.Count];
                    Schedule p2 = Chromosomes[random.Next(1000) % Chromosomes.Count];

                    offspring[j] = p1.Crossover(p2);
                    offspring[j].Mutation();
                }

                // replace chromosomes of current operation with offspring
                for (int j = 0; j < ReplaceByGeneration; ++j)
                {
                    int ci;
                    do
                    {
                        // select chromosome for replacement randomly
                        ci = random.Next() % Chromosomes.Count;

                        // protect best chromosomes from replacement
                    } while (IsInBest(ci));

                    // replace chromosomes
                    Chromosomes[ci] = offspring[j];

                    // try to add new chromosomes in best chromosome group
                    AddToBest(ci);
                }

                ++CurrentGeneration;
            }
        }

        // Stops execution of algorithm
        public void Stop()
        {
            if (State == AlgorithmState.Running)
                State = AlgorithmState.Userstopped;

            //TODO: add synchronization
        }

        // Returns pointer to best chromosomes in population
        public Schedule GetBestChromosome()
        {
            return Chromosomes[BestChromosomes[0]];
        }
    }
}
