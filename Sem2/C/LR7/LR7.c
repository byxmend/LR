#define _CRT_SECURE_NO_WARNINGS

#include<stdio.h>
#include<math.h>
#include<stdlib.h>
#include<string.h>
#include<malloc.h>

typedef struct node
{
    int flightNumber;
    int typeOfPlane; // number of seats
    int numberOfTickets;
    char startLocation[20];
    char finishLocation[20];
    char place[20];
    char time[20];
    char date[20];
    struct node* pNext;
    struct node* pPrev;
} Node;

typedef struct informationAboutSchedule
{
    Node* head;
    Node* tail;
    Node* top;
} InformationAboutSchedule; 

void pushBack(InformationAboutSchedule* schedules, Node* node)
{
    node->pNext = NULL;
    node->pPrev = NULL;
    Node* currant = (Node*)malloc(sizeof(Node));

    currant->flightNumber = node->flightNumber;
    currant->typeOfPlane = node->typeOfPlane;
    currant->numberOfTickets = 0;
    strcpy(currant->startLocation, node->startLocation);
    strcpy(currant->finishLocation, node->finishLocation);
    strcpy(currant->place, node->place);
    strcpy(currant->time, node->time);
    strcpy(currant->date, node->date);

    currant->pNext = NULL;
    currant->pPrev = NULL;

    if (schedules->head == NULL)
    {
        schedules->head = currant;
        schedules->top = currant;
        schedules->tail = currant;
    }
    else
    {
        currant->pPrev = schedules->top;
        schedules->top->pNext = currant;
        schedules->top = currant;
        schedules->tail = currant;
    }
}

void printElementOfList(InformationAboutSchedule schedules, int counter)
{
    Node* p = schedules.head;

    for (int i = 0; i < counter; i++)
    {
        p = p->pNext;
    }

    printf("\n1. Flight number: %d", p->flightNumber);
    printf("\n2. Type of plane: %d", p->typeOfPlane);
    printf("\n3. Start location: %s", p->startLocation);
    printf("\n4. Finish location: %s", p->finishLocation);
    printf("\n5. Place: %s", p->place);
    printf("\n6. Time: %s", p->time);
    printf("\n7. Date: %s", p->date);
}

// flightNumber
void findByFlightNumber(InformationAboutSchedule schedules, int numb)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (p->flightNumber == numb)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

// typeOfPlane
void findByTypeOfPlane(InformationAboutSchedule schedules, int numb)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (p->typeOfPlane == numb)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

// startLocation
void findByStartLocation(InformationAboutSchedule schedules, char* str)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (strcmp(str, p->startLocation) == 0)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

// finishLocation
void findByFinishLocation(InformationAboutSchedule schedules, char* str)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (strcmp(str, p->finishLocation) == 0)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

// place
void findByPlace(InformationAboutSchedule schedules, char* str)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (strcmp(str, p->place) == 0)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

// time
void findByTime(InformationAboutSchedule schedules, char* str)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (strcmp(str, p->time) == 0)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

// date
void findByDate(InformationAboutSchedule schedules, char* str)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (strcmp(str, p->date) == 0)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

void numberOfAvailableSeats(InformationAboutSchedule schedules)
{
    Node* p = schedules.head;
    int numbOfSeats;

    while (1)
    {
        if (p->pNext == NULL)
        {
            break;
        }

        numbOfSeats = p->typeOfPlane - p->numberOfTickets;

        printf("\n\nFlight number: %d", p->flightNumber);
        printf("\nNumber of available seats: %d", numbOfSeats);

        p = p->pNext;
    }
}

