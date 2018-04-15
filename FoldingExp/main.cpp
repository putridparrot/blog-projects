#include <iostream>

template<typename... Args>
auto unary_right_fold(Args... args) {
    return (args + ...);
}

template<typename... Args>
auto unary_left_fold(Args... args) {
    return (... + args);
}

template<typename... Args>
auto binary_right_fold(Args... args) {
    return (args + ... + 1);
}

template<typename... Args>
auto binary_left_fold(Args... args) {
    return (1 + ... + args);
}

template<typename... Args>
auto sum(Args... args) {
    return (... + args);
}

int main() {
    //std::cout << binary_right_fold(1.0, 2.0f, 3);
    std::cout << sum(1, 2.2, 3) << std::endl;
    return 0;
}