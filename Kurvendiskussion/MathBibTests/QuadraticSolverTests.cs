using NUnit.Framework;
using MathBib;


namespace MathBibTests
{
    public class QuadraticSolverTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //QuadraticTests

        [Test]
        public void TestNoSolution()
        {
            //TODO: Implement Test for the case discriminante < 0;
            QuadraticSolver solver = new QuadraticSolver(1, 2, 3);
            Assert.Pass();
        }

        [Test]
        public void TestOneSolution()
        {
            //TODO: Implement Test for the case discriminante = 0;
            QuadraticSolver solver = new QuadraticSolver(1, 2, 3);
            Assert.Pass();
        }

        [Test]
        public void TestTwoSolution()
        {
            //TODO: Implement Test for the case discriminante > 0;
            QuadraticSolver solver = new QuadraticSolver(1, 2, 3);
            Assert.Pass();
        }
    }
}