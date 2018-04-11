package com.putridparrot;

import org.jmock.Expectations;
import org.jmock.Mockery;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertEquals;


public class CalculatorTest {

    private Mockery mockery;

    @Before
    public void setUp() {
        mockery = new Mockery();
    }

    @After
    public void tearDown() {
        mockery.assertIsSatisfied();
    }

    @Test
    public void add() {

        final Calculator calc = mockery.mock(Calculator.class);

        mockery.checking(new Expectations()
        {
            {
                oneOf(calc).add(2.0, 4.0);
                will(returnValue(6.0));
            }
        });

        double result = calc.add(2, 4);

        assertEquals(6.0, result, 0);
    }

    @Test
    public void random() {
        final Calculator calc = mockery.mock(Calculator.class);

        mockery.checking(new Expectations()
        {
            {
                exactly(3)
                   .of(calc)
                   .random();

                will(onConsecutiveCalls(
                    returnValue(4),
                    returnValue(10),
                    returnValue(42)
                ));
            }
        });

        assertEquals(4, calc.random());
        assertEquals(10, calc.random());
        assertEquals(42, calc.random());
    }
}
