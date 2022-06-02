namespace ItemsClassifier
{
    public class ListItem
    {
        public ListItem(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}
