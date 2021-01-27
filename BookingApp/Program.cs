using System;

namespace BookingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("Please enter size of your hotel: ");

            int hotelSize;
            while (!int.TryParse(Console.ReadLine(), out hotelSize) || hotelSize > 1000)
            {
                Console.WriteLine("Bad data: size should be a number less than 10000");
                Console.WriteLine("Please enter size of your hotel: ");
            }
            Hotel hotel = new Hotel(hotelSize);

            while (true)
            {
                Console.Write("Enter 'y' if you want to make a reservation, 'n' for termination: ");
                string makeReservation = Console.ReadLine();

                if (makeReservation.ToLower().Equals("y"))
                {
                    try
                    {
                        Console.Write("Enter start day: ");
                        int startDay = int.Parse(Console.ReadLine());

                        Console.Write("Enter end day: ");
                        int endDay = int.Parse(Console.ReadLine());

                        bool reservationAccepted = hotel.IsReservationAccepted(startDay, endDay);
                        string acceptance = reservationAccepted ? "accepted" : "declined";
                        Console.WriteLine("Your reservation is {0}", acceptance);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Bad data");
                    }
                }
                else if (makeReservation.ToLower().Equals("n"))
                {
                    break;
                }

            }

        }
    }
}
