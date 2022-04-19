using Messaging;
using System;
using System.Collections.Generic;
using Xunit;

namespace Device.Tests
{
    public class DeviceTest
    {
        //Arrange
        private readonly Device device;

        public DeviceTest()
        {
            //Act
            device = new Device();
        }

        [Fact]
        public void AfterDeviceInitialiseWithTenMessages_TenMessagesExists()
        {
            //Arrange
            var bootstrapSettings = CreateBootstrapSettings(10);

            //Act
            var device = new Device(bootstrapSettings);

            //Assert
            Assert.Equal(10, device.Messages.Count);
        }

        [Fact]
        public void AfterDeviceInitialiseWithOneMessage_OneMessageExists()
        {
            //Arrange
            var bootstrapSettings = CreateBootstrapSettings(1);

            //Act
            var device = new Device(bootstrapSettings);

            //Assert
            Assert.Single(device.Messages);
        }

        [Fact]
        public void AfterDeviceInitialise_NoMessagesExists()
        {
            //Assert
            Assert.Empty(device.Messages);
        }

        [Fact]
        public void DeviceHasId()
        {
            //Assert
            Assert.IsType<Guid>(device.Id);
        }

        [Fact]
        public void DeviceCanInitialise_WithBootstrapSettings()
        {
            //Arrange
            var bootstrapSettings = CreateBootstrapSettings(0);

            //Act
            var device = new Device(bootstrapSettings);

            //Assert
            Assert.NotNull(device);
        }

        [Fact]
        public void DeviceCanInitialise_WithoutBootstrapSettings()
        {
            //Act
            var device = new Device();

            //Assert
            Assert.NotNull(device);
        }

        ///////////////////////////
        
        private BootstrapSettings CreateBootstrapSettings(int numberOfMessages)
        {
            var id = Guid.NewGuid();
            var messages = new Queue<IMessage>();
            
            for(int i = 0; i < numberOfMessages; i++)
            {
                var message = GenerateMessageForDevice(id);

                messages.Enqueue(message);
            }
            
            var bootstrapSettings = new BootstrapSettings
            {
                NewId = id,
                NewMessages = messages
            };

            return bootstrapSettings;
        }

        private IMessage GenerateMessageForDevice(Guid deviceId)
        {
            var deviceMessage = new DeviceMessage(deviceId);

            return deviceMessage;
        }
    }
}