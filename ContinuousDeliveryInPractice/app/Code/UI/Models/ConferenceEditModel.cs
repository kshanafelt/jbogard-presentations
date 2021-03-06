using System;

namespace CodeCampServerLite.UI.Models
{
    using MediatR;

    public class ConferenceEditModel : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Sponsor { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public DateTime Date { get; set; }

        public AttendeeEditModel[] Attendees { get; set; }

        public class AttendeeEditModel
        {
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }
    }
}