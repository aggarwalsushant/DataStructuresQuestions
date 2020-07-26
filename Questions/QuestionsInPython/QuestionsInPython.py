print('Start question')

# https://practice.geeksforgeeks.org/problems/inversion-of-array/0/
def Inversion_Of_Array(array):
    counter = 0

    for fixed in range(0, len(array)-1):
        for mover in range(fixed+1, len(array)):
            if array[fixed]>array[mover]:
                counter += 1

    print(counter)

def Accept_Inputs_And_Run_Code():
    for _ in range(int(input())):
        arrayLen = int(input())
        array = list(map(int, input().split()))
        Inversion_Of_Array(array);

Accept_Inputs_And_Run_Code()