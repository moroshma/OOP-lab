namespace lab_1_3
{

    internal class Tree
    {
        public List<Tree> Trees;

        public Tree(int a)
        {
            Variable = a;
            Trees = new List<Tree>();
        }

        public int Variable { get; set; }

        public void Print()
        {
            Console.WriteLine(Variable);
            foreach (var t in Trees) t.Print();
        }
    }
}