import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;

@RunWith(MinimalRunner.class)
public class MyTest {
    @Test
    public void testFailure() {
        // ensure the test runner handles success
        Assert.assertTrue(false);
    }

    @Test
    public void testSuccess() {
        // ensure the test runner handles success
        Assert.assertTrue(true);
    }
}
