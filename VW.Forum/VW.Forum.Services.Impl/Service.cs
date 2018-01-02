using AutoMapper;
using VW.Forum.Data;

namespace VW.Forum.Services.Impl
{
	public abstract class Service : IService
	{
		protected Service(VwForumDbContext context, IMapper mapper)
		{
			Context = context;
			Mapper = mapper;
		}

		public VwForumDbContext Context { get; }

		public IMapper Mapper { get; }
	}
}
