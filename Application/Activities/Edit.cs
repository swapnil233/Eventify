using MediatR;
using Domain;
using Persistence;
using AutoMapper;

namespace Application.Activities;

public class Edit
{
    public class Command : IRequest
    {
        public Activity Activity { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            // Get the activity from DB
            var activity = await _context.Activities.FindAsync(request.Activity.Id);

            // Update using AutoMapper
            _mapper.Map(request.Activity, activity);

            // Save changes
            await _context.SaveChangesAsync();

            // Notify API
            return Unit.Value;
        }
    }
}