// nearest flight
void findNearestFlight(InformationAboutSchedule schedules, char* strStartLocation, char* strFinishLocation)
{
    Node* p = schedules.head;
    Node* e;
    int counter = 0, numberOfDates = 1;
    int firstMonthNumber = 12, firstDayNumber = 31;
    int secondMonthNumber = 0, secondDayNumber = 0;
    int secondMonthFirstNumber = 0, secondMonthSecondNumber = 0;
    int secondDayFirstNumber = 0, secondDaySecondNumber = 0;

    printf("\nAll flight dates:\n");

    while (p != NULL)
    {
        if (strcmp(strStartLocation, p->startLocation) == 0 &&
            strcmp(strFinishLocation, p->finishLocation) == 0)
        {
            // convert date
            e = p->date;
            char allString[20] = { 0 };
            strcat(allString, e);

            // day
            secondDayFirstNumber = allString[0] - '0';
            secondDaySecondNumber = allString[1] - '0';
            secondDayNumber = (secondDayFirstNumber * 10) + secondDaySecondNumber;

            // month
            secondMonthFirstNumber = allString[3] - '0';
            secondMonthSecondNumber = allString[4] - '0';
            secondMonthNumber = (secondMonthFirstNumber * 10) + secondMonthSecondNumber;

            // check
            if (secondMonthNumber < firstMonthNumber)
            {
                firstMonthNumber = secondMonthNumber;
                firstDayNumber = secondDayNumber;
            }
            else if (secondMonthNumber == firstMonthNumber && secondDayNumber < firstDayNumber)
                firstDayNumber = secondDayNumber;

            // print date
            printf("\n%d. Date: %s", numberOfDates, p->date);
            numberOfDates++;
        }

        p = p->pNext;
        counter++;
    }

    printf("\n\nNearest flight date: ");

    if (firstDayNumber < 10)
        printf("0%d:", firstDayNumber);
    else
        printf("%d:", firstDayNumber);

    if (firstMonthNumber < 10)
        printf("0%d", firstMonthNumber);
    else
        printf("%d", firstMonthNumber);
}

void printAllTickets(InformationAboutSchedule schedules)
{
    Node* p = schedules.head;
    int counter = 0, index = 1;

    while (p != NULL)
    {
        if (p->numberOfTickets > 0)
        {
            printf("\nTicket number #%d", index);
            printElementOfList(schedules, counter);
            printf("8. Number of tickets: %d", p->numberOfTickets);

            index++;
        }

        p = p->pNext;
        counter++;
    }
}

void bookATicket(InformationAboutSchedule* schedules, char* strStartLocation,
    char* strFinishLocation, char* date)
{
    Node* p = schedules->head;
    int counter = 0, numberOfDates = 1, selectedNumber;

    while (p != NULL)
    {
        if (strcmp(strStartLocation, p->startLocation) == 0 &&
            strcmp(strFinishLocation, p->finishLocation) == 0 &&
            strcmp(date, p->date) == 0)
        {
            printf("\n%d. Time: %s", numberOfDates, p->time);
            numberOfDates++;
        }

        p = p->pNext;
        counter++;
    }

    if (numberOfDates == 1)
    {
        printf("\nThere are no flights on this day");
    }
    else
    {
        printf("\n\nChoose the number: ");
        scanf_s("%d", &selectedNumber);

        if (selectedNumber < 1 || selectedNumber > (numberOfDates - 1))
        {
            printf("\nError to book a ticket");
        }

        p = schedules->head;
        counter = 0;
        numberOfDates = 1;

        while (p != NULL && numberOfDates != (selectedNumber + 1))
        {
            if (strcmp(strStartLocation, p->startLocation) == 0 &&
                strcmp(strFinishLocation, p->finishLocation) == 0 &&
                strcmp(date, p->date) == 0)
            {
                numberOfDates++;
            }

            if (numberOfDates == (selectedNumber + 1))
            {
                if (p->numberOfTickets < p->typeOfPlane)
                {
                    p->numberOfTickets++;
                    printf("Ticket ordered successfully!");
                }
                else
                {
                    printf("All seats are reserved");
                }
            }

            p = p->pNext;
            counter++;
        }
    }
}

void handOverATicket(InformationAboutSchedule* schedules, InformationAboutSchedule schedulesSave)
{
    Node* p = schedules->head;
    int selectedNumber, index = 1;

    printAllTickets(schedulesSave);
    printf("\n\nChoose the number: ");
    scanf_s("%d", &selectedNumber);

    while (p != NULL)
    {
        if (p->numberOfTickets > 0)
        {
            index++;
        }

        if (selectedNumber == (index - 1))
        {
            p->numberOfTickets--;
            printf("Ticket passed successfull!");
        }

        p = p->pNext;
    }
}

