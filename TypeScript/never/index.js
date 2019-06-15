function unreachable(param) {
    throw new Error('should not reach here');
}
function makeChoice(choice) {
    switch (choice) {
        case 'A': return 'A selected';
        case 'B': return 'B selected';
        case 'C': return 'C selected';
    }
    var c = choice;
    unreachable(choice);
}
makeChoice('C');
