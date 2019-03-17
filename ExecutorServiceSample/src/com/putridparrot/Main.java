package com.putridparrot;

import java.util.concurrent.*;

public class Main {

    public static void main(String[] args) throws InterruptedException, ExecutionException {
        System.out.println("Main Thread - " + Thread.currentThread().getId());
        System.out.println("Processors - " + Runtime.getRuntime().availableProcessors());

        //ExecutorService executorService = Executors.newSingleThreadExecutor();
        ExecutorService executorService = Executors.newFixedThreadPool(Runtime.getRuntime().availableProcessors());

        Future<?> f1 = executorService.submit(() -> outputInformation(1));

        Future<?> f2 = executorService.submit(() -> outputInformation(2));

        Future<?> f3 = executorService.submit(() -> outputInformation(3));

        f1.get();
        f2.get();
        f3.get();

        executorService.shutdown();
    }

    private static void outputInformation(int id) {
        try {
            // some arbitrary time wasting
            Thread.sleep(2000);
            System.out.println(id + " - " + Thread.currentThread().getId());
        }catch (Exception e) {
        }
    }
}