void menu()
{
    printf("\n1 - Find (flightNumber)\n");
    printf("2 - Find (typeOfPlane)\n");
    printf("3 - Find (startLocation)\n");
    printf("4 - Find (finishLocation)\n");
    printf("5 - Find (place)\n");
    printf("6 - Find (time)\n");
    printf("7 - Find (day)\n");
    printf("8 - Find the nearest flight\n");
    printf("9 - Book a ticket\n");
    printf("10 - Hand over your ticket\n");
    printf("11 - Number of available seats\n");
    printf("12 - Print ticket\n");
    printf("Other - Save in data in the file and exit\n");
}

int main()
{
    char stringFromTheFile[200];
    char stringToFindSomething[20];
    char secondStringToFindSomething[20];
    char thirdStringToFindSomething[20];
    char* next = 0;
    int countFildsOFStructure = 0, numbMenu, numbToFindSomething;

    InformationAboutSchedule schedules = { NULL, NULL, NULL };

    FILE* filePrint;
    FILE* fileWrite;

    // open filePrint
    int errOpenFilePrint = fopen_s(&filePrint, "filePrint.txt", "r");

    if (errOpenFilePrint != 0)
    {
        exit(1);
    }

    // open fileWrite
    int errOpenFileWrite = fopen_s(&fileWrite, "fileWrite.txt", "w");

    if (errOpenFileWrite != 0)
    {
        exit(1);
    }

    // Fill the list from filePrint
    while (!feof(filePrint))
    {
        fgets(stringFromTheFile, 200, filePrint);

        char* s = strtok_s(stringFromTheFile, ",", &next);
        
        Node currant = { 0, 0, "", "", "", "", "", NULL, NULL };
        
        do {
            switch (countFildsOFStructure)
            {
            case 0:
                currant.flightNumber = atoi(s);
                break;
            case 1:
                currant.typeOfPlane = atoi(s);
                break;
            case 2:
                strcat(currant.startLocation, s);
                break;
            case 3:
                strcat(currant.finishLocation, s);
                break;
            case 4:
                strcat(currant.place, s);
                break;
            case 5:
                strcat(currant.time, s);
                break;
            case 6:
                strcat(currant.date, s);
                break;
            }

            countFildsOFStructure++;
        } while (s = strtok_s(0, ",", &next));

        countFildsOFStructure = 0;

        pushBack(&schedules, &currant);
    }

    // algorithm
    menu();

    while (1)
    {
        scanf_s("%d", &numbMenu);

        switch (numbMenu)
        {
        case 1:
            numbToFindSomething = 0;
            scanf_s("%d", &numbToFindSomething);
            findByFlightNumber(schedules, numbToFindSomething);
            break;
        case 2:
            numbToFindSomething = 0;
            scanf_s("%d", &numbToFindSomething);
            findByTypeOfPlane(schedules, numbToFindSomething);
            break;
        case 3:
            gets(stringToFindSomething);
            findByStartLocation(schedules, stringToFindSomething);
            break;
        case 4:
            gets(stringToFindSomething);
            findByFinishLocation(schedules, stringToFindSomething);
            break;
        case 5:
            gets(stringToFindSomething);
            findByPlace(schedules, stringToFindSomething);
            break;
        case 6:
            gets(stringToFindSomething);
            findByTime(schedules, stringToFindSomething);
            break;
        case 7:
            // TODO: (+ "\n")
            gets(stringToFindSomething);
            //
            findByDate(schedules, stringToFindSomething);
            break;
        case 8:
            // TODO:
            gets(stringToFindSomething);
            gets(secondStringToFindSomething);
            findNearestFlight(schedules, stringToFindSomething, secondStringToFindSomething);
            break;
        case 9:
            gets(stringToFindSomething);
            gets(secondStringToFindSomething);
            gets(thirdStringToFindSomething);
            bookATicket(&schedules, "Paris", "Munich", "05.06\n");
            break;
        case 10:
            handOverATicket(&schedules, schedules);
            break;
        case 11:
            numberOfAvailableSeats(schedules);
            break;
        case 12:
            printAllTickets(schedules);
            break;
        default:

            return 0;
        }
    }
}

// TODO: close files
// TODO: clear dynamic memory
// TODO: add (\n)
