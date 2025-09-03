using AutoMapper;
using TaskManagerApi.Data.Dtos.TaskOnDto;

namespace TaskManagerApi.Profiles
{
    public class TaskProfile:Profile
    {
        public TaskProfile()
        {
            CreateMap<Task,TaskReadDto>();
            CreateMap<CreatedTaskDto,Task>();
            CreateMap<UpdateTaskDto,Task>();    
        }
    }
}
