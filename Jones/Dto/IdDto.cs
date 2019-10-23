namespace Jones.Dto
{
    public class IdDto<T>
    {
        public T Id { get; }

        public IdDto(T id)
        {
            Id = id;
        }
    }
    
    public class IdDto : IdDto<int>
    {
        public IdDto(int id) : base(id)
        {
        }
    }

    public class IdStringDto : IdDto<string>
    {
        public IdStringDto(string id) : base(id)
        {
        }
    }
}