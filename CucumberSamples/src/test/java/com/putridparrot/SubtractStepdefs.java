package com.putridparrot;

import cucumber.api.java.en.When;

public class SubtractStepdefs {

    private ScenarioContext context;

    public SubtractStepdefs(ScenarioContext context) {
        this.context = context;
    }

    @When("^I subtract the two values$")
    public void iSubtracTheTwoValues()  {
        Calculator calculator = new Calculator();

        context.setResult(calculator.subtract(context.getValue1(), context.getValue2()));
    }
}
