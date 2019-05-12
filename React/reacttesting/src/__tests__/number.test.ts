export function getNumber(): number {
    return 1234;
}

it('Test 2', () => {
    expect(getNumber()).toEqual(1234);
});