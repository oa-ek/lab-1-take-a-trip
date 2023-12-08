﻿using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TakeTripAsp.Application.Features.BookingStatusFeatures.Commands.DeleteBookingStatus
{
    public class DeleteBookingStatusCommand
       : IRequest<int>
    {
        public int Id { get; set; }
    }
}
