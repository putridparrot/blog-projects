type Choice = 'A' | 'B' | 'C';

function unreachable(param: never): never { 
    throw new Error('should not reach here')
}

function makeChoice(choice: Choice) {
  switch(choice) {
    case 'A': return 'A selected'
    case 'B': return 'B selected'
    case 'C': return 'C selected'
  }
  let c: never = choice;

  unreachable(choice);
}

makeChoice('C');

