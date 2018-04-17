/*
  Serial Event example

 When new serial data arrives, this sketch adds it to a String.
 When a newline is received, the loop prints the string and
 clears it.

 A good test for this is to try it with a GPS receiver
 that sends out NMEA 0183 sentences.

 Created 9 May 2011
 by Tom Igoe

 This example code is in the public domain.

 http://www.arduino.cc/en/Tutorial/SerialEvent

 */
#define ushort word
#define START_COMMAND 0xFD
#define END_COMMAND 0xFE
#define MAX_DATA 0xFC
#define BUFF_LENGTH 100
#define TRIGGER_PIN 8
#define DISTANCE_SENSOR_NUM 2

#define COMMAND_ID_GET_DISTANCE 0x21
#define COMMAND_ID_TURN_DISTANCE_SENSOR 0x22
#define COMMAND_ID_HANDSHAKE 0x10
#define DISTANCE_SENSOR 1

word crctbl[] =
{
    0x0000,0x1021,0x2042,0x3063,0x4084,0x50A5,0x60C6,0x70E7,
    0x8108,0x9129,0xA14A,0xB16B,0xC18C,0xD1AD,0xE1CE,0xF1EF,
    0x1231,0x0210,0x3273,0x2252,0x52B5,0x4294,0x72F7,0x62D6,
    0x9339,0x8318,0xB37B,0xA35A,0xD3BD,0xC39C,0xF3FF,0xE3DE,
    0x2462,0x3443,0x0420,0x1401,0x64E6,0x74C7,0x44A4,0x5485,
    0xA56A,0xB54B,0x8528,0x9509,0xE5EE,0xF5CF,0xC5AC,0xD58D,
    0x3653,0x2672,0x1611,0x0630,0x76D7,0x66F6,0x5695,0x46B4,
    0xB75B,0xA77A,0x9719,0x8738,0xF7DF,0xE7FE,0xD79D,0xC7BC,
    0x48C4,0x58E5,0x6886,0x78A7,0x0840,0x1861,0x2802,0x3823,
    0xC9CC,0xD9ED,0xE98E,0xF9AF,0x8948,0x9969,0xA90A,0xB92B,
    0x5AF5,0x4AD4,0x7AB7,0x6A96,0x1A71,0x0A50,0x3A33,0x2A12,
    0xDBFD,0xCBDC,0xFBBF,0xEB9E,0x9B79,0x8B58,0xBB3B,0xAB1A,
    0x6CA6,0x7C87,0x4CE4,0x5CC5,0x2C22,0x3C03,0x0C60,0x1C41,
    0xEDAE,0xFD8F,0xCDEC,0xDDCD,0xAD2A,0xBD0B,0x8D68,0x9D49,
    0x7E97,0x6EB6,0x5ED5,0x4EF4,0x3E13,0x2E32,0x1E51,0x0E70,
    0xFF9F,0xEFBE,0xDFDD,0xCFFC,0xBF1B,0xAF3A,0x9F59,0x8F78,
    0x9188,0x81A9,0xB1CA,0xA1EB,0xD10C,0xC12D,0xF14E,0xE16F,
    0x1080,0x00A1,0x30C2,0x20E3,0x5004,0x4025,0x7046,0x6067,
    0x83B9,0x9398,0xA3FB,0xB3DA,0xC33D,0xD31C,0xE37F,0xF35E,
    0x02B1,0x1290,0x22F3,0x32D2,0x4235,0x5214,0x6277,0x7256,
    0xB5EA,0xA5CB,0x95A8,0x8589,0xF56E,0xE54F,0xD52C,0xC50D,
    0x34E2,0x24C3,0x14A0,0x0481,0x7466,0x6447,0x5424,0x4405,
    0xA7DB,0xB7FA,0x8799,0x97B8,0xE75F,0xF77E,0xC71D,0xD73C,
    0x26D3,0x36F2,0x0691,0x16B0,0x6657,0x7676,0x4615,0x5634,
    0xD94C,0xC96D,0xF90E,0xE92F,0x99C8,0x89E9,0xB98A,0xA9AB,
    0x5844,0x4865,0x7806,0x6827,0x18C0,0x08E1,0x3882,0x28A3,
    0xCB7D,0xDB5C,0xEB3F,0xFB1E,0x8BF9,0x9BD8,0xABBB,0xBB9A,
    0x4A75,0x5A54,0x6A37,0x7A16,0x0AF1,0x1AD0,0x2AB3,0x3A92,
    0xFD2E,0xED0F,0xDD6C,0xCD4D,0xBDAA,0xAD8B,0x9DE8,0x8DC9,
    0x7C26,0x6C07,0x5C64,0x4C45,0x3CA2,0x2C83,0x1CE0,0x0CC1,
    0xEF1F,0xFF3E,0xCF5D,0xDF7C,0xAF9B,0xBFBA,0x8FD9,0x9FF8,
    0x6E17,0x7E36,0x4E55,0x5E74,0x2E93,0x3EB2,0x0ED1,0x1EF0
};

unsigned char inputData[BUFF_LENGTH];         // hold incoming data
int count = 0;                        // length of incomming data  
unsigned char commandData[BUFF_LENGTH];       // hold decoded command data
int commandLength;                    // length of command data
unsigned char responseData[BUFF_LENGTH];
int responseLength = 0;

byte DistanceSensorOnFlag = 0;

