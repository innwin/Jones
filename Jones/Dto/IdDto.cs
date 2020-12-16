namespace Jones.Dto
{
    public record IdDto<T>
    {
        public T Id { get; }

        public IdDto(T id)
        {
            Id = id;
        }
    }
    
    public record IdDto : IdDto<int>
    {
        public IdDto(int id) : base(id)
        {
        }
    }

    public record IdStringDto : IdDto<string>
    {
        public IdStringDto(string id) : base(id)
        {
        }
    }
}