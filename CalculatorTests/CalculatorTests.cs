using ClassLibraryExample;

namespace ClassLibraryTests
{
    public class Tests
    {
        [Test]
        public void ShouldAddNumbers()
        {
            // Arrange
            var a = 1;
            var b = 2;
            var expected = a + b;
            var calculator = new Calculator();

            // Act
            var actual = calculator.Add(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("TroubleMaker")]
        public void TroubleMaker()
        {
            // Arrange
            using var unhandledExceptionRaised = new ManualResetEventSlim();
            void tempHandler(object o, UnhandledExceptionEventArgs e)
            {
                unhandledExceptionRaised.Set();
            }
            AppDomain.CurrentDomain.UnhandledException += tempHandler;

            var thread = new Thread(() => { throw new ApplicationException(); });
            thread.Start();
            unhandledExceptionRaised.Wait(1000 * 5);

            // Act
            AppDomain.CurrentDomain.UnhandledException -= tempHandler;

            // Assert
        }
    }
}