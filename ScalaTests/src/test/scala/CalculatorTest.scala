import org.scalatest.FunSuite

class CalculatorTest extends FunSuite {

  test("testAdd") {
    val calc = new Calculator

    assert(calc.add(1, 2) == 3)
  }

  test("testSubtract") {
    val calc = new Calculator

    assert(calc.subtract(5, 4) == 1)
  }
}
