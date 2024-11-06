namespace CounterApp2.Models
{
    public class CounterData
    {
        public List<CounterModel> Counters { get; set; }

        public CounterData() 
        {
            Counters = new List<CounterModel>();
        }
    }
}
