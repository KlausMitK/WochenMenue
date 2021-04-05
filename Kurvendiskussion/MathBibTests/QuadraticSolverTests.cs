using NUnit.Framework;
using MathBib;
using System.Collections.Generic;


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
            QuadraticSolver solver = new QuadraticSolver(2, 1, 1);
            List<double> result = solver.Solve();
            Assert.AreEqual(result.Count, 0);   
        }

        [Test]
        public void TestOneSolution()
        {
            QuadraticSolver solver = new QuadraticSolver(1, 2, 1);
            List<double> result = solver.Solve();
            Assert.AreEqual(result.Count, 1);
            double x1 = result[0];
            Assert.AreEqual(x1, -1);
        }

        [Test]
        public void TestTwoSolution()
        {
            QuadraticSolver solver = new QuadraticSolver(4, 5, 1);
            List<double> result = solver.Solve();
            Assert.AreEqual(result.Count, 2);
            double x1 = result[0];
            double x2 = result[1];
            Assert.AreEqual(x1, -0, 25);
            Assert.AreEqual(x2, -1);
        }

        [Test]
        public void TestaIsZero()
        {
            QuadraticSolver solver = new QuadraticSolver(0, 2, 4);
            List<double> result = solver.Solve();
            Assert.AreEqual(result.Count, 1);
            double x1 = result[0];
            Assert.AreEqual(x1, -2);
        }

        [Test]
        public void TestaAndbAreZero()
        {
            QuadraticSolver solver = new QuadraticSolver(0, 0, 2);
            List<double> result = solver.Solve();
            Assert.AreEqual(result.Count, 0);
        }
    }
}