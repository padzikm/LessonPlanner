using System.Collections.Generic;

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
            //int size = (int)_slots.size();

            //// make new chromosome, copy chromosome setup
            //Schedule* newChromosome = new Schedule( *this, true );

            //// place classes at random position
            //const list<CourseClass*>& c = Configuration::GetInstance().GetCourseClasses();
            //for( list<CourseClass*>::const_iterator it = c.begin(); it != c.end(); it++ )
            //{
            //    // determine random position of class
            //    int nr = Configuration::GetInstance().GetNumberOfRooms();
            //    int dur = ( *it )->GetDuration();
            //    int day = rand() % DAYS_NUM;
            //    int room = rand() % nr;
            //    int time = rand() % ( DAY_HOURS + 1 - dur );
            //    int pos = day * nr * DAY_HOURS + room * DAY_HOURS + time;

            //    // fill time-space slots, for each hour of class
            //    for( int i = dur - 1; i >= 0; i-- )
            //        newChromosome->_slots.at( pos + i ).push_back( *it );

            //    // insert in class table of chromosome
            //    newChromosome->_classes.insert( pair<CourseClass*, int>( *it, pos ) );
            //}

            //newChromosome->CalculateFitness();

            //// return smart pointer
            //return newChromosome;
            return null;
        }

        // Performes crossover operation using to chromosomes and returns pointer to offspring
        public Schedule Crossover(Schedule parent2)
        {
            //        // check probability of crossover operation
            //if( rand() % 100 > _crossoverProbability )
            //    // no crossover, just copy first parent
            //    return new Schedule( *this, false );

            //// new chromosome object, copy chromosome setup
            //Schedule* n = new Schedule( *this, true );

            //// number of classes
            //int size = (int)_classes.size();

            //vector<bool> cp( size );

            //// determine crossover point (randomly)
            //for( int i = _numberOfCrossoverPoints; i > 0; i-- )
            //{
            //    while( 1 )
            //    {
            //        int p = rand() % size;
            //        if( !cp[ p ] )
            //        {
            //            cp[ p ] = true;
            //            break;
            //        }
            //    }
            //}

            //hash_map<CourseClass*, int>::const_iterator it1 = _classes.begin();
            //hash_map<CourseClass*, int>::const_iterator it2 = parent2._classes.begin();

            //// make new code by combining parent codes
            //bool first = rand() % 2 == 0;
            //for( int i = 0; i < size; i++ )
            //{
            //    if( first )
            //    {
            //        // insert class from first parent into new chromosome's calss table
            //        n->_classes.insert( pair<CourseClass*, int>( ( *it1 ).first, ( *it1 ).second ) );
            //        // all time-space slots of class are copied
            //        for( int i = ( *it1 ).first->GetDuration() - 1; i >= 0; i-- )
            //            n->_slots[ ( *it1 ).second + i ].push_back( ( *it1 ).first );
            //    }
            //    else
            //    {
            //        // insert class from second parent into new chromosome's calss table
            //        n->_classes.insert( pair<CourseClass*, int>( ( *it2 ).first, ( *it2 ).second ) );
            //        // all time-space slots of class are copied
            //        for( int i = ( *it2 ).first->GetDuration() - 1; i >= 0; i-- )
            //            n->_slots[ ( *it2 ).second + i ].push_back( ( *it2 ).first );
            //    }

            //    // crossover point
            //    if( cp[ i ] )
            //        // change soruce chromosome
            //        first = !first;

            //    it1++;
            //    it2++;
            //}

            //n->CalculateFitness();

            //// return smart pointer to offspring
            //return n;
            return null;
        }

        // Performs mutation on chromosome
        public void Mutation()
        {
            //        // check probability of mutation operation
            //if( rand() % 100 > _mutationProbability )
            //    return;

            //// number of classes
            //int numberOfClasses = (int)_classes.size();
            //// number of time-space slots
            //int size = (int)_slots.size();

            //// move selected number of classes at random position
            //for( int i = _mutationSize; i > 0; i-- )
            //{
            //    // select ranom chromosome for movement
            //    int mpos = rand() % numberOfClasses;
            //    int pos1 = 0;
            //    hash_map<CourseClass*, int>::iterator it = _classes.begin();
            //    for( ; mpos > 0; it++, mpos-- )
            //        ;

            //    // current time-space slot used by class
            //    pos1 = ( *it ).second;

            //    CourseClass* cc1 = ( *it ).first;

            //    // determine position of class randomly
            //    int nr = Configuration::GetInstance().GetNumberOfRooms();
            //    int dur = cc1->GetDuration();
            //    int day = rand() % DAYS_NUM;
            //    int room = rand() % nr;
            //    int time = rand() % ( DAY_HOURS + 1 - dur );
            //    int pos2 = day * nr * DAY_HOURS + room * DAY_HOURS + time;

            //    // move all time-space slots
            //    for( int i = dur - 1; i >= 0; i-- )
            //    {
            //        // remove class hour from current time-space slot
            //        list<CourseClass*>& cl = _slots[ pos1 + i ];
            //        for( list<CourseClass*>::iterator it = cl.begin(); it != cl.end(); it++ )
            //        {
            //            if( *it == cc1 )
            //            {
            //                cl.erase( it );
            //                break;
            //            }
            //        }

            //        // move class hour to new time-space slot
            //        _slots.at( pos2 + i ).push_back( cc1 );
            //    }

            //    // change entry of class table to point to new time-space slots
            //    _classes[ cc1 ] = pos2;
        }

        // Calculates fitness value of chromosome
        public void CalculateFitness()
        {
            //            // chromosome's score
            //    int score = 0;

            //    int numberOfRooms = Configuration::GetInstance().GetNumberOfRooms();
            //    int daySize = DAY_HOURS * numberOfRooms;

            //    int ci = 0;

            //    // check criterias and calculate scores for each class in schedule
            //    for( hash_map<CourseClass*, int>::const_iterator it = _classes.begin(); it != _classes.end(); ++it, ci += 5 )
            //    {
            //        // coordinate of time-space slot
            //        int p = ( *it ).second;
            //        int day = p / daySize;
            //        int time = p % daySize;
            //        int room = time / DAY_HOURS;
            //        time = time % DAY_HOURS;

            //        int dur = ( *it ).first->GetDuration();

            //        // check for room overlapping of classes
            //        bool ro = false;
            //        for( int i = dur - 1; i >= 0; i-- )
            //        {
            //            if( _slots[ p + i ].size() > 1 )
            //            {
            //                ro = true;
            //                break;
            //            }
            //        }

            //        // on room overlaping
            //        if( !ro )
            //            score++;

            //        _criteria[ ci + 0 ] = !ro;

            //        CourseClass* cc = ( *it ).first;
            //        Room* r = Configuration::GetInstance().GetRoomById( room );
            //        // does current room have enough seats
            //        _criteria[ ci + 1 ] = r->GetNumberOfSeats() >= cc->GetNumberOfSeats();
            //        if( _criteria[ ci + 1 ] )
            //            score++;

            //        // does current room have computers if they are required
            //        _criteria[ ci + 2 ] = !cc->IsLabRequired() || ( cc->IsLabRequired() && r->IsLab() );
            //        if( _criteria[ ci + 2 ] )
            //            score++;

            //        bool po = false, go = false;
            //        // check overlapping of classes for professors and student groups
            //        for( int i = numberOfRooms, t = day * daySize + time; i > 0; i--, t += DAY_HOURS )
            //        {
            //            // for each hour of class
            //            for( int i = dur - 1; i >= 0; i-- )
            //            {
            //                // check for overlapping with other classes at same time
            //                const list<CourseClass*>& cl = _slots[ t + i ];
            //                for( list<CourseClass*>::const_iterator it = cl.begin(); it != cl.end(); it++ )
            //                {
            //                    if( cc != *it )
            //                    {
            //                        // professor overlaps?
            //                        if( !po && cc->ProfessorOverlaps( **it ) )
            //                            po = true;

            //                        // student group overlaps?
            //                        if( !go && cc->GroupsOverlap( **it ) )
            //                            go = true;

            //                        // both type of overlapping? no need to check more
            //                        if( po && go )
            //                            goto total_overlap;
            //                    }
            //                }
            //            }
            //        }

            //total_overlap:

            //        // professors have no overlaping classes?
            //        if( !po )
            //            score++;
            //        _criteria[ ci + 3 ] = !po;

            //        // student groups has no overlaping classes?
            //        if( !go )
            //            score++;
            //        _criteria[ ci + 4 ] = !go;
            //    }

            //    // calculate fitess value based on score
            //    _fitness = (float)score / ( Configuration::GetInstance().GetNumberOfCourseClasses() * DAYS_NUM );
        }
    }
}