void setup() {
  // initialize serial:
  Serial.begin(9600);

  for (int i = 0; i < DISTANCE_SENSOR_NUM; i++) {
    pinMode(TRIGGER_PIN + i * 2, OUTPUT);
    pinMode(TRIGGER_PIN + i * 2 + 1,INPUT);
  }
}

void loop() {
  if (DistanceSensorOnFlag != 0) {
    getAndSendDistanceValues();
    responseCommand(responseData, responseLength);
    delay(100/DISTANCE_SENSOR_NUM - 10 *DISTANCE_SENSOR_NUM);
  }
}

void getAndSendDistanceValues() {
  responseLength = 0;
  responseData[responseLength++] = COMMAND_ID_GET_DISTANCE + 0x80;
  responseData[responseLength++] = DISTANCE_SENSOR_NUM;
  for (int i = 0; i < DISTANCE_SENSOR_NUM; i++) {
    int distance = 0x00;
    if ((DistanceSensorOnFlag & (1 << i)) > 0) {
      distance = getObjectDistance(i);
    } 
    responseData[responseLength++] = distance;
    responseData[responseLength++] = distance >> 8;
    delay(10);
  }
}

/*
  SerialEvent occurs whenever a new data comes in the
 hardware serial RX.  This routine is run between each
 time loop() runs, so using delay inside loop can delay
 response.  Multiple bytes of data may be available.
 */
void serialEvent() 
{
  while (Serial.available()) {
    // get the new byte:
    unsigned char inChar = (unsigned char)Serial.read();

    if (inChar == START_COMMAND) {//start command
      count = 0;
      continue;
    }

    if (inChar == END_COMMAND) {//end command
      if (validateCRC()) {
        decodeCommand();
        if (processCommand()) {
          responseCommand(responseData, responseLength);
        }
      }
      continue;
    }
    // add it to the inputString:
    inputData[count++ % 200] = inChar;
  }
}

boolean validateCRC() 
{
  if (count < 3) {
    return false;
  }
  word crc = calculateCRC(inputData, 0, count - 2);
  return ((byte)crc == inputData[count - 2]) && (crc >> 8 == inputData[count - 1]);
}

void decodeCommand() {
  byte added = 0;
  commandLength = 0;
  for (int i = 0; i < count - 2; i++) {
    if (inputData[i] >= MAX_DATA) {
      added = MAX_DATA;
    } else {
      commandData[commandLength++] = inputData[i] + added;
      added = 0;
    }
  }
}

boolean processCommand() {
  responseLength = 0;
  responseData[responseLength++] = commandData[0] + 0x80;
  switch (commandData[0]) {
    case COMMAND_ID_GET_DISTANCE:
      getDistanceData();      
      break;
    case COMMAND_ID_TURN_DISTANCE_SENSOR:
      DistanceSensorOnFlag = commandData[1];      
      break;
    case COMMAND_ID_HANDSHAKE:
      responseData[responseLength++] = DISTANCE_SENSOR;
      responseData[responseLength++] = 1;// sensor id = 1            
      responseData[responseLength++] = DISTANCE_SENSOR;// device type = sensor
      responseData[responseLength++] = 2;// sensor id = 2  
      break;
    default:
      defaultResponse();
      break;
  }
  return true;
}

void turnDistanceSensor(byte sensor) {
  
}
void defaultResponse() {
  for (int i = 1; i < commandLength; i++) {
    responseData[responseLength++] = commandData[i];
  }
}

void responseCommand(byte data[], int length) 
{
  Serial.write(START_COMMAND);
  word crc = 0;
  for (int i = 0; i < length; i++) {
    if (data[i] >= MAX_DATA) {
      crc = getCRC(MAX_DATA, crc);
      Serial.write(MAX_DATA);
      crc = getCRC(data[i] - MAX_DATA, crc);
      Serial.write(data[i] - MAX_DATA);
    } else {
      crc = getCRC(data[i], crc);
      Serial.write(data[i]);
    }
  }
  Serial.write((byte)crc);
  Serial.write((byte)(crc >> 8));
  Serial.write(END_COMMAND);
}

word getCRC(byte value, word lastCRC) {
   return crctbl[((word)(lastCRC ^ (value)) & 0x00FF)];
}

word calculateCRC(byte values[], int start, int end) {
    word retval;

    retval = 0;
    for (int i = start; i < end; i++)
    {
        retval = getCRC(values[i], retval);
    }

    return retval;
}
//ARDUINO MEGA2560

void getDistanceData() {
  responseData[responseLength++] = DISTANCE_SENSOR_NUM;
  for (int i = 0; i < DISTANCE_SENSOR_NUM; i++) {
    int distance = getObjectDistance(i);
    responseData[responseLength++] = distance;
    responseData[responseLength++] = distance >> 8;
  }
}

int getObjectDistance(int sensor)
{
  unsigned long triggerTime;
  int distance;
  
  /*Phat xung tu chan Trig*/
  int triggerPin = TRIGGER_PIN + sensor * 2;
  digitalWrite(triggerPin, 0);
  delayMicroseconds(2);
  digitalWrite(triggerPin, 1);
  delayMicroseconds(5);
  digitalWrite(triggerPin, 0);
  
  /*Tinh toan*/
  triggerTime = pulseIn(triggerPin + 1, 1);  //ms
  distance = int((triggerTime / 2) / 2.94117647);  //1/2.94117647 m/ms : van toc song sieu am
  return distance;
}

