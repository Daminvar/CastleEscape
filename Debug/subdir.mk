################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
CC_SRCS += \
../Main.cc \
../MainMenu.cc \
../State.cc \
../StateManager.cc \
../TextMenu.cc 

OBJS += \
./Main.o \
./MainMenu.o \
./State.o \
./StateManager.o \
./TextMenu.o 

CC_DEPS += \
./Main.d \
./MainMenu.d \
./State.d \
./StateManager.d \
./TextMenu.d 


# Each subdirectory must supply rules for building sources it contributes
%.o: ../%.cc
	@echo 'Building file: $<'
	@echo 'Invoking: GCC C++ Compiler'
	g++ -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o"$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '

