package com.putridparrot;

import cucumber.api.java.Before;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;
import org.junit.Assert;

public class AddStepDefs {

    private ScenarioContext context;

    public AddStepDefs(ScenarioContext context) {
        this.context = context;
    }

    @Given("^Two input values, (-?\\d+) and (-?\\d+)$")
    public void twoInputValuesAnd(int a, int b) throws Throwable {
        context.setValue1(a);
        context.setValue2(b);
    }

    @When("^I add the two values$")
    public void iAddTheTwoValues() throws Throwable {
        Calculator calculator = new Calculator();

        context.setResult(calculator.add(context.getValue1(), context.getValue2()));
    }

    @Then("^I expect the result (-?\\d+)$")
    public void iExpectTheResult(int r) throws Throwable {
        Assert.assertEquals(r, context.getResult());
    }
}

// code before we added pico container
//public class AddStepDefs {
//
//    private Calculator calculator;
//    private int value1;
//    private int value2;
//    private int result;
//
//    @Before
//    public void before() {
//        calculator = new Calculator();
//    }
//
//    @Given("^Two input values, (-?\\d+) and (-?\\d+)$")
//    public void twoInputValuesAnd(int arg0, int arg1) throws Throwable {
//        value1 = arg0;
//        value2 = arg1;
//    }
//
//    @When("^I add the two values$")
//    public void iAddTheTwoValues() throws Throwable {
//        result = calculator.add(value1, value2);
//    }
//
//    @Then("^I expect the result (-?\\d+)$")
//    public void iExpectTheResult(int arg0) throws Throwable {
//        Assert.assertEquals(arg0, result);
//    }
//}