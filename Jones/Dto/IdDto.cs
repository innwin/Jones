namespace Jones.Dto
{
    public class IdDto<T>
    {
        public T Id { get; set; }
    }
    
    public class IdDto : IdDto<int>
    {
    }

    public class IdStringDto : IdDto<string>
    {
    }
}