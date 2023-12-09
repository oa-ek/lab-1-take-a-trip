﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTripAsp.Application.Features.BookingFeatures.Commands.DeleteBookings
{
    public class DeleteBookingsCommand 
        : IRequest<int>
    {
        public int Id { get; set; }
    }
}
