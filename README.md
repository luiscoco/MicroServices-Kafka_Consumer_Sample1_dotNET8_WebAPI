# dotNet8WebAPI_Consume_Kafka_JSON_messages

```
kafka-consumer-groups --bootstrap-server localhost:9092 --list
```

This is the  **GroupId** output we get: console-consumer-10519

To see more details about the selected group we run this command:

```
kafka-consumer-groups --bootstrap-server localhost:9092 --describe --group console-consumer-10519
```

This is the output we get:

GROUP                  TOPIC           PARTITION  CURRENT-OFFSET  LOG-END-OFFSET  LAG             CONSUMER-ID                                           HOST            CLIENT-ID

console-consumer-10519 test            0          -               3               -               console-consumer-04bd761a-bbb2-4b56-b1a9-b54a3ba2f945 /127.0.0.1      console-consumer

