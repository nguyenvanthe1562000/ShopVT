namespace Model.Command
{
    public class BaseCommand
    {
        public virtual int UserId { get; set; }
        public virtual string TableName { get; set; }
    } 
}