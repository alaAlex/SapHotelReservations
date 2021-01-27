using System.Collections.Generic;
using System.Linq;

namespace BookingApp
{
    public class Hotel
    {

        #region Poperties

        /// <summary>
        /// Schedule is represented as a dictionary where:
        /// keys are days
        /// values are rooms which are booked on that day
        /// </summary>
        public Dictionary<int, HashSet<int>> Schedule { get; private set; }

        /// <summary>
        /// List of all rooms
        /// </summary>
        public HashSet<int> Rooms { get; private set; }

        /// <summary>
        /// Number of hotel rooms
        /// </summary>
        public int Size { get; private set; }

        #endregion Poperties

        #region Constructor

        public Hotel(int size)
        {
            Schedule = new Dictionary<int, HashSet<int>>();
            Rooms = new HashSet<int>();
            Size = size;
            InitializeRoomsAndSchedule();
        }

        #endregion Constructor

        #region Initialization

        private void InitializeRoomsAndSchedule()
        {
            for (int i = 0; i <= 364; i++)
                Schedule.Add(i, new HashSet<int>());

            for (int i = 1; i <= Size; i++)
                Rooms.Add(i);
        }

        #endregion Initialization

        #region Methods

        /// <summary>
        /// Checks if reservation is accepted
        /// </summary>
        /// <param name="startDay"></param>
        /// <param name="endDay"></param>
        /// <returns></returns>
        public bool IsReservationAccepted(int startDay, int endDay)
        {
            // check if entered data is correct
            if (startDay > endDay || !IsDayInRange(startDay) || !IsDayInRange(endDay))
                return false;

            HashSet<int> requestedDays = new HashSet<int>();
            for (int i = startDay; i <= endDay; i++)
                requestedDays.Add(i);

            // find rooms that are avalable every day of the requested days
            HashSet<int> availableRooms = new HashSet<int>(Rooms);

            foreach (int day in requestedDays)
                availableRooms.ExceptWith(Schedule[day]); // exclude the ones that are reserved

            if (availableRooms.Count == 0)
                return false;

            int chosenRoom = availableRooms.FirstOrDefault();

            // check if we can schedule without holes
            if (startDay > 0)
            {
                availableRooms.IntersectWith(Schedule[startDay - 1]);
                if (availableRooms.Count > 0)
                    chosenRoom = availableRooms.FirstOrDefault();
            }

            foreach (int day in requestedDays)
                Schedule[day].Add(chosenRoom);


            return true;
        }

        private bool IsDayInRange(int day)
        {
            return day >= 0 && day < 365;
        }

        #endregion Methods
    }
}
