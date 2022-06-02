namespace ItemsClassifier
{
    public class ItemModel
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ListItem PredictCategory { get; set; }
        public ListItem PredictCategoryByDescription { get; set; }
    }
}
