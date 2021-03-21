namespace Tank
{
    class Person
    {
        public string Name { get; set; }
    }
    
    class People
    {
        Person[] data;
        
        public People()
        {
            data = new Person[5];
        }
        
        public Person this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }
    }
}