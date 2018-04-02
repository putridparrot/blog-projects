package com.putridparrot

import kotlin.test.assertEquals
import org.junit.Test as test

class TestCalculator() {
    @test fun testAdd() {
        val c = Calculator()

        assertEquals(c.add(5, 2), 7)
    }
}