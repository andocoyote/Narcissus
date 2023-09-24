using Narcissus.UserInterface;

namespace Narcissus.TestInterface
{
    public class TestInterface : IUserInterface
    {

        public TestInterface()
        {

        }

        public async Task<bool> Run()
        {
            return true;
        }

        public async Task TestTask()
        {

        }
    }
}
