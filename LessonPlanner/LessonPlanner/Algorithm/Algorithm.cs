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

        public Algorithm(int numberOfChromosomes, int replaceByGeneration, int trackBest, Schedule prototype)
        {
            ReplaceByGeneration = replaceByGeneration;
            CurrentBestSize = 0;
            Prototype = prototype;
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
        }

        // Starts and executes algorithm
        public void Start()
        {
            //        if( !_prototype )
            //    return;

            //CSingleLock lock( &_stateSect, TRUE );

            //// do not run already running algorithm
            //if( _state == AS_RUNNING )
            //    return;

            //_state = AS_RUNNING;

            //lock.Unlock();

            //if( _observer )
            //    // notify observer that execution of algorithm has changed it state
            //    _observer->EvolutionStateChanged( _state );

            //// clear best chromosome group from previous execution
            //ClearBest();

            //// initialize new population with chromosomes randomly built using prototype
            //int i = 0;
            //for( vector<Schedule*>::iterator it = _chromosomes.begin(); it != _chromosomes.end(); ++it, ++i )
            //{
            //    // remove chromosome from previous execution
            //    if( *it )
            //        delete *it;

            //    // add new chromosome to population
            //    *it = _prototype->MakeNewFromPrototype();
            //    AddToBest( i );
            //}

            //_currentGeneration = 0;

            //while( 1 )
            //{
            //    lock.Lock();

            //    // user has stopped execution?
            //    if( _state != AS_RUNNING )
            //    {
            //        lock.Unlock();
            //        break;
            //    }

            //    Schedule* best = GetBestChromosome();

            //    // algorithm has reached criteria?
            //    if( best->GetFitness() >= 1 )
            //    {
            //        _state = AS_CRITERIA_STOPPED;
            //        lock.Unlock();
            //        break;
            //    }

            //    lock.Unlock();

            //    // produce offepsing
            //    vector<Schedule*> offspring;
            //    offspring.resize( _replaceByGeneration );
            //    for( int j = 0; j < _replaceByGeneration; j++ )
            //    {
            //        // selects parent randomly
            //        Schedule* p1 = _chromosomes[ rand() % _chromosomes.size() ];
            //        Schedule* p2 = _chromosomes[ rand() % _chromosomes.size() ];

            //        offspring[ j ] = p1->Crossover( *p2 );
            //        offspring[ j ]->Mutation();
            //    }

            //    // replace chromosomes of current operation with offspring
            //    for( int j = 0; j < _replaceByGeneration; j++ )
            //    {
            //        int ci;
            //        do
            //        {
            //            // select chromosome for replacement randomly
            //            ci = rand() % (int)_chromosomes.size();

            //            // protect best chromosomes from replacement
            //        } while( IsInBest( ci ) );

            //        // replace chromosomes
            //        delete _chromosomes[ ci ];
            //        _chromosomes[ ci ] = offspring[ j ];

            //        // try to add new chromosomes in best chromosome group
            //        AddToBest( ci );
            //    }

            //    // algorithm has found new best chromosome
            //    if( best != GetBestChromosome() && _observer )
            //        // notify observer
            //        _observer->NewBestChromosome( *GetBestChromosome() );

            //    _currentGeneration++;
            //}

            //if( _observer )
            //    // notify observer that execution of algorithm has changed it state
            //    _observer->EvolutionStateChanged( _state );
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
