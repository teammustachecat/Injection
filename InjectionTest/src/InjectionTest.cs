using NUnit.Framework;
using MustacheCat.Core.Injection;
using System.Collections.Generic;

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

      var removed = injector.Remove<TestClass>();
      Assert.AreSame(original, removed);
      Assert.Throws<KeyNotFoundException>(new TestDelegate(() => injector.Inject<TestClass>()));
    }

    [Test()]
    public void TestRegisterInjectByString () {
      var original = new TestClass();
      injector.Register("testClassService", original);

      var injected = injector.Inject<TestClass>("testClassService");
      Assert.AreSame(original, injected);

      var removed = injector.Remove<TestClass>("testClassService");
      Assert.AreSame(original, removed);
      Assert.Throws<KeyNotFoundException>(new TestDelegate(() => injector.Inject<TestClass>("testClassService")));
    }
  }
}
