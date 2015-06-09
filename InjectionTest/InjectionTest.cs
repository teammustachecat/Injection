using System;
using NUnit.Framework;
using MustacheCat.Core.Injection;

namespace InjectionTest {

  public class TestClass {}
  public class TestCreateClass {}

  [TestFixture()]
  public class TestInjector {
    [Test()]
    public void TestRegisterInject () {
      var injector = new Injector();
      var original = new TestClass();
      injector.Register<TestClass>(original);
      var injected = injector.Inject<TestClass>();
      Assert.AreSame(original, injected);

      var t1 = injector.InjectOrCreate<TestCreateClass>();
      Assert.IsNotNull(t1);
      var t2 = injector.InjectOrCreate<TestCreateClass>();
      Assert.AreSame(t1, t2);
    }
  }
}
