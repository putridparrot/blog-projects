#include <iostream>
#include <thread>
#include <future>

int main() {
    std::cout << "Starting..." << std::endl;

    auto promise = std::promise<std::string>();
    auto producer = std::thread([&]
        {
            // simulate some long-ish running task
            std::this_thread::sleep_for(std::chrono::seconds(5));
            promise.set_value("Some Message");
         });

    auto future = promise.get_future();
    auto consumer = std::thread([&]
        {
            std::cout << future.get().c_str();
        });

    // for testing, we'll block the current thread
    // until these have completed
    producer.join();
    consumer.join();

    return 0;
}