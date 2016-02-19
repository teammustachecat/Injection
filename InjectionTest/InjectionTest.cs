using NUnit.Framework;
using MustacheCat.Core.Injection;

namespace InjectionTest {

  public class TestClass {}

  [TestFixture()]
  public class TestInjector {
    private Injector injector;

    [SetUp()]
    public void BeforeEach () {
      injector = new Injector();
    }

    [Test()]
    public void TestRegisterInjectByType () {
      var original = new TestClass();
      injector.Register<TestClass>(original);
      var injected = injector.Inject<TestClass>();
      Assert.AreSame(original, injected);
    }

    [Test()]
    public void TestRegisterInjectByString () {
      var original = new TestClass();
      injector.Register("testClassService", original);
      var injected = injector.Inject<TestClass>("testClassService");
      Assert.AreSame(original, injected);
    }
  }
}
