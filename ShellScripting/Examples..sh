#!/bin/bash

# what's the current shell
echo "Current Shell:" $SHELL
# string interpolation style
echo "Current Shell: $SHELL"

# variables
#VARIABLE1 = "Hello" # will result in "command not found"
VARIABLE1="Hello"
variable2="World"

echo $VARIABLE1 $variable2

# numerical variables
i=0
let "i=i+1"
#OR
i=$((i+1))

let "i++"
#OR
((i++))
#OR
let "i+=1"
#OR
((i+=1))
echo $i # should be 6

# logic operations
if [ $i = 6 ]
then
   echo "i is correctly set to 6"
fi

if [ $i -eq 6 ]
then
   echo "i is correctly set to 6"
fi
test i=6; echo "i is correctly set to 6"

if [ $i -lt 10 ]
then
   echo "i is less than 10"
fi

if [ ! -d "BAK" ]
then
   echo "BAK does not exist"
else
   echo "BAK exists"
fi

say_hello()
{
    echo "say_hello called"
}

say_hello

say_something()
{
    echo "say_someting says $1 $2"
    echo "$@"
}

say_something Hello World

# call shell command
echo "Running ls -a"
for i in $( ls ); do
   echo item: $i
done

for entry in "."/*
do
  echo "$entry"
done

echo "While loop"
i=0
while [ $i -lt 10 ]
do
   echo $i
   ((i++))
done

echo "Until loop"
until [ $i -lt 0 ]
do
   echo $i
   ((i--))
done

echo "for loop using an array as input"
array=("a" "b" "c")

echo "Array element at index 1 is ${array[1]}"

for item in ${array[@]}
do
  echo $item
done

echo "ls -a"
for item in $(ls -a)
do
   echo $item
done

echo "Better file loop"
for item in ${PWD}/*
do
   echo $item
done

echo "Using seq syntax"
for item in `seq 1 10`;
do
   echo $item
done

echo "Current i"
echo $i
unset i
echo "Unset i"
echo $i

echo "Starting merge from ${PWD}"
