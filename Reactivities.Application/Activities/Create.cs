﻿using MediatR;
using Reactivities.Domain.Activities;
using Reactivities.Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reactivities.Application.Activities
{
	public class Create
	{
		public class Command : IRequest {
			public Activity Activity { get; set; }
		}

		public class Handler : IRequestHandler<Command>
		{
			private readonly DataContext _context;
			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
			{
				_context.Activities.Add(request.Activity);

				await _context.SaveChangesAsync();

				return Unit.Value;
			}
		}
	}
}
