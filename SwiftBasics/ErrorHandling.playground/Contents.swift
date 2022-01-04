import Foundation
enum SomeErrors: Error {
    case BasicError
    case WithCodeError(errorCode: Int)
}

func thingsBreak(value: Int) throws -> Void {
    guard value > 0 else {
        throw SomeErrors.BasicError
    }
    throw SomeErrors.WithCodeError(errorCode: value)
}

do {
    // causes basic error
    // try thingsBreak(value: 0)
    // causes with code error
    try thingsBreak(value: 10)
} catch SomeErrors.BasicError {
    print("Basic error detected")
} catch SomeErrors.WithCodeError(let errorCode) {
    print("With code error detected, code \(errorCode)")
}
