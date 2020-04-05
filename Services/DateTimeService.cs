using System;

namespace model_validation_tutorial.Services
{
   public class DateTimeService : IDateTimeService
   {
      public DateTime CurrentTime()
      {
         return DateTime.UtcNow.AddHours(7);
      }
   }
}