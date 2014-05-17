﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace LessonPlanner
{
    class Schedule
    {
        // Number of crossover points of parent's class tables
        public int NumberOfCrossoverPoints { get; set; }

        // Number of classes that is moved randomly by single mutation operation
        public int MutationSize { get; set; }

        // Probability that crossover will occure
        public int CrossoverProbability { get; set; }

        // Probability that mutation will occure
        public int MutationProbability { get; set; }

        // Fitness value of chromosome
        public float Fitness { get; set; }

        // Flags of class requiroments satisfaction
        public List<bool> Criteria { get; set; }

        // Time-space slots, one entry represent one hour in one classroom
        public List<List<CourseClass>> Slots { get; set; }

        // Class table for chromosome
        // Used to determine first time-space slot used by class
        public Dictionary<CourseClass, int> Classes { get; set; }

        private static readonly Random random = new Random();



        // Initializes chromosomes with configuration block (setup of chromosome)
        public Schedule(int numberOfCrossoverPoints, int mutationSize, int crossoverProbability, int mutationProbability)
        {
            MutationSize = mutationSize;
            NumberOfCrossoverPoints = numberOfCrossoverPoints;
            CrossoverProbability = crossoverProbability;
            MutationProbability = mutationProbability;
            Fitness = 0;
            // reserve space for time-space slots in chromosomes code
            //Slots = new List<List<CourseClass>>(Consts.DayCount * Consts.DayHours * Configuration::GetInstance().GetNumberOfRooms() );

            // reserve space for flags of class requirements
            //Criteria.resize( Configuration::GetInstance().GetNumberOfCourseClasses() * 5 );
        }

        // Copy constructor
        public Schedule(Schedule c, bool setupOnly)
        {
            //        if( !setupOnly )
            //{
            //    // copy code
            //    _slots = c._slots;
            //    _classes = c._classes;

            //    // copy flags of class requirements
            //    _criteria = c._criteria;

            //    // copy fitness
            //    _fitness = c._fitness;
            //}
            //else
            //{
            //    // reserve space for time-space slots in chromosomes code
            //    _slots.resize( DAYS_NUM * DAY_HOURS * Configuration::GetInstance().GetNumberOfRooms() );

            //    // reserve space for flags of class requirements
            //    _criteria.resize( Configuration::GetInstance().GetNumberOfCourseClasses() * 5 );
            //}

            //// copy parameters
            //_numberOfCrossoverPoints = c._numberOfCrossoverPoints;
            //_mutationSize = c._mutationSize;
            //_crossoverProbability = c._crossoverProbability;
            //_mutationProbability = c._mutationProbability;
        }

        // Makes copy ot chromosome
        public Schedule MakeCopy(bool setupOnly)
        {
            return new Schedule(this, setupOnly);
        }

        // Makes new chromosome with same setup but with randomly chosen code
        public Schedule MakeNewFromPrototype()
        {
            //        // number of time-space slots
            int size = Slots.Count;

            //// make new chromosome, copy chromosome setup
            Schedule newChromosome = new Schedule(this, true);
            // place classes at random position
            var configuration = new Configuration();
            configuration.FillExampleData();
            List<CourseClass> c = new List<CourseClass>();

            //const list<CourseClass*>& c = Configuration::GetInstance().GetCourseClasses();
            foreach (var courseClass in c)
            {
                // determine random position of class
                int nr = configuration.GetNumberOfRooms();
                int duration = courseClass.LessonDuration;
                int day = random.Next(0, Consts.DayCount);
                int room = random.Next(0, nr);
                int time = random.Next(0, Consts.DayHours + 1 - duration);
                int pos = day * nr * Consts.DayCount;
                // fill time-space slots, for each hour of class
                for (int i = duration - 1; i >= 0; i--)
                    newChromosome.Slots[pos + i].Add(courseClass);
                // insert in class table of chromosome
                newChromosome.Classes.Add(courseClass, pos);

            }
            newChromosome.CalculateFitness();
            return newChromosome;
        }

        // Performes crossover operation using to chromosomes and returns pointer to offspring
        public Schedule Crossover(Schedule parent2)
        {
            //        // check probability of crossover operation
            if (random.Next(100) > CrossoverProbability)
                // no crossover, just copy first parent
                return new Schedule(this, false);

            // new chromosome object, copy chromosome setup
            Schedule n = new Schedule(this, true);

            //// number of classes
            //int size = (int)_classes.size();
            int size = Classes.Count;

            List<bool> cp = new List<bool>(size);

            // determine crossover point (randomly)
            for (int i = NumberOfCrossoverPoints; i > 0; i--)
            {
                while (true)
                {
                    int p = random.Next(size);
                    if (!cp[p])
                    {
                        cp[p] = true;
                        break;
                    }
                }
            }
            // make new code by combining parent codes
            bool first = random.Next(2) == 0;

            for (int i = 0, k = 0, j = 0; i < size; i++, j++, k++)
            {
                if (first)
                {
                    // insert class from first parent into new chromosome's calss table
                    var classValue = Classes.ElementAt(k);
                    n.Classes.Add(classValue.Key, classValue.Value);
                    // all time-space slots of class are copied
                    for (int x = classValue.Key.LessonDuration - 1; x >= 0; x--)
                    {
                        n.Slots[classValue.Value + x].Add(classValue.Key);
                    }

                }
                else
                {
                    // insert class from second parent into new chromosome's calss table

                    var classValue = parent2.Classes.ElementAt(j);
                    n.Classes.Add(classValue.Key, classValue.Value);
                    // all time-space slots of class are copied
                    for (int x = classValue.Key.LessonDuration - 1; x >= 0; x--)
                    {
                        n.Slots[classValue.Value + x].Add(classValue.Key);
                    }
                    //crossover point
                    if (cp[i])
                        first = !first;

                }
                CalculateFitness();
            }
            return n;
        }

        // Performs mutation on chromosome
        public void Mutation()
        {

            var configuration = new Configuration();
            configuration.FillExampleData();
            //check probability of mutation operation
            if (random.Next(100) > MutationProbability)
                return;


            // number of classes
            int numberOfClasses = Classes.Count;
            // number of time-space slots
            int size = Slots.Count;

            // move selected number of classes at random position
            for (int i = MutationSize; i > 0; i--)
            {
                // select ranom chromosome for movement
                int mpos = random.Next(numberOfClasses);
                int pos1 = 0;
                CourseClass cc1 = Classes.ElementAt(mpos).Key;

                pos1 = Classes.ElementAt(mpos).Value;

                int nr = configuration.GetNumberOfRooms();
                int duration = cc1.LessonDuration;
                int day = random.Next(0, Consts.DayCount);
                int room = random.Next(0, nr);
                int time = random.Next(0, Consts.DayHours + 1 - duration);
                int pos2 = day * nr * Consts.DayHours + room * Consts.DayHours + time;
                // move all time-space slots
                for (int j = duration - 1; j >= 0; j--)
                {
                    // remove class hour from current time-space slot

                    List<CourseClass> cl = Slots[pos1 + 1];
                    for (int k = 0; k < cl.Count; k++)
                    {
                        if (cl[k] == cc1)
                            cl.Remove(cl[k]);
                    }
                    // move class hour to new time-space slot
                    Slots[pos2 + i].Add(cc1);
                }
                // change entry of class table to point to new time-space slots
                Classes[cc1] = pos2;
            }
        }

        // Calculates fitness value of chromosome
        public void CalculateFitness()
        {
            // chromosome's score
            int score = 0;
            var configuration = new Configuration();
            configuration.FillExampleData();

            int numberOfRooms = configuration.GetNumberOfRooms();
            int daySize = Consts.DayHours * numberOfRooms;

            int ci = 0;

            // check criterias and calculate scores for each class in schedule
            foreach (var classValue in Classes)
            {
                int p = classValue.Value;
                int day = p / daySize;
                int time = p % daySize;
                int room = time % Consts.DayHours;
                time = time % Consts.DayHours;

                int duration = classValue.Key.LessonDuration;
                bool ro = false;
                for (int i = duration - 1; i >= 0; i--)
                {
                    if (Slots[p + i].Count > 1)
                    {
                        ro = true;
                        break;
                    }
                    if (!ro)
                        score++;
                    Criteria[ci + 0] = !ro;
                    CourseClass courseClass = classValue.Key;
                    Room roomInstance = configuration.GetRoomById(room);
                    // does current room have enough seats
                    //TODO Criteria[ci + 1] = roomInstance.SeatCount >= courseClass.SeatCount;
                    if (Criteria[ci + 1])
                        score++;
                    Criteria[ci + 2] = !courseClass.IsLabRequired || courseClass.IsLabRequired && roomInstance.IsLab;
                    if (Criteria[ci + 1])
                        score++;

                    bool po = false, go = false;
                    // does current room have enough seats
                    for (int j = numberOfRooms, t = day * daySize + time; j > 0; j--, t += Consts.DayHours)
                    {
                        for (int k = duration - 1; k >= 0; k--)
                        {
                            List<CourseClass> cl = Slots[t + i];
                            foreach (var clValue in cl)
                            {
                                if (courseClass != clValue)
                                {
                                    // professor overlaps?
                                    if (!po && courseClass.ProfessorOverlaps(clValue))
                                        po = true;
                                    if (!go && courseClass.GroupsOverlap(clValue))
                                        go = true;
                                    if (po && go)
                                        goto total_overlap;
                                }
                            }
                        }
                    }
                total_overlap:
                    {
                        if (!po)
                            score++;
                        Criteria[ci + 3] = !po;

                        // student groups has no overlaping classes?
                        if (!go)
                            score++;
                        Criteria[ci + 4] = !go;
                    }

                    // calculate fitess value based on score
                    Fitness = (float)score / (configuration.GetNumberOfCourseClasses() * Consts.DayCount);
                }
                ci += 5;
            }


        }

    }
}