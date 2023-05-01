namespace Data_Model.Abstract
{
    public abstract class DatabaseItem : SimpleDatabaseItem
    {
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
