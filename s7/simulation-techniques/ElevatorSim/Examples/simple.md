# Elevator simulation report
The building has **5 floors**.

The building has a system of **2 elevators** that follows the **Simple** strategy. Each can fit at most **4 people**.

It takes **10 seconds** for an elevator to travel from one floor to the next.

It takes **3 seconds** for the elevator doors to open.

The elevator doors stay open for **12 seconds**.

**200** people came in the building.

The time between each arrival follows an exponential distribution with mean equal to **00:01:30**.

The number of floors each person visited follows a normal distribution with mean equal to **4** and standard deviation equal to **1**.

The time each person stays on a floor follows a normal distrubution with mean equal to **00:30:00** and standard deviation equal to **00:07:30**.

The simulation's random number generator seed is **7321007903481422866**

You can replay the simulation by running the program with the following JSON file:

``` json
{
  "NumberOfFloors": 5,
  "NumberOfElevators": 2,
  "TotalArrivals": 200,
  "ElevatorMovingDelay": 10,
  "ElevatorDoorOpeningDelay": 3,
  "ElevatorDoorOpeningDuration": 12,
  "ElevatorCapacity": 4,
  "DurationOfStayOnFloor": {
    "Mean": 1800,
    "Stdev": 450
  },
  "NumberOfFloorsVisited": {
    "Mean": 4,
    "Stdev": 1
  },
  "MeanTimeBetweenArrivals": 90,
  "ElevatorStrategy": "Simple",
  "Seed": 7321007903481422866
}
```

## Statistics
### System
|||
|----|-----|
|**Simulation duration**|38074 time units (10:34:34)|
|**Total productive time units (where work was done)**|7559 time units|
|**% of simulation in idle**|80.15 %|
|**Total work items executed**|18231|
|**Average work items per time unit**|0.479|
|**Average work items per productive time unit**|2.41|

### People
|Name|Average|Min|Max|
|----|-------|---|---|
|**Time spent in the building overall**|02:08:03.5700000|00:28:10|03:38:02|
|**Time spent in the building waiting**|00:09:50.3200000|00:02:16|00:18:20|
|**% of time spent in the building waiting**|7.96 %|2.25 %|17.63 %|

### Elevators
> An elevator gets activated when it starts moving after being put to rest.

> The "Average occupancy" column's two values show the average number of passengers on an elevator at all times, and excluding the times when it is empty.

|Name|Floors travelled|Time in motion (% of simulation)|Activations|Passengers served|Average occupancy|
|----|----------------|--------------------------------|-----------|-----------------|-----------------|
|elevator_1|1334|03:42:20 (35.04 %)|96|510|0.923 / 1.77|
|elevator_2|1324|03:40:40 (34.77 %)|97|475|0.882 / 1.71|

### Floors
> The "Average people on floor" column's two values show the average people on a floor at all times, and excluding the times when it is empty.

|Number|Total arrivals|Average people on floor|Max people on floor|Time spent on floor (average/max/min)|Waiting time (average/max)|% of waiting time (average/max)|
|------|--------------|-----------------------|-------------------|-------------------------------------|--------------------------|-------------------------------|
|1|160|92.6 / 92.7|160|00:31:09.9062500 / 00:52:48 / 00:14:55|00:00:45.2375000 / 00:04:42|2.44 % / 12.95 %|
|2|163|89.7 / 90.8|163|00:30:26.3742331 / 00:51:01 / 00:06:36|00:00:40.8036809 / 00:05:07|2.33 % / 14.67 %|
|3|169|93.5 / 95.6|169|00:30:41.5502958 / 00:48:39 / 00:09:42|00:00:44.7692307 / 00:06:27|2.50 % / 14.17 %|
|4|147|78.4 / 78.7|147|00:30:59.2721088 / 00:48:01 / 00:13:07|00:00:39.5238095 / 00:03:50|2.16 % / 14.16 %|
|5|146|79 / 81.8|146|00:31:19.8493150 / 00:52:21 / 00:08:54|00:01:08.2328767 / 00:04:48|3.71 % / 16.74 %|

### Waiting Queues
|Name|Total arrivals|Waiting time (total/average/max)|Average queue length|Max queue length|
|----|--------------|--------------------------------|--------------------|----------------|
|floor_0|200|00:30:40 / 00:00:09.2000000 / 00:03:11|1.09|2|
|floor_1|160|00:28:39 / 00:00:10.7437500 / 00:02:50|1.21|3|
|floor_2|163|00:18:04 / 00:00:06.6503067 / 00:04:10|1.58|3|
|floor_3|169|00:19:58 / 00:00:07.0887573 / 00:02:11|1.3|3|
|floor_4|147|00:09:37 / 00:00:03.9251700 / 00:02:06|1.08|2|
|floor_5|146|00:39:50 / 00:00:16.3698630 / 00:03:22|1.2|3|

## Simulation Log
<details>
<summary>Click to expand (20045 lines)</summary>

```
[D1 08:00:00 citizen_1] Entered the building, will visit 5 floors in total
[D1 08:00:00 citizen_1] Time to go to floor 1 and stay there for 00:29:42
[D1 08:00:00 floor_0] citizen_1 entered the queue
[D1 08:00:00 floor_0] citizen_1 found an empty queue and will be served immediately
[D1 08:00:00 elevator_1] Summoned to floor 0 from floor 0
[D1 08:00:00 elevator_1] Opening doors
[D1 08:00:00 elevator_2] Summoned to floor 0 from floor 0
[D1 08:00:00 elevator_2] Opening doors
[D1 08:00:03 elevator_1] Opened doors
[D1 08:00:03 elevator_2] Opened doors
[D1 08:00:03 citizen_1] Entered elevator_1, going to floor 1
[D1 08:00:03 floor_0] citizen_1 is leaving the queue
[D1 08:00:03 floor_0] The queue is now empty
[D1 08:00:15 elevator_2] Closing doors
[D1 08:00:15 elevator_1] Closing doors
[D1 08:00:18 elevator_2] Closed doors
[D1 08:00:18 elevator_1] Closed doors
[D1 08:00:18 elevator_1] Sprung into motion, heading Up
[D1 08:00:28 elevator_1] At floor 1
[D1 08:00:28 elevator_1] Stopped at floor 1
[D1 08:00:28 elevator_1] Opening doors
[D1 08:00:31 elevator_1] Opened doors
[D1 08:00:31 citizen_1] Left elevator_1, arrived at floor 1
[D1 08:00:43 elevator_1] Closing doors
[D1 08:00:46 elevator_1] Closed doors
[D1 08:00:46 elevator_1] Resting at floor 1
[D1 08:01:35 citizen_2] Entered the building, will visit 6 floors in total
[D1 08:01:35 citizen_2] Time to go to floor 4 and stay there for 00:37:30
[D1 08:01:35 floor_0] citizen_2 entered the queue
[D1 08:01:35 floor_0] citizen_2 found an empty queue and will be served immediately
[D1 08:01:35 elevator_2] Summoned to floor 0 from floor 0
[D1 08:01:35 elevator_2] Opening doors
[D1 08:01:38 elevator_2] Opened doors
[D1 08:01:38 citizen_2] Entered elevator_2, going to floor 4
[D1 08:01:38 floor_0] citizen_2 is leaving the queue
[D1 08:01:38 floor_0] The queue is now empty
[D1 08:01:50 elevator_2] Closing doors
[D1 08:01:53 elevator_2] Closed doors
[D1 08:01:53 elevator_2] Sprung into motion, heading Up
[D1 08:02:03 elevator_2] At floor 1
[D1 08:02:13 elevator_2] At floor 2
[D1 08:02:23 elevator_2] At floor 3
[D1 08:02:33 elevator_2] At floor 4
[D1 08:02:33 elevator_2] Stopped at floor 4
[D1 08:02:33 elevator_2] Opening doors
[D1 08:02:36 elevator_2] Opened doors
[D1 08:02:36 citizen_2] Left elevator_2, arrived at floor 4
[D1 08:02:48 elevator_2] Closing doors
[D1 08:02:51 elevator_2] Closed doors
[D1 08:02:51 elevator_2] Resting at floor 4
[D1 08:02:57 citizen_3] Entered the building, will visit 4 floors in total
[D1 08:02:57 citizen_3] Time to go to floor 1 and stay there for 00:32:30
[D1 08:02:57 floor_0] citizen_3 entered the queue
[D1 08:02:57 floor_0] citizen_3 found an empty queue and will be served immediately
[D1 08:02:57 elevator_1] Summoned to floor 0 from floor 1
[D1 08:02:57 elevator_1] Sprung into motion, heading Down
[D1 08:03:07 elevator_1] At floor 0
[D1 08:03:07 elevator_1] Stopped at floor 0
[D1 08:03:07 elevator_1] Opening doors
[D1 08:03:10 elevator_1] Opened doors
[D1 08:03:10 citizen_3] Entered elevator_1, going to floor 1
[D1 08:03:10 floor_0] citizen_3 is leaving the queue
[D1 08:03:10 floor_0] The queue is now empty
[D1 08:03:22 elevator_1] Closing doors
[D1 08:03:25 elevator_1] Closed doors
[D1 08:03:25 elevator_1] Changing direction to Up
[D1 08:03:35 elevator_1] At floor 1
[D1 08:03:35 elevator_1] Stopped at floor 1
[D1 08:03:35 elevator_1] Opening doors
[D1 08:03:38 elevator_1] Opened doors
[D1 08:03:38 citizen_3] Left elevator_1, arrived at floor 1
[D1 08:03:50 elevator_1] Closing doors
[D1 08:03:53 elevator_1] Closed doors
[D1 08:03:53 elevator_1] Resting at floor 1
[D1 08:04:39 citizen_4] Entered the building, will visit 4 floors in total
[D1 08:04:39 citizen_4] Time to go to floor 4 and stay there for 00:33:42
[D1 08:04:39 floor_0] citizen_4 entered the queue
[D1 08:04:39 floor_0] citizen_4 found an empty queue and will be served immediately
[D1 08:04:39 elevator_1] Summoned to floor 0 from floor 1
[D1 08:04:39 elevator_1] Sprung into motion, heading Down
[D1 08:04:49 elevator_1] At floor 0
[D1 08:04:49 elevator_1] Stopped at floor 0
[D1 08:04:49 elevator_1] Opening doors
[D1 08:04:52 elevator_1] Opened doors
[D1 08:04:52 citizen_4] Entered elevator_1, going to floor 4
[D1 08:04:52 floor_0] citizen_4 is leaving the queue
[D1 08:04:52 floor_0] The queue is now empty
[D1 08:05:04 elevator_1] Closing doors
[D1 08:05:07 elevator_1] Closed doors
[D1 08:05:07 elevator_1] Changing direction to Up
[D1 08:05:17 elevator_1] At floor 1
[D1 08:05:27 elevator_1] At floor 2
[D1 08:05:37 elevator_1] At floor 3
[D1 08:05:47 elevator_1] At floor 4
[D1 08:05:47 elevator_1] Stopped at floor 4
[D1 08:05:47 elevator_1] Opening doors
[D1 08:05:50 elevator_1] Opened doors
[D1 08:05:50 citizen_4] Left elevator_1, arrived at floor 4
[D1 08:06:02 elevator_1] Closing doors
[D1 08:06:05 elevator_1] Closed doors
[D1 08:06:05 elevator_1] Resting at floor 4
[D1 08:06:08 citizen_5] Entered the building, will visit 3 floors in total
[D1 08:06:08 citizen_5] Time to go to floor 2 and stay there for 00:28:11
[D1 08:06:08 floor_0] citizen_5 entered the queue
[D1 08:06:08 floor_0] citizen_5 found an empty queue and will be served immediately
[D1 08:06:08 elevator_1] Summoned to floor 0 from floor 4
[D1 08:06:08 elevator_1] Sprung into motion, heading Down
[D1 08:06:08 elevator_2] Summoned to floor 0 from floor 4
[D1 08:06:08 elevator_2] Sprung into motion, heading Down
[D1 08:06:18 elevator_1] At floor 3
[D1 08:06:18 elevator_2] At floor 3
[D1 08:06:28 elevator_1] At floor 2
[D1 08:06:28 elevator_2] At floor 2
[D1 08:06:38 elevator_1] At floor 1
[D1 08:06:38 elevator_2] At floor 1
[D1 08:06:48 elevator_1] At floor 0
[D1 08:06:48 elevator_1] Stopped at floor 0
[D1 08:06:48 elevator_1] Opening doors
[D1 08:06:48 elevator_2] At floor 0
[D1 08:06:48 elevator_2] Stopped at floor 0
[D1 08:06:48 elevator_2] Opening doors
[D1 08:06:51 elevator_1] Opened doors
[D1 08:06:51 elevator_2] Opened doors
[D1 08:06:51 citizen_5] Entered elevator_1, going to floor 2
[D1 08:06:51 floor_0] citizen_5 is leaving the queue
[D1 08:06:51 floor_0] The queue is now empty
[D1 08:07:03 elevator_1] Closing doors
[D1 08:07:03 elevator_2] Closing doors
[D1 08:07:06 elevator_1] Closed doors
[D1 08:07:06 elevator_2] Closed doors
[D1 08:07:06 elevator_1] Changing direction to Up
[D1 08:07:06 elevator_2] Resting at floor 0
[D1 08:07:16 elevator_1] At floor 1
[D1 08:07:26 elevator_1] At floor 2
[D1 08:07:26 elevator_1] Stopped at floor 2
[D1 08:07:26 elevator_1] Opening doors
[D1 08:07:29 elevator_1] Opened doors
[D1 08:07:29 citizen_5] Left elevator_1, arrived at floor 2
[D1 08:07:41 elevator_1] Closing doors
[D1 08:07:42 citizen_6] Entered the building, will visit 4 floors in total
[D1 08:07:42 citizen_6] Time to go to floor 1 and stay there for 00:36:03
[D1 08:07:42 floor_0] citizen_6 entered the queue
[D1 08:07:42 floor_0] citizen_6 found an empty queue and will be served immediately
[D1 08:07:42 elevator_2] Summoned to floor 0 from floor 0
[D1 08:07:42 elevator_2] Opening doors
[D1 08:07:44 elevator_1] Closed doors
[D1 08:07:44 elevator_1] Resting at floor 2
[D1 08:07:45 elevator_2] Opened doors
[D1 08:07:45 citizen_6] Entered elevator_2, going to floor 1
[D1 08:07:45 floor_0] citizen_6 is leaving the queue
[D1 08:07:45 floor_0] The queue is now empty
[D1 08:07:57 elevator_2] Closing doors
[D1 08:08:00 elevator_2] Closed doors
[D1 08:08:00 elevator_2] Sprung into motion, heading Up
[D1 08:08:10 elevator_2] At floor 1
[D1 08:08:10 elevator_2] Stopped at floor 1
[D1 08:08:10 elevator_2] Opening doors
[D1 08:08:13 elevator_2] Opened doors
[D1 08:08:13 citizen_6] Left elevator_2, arrived at floor 1
[D1 08:08:25 elevator_2] Closing doors
[D1 08:08:28 elevator_2] Closed doors
[D1 08:08:28 elevator_2] Resting at floor 1
[D1 08:09:41 citizen_7] Entered the building, will visit 5 floors in total
[D1 08:09:41 citizen_7] Time to go to floor 4 and stay there for 00:35:25
[D1 08:09:41 floor_0] citizen_7 entered the queue
[D1 08:09:41 floor_0] citizen_7 found an empty queue and will be served immediately
[D1 08:09:41 elevator_2] Summoned to floor 0 from floor 1
[D1 08:09:41 elevator_2] Sprung into motion, heading Down
[D1 08:09:51 elevator_2] At floor 0
[D1 08:09:51 elevator_2] Stopped at floor 0
[D1 08:09:51 elevator_2] Opening doors
[D1 08:09:54 elevator_2] Opened doors
[D1 08:09:54 citizen_7] Entered elevator_2, going to floor 4
[D1 08:09:54 floor_0] citizen_7 is leaving the queue
[D1 08:09:54 floor_0] The queue is now empty
[D1 08:10:06 elevator_2] Closing doors
[D1 08:10:09 elevator_2] Closed doors
[D1 08:10:09 elevator_2] Changing direction to Up
[D1 08:10:19 elevator_2] At floor 1
[D1 08:10:29 elevator_2] At floor 2
[D1 08:10:39 elevator_2] At floor 3
[D1 08:10:49 elevator_2] At floor 4
[D1 08:10:49 elevator_2] Stopped at floor 4
[D1 08:10:49 elevator_2] Opening doors
[D1 08:10:52 elevator_2] Opened doors
[D1 08:10:52 citizen_7] Left elevator_2, arrived at floor 4
[D1 08:11:04 elevator_2] Closing doors
[D1 08:11:07 elevator_2] Closed doors
[D1 08:11:07 elevator_2] Resting at floor 4
[D1 08:12:37 citizen_8] Entered the building, will visit 4 floors in total
[D1 08:12:37 citizen_8] Time to go to floor 3 and stay there for 00:35:02
[D1 08:12:37 floor_0] citizen_8 entered the queue
[D1 08:12:37 floor_0] citizen_8 found an empty queue and will be served immediately
[D1 08:12:37 elevator_1] Summoned to floor 0 from floor 2
[D1 08:12:37 elevator_1] Sprung into motion, heading Down
[D1 08:12:47 elevator_1] At floor 1
[D1 08:12:57 elevator_1] At floor 0
[D1 08:12:57 elevator_1] Stopped at floor 0
[D1 08:12:57 elevator_1] Opening doors
[D1 08:13:00 elevator_1] Opened doors
[D1 08:13:00 citizen_8] Entered elevator_1, going to floor 3
[D1 08:13:00 floor_0] citizen_8 is leaving the queue
[D1 08:13:00 floor_0] The queue is now empty
[D1 08:13:12 elevator_1] Closing doors
[D1 08:13:15 elevator_1] Closed doors
[D1 08:13:15 elevator_1] Changing direction to Up
[D1 08:13:25 elevator_1] At floor 1
[D1 08:13:35 elevator_1] At floor 2
[D1 08:13:40 citizen_9] Entered the building, will visit 3 floors in total
[D1 08:13:40 citizen_9] Time to go to floor 1 and stay there for 00:39:09
[D1 08:13:40 floor_0] citizen_9 entered the queue
[D1 08:13:40 floor_0] citizen_9 found an empty queue and will be served immediately
[D1 08:13:40 elevator_1] Summoned to floor 0 from floor 2
[D1 08:13:45 elevator_1] At floor 3
[D1 08:13:45 elevator_1] Stopped at floor 3
[D1 08:13:45 elevator_1] Opening doors
[D1 08:13:48 elevator_1] Opened doors
[D1 08:13:48 citizen_8] Left elevator_1, arrived at floor 3
[D1 08:14:00 elevator_1] Closing doors
[D1 08:14:03 elevator_1] Closed doors
[D1 08:14:03 elevator_1] Changing direction to Down
[D1 08:14:13 elevator_1] At floor 2
[D1 08:14:23 elevator_1] At floor 1
[D1 08:14:33 elevator_1] At floor 0
[D1 08:14:33 elevator_1] Stopped at floor 0
[D1 08:14:33 elevator_1] Opening doors
[D1 08:14:36 elevator_1] Opened doors
[D1 08:14:36 citizen_9] Entered elevator_1, going to floor 1
[D1 08:14:36 floor_0] citizen_9 is leaving the queue
[D1 08:14:36 floor_0] The queue is now empty
[D1 08:14:48 elevator_1] Closing doors
[D1 08:14:51 elevator_1] Closed doors
[D1 08:14:51 elevator_1] Changing direction to Up
[D1 08:15:01 elevator_1] At floor 1
[D1 08:15:01 elevator_1] Stopped at floor 1
[D1 08:15:01 elevator_1] Opening doors
[D1 08:15:04 elevator_1] Opened doors
[D1 08:15:04 citizen_9] Left elevator_1, arrived at floor 1
[D1 08:15:16 elevator_1] Closing doors
[D1 08:15:19 elevator_1] Closed doors
[D1 08:15:19 elevator_1] Resting at floor 1
[D1 08:15:55 citizen_10] Entered the building, will visit 5 floors in total
[D1 08:15:55 citizen_10] Time to go to floor 3 and stay there for 00:19:19
[D1 08:15:55 floor_0] citizen_10 entered the queue
[D1 08:15:55 floor_0] citizen_10 found an empty queue and will be served immediately
[D1 08:15:55 elevator_1] Summoned to floor 0 from floor 1
[D1 08:15:55 elevator_1] Sprung into motion, heading Down
[D1 08:16:05 elevator_1] At floor 0
[D1 08:16:05 elevator_1] Stopped at floor 0
[D1 08:16:05 elevator_1] Opening doors
[D1 08:16:08 elevator_1] Opened doors
[D1 08:16:08 citizen_10] Entered elevator_1, going to floor 3
[D1 08:16:08 floor_0] citizen_10 is leaving the queue
[D1 08:16:08 floor_0] The queue is now empty
[D1 08:16:20 elevator_1] Closing doors
[D1 08:16:23 elevator_1] Closed doors
[D1 08:16:23 elevator_1] Changing direction to Up
[D1 08:16:33 elevator_1] At floor 1
[D1 08:16:43 elevator_1] At floor 2
[D1 08:16:53 elevator_1] At floor 3
[D1 08:16:53 elevator_1] Stopped at floor 3
[D1 08:16:53 elevator_1] Opening doors
[D1 08:16:56 elevator_1] Opened doors
[D1 08:16:56 citizen_10] Left elevator_1, arrived at floor 3
[D1 08:17:08 elevator_1] Closing doors
[D1 08:17:11 elevator_1] Closed doors
[D1 08:17:11 elevator_1] Resting at floor 3
[D1 08:17:12 citizen_11] Entered the building, will visit 3 floors in total
[D1 08:17:12 citizen_11] Time to go to floor 3 and stay there for 00:48:11
[D1 08:17:12 floor_0] citizen_11 entered the queue
[D1 08:17:12 floor_0] citizen_11 found an empty queue and will be served immediately
[D1 08:17:12 elevator_1] Summoned to floor 0 from floor 3
[D1 08:17:12 elevator_1] Sprung into motion, heading Down
[D1 08:17:22 elevator_1] At floor 2
[D1 08:17:32 elevator_1] At floor 1
[D1 08:17:42 elevator_1] At floor 0
[D1 08:17:42 elevator_1] Stopped at floor 0
[D1 08:17:42 elevator_1] Opening doors
[D1 08:17:45 elevator_1] Opened doors
[D1 08:17:45 citizen_11] Entered elevator_1, going to floor 3
[D1 08:17:45 floor_0] citizen_11 is leaving the queue
[D1 08:17:45 floor_0] The queue is now empty
[D1 08:17:57 elevator_1] Closing doors
[D1 08:18:00 elevator_1] Closed doors
[D1 08:18:00 elevator_1] Changing direction to Up
[D1 08:18:10 elevator_1] At floor 1
[D1 08:18:20 elevator_1] At floor 2
[D1 08:18:21 citizen_12] Entered the building, will visit 5 floors in total
[D1 08:18:21 citizen_12] Time to go to floor 1 and stay there for 00:22:10
[D1 08:18:21 floor_0] citizen_12 entered the queue
[D1 08:18:21 floor_0] citizen_12 found an empty queue and will be served immediately
[D1 08:18:21 elevator_1] Summoned to floor 0 from floor 2
[D1 08:18:30 elevator_1] At floor 3
[D1 08:18:30 elevator_1] Stopped at floor 3
[D1 08:18:30 elevator_1] Opening doors
[D1 08:18:33 elevator_1] Opened doors
[D1 08:18:33 citizen_11] Left elevator_1, arrived at floor 3
[D1 08:18:45 elevator_1] Closing doors
[D1 08:18:48 elevator_1] Closed doors
[D1 08:18:48 elevator_1] Changing direction to Down
[D1 08:18:58 elevator_1] At floor 2
[D1 08:19:08 elevator_1] At floor 1
[D1 08:19:18 elevator_1] At floor 0
[D1 08:19:18 elevator_1] Stopped at floor 0
[D1 08:19:18 elevator_1] Opening doors
[D1 08:19:21 elevator_1] Opened doors
[D1 08:19:21 citizen_12] Entered elevator_1, going to floor 1
[D1 08:19:21 floor_0] citizen_12 is leaving the queue
[D1 08:19:21 floor_0] The queue is now empty
[D1 08:19:33 elevator_1] Closing doors
[D1 08:19:36 elevator_1] Closed doors
[D1 08:19:36 elevator_1] Changing direction to Up
[D1 08:19:46 elevator_1] At floor 1
[D1 08:19:46 elevator_1] Stopped at floor 1
[D1 08:19:46 elevator_1] Opening doors
[D1 08:19:49 elevator_1] Opened doors
[D1 08:19:49 citizen_12] Left elevator_1, arrived at floor 1
[D1 08:19:59 citizen_13] Entered the building, will visit 3 floors in total
[D1 08:19:59 citizen_13] Time to go to floor 5 and stay there for 00:40:20
[D1 08:19:59 floor_0] citizen_13 entered the queue
[D1 08:19:59 floor_0] citizen_13 found an empty queue and will be served immediately
[D1 08:19:59 elevator_1] Summoned to floor 0 from floor 1
[D1 08:20:01 elevator_1] Closing doors
[D1 08:20:04 elevator_1] Closed doors
[D1 08:20:04 elevator_1] Changing direction to Down
[D1 08:20:14 elevator_1] At floor 0
[D1 08:20:14 elevator_1] Stopped at floor 0
[D1 08:20:14 elevator_1] Opening doors
[D1 08:20:17 elevator_1] Opened doors
[D1 08:20:17 citizen_13] Entered elevator_1, going to floor 5
[D1 08:20:17 floor_0] citizen_13 is leaving the queue
[D1 08:20:17 floor_0] The queue is now empty
[D1 08:20:29 elevator_1] Closing doors
[D1 08:20:32 elevator_1] Closed doors
[D1 08:20:32 elevator_1] Changing direction to Up
[D1 08:20:42 elevator_1] At floor 1
[D1 08:20:52 elevator_1] At floor 2
[D1 08:21:02 elevator_1] At floor 3
[D1 08:21:12 elevator_1] At floor 4
[D1 08:21:20 citizen_14] Entered the building, will visit 7 floors in total
[D1 08:21:20 citizen_14] Time to go to floor 2 and stay there for 00:24:41
[D1 08:21:20 floor_0] citizen_14 entered the queue
[D1 08:21:20 floor_0] citizen_14 found an empty queue and will be served immediately
[D1 08:21:20 elevator_1] Summoned to floor 0 from floor 4
[D1 08:21:20 elevator_2] Summoned to floor 0 from floor 4
[D1 08:21:20 elevator_2] Sprung into motion, heading Down
[D1 08:21:22 elevator_1] At floor 5
[D1 08:21:22 elevator_1] Stopped at floor 5
[D1 08:21:22 elevator_1] Opening doors
[D1 08:21:25 elevator_1] Opened doors
[D1 08:21:25 citizen_13] Left elevator_1, arrived at floor 5
[D1 08:21:30 elevator_2] At floor 3
[D1 08:21:37 elevator_1] Closing doors
[D1 08:21:40 elevator_2] At floor 2
[D1 08:21:40 elevator_1] Closed doors
[D1 08:21:40 elevator_1] Changing direction to Down
[D1 08:21:50 elevator_2] At floor 1
[D1 08:21:50 elevator_1] At floor 4
[D1 08:22:00 elevator_2] At floor 0
[D1 08:22:00 elevator_2] Stopped at floor 0
[D1 08:22:00 elevator_2] Opening doors
[D1 08:22:00 elevator_1] At floor 3
[D1 08:22:03 elevator_2] Opened doors
[D1 08:22:03 citizen_14] Entered elevator_2, going to floor 2
[D1 08:22:03 floor_0] citizen_14 is leaving the queue
[D1 08:22:03 floor_0] The queue is now empty
[D1 08:22:10 elevator_1] At floor 2
[D1 08:22:15 elevator_2] Closing doors
[D1 08:22:18 elevator_2] Closed doors
[D1 08:22:18 elevator_2] Changing direction to Up
[D1 08:22:20 elevator_1] At floor 1
[D1 08:22:28 elevator_2] At floor 1
[D1 08:22:30 elevator_1] At floor 0
[D1 08:22:30 elevator_1] Stopped at floor 0
[D1 08:22:30 elevator_1] Opening doors
[D1 08:22:33 elevator_1] Opened doors
[D1 08:22:38 elevator_2] At floor 2
[D1 08:22:38 elevator_2] Stopped at floor 2
[D1 08:22:38 elevator_2] Opening doors
[D1 08:22:41 elevator_2] Opened doors
[D1 08:22:41 citizen_14] Left elevator_2, arrived at floor 2
[D1 08:22:45 elevator_1] Closing doors
[D1 08:22:48 elevator_1] Closed doors
[D1 08:22:48 elevator_1] Resting at floor 0
[D1 08:22:53 elevator_2] Closing doors
[D1 08:22:56 elevator_2] Closed doors
[D1 08:22:56 elevator_2] Resting at floor 2
[D1 08:26:24 citizen_15] Entered the building, will visit 4 floors in total
[D1 08:26:24 citizen_15] Time to go to floor 5 and stay there for 00:27:51
[D1 08:26:24 floor_0] citizen_15 entered the queue
[D1 08:26:24 floor_0] citizen_15 found an empty queue and will be served immediately
[D1 08:26:24 elevator_1] Summoned to floor 0 from floor 0
[D1 08:26:24 elevator_1] Opening doors
[D1 08:26:27 elevator_1] Opened doors
[D1 08:26:27 citizen_15] Entered elevator_1, going to floor 5
[D1 08:26:27 floor_0] citizen_15 is leaving the queue
[D1 08:26:27 floor_0] The queue is now empty
[D1 08:26:39 elevator_1] Closing doors
[D1 08:26:42 elevator_1] Closed doors
[D1 08:26:42 elevator_1] Sprung into motion, heading Up
[D1 08:26:52 elevator_1] At floor 1
[D1 08:27:02 elevator_1] At floor 2
[D1 08:27:12 elevator_1] At floor 3
[D1 08:27:22 elevator_1] At floor 4
[D1 08:27:32 elevator_1] At floor 5
[D1 08:27:32 elevator_1] Stopped at floor 5
[D1 08:27:32 elevator_1] Opening doors
[D1 08:27:35 elevator_1] Opened doors
[D1 08:27:35 citizen_15] Left elevator_1, arrived at floor 5
[D1 08:27:45 citizen_16] Entered the building, will visit 2 floors in total
[D1 08:27:45 citizen_16] Time to go to floor 2 and stay there for 00:39:19
[D1 08:27:45 floor_0] citizen_16 entered the queue
[D1 08:27:45 floor_0] citizen_16 found an empty queue and will be served immediately
[D1 08:27:45 elevator_2] Summoned to floor 0 from floor 2
[D1 08:27:45 elevator_2] Sprung into motion, heading Down
[D1 08:27:47 elevator_1] Closing doors
[D1 08:27:50 elevator_1] Closed doors
[D1 08:27:50 elevator_1] Resting at floor 5
[D1 08:27:55 elevator_2] At floor 1
[D1 08:28:05 elevator_2] At floor 0
[D1 08:28:05 elevator_2] Stopped at floor 0
[D1 08:28:05 elevator_2] Opening doors
[D1 08:28:08 elevator_2] Opened doors
[D1 08:28:08 citizen_16] Entered elevator_2, going to floor 2
[D1 08:28:08 floor_0] citizen_16 is leaving the queue
[D1 08:28:08 floor_0] The queue is now empty
[D1 08:28:20 elevator_2] Closing doors
[D1 08:28:23 elevator_2] Closed doors
[D1 08:28:23 elevator_2] Changing direction to Up
[D1 08:28:33 elevator_2] At floor 1
[D1 08:28:43 elevator_2] At floor 2
[D1 08:28:43 elevator_2] Stopped at floor 2
[D1 08:28:43 elevator_2] Opening doors
[D1 08:28:46 elevator_2] Opened doors
[D1 08:28:46 citizen_16] Left elevator_2, arrived at floor 2
[D1 08:28:58 elevator_2] Closing doors
[D1 08:29:01 elevator_2] Closed doors
[D1 08:29:01 elevator_2] Resting at floor 2
[D1 08:30:05 citizen_17] Entered the building, will visit 4 floors in total
[D1 08:30:05 citizen_17] Time to go to floor 3 and stay there for 00:20:41
[D1 08:30:05 floor_0] citizen_17 entered the queue
[D1 08:30:05 floor_0] citizen_17 found an empty queue and will be served immediately
[D1 08:30:05 elevator_2] Summoned to floor 0 from floor 2
[D1 08:30:05 elevator_2] Sprung into motion, heading Down
[D1 08:30:13 citizen_1] Time to go to floor 2 and stay there for 00:28:01
[D1 08:30:13 floor_1] citizen_1 entered the queue
[D1 08:30:13 floor_1] citizen_1 found an empty queue and will be served immediately
[D1 08:30:13 elevator_2] Summoned to floor 1 from floor 2
[D1 08:30:15 elevator_2] At floor 1
[D1 08:30:15 elevator_2] Stopped at floor 1
[D1 08:30:15 elevator_2] Opening doors
[D1 08:30:18 elevator_2] Opened doors
[D1 08:30:18 citizen_1] Entered elevator_2, going to floor 2
[D1 08:30:18 floor_1] citizen_1 is leaving the queue
[D1 08:30:18 floor_1] The queue is now empty
[D1 08:30:30 elevator_2] Closing doors
[D1 08:30:33 elevator_2] Closed doors
[D1 08:30:43 elevator_2] At floor 0
[D1 08:30:43 elevator_2] Stopped at floor 0
[D1 08:30:43 elevator_2] Opening doors
[D1 08:30:46 elevator_2] Opened doors
[D1 08:30:46 citizen_17] Entered elevator_2, going to floor 3
[D1 08:30:46 floor_0] citizen_17 is leaving the queue
[D1 08:30:46 floor_0] The queue is now empty
[D1 08:30:58 elevator_2] Closing doors
[D1 08:31:01 elevator_2] Closed doors
[D1 08:31:01 elevator_2] Changing direction to Up
[D1 08:31:11 elevator_2] At floor 1
[D1 08:31:15 citizen_18] Entered the building, will visit 6 floors in total
[D1 08:31:15 citizen_18] Time to go to floor 3 and stay there for 00:29:45
[D1 08:31:15 floor_0] citizen_18 entered the queue
[D1 08:31:15 floor_0] citizen_18 found an empty queue and will be served immediately
[D1 08:31:15 elevator_2] Summoned to floor 0 from floor 1
[D1 08:31:21 elevator_2] At floor 2
[D1 08:31:21 elevator_2] Stopped at floor 2
[D1 08:31:21 elevator_2] Opening doors
[D1 08:31:24 elevator_2] Opened doors
[D1 08:31:24 citizen_1] Left elevator_2, arrived at floor 2
[D1 08:31:36 elevator_2] Closing doors
[D1 08:31:39 elevator_2] Closed doors
[D1 08:31:49 elevator_2] At floor 3
[D1 08:31:49 elevator_2] Stopped at floor 3
[D1 08:31:49 elevator_2] Opening doors
[D1 08:31:52 elevator_2] Opened doors
[D1 08:31:52 citizen_17] Left elevator_2, arrived at floor 3
[D1 08:32:04 elevator_2] Closing doors
[D1 08:32:07 elevator_2] Closed doors
[D1 08:32:07 elevator_2] Changing direction to Down
[D1 08:32:17 elevator_2] At floor 2
[D1 08:32:27 elevator_2] At floor 1
[D1 08:32:34 citizen_19] Entered the building, will visit 4 floors in total
[D1 08:32:34 citizen_19] Time to go to floor 4 and stay there for 00:19:08
[D1 08:32:34 floor_0] citizen_19 entered the queue
[D1 08:32:34 floor_0] citizen_19 is queued along with 0 other arrivals in front of it
[D1 08:32:37 elevator_2] At floor 0
[D1 08:32:37 elevator_2] Stopped at floor 0
[D1 08:32:37 elevator_2] Opening doors
[D1 08:32:40 elevator_2] Opened doors
[D1 08:32:40 citizen_18] Entered elevator_2, going to floor 3
[D1 08:32:40 floor_0] citizen_18 is leaving the queue
[D1 08:32:40 floor_0] citizen_19 was served
[D1 08:32:40 elevator_2] Summoned to floor 0 from floor 0
[D1 08:32:40 citizen_19] Entered elevator_2, going to floor 4
[D1 08:32:40 floor_0] citizen_19 is leaving the queue
[D1 08:32:40 floor_0] The queue is now empty
[D1 08:32:52 elevator_2] Closing doors
[D1 08:32:55 elevator_2] Closed doors
[D1 08:32:55 elevator_2] Changing direction to Up
[D1 08:33:05 elevator_2] At floor 1
[D1 08:33:15 elevator_2] At floor 2
[D1 08:33:25 elevator_2] At floor 3
[D1 08:33:25 elevator_2] Stopped at floor 3
[D1 08:33:25 elevator_2] Opening doors
[D1 08:33:28 elevator_2] Opened doors
[D1 08:33:28 citizen_18] Left elevator_2, arrived at floor 3
[D1 08:33:40 elevator_2] Closing doors
[D1 08:33:43 elevator_2] Closed doors
[D1 08:33:53 elevator_2] At floor 4
[D1 08:33:53 elevator_2] Stopped at floor 4
[D1 08:33:53 elevator_2] Opening doors
[D1 08:33:56 elevator_2] Opened doors
[D1 08:33:56 citizen_19] Left elevator_2, arrived at floor 4
[D1 08:34:08 elevator_2] Closing doors
[D1 08:34:11 elevator_2] Closed doors
[D1 08:34:11 elevator_2] Resting at floor 4
[D1 08:35:40 citizen_5] Time to go to floor 3 and stay there for 00:25:57
[D1 08:35:40 floor_2] citizen_5 entered the queue
[D1 08:35:40 floor_2] citizen_5 found an empty queue and will be served immediately
[D1 08:35:40 elevator_2] Summoned to floor 2 from floor 4
[D1 08:35:40 elevator_2] Sprung into motion, heading Down
[D1 08:35:46 citizen_20] Entered the building, will visit 5 floors in total
[D1 08:35:46 citizen_20] Time to go to floor 4 and stay there for 00:43:35
[D1 08:35:46 floor_0] citizen_20 entered the queue
[D1 08:35:46 floor_0] citizen_20 found an empty queue and will be served immediately
[D1 08:35:46 elevator_2] Summoned to floor 0 from floor 4
[D1 08:35:50 elevator_2] At floor 3
[D1 08:36:00 elevator_2] At floor 2
[D1 08:36:00 elevator_2] Stopped at floor 2
[D1 08:36:00 elevator_2] Opening doors
[D1 08:36:03 elevator_2] Opened doors
[D1 08:36:03 citizen_5] Entered elevator_2, going to floor 3
[D1 08:36:03 floor_2] citizen_5 is leaving the queue
[D1 08:36:03 floor_2] The queue is now empty
[D1 08:36:08 citizen_3] Time to go to floor 4 and stay there for 00:27:00
[D1 08:36:08 floor_1] citizen_3 entered the queue
[D1 08:36:08 floor_1] citizen_3 found an empty queue and will be served immediately
[D1 08:36:08 elevator_2] Summoned to floor 1 from floor 2
[D1 08:36:15 citizen_10] Time to go to floor 1 and stay there for 00:30:20
[D1 08:36:15 floor_3] citizen_10 entered the queue
[D1 08:36:15 floor_3] citizen_10 found an empty queue and will be served immediately
[D1 08:36:15 elevator_2] Summoned to floor 3 from floor 2
[D1 08:36:15 elevator_2] Closing doors
[D1 08:36:18 elevator_2] Closed doors
[D1 08:36:28 elevator_2] At floor 1
[D1 08:36:28 elevator_2] Stopped at floor 1
[D1 08:36:28 elevator_2] Opening doors
[D1 08:36:31 elevator_2] Opened doors
[D1 08:36:31 citizen_3] Entered elevator_2, going to floor 4
[D1 08:36:31 floor_1] citizen_3 is leaving the queue
[D1 08:36:31 floor_1] The queue is now empty
[D1 08:36:43 elevator_2] Closing doors
[D1 08:36:46 elevator_2] Closed doors
[D1 08:36:56 elevator_2] At floor 0
[D1 08:36:56 elevator_2] Stopped at floor 0
[D1 08:36:56 elevator_2] Opening doors
[D1 08:36:59 elevator_2] Opened doors
[D1 08:36:59 citizen_20] Entered elevator_2, going to floor 4
[D1 08:36:59 floor_0] citizen_20 is leaving the queue
[D1 08:36:59 floor_0] The queue is now empty
[D1 08:37:11 elevator_2] Closing doors
[D1 08:37:14 elevator_2] Closed doors
[D1 08:37:14 elevator_2] Changing direction to Up
[D1 08:37:24 elevator_2] At floor 1
[D1 08:37:34 elevator_2] At floor 2
[D1 08:37:44 elevator_2] At floor 3
[D1 08:37:44 elevator_2] Stopped at floor 3
[D1 08:37:44 elevator_2] Opening doors
[D1 08:37:47 elevator_2] Opened doors
[D1 08:37:47 citizen_5] Left elevator_2, arrived at floor 3
[D1 08:37:47 citizen_10] Entered elevator_2, going to floor 1
[D1 08:37:47 floor_3] citizen_10 is leaving the queue
[D1 08:37:47 floor_3] The queue is now empty
[D1 08:37:59 elevator_2] Closing doors
[D1 08:38:02 elevator_2] Closed doors
[D1 08:38:12 elevator_2] At floor 4
[D1 08:38:12 elevator_2] Stopped at floor 4
[D1 08:38:12 elevator_2] Opening doors
[D1 08:38:15 elevator_2] Opened doors
[D1 08:38:15 citizen_3] Left elevator_2, arrived at floor 4
[D1 08:38:15 citizen_20] Left elevator_2, arrived at floor 4
[D1 08:38:27 elevator_2] Closing doors
[D1 08:38:30 elevator_2] Closed doors
[D1 08:38:30 elevator_2] Changing direction to Down
[D1 08:38:40 elevator_2] At floor 3
[D1 08:38:50 elevator_2] At floor 2
[D1 08:39:00 elevator_2] At floor 1
[D1 08:39:00 elevator_2] Stopped at floor 1
[D1 08:39:00 elevator_2] Opening doors
[D1 08:39:03 elevator_2] Opened doors
[D1 08:39:03 citizen_10] Left elevator_2, arrived at floor 1
[D1 08:39:15 elevator_2] Closing doors
[D1 08:39:18 elevator_2] Closed doors
[D1 08:39:18 elevator_2] Resting at floor 1
[D1 08:39:32 citizen_4] Time to go to floor 1 and stay there for 00:28:37
[D1 08:39:32 floor_4] citizen_4 entered the queue
[D1 08:39:32 floor_4] citizen_4 found an empty queue and will be served immediately
[D1 08:39:32 elevator_1] Summoned to floor 4 from floor 5
[D1 08:39:32 elevator_1] Sprung into motion, heading Down
[D1 08:39:42 elevator_1] At floor 4
[D1 08:39:42 elevator_1] Stopped at floor 4
[D1 08:39:42 elevator_1] Opening doors
[D1 08:39:45 elevator_1] Opened doors
[D1 08:39:45 citizen_4] Entered elevator_1, going to floor 1
[D1 08:39:45 floor_4] citizen_4 is leaving the queue
[D1 08:39:45 floor_4] The queue is now empty
[D1 08:39:57 elevator_1] Closing doors
[D1 08:40:00 elevator_1] Closed doors
[D1 08:40:06 citizen_2] Time to go to floor 2 and stay there for 00:23:16
[D1 08:40:06 floor_4] citizen_2 entered the queue
[D1 08:40:06 floor_4] citizen_2 found an empty queue and will be served immediately
[D1 08:40:06 elevator_1] Summoned to floor 4 from floor 4
[D1 08:40:10 elevator_1] At floor 3
[D1 08:40:20 elevator_1] At floor 2
[D1 08:40:30 elevator_1] At floor 1
[D1 08:40:30 elevator_1] Stopped at floor 1
[D1 08:40:30 elevator_1] Opening doors
[D1 08:40:33 elevator_1] Opened doors
[D1 08:40:33 citizen_4] Left elevator_1, arrived at floor 1
[D1 08:40:45 elevator_1] Closing doors
[D1 08:40:48 elevator_1] Closed doors
[D1 08:40:48 elevator_1] Changing direction to Up
[D1 08:40:58 elevator_1] At floor 2
[D1 08:41:08 elevator_1] At floor 3
[D1 08:41:13 citizen_21] Entered the building, will visit 6 floors in total
[D1 08:41:13 citizen_21] Time to go to floor 2 and stay there for 00:30:00
[D1 08:41:13 floor_0] citizen_21 entered the queue
[D1 08:41:13 floor_0] citizen_21 found an empty queue and will be served immediately
[D1 08:41:13 elevator_2] Summoned to floor 0 from floor 1
[D1 08:41:13 elevator_2] Sprung into motion, heading Down
[D1 08:41:18 elevator_1] At floor 4
[D1 08:41:18 elevator_1] Stopped at floor 4
[D1 08:41:18 elevator_1] Opening doors
[D1 08:41:21 elevator_1] Opened doors
[D1 08:41:21 citizen_2] Entered elevator_1, going to floor 2
[D1 08:41:21 floor_4] citizen_2 is leaving the queue
[D1 08:41:21 floor_4] The queue is now empty
[D1 08:41:23 elevator_2] At floor 0
[D1 08:41:23 elevator_2] Stopped at floor 0
[D1 08:41:23 elevator_2] Opening doors
[D1 08:41:26 elevator_2] Opened doors
[D1 08:41:26 citizen_21] Entered elevator_2, going to floor 2
[D1 08:41:26 floor_0] citizen_21 is leaving the queue
[D1 08:41:26 floor_0] The queue is now empty
[D1 08:41:33 elevator_1] Closing doors
[D1 08:41:36 elevator_1] Closed doors
[D1 08:41:36 elevator_1] Changing direction to Down
[D1 08:41:38 elevator_2] Closing doors
[D1 08:41:41 elevator_2] Closed doors
[D1 08:41:41 elevator_2] Changing direction to Up
[D1 08:41:46 elevator_1] At floor 3
[D1 08:41:51 elevator_2] At floor 1
[D1 08:41:56 elevator_1] At floor 2
[D1 08:41:56 elevator_1] Stopped at floor 2
[D1 08:41:56 elevator_1] Opening doors
[D1 08:41:59 citizen_12] Time to go to floor 4 and stay there for 00:30:08
[D1 08:41:59 floor_1] citizen_12 entered the queue
[D1 08:41:59 floor_1] citizen_12 found an empty queue and will be served immediately
[D1 08:41:59 elevator_2] Summoned to floor 1 from floor 1
[D1 08:41:59 elevator_1] Opened doors
[D1 08:41:59 citizen_2] Left elevator_1, arrived at floor 2
[D1 08:42:01 elevator_2] At floor 2
[D1 08:42:01 elevator_2] Stopped at floor 2
[D1 08:42:01 elevator_2] Opening doors
[D1 08:42:04 elevator_2] Opened doors
[D1 08:42:04 citizen_21] Left elevator_2, arrived at floor 2
[D1 08:42:11 elevator_1] Closing doors
[D1 08:42:14 elevator_1] Closed doors
[D1 08:42:14 elevator_1] Resting at floor 2
[D1 08:42:16 elevator_2] Closing doors
[D1 08:42:19 elevator_2] Closed doors
[D1 08:42:19 elevator_2] Changing direction to Down
[D1 08:42:29 elevator_2] At floor 1
[D1 08:42:29 elevator_2] Stopped at floor 1
[D1 08:42:29 elevator_2] Opening doors
[D1 08:42:32 elevator_2] Opened doors
[D1 08:42:32 citizen_12] Entered elevator_2, going to floor 4
[D1 08:42:32 floor_1] citizen_12 is leaving the queue
[D1 08:42:32 floor_1] The queue is now empty
[D1 08:42:44 elevator_2] Closing doors
[D1 08:42:47 elevator_2] Closed doors
[D1 08:42:47 elevator_2] Changing direction to Up
[D1 08:42:57 elevator_2] At floor 2
[D1 08:43:07 elevator_2] At floor 3
[D1 08:43:17 elevator_2] At floor 4
[D1 08:43:17 elevator_2] Stopped at floor 4
[D1 08:43:17 elevator_2] Opening doors
[D1 08:43:20 elevator_2] Opened doors
[D1 08:43:20 citizen_12] Left elevator_2, arrived at floor 4
[D1 08:43:32 elevator_2] Closing doors
[D1 08:43:35 elevator_2] Closed doors
[D1 08:43:35 elevator_2] Resting at floor 4
[D1 08:44:16 citizen_6] Time to go to floor 4 and stay there for 00:32:18
[D1 08:44:16 floor_1] citizen_6 entered the queue
[D1 08:44:16 floor_1] citizen_6 found an empty queue and will be served immediately
[D1 08:44:16 elevator_1] Summoned to floor 1 from floor 2
[D1 08:44:16 elevator_1] Sprung into motion, heading Down
[D1 08:44:26 elevator_1] At floor 1
[D1 08:44:26 elevator_1] Stopped at floor 1
[D1 08:44:26 elevator_1] Opening doors
[D1 08:44:29 elevator_1] Opened doors
[D1 08:44:29 citizen_6] Entered elevator_1, going to floor 4
[D1 08:44:29 floor_1] citizen_6 is leaving the queue
[D1 08:44:29 floor_1] The queue is now empty
[D1 08:44:41 elevator_1] Closing doors
[D1 08:44:44 elevator_1] Closed doors
[D1 08:44:44 elevator_1] Changing direction to Up
[D1 08:44:54 elevator_1] At floor 2
[D1 08:45:04 elevator_1] At floor 3
[D1 08:45:14 elevator_1] At floor 4
[D1 08:45:14 elevator_1] Stopped at floor 4
[D1 08:45:14 elevator_1] Opening doors
[D1 08:45:17 elevator_1] Opened doors
[D1 08:45:17 citizen_6] Left elevator_1, arrived at floor 4
[D1 08:45:29 elevator_1] Closing doors
[D1 08:45:32 elevator_1] Closed doors
[D1 08:45:32 elevator_1] Resting at floor 4
[D1 08:45:42 citizen_22] Entered the building, will visit 4 floors in total
[D1 08:45:42 citizen_22] Time to go to floor 1 and stay there for 00:27:24
[D1 08:45:42 floor_0] citizen_22 entered the queue
[D1 08:45:42 floor_0] citizen_22 found an empty queue and will be served immediately
[D1 08:45:42 elevator_1] Summoned to floor 0 from floor 4
[D1 08:45:42 elevator_1] Sprung into motion, heading Down
[D1 08:45:42 elevator_2] Summoned to floor 0 from floor 4
[D1 08:45:42 elevator_2] Sprung into motion, heading Down
[D1 08:45:52 elevator_1] At floor 3
[D1 08:45:52 elevator_2] At floor 3
[D1 08:46:02 elevator_1] At floor 2
[D1 08:46:02 elevator_2] At floor 2
[D1 08:46:12 elevator_1] At floor 1
[D1 08:46:12 elevator_2] At floor 1
[D1 08:46:17 citizen_7] Time to go to floor 2 and stay there for 00:29:18
[D1 08:46:17 floor_4] citizen_7 entered the queue
[D1 08:46:17 floor_4] citizen_7 found an empty queue and will be served immediately
[D1 08:46:17 elevator_1] Summoned to floor 4 from floor 1
[D1 08:46:17 elevator_2] Summoned to floor 4 from floor 1
[D1 08:46:22 elevator_1] At floor 0
[D1 08:46:22 elevator_1] Stopped at floor 0
[D1 08:46:22 elevator_1] Opening doors
[D1 08:46:22 elevator_2] At floor 0
[D1 08:46:22 elevator_2] Stopped at floor 0
[D1 08:46:22 elevator_2] Opening doors
[D1 08:46:25 elevator_1] Opened doors
[D1 08:46:25 elevator_2] Opened doors
[D1 08:46:25 citizen_22] Entered elevator_1, going to floor 1
[D1 08:46:25 floor_0] citizen_22 is leaving the queue
[D1 08:46:25 floor_0] The queue is now empty
[D1 08:46:37 elevator_1] Closing doors
[D1 08:46:37 elevator_2] Closing doors
[D1 08:46:40 elevator_1] Closed doors
[D1 08:46:40 elevator_2] Closed doors
[D1 08:46:40 elevator_1] Changing direction to Up
[D1 08:46:40 elevator_2] Changing direction to Up
[D1 08:46:46 citizen_23] Entered the building, will visit 3 floors in total
[D1 08:46:46 citizen_23] Time to go to floor 3 and stay there for 00:29:05
[D1 08:46:46 floor_0] citizen_23 entered the queue
[D1 08:46:46 floor_0] citizen_23 found an empty queue and will be served immediately
[D1 08:46:46 elevator_1] Summoned to floor 0 from floor 0
[D1 08:46:46 elevator_2] Summoned to floor 0 from floor 0
[D1 08:46:50 elevator_1] At floor 1
[D1 08:46:50 elevator_1] Stopped at floor 1
[D1 08:46:50 elevator_1] Opening doors
[D1 08:46:50 elevator_2] At floor 1
[D1 08:46:53 elevator_1] Opened doors
[D1 08:46:53 citizen_22] Left elevator_1, arrived at floor 1
[D1 08:47:00 elevator_2] At floor 2
[D1 08:47:05 elevator_1] Closing doors
[D1 08:47:08 elevator_1] Closed doors
[D1 08:47:10 elevator_2] At floor 3
[D1 08:47:18 elevator_1] At floor 2
[D1 08:47:20 elevator_2] At floor 4
[D1 08:47:20 elevator_2] Stopped at floor 4
[D1 08:47:20 elevator_2] Opening doors
[D1 08:47:22 citizen_14] Time to go to floor 1 and stay there for 00:38:13
[D1 08:47:22 floor_2] citizen_14 entered the queue
[D1 08:47:22 floor_2] citizen_14 found an empty queue and will be served immediately
[D1 08:47:22 elevator_1] Summoned to floor 2 from floor 2
[D1 08:47:23 elevator_2] Opened doors
[D1 08:47:23 citizen_7] Entered elevator_2, going to floor 2
[D1 08:47:23 floor_4] citizen_7 is leaving the queue
[D1 08:47:23 floor_4] The queue is now empty
[D1 08:47:28 elevator_1] At floor 3
[D1 08:47:35 elevator_2] Closing doors
[D1 08:47:38 elevator_1] At floor 4
[D1 08:47:38 elevator_1] Stopped at floor 4
[D1 08:47:38 elevator_1] Opening doors
[D1 08:47:38 elevator_2] Closed doors
[D1 08:47:38 elevator_2] Changing direction to Down
[D1 08:47:41 elevator_1] Opened doors
[D1 08:47:48 elevator_2] At floor 3
[D1 08:47:53 elevator_1] Closing doors
[D1 08:47:56 elevator_1] Closed doors
[D1 08:47:56 elevator_1] Changing direction to Down
[D1 08:47:58 elevator_2] At floor 2
[D1 08:47:58 elevator_2] Stopped at floor 2
[D1 08:47:58 elevator_2] Opening doors
[D1 08:48:01 elevator_2] Opened doors
[D1 08:48:01 citizen_7] Left elevator_2, arrived at floor 2
[D1 08:48:06 elevator_1] At floor 3
[D1 08:48:13 elevator_2] Closing doors
[D1 08:48:16 elevator_1] At floor 2
[D1 08:48:16 elevator_1] Stopped at floor 2
[D1 08:48:16 elevator_1] Opening doors
[D1 08:48:16 elevator_2] Closed doors
[D1 08:48:19 elevator_1] Opened doors
[D1 08:48:19 citizen_14] Entered elevator_1, going to floor 1
[D1 08:48:19 floor_2] citizen_14 is leaving the queue
[D1 08:48:19 floor_2] The queue is now empty
[D1 08:48:26 elevator_2] At floor 1
[D1 08:48:31 citizen_24] Entered the building, will visit 4 floors in total
[D1 08:48:31 citizen_24] Time to go to floor 3 and stay there for 00:40:52
[D1 08:48:31 floor_0] citizen_24 entered the queue
[D1 08:48:31 floor_0] citizen_24 is queued along with 0 other arrivals in front of it
[D1 08:48:31 elevator_1] Closing doors
[D1 08:48:34 elevator_1] Closed doors
[D1 08:48:36 elevator_2] At floor 0
[D1 08:48:36 elevator_2] Stopped at floor 0
[D1 08:48:36 elevator_2] Opening doors
[D1 08:48:39 elevator_2] Opened doors
[D1 08:48:39 citizen_23] Entered elevator_2, going to floor 3
[D1 08:48:39 floor_0] citizen_23 is leaving the queue
[D1 08:48:39 floor_0] citizen_24 was served
[D1 08:48:39 elevator_2] Summoned to floor 0 from floor 0
[D1 08:48:39 citizen_24] Entered elevator_2, going to floor 3
[D1 08:48:39 floor_0] citizen_24 is leaving the queue
[D1 08:48:39 floor_0] The queue is now empty
[D1 08:48:44 elevator_1] At floor 1
[D1 08:48:44 elevator_1] Stopped at floor 1
[D1 08:48:44 elevator_1] Opening doors
[D1 08:48:47 elevator_1] Opened doors
[D1 08:48:47 citizen_14] Left elevator_1, arrived at floor 1
[D1 08:48:50 citizen_8] Time to go to floor 1 and stay there for 00:27:15
[D1 08:48:50 floor_3] citizen_8 entered the queue
[D1 08:48:50 floor_3] citizen_8 found an empty queue and will be served immediately
[D1 08:48:50 elevator_1] Summoned to floor 3 from floor 1
[D1 08:48:51 elevator_2] Closing doors
[D1 08:48:54 elevator_2] Closed doors
[D1 08:48:54 elevator_2] Changing direction to Up
[D1 08:48:59 elevator_1] Closing doors
[D1 08:49:02 elevator_1] Closed doors
[D1 08:49:04 elevator_2] At floor 1
[D1 08:49:12 elevator_1] At floor 0
[D1 08:49:12 elevator_1] Stopped at floor 0
[D1 08:49:12 elevator_1] Opening doors
[D1 08:49:14 elevator_2] At floor 2
[D1 08:49:15 elevator_1] Opened doors
[D1 08:49:24 elevator_2] At floor 3
[D1 08:49:24 elevator_2] Stopped at floor 3
[D1 08:49:24 elevator_2] Opening doors
[D1 08:49:27 elevator_1] Closing doors
[D1 08:49:27 elevator_2] Opened doors
[D1 08:49:27 citizen_23] Left elevator_2, arrived at floor 3
[D1 08:49:27 citizen_24] Left elevator_2, arrived at floor 3
[D1 08:49:30 elevator_1] Closed doors
[D1 08:49:30 elevator_1] Changing direction to Up
[D1 08:49:39 elevator_2] Closing doors
[D1 08:49:40 elevator_1] At floor 1
[D1 08:49:42 elevator_2] Closed doors
[D1 08:49:42 elevator_2] Resting at floor 3
[D1 08:49:50 elevator_1] At floor 2
[D1 08:50:00 elevator_1] At floor 3
[D1 08:50:00 elevator_1] Stopped at floor 3
[D1 08:50:00 elevator_1] Opening doors
[D1 08:50:03 elevator_1] Opened doors
[D1 08:50:03 citizen_8] Entered elevator_1, going to floor 1
[D1 08:50:03 floor_3] citizen_8 is leaving the queue
[D1 08:50:03 floor_3] The queue is now empty
[D1 08:50:15 elevator_1] Closing doors
[D1 08:50:18 elevator_1] Closed doors
[D1 08:50:18 elevator_1] Changing direction to Down
[D1 08:50:28 elevator_1] At floor 2
[D1 08:50:38 elevator_1] At floor 1
[D1 08:50:38 elevator_1] Stopped at floor 1
[D1 08:50:38 elevator_1] Opening doors
[D1 08:50:41 elevator_1] Opened doors
[D1 08:50:41 citizen_8] Left elevator_1, arrived at floor 1
[D1 08:50:53 elevator_1] Closing doors
[D1 08:50:56 elevator_1] Closed doors
[D1 08:50:56 elevator_1] Resting at floor 1
[D1 08:51:31 citizen_25] Entered the building, will visit 5 floors in total
[D1 08:51:31 citizen_25] Time to go to floor 5 and stay there for 00:29:06
[D1 08:51:31 floor_0] citizen_25 entered the queue
[D1 08:51:31 floor_0] citizen_25 found an empty queue and will be served immediately
[D1 08:51:31 elevator_1] Summoned to floor 0 from floor 1
[D1 08:51:31 elevator_1] Sprung into motion, heading Down
[D1 08:51:41 elevator_1] At floor 0
[D1 08:51:41 elevator_1] Stopped at floor 0
[D1 08:51:41 elevator_1] Opening doors
[D1 08:51:44 elevator_1] Opened doors
[D1 08:51:44 citizen_25] Entered elevator_1, going to floor 5
[D1 08:51:44 floor_0] citizen_25 is leaving the queue
[D1 08:51:44 floor_0] The queue is now empty
[D1 08:51:56 elevator_1] Closing doors
[D1 08:51:59 elevator_1] Closed doors
[D1 08:51:59 elevator_1] Changing direction to Up
[D1 08:52:09 elevator_1] At floor 1
[D1 08:52:19 elevator_1] At floor 2
[D1 08:52:29 elevator_1] At floor 3
[D1 08:52:33 citizen_17] Time to go to floor 4 and stay there for 00:22:38
[D1 08:52:33 floor_3] citizen_17 entered the queue
[D1 08:52:33 floor_3] citizen_17 found an empty queue and will be served immediately
[D1 08:52:33 elevator_1] Summoned to floor 3 from floor 3
[D1 08:52:33 elevator_2] Summoned to floor 3 from floor 3
[D1 08:52:33 elevator_2] Opening doors
[D1 08:52:36 elevator_2] Opened doors
[D1 08:52:36 citizen_17] Entered elevator_2, going to floor 4
[D1 08:52:36 floor_3] citizen_17 is leaving the queue
[D1 08:52:36 floor_3] The queue is now empty
[D1 08:52:39 elevator_1] At floor 4
[D1 08:52:48 elevator_2] Closing doors
[D1 08:52:48 citizen_26] Entered the building, will visit 3 floors in total
[D1 08:52:48 citizen_26] Time to go to floor 3 and stay there for 00:26:35
[D1 08:52:48 floor_0] citizen_26 entered the queue
[D1 08:52:48 floor_0] citizen_26 found an empty queue and will be served immediately
[D1 08:52:48 elevator_2] Summoned to floor 0 from floor 3
[D1 08:52:49 elevator_1] At floor 5
[D1 08:52:49 elevator_1] Stopped at floor 5
[D1 08:52:49 elevator_1] Opening doors
[D1 08:52:51 elevator_2] Closed doors
[D1 08:52:51 elevator_2] Sprung into motion, heading Up
[D1 08:52:52 elevator_1] Opened doors
[D1 08:52:52 citizen_25] Left elevator_1, arrived at floor 5
[D1 08:53:01 elevator_2] At floor 4
[D1 08:53:01 elevator_2] Stopped at floor 4
[D1 08:53:01 elevator_2] Opening doors
[D1 08:53:04 elevator_1] Closing doors
[D1 08:53:04 elevator_2] Opened doors
[D1 08:53:04 citizen_19] Time to go to floor 5 and stay there for 00:25:40
[D1 08:53:04 floor_4] citizen_19 entered the queue
[D1 08:53:04 floor_4] citizen_19 found an empty queue and will be served immediately
[D1 08:53:04 elevator_2] Summoned to floor 4 from floor 4
[D1 08:53:04 citizen_19] Entered elevator_2, going to floor 5
[D1 08:53:04 floor_4] citizen_19 is leaving the queue
[D1 08:53:04 floor_4] The queue is now empty
[D1 08:53:04 citizen_17] Left elevator_2, arrived at floor 4
[D1 08:53:07 elevator_1] Closed doors
[D1 08:53:07 elevator_1] Changing direction to Down
[D1 08:53:16 elevator_2] Closing doors
[D1 08:53:17 elevator_1] At floor 4
[D1 08:53:19 elevator_2] Closed doors
[D1 08:53:27 elevator_1] At floor 3
[D1 08:53:27 elevator_1] Stopped at floor 3
[D1 08:53:27 elevator_1] Opening doors
[D1 08:53:29 elevator_2] At floor 5
[D1 08:53:29 elevator_2] Stopped at floor 5
[D1 08:53:29 elevator_2] Opening doors
[D1 08:53:30 elevator_1] Opened doors
[D1 08:53:32 elevator_2] Opened doors
[D1 08:53:32 citizen_19] Left elevator_2, arrived at floor 5
[D1 08:53:42 elevator_1] Closing doors
[D1 08:53:44 elevator_2] Closing doors
[D1 08:53:45 elevator_1] Closed doors
[D1 08:53:45 elevator_1] Resting at floor 3
[D1 08:53:47 elevator_2] Closed doors
[D1 08:53:47 elevator_2] Changing direction to Down
[D1 08:53:57 elevator_2] At floor 4
[D1 08:54:07 elevator_2] At floor 3
[D1 08:54:13 citizen_9] Time to go to floor 2 and stay there for 00:30:46
[D1 08:54:13 floor_1] citizen_9 entered the queue
[D1 08:54:13 floor_1] citizen_9 found an empty queue and will be served immediately
[D1 08:54:13 elevator_1] Summoned to floor 1 from floor 3
[D1 08:54:13 elevator_1] Sprung into motion, heading Down
[D1 08:54:13 elevator_2] Summoned to floor 1 from floor 3
[D1 08:54:17 elevator_2] At floor 2
[D1 08:54:23 elevator_1] At floor 2
[D1 08:54:27 elevator_2] At floor 1
[D1 08:54:27 elevator_2] Stopped at floor 1
[D1 08:54:27 elevator_2] Opening doors
[D1 08:54:30 elevator_2] Opened doors
[D1 08:54:30 citizen_9] Entered elevator_2, going to floor 2
[D1 08:54:30 floor_1] citizen_9 is leaving the queue
[D1 08:54:30 floor_1] The queue is now empty
[D1 08:54:33 elevator_1] At floor 1
[D1 08:54:33 elevator_1] Stopped at floor 1
[D1 08:54:33 elevator_1] Opening doors
[D1 08:54:36 elevator_1] Opened doors
[D1 08:54:42 elevator_2] Closing doors
[D1 08:54:45 elevator_2] Closed doors
[D1 08:54:48 elevator_1] Closing doors
[D1 08:54:51 elevator_1] Closed doors
[D1 08:54:51 elevator_1] Resting at floor 1
[D1 08:54:55 elevator_2] At floor 0
[D1 08:54:55 elevator_2] Stopped at floor 0
[D1 08:54:55 elevator_2] Opening doors
[D1 08:54:58 elevator_2] Opened doors
[D1 08:54:58 citizen_26] Entered elevator_2, going to floor 3
[D1 08:54:58 floor_0] citizen_26 is leaving the queue
[D1 08:54:58 floor_0] The queue is now empty
[D1 08:55:10 elevator_2] Closing doors
[D1 08:55:13 elevator_2] Closed doors
[D1 08:55:13 elevator_2] Changing direction to Up
[D1 08:55:17 citizen_27] Entered the building, will visit 3 floors in total
[D1 08:55:17 citizen_27] Time to go to floor 2 and stay there for 00:29:14
[D1 08:55:17 floor_0] citizen_27 entered the queue
[D1 08:55:17 floor_0] citizen_27 found an empty queue and will be served immediately
[D1 08:55:17 elevator_2] Summoned to floor 0 from floor 0
[D1 08:55:23 elevator_2] At floor 1
[D1 08:55:26 citizen_15] Time to go to floor 3 and stay there for 00:30:57
[D1 08:55:26 floor_5] citizen_15 entered the queue
[D1 08:55:26 floor_5] citizen_15 found an empty queue and will be served immediately
[D1 08:55:26 elevator_1] Summoned to floor 5 from floor 1
[D1 08:55:26 elevator_1] Sprung into motion, heading Up
[D1 08:55:26 elevator_2] Summoned to floor 5 from floor 1
[D1 08:55:33 elevator_2] At floor 2
[D1 08:55:33 elevator_2] Stopped at floor 2
[D1 08:55:33 elevator_2] Opening doors
[D1 08:55:36 elevator_1] At floor 2
[D1 08:55:36 elevator_2] Opened doors
[D1 08:55:36 citizen_9] Left elevator_2, arrived at floor 2
[D1 08:55:46 elevator_1] At floor 3
[D1 08:55:48 elevator_2] Closing doors
[D1 08:55:51 elevator_2] Closed doors
[D1 08:55:56 elevator_1] At floor 4
[D1 08:56:01 elevator_2] At floor 3
[D1 08:56:01 elevator_2] Stopped at floor 3
[D1 08:56:01 elevator_2] Opening doors
[D1 08:56:04 elevator_2] Opened doors
[D1 08:56:04 citizen_26] Left elevator_2, arrived at floor 3
[D1 08:56:06 elevator_1] At floor 5
[D1 08:56:06 elevator_1] Stopped at floor 5
[D1 08:56:06 elevator_1] Opening doors
[D1 08:56:09 elevator_1] Opened doors
[D1 08:56:09 citizen_15] Entered elevator_1, going to floor 3
[D1 08:56:09 floor_5] citizen_15 is leaving the queue
[D1 08:56:09 floor_5] The queue is now empty
[D1 08:56:16 elevator_2] Closing doors
[D1 08:56:19 elevator_2] Closed doors
[D1 08:56:21 elevator_1] Closing doors
[D1 08:56:24 elevator_1] Closed doors
[D1 08:56:24 elevator_1] Changing direction to Down
[D1 08:56:29 elevator_2] At floor 4
[D1 08:56:34 elevator_1] At floor 4
[D1 08:56:39 elevator_2] At floor 5
[D1 08:56:39 elevator_2] Stopped at floor 5
[D1 08:56:39 elevator_2] Opening doors
[D1 08:56:42 elevator_2] Opened doors
[D1 08:56:44 elevator_1] At floor 3
[D1 08:56:44 elevator_1] Stopped at floor 3
[D1 08:56:44 elevator_1] Opening doors
[D1 08:56:47 elevator_1] Opened doors
[D1 08:56:47 citizen_15] Left elevator_1, arrived at floor 3
[D1 08:56:54 elevator_2] Closing doors
[D1 08:56:57 elevator_2] Closed doors
[D1 08:56:57 elevator_2] Changing direction to Down
[D1 08:56:59 elevator_1] Closing doors
[D1 08:57:00 citizen_28] Entered the building, will visit 5 floors in total
[D1 08:57:00 citizen_28] Time to go to floor 2 and stay there for 00:30:51
[D1 08:57:00 floor_0] citizen_28 entered the queue
[D1 08:57:00 floor_0] citizen_28 is queued along with 0 other arrivals in front of it
[D1 08:57:02 elevator_1] Closed doors
[D1 08:57:02 elevator_1] Resting at floor 3
[D1 08:57:07 elevator_2] At floor 4
[D1 08:57:17 elevator_2] At floor 3
[D1 08:57:27 elevator_2] At floor 2
[D1 08:57:37 elevator_2] At floor 1
[D1 08:57:47 elevator_2] At floor 0
[D1 08:57:47 elevator_2] Stopped at floor 0
[D1 08:57:47 elevator_2] Opening doors
[D1 08:57:50 elevator_2] Opened doors
[D1 08:57:50 citizen_27] Entered elevator_2, going to floor 2
[D1 08:57:50 floor_0] citizen_27 is leaving the queue
[D1 08:57:50 floor_0] citizen_28 was served
[D1 08:57:50 elevator_2] Summoned to floor 0 from floor 0
[D1 08:57:50 citizen_28] Entered elevator_2, going to floor 2
[D1 08:57:50 floor_0] citizen_28 is leaving the queue
[D1 08:57:50 floor_0] The queue is now empty
[D1 08:58:02 elevator_2] Closing doors
[D1 08:58:05 elevator_2] Closed doors
[D1 08:58:05 elevator_2] Changing direction to Up
[D1 08:58:15 elevator_2] At floor 1
[D1 08:58:25 elevator_2] At floor 2
[D1 08:58:25 elevator_2] Stopped at floor 2
[D1 08:58:25 elevator_2] Opening doors
[D1 08:58:28 elevator_2] Opened doors
[D1 08:58:28 citizen_27] Left elevator_2, arrived at floor 2
[D1 08:58:28 citizen_28] Left elevator_2, arrived at floor 2
[D1 08:58:40 elevator_2] Closing doors
[D1 08:58:43 elevator_2] Closed doors
[D1 08:58:43 elevator_2] Resting at floor 2
[D1 08:59:25 citizen_1] Time to go to floor 3 and stay there for 00:16:07
[D1 08:59:25 floor_2] citizen_1 entered the queue
[D1 08:59:25 floor_2] citizen_1 found an empty queue and will be served immediately
[D1 08:59:25 elevator_2] Summoned to floor 2 from floor 2
[D1 08:59:25 elevator_2] Opening doors
[D1 08:59:28 elevator_2] Opened doors
[D1 08:59:28 citizen_1] Entered elevator_2, going to floor 3
[D1 08:59:28 floor_2] citizen_1 is leaving the queue
[D1 08:59:28 floor_2] The queue is now empty
[D1 08:59:40 elevator_2] Closing doors
[D1 08:59:43 elevator_2] Closed doors
[D1 08:59:43 elevator_2] Sprung into motion, heading Up
[D1 08:59:53 elevator_2] At floor 3
[D1 08:59:53 elevator_2] Stopped at floor 3
[D1 08:59:53 elevator_2] Opening doors
[D1 08:59:56 elevator_2] Opened doors
[D1 08:59:56 citizen_1] Left elevator_2, arrived at floor 3
[D1 09:00:08 elevator_2] Closing doors
[D1 09:00:11 elevator_2] Closed doors
[D1 09:00:11 elevator_2] Resting at floor 3
[D1 09:00:36 citizen_29] Entered the building, will visit 4 floors in total
[D1 09:00:36 citizen_29] Time to go to floor 2 and stay there for 00:34:20
[D1 09:00:36 floor_0] citizen_29 entered the queue
[D1 09:00:36 floor_0] citizen_29 found an empty queue and will be served immediately
[D1 09:00:36 elevator_1] Summoned to floor 0 from floor 3
[D1 09:00:36 elevator_1] Sprung into motion, heading Down
[D1 09:00:36 elevator_2] Summoned to floor 0 from floor 3
[D1 09:00:36 elevator_2] Sprung into motion, heading Down
[D1 09:00:46 elevator_1] At floor 2
[D1 09:00:46 elevator_2] At floor 2
[D1 09:00:56 elevator_1] At floor 1
[D1 09:00:56 elevator_2] At floor 1
[D1 09:01:06 elevator_1] At floor 0
[D1 09:01:06 elevator_1] Stopped at floor 0
[D1 09:01:06 elevator_1] Opening doors
[D1 09:01:06 elevator_2] At floor 0
[D1 09:01:06 elevator_2] Stopped at floor 0
[D1 09:01:06 elevator_2] Opening doors
[D1 09:01:09 elevator_1] Opened doors
[D1 09:01:09 elevator_2] Opened doors
[D1 09:01:09 citizen_29] Entered elevator_1, going to floor 2
[D1 09:01:09 floor_0] citizen_29 is leaving the queue
[D1 09:01:09 floor_0] The queue is now empty
[D1 09:01:21 elevator_1] Closing doors
[D1 09:01:21 elevator_2] Closing doors
[D1 09:01:24 elevator_1] Closed doors
[D1 09:01:24 elevator_2] Closed doors
[D1 09:01:24 elevator_1] Changing direction to Up
[D1 09:01:24 elevator_2] Resting at floor 0
[D1 09:01:34 elevator_1] At floor 1
[D1 09:01:44 elevator_1] At floor 2
[D1 09:01:44 elevator_1] Stopped at floor 2
[D1 09:01:44 elevator_1] Opening doors
[D1 09:01:45 citizen_13] Time to go to floor 4 and stay there for 00:24:37
[D1 09:01:45 floor_5] citizen_13 entered the queue
[D1 09:01:45 floor_5] citizen_13 found an empty queue and will be served immediately
[D1 09:01:45 elevator_1] Summoned to floor 5 from floor 2
[D1 09:01:47 elevator_1] Opened doors
[D1 09:01:47 citizen_29] Left elevator_1, arrived at floor 2
[D1 09:01:59 elevator_1] Closing doors
[D1 09:02:02 elevator_1] Closed doors
[D1 09:02:12 elevator_1] At floor 3
[D1 09:02:13 citizen_30] Entered the building, will visit 5 floors in total
[D1 09:02:13 citizen_30] Time to go to floor 5 and stay there for 00:23:58
[D1 09:02:13 floor_0] citizen_30 entered the queue
[D1 09:02:13 floor_0] citizen_30 found an empty queue and will be served immediately
[D1 09:02:13 elevator_2] Summoned to floor 0 from floor 0
[D1 09:02:13 elevator_2] Opening doors
[D1 09:02:16 elevator_2] Opened doors
[D1 09:02:16 citizen_30] Entered elevator_2, going to floor 5
[D1 09:02:16 floor_0] citizen_30 is leaving the queue
[D1 09:02:16 floor_0] The queue is now empty
[D1 09:02:22 elevator_1] At floor 4
[D1 09:02:28 elevator_2] Closing doors
[D1 09:02:31 elevator_2] Closed doors
[D1 09:02:31 elevator_2] Sprung into motion, heading Up
[D1 09:02:32 elevator_1] At floor 5
[D1 09:02:32 elevator_1] Stopped at floor 5
[D1 09:02:32 elevator_1] Opening doors
[D1 09:02:35 elevator_1] Opened doors
[D1 09:02:35 citizen_13] Entered elevator_1, going to floor 4
[D1 09:02:35 floor_5] citizen_13 is leaving the queue
[D1 09:02:35 floor_5] The queue is now empty
[D1 09:02:41 elevator_2] At floor 1
[D1 09:02:47 elevator_1] Closing doors
[D1 09:02:50 elevator_1] Closed doors
[D1 09:02:50 elevator_1] Changing direction to Down
[D1 09:02:51 elevator_2] At floor 2
[D1 09:03:00 elevator_1] At floor 4
[D1 09:03:00 elevator_1] Stopped at floor 4
[D1 09:03:00 elevator_1] Opening doors
[D1 09:03:01 elevator_2] At floor 3
[D1 09:03:03 elevator_1] Opened doors
[D1 09:03:03 citizen_13] Left elevator_1, arrived at floor 4
[D1 09:03:11 elevator_2] At floor 4
[D1 09:03:13 citizen_18] Time to go to floor 2 and stay there for 00:38:12
[D1 09:03:13 floor_3] citizen_18 entered the queue
[D1 09:03:13 floor_3] citizen_18 found an empty queue and will be served immediately
[D1 09:03:13 elevator_1] Summoned to floor 3 from floor 4
[D1 09:03:13 elevator_2] Summoned to floor 3 from floor 4
[D1 09:03:15 elevator_1] Closing doors
[D1 09:03:18 elevator_1] Closed doors
[D1 09:03:21 elevator_2] At floor 5
[D1 09:03:21 elevator_2] Stopped at floor 5
[D1 09:03:21 elevator_2] Opening doors
[D1 09:03:24 elevator_2] Opened doors
[D1 09:03:24 citizen_30] Left elevator_2, arrived at floor 5
[D1 09:03:28 elevator_1] At floor 3
[D1 09:03:28 elevator_1] Stopped at floor 3
[D1 09:03:28 elevator_1] Opening doors
[D1 09:03:31 elevator_1] Opened doors
[D1 09:03:31 citizen_18] Entered elevator_1, going to floor 2
[D1 09:03:31 floor_3] citizen_18 is leaving the queue
[D1 09:03:31 floor_3] The queue is now empty
[D1 09:03:36 elevator_2] Closing doors
[D1 09:03:39 elevator_2] Closed doors
[D1 09:03:39 elevator_2] Changing direction to Down
[D1 09:03:43 elevator_1] Closing doors
[D1 09:03:44 citizen_5] Time to go to floor 1 and stay there for 00:40:04
[D1 09:03:44 floor_3] citizen_5 entered the queue
[D1 09:03:44 floor_3] citizen_5 found an empty queue and will be served immediately
[D1 09:03:44 elevator_1] Summoned to floor 3 from floor 3
[D1 09:03:46 elevator_1] Reopening doors
[D1 09:03:46 citizen_5] Entered elevator_1, going to floor 1
[D1 09:03:46 floor_3] citizen_5 is leaving the queue
[D1 09:03:46 floor_3] The queue is now empty
[D1 09:03:49 elevator_2] At floor 4
[D1 09:03:58 elevator_1] Closing doors
[D1 09:03:59 elevator_2] At floor 3
[D1 09:03:59 elevator_2] Stopped at floor 3
[D1 09:03:59 elevator_2] Opening doors
[D1 09:04:01 elevator_1] Closed doors
[D1 09:04:02 elevator_2] Opened doors
[D1 09:04:11 elevator_1] At floor 2
[D1 09:04:11 elevator_1] Stopped at floor 2
[D1 09:04:11 elevator_1] Opening doors
[D1 09:04:14 elevator_2] Closing doors
[D1 09:04:14 elevator_1] Opened doors
[D1 09:04:14 citizen_18] Left elevator_1, arrived at floor 2
[D1 09:04:17 elevator_2] Closed doors
[D1 09:04:17 elevator_2] Resting at floor 3
[D1 09:04:26 elevator_1] Closing doors
[D1 09:04:29 elevator_1] Closed doors
[D1 09:04:39 elevator_1] At floor 1
[D1 09:04:39 elevator_1] Stopped at floor 1
[D1 09:04:39 elevator_1] Opening doors
[D1 09:04:42 elevator_1] Opened doors
[D1 09:04:42 citizen_5] Left elevator_1, arrived at floor 1
[D1 09:04:54 elevator_1] Closing doors
[D1 09:04:57 elevator_1] Closed doors
[D1 09:04:57 elevator_1] Resting at floor 1
[D1 09:05:15 citizen_3] Time to go to floor 1 and stay there for 00:35:00
[D1 09:05:15 floor_4] citizen_3 entered the queue
[D1 09:05:15 floor_4] citizen_3 found an empty queue and will be served immediately
[D1 09:05:15 elevator_2] Summoned to floor 4 from floor 3
[D1 09:05:15 elevator_2] Sprung into motion, heading Up
[D1 09:05:15 citizen_2] Time to go to floor 3 and stay there for 00:37:45
[D1 09:05:15 floor_2] citizen_2 entered the queue
[D1 09:05:15 floor_2] citizen_2 found an empty queue and will be served immediately
[D1 09:05:15 elevator_1] Summoned to floor 2 from floor 1
[D1 09:05:15 elevator_1] Sprung into motion, heading Up
[D1 09:05:15 elevator_2] Summoned to floor 2 from floor 3
[D1 09:05:25 elevator_2] At floor 4
[D1 09:05:25 elevator_2] Stopped at floor 4
[D1 09:05:25 elevator_2] Opening doors
[D1 09:05:25 elevator_1] At floor 2
[D1 09:05:25 elevator_1] Stopped at floor 2
[D1 09:05:25 elevator_1] Opening doors
[D1 09:05:28 elevator_2] Opened doors
[D1 09:05:28 elevator_1] Opened doors
[D1 09:05:28 citizen_3] Entered elevator_2, going to floor 1
[D1 09:05:28 citizen_2] Entered elevator_1, going to floor 3
[D1 09:05:28 floor_4] citizen_3 is leaving the queue
[D1 09:05:28 floor_4] The queue is now empty
[D1 09:05:28 floor_2] citizen_2 is leaving the queue
[D1 09:05:28 floor_2] The queue is now empty
[D1 09:05:40 elevator_1] Closing doors
[D1 09:05:40 elevator_2] Closing doors
[D1 09:05:43 elevator_1] Closed doors
[D1 09:05:43 elevator_2] Closed doors
[D1 09:05:43 elevator_2] Changing direction to Down
[D1 09:05:44 citizen_31] Entered the building, will visit 4 floors in total
[D1 09:05:44 citizen_31] Time to go to floor 1 and stay there for 00:33:12
[D1 09:05:44 floor_0] citizen_31 entered the queue
[D1 09:05:44 floor_0] citizen_31 found an empty queue and will be served immediately
[D1 09:05:44 elevator_1] Summoned to floor 0 from floor 2
[D1 09:05:53 elevator_1] At floor 3
[D1 09:05:53 elevator_1] Stopped at floor 3
[D1 09:05:53 elevator_1] Opening doors
[D1 09:05:53 elevator_2] At floor 3
[D1 09:05:56 elevator_1] Opened doors
[D1 09:05:56 citizen_2] Left elevator_1, arrived at floor 3
[D1 09:06:03 elevator_2] At floor 2
[D1 09:06:03 elevator_2] Stopped at floor 2
[D1 09:06:03 elevator_2] Opening doors
[D1 09:06:06 elevator_2] Opened doors
[D1 09:06:08 elevator_1] Closing doors
[D1 09:06:11 elevator_1] Closed doors
[D1 09:06:11 elevator_1] Changing direction to Down
[D1 09:06:18 elevator_2] Closing doors
[D1 09:06:21 elevator_1] At floor 2
[D1 09:06:21 elevator_2] Closed doors
[D1 09:06:31 elevator_1] At floor 1
[D1 09:06:31 elevator_2] At floor 1
[D1 09:06:31 elevator_2] Stopped at floor 1
[D1 09:06:31 elevator_2] Opening doors
[D1 09:06:34 elevator_2] Opened doors
[D1 09:06:34 citizen_3] Left elevator_2, arrived at floor 1
[D1 09:06:41 elevator_1] At floor 0
[D1 09:06:41 elevator_1] Stopped at floor 0
[D1 09:06:41 elevator_1] Opening doors
[D1 09:06:44 citizen_11] Time to go to floor 1 and stay there for 00:26:27
[D1 09:06:44 floor_3] citizen_11 entered the queue
[D1 09:06:44 floor_3] citizen_11 found an empty queue and will be served immediately
[D1 09:06:44 elevator_2] Summoned to floor 3 from floor 1
[D1 09:06:44 elevator_1] Opened doors
[D1 09:06:44 citizen_31] Entered elevator_1, going to floor 1
[D1 09:06:44 floor_0] citizen_31 is leaving the queue
[D1 09:06:44 floor_0] The queue is now empty
[D1 09:06:46 elevator_2] Closing doors
[D1 09:06:49 elevator_2] Closed doors
[D1 09:06:49 elevator_2] Changing direction to Up
[D1 09:06:56 elevator_1] Closing doors
[D1 09:06:59 elevator_2] At floor 2
[D1 09:06:59 elevator_1] Closed doors
[D1 09:06:59 elevator_1] Changing direction to Up
[D1 09:07:09 elevator_2] At floor 3
[D1 09:07:09 elevator_2] Stopped at floor 3
[D1 09:07:09 elevator_2] Opening doors
[D1 09:07:09 elevator_1] At floor 1
[D1 09:07:09 elevator_1] Stopped at floor 1
[D1 09:07:09 elevator_1] Opening doors
[D1 09:07:12 elevator_2] Opened doors
[D1 09:07:12 elevator_1] Opened doors
[D1 09:07:12 citizen_31] Left elevator_1, arrived at floor 1
[D1 09:07:12 citizen_11] Entered elevator_2, going to floor 1
[D1 09:07:12 floor_3] citizen_11 is leaving the queue
[D1 09:07:12 floor_3] The queue is now empty
[D1 09:07:24 elevator_2] Closing doors
[D1 09:07:24 elevator_1] Closing doors
[D1 09:07:27 elevator_2] Closed doors
[D1 09:07:27 elevator_1] Closed doors
[D1 09:07:27 elevator_2] Changing direction to Down
[D1 09:07:27 elevator_1] Resting at floor 1
[D1 09:07:37 elevator_2] At floor 2
[D1 09:07:47 elevator_2] At floor 1
[D1 09:07:47 elevator_2] Stopped at floor 1
[D1 09:07:47 elevator_2] Opening doors
[D1 09:07:50 elevator_2] Opened doors
[D1 09:07:50 citizen_11] Left elevator_2, arrived at floor 1
[D1 09:08:02 elevator_2] Closing doors
[D1 09:08:05 citizen_16] Time to go to floor 1 and stay there for 00:29:08
[D1 09:08:05 floor_2] citizen_16 entered the queue
[D1 09:08:05 floor_2] citizen_16 found an empty queue and will be served immediately
[D1 09:08:05 elevator_1] Summoned to floor 2 from floor 1
[D1 09:08:05 elevator_1] Sprung into motion, heading Up
[D1 09:08:05 elevator_2] Summoned to floor 2 from floor 1
[D1 09:08:05 elevator_2] Closed doors
[D1 09:08:05 elevator_2] Changing direction to Up
[D1 09:08:15 elevator_1] At floor 2
[D1 09:08:15 elevator_1] Stopped at floor 2
[D1 09:08:15 elevator_1] Opening doors
[D1 09:08:15 elevator_2] At floor 2
[D1 09:08:15 elevator_2] Stopped at floor 2
[D1 09:08:15 elevator_2] Opening doors
[D1 09:08:18 elevator_1] Opened doors
[D1 09:08:18 elevator_2] Opened doors
[D1 09:08:18 citizen_16] Entered elevator_1, going to floor 1
[D1 09:08:18 floor_2] citizen_16 is leaving the queue
[D1 09:08:18 floor_2] The queue is now empty
[D1 09:08:30 elevator_1] Closing doors
[D1 09:08:30 elevator_2] Closing doors
[D1 09:08:33 elevator_1] Closed doors
[D1 09:08:33 elevator_2] Closed doors
[D1 09:08:33 elevator_1] Changing direction to Down
[D1 09:08:33 elevator_2] Resting at floor 2
[D1 09:08:43 elevator_1] At floor 1
[D1 09:08:43 elevator_1] Stopped at floor 1
[D1 09:08:43 elevator_1] Opening doors
[D1 09:08:46 elevator_1] Opened doors
[D1 09:08:46 citizen_16] Left elevator_1, arrived at floor 1
[D1 09:08:58 elevator_1] Closing doors
[D1 09:09:01 elevator_1] Closed doors
[D1 09:09:01 elevator_1] Resting at floor 1
[D1 09:09:10 citizen_4] Time to go to floor 5 and stay there for 00:17:27
[D1 09:09:10 floor_1] citizen_4 entered the queue
[D1 09:09:10 floor_1] citizen_4 found an empty queue and will be served immediately
[D1 09:09:10 elevator_1] Summoned to floor 1 from floor 1
[D1 09:09:10 elevator_1] Opening doors
[D1 09:09:13 elevator_1] Opened doors
[D1 09:09:13 citizen_4] Entered elevator_1, going to floor 5
[D1 09:09:13 floor_1] citizen_4 is leaving the queue
[D1 09:09:13 floor_1] The queue is now empty
[D1 09:09:23 citizen_10] Time to go to floor 4 and stay there for 00:38:34
[D1 09:09:23 floor_1] citizen_10 entered the queue
[D1 09:09:23 floor_1] citizen_10 found an empty queue and will be served immediately
[D1 09:09:23 elevator_1] Summoned to floor 1 from floor 1
[D1 09:09:23 citizen_10] Entered elevator_1, going to floor 4
[D1 09:09:23 floor_1] citizen_10 is leaving the queue
[D1 09:09:23 floor_1] The queue is now empty
[D1 09:09:25 elevator_1] Closing doors
[D1 09:09:28 elevator_1] Closed doors
[D1 09:09:28 elevator_1] Sprung into motion, heading Up
[D1 09:09:38 elevator_1] At floor 2
[D1 09:09:48 elevator_1] At floor 3
[D1 09:09:58 elevator_1] At floor 4
[D1 09:09:58 elevator_1] Stopped at floor 4
[D1 09:09:58 elevator_1] Opening doors
[D1 09:10:01 elevator_1] Opened doors
[D1 09:10:01 citizen_10] Left elevator_1, arrived at floor 4
[D1 09:10:13 elevator_1] Closing doors
[D1 09:10:16 elevator_1] Closed doors
[D1 09:10:26 elevator_1] At floor 5
[D1 09:10:26 elevator_1] Stopped at floor 5
[D1 09:10:26 elevator_1] Opening doors
[D1 09:10:29 elevator_1] Opened doors
[D1 09:10:29 citizen_4] Left elevator_1, arrived at floor 5
[D1 09:10:41 elevator_1] Closing doors
[D1 09:10:44 elevator_1] Closed doors
[D1 09:10:44 elevator_1] Resting at floor 5
[D1 09:10:45 citizen_32] Entered the building, will visit 6 floors in total
[D1 09:10:45 citizen_32] Time to go to floor 5 and stay there for 00:19:09
[D1 09:10:45 floor_0] citizen_32 entered the queue
[D1 09:10:45 floor_0] citizen_32 found an empty queue and will be served immediately
[D1 09:10:45 elevator_2] Summoned to floor 0 from floor 2
[D1 09:10:45 elevator_2] Sprung into motion, heading Down
[D1 09:10:55 elevator_2] At floor 1
[D1 09:11:05 elevator_2] At floor 0
[D1 09:11:05 elevator_2] Stopped at floor 0
[D1 09:11:05 elevator_2] Opening doors
[D1 09:11:08 elevator_2] Opened doors
[D1 09:11:08 citizen_32] Entered elevator_2, going to floor 5
[D1 09:11:08 floor_0] citizen_32 is leaving the queue
[D1 09:11:08 floor_0] The queue is now empty
[D1 09:11:20 elevator_2] Closing doors
[D1 09:11:23 elevator_2] Closed doors
[D1 09:11:23 elevator_2] Changing direction to Up
[D1 09:11:33 elevator_2] At floor 1
[D1 09:11:43 elevator_2] At floor 2
[D1 09:11:53 elevator_2] At floor 3
[D1 09:12:03 elevator_2] At floor 4
[D1 09:12:04 citizen_21] Time to go to floor 3 and stay there for 00:28:17
[D1 09:12:04 floor_2] citizen_21 entered the queue
[D1 09:12:04 floor_2] citizen_21 found an empty queue and will be served immediately
[D1 09:12:04 elevator_2] Summoned to floor 2 from floor 4
[D1 09:12:13 elevator_2] At floor 5
[D1 09:12:13 elevator_2] Stopped at floor 5
[D1 09:12:13 elevator_2] Opening doors
[D1 09:12:16 elevator_2] Opened doors
[D1 09:12:16 citizen_32] Left elevator_2, arrived at floor 5
[D1 09:12:28 elevator_2] Closing doors
[D1 09:12:31 elevator_2] Closed doors
[D1 09:12:31 elevator_2] Changing direction to Down
[D1 09:12:41 elevator_2] At floor 4
[D1 09:12:51 elevator_2] At floor 3
[D1 09:13:01 elevator_2] At floor 2
[D1 09:13:01 elevator_2] Stopped at floor 2
[D1 09:13:01 elevator_2] Opening doors
[D1 09:13:04 elevator_2] Opened doors
[D1 09:13:04 citizen_21] Entered elevator_2, going to floor 3
[D1 09:13:04 floor_2] citizen_21 is leaving the queue
[D1 09:13:04 floor_2] The queue is now empty
[D1 09:13:16 elevator_2] Closing doors
[D1 09:13:19 elevator_2] Closed doors
[D1 09:13:19 elevator_2] Changing direction to Up
[D1 09:13:28 citizen_12] Time to go to floor 2 and stay there for 00:24:53
[D1 09:13:28 floor_4] citizen_12 entered the queue
[D1 09:13:28 floor_4] citizen_12 found an empty queue and will be served immediately
[D1 09:13:28 elevator_1] Summoned to floor 4 from floor 5
[D1 09:13:28 elevator_1] Sprung into motion, heading Down
[D1 09:13:29 elevator_2] At floor 3
[D1 09:13:29 elevator_2] Stopped at floor 3
[D1 09:13:29 elevator_2] Opening doors
[D1 09:13:32 elevator_2] Opened doors
[D1 09:13:32 citizen_21] Left elevator_2, arrived at floor 3
[D1 09:13:38 elevator_1] At floor 4
[D1 09:13:38 elevator_1] Stopped at floor 4
[D1 09:13:38 elevator_1] Opening doors
[D1 09:13:41 elevator_1] Opened doors
[D1 09:13:41 citizen_12] Entered elevator_1, going to floor 2
[D1 09:13:41 floor_4] citizen_12 is leaving the queue
[D1 09:13:41 floor_4] The queue is now empty
[D1 09:13:44 elevator_2] Closing doors
[D1 09:13:47 elevator_2] Closed doors
[D1 09:13:47 elevator_2] Resting at floor 3
[D1 09:13:50 citizen_33] Entered the building, will visit 3 floors in total
[D1 09:13:50 citizen_33] Time to go to floor 1 and stay there for 00:25:08
[D1 09:13:50 floor_0] citizen_33 entered the queue
[D1 09:13:50 floor_0] citizen_33 found an empty queue and will be served immediately
[D1 09:13:50 elevator_2] Summoned to floor 0 from floor 3
[D1 09:13:50 elevator_2] Sprung into motion, heading Down
[D1 09:13:53 elevator_1] Closing doors
[D1 09:13:56 elevator_1] Closed doors
[D1 09:14:00 elevator_2] At floor 2
[D1 09:14:06 elevator_1] At floor 3
[D1 09:14:10 elevator_2] At floor 1
[D1 09:14:16 elevator_1] At floor 2
[D1 09:14:16 elevator_1] Stopped at floor 2
[D1 09:14:16 elevator_1] Opening doors
[D1 09:14:17 citizen_22] Time to go to floor 3 and stay there for 00:19:17
[D1 09:14:17 floor_1] citizen_22 entered the queue
[D1 09:14:17 floor_1] citizen_22 found an empty queue and will be served immediately
[D1 09:14:17 elevator_2] Summoned to floor 1 from floor 1
[D1 09:14:19 elevator_1] Opened doors
[D1 09:14:19 citizen_12] Left elevator_1, arrived at floor 2
[D1 09:14:20 elevator_2] At floor 0
[D1 09:14:20 elevator_2] Stopped at floor 0
[D1 09:14:20 elevator_2] Opening doors
[D1 09:14:23 elevator_2] Opened doors
[D1 09:14:23 citizen_33] Entered elevator_2, going to floor 1
[D1 09:14:23 floor_0] citizen_33 is leaving the queue
[D1 09:14:23 floor_0] The queue is now empty
[D1 09:14:31 elevator_1] Closing doors
[D1 09:14:34 elevator_1] Closed doors
[D1 09:14:34 elevator_1] Resting at floor 2
[D1 09:14:35 elevator_2] Closing doors
[D1 09:14:38 elevator_2] Closed doors
[D1 09:14:38 elevator_2] Changing direction to Up
[D1 09:14:48 elevator_2] At floor 1
[D1 09:14:48 elevator_2] Stopped at floor 1
[D1 09:14:48 elevator_2] Opening doors
[D1 09:14:51 elevator_2] Opened doors
[D1 09:14:51 citizen_33] Left elevator_2, arrived at floor 1
[D1 09:14:51 citizen_22] Entered elevator_2, going to floor 3
[D1 09:14:51 floor_1] citizen_22 is leaving the queue
[D1 09:14:51 floor_1] The queue is now empty
[D1 09:15:03 elevator_2] Closing doors
[D1 09:15:06 elevator_2] Closed doors
[D1 09:15:16 elevator_2] At floor 2
[D1 09:15:26 elevator_2] At floor 3
[D1 09:15:26 elevator_2] Stopped at floor 3
[D1 09:15:26 elevator_2] Opening doors
[D1 09:15:29 elevator_2] Opened doors
[D1 09:15:29 citizen_22] Left elevator_2, arrived at floor 3
[D1 09:15:41 elevator_2] Closing doors
[D1 09:15:42 citizen_17] Time to go to floor 3 and stay there for 00:20:56
[D1 09:15:42 floor_4] citizen_17 entered the queue
[D1 09:15:42 floor_4] citizen_17 found an empty queue and will be served immediately
[D1 09:15:42 elevator_2] Summoned to floor 4 from floor 3
[D1 09:15:44 elevator_2] Closed doors
[D1 09:15:54 elevator_2] At floor 4
[D1 09:15:54 elevator_2] Stopped at floor 4
[D1 09:15:54 elevator_2] Opening doors
[D1 09:15:57 elevator_2] Opened doors
[D1 09:15:57 citizen_17] Entered elevator_2, going to floor 3
[D1 09:15:57 floor_4] citizen_17 is leaving the queue
[D1 09:15:57 floor_4] The queue is now empty
[D1 09:16:03 citizen_1] Time to go to floor 4 and stay there for 00:40:31
[D1 09:16:03 floor_3] citizen_1 entered the queue
[D1 09:16:03 floor_3] citizen_1 found an empty queue and will be served immediately
[D1 09:16:03 elevator_1] Summoned to floor 3 from floor 2
[D1 09:16:03 elevator_1] Sprung into motion, heading Up
[D1 09:16:03 elevator_2] Summoned to floor 3 from floor 4
[D1 09:16:09 elevator_2] Closing doors
[D1 09:16:12 elevator_2] Closed doors
[D1 09:16:12 elevator_2] Changing direction to Down
[D1 09:16:13 elevator_1] At floor 3
[D1 09:16:13 elevator_1] Stopped at floor 3
[D1 09:16:13 elevator_1] Opening doors
[D1 09:16:16 elevator_1] Opened doors
[D1 09:16:16 citizen_1] Entered elevator_1, going to floor 4
[D1 09:16:16 floor_3] citizen_1 is leaving the queue
[D1 09:16:16 floor_3] The queue is now empty
[D1 09:16:22 elevator_2] At floor 3
[D1 09:16:22 elevator_2] Stopped at floor 3
[D1 09:16:22 elevator_2] Opening doors
[D1 09:16:25 elevator_2] Opened doors
[D1 09:16:25 citizen_17] Left elevator_2, arrived at floor 3
[D1 09:16:28 elevator_1] Closing doors
[D1 09:16:31 elevator_1] Closed doors
[D1 09:16:37 elevator_2] Closing doors
[D1 09:16:40 elevator_2] Closed doors
[D1 09:16:40 elevator_2] Resting at floor 3
[D1 09:16:41 elevator_1] At floor 4
[D1 09:16:41 elevator_1] Stopped at floor 4
[D1 09:16:41 elevator_1] Opening doors
[D1 09:16:44 elevator_1] Opened doors
[D1 09:16:44 citizen_1] Left elevator_1, arrived at floor 4
[D1 09:16:56 elevator_1] Closing doors
[D1 09:16:59 elevator_1] Closed doors
[D1 09:16:59 elevator_1] Resting at floor 4
[D1 09:17:05 citizen_34] Entered the building, will visit 5 floors in total
[D1 09:17:05 citizen_34] Time to go to floor 2 and stay there for 00:36:00
[D1 09:17:05 floor_0] citizen_34 entered the queue
[D1 09:17:05 floor_0] citizen_34 found an empty queue and will be served immediately
[D1 09:17:05 elevator_2] Summoned to floor 0 from floor 3
[D1 09:17:05 elevator_2] Sprung into motion, heading Down
[D1 09:17:15 elevator_2] At floor 2
[D1 09:17:19 citizen_7] Time to go to floor 4 and stay there for 00:24:20
[D1 09:17:19 floor_2] citizen_7 entered the queue
[D1 09:17:19 floor_2] citizen_7 found an empty queue and will be served immediately
[D1 09:17:19 elevator_2] Summoned to floor 2 from floor 2
[D1 09:17:25 elevator_2] At floor 1
[D1 09:17:35 citizen_6] Time to go to floor 1 and stay there for 00:21:56
[D1 09:17:35 floor_4] citizen_6 entered the queue
[D1 09:17:35 floor_4] citizen_6 found an empty queue and will be served immediately
[D1 09:17:35 elevator_1] Summoned to floor 4 from floor 4
[D1 09:17:35 elevator_1] Opening doors
[D1 09:17:35 elevator_2] At floor 0
[D1 09:17:35 elevator_2] Stopped at floor 0
[D1 09:17:35 elevator_2] Opening doors
[D1 09:17:38 elevator_1] Opened doors
[D1 09:17:38 elevator_2] Opened doors
[D1 09:17:38 citizen_6] Entered elevator_1, going to floor 1
[D1 09:17:38 floor_4] citizen_6 is leaving the queue
[D1 09:17:38 floor_4] The queue is now empty
[D1 09:17:38 citizen_34] Entered elevator_2, going to floor 2
[D1 09:17:38 floor_0] citizen_34 is leaving the queue
[D1 09:17:38 floor_0] The queue is now empty
[D1 09:17:50 elevator_2] Closing doors
[D1 09:17:50 elevator_1] Closing doors
[D1 09:17:53 elevator_2] Closed doors
[D1 09:17:53 elevator_1] Closed doors
[D1 09:17:53 elevator_2] Changing direction to Up
[D1 09:17:53 elevator_1] Sprung into motion, heading Down
[D1 09:17:56 citizen_8] Time to go to floor 2 and stay there for 00:25:56
[D1 09:17:56 floor_1] citizen_8 entered the queue
[D1 09:17:56 floor_1] citizen_8 found an empty queue and will be served immediately
[D1 09:17:56 elevator_2] Summoned to floor 1 from floor 0
[D1 09:18:03 elevator_2] At floor 1
[D1 09:18:03 elevator_2] Stopped at floor 1
[D1 09:18:03 elevator_2] Opening doors
[D1 09:18:03 elevator_1] At floor 3
[D1 09:18:06 elevator_2] Opened doors
[D1 09:18:06 citizen_8] Entered elevator_2, going to floor 2
[D1 09:18:06 floor_1] citizen_8 is leaving the queue
[D1 09:18:06 floor_1] The queue is now empty
[D1 09:18:13 elevator_1] At floor 2
[D1 09:18:18 elevator_2] Closing doors
[D1 09:18:21 elevator_2] Closed doors
[D1 09:18:23 elevator_1] At floor 1
[D1 09:18:23 elevator_1] Stopped at floor 1
[D1 09:18:23 elevator_1] Opening doors
[D1 09:18:26 elevator_1] Opened doors
[D1 09:18:26 citizen_6] Left elevator_1, arrived at floor 1
[D1 09:18:31 elevator_2] At floor 2
[D1 09:18:31 elevator_2] Stopped at floor 2
[D1 09:18:31 elevator_2] Opening doors
[D1 09:18:32 citizen_23] Time to go to floor 1 and stay there for 00:28:59
[D1 09:18:32 floor_3] citizen_23 entered the queue
[D1 09:18:32 floor_3] citizen_23 found an empty queue and will be served immediately
[D1 09:18:32 elevator_2] Summoned to floor 3 from floor 2
[D1 09:18:34 elevator_2] Opened doors
[D1 09:18:34 citizen_34] Left elevator_2, arrived at floor 2
[D1 09:18:34 citizen_8] Left elevator_2, arrived at floor 2
[D1 09:18:34 citizen_7] Entered elevator_2, going to floor 4
[D1 09:18:34 floor_2] citizen_7 is leaving the queue
[D1 09:18:34 floor_2] The queue is now empty
[D1 09:18:35 citizen_35] Entered the building, will visit 3 floors in total
[D1 09:18:35 citizen_35] Time to go to floor 1 and stay there for 00:26:48
[D1 09:18:35 floor_0] citizen_35 entered the queue
[D1 09:18:35 floor_0] citizen_35 found an empty queue and will be served immediately
[D1 09:18:35 elevator_1] Summoned to floor 0 from floor 1
[D1 09:18:38 elevator_1] Closing doors
[D1 09:18:41 elevator_1] Closed doors
[D1 09:18:46 elevator_2] Closing doors
[D1 09:18:49 elevator_2] Closed doors
[D1 09:18:51 elevator_1] At floor 0
[D1 09:18:51 elevator_1] Stopped at floor 0
[D1 09:18:51 elevator_1] Opening doors
[D1 09:18:54 elevator_1] Opened doors
[D1 09:18:54 citizen_35] Entered elevator_1, going to floor 1
[D1 09:18:54 floor_0] citizen_35 is leaving the queue
[D1 09:18:54 floor_0] The queue is now empty
[D1 09:18:59 elevator_2] At floor 3
[D1 09:18:59 elevator_2] Stopped at floor 3
[D1 09:18:59 elevator_2] Opening doors
[D1 09:19:02 elevator_2] Opened doors
[D1 09:19:02 citizen_23] Entered elevator_2, going to floor 1
[D1 09:19:02 floor_3] citizen_23 is leaving the queue
[D1 09:19:02 floor_3] The queue is now empty
[D1 09:19:06 elevator_1] Closing doors
[D1 09:19:09 elevator_1] Closed doors
[D1 09:19:09 elevator_1] Changing direction to Up
[D1 09:19:12 citizen_19] Time to go to floor 3 and stay there for 00:37:08
[D1 09:19:12 floor_5] citizen_19 entered the queue
[D1 09:19:12 floor_5] citizen_19 found an empty queue and will be served immediately
[D1 09:19:12 elevator_2] Summoned to floor 5 from floor 3
[D1 09:19:14 elevator_2] Closing doors
[D1 09:19:17 elevator_2] Closed doors
[D1 09:19:19 elevator_1] At floor 1
[D1 09:19:19 elevator_1] Stopped at floor 1
[D1 09:19:19 elevator_1] Opening doors
[D1 09:19:22 elevator_1] Opened doors
[D1 09:19:22 citizen_35] Left elevator_1, arrived at floor 1
[D1 09:19:27 elevator_2] At floor 4
[D1 09:19:27 elevator_2] Stopped at floor 4
[D1 09:19:27 elevator_2] Opening doors
[D1 09:19:30 elevator_2] Opened doors
[D1 09:19:30 citizen_7] Left elevator_2, arrived at floor 4
[D1 09:19:34 elevator_1] Closing doors
[D1 09:19:37 elevator_1] Closed doors
[D1 09:19:37 elevator_1] Resting at floor 1
[D1 09:19:42 elevator_2] Closing doors
[D1 09:19:45 elevator_2] Closed doors
[D1 09:19:55 elevator_2] At floor 5
[D1 09:19:55 elevator_2] Stopped at floor 5
[D1 09:19:55 elevator_2] Opening doors
[D1 09:19:58 elevator_2] Opened doors
[D1 09:19:58 citizen_19] Entered elevator_2, going to floor 3
[D1 09:19:58 floor_5] citizen_19 is leaving the queue
[D1 09:19:58 floor_5] The queue is now empty
[D1 09:20:10 elevator_2] Closing doors
[D1 09:20:13 elevator_2] Closed doors
[D1 09:20:13 elevator_2] Changing direction to Down
[D1 09:20:18 citizen_36] Entered the building, will visit 5 floors in total
[D1 09:20:18 citizen_36] Time to go to floor 5 and stay there for 00:36:19
[D1 09:20:18 floor_0] citizen_36 entered the queue
[D1 09:20:18 floor_0] citizen_36 found an empty queue and will be served immediately
[D1 09:20:18 elevator_1] Summoned to floor 0 from floor 1
[D1 09:20:18 elevator_1] Sprung into motion, heading Down
[D1 09:20:23 elevator_2] At floor 4
[D1 09:20:28 elevator_1] At floor 0
[D1 09:20:28 elevator_1] Stopped at floor 0
[D1 09:20:28 elevator_1] Opening doors
[D1 09:20:31 elevator_1] Opened doors
[D1 09:20:31 citizen_36] Entered elevator_1, going to floor 5
[D1 09:20:31 floor_0] citizen_36 is leaving the queue
[D1 09:20:31 floor_0] The queue is now empty
[D1 09:20:33 elevator_2] At floor 3
[D1 09:20:33 elevator_2] Stopped at floor 3
[D1 09:20:33 elevator_2] Opening doors
[D1 09:20:36 elevator_2] Opened doors
[D1 09:20:36 citizen_19] Left elevator_2, arrived at floor 3
[D1 09:20:43 elevator_1] Closing doors
[D1 09:20:46 elevator_1] Closed doors
[D1 09:20:46 elevator_1] Changing direction to Up
[D1 09:20:48 elevator_2] Closing doors
[D1 09:20:51 elevator_2] Closed doors
[D1 09:20:56 elevator_1] At floor 1
[D1 09:21:01 elevator_2] At floor 2
[D1 09:21:06 elevator_1] At floor 2
[D1 09:21:11 elevator_2] At floor 1
[D1 09:21:11 elevator_2] Stopped at floor 1
[D1 09:21:11 elevator_2] Opening doors
[D1 09:21:14 elevator_2] Opened doors
[D1 09:21:14 citizen_23] Left elevator_2, arrived at floor 1
[D1 09:21:16 elevator_1] At floor 3
[D1 09:21:26 elevator_2] Closing doors
[D1 09:21:26 elevator_1] At floor 4
[D1 09:21:29 elevator_2] Closed doors
[D1 09:21:29 elevator_2] Resting at floor 1
[D1 09:21:36 elevator_1] At floor 5
[D1 09:21:36 elevator_1] Stopped at floor 5
[D1 09:21:36 elevator_1] Opening doors
[D1 09:21:39 elevator_1] Opened doors
[D1 09:21:39 citizen_36] Left elevator_1, arrived at floor 5
[D1 09:21:50 citizen_20] Time to go to floor 1 and stay there for 00:20:05
[D1 09:21:50 floor_4] citizen_20 entered the queue
[D1 09:21:50 floor_4] citizen_20 found an empty queue and will be served immediately
[D1 09:21:50 elevator_1] Summoned to floor 4 from floor 5
[D1 09:21:51 elevator_1] Closing doors
[D1 09:21:54 elevator_1] Closed doors
[D1 09:21:54 elevator_1] Changing direction to Down
[D1 09:21:56 citizen_37] Entered the building, will visit 3 floors in total
[D1 09:21:56 citizen_37] Time to go to floor 4 and stay there for 00:23:46
[D1 09:21:56 floor_0] citizen_37 entered the queue
[D1 09:21:56 floor_0] citizen_37 found an empty queue and will be served immediately
[D1 09:21:56 elevator_2] Summoned to floor 0 from floor 1
[D1 09:21:56 elevator_2] Sprung into motion, heading Down
[D1 09:21:58 citizen_25] Time to go to floor 1 and stay there for 00:39:53
[D1 09:21:58 floor_5] citizen_25 entered the queue
[D1 09:21:58 floor_5] citizen_25 found an empty queue and will be served immediately
[D1 09:21:58 elevator_1] Summoned to floor 5 from floor 5
[D1 09:22:04 elevator_1] At floor 4
[D1 09:22:04 elevator_1] Stopped at floor 4
[D1 09:22:04 elevator_1] Opening doors
[D1 09:22:06 elevator_2] At floor 0
[D1 09:22:06 elevator_2] Stopped at floor 0
[D1 09:22:06 elevator_2] Opening doors
[D1 09:22:07 elevator_1] Opened doors
[D1 09:22:07 citizen_20] Entered elevator_1, going to floor 1
[D1 09:22:07 floor_4] citizen_20 is leaving the queue
[D1 09:22:07 floor_4] The queue is now empty
[D1 09:22:09 elevator_2] Opened doors
[D1 09:22:09 citizen_37] Entered elevator_2, going to floor 4
[D1 09:22:09 floor_0] citizen_37 is leaving the queue
[D1 09:22:09 floor_0] The queue is now empty
[D1 09:22:19 elevator_1] Closing doors
[D1 09:22:21 elevator_2] Closing doors
[D1 09:22:22 elevator_1] Closed doors
[D1 09:22:24 elevator_2] Closed doors
[D1 09:22:24 elevator_2] Changing direction to Up
[D1 09:22:32 elevator_1] At floor 3
[D1 09:22:34 elevator_2] At floor 1
[D1 09:22:39 citizen_26] Time to go to floor 1 and stay there for 00:38:43
[D1 09:22:39 floor_3] citizen_26 entered the queue
[D1 09:22:39 floor_3] citizen_26 found an empty queue and will be served immediately
[D1 09:22:39 elevator_1] Summoned to floor 3 from floor 3
[D1 09:22:42 elevator_1] At floor 2
[D1 09:22:44 elevator_2] At floor 2
[D1 09:22:52 elevator_1] At floor 1
[D1 09:22:52 elevator_1] Stopped at floor 1
[D1 09:22:52 elevator_1] Opening doors
[D1 09:22:54 elevator_2] At floor 3
[D1 09:22:55 elevator_1] Opened doors
[D1 09:22:55 citizen_20] Left elevator_1, arrived at floor 1
[D1 09:23:04 elevator_2] At floor 4
[D1 09:23:04 elevator_2] Stopped at floor 4
[D1 09:23:04 elevator_2] Opening doors
[D1 09:23:07 elevator_1] Closing doors
[D1 09:23:07 elevator_2] Opened doors
[D1 09:23:07 citizen_37] Left elevator_2, arrived at floor 4
[D1 09:23:10 elevator_1] Closed doors
[D1 09:23:10 elevator_1] Changing direction to Up
[D1 09:23:19 elevator_2] Closing doors
[D1 09:23:20 elevator_1] At floor 2
[D1 09:23:22 elevator_2] Closed doors
[D1 09:23:22 elevator_2] Resting at floor 4
[D1 09:23:30 elevator_1] At floor 3
[D1 09:23:30 elevator_1] Stopped at floor 3
[D1 09:23:30 elevator_1] Opening doors
[D1 09:23:33 elevator_1] Opened doors
[D1 09:23:33 citizen_26] Entered elevator_1, going to floor 1
[D1 09:23:33 floor_3] citizen_26 is leaving the queue
[D1 09:23:33 floor_3] The queue is now empty
[D1 09:23:36 citizen_38] Entered the building, will visit 5 floors in total
[D1 09:23:36 citizen_38] Time to go to floor 5 and stay there for 00:32:23
[D1 09:23:36 floor_0] citizen_38 entered the queue
[D1 09:23:36 floor_0] citizen_38 found an empty queue and will be served immediately
[D1 09:23:36 elevator_1] Summoned to floor 0 from floor 3
[D1 09:23:45 elevator_1] Closing doors
[D1 09:23:48 elevator_1] Closed doors
[D1 09:23:58 elevator_1] At floor 4
[D1 09:24:08 elevator_1] At floor 5
[D1 09:24:08 elevator_1] Stopped at floor 5
[D1 09:24:08 elevator_1] Opening doors
[D1 09:24:11 elevator_1] Opened doors
[D1 09:24:11 citizen_25] Entered elevator_1, going to floor 1
[D1 09:24:11 floor_5] citizen_25 is leaving the queue
[D1 09:24:11 floor_5] The queue is now empty
[D1 09:24:23 elevator_1] Closing doors
[D1 09:24:26 elevator_1] Closed doors
[D1 09:24:26 elevator_1] Changing direction to Down
[D1 09:24:36 elevator_1] At floor 4
[D1 09:24:46 elevator_1] At floor 3
[D1 09:24:56 elevator_1] At floor 2
[D1 09:25:06 elevator_1] At floor 1
[D1 09:25:06 elevator_1] Stopped at floor 1
[D1 09:25:06 elevator_1] Opening doors
[D1 09:25:09 elevator_1] Opened doors
[D1 09:25:09 citizen_26] Left elevator_1, arrived at floor 1
[D1 09:25:09 citizen_25] Left elevator_1, arrived at floor 1
[D1 09:25:21 elevator_1] Closing doors
[D1 09:25:24 elevator_1] Closed doors
[D1 09:25:34 elevator_1] At floor 0
[D1 09:25:34 elevator_1] Stopped at floor 0
[D1 09:25:34 elevator_1] Opening doors
[D1 09:25:37 elevator_1] Opened doors
[D1 09:25:37 citizen_38] Entered elevator_1, going to floor 5
[D1 09:25:37 floor_0] citizen_38 is leaving the queue
[D1 09:25:37 floor_0] The queue is now empty
[D1 09:25:49 elevator_1] Closing doors
[D1 09:25:52 elevator_1] Closed doors
[D1 09:25:52 elevator_1] Changing direction to Up
[D1 09:26:02 elevator_1] At floor 1
[D1 09:26:12 elevator_1] At floor 2
[D1 09:26:22 citizen_9] Time to go to floor 1 and stay there for 00:30:12
[D1 09:26:22 floor_2] citizen_9 entered the queue
[D1 09:26:22 floor_2] citizen_9 found an empty queue and will be served immediately
[D1 09:26:22 elevator_1] Summoned to floor 2 from floor 2
[D1 09:26:22 elevator_1] At floor 3
[D1 09:26:32 elevator_1] At floor 4
[D1 09:26:42 elevator_1] At floor 5
[D1 09:26:42 elevator_1] Stopped at floor 5
[D1 09:26:42 elevator_1] Opening doors
[D1 09:26:45 elevator_1] Opened doors
[D1 09:26:45 citizen_38] Left elevator_1, arrived at floor 5
[D1 09:26:57 elevator_1] Closing doors
[D1 09:27:00 citizen_14] Time to go to floor 5 and stay there for 00:22:02
[D1 09:27:00 floor_1] citizen_14 entered the queue
[D1 09:27:00 floor_1] citizen_14 found an empty queue and will be served immediately
[D1 09:27:00 elevator_2] Summoned to floor 1 from floor 4
[D1 09:27:00 elevator_2] Sprung into motion, heading Down
[D1 09:27:00 elevator_1] Closed doors
[D1 09:27:00 elevator_1] Changing direction to Down
[D1 09:27:05 citizen_39] Entered the building, will visit 4 floors in total
[D1 09:27:05 citizen_39] Time to go to floor 2 and stay there for 00:35:41
[D1 09:27:05 floor_0] citizen_39 entered the queue
[D1 09:27:05 floor_0] citizen_39 found an empty queue and will be served immediately
[D1 09:27:05 elevator_2] Summoned to floor 0 from floor 4
[D1 09:27:10 elevator_2] At floor 3
[D1 09:27:10 elevator_1] At floor 4
[D1 09:27:20 elevator_2] At floor 2
[D1 09:27:20 elevator_1] At floor 3
[D1 09:27:22 citizen_30] Time to go to floor 2 and stay there for 00:41:44
[D1 09:27:22 floor_5] citizen_30 entered the queue
[D1 09:27:22 floor_5] citizen_30 found an empty queue and will be served immediately
[D1 09:27:22 elevator_1] Summoned to floor 5 from floor 3
[D1 09:27:30 elevator_2] At floor 1
[D1 09:27:30 elevator_2] Stopped at floor 1
[D1 09:27:30 elevator_2] Opening doors
[D1 09:27:30 elevator_1] At floor 2
[D1 09:27:30 elevator_1] Stopped at floor 2
[D1 09:27:30 elevator_1] Opening doors
[D1 09:27:33 elevator_2] Opened doors
[D1 09:27:33 elevator_1] Opened doors
[D1 09:27:33 citizen_14] Entered elevator_2, going to floor 5
[D1 09:27:33 citizen_9] Entered elevator_1, going to floor 1
[D1 09:27:33 floor_1] citizen_14 is leaving the queue
[D1 09:27:33 floor_1] The queue is now empty
[D1 09:27:33 floor_2] citizen_9 is leaving the queue
[D1 09:27:33 floor_2] The queue is now empty
[D1 09:27:40 citizen_13] Time to go to floor 3 and stay there for 00:31:21
[D1 09:27:40 floor_4] citizen_13 entered the queue
[D1 09:27:40 floor_4] citizen_13 found an empty queue and will be served immediately
[D1 09:27:40 elevator_1] Summoned to floor 4 from floor 2
[D1 09:27:42 citizen_27] Time to go to floor 5 and stay there for 00:42:58
[D1 09:27:42 floor_2] citizen_27 entered the queue
[D1 09:27:42 floor_2] citizen_27 found an empty queue and will be served immediately
[D1 09:27:42 elevator_1] Summoned to floor 2 from floor 2
[D1 09:27:42 citizen_27] Entered elevator_1, going to floor 5
[D1 09:27:42 floor_2] citizen_27 is leaving the queue
[D1 09:27:42 floor_2] The queue is now empty
[D1 09:27:44 citizen_15] Time to go to floor 1 and stay there for 00:16:50
[D1 09:27:44 floor_3] citizen_15 entered the queue
[D1 09:27:44 floor_3] citizen_15 found an empty queue and will be served immediately
[D1 09:27:44 elevator_1] Summoned to floor 3 from floor 2
[D1 09:27:45 elevator_1] Closing doors
[D1 09:27:45 elevator_2] Closing doors
[D1 09:27:48 elevator_1] Closed doors
[D1 09:27:48 elevator_2] Closed doors
[D1 09:27:56 citizen_4] Time to go to floor 3 and stay there for 00:34:13
[D1 09:27:56 floor_5] citizen_4 entered the queue
[D1 09:27:56 floor_5] citizen_4 is queued along with 0 other arrivals in front of it
[D1 09:27:58 elevator_1] At floor 1
[D1 09:27:58 elevator_1] Stopped at floor 1
[D1 09:27:58 elevator_1] Opening doors
[D1 09:27:58 elevator_2] At floor 0
[D1 09:27:58 elevator_2] Stopped at floor 0
[D1 09:27:58 elevator_2] Opening doors
[D1 09:28:01 elevator_1] Opened doors
[D1 09:28:01 elevator_2] Opened doors
[D1 09:28:01 citizen_9] Left elevator_1, arrived at floor 1
[D1 09:28:01 citizen_39] Entered elevator_2, going to floor 2
[D1 09:28:01 floor_0] citizen_39 is leaving the queue
[D1 09:28:01 floor_0] The queue is now empty
[D1 09:28:13 elevator_2] Closing doors
[D1 09:28:13 elevator_1] Closing doors
[D1 09:28:16 elevator_2] Closed doors
[D1 09:28:16 elevator_1] Closed doors
[D1 09:28:16 elevator_2] Changing direction to Up
[D1 09:28:16 elevator_1] Changing direction to Up
[D1 09:28:26 elevator_2] At floor 1
[D1 09:28:26 elevator_1] At floor 2
[D1 09:28:36 elevator_2] At floor 2
[D1 09:28:36 elevator_2] Stopped at floor 2
[D1 09:28:36 elevator_2] Opening doors
[D1 09:28:36 elevator_1] At floor 3
[D1 09:28:36 elevator_1] Stopped at floor 3
[D1 09:28:36 elevator_1] Opening doors
[D1 09:28:38 citizen_40] Entered the building, will visit 3 floors in total
[D1 09:28:38 citizen_40] Time to go to floor 3 and stay there for 00:27:32
[D1 09:28:38 floor_0] citizen_40 entered the queue
[D1 09:28:38 floor_0] citizen_40 found an empty queue and will be served immediately
[D1 09:28:38 elevator_2] Summoned to floor 0 from floor 2
[D1 09:28:39 elevator_2] Opened doors
[D1 09:28:39 elevator_1] Opened doors
[D1 09:28:39 citizen_39] Left elevator_2, arrived at floor 2
[D1 09:28:39 citizen_15] Entered elevator_1, going to floor 1
[D1 09:28:39 floor_3] citizen_15 is leaving the queue
[D1 09:28:39 floor_3] The queue is now empty
[D1 09:28:51 elevator_1] Closing doors
[D1 09:28:51 elevator_2] Closing doors
[D1 09:28:54 elevator_1] Closed doors
[D1 09:28:54 elevator_2] Closed doors
[D1 09:29:04 elevator_1] At floor 4
[D1 09:29:04 elevator_1] Stopped at floor 4
[D1 09:29:04 elevator_1] Opening doors
[D1 09:29:04 elevator_2] At floor 3
[D1 09:29:07 elevator_1] Opened doors
[D1 09:29:07 citizen_13] Entered elevator_1, going to floor 3
[D1 09:29:07 floor_4] citizen_13 is leaving the queue
[D1 09:29:07 floor_4] The queue is now empty
[D1 09:29:14 elevator_2] At floor 4
[D1 09:29:19 citizen_28] Time to go to floor 5 and stay there for 00:41:12
[D1 09:29:19 floor_2] citizen_28 entered the queue
[D1 09:29:19 floor_2] citizen_28 found an empty queue and will be served immediately
[D1 09:29:19 elevator_1] Summoned to floor 2 from floor 4
[D1 09:29:19 elevator_2] Summoned to floor 2 from floor 4
[D1 09:29:19 elevator_1] Closing doors
[D1 09:29:22 elevator_1] Closed doors
[D1 09:29:24 elevator_2] At floor 5
[D1 09:29:24 elevator_2] Stopped at floor 5
[D1 09:29:24 elevator_2] Opening doors
[D1 09:29:27 elevator_2] Opened doors
[D1 09:29:27 citizen_14] Left elevator_2, arrived at floor 5
[D1 09:29:32 elevator_1] At floor 5
[D1 09:29:32 elevator_1] Stopped at floor 5
[D1 09:29:32 elevator_1] Opening doors
[D1 09:29:35 elevator_1] Opened doors
[D1 09:29:35 citizen_27] Left elevator_1, arrived at floor 5
[D1 09:29:35 citizen_30] Entered elevator_1, going to floor 2
[D1 09:29:35 floor_5] citizen_30 is leaving the queue
[D1 09:29:35 floor_5] citizen_4 was served
[D1 09:29:35 elevator_1] Summoned to floor 5 from floor 5
[D1 09:29:35 elevator_2] Summoned to floor 5 from floor 5
[D1 09:29:35 citizen_4] Entered elevator_1, going to floor 3
[D1 09:29:35 floor_5] citizen_4 is leaving the queue
[D1 09:29:35 floor_5] The queue is now empty
[D1 09:29:39 elevator_2] Closing doors
[D1 09:29:42 elevator_2] Closed doors
[D1 09:29:42 elevator_2] Changing direction to Down
[D1 09:29:47 elevator_1] Closing doors
[D1 09:29:50 elevator_1] Closed doors
[D1 09:29:50 elevator_1] Changing direction to Down
[D1 09:29:52 elevator_2] At floor 4
[D1 09:30:00 elevator_1] At floor 4
[D1 09:30:02 elevator_2] At floor 3
[D1 09:30:10 elevator_1] At floor 3
[D1 09:30:10 elevator_1] Stopped at floor 3
[D1 09:30:10 elevator_1] Opening doors
[D1 09:30:12 elevator_2] At floor 2
[D1 09:30:12 elevator_2] Stopped at floor 2
[D1 09:30:12 elevator_2] Opening doors
[D1 09:30:13 elevator_1] Opened doors
[D1 09:30:13 citizen_13] Left elevator_1, arrived at floor 3
[D1 09:30:13 citizen_4] Left elevator_1, arrived at floor 3
[D1 09:30:15 elevator_2] Opened doors
[D1 09:30:15 citizen_28] Entered elevator_2, going to floor 5
[D1 09:30:15 floor_2] citizen_28 is leaving the queue
[D1 09:30:15 floor_2] The queue is now empty
[D1 09:30:19 citizen_24] Time to go to floor 5 and stay there for 00:20:08
[D1 09:30:19 floor_3] citizen_24 entered the queue
[D1 09:30:19 floor_3] citizen_24 found an empty queue and will be served immediately
[D1 09:30:19 elevator_1] Summoned to floor 3 from floor 3
[D1 09:30:19 citizen_24] Entered elevator_1, going to floor 5
[D1 09:30:19 floor_3] citizen_24 is leaving the queue
[D1 09:30:19 floor_3] The queue is now empty
[D1 09:30:25 elevator_1] Closing doors
[D1 09:30:27 elevator_2] Closing doors
[D1 09:30:28 elevator_1] Closed doors
[D1 09:30:30 elevator_2] Closed doors
[D1 09:30:38 elevator_1] At floor 2
[D1 09:30:38 elevator_1] Stopped at floor 2
[D1 09:30:38 elevator_1] Opening doors
[D1 09:30:40 elevator_2] At floor 1
[D1 09:30:41 elevator_1] Opened doors
[D1 09:30:41 citizen_30] Left elevator_1, arrived at floor 2
[D1 09:30:50 elevator_2] At floor 0
[D1 09:30:50 elevator_2] Stopped at floor 0
[D1 09:30:50 elevator_2] Opening doors
[D1 09:30:53 elevator_1] Closing doors
[D1 09:30:53 elevator_2] Opened doors
[D1 09:30:53 citizen_40] Entered elevator_2, going to floor 3
[D1 09:30:53 floor_0] citizen_40 is leaving the queue
[D1 09:30:53 floor_0] The queue is now empty
[D1 09:30:56 elevator_1] Closed doors
[D1 09:31:05 elevator_2] Closing doors
[D1 09:31:06 elevator_1] At floor 1
[D1 09:31:06 elevator_1] Stopped at floor 1
[D1 09:31:06 elevator_1] Opening doors
[D1 09:31:08 elevator_2] Closed doors
[D1 09:31:08 elevator_2] Changing direction to Up
[D1 09:31:09 elevator_1] Opened doors
[D1 09:31:09 citizen_15] Left elevator_1, arrived at floor 1
[D1 09:31:18 elevator_2] At floor 1
[D1 09:31:21 elevator_1] Closing doors
[D1 09:31:24 elevator_1] Closed doors
[D1 09:31:24 elevator_1] Changing direction to Up
[D1 09:31:25 citizen_32] Time to go to floor 4 and stay there for 00:30:16
[D1 09:31:25 floor_5] citizen_32 entered the queue
[D1 09:31:25 floor_5] citizen_32 found an empty queue and will be served immediately
[D1 09:31:25 elevator_1] Summoned to floor 5 from floor 1
[D1 09:31:25 elevator_2] Summoned to floor 5 from floor 1
[D1 09:31:28 elevator_2] At floor 2
[D1 09:31:34 elevator_1] At floor 2
[D1 09:31:38 elevator_2] At floor 3
[D1 09:31:38 elevator_2] Stopped at floor 3
[D1 09:31:38 elevator_2] Opening doors
[D1 09:31:41 elevator_2] Opened doors
[D1 09:31:41 citizen_40] Left elevator_2, arrived at floor 3
[D1 09:31:44 elevator_1] At floor 3
[D1 09:31:53 elevator_2] Closing doors
[D1 09:31:54 elevator_1] At floor 4
[D1 09:31:56 elevator_2] Closed doors
[D1 09:32:04 elevator_1] At floor 5
[D1 09:32:04 elevator_1] Stopped at floor 5
[D1 09:32:04 elevator_1] Opening doors
[D1 09:32:06 elevator_2] At floor 4
[D1 09:32:07 elevator_1] Opened doors
[D1 09:32:07 citizen_24] Left elevator_1, arrived at floor 5
[D1 09:32:07 citizen_32] Entered elevator_1, going to floor 4
[D1 09:32:07 floor_5] citizen_32 is leaving the queue
[D1 09:32:07 floor_5] The queue is now empty
[D1 09:32:16 elevator_2] At floor 5
[D1 09:32:16 elevator_2] Stopped at floor 5
[D1 09:32:16 elevator_2] Opening doors
[D1 09:32:19 elevator_1] Closing doors
[D1 09:32:19 elevator_2] Opened doors
[D1 09:32:19 citizen_28] Left elevator_2, arrived at floor 5
[D1 09:32:22 elevator_1] Closed doors
[D1 09:32:22 elevator_1] Changing direction to Down
[D1 09:32:31 elevator_2] Closing doors
[D1 09:32:32 elevator_1] At floor 4
[D1 09:32:32 elevator_1] Stopped at floor 4
[D1 09:32:32 elevator_1] Opening doors
[D1 09:32:34 elevator_2] Closed doors
[D1 09:32:34 elevator_2] Resting at floor 5
[D1 09:32:35 elevator_1] Opened doors
[D1 09:32:35 citizen_32] Left elevator_1, arrived at floor 4
[D1 09:32:47 elevator_1] Closing doors
[D1 09:32:50 elevator_1] Closed doors
[D1 09:32:50 elevator_1] Resting at floor 4
[D1 09:34:17 citizen_11] Time to go to floor 3 and stay there for 00:33:13
[D1 09:34:17 floor_1] citizen_11 entered the queue
[D1 09:34:17 floor_1] citizen_11 found an empty queue and will be served immediately
[D1 09:34:17 elevator_1] Summoned to floor 1 from floor 4
[D1 09:34:17 elevator_1] Sprung into motion, heading Down
[D1 09:34:27 elevator_1] At floor 3
[D1 09:34:37 elevator_1] At floor 2
[D1 09:34:45 citizen_41] Entered the building, will visit 4 floors in total
[D1 09:34:45 citizen_41] Time to go to floor 5 and stay there for 00:37:45
[D1 09:34:45 floor_0] citizen_41 entered the queue
[D1 09:34:45 floor_0] citizen_41 found an empty queue and will be served immediately
[D1 09:34:45 elevator_1] Summoned to floor 0 from floor 2
[D1 09:34:46 citizen_22] Time to go to floor 2 and stay there for 00:33:02
[D1 09:34:46 floor_3] citizen_22 entered the queue
[D1 09:34:46 floor_3] citizen_22 found an empty queue and will be served immediately
[D1 09:34:46 elevator_1] Summoned to floor 3 from floor 2
[D1 09:34:47 elevator_1] At floor 1
[D1 09:34:47 elevator_1] Stopped at floor 1
[D1 09:34:47 elevator_1] Opening doors
[D1 09:34:50 elevator_1] Opened doors
[D1 09:34:50 citizen_11] Entered elevator_1, going to floor 3
[D1 09:34:50 floor_1] citizen_11 is leaving the queue
[D1 09:34:50 floor_1] The queue is now empty
[D1 09:35:02 elevator_1] Closing doors
[D1 09:35:05 elevator_1] Closed doors
[D1 09:35:15 elevator_1] At floor 0
[D1 09:35:15 elevator_1] Stopped at floor 0
[D1 09:35:15 elevator_1] Opening doors
[D1 09:35:18 elevator_1] Opened doors
[D1 09:35:18 citizen_41] Entered elevator_1, going to floor 5
[D1 09:35:18 floor_0] citizen_41 is leaving the queue
[D1 09:35:18 floor_0] The queue is now empty
[D1 09:35:30 elevator_1] Closing doors
[D1 09:35:33 elevator_1] Closed doors
[D1 09:35:33 elevator_1] Changing direction to Up
[D1 09:35:43 elevator_1] At floor 1
[D1 09:35:53 elevator_1] At floor 2
[D1 09:36:03 elevator_1] At floor 3
[D1 09:36:03 elevator_1] Stopped at floor 3
[D1 09:36:03 elevator_1] Opening doors
[D1 09:36:06 elevator_1] Opened doors
[D1 09:36:06 citizen_11] Left elevator_1, arrived at floor 3
[D1 09:36:06 citizen_22] Entered elevator_1, going to floor 2
[D1 09:36:06 floor_3] citizen_22 is leaving the queue
[D1 09:36:06 floor_3] The queue is now empty
[D1 09:36:07 citizen_29] Time to go to floor 1 and stay there for 00:15:46
[D1 09:36:07 floor_2] citizen_29 entered the queue
[D1 09:36:07 floor_2] citizen_29 found an empty queue and will be served immediately
[D1 09:36:07 elevator_1] Summoned to floor 2 from floor 3
[D1 09:36:18 elevator_1] Closing doors
[D1 09:36:21 elevator_1] Closed doors
[D1 09:36:30 citizen_42] Entered the building, will visit 3 floors in total
[D1 09:36:30 citizen_42] Time to go to floor 2 and stay there for 00:34:49
[D1 09:36:30 floor_0] citizen_42 entered the queue
[D1 09:36:30 floor_0] citizen_42 found an empty queue and will be served immediately
[D1 09:36:30 elevator_1] Summoned to floor 0 from floor 3
[D1 09:36:31 elevator_1] At floor 4
[D1 09:36:41 elevator_1] At floor 5
[D1 09:36:41 elevator_1] Stopped at floor 5
[D1 09:36:41 elevator_1] Opening doors
[D1 09:36:44 elevator_1] Opened doors
[D1 09:36:44 citizen_41] Left elevator_1, arrived at floor 5
[D1 09:36:56 elevator_1] Closing doors
[D1 09:36:59 elevator_1] Closed doors
[D1 09:36:59 elevator_1] Changing direction to Down
[D1 09:37:09 elevator_1] At floor 4
[D1 09:37:19 elevator_1] At floor 3
[D1 09:37:21 citizen_17] Time to go to floor 4 and stay there for 00:28:59
[D1 09:37:21 floor_3] citizen_17 entered the queue
[D1 09:37:21 floor_3] citizen_17 found an empty queue and will be served immediately
[D1 09:37:21 elevator_1] Summoned to floor 3 from floor 3
[D1 09:37:29 elevator_1] At floor 2
[D1 09:37:29 elevator_1] Stopped at floor 2
[D1 09:37:29 elevator_1] Opening doors
[D1 09:37:32 elevator_1] Opened doors
[D1 09:37:32 citizen_22] Left elevator_1, arrived at floor 2
[D1 09:37:32 citizen_29] Entered elevator_1, going to floor 1
[D1 09:37:32 floor_2] citizen_29 is leaving the queue
[D1 09:37:32 floor_2] The queue is now empty
[D1 09:37:44 elevator_1] Closing doors
[D1 09:37:47 elevator_1] Closed doors
[D1 09:37:54 citizen_16] Time to go to the ground floor and leave
[D1 09:37:54 floor_1] citizen_16 entered the queue
[D1 09:37:54 floor_1] citizen_16 found an empty queue and will be served immediately
[D1 09:37:54 elevator_1] Summoned to floor 1 from floor 2
[D1 09:37:57 elevator_1] At floor 1
[D1 09:37:57 elevator_1] Stopped at floor 1
[D1 09:37:57 elevator_1] Opening doors
[D1 09:38:00 elevator_1] Opened doors
[D1 09:38:00 citizen_29] Left elevator_1, arrived at floor 1
[D1 09:38:00 citizen_16] Entered elevator_1, going to floor 0
[D1 09:38:00 floor_1] citizen_16 is leaving the queue
[D1 09:38:00 floor_1] The queue is now empty
[D1 09:38:12 elevator_1] Closing doors
[D1 09:38:15 elevator_1] Closed doors
[D1 09:38:25 elevator_1] At floor 0
[D1 09:38:25 elevator_1] Stopped at floor 0
[D1 09:38:25 elevator_1] Opening doors
[D1 09:38:28 elevator_1] Opened doors
[D1 09:38:28 citizen_16] Left elevator_1, arrived at floor 0
[D1 09:38:28 citizen_16] Left the building
[D1 09:38:28 citizen_42] Entered elevator_1, going to floor 2
[D1 09:38:28 floor_0] citizen_42 is leaving the queue
[D1 09:38:28 floor_0] The queue is now empty
[D1 09:38:40 elevator_1] Closing doors
[D1 09:38:43 citizen_43] Entered the building, will visit 5 floors in total
[D1 09:38:43 citizen_43] Time to go to floor 2 and stay there for 00:26:52
[D1 09:38:43 floor_0] citizen_43 entered the queue
[D1 09:38:43 floor_0] citizen_43 found an empty queue and will be served immediately
[D1 09:38:43 elevator_1] Summoned to floor 0 from floor 0
[D1 09:38:43 elevator_1] Reopening doors
[D1 09:38:43 citizen_43] Entered elevator_1, going to floor 2
[D1 09:38:43 floor_0] citizen_43 is leaving the queue
[D1 09:38:43 floor_0] The queue is now empty
[D1 09:38:55 elevator_1] Closing doors
[D1 09:38:58 elevator_1] Closed doors
[D1 09:38:58 elevator_1] Changing direction to Up
[D1 09:39:08 elevator_1] At floor 1
[D1 09:39:12 citizen_12] Time to go to floor 3 and stay there for 00:41:14
[D1 09:39:12 floor_2] citizen_12 entered the queue
[D1 09:39:12 floor_2] citizen_12 found an empty queue and will be served immediately
[D1 09:39:12 elevator_1] Summoned to floor 2 from floor 1
[D1 09:39:18 elevator_1] At floor 2
[D1 09:39:18 elevator_1] Stopped at floor 2
[D1 09:39:18 elevator_1] Opening doors
[D1 09:39:21 elevator_1] Opened doors
[D1 09:39:21 citizen_42] Left elevator_1, arrived at floor 2
[D1 09:39:21 citizen_43] Left elevator_1, arrived at floor 2
[D1 09:39:21 citizen_12] Entered elevator_1, going to floor 3
[D1 09:39:21 floor_2] citizen_12 is leaving the queue
[D1 09:39:21 floor_2] The queue is now empty
[D1 09:39:33 elevator_1] Closing doors
[D1 09:39:36 elevator_1] Closed doors
[D1 09:39:46 elevator_1] At floor 3
[D1 09:39:46 elevator_1] Stopped at floor 3
[D1 09:39:46 elevator_1] Opening doors
[D1 09:39:49 elevator_1] Opened doors
[D1 09:39:49 citizen_12] Left elevator_1, arrived at floor 3
[D1 09:39:49 citizen_17] Entered elevator_1, going to floor 4
[D1 09:39:49 floor_3] citizen_17 is leaving the queue
[D1 09:39:49 floor_3] The queue is now empty
[D1 09:39:59 citizen_33] Time to go to floor 5 and stay there for 00:27:41
[D1 09:39:59 floor_1] citizen_33 entered the queue
[D1 09:39:59 floor_1] citizen_33 found an empty queue and will be served immediately
[D1 09:39:59 elevator_1] Summoned to floor 1 from floor 3
[D1 09:40:01 elevator_1] Closing doors
[D1 09:40:04 elevator_1] Closed doors
[D1 09:40:14 elevator_1] At floor 4
[D1 09:40:14 elevator_1] Stopped at floor 4
[D1 09:40:14 elevator_1] Opening doors
[D1 09:40:17 elevator_1] Opened doors
[D1 09:40:17 citizen_17] Left elevator_1, arrived at floor 4
[D1 09:40:22 citizen_6] Time to go to floor 5 and stay there for 00:34:42
[D1 09:40:22 floor_1] citizen_6 entered the queue
[D1 09:40:22 floor_1] citizen_6 is queued along with 0 other arrivals in front of it
[D1 09:40:24 citizen_31] Time to go to floor 3 and stay there for 00:14:03
[D1 09:40:24 floor_1] citizen_31 entered the queue
[D1 09:40:24 floor_1] citizen_31 is queued along with 1 other arrivals in front of it
[D1 09:40:29 elevator_1] Closing doors
[D1 09:40:32 elevator_1] Closed doors
[D1 09:40:32 elevator_1] Changing direction to Down
[D1 09:40:42 elevator_1] At floor 3
[D1 09:40:52 elevator_1] At floor 2
[D1 09:41:02 elevator_1] At floor 1
[D1 09:41:02 elevator_1] Stopped at floor 1
[D1 09:41:02 elevator_1] Opening doors
[D1 09:41:05 elevator_1] Opened doors
[D1 09:41:05 citizen_33] Entered elevator_1, going to floor 5
[D1 09:41:05 floor_1] citizen_33 is leaving the queue
[D1 09:41:05 floor_1] citizen_6 was served
[D1 09:41:05 elevator_1] Summoned to floor 1 from floor 1
[D1 09:41:05 citizen_6] Entered elevator_1, going to floor 5
[D1 09:41:05 floor_1] citizen_6 is leaving the queue
[D1 09:41:05 floor_1] citizen_31 was served
[D1 09:41:05 elevator_1] Summoned to floor 1 from floor 1
[D1 09:41:05 citizen_31] Entered elevator_1, going to floor 3
[D1 09:41:05 floor_1] citizen_31 is leaving the queue
[D1 09:41:05 floor_1] The queue is now empty
[D1 09:41:08 citizen_44] Entered the building, will visit 5 floors in total
[D1 09:41:08 citizen_44] Time to go to floor 2 and stay there for 00:49:57
[D1 09:41:08 floor_0] citizen_44 entered the queue
[D1 09:41:08 floor_0] citizen_44 found an empty queue and will be served immediately
[D1 09:41:08 elevator_1] Summoned to floor 0 from floor 1
[D1 09:41:17 elevator_1] Closing doors
[D1 09:41:20 elevator_1] Closed doors
[D1 09:41:30 elevator_1] At floor 0
[D1 09:41:30 elevator_1] Stopped at floor 0
[D1 09:41:30 elevator_1] Opening doors
[D1 09:41:33 elevator_1] Opened doors
[D1 09:41:33 citizen_44] Entered elevator_1, going to floor 2
[D1 09:41:33 floor_0] citizen_44 is leaving the queue
[D1 09:41:33 floor_0] The queue is now empty
[D1 09:41:34 citizen_3] Time to go to floor 5 and stay there for 00:26:33
[D1 09:41:34 floor_1] citizen_3 entered the queue
[D1 09:41:34 floor_1] citizen_3 found an empty queue and will be served immediately
[D1 09:41:34 elevator_1] Summoned to floor 1 from floor 0
[D1 09:41:45 elevator_1] Closing doors
[D1 09:41:48 elevator_1] Closed doors
[D1 09:41:48 elevator_1] Changing direction to Up
[D1 09:41:49 citizen_21] Time to go to floor 2 and stay there for 00:35:43
[D1 09:41:49 floor_3] citizen_21 entered the queue
[D1 09:41:49 floor_3] citizen_21 found an empty queue and will be served immediately
[D1 09:41:49 elevator_2] Summoned to floor 3 from floor 5
[D1 09:41:49 elevator_2] Sprung into motion, heading Down
[D1 09:41:58 elevator_1] At floor 1
[D1 09:41:58 elevator_1] Stopped at floor 1
[D1 09:41:58 elevator_1] Opening doors
[D1 09:41:59 elevator_2] At floor 4
[D1 09:42:01 elevator_1] Opened doors
[D1 09:42:01 citizen_3] Cannot enter elevator_1, it is full
[D1 09:42:01 citizen_3] All elevators were full, trying to summon them again
[D1 09:42:09 elevator_2] At floor 3
[D1 09:42:09 elevator_2] Stopped at floor 3
[D1 09:42:09 elevator_2] Opening doors
[D1 09:42:12 elevator_2] Opened doors
[D1 09:42:12 citizen_21] Entered elevator_2, going to floor 2
[D1 09:42:12 floor_3] citizen_21 is leaving the queue
[D1 09:42:12 floor_3] The queue is now empty
[D1 09:42:13 elevator_1] Closing doors
[D1 09:42:16 elevator_1] Closed doors
[D1 09:42:17 elevator_1] Summoned to floor 1 from floor 1
[D1 09:42:24 elevator_2] Closing doors
[D1 09:42:26 elevator_1] At floor 2
[D1 09:42:26 elevator_1] Stopped at floor 2
[D1 09:42:26 elevator_1] Opening doors
[D1 09:42:26 citizen_18] Time to go to floor 5 and stay there for 00:33:26
[D1 09:42:26 floor_2] citizen_18 entered the queue
[D1 09:42:26 floor_2] citizen_18 found an empty queue and will be served immediately
[D1 09:42:26 elevator_1] Summoned to floor 2 from floor 2
[D1 09:42:27 elevator_2] Closed doors
[D1 09:42:29 elevator_1] Opened doors
[D1 09:42:29 citizen_44] Left elevator_1, arrived at floor 2
[D1 09:42:29 citizen_18] Entered elevator_1, going to floor 5
[D1 09:42:29 floor_2] citizen_18 is leaving the queue
[D1 09:42:29 floor_2] The queue is now empty
[D1 09:42:37 elevator_2] At floor 2
[D1 09:42:37 elevator_2] Stopped at floor 2
[D1 09:42:37 elevator_2] Opening doors
[D1 09:42:40 elevator_2] Opened doors
[D1 09:42:40 citizen_21] Left elevator_2, arrived at floor 2
[D1 09:42:41 elevator_1] Closing doors
[D1 09:42:44 elevator_1] Closed doors
[D1 09:42:52 elevator_2] Closing doors
[D1 09:42:54 elevator_1] At floor 3
[D1 09:42:54 elevator_1] Stopped at floor 3
[D1 09:42:54 elevator_1] Opening doors
[D1 09:42:55 elevator_2] Closed doors
[D1 09:42:55 elevator_2] Resting at floor 2
[D1 09:42:57 elevator_1] Opened doors
[D1 09:42:57 citizen_31] Left elevator_1, arrived at floor 3
[D1 09:43:00 citizen_20] Time to go to floor 3 and stay there for 00:25:26
[D1 09:43:00 floor_1] citizen_20 entered the queue
[D1 09:43:00 floor_1] citizen_20 is queued along with 0 other arrivals in front of it
[D1 09:43:09 elevator_1] Closing doors
[D1 09:43:12 elevator_1] Closed doors
[D1 09:43:22 elevator_1] At floor 4
[D1 09:43:31 citizen_45] Entered the building, will visit 4 floors in total
[D1 09:43:31 citizen_45] Time to go to floor 4 and stay there for 00:23:45
[D1 09:43:31 floor_0] citizen_45 entered the queue
[D1 09:43:31 floor_0] citizen_45 found an empty queue and will be served immediately
[D1 09:43:31 elevator_2] Summoned to floor 0 from floor 2
[D1 09:43:31 elevator_2] Sprung into motion, heading Down
[D1 09:43:32 elevator_1] At floor 5
[D1 09:43:32 elevator_1] Stopped at floor 5
[D1 09:43:32 elevator_1] Opening doors
[D1 09:43:35 elevator_1] Opened doors
[D1 09:43:35 citizen_33] Left elevator_1, arrived at floor 5
[D1 09:43:35 citizen_6] Left elevator_1, arrived at floor 5
[D1 09:43:35 citizen_18] Left elevator_1, arrived at floor 5
[D1 09:43:41 citizen_2] Time to go to floor 2 and stay there for 00:32:48
[D1 09:43:41 floor_3] citizen_2 entered the queue
[D1 09:43:41 floor_3] citizen_2 found an empty queue and will be served immediately
[D1 09:43:41 elevator_2] Summoned to floor 3 from floor 2
[D1 09:43:41 elevator_2] At floor 1
[D1 09:43:47 elevator_1] Closing doors
[D1 09:43:50 citizen_7] Time to go to floor 5 and stay there for 00:32:24
[D1 09:43:50 floor_4] citizen_7 entered the queue
[D1 09:43:50 floor_4] citizen_7 found an empty queue and will be served immediately
[D1 09:43:50 elevator_1] Summoned to floor 4 from floor 5
[D1 09:43:50 elevator_1] Closed doors
[D1 09:43:50 elevator_1] Changing direction to Down
[D1 09:43:51 elevator_2] At floor 0
[D1 09:43:51 elevator_2] Stopped at floor 0
[D1 09:43:51 elevator_2] Opening doors
[D1 09:43:54 elevator_2] Opened doors
[D1 09:43:54 citizen_45] Entered elevator_2, going to floor 4
[D1 09:43:54 floor_0] citizen_45 is leaving the queue
[D1 09:43:54 floor_0] The queue is now empty
[D1 09:44:00 elevator_1] At floor 4
[D1 09:44:00 elevator_1] Stopped at floor 4
[D1 09:44:00 elevator_1] Opening doors
[D1 09:44:03 elevator_1] Opened doors
[D1 09:44:03 citizen_7] Entered elevator_1, going to floor 5
[D1 09:44:03 floor_4] citizen_7 is leaving the queue
[D1 09:44:03 floor_4] The queue is now empty
[D1 09:44:06 elevator_2] Closing doors
[D1 09:44:09 elevator_2] Closed doors
[D1 09:44:09 elevator_2] Changing direction to Up
[D1 09:44:15 elevator_1] Closing doors
[D1 09:44:18 elevator_1] Closed doors
[D1 09:44:19 elevator_2] At floor 1
[D1 09:44:28 elevator_1] At floor 3
[D1 09:44:29 elevator_2] At floor 2
[D1 09:44:30 citizen_8] Time to go to floor 3 and stay there for 00:27:23
[D1 09:44:30 floor_2] citizen_8 entered the queue
[D1 09:44:30 floor_2] citizen_8 found an empty queue and will be served immediately
[D1 09:44:30 elevator_2] Summoned to floor 2 from floor 2
[D1 09:44:38 elevator_1] At floor 2
[D1 09:44:39 elevator_2] At floor 3
[D1 09:44:39 elevator_2] Stopped at floor 3
[D1 09:44:39 elevator_2] Opening doors
[D1 09:44:42 elevator_2] Opened doors
[D1 09:44:42 citizen_2] Entered elevator_2, going to floor 2
[D1 09:44:42 floor_3] citizen_2 is leaving the queue
[D1 09:44:42 floor_3] The queue is now empty
[D1 09:44:43 citizen_46] Entered the building, will visit 5 floors in total
[D1 09:44:43 citizen_46] Time to go to floor 3 and stay there for 00:34:38
[D1 09:44:43 floor_0] citizen_46 entered the queue
[D1 09:44:43 floor_0] citizen_46 found an empty queue and will be served immediately
[D1 09:44:43 elevator_1] Summoned to floor 0 from floor 2
[D1 09:44:46 citizen_5] Time to go to the ground floor and leave
[D1 09:44:46 floor_1] citizen_5 entered the queue
[D1 09:44:46 floor_1] citizen_5 is queued along with 1 other arrivals in front of it
[D1 09:44:48 elevator_1] At floor 1
[D1 09:44:48 elevator_1] Stopped at floor 1
[D1 09:44:48 elevator_1] Opening doors
[D1 09:44:51 elevator_1] Opened doors
[D1 09:44:51 citizen_3] Entered elevator_1, going to floor 5
[D1 09:44:51 floor_1] citizen_3 is leaving the queue
[D1 09:44:51 floor_1] citizen_20 was served
[D1 09:44:51 elevator_1] Summoned to floor 1 from floor 1
[D1 09:44:51 citizen_20] Entered elevator_1, going to floor 3
[D1 09:44:51 floor_1] citizen_20 is leaving the queue
[D1 09:44:51 floor_1] citizen_5 was served
[D1 09:44:51 elevator_1] Summoned to floor 1 from floor 1
[D1 09:44:51 citizen_5] Entered elevator_1, going to floor 0
[D1 09:44:51 floor_1] citizen_5 is leaving the queue
[D1 09:44:51 floor_1] The queue is now empty
[D1 09:44:54 elevator_2] Closing doors
[D1 09:44:57 elevator_2] Closed doors
[D1 09:45:03 elevator_1] Closing doors
[D1 09:45:06 elevator_1] Closed doors
[D1 09:45:07 elevator_2] At floor 4
[D1 09:45:07 elevator_2] Stopped at floor 4
[D1 09:45:07 elevator_2] Opening doors
[D1 09:45:10 elevator_2] Opened doors
[D1 09:45:10 citizen_45] Left elevator_2, arrived at floor 4
[D1 09:45:16 elevator_1] At floor 0
[D1 09:45:16 elevator_1] Stopped at floor 0
[D1 09:45:16 elevator_1] Opening doors
[D1 09:45:19 elevator_1] Opened doors
[D1 09:45:19 citizen_5] Left elevator_1, arrived at floor 0
[D1 09:45:19 citizen_5] Left the building
[D1 09:45:19 citizen_46] Entered elevator_1, going to floor 3
[D1 09:45:19 floor_0] citizen_46 is leaving the queue
[D1 09:45:19 floor_0] The queue is now empty
[D1 09:45:22 elevator_2] Closing doors
[D1 09:45:25 elevator_2] Closed doors
[D1 09:45:25 elevator_2] Changing direction to Down
[D1 09:45:31 elevator_1] Closing doors
[D1 09:45:34 elevator_1] Closed doors
[D1 09:45:34 elevator_1] Changing direction to Up
[D1 09:45:35 elevator_2] At floor 3
[D1 09:45:44 elevator_1] At floor 1
[D1 09:45:45 elevator_2] At floor 2
[D1 09:45:45 elevator_2] Stopped at floor 2
[D1 09:45:45 elevator_2] Opening doors
[D1 09:45:48 elevator_2] Opened doors
[D1 09:45:48 citizen_2] Left elevator_2, arrived at floor 2
[D1 09:45:48 citizen_8] Entered elevator_2, going to floor 3
[D1 09:45:48 floor_2] citizen_8 is leaving the queue
[D1 09:45:48 floor_2] The queue is now empty
[D1 09:45:54 elevator_1] At floor 2
[D1 09:46:00 elevator_2] Closing doors
[D1 09:46:03 elevator_2] Closed doors
[D1 09:46:03 elevator_2] Changing direction to Up
[D1 09:46:04 elevator_1] At floor 3
[D1 09:46:04 elevator_1] Stopped at floor 3
[D1 09:46:04 elevator_1] Opening doors
[D1 09:46:07 elevator_1] Opened doors
[D1 09:46:07 citizen_20] Left elevator_1, arrived at floor 3
[D1 09:46:07 citizen_46] Left elevator_1, arrived at floor 3
[D1 09:46:08 citizen_47] Entered the building, will visit 3 floors in total
[D1 09:46:08 citizen_47] Time to go to floor 5 and stay there for 00:25:37
[D1 09:46:08 floor_0] citizen_47 entered the queue
[D1 09:46:08 floor_0] citizen_47 found an empty queue and will be served immediately
[D1 09:46:08 elevator_2] Summoned to floor 0 from floor 2
[D1 09:46:10 citizen_35] Time to go to floor 4 and stay there for 00:26:23
[D1 09:46:10 floor_1] citizen_35 entered the queue
[D1 09:46:10 floor_1] citizen_35 found an empty queue and will be served immediately
[D1 09:46:10 elevator_2] Summoned to floor 1 from floor 2
[D1 09:46:13 elevator_2] At floor 3
[D1 09:46:13 elevator_2] Stopped at floor 3
[D1 09:46:13 elevator_2] Opening doors
[D1 09:46:16 elevator_2] Opened doors
[D1 09:46:16 citizen_8] Left elevator_2, arrived at floor 3
[D1 09:46:19 elevator_1] Closing doors
[D1 09:46:22 elevator_1] Closed doors
[D1 09:46:28 elevator_2] Closing doors
[D1 09:46:31 elevator_2] Closed doors
[D1 09:46:31 elevator_2] Changing direction to Down
[D1 09:46:32 elevator_1] At floor 4
[D1 09:46:41 elevator_2] At floor 2
[D1 09:46:42 elevator_1] At floor 5
[D1 09:46:42 elevator_1] Stopped at floor 5
[D1 09:46:42 elevator_1] Opening doors
[D1 09:46:45 elevator_1] Opened doors
[D1 09:46:45 citizen_7] Left elevator_1, arrived at floor 5
[D1 09:46:45 citizen_3] Left elevator_1, arrived at floor 5
[D1 09:46:51 elevator_2] At floor 1
[D1 09:46:51 elevator_2] Stopped at floor 1
[D1 09:46:51 elevator_2] Opening doors
[D1 09:46:53 citizen_37] Time to go to floor 1 and stay there for 00:35:50
[D1 09:46:53 floor_4] citizen_37 entered the queue
[D1 09:46:53 floor_4] citizen_37 found an empty queue and will be served immediately
[D1 09:46:53 elevator_1] Summoned to floor 4 from floor 5
[D1 09:46:54 elevator_2] Opened doors
[D1 09:46:54 citizen_35] Entered elevator_2, going to floor 4
[D1 09:46:54 floor_1] citizen_35 is leaving the queue
[D1 09:46:54 floor_1] The queue is now empty
[D1 09:46:57 elevator_1] Closing doors
[D1 09:47:00 elevator_1] Closed doors
[D1 09:47:00 elevator_1] Changing direction to Down
[D1 09:47:06 elevator_2] Closing doors
[D1 09:47:09 elevator_2] Closed doors
[D1 09:47:10 elevator_1] At floor 4
[D1 09:47:10 elevator_1] Stopped at floor 4
[D1 09:47:10 elevator_1] Opening doors
[D1 09:47:13 elevator_1] Opened doors
[D1 09:47:13 citizen_37] Entered elevator_1, going to floor 1
[D1 09:47:13 floor_4] citizen_37 is leaving the queue
[D1 09:47:13 floor_4] The queue is now empty
[D1 09:47:19 elevator_2] At floor 0
[D1 09:47:19 elevator_2] Stopped at floor 0
[D1 09:47:19 elevator_2] Opening doors
[D1 09:47:22 elevator_2] Opened doors
[D1 09:47:22 citizen_47] Entered elevator_2, going to floor 5
[D1 09:47:22 floor_0] citizen_47 is leaving the queue
[D1 09:47:22 floor_0] The queue is now empty
[D1 09:47:25 elevator_1] Closing doors
[D1 09:47:28 elevator_1] Closed doors
[D1 09:47:34 elevator_2] Closing doors
[D1 09:47:37 elevator_2] Closed doors
[D1 09:47:37 elevator_2] Changing direction to Up
[D1 09:47:38 elevator_1] At floor 3
[D1 09:47:47 elevator_2] At floor 1
[D1 09:47:48 elevator_1] At floor 2
[D1 09:47:57 elevator_2] At floor 2
[D1 09:47:58 elevator_1] At floor 1
[D1 09:47:58 elevator_1] Stopped at floor 1
[D1 09:47:58 elevator_1] Opening doors
[D1 09:47:59 citizen_15] Time to go to floor 2 and stay there for 00:32:09
[D1 09:47:59 floor_1] citizen_15 entered the queue
[D1 09:47:59 floor_1] citizen_15 found an empty queue and will be served immediately
[D1 09:47:59 elevator_1] Summoned to floor 1 from floor 1
[D1 09:48:01 elevator_1] Opened doors
[D1 09:48:01 citizen_37] Left elevator_1, arrived at floor 1
[D1 09:48:01 citizen_15] Entered elevator_1, going to floor 2
[D1 09:48:01 floor_1] citizen_15 is leaving the queue
[D1 09:48:01 floor_1] The queue is now empty
[D1 09:48:07 elevator_2] At floor 3
[D1 09:48:13 elevator_1] Closing doors
[D1 09:48:16 elevator_1] Closed doors
[D1 09:48:16 elevator_1] Changing direction to Up
[D1 09:48:17 elevator_2] At floor 4
[D1 09:48:17 elevator_2] Stopped at floor 4
[D1 09:48:17 elevator_2] Opening doors
[D1 09:48:20 elevator_2] Opened doors
[D1 09:48:20 citizen_35] Left elevator_2, arrived at floor 4
[D1 09:48:26 elevator_1] At floor 2
[D1 09:48:26 elevator_1] Stopped at floor 2
[D1 09:48:26 elevator_1] Opening doors
[D1 09:48:29 elevator_1] Opened doors
[D1 09:48:29 citizen_15] Left elevator_1, arrived at floor 2
[D1 09:48:32 elevator_2] Closing doors
[D1 09:48:35 citizen_10] Time to go to floor 2 and stay there for 00:27:04
[D1 09:48:35 floor_4] citizen_10 entered the queue
[D1 09:48:35 floor_4] citizen_10 found an empty queue and will be served immediately
[D1 09:48:35 elevator_2] Summoned to floor 4 from floor 4
[D1 09:48:35 elevator_2] Reopening doors
[D1 09:48:35 citizen_10] Entered elevator_2, going to floor 2
[D1 09:48:35 floor_4] citizen_10 is leaving the queue
[D1 09:48:35 floor_4] The queue is now empty
[D1 09:48:41 elevator_1] Closing doors
[D1 09:48:44 elevator_1] Closed doors
[D1 09:48:44 elevator_1] Resting at floor 2
[D1 09:48:47 elevator_2] Closing doors
[D1 09:48:50 elevator_2] Closed doors
[D1 09:49:00 elevator_2] At floor 5
[D1 09:49:00 elevator_2] Stopped at floor 5
[D1 09:49:00 elevator_2] Opening doors
[D1 09:49:03 elevator_2] Opened doors
[D1 09:49:03 citizen_47] Left elevator_2, arrived at floor 5
[D1 09:49:15 elevator_2] Closing doors
[D1 09:49:18 elevator_2] Closed doors
[D1 09:49:18 elevator_2] Changing direction to Down
[D1 09:49:28 elevator_2] At floor 4
[D1 09:49:38 elevator_2] At floor 3
[D1 09:49:48 elevator_2] At floor 2
[D1 09:49:48 elevator_2] Stopped at floor 2
[D1 09:49:48 elevator_2] Opening doors
[D1 09:49:51 elevator_2] Opened doors
[D1 09:49:51 citizen_10] Left elevator_2, arrived at floor 2
[D1 09:50:03 elevator_2] Closing doors
[D1 09:50:06 elevator_2] Closed doors
[D1 09:50:06 elevator_2] Resting at floor 2
[D1 09:50:13 citizen_23] Time to go to floor 3 and stay there for 00:22:38
[D1 09:50:13 floor_1] citizen_23 entered the queue
[D1 09:50:13 floor_1] citizen_23 found an empty queue and will be served immediately
[D1 09:50:13 elevator_1] Summoned to floor 1 from floor 2
[D1 09:50:13 elevator_1] Sprung into motion, heading Down
[D1 09:50:13 elevator_2] Summoned to floor 1 from floor 2
[D1 09:50:13 elevator_2] Sprung into motion, heading Down
[D1 09:50:23 elevator_1] At floor 1
[D1 09:50:23 elevator_1] Stopped at floor 1
[D1 09:50:23 elevator_1] Opening doors
[D1 09:50:23 elevator_2] At floor 1
[D1 09:50:23 elevator_2] Stopped at floor 1
[D1 09:50:23 elevator_2] Opening doors
[D1 09:50:26 elevator_1] Opened doors
[D1 09:50:26 elevator_2] Opened doors
[D1 09:50:26 citizen_23] Entered elevator_1, going to floor 3
[D1 09:50:26 floor_1] citizen_23 is leaving the queue
[D1 09:50:26 floor_1] The queue is now empty
[D1 09:50:29 citizen_48] Entered the building, will visit 4 floors in total
[D1 09:50:29 citizen_48] Time to go to floor 2 and stay there for 00:26:12
[D1 09:50:29 floor_0] citizen_48 entered the queue
[D1 09:50:29 floor_0] citizen_48 found an empty queue and will be served immediately
[D1 09:50:29 elevator_1] Summoned to floor 0 from floor 1
[D1 09:50:29 elevator_2] Summoned to floor 0 from floor 1
[D1 09:50:38 elevator_1] Closing doors
[D1 09:50:38 elevator_2] Closing doors
[D1 09:50:41 elevator_1] Closed doors
[D1 09:50:41 elevator_2] Closed doors
[D1 09:50:51 elevator_1] At floor 0
[D1 09:50:51 elevator_1] Stopped at floor 0
[D1 09:50:51 elevator_1] Opening doors
[D1 09:50:51 elevator_2] At floor 0
[D1 09:50:51 elevator_2] Stopped at floor 0
[D1 09:50:51 elevator_2] Opening doors
[D1 09:50:54 elevator_1] Opened doors
[D1 09:50:54 elevator_2] Opened doors
[D1 09:50:54 citizen_48] Entered elevator_1, going to floor 2
[D1 09:50:54 floor_0] citizen_48 is leaving the queue
[D1 09:50:54 floor_0] The queue is now empty
[D1 09:51:06 elevator_1] Closing doors
[D1 09:51:06 elevator_2] Closing doors
[D1 09:51:09 elevator_1] Closed doors
[D1 09:51:09 elevator_2] Closed doors
[D1 09:51:09 elevator_1] Changing direction to Up
[D1 09:51:09 elevator_2] Resting at floor 0
[D1 09:51:19 elevator_1] At floor 1
[D1 09:51:29 citizen_14] Time to go to floor 1 and stay there for 00:34:42
[D1 09:51:29 floor_5] citizen_14 entered the queue
[D1 09:51:29 floor_5] citizen_14 found an empty queue and will be served immediately
[D1 09:51:29 elevator_1] Summoned to floor 5 from floor 1
[D1 09:51:29 elevator_1] At floor 2
[D1 09:51:29 elevator_1] Stopped at floor 2
[D1 09:51:29 elevator_1] Opening doors
[D1 09:51:32 elevator_1] Opened doors
[D1 09:51:32 citizen_48] Left elevator_1, arrived at floor 2
[D1 09:51:42 citizen_49] Entered the building, will visit 3 floors in total
[D1 09:51:42 citizen_49] Time to go to floor 1 and stay there for 00:22:41
[D1 09:51:42 floor_0] citizen_49 entered the queue
[D1 09:51:42 floor_0] citizen_49 found an empty queue and will be served immediately
[D1 09:51:42 elevator_2] Summoned to floor 0 from floor 0
[D1 09:51:42 elevator_2] Opening doors
[D1 09:51:44 elevator_1] Closing doors
[D1 09:51:45 elevator_2] Opened doors
[D1 09:51:45 citizen_49] Entered elevator_2, going to floor 1
[D1 09:51:45 floor_0] citizen_49 is leaving the queue
[D1 09:51:45 floor_0] The queue is now empty
[D1 09:51:47 elevator_1] Closed doors
[D1 09:51:57 elevator_2] Closing doors
[D1 09:51:57 elevator_1] At floor 3
[D1 09:51:57 elevator_1] Stopped at floor 3
[D1 09:51:57 elevator_1] Opening doors
[D1 09:52:00 elevator_2] Closed doors
[D1 09:52:00 elevator_1] Opened doors
[D1 09:52:00 elevator_2] Sprung into motion, heading Up
[D1 09:52:00 citizen_23] Left elevator_1, arrived at floor 3
[D1 09:52:10 elevator_2] At floor 1
[D1 09:52:10 elevator_2] Stopped at floor 1
[D1 09:52:10 elevator_2] Opening doors
[D1 09:52:12 elevator_1] Closing doors
[D1 09:52:13 elevator_2] Opened doors
[D1 09:52:13 citizen_49] Left elevator_2, arrived at floor 1
[D1 09:52:15 elevator_1] Closed doors
[D1 09:52:15 citizen_24] Time to go to floor 1 and stay there for 00:26:48
[D1 09:52:15 floor_5] citizen_24 entered the queue
[D1 09:52:15 floor_5] citizen_24 is queued along with 0 other arrivals in front of it
[D1 09:52:25 elevator_2] Closing doors
[D1 09:52:25 elevator_1] At floor 4
[D1 09:52:28 elevator_2] Closed doors
[D1 09:52:28 elevator_2] Resting at floor 1
[D1 09:52:35 elevator_1] At floor 5
[D1 09:52:35 elevator_1] Stopped at floor 5
[D1 09:52:35 elevator_1] Opening doors
[D1 09:52:38 elevator_1] Opened doors
[D1 09:52:38 citizen_14] Entered elevator_1, going to floor 1
[D1 09:52:38 floor_5] citizen_14 is leaving the queue
[D1 09:52:38 floor_5] citizen_24 was served
[D1 09:52:38 elevator_1] Summoned to floor 5 from floor 5
[D1 09:52:38 citizen_24] Entered elevator_1, going to floor 1
[D1 09:52:38 floor_5] citizen_24 is leaving the queue
[D1 09:52:38 floor_5] The queue is now empty
[D1 09:52:50 elevator_1] Closing doors
[D1 09:52:53 elevator_1] Closed doors
[D1 09:52:53 elevator_1] Changing direction to Down
[D1 09:53:03 elevator_1] At floor 4
[D1 09:53:13 elevator_1] At floor 3
[D1 09:53:23 elevator_1] At floor 2
[D1 09:53:33 elevator_1] At floor 1
[D1 09:53:33 elevator_1] Stopped at floor 1
[D1 09:53:33 elevator_1] Opening doors
[D1 09:53:36 elevator_1] Opened doors
[D1 09:53:36 citizen_14] Left elevator_1, arrived at floor 1
[D1 09:53:36 citizen_24] Left elevator_1, arrived at floor 1
[D1 09:53:46 citizen_29] Time to go to floor 4 and stay there for 00:31:11
[D1 09:53:46 floor_1] citizen_29 entered the queue
[D1 09:53:46 floor_1] citizen_29 found an empty queue and will be served immediately
[D1 09:53:46 elevator_1] Summoned to floor 1 from floor 1
[D1 09:53:46 elevator_2] Summoned to floor 1 from floor 1
[D1 09:53:46 elevator_2] Opening doors
[D1 09:53:46 citizen_29] Entered elevator_1, going to floor 4
[D1 09:53:46 floor_1] citizen_29 is leaving the queue
[D1 09:53:46 floor_1] The queue is now empty
[D1 09:53:48 elevator_1] Closing doors
[D1 09:53:49 elevator_2] Opened doors
[D1 09:53:51 elevator_1] Closed doors
[D1 09:53:51 elevator_1] Changing direction to Up
[D1 09:54:01 elevator_2] Closing doors
[D1 09:54:01 elevator_1] At floor 2
[D1 09:54:04 elevator_2] Closed doors
[D1 09:54:11 elevator_1] At floor 3
[D1 09:54:21 elevator_1] At floor 4
[D1 09:54:21 elevator_1] Stopped at floor 4
[D1 09:54:21 elevator_1] Opening doors
[D1 09:54:22 citizen_50] Entered the building, will visit 4 floors in total
[D1 09:54:22 citizen_50] Time to go to floor 2 and stay there for 00:27:09
[D1 09:54:22 floor_0] citizen_50 entered the queue
[D1 09:54:22 floor_0] citizen_50 found an empty queue and will be served immediately
[D1 09:54:22 elevator_2] Summoned to floor 0 from floor 1
[D1 09:54:22 elevator_2] Sprung into motion, heading Down
[D1 09:54:24 elevator_1] Opened doors
[D1 09:54:24 citizen_29] Left elevator_1, arrived at floor 4
[D1 09:54:32 elevator_2] At floor 0
[D1 09:54:32 elevator_2] Stopped at floor 0
[D1 09:54:32 elevator_2] Opening doors
[D1 09:54:34 citizen_34] Time to go to floor 1 and stay there for 00:29:43
[D1 09:54:34 floor_2] citizen_34 entered the queue
[D1 09:54:34 floor_2] citizen_34 found an empty queue and will be served immediately
[D1 09:54:34 elevator_1] Summoned to floor 2 from floor 4
[D1 09:54:34 elevator_2] Summoned to floor 2 from floor 0
[D1 09:54:35 elevator_2] Opened doors
[D1 09:54:35 citizen_50] Entered elevator_2, going to floor 2
[D1 09:54:35 floor_0] citizen_50 is leaving the queue
[D1 09:54:35 floor_0] The queue is now empty
[D1 09:54:36 elevator_1] Closing doors
[D1 09:54:39 elevator_1] Closed doors
[D1 09:54:39 elevator_1] Changing direction to Down
[D1 09:54:47 elevator_2] Closing doors
[D1 09:54:49 elevator_1] At floor 3
[D1 09:54:50 elevator_2] Closed doors
[D1 09:54:50 elevator_2] Changing direction to Up
[D1 09:54:59 elevator_1] At floor 2
[D1 09:54:59 elevator_1] Stopped at floor 2
[D1 09:54:59 elevator_1] Opening doors
[D1 09:55:00 elevator_2] At floor 1
[D1 09:55:02 elevator_1] Opened doors
[D1 09:55:02 citizen_34] Entered elevator_1, going to floor 1
[D1 09:55:02 floor_2] citizen_34 is leaving the queue
[D1 09:55:02 floor_2] The queue is now empty
[D1 09:55:10 elevator_2] At floor 2
[D1 09:55:10 elevator_2] Stopped at floor 2
[D1 09:55:10 elevator_2] Opening doors
[D1 09:55:13 elevator_2] Opened doors
[D1 09:55:13 citizen_50] Left elevator_2, arrived at floor 2
[D1 09:55:14 elevator_1] Closing doors
[D1 09:55:17 elevator_1] Closed doors
[D1 09:55:25 elevator_2] Closing doors
[D1 09:55:27 elevator_1] At floor 1
[D1 09:55:27 elevator_1] Stopped at floor 1
[D1 09:55:27 elevator_1] Opening doors
[D1 09:55:28 elevator_2] Closed doors
[D1 09:55:28 elevator_2] Resting at floor 2
[D1 09:55:30 elevator_1] Opened doors
[D1 09:55:30 citizen_34] Left elevator_1, arrived at floor 1
[D1 09:55:42 elevator_1] Closing doors
[D1 09:55:45 elevator_1] Closed doors
[D1 09:55:45 elevator_1] Resting at floor 1
[D1 09:57:00 citizen_31] Time to go to floor 5 and stay there for 00:36:13
[D1 09:57:00 floor_3] citizen_31 entered the queue
[D1 09:57:00 floor_3] citizen_31 found an empty queue and will be served immediately
[D1 09:57:00 elevator_2] Summoned to floor 3 from floor 2
[D1 09:57:00 elevator_2] Sprung into motion, heading Up
[D1 09:57:10 elevator_2] At floor 3
[D1 09:57:10 elevator_2] Stopped at floor 3
[D1 09:57:10 elevator_2] Opening doors
[D1 09:57:13 elevator_2] Opened doors
[D1 09:57:13 citizen_31] Entered elevator_2, going to floor 5
[D1 09:57:13 floor_3] citizen_31 is leaving the queue
[D1 09:57:13 floor_3] The queue is now empty
[D1 09:57:15 citizen_1] Time to go to floor 5 and stay there for 00:30:34
[D1 09:57:15 floor_4] citizen_1 entered the queue
[D1 09:57:15 floor_4] citizen_1 found an empty queue and will be served immediately
[D1 09:57:15 elevator_2] Summoned to floor 4 from floor 3
[D1 09:57:25 elevator_2] Closing doors
[D1 09:57:28 elevator_2] Closed doors
[D1 09:57:38 elevator_2] At floor 4
[D1 09:57:38 elevator_2] Stopped at floor 4
[D1 09:57:38 elevator_2] Opening doors
[D1 09:57:41 elevator_2] Opened doors
[D1 09:57:41 citizen_1] Entered elevator_2, going to floor 5
[D1 09:57:41 floor_4] citizen_1 is leaving the queue
[D1 09:57:41 floor_4] The queue is now empty
[D1 09:57:44 citizen_19] Time to go to floor 2 and stay there for 00:43:59
[D1 09:57:44 floor_3] citizen_19 entered the queue
[D1 09:57:44 floor_3] citizen_19 found an empty queue and will be served immediately
[D1 09:57:44 elevator_2] Summoned to floor 3 from floor 4
[D1 09:57:53 elevator_2] Closing doors
[D1 09:57:56 elevator_2] Closed doors
[D1 09:57:58 citizen_36] Time to go to floor 3 and stay there for 00:36:10
[D1 09:57:58 floor_5] citizen_36 entered the queue
[D1 09:57:58 floor_5] citizen_36 found an empty queue and will be served immediately
[D1 09:57:58 elevator_2] Summoned to floor 5 from floor 4
[D1 09:58:06 elevator_2] At floor 5
[D1 09:58:06 elevator_2] Stopped at floor 5
[D1 09:58:06 elevator_2] Opening doors
[D1 09:58:09 elevator_2] Opened doors
[D1 09:58:09 citizen_31] Left elevator_2, arrived at floor 5
[D1 09:58:09 citizen_1] Left elevator_2, arrived at floor 5
[D1 09:58:09 citizen_36] Entered elevator_2, going to floor 3
[D1 09:58:09 floor_5] citizen_36 is leaving the queue
[D1 09:58:09 floor_5] The queue is now empty
[D1 09:58:13 citizen_9] Time to go to the ground floor and leave
[D1 09:58:13 floor_1] citizen_9 entered the queue
[D1 09:58:13 floor_1] citizen_9 found an empty queue and will be served immediately
[D1 09:58:13 elevator_1] Summoned to floor 1 from floor 1
[D1 09:58:13 elevator_1] Opening doors
[D1 09:58:16 elevator_1] Opened doors
[D1 09:58:16 citizen_9] Entered elevator_1, going to floor 0
[D1 09:58:16 floor_1] citizen_9 is leaving the queue
[D1 09:58:16 floor_1] The queue is now empty
[D1 09:58:21 elevator_2] Closing doors
[D1 09:58:24 elevator_2] Closed doors
[D1 09:58:24 elevator_2] Changing direction to Down
[D1 09:58:27 citizen_51] Entered the building, will visit 5 floors in total
[D1 09:58:27 citizen_51] Time to go to floor 1 and stay there for 00:34:39
[D1 09:58:27 floor_0] citizen_51 entered the queue
[D1 09:58:27 floor_0] citizen_51 found an empty queue and will be served immediately
[D1 09:58:27 elevator_1] Summoned to floor 0 from floor 1
[D1 09:58:28 elevator_1] Closing doors
[D1 09:58:31 elevator_1] Closed doors
[D1 09:58:31 elevator_1] Sprung into motion, heading Down
[D1 09:58:34 elevator_2] At floor 4
[D1 09:58:41 elevator_1] At floor 0
[D1 09:58:41 elevator_1] Stopped at floor 0
[D1 09:58:41 elevator_1] Opening doors
[D1 09:58:44 elevator_2] At floor 3
[D1 09:58:44 elevator_2] Stopped at floor 3
[D1 09:58:44 elevator_2] Opening doors
[D1 09:58:44 elevator_1] Opened doors
[D1 09:58:44 citizen_9] Left elevator_1, arrived at floor 0
[D1 09:58:44 citizen_9] Left the building
[D1 09:58:44 citizen_51] Entered elevator_1, going to floor 1
[D1 09:58:44 floor_0] citizen_51 is leaving the queue
[D1 09:58:44 floor_0] The queue is now empty
[D1 09:58:47 elevator_2] Opened doors
[D1 09:58:47 citizen_36] Left elevator_2, arrived at floor 3
[D1 09:58:47 citizen_19] Entered elevator_2, going to floor 2
[D1 09:58:47 floor_3] citizen_19 is leaving the queue
[D1 09:58:47 floor_3] The queue is now empty
[D1 09:58:56 elevator_1] Closing doors
[D1 09:58:59 elevator_2] Closing doors
[D1 09:58:59 elevator_1] Closed doors
[D1 09:58:59 elevator_1] Changing direction to Up
[D1 09:59:02 elevator_2] Closed doors
[D1 09:59:08 citizen_38] Time to go to floor 2 and stay there for 00:34:35
[D1 09:59:08 floor_5] citizen_38 entered the queue
[D1 09:59:08 floor_5] citizen_38 found an empty queue and will be served immediately
[D1 09:59:08 elevator_2] Summoned to floor 5 from floor 3
[D1 09:59:09 elevator_1] At floor 1
[D1 09:59:09 elevator_1] Stopped at floor 1
[D1 09:59:09 elevator_1] Opening doors
[D1 09:59:12 elevator_2] At floor 2
[D1 09:59:12 elevator_2] Stopped at floor 2
[D1 09:59:12 elevator_2] Opening doors
[D1 09:59:12 elevator_1] Opened doors
[D1 09:59:12 citizen_51] Left elevator_1, arrived at floor 1
[D1 09:59:13 citizen_40] Time to go to floor 1 and stay there for 00:27:38
[D1 09:59:13 floor_3] citizen_40 entered the queue
[D1 09:59:13 floor_3] citizen_40 found an empty queue and will be served immediately
[D1 09:59:13 elevator_2] Summoned to floor 3 from floor 2
[D1 09:59:15 elevator_2] Opened doors
[D1 09:59:15 citizen_19] Left elevator_2, arrived at floor 2
[D1 09:59:24 elevator_1] Closing doors
[D1 09:59:27 elevator_2] Closing doors
[D1 09:59:27 elevator_1] Closed doors
[D1 09:59:27 elevator_1] Resting at floor 1
[D1 09:59:30 elevator_2] Closed doors
[D1 09:59:30 elevator_2] Changing direction to Up
[D1 09:59:40 elevator_2] At floor 3
[D1 09:59:40 elevator_2] Stopped at floor 3
[D1 09:59:40 elevator_2] Opening doors
[D1 09:59:43 elevator_2] Opened doors
[D1 09:59:43 citizen_40] Entered elevator_2, going to floor 1
[D1 09:59:43 floor_3] citizen_40 is leaving the queue
[D1 09:59:43 floor_3] The queue is now empty
[D1 09:59:55 elevator_2] Closing doors
[D1 09:59:58 elevator_2] Closed doors
[D1 10:00:08 elevator_2] At floor 4
[D1 10:00:18 elevator_2] At floor 5
[D1 10:00:18 elevator_2] Stopped at floor 5
[D1 10:00:18 elevator_2] Opening doors
[D1 10:00:21 elevator_2] Opened doors
[D1 10:00:21 citizen_38] Entered elevator_2, going to floor 2
[D1 10:00:21 floor_5] citizen_38 is leaving the queue
[D1 10:00:21 floor_5] The queue is now empty
[D1 10:00:33 elevator_2] Closing doors
[D1 10:00:36 elevator_2] Closed doors
[D1 10:00:36 elevator_2] Changing direction to Down
[D1 10:00:46 elevator_2] At floor 4
[D1 10:00:56 elevator_2] At floor 3
[D1 10:01:06 elevator_2] At floor 2
[D1 10:01:06 elevator_2] Stopped at floor 2
[D1 10:01:06 elevator_2] Opening doors
[D1 10:01:09 elevator_2] Opened doors
[D1 10:01:09 citizen_38] Left elevator_2, arrived at floor 2
[D1 10:01:18 citizen_52] Entered the building, will visit 5 floors in total
[D1 10:01:18 citizen_52] Time to go to floor 4 and stay there for 00:24:16
[D1 10:01:18 floor_0] citizen_52 entered the queue
[D1 10:01:18 floor_0] citizen_52 found an empty queue and will be served immediately
[D1 10:01:18 elevator_1] Summoned to floor 0 from floor 1
[D1 10:01:18 elevator_1] Sprung into motion, heading Down
[D1 10:01:21 elevator_2] Closing doors
[D1 10:01:24 elevator_2] Closed doors
[D1 10:01:28 elevator_1] At floor 0
[D1 10:01:28 elevator_1] Stopped at floor 0
[D1 10:01:28 elevator_1] Opening doors
[D1 10:01:31 elevator_1] Opened doors
[D1 10:01:31 citizen_52] Entered elevator_1, going to floor 4
[D1 10:01:31 floor_0] citizen_52 is leaving the queue
[D1 10:01:31 floor_0] The queue is now empty
[D1 10:01:34 citizen_13] Time to go to the ground floor and leave
[D1 10:01:34 floor_3] citizen_13 entered the queue
[D1 10:01:34 floor_3] citizen_13 found an empty queue and will be served immediately
[D1 10:01:34 elevator_2] Summoned to floor 3 from floor 2
[D1 10:01:34 elevator_2] At floor 1
[D1 10:01:34 elevator_2] Stopped at floor 1
[D1 10:01:34 elevator_2] Opening doors
[D1 10:01:37 elevator_2] Opened doors
[D1 10:01:37 citizen_40] Left elevator_2, arrived at floor 1
[D1 10:01:43 elevator_1] Closing doors
[D1 10:01:46 elevator_1] Closed doors
[D1 10:01:46 elevator_1] Changing direction to Up
[D1 10:01:49 elevator_2] Closing doors
[D1 10:01:52 elevator_2] Closed doors
[D1 10:01:52 elevator_2] Changing direction to Up
[D1 10:01:56 elevator_1] At floor 1
[D1 10:02:02 elevator_2] At floor 2
[D1 10:02:06 elevator_1] At floor 2
[D1 10:02:12 elevator_2] At floor 3
[D1 10:02:12 elevator_2] Stopped at floor 3
[D1 10:02:12 elevator_2] Opening doors
[D1 10:02:15 elevator_2] Opened doors
[D1 10:02:15 citizen_13] Entered elevator_2, going to floor 0
[D1 10:02:15 floor_3] citizen_13 is leaving the queue
[D1 10:02:15 floor_3] The queue is now empty
[D1 10:02:16 elevator_1] At floor 3
[D1 10:02:22 citizen_53] Entered the building, will visit 3 floors in total
[D1 10:02:22 citizen_53] Time to go to floor 1 and stay there for 00:23:43
[D1 10:02:22 floor_0] citizen_53 entered the queue
[D1 10:02:22 floor_0] citizen_53 found an empty queue and will be served immediately
[D1 10:02:22 elevator_1] Summoned to floor 0 from floor 3
[D1 10:02:22 elevator_2] Summoned to floor 0 from floor 3
[D1 10:02:26 elevator_1] At floor 4
[D1 10:02:26 elevator_1] Stopped at floor 4
[D1 10:02:26 elevator_1] Opening doors
[D1 10:02:27 elevator_2] Closing doors
[D1 10:02:29 elevator_1] Opened doors
[D1 10:02:29 citizen_52] Left elevator_1, arrived at floor 4
[D1 10:02:30 elevator_2] Closed doors
[D1 10:02:30 elevator_2] Changing direction to Down
[D1 10:02:40 elevator_2] At floor 2
[D1 10:02:41 elevator_1] Closing doors
[D1 10:02:44 elevator_1] Closed doors
[D1 10:02:44 elevator_1] Changing direction to Down
[D1 10:02:50 elevator_2] At floor 1
[D1 10:02:51 citizen_32] Time to go to floor 3 and stay there for 00:25:44
[D1 10:02:51 floor_4] citizen_32 entered the queue
[D1 10:02:51 floor_4] citizen_32 found an empty queue and will be served immediately
[D1 10:02:51 elevator_1] Summoned to floor 4 from floor 4
[D1 10:02:54 elevator_1] At floor 3
[D1 10:03:00 elevator_2] At floor 0
[D1 10:03:00 elevator_2] Stopped at floor 0
[D1 10:03:00 elevator_2] Opening doors
[D1 10:03:03 elevator_2] Opened doors
[D1 10:03:03 citizen_13] Left elevator_2, arrived at floor 0
[D1 10:03:03 citizen_13] Left the building
[D1 10:03:03 citizen_53] Entered elevator_2, going to floor 1
[D1 10:03:03 floor_0] citizen_53 is leaving the queue
[D1 10:03:03 floor_0] The queue is now empty
[D1 10:03:04 elevator_1] At floor 2
[D1 10:03:14 elevator_1] At floor 1
[D1 10:03:15 elevator_2] Closing doors
[D1 10:03:18 elevator_2] Closed doors
[D1 10:03:18 elevator_2] Changing direction to Up
[D1 10:03:24 elevator_1] At floor 0
[D1 10:03:24 elevator_1] Stopped at floor 0
[D1 10:03:24 elevator_1] Opening doors
[D1 10:03:27 elevator_1] Opened doors
[D1 10:03:28 elevator_2] At floor 1
[D1 10:03:28 elevator_2] Stopped at floor 1
[D1 10:03:28 elevator_2] Opening doors
[D1 10:03:31 elevator_2] Opened doors
[D1 10:03:31 citizen_53] Left elevator_2, arrived at floor 1
[D1 10:03:35 citizen_54] Entered the building, will visit 4 floors in total
[D1 10:03:35 citizen_54] Time to go to floor 2 and stay there for 00:34:12
[D1 10:03:35 floor_0] citizen_54 entered the queue
[D1 10:03:35 floor_0] citizen_54 found an empty queue and will be served immediately
[D1 10:03:35 elevator_1] Summoned to floor 0 from floor 0
[D1 10:03:35 citizen_54] Entered elevator_1, going to floor 2
[D1 10:03:35 floor_0] citizen_54 is leaving the queue
[D1 10:03:35 floor_0] The queue is now empty
[D1 10:03:39 elevator_1] Closing doors
[D1 10:03:42 elevator_1] Closed doors
[D1 10:03:42 elevator_1] Changing direction to Up
[D1 10:03:43 elevator_2] Closing doors
[D1 10:03:46 elevator_2] Closed doors
[D1 10:03:46 elevator_2] Resting at floor 1
[D1 10:03:52 citizen_26] Time to go to floor 3 and stay there for 00:36:29
[D1 10:03:52 floor_1] citizen_26 entered the queue
[D1 10:03:52 floor_1] citizen_26 found an empty queue and will be served immediately
[D1 10:03:52 elevator_2] Summoned to floor 1 from floor 1
[D1 10:03:52 elevator_2] Opening doors
[D1 10:03:52 elevator_1] At floor 1
[D1 10:03:55 elevator_2] Opened doors
[D1 10:03:55 citizen_26] Entered elevator_2, going to floor 3
[D1 10:03:55 floor_1] citizen_26 is leaving the queue
[D1 10:03:55 floor_1] The queue is now empty
[D1 10:04:02 elevator_1] At floor 2
[D1 10:04:02 elevator_1] Stopped at floor 2
[D1 10:04:02 elevator_1] Opening doors
[D1 10:04:05 elevator_1] Opened doors
[D1 10:04:05 citizen_54] Left elevator_1, arrived at floor 2
[D1 10:04:07 elevator_2] Closing doors
[D1 10:04:10 elevator_2] Closed doors
[D1 10:04:10 elevator_2] Sprung into motion, heading Up
[D1 10:04:17 elevator_1] Closing doors
[D1 10:04:20 citizen_39] Time to go to floor 1 and stay there for 00:35:52
[D1 10:04:20 floor_2] citizen_39 entered the queue
[D1 10:04:20 floor_2] citizen_39 found an empty queue and will be served immediately
[D1 10:04:20 elevator_1] Summoned to floor 2 from floor 2
[D1 10:04:20 elevator_2] At floor 2
[D1 10:04:20 elevator_1] Reopening doors
[D1 10:04:20 citizen_39] Entered elevator_1, going to floor 1
[D1 10:04:20 floor_2] citizen_39 is leaving the queue
[D1 10:04:20 floor_2] The queue is now empty
[D1 10:04:26 citizen_4] Time to go to the ground floor and leave
[D1 10:04:26 floor_3] citizen_4 entered the queue
[D1 10:04:26 floor_3] citizen_4 found an empty queue and will be served immediately
[D1 10:04:26 elevator_1] Summoned to floor 3 from floor 2
[D1 10:04:26 elevator_2] Summoned to floor 3 from floor 2
[D1 10:04:30 elevator_2] At floor 3
[D1 10:04:30 elevator_2] Stopped at floor 3
[D1 10:04:30 elevator_2] Opening doors
[D1 10:04:32 elevator_1] Closing doors
[D1 10:04:33 elevator_2] Opened doors
[D1 10:04:33 citizen_26] Left elevator_2, arrived at floor 3
[D1 10:04:33 citizen_4] Entered elevator_2, going to floor 0
[D1 10:04:33 floor_3] citizen_4 is leaving the queue
[D1 10:04:33 floor_3] The queue is now empty
[D1 10:04:35 elevator_1] Closed doors
[D1 10:04:45 elevator_2] Closing doors
[D1 10:04:45 elevator_1] At floor 3
[D1 10:04:45 elevator_1] Stopped at floor 3
[D1 10:04:45 elevator_1] Opening doors
[D1 10:04:48 elevator_2] Closed doors
[D1 10:04:48 elevator_1] Opened doors
[D1 10:04:48 elevator_2] Changing direction to Down
[D1 10:04:58 elevator_2] At floor 2
[D1 10:05:00 elevator_1] Closing doors
[D1 10:05:02 citizen_25] Time to go to floor 2 and stay there for 00:26:38
[D1 10:05:02 floor_1] citizen_25 entered the queue
[D1 10:05:02 floor_1] citizen_25 found an empty queue and will be served immediately
[D1 10:05:02 elevator_2] Summoned to floor 1 from floor 2
[D1 10:05:03 elevator_1] Closed doors
[D1 10:05:08 elevator_2] At floor 1
[D1 10:05:08 elevator_2] Stopped at floor 1
[D1 10:05:08 elevator_2] Opening doors
[D1 10:05:11 elevator_2] Opened doors
[D1 10:05:11 citizen_25] Entered elevator_2, going to floor 2
[D1 10:05:11 floor_1] citizen_25 is leaving the queue
[D1 10:05:11 floor_1] The queue is now empty
[D1 10:05:13 elevator_1] At floor 4
[D1 10:05:13 elevator_1] Stopped at floor 4
[D1 10:05:13 elevator_1] Opening doors
[D1 10:05:16 elevator_1] Opened doors
[D1 10:05:16 citizen_32] Entered elevator_1, going to floor 3
[D1 10:05:16 floor_4] citizen_32 is leaving the queue
[D1 10:05:16 floor_4] The queue is now empty
[D1 10:05:23 elevator_2] Closing doors
[D1 10:05:26 elevator_2] Closed doors
[D1 10:05:28 elevator_1] Closing doors
[D1 10:05:31 elevator_1] Closed doors
[D1 10:05:31 elevator_1] Changing direction to Down
[D1 10:05:36 elevator_2] At floor 0
[D1 10:05:36 elevator_2] Stopped at floor 0
[D1 10:05:36 elevator_2] Opening doors
[D1 10:05:39 elevator_2] Opened doors
[D1 10:05:39 citizen_4] Left elevator_2, arrived at floor 0
[D1 10:05:39 citizen_4] Left the building
[D1 10:05:41 elevator_1] At floor 3
[D1 10:05:41 elevator_1] Stopped at floor 3
[D1 10:05:41 elevator_1] Opening doors
[D1 10:05:44 elevator_1] Opened doors
[D1 10:05:44 citizen_32] Left elevator_1, arrived at floor 3
[D1 10:05:51 elevator_2] Closing doors
[D1 10:05:54 elevator_2] Closed doors
[D1 10:05:54 elevator_2] Changing direction to Up
[D1 10:05:56 elevator_1] Closing doors
[D1 10:05:59 elevator_1] Closed doors
[D1 10:06:04 elevator_2] At floor 1
[D1 10:06:09 elevator_1] At floor 2
[D1 10:06:13 citizen_43] Time to go to floor 3 and stay there for 00:18:30
[D1 10:06:13 floor_2] citizen_43 entered the queue
[D1 10:06:13 floor_2] citizen_43 found an empty queue and will be served immediately
[D1 10:06:13 elevator_1] Summoned to floor 2 from floor 2
[D1 10:06:14 elevator_2] At floor 2
[D1 10:06:14 elevator_2] Stopped at floor 2
[D1 10:06:14 elevator_2] Opening doors
[D1 10:06:16 citizen_55] Entered the building, will visit 3 floors in total
[D1 10:06:16 citizen_55] Time to go to floor 1 and stay there for 00:31:14
[D1 10:06:16 floor_0] citizen_55 entered the queue
[D1 10:06:16 floor_0] citizen_55 found an empty queue and will be served immediately
[D1 10:06:16 elevator_1] Summoned to floor 0 from floor 2
[D1 10:06:16 elevator_2] Summoned to floor 0 from floor 2
[D1 10:06:17 elevator_2] Opened doors
[D1 10:06:17 citizen_25] Left elevator_2, arrived at floor 2
[D1 10:06:19 elevator_1] At floor 1
[D1 10:06:19 elevator_1] Stopped at floor 1
[D1 10:06:19 elevator_1] Opening doors
[D1 10:06:22 elevator_1] Opened doors
[D1 10:06:22 citizen_39] Left elevator_1, arrived at floor 1
[D1 10:06:29 elevator_2] Closing doors
[D1 10:06:32 elevator_2] Closed doors
[D1 10:06:32 elevator_2] Changing direction to Down
[D1 10:06:34 elevator_1] Closing doors
[D1 10:06:37 elevator_1] Closed doors
[D1 10:06:42 elevator_2] At floor 1
[D1 10:06:47 elevator_1] At floor 0
[D1 10:06:47 elevator_1] Stopped at floor 0
[D1 10:06:47 elevator_1] Opening doors
[D1 10:06:50 elevator_1] Opened doors
[D1 10:06:50 citizen_55] Entered elevator_1, going to floor 1
[D1 10:06:50 floor_0] citizen_55 is leaving the queue
[D1 10:06:50 floor_0] The queue is now empty
[D1 10:06:52 elevator_2] At floor 0
[D1 10:06:52 elevator_2] Stopped at floor 0
[D1 10:06:52 elevator_2] Opening doors
[D1 10:06:55 elevator_2] Opened doors
[D1 10:07:02 elevator_1] Closing doors
[D1 10:07:05 elevator_1] Closed doors
[D1 10:07:05 elevator_1] Changing direction to Up
[D1 10:07:07 elevator_2] Closing doors
[D1 10:07:10 elevator_2] Closed doors
[D1 10:07:10 elevator_2] Resting at floor 0
[D1 10:07:15 elevator_1] At floor 1
[D1 10:07:15 elevator_1] Stopped at floor 1
[D1 10:07:15 elevator_1] Opening doors
[D1 10:07:18 elevator_1] Opened doors
[D1 10:07:18 citizen_55] Left elevator_1, arrived at floor 1
[D1 10:07:30 elevator_1] Closing doors
[D1 10:07:33 elevator_1] Closed doors
[D1 10:07:43 elevator_1] At floor 2
[D1 10:07:43 elevator_1] Stopped at floor 2
[D1 10:07:43 elevator_1] Opening doors
[D1 10:07:46 elevator_1] Opened doors
[D1 10:07:46 citizen_43] Entered elevator_1, going to floor 3
[D1 10:07:46 floor_2] citizen_43 is leaving the queue
[D1 10:07:46 floor_2] The queue is now empty
[D1 10:07:58 elevator_1] Closing doors
[D1 10:08:01 elevator_1] Closed doors
[D1 10:08:11 elevator_1] At floor 3
[D1 10:08:11 elevator_1] Stopped at floor 3
[D1 10:08:11 elevator_1] Opening doors
[D1 10:08:14 elevator_1] Opened doors
[D1 10:08:14 citizen_43] Left elevator_1, arrived at floor 3
[D1 10:08:26 elevator_1] Closing doors
[D1 10:08:29 elevator_1] Closed doors
[D1 10:08:29 elevator_1] Resting at floor 3
[D1 10:08:55 citizen_45] Time to go to floor 3 and stay there for 00:43:40
[D1 10:08:55 floor_4] citizen_45 entered the queue
[D1 10:08:55 floor_4] citizen_45 found an empty queue and will be served immediately
[D1 10:08:55 elevator_1] Summoned to floor 4 from floor 3
[D1 10:08:55 elevator_1] Sprung into motion, heading Up
[D1 10:09:05 elevator_1] At floor 4
[D1 10:09:05 elevator_1] Stopped at floor 4
[D1 10:09:05 elevator_1] Opening doors
[D1 10:09:08 elevator_1] Opened doors
[D1 10:09:08 citizen_45] Entered elevator_1, going to floor 3
[D1 10:09:08 floor_4] citizen_45 is leaving the queue
[D1 10:09:08 floor_4] The queue is now empty
[D1 10:09:16 citizen_17] Time to go to the ground floor and leave
[D1 10:09:16 floor_4] citizen_17 entered the queue
[D1 10:09:16 floor_4] citizen_17 found an empty queue and will be served immediately
[D1 10:09:16 elevator_1] Summoned to floor 4 from floor 4
[D1 10:09:16 citizen_17] Entered elevator_1, going to floor 0
[D1 10:09:16 floor_4] citizen_17 is leaving the queue
[D1 10:09:16 floor_4] The queue is now empty
[D1 10:09:19 citizen_11] Time to go to the ground floor and leave
[D1 10:09:19 floor_3] citizen_11 entered the queue
[D1 10:09:19 floor_3] citizen_11 found an empty queue and will be served immediately
[D1 10:09:19 elevator_1] Summoned to floor 3 from floor 4
[D1 10:09:20 elevator_1] Closing doors
[D1 10:09:23 elevator_1] Closed doors
[D1 10:09:23 elevator_1] Changing direction to Down
[D1 10:09:30 citizen_56] Entered the building, will visit 3 floors in total
[D1 10:09:30 citizen_56] Time to go to floor 1 and stay there for 00:27:08
[D1 10:09:30 floor_0] citizen_56 entered the queue
[D1 10:09:30 floor_0] citizen_56 found an empty queue and will be served immediately
[D1 10:09:30 elevator_2] Summoned to floor 0 from floor 0
[D1 10:09:30 elevator_2] Opening doors
[D1 10:09:33 elevator_1] At floor 3
[D1 10:09:33 elevator_1] Stopped at floor 3
[D1 10:09:33 elevator_1] Opening doors
[D1 10:09:33 elevator_2] Opened doors
[D1 10:09:33 citizen_56] Entered elevator_2, going to floor 1
[D1 10:09:33 floor_0] citizen_56 is leaving the queue
[D1 10:09:33 floor_0] The queue is now empty
[D1 10:09:36 elevator_1] Opened doors
[D1 10:09:36 citizen_45] Left elevator_1, arrived at floor 3
[D1 10:09:36 citizen_11] Entered elevator_1, going to floor 0
[D1 10:09:36 floor_3] citizen_11 is leaving the queue
[D1 10:09:36 floor_3] The queue is now empty
[D1 10:09:45 elevator_2] Closing doors
[D1 10:09:48 elevator_1] Closing doors
[D1 10:09:48 elevator_2] Closed doors
[D1 10:09:48 elevator_2] Sprung into motion, heading Up
[D1 10:09:51 elevator_1] Closed doors
[D1 10:09:58 elevator_2] At floor 1
[D1 10:09:58 elevator_2] Stopped at floor 1
[D1 10:09:58 elevator_2] Opening doors
[D1 10:10:01 elevator_1] At floor 2
[D1 10:10:01 elevator_2] Opened doors
[D1 10:10:01 citizen_56] Left elevator_2, arrived at floor 1
[D1 10:10:11 elevator_1] At floor 1
[D1 10:10:13 elevator_2] Closing doors
[D1 10:10:16 elevator_2] Closed doors
[D1 10:10:16 elevator_2] Resting at floor 1
[D1 10:10:21 elevator_1] At floor 0
[D1 10:10:21 elevator_1] Stopped at floor 0
[D1 10:10:21 elevator_1] Opening doors
[D1 10:10:24 elevator_1] Opened doors
[D1 10:10:24 citizen_17] Left elevator_1, arrived at floor 0
[D1 10:10:24 citizen_11] Left elevator_1, arrived at floor 0
[D1 10:10:24 citizen_17] Left the building
[D1 10:10:24 citizen_11] Left the building
[D1 10:10:34 citizen_22] Time to go to floor 4 and stay there for 00:26:42
[D1 10:10:34 floor_2] citizen_22 entered the queue
[D1 10:10:34 floor_2] citizen_22 found an empty queue and will be served immediately
[D1 10:10:34 elevator_2] Summoned to floor 2 from floor 1
[D1 10:10:34 elevator_2] Sprung into motion, heading Up
[D1 10:10:36 elevator_1] Closing doors
[D1 10:10:39 elevator_1] Closed doors
[D1 10:10:39 elevator_1] Resting at floor 0
[D1 10:10:44 elevator_2] At floor 2
[D1 10:10:44 elevator_2] Stopped at floor 2
[D1 10:10:44 elevator_2] Opening doors
[D1 10:10:47 elevator_2] Opened doors
[D1 10:10:47 citizen_22] Entered elevator_2, going to floor 4
[D1 10:10:47 floor_2] citizen_22 is leaving the queue
[D1 10:10:47 floor_2] The queue is now empty
[D1 10:10:59 elevator_2] Closing doors
[D1 10:11:02 elevator_2] Closed doors
[D1 10:11:10 citizen_57] Entered the building, will visit 4 floors in total
[D1 10:11:10 citizen_57] Time to go to floor 3 and stay there for 00:36:43
[D1 10:11:10 floor_0] citizen_57 entered the queue
[D1 10:11:10 floor_0] citizen_57 found an empty queue and will be served immediately
[D1 10:11:10 elevator_1] Summoned to floor 0 from floor 0
[D1 10:11:10 elevator_1] Opening doors
[D1 10:11:12 elevator_2] At floor 3
[D1 10:11:13 elevator_1] Opened doors
[D1 10:11:13 citizen_57] Entered elevator_1, going to floor 3
[D1 10:11:13 floor_0] citizen_57 is leaving the queue
[D1 10:11:13 floor_0] The queue is now empty
[D1 10:11:16 citizen_33] Time to go to floor 2 and stay there for 00:34:22
[D1 10:11:16 floor_5] citizen_33 entered the queue
[D1 10:11:16 floor_5] citizen_33 found an empty queue and will be served immediately
[D1 10:11:16 elevator_2] Summoned to floor 5 from floor 3
[D1 10:11:22 elevator_2] At floor 4
[D1 10:11:22 elevator_2] Stopped at floor 4
[D1 10:11:22 elevator_2] Opening doors
[D1 10:11:25 elevator_1] Closing doors
[D1 10:11:25 elevator_2] Opened doors
[D1 10:11:25 citizen_22] Left elevator_2, arrived at floor 4
[D1 10:11:28 elevator_1] Closed doors
[D1 10:11:28 elevator_1] Sprung into motion, heading Up
[D1 10:11:33 citizen_20] Time to go to floor 2 and stay there for 00:06:07
[D1 10:11:33 floor_3] citizen_20 entered the queue
[D1 10:11:33 floor_3] citizen_20 found an empty queue and will be served immediately
[D1 10:11:33 elevator_2] Summoned to floor 3 from floor 4
[D1 10:11:37 elevator_2] Closing doors
[D1 10:11:38 elevator_1] At floor 1
[D1 10:11:40 elevator_2] Closed doors
[D1 10:11:48 elevator_1] At floor 2
[D1 10:11:50 elevator_2] At floor 5
[D1 10:11:50 elevator_2] Stopped at floor 5
[D1 10:11:50 elevator_2] Opening doors
[D1 10:11:53 elevator_2] Opened doors
[D1 10:11:53 citizen_33] Entered elevator_2, going to floor 2
[D1 10:11:53 floor_5] citizen_33 is leaving the queue
[D1 10:11:53 floor_5] The queue is now empty
[D1 10:11:58 elevator_1] At floor 3
[D1 10:11:58 elevator_1] Stopped at floor 3
[D1 10:11:58 elevator_1] Opening doors
[D1 10:12:01 elevator_1] Opened doors
[D1 10:12:01 citizen_57] Left elevator_1, arrived at floor 3
[D1 10:12:05 elevator_2] Closing doors
[D1 10:12:08 elevator_2] Closed doors
[D1 10:12:08 elevator_2] Changing direction to Down
[D1 10:12:13 elevator_1] Closing doors
[D1 10:12:16 elevator_1] Closed doors
[D1 10:12:16 elevator_1] Resting at floor 3
[D1 10:12:18 elevator_2] At floor 4
[D1 10:12:25 citizen_30] Time to go to floor 1 and stay there for 00:38:54
[D1 10:12:25 floor_2] citizen_30 entered the queue
[D1 10:12:25 floor_2] citizen_30 found an empty queue and will be served immediately
[D1 10:12:25 elevator_1] Summoned to floor 2 from floor 3
[D1 10:12:25 elevator_1] Sprung into motion, heading Down
[D1 10:12:28 elevator_2] At floor 3
[D1 10:12:28 elevator_2] Stopped at floor 3
[D1 10:12:28 elevator_2] Opening doors
[D1 10:12:31 elevator_2] Opened doors
[D1 10:12:31 citizen_20] Entered elevator_2, going to floor 2
[D1 10:12:31 floor_3] citizen_20 is leaving the queue
[D1 10:12:31 floor_3] The queue is now empty
[D1 10:12:33 citizen_27] Time to go to floor 1 and stay there for 00:19:07
[D1 10:12:33 floor_5] citizen_27 entered the queue
[D1 10:12:33 floor_5] citizen_27 found an empty queue and will be served immediately
[D1 10:12:33 elevator_1] Summoned to floor 5 from floor 3
[D1 10:12:33 elevator_2] Summoned to floor 5 from floor 3
[D1 10:12:35 elevator_1] At floor 2
[D1 10:12:35 elevator_1] Stopped at floor 2
[D1 10:12:35 elevator_1] Opening doors
[D1 10:12:38 elevator_1] Opened doors
[D1 10:12:38 citizen_30] Entered elevator_1, going to floor 1
[D1 10:12:38 floor_2] citizen_30 is leaving the queue
[D1 10:12:38 floor_2] The queue is now empty
[D1 10:12:43 elevator_2] Closing doors
[D1 10:12:46 elevator_2] Closed doors
[D1 10:12:50 elevator_1] Closing doors
[D1 10:12:53 elevator_1] Closed doors
[D1 10:12:56 elevator_2] At floor 2
[D1 10:12:56 elevator_2] Stopped at floor 2
[D1 10:12:56 elevator_2] Opening doors
[D1 10:12:59 elevator_2] Opened doors
[D1 10:12:59 citizen_33] Left elevator_2, arrived at floor 2
[D1 10:12:59 citizen_20] Left elevator_2, arrived at floor 2
[D1 10:13:03 elevator_1] At floor 1
[D1 10:13:03 elevator_1] Stopped at floor 1
[D1 10:13:03 elevator_1] Opening doors
[D1 10:13:06 elevator_1] Opened doors
[D1 10:13:06 citizen_30] Left elevator_1, arrived at floor 1
[D1 10:13:11 elevator_2] Closing doors
[D1 10:13:14 elevator_2] Closed doors
[D1 10:13:14 elevator_2] Changing direction to Up
[D1 10:13:18 citizen_3] Time to go to the ground floor and leave
[D1 10:13:18 floor_5] citizen_3 entered the queue
[D1 10:13:18 floor_5] citizen_3 is queued along with 0 other arrivals in front of it
[D1 10:13:18 elevator_1] Closing doors
[D1 10:13:21 elevator_1] Closed doors
[D1 10:13:21 elevator_1] Changing direction to Up
[D1 10:13:24 elevator_2] At floor 3
[D1 10:13:31 elevator_1] At floor 2
[D1 10:13:31 citizen_28] Time to go to floor 4 and stay there for 00:40:33
[D1 10:13:31 floor_5] citizen_28 entered the queue
[D1 10:13:31 floor_5] citizen_28 is queued along with 1 other arrivals in front of it
[D1 10:13:34 elevator_2] At floor 4
[D1 10:13:39 citizen_8] Time to go to the ground floor and leave
[D1 10:13:39 floor_3] citizen_8 entered the queue
[D1 10:13:39 floor_3] citizen_8 found an empty queue and will be served immediately
[D1 10:13:39 elevator_1] Summoned to floor 3 from floor 2
[D1 10:13:39 elevator_2] Summoned to floor 3 from floor 4
[D1 10:13:41 elevator_1] At floor 3
[D1 10:13:41 elevator_1] Stopped at floor 3
[D1 10:13:41 elevator_1] Opening doors
[D1 10:13:44 elevator_2] At floor 5
[D1 10:13:44 elevator_2] Stopped at floor 5
[D1 10:13:44 elevator_2] Opening doors
[D1 10:13:44 elevator_1] Opened doors
[D1 10:13:44 citizen_8] Entered elevator_1, going to floor 0
[D1 10:13:44 floor_3] citizen_8 is leaving the queue
[D1 10:13:44 floor_3] The queue is now empty
[D1 10:13:47 elevator_2] Opened doors
[D1 10:13:47 citizen_27] Entered elevator_2, going to floor 1
[D1 10:13:47 floor_5] citizen_27 is leaving the queue
[D1 10:13:47 floor_5] citizen_3 was served
[D1 10:13:47 elevator_2] Summoned to floor 5 from floor 5
[D1 10:13:47 citizen_3] Entered elevator_2, going to floor 0
[D1 10:13:47 floor_5] citizen_3 is leaving the queue
[D1 10:13:47 floor_5] citizen_28 was served
[D1 10:13:47 elevator_2] Summoned to floor 5 from floor 5
[D1 10:13:47 citizen_28] Entered elevator_2, going to floor 4
[D1 10:13:47 floor_5] citizen_28 is leaving the queue
[D1 10:13:47 floor_5] The queue is now empty
[D1 10:13:56 elevator_1] Closing doors
[D1 10:13:59 elevator_2] Closing doors
[D1 10:13:59 elevator_1] Closed doors
[D1 10:14:02 elevator_2] Closed doors
[D1 10:14:02 elevator_2] Changing direction to Down
[D1 10:14:09 elevator_1] At floor 4
[D1 10:14:10 citizen_42] Time to go to floor 3 and stay there for 00:37:03
[D1 10:14:10 floor_2] citizen_42 entered the queue
[D1 10:14:10 floor_2] citizen_42 found an empty queue and will be served immediately
[D1 10:14:10 elevator_1] Summoned to floor 2 from floor 4
[D1 10:14:12 elevator_2] At floor 4
[D1 10:14:12 elevator_2] Stopped at floor 4
[D1 10:14:12 elevator_2] Opening doors
[D1 10:14:15 elevator_2] Opened doors
[D1 10:14:15 citizen_28] Left elevator_2, arrived at floor 4
[D1 10:14:19 elevator_1] At floor 5
[D1 10:14:19 elevator_1] Stopped at floor 5
[D1 10:14:19 elevator_1] Opening doors
[D1 10:14:22 elevator_1] Opened doors
[D1 10:14:27 elevator_2] Closing doors
[D1 10:14:29 citizen_41] Time to go to floor 2 and stay there for 00:39:01
[D1 10:14:29 floor_5] citizen_41 entered the queue
[D1 10:14:29 floor_5] citizen_41 found an empty queue and will be served immediately
[D1 10:14:29 elevator_1] Summoned to floor 5 from floor 5
[D1 10:14:29 citizen_41] Entered elevator_1, going to floor 2
[D1 10:14:29 floor_5] citizen_41 is leaving the queue
[D1 10:14:29 floor_5] The queue is now empty
[D1 10:14:30 elevator_2] Closed doors
[D1 10:14:34 elevator_1] Closing doors
[D1 10:14:37 elevator_1] Closed doors
[D1 10:14:37 elevator_1] Changing direction to Down
[D1 10:14:38 citizen_23] Time to go to the ground floor and leave
[D1 10:14:38 floor_3] citizen_23 entered the queue
[D1 10:14:38 floor_3] citizen_23 found an empty queue and will be served immediately
[D1 10:14:38 elevator_2] Summoned to floor 3 from floor 4
[D1 10:14:40 elevator_2] At floor 3
[D1 10:14:40 elevator_2] Stopped at floor 3
[D1 10:14:40 elevator_2] Opening doors
[D1 10:14:40 citizen_47] Time to go to floor 1 and stay there for 00:44:11
[D1 10:14:40 floor_5] citizen_47 entered the queue
[D1 10:14:40 floor_5] citizen_47 found an empty queue and will be served immediately
[D1 10:14:40 elevator_1] Summoned to floor 5 from floor 5
[D1 10:14:43 elevator_2] Opened doors
[D1 10:14:43 citizen_35] Time to go to floor 3 and stay there for 00:27:39
[D1 10:14:43 floor_4] citizen_35 entered the queue
[D1 10:14:43 floor_4] citizen_35 found an empty queue and will be served immediately
[D1 10:14:43 elevator_1] Summoned to floor 4 from floor 5
[D1 10:14:43 elevator_2] Summoned to floor 4 from floor 3
[D1 10:14:43 citizen_23] Entered elevator_2, going to floor 0
[D1 10:14:43 floor_3] citizen_23 is leaving the queue
[D1 10:14:43 floor_3] The queue is now empty
[D1 10:14:47 elevator_1] At floor 4
[D1 10:14:47 elevator_1] Stopped at floor 4
[D1 10:14:47 elevator_1] Opening doors
[D1 10:14:50 elevator_1] Opened doors
[D1 10:14:50 citizen_35] Entered elevator_1, going to floor 3
[D1 10:14:50 floor_4] citizen_35 is leaving the queue
[D1 10:14:50 floor_4] The queue is now empty
[D1 10:14:54 citizen_49] Time to go to floor 5 and stay there for 00:22:18
[D1 10:14:54 floor_1] citizen_49 entered the queue
[D1 10:14:54 floor_1] citizen_49 found an empty queue and will be served immediately
[D1 10:14:54 elevator_2] Summoned to floor 1 from floor 3
[D1 10:14:55 elevator_2] Closing doors
[D1 10:14:58 elevator_2] Closed doors
[D1 10:15:02 elevator_1] Closing doors
[D1 10:15:05 elevator_1] Closed doors
[D1 10:15:08 elevator_2] At floor 2
[D1 10:15:15 elevator_1] At floor 3
[D1 10:15:15 elevator_1] Stopped at floor 3
[D1 10:15:15 elevator_1] Opening doors
[D1 10:15:18 elevator_2] At floor 1
[D1 10:15:18 elevator_2] Stopped at floor 1
[D1 10:15:18 elevator_2] Opening doors
[D1 10:15:18 elevator_1] Opened doors
[D1 10:15:18 citizen_35] Left elevator_1, arrived at floor 3
[D1 10:15:21 elevator_2] Opened doors
[D1 10:15:21 citizen_27] Left elevator_2, arrived at floor 1
[D1 10:15:21 citizen_49] Entered elevator_2, going to floor 5
[D1 10:15:21 floor_1] citizen_49 is leaving the queue
[D1 10:15:21 floor_1] The queue is now empty
[D1 10:15:30 elevator_1] Closing doors
[D1 10:15:33 elevator_2] Closing doors
[D1 10:15:33 elevator_1] Closed doors
[D1 10:15:34 citizen_58] Entered the building, will visit 2 floors in total
[D1 10:15:34 citizen_58] Time to go to floor 1 and stay there for 00:26:26
[D1 10:15:34 floor_0] citizen_58 entered the queue
[D1 10:15:34 floor_0] citizen_58 found an empty queue and will be served immediately
[D1 10:15:34 elevator_2] Summoned to floor 0 from floor 1
[D1 10:15:36 elevator_2] Closed doors
[D1 10:15:43 elevator_1] At floor 2
[D1 10:15:43 elevator_1] Stopped at floor 2
[D1 10:15:43 elevator_1] Opening doors
[D1 10:15:46 elevator_2] At floor 0
[D1 10:15:46 elevator_2] Stopped at floor 0
[D1 10:15:46 elevator_2] Opening doors
[D1 10:15:46 elevator_1] Opened doors
[D1 10:15:46 citizen_41] Left elevator_1, arrived at floor 2
[D1 10:15:46 citizen_42] Entered elevator_1, going to floor 3
[D1 10:15:46 floor_2] citizen_42 is leaving the queue
[D1 10:15:46 floor_2] The queue is now empty
[D1 10:15:49 elevator_2] Opened doors
[D1 10:15:49 citizen_3] Left elevator_2, arrived at floor 0
[D1 10:15:49 citizen_23] Left elevator_2, arrived at floor 0
[D1 10:15:49 citizen_3] Left the building
[D1 10:15:49 citizen_23] Left the building
[D1 10:15:49 citizen_58] Entered elevator_2, going to floor 1
[D1 10:15:49 floor_0] citizen_58 is leaving the queue
[D1 10:15:49 floor_0] The queue is now empty
[D1 10:15:58 elevator_1] Closing doors
[D1 10:16:01 elevator_2] Closing doors
[D1 10:16:01 elevator_1] Closed doors
[D1 10:16:04 elevator_2] Closed doors
[D1 10:16:04 elevator_2] Changing direction to Up
[D1 10:16:11 elevator_1] At floor 1
[D1 10:16:14 elevator_2] At floor 1
[D1 10:16:14 elevator_2] Stopped at floor 1
[D1 10:16:14 elevator_2] Opening doors
[D1 10:16:17 elevator_2] Opened doors
[D1 10:16:17 citizen_58] Left elevator_2, arrived at floor 1
[D1 10:16:21 elevator_1] At floor 0
[D1 10:16:21 elevator_1] Stopped at floor 0
[D1 10:16:21 elevator_1] Opening doors
[D1 10:16:24 elevator_1] Opened doors
[D1 10:16:24 citizen_8] Left elevator_1, arrived at floor 0
[D1 10:16:24 citizen_8] Left the building
[D1 10:16:29 elevator_2] Closing doors
[D1 10:16:32 elevator_2] Closed doors
[D1 10:16:36 elevator_1] Closing doors
[D1 10:16:39 elevator_1] Closed doors
[D1 10:16:39 elevator_1] Changing direction to Up
[D1 10:16:42 elevator_2] At floor 2
[D1 10:16:49 elevator_1] At floor 1
[D1 10:16:52 elevator_2] At floor 3
[D1 10:16:55 citizen_10] Time to go to floor 4 and stay there for 00:22:20
[D1 10:16:55 floor_2] citizen_10 entered the queue
[D1 10:16:55 floor_2] citizen_10 found an empty queue and will be served immediately
[D1 10:16:55 elevator_1] Summoned to floor 2 from floor 1
[D1 10:16:55 elevator_2] Summoned to floor 2 from floor 3
[D1 10:16:59 elevator_1] At floor 2
[D1 10:16:59 elevator_1] Stopped at floor 2
[D1 10:16:59 elevator_1] Opening doors
[D1 10:17:01 citizen_18] Time to go to floor 4 and stay there for 00:38:25
[D1 10:17:01 floor_5] citizen_18 entered the queue
[D1 10:17:01 floor_5] citizen_18 is queued along with 0 other arrivals in front of it
[D1 10:17:02 elevator_2] At floor 4
[D1 10:17:02 elevator_2] Stopped at floor 4
[D1 10:17:02 elevator_2] Opening doors
[D1 10:17:02 elevator_1] Opened doors
[D1 10:17:02 citizen_10] Entered elevator_1, going to floor 4
[D1 10:17:02 floor_2] citizen_10 is leaving the queue
[D1 10:17:02 floor_2] The queue is now empty
[D1 10:17:03 citizen_59] Entered the building, will visit 2 floors in total
[D1 10:17:03 citizen_59] Time to go to floor 4 and stay there for 00:41:27
[D1 10:17:03 floor_0] citizen_59 entered the queue
[D1 10:17:03 floor_0] citizen_59 found an empty queue and will be served immediately
[D1 10:17:03 elevator_1] Summoned to floor 0 from floor 2
[D1 10:17:05 elevator_2] Opened doors
[D1 10:17:14 elevator_1] Closing doors
[D1 10:17:17 elevator_2] Closing doors
[D1 10:17:17 elevator_1] Closed doors
[D1 10:17:20 elevator_2] Closed doors
[D1 10:17:27 elevator_1] At floor 3
[D1 10:17:27 elevator_1] Stopped at floor 3
[D1 10:17:27 elevator_1] Opening doors
[D1 10:17:30 elevator_2] At floor 5
[D1 10:17:30 elevator_2] Stopped at floor 5
[D1 10:17:30 elevator_2] Opening doors
[D1 10:17:30 elevator_1] Opened doors
[D1 10:17:30 citizen_42] Left elevator_1, arrived at floor 3
[D1 10:17:33 elevator_2] Opened doors
[D1 10:17:33 citizen_49] Left elevator_2, arrived at floor 5
[D1 10:17:42 elevator_1] Closing doors
[D1 10:17:44 citizen_48] Time to go to floor 3 and stay there for 00:25:11
[D1 10:17:44 floor_2] citizen_48 entered the queue
[D1 10:17:44 floor_2] citizen_48 found an empty queue and will be served immediately
[D1 10:17:44 elevator_1] Summoned to floor 2 from floor 3
[D1 10:17:45 elevator_2] Closing doors
[D1 10:17:45 elevator_1] Closed doors
[D1 10:17:48 elevator_2] Closed doors
[D1 10:17:48 elevator_2] Changing direction to Down
[D1 10:17:55 elevator_1] At floor 4
[D1 10:17:55 elevator_1] Stopped at floor 4
[D1 10:17:55 elevator_1] Opening doors
[D1 10:17:58 elevator_2] At floor 4
[D1 10:17:58 elevator_1] Opened doors
[D1 10:17:58 citizen_10] Left elevator_1, arrived at floor 4
[D1 10:18:08 elevator_2] At floor 3
[D1 10:18:10 elevator_1] Closing doors
[D1 10:18:13 elevator_1] Closed doors
[D1 10:18:17 citizen_6] Time to go to the ground floor and leave
[D1 10:18:17 floor_5] citizen_6 entered the queue
[D1 10:18:17 floor_5] citizen_6 is queued along with 1 other arrivals in front of it
[D1 10:18:18 elevator_2] At floor 2
[D1 10:18:18 elevator_2] Stopped at floor 2
[D1 10:18:18 elevator_2] Opening doors
[D1 10:18:21 elevator_2] Opened doors
[D1 10:18:23 citizen_21] Time to go to floor 3 and stay there for 00:20:04
[D1 10:18:23 floor_2] citizen_21 entered the queue
[D1 10:18:23 floor_2] citizen_21 is queued along with 0 other arrivals in front of it
[D1 10:18:23 elevator_1] At floor 5
[D1 10:18:23 elevator_1] Stopped at floor 5
[D1 10:18:23 elevator_1] Opening doors
[D1 10:18:26 elevator_1] Opened doors
[D1 10:18:26 citizen_47] Entered elevator_1, going to floor 1
[D1 10:18:26 floor_5] citizen_47 is leaving the queue
[D1 10:18:26 floor_5] citizen_18 was served
[D1 10:18:26 elevator_1] Summoned to floor 5 from floor 5
[D1 10:18:26 citizen_18] Entered elevator_1, going to floor 4
[D1 10:18:26 floor_5] citizen_18 is leaving the queue
[D1 10:18:26 floor_5] citizen_6 was served
[D1 10:18:26 elevator_1] Summoned to floor 5 from floor 5
[D1 10:18:26 citizen_6] Entered elevator_1, going to floor 0
[D1 10:18:26 floor_5] citizen_6 is leaving the queue
[D1 10:18:26 floor_5] The queue is now empty
[D1 10:18:33 elevator_2] Closing doors
[D1 10:18:36 citizen_2] Time to go to floor 1 and stay there for 00:32:25
[D1 10:18:36 floor_2] citizen_2 entered the queue
[D1 10:18:36 floor_2] citizen_2 is queued along with 1 other arrivals in front of it
[D1 10:18:36 elevator_2] Closed doors
[D1 10:18:36 elevator_2] Resting at floor 2
[D1 10:18:38 elevator_1] Closing doors
[D1 10:18:41 elevator_1] Closed doors
[D1 10:18:41 elevator_1] Changing direction to Down
[D1 10:18:51 elevator_1] At floor 4
[D1 10:18:51 elevator_1] Stopped at floor 4
[D1 10:18:51 elevator_1] Opening doors
[D1 10:18:54 elevator_1] Opened doors
[D1 10:18:54 citizen_18] Left elevator_1, arrived at floor 4
[D1 10:19:06 citizen_20] Time to go to floor 3 and stay there for 00:29:23
[D1 10:19:06 floor_2] citizen_20 entered the queue
[D1 10:19:06 floor_2] citizen_20 is queued along with 2 other arrivals in front of it
[D1 10:19:06 elevator_1] Closing doors
[D1 10:19:09 citizen_7] Time to go to floor 3 and stay there for 00:29:11
[D1 10:19:09 floor_5] citizen_7 entered the queue
[D1 10:19:09 floor_5] citizen_7 found an empty queue and will be served immediately
[D1 10:19:09 elevator_1] Summoned to floor 5 from floor 4
[D1 10:19:09 elevator_1] Closed doors
[D1 10:19:19 elevator_1] At floor 3
[D1 10:19:29 elevator_1] At floor 2
[D1 10:19:29 elevator_1] Stopped at floor 2
[D1 10:19:29 elevator_1] Opening doors
[D1 10:19:32 elevator_1] Opened doors
[D1 10:19:32 citizen_48] Entered elevator_1, going to floor 3
[D1 10:19:32 floor_2] citizen_48 is leaving the queue
[D1 10:19:32 floor_2] citizen_21 was served
[D1 10:19:32 elevator_1] Summoned to floor 2 from floor 2
[D1 10:19:32 elevator_2] Summoned to floor 2 from floor 2
[D1 10:19:32 elevator_2] Opening doors
[D1 10:19:32 citizen_21] Entered elevator_1, going to floor 3
[D1 10:19:32 floor_2] citizen_21 is leaving the queue
[D1 10:19:32 floor_2] citizen_2 was served
[D1 10:19:32 elevator_1] Summoned to floor 2 from floor 2
[D1 10:19:32 elevator_2] Summoned to floor 2 from floor 2
[D1 10:19:32 citizen_2] Cannot enter elevator_1, it is full
[D1 10:19:35 elevator_2] Opened doors
[D1 10:19:35 citizen_2] Entered elevator_2, going to floor 1
[D1 10:19:35 floor_2] citizen_2 is leaving the queue
[D1 10:19:35 floor_2] citizen_20 was served
[D1 10:19:35 elevator_1] Summoned to floor 2 from floor 2
[D1 10:19:35 elevator_2] Summoned to floor 2 from floor 2
[D1 10:19:35 citizen_20] Cannot enter elevator_1, it is full
[D1 10:19:35 citizen_20] Entered elevator_2, going to floor 3
[D1 10:19:35 floor_2] citizen_20 is leaving the queue
[D1 10:19:35 floor_2] The queue is now empty
[D1 10:19:44 elevator_1] Closing doors
[D1 10:19:47 elevator_2] Closing doors
[D1 10:19:47 elevator_1] Closed doors
[D1 10:19:50 elevator_2] Closed doors
[D1 10:19:50 elevator_2] Sprung into motion, heading Down
[D1 10:19:57 elevator_1] At floor 1
[D1 10:19:57 elevator_1] Stopped at floor 1
[D1 10:19:57 elevator_1] Opening doors
[D1 10:20:00 elevator_2] At floor 1
[D1 10:20:00 elevator_2] Stopped at floor 1
[D1 10:20:00 elevator_2] Opening doors
[D1 10:20:00 elevator_1] Opened doors
[D1 10:20:00 citizen_47] Left elevator_1, arrived at floor 1
[D1 10:20:03 elevator_2] Opened doors
[D1 10:20:03 citizen_2] Left elevator_2, arrived at floor 1
[D1 10:20:12 elevator_1] Closing doors
[D1 10:20:15 elevator_2] Closing doors
[D1 10:20:15 elevator_1] Closed doors
[D1 10:20:18 elevator_2] Closed doors
[D1 10:20:18 elevator_2] Changing direction to Up
[D1 10:20:24 citizen_24] Time to go to floor 2 and stay there for 00:31:28
[D1 10:20:24 floor_1] citizen_24 entered the queue
[D1 10:20:24 floor_1] citizen_24 found an empty queue and will be served immediately
[D1 10:20:24 elevator_1] Summoned to floor 1 from floor 1
[D1 10:20:24 elevator_2] Summoned to floor 1 from floor 1
[D1 10:20:25 elevator_1] At floor 0
[D1 10:20:25 elevator_1] Stopped at floor 0
[D1 10:20:25 elevator_1] Opening doors
[D1 10:20:27 citizen_60] Entered the building, will visit 4 floors in total
[D1 10:20:27 citizen_60] Time to go to floor 1 and stay there for 00:40:12
[D1 10:20:27 floor_0] citizen_60 entered the queue
[D1 10:20:27 floor_0] citizen_60 is queued along with 0 other arrivals in front of it
[D1 10:20:28 elevator_2] At floor 2
[D1 10:20:28 elevator_1] Opened doors
[D1 10:20:28 citizen_6] Left elevator_1, arrived at floor 0
[D1 10:20:28 citizen_6] Left the building
[D1 10:20:28 citizen_59] Entered elevator_1, going to floor 4
[D1 10:20:28 floor_0] citizen_59 is leaving the queue
[D1 10:20:28 floor_0] citizen_60 was served
[D1 10:20:28 elevator_1] Summoned to floor 0 from floor 0
[D1 10:20:28 citizen_60] Entered elevator_1, going to floor 1
[D1 10:20:28 floor_0] citizen_60 is leaving the queue
[D1 10:20:28 floor_0] The queue is now empty
[D1 10:20:38 citizen_15] Time to go to the ground floor and leave
[D1 10:20:38 floor_2] citizen_15 entered the queue
[D1 10:20:38 floor_2] citizen_15 found an empty queue and will be served immediately
[D1 10:20:38 elevator_2] Summoned to floor 2 from floor 2
[D1 10:20:38 elevator_2] At floor 3
[D1 10:20:38 elevator_2] Stopped at floor 3
[D1 10:20:38 elevator_2] Opening doors
[D1 10:20:40 elevator_1] Closing doors
[D1 10:20:41 elevator_2] Opened doors
[D1 10:20:41 citizen_20] Left elevator_2, arrived at floor 3
[D1 10:20:43 elevator_1] Closed doors
[D1 10:20:43 elevator_1] Changing direction to Up
[D1 10:20:45 citizen_46] Time to go to floor 2 and stay there for 00:25:55
[D1 10:20:45 floor_3] citizen_46 entered the queue
[D1 10:20:45 floor_3] citizen_46 found an empty queue and will be served immediately
[D1 10:20:45 elevator_2] Summoned to floor 3 from floor 3
[D1 10:20:45 citizen_46] Entered elevator_2, going to floor 2
[D1 10:20:45 floor_3] citizen_46 is leaving the queue
[D1 10:20:45 floor_3] The queue is now empty
[D1 10:20:53 elevator_2] Closing doors
[D1 10:20:53 elevator_1] At floor 1
[D1 10:20:53 elevator_1] Stopped at floor 1
[D1 10:20:53 elevator_1] Opening doors
[D1 10:20:56 elevator_2] Closed doors
[D1 10:20:56 elevator_1] Opened doors
[D1 10:20:56 elevator_2] Changing direction to Down
[D1 10:20:56 citizen_60] Left elevator_1, arrived at floor 1
[D1 10:20:56 citizen_24] Entered elevator_1, going to floor 2
[D1 10:20:56 floor_1] citizen_24 is leaving the queue
[D1 10:20:56 floor_1] The queue is now empty
[D1 10:21:03 citizen_12] Time to go to floor 2 and stay there for 00:21:02
[D1 10:21:03 floor_3] citizen_12 entered the queue
[D1 10:21:03 floor_3] citizen_12 found an empty queue and will be served immediately
[D1 10:21:03 elevator_2] Summoned to floor 3 from floor 3
[D1 10:21:06 elevator_2] At floor 2
[D1 10:21:06 elevator_2] Stopped at floor 2
[D1 10:21:06 elevator_2] Opening doors
[D1 10:21:08 elevator_1] Closing doors
[D1 10:21:09 elevator_2] Opened doors
[D1 10:21:09 citizen_46] Left elevator_2, arrived at floor 2
[D1 10:21:09 citizen_15] Entered elevator_2, going to floor 0
[D1 10:21:09 floor_2] citizen_15 is leaving the queue
[D1 10:21:09 floor_2] The queue is now empty
[D1 10:21:11 elevator_1] Closed doors
[D1 10:21:21 elevator_2] Closing doors
[D1 10:21:21 elevator_1] At floor 2
[D1 10:21:21 elevator_1] Stopped at floor 2
[D1 10:21:21 elevator_1] Opening doors
[D1 10:21:24 elevator_2] Closed doors
[D1 10:21:24 elevator_1] Opened doors
[D1 10:21:24 citizen_24] Left elevator_1, arrived at floor 2
[D1 10:21:34 elevator_2] At floor 1
[D1 10:21:34 elevator_2] Stopped at floor 1
[D1 10:21:34 elevator_2] Opening doors
[D1 10:21:36 elevator_1] Closing doors
[D1 10:21:37 elevator_2] Opened doors
[D1 10:21:39 elevator_1] Closed doors
[D1 10:21:49 elevator_2] Closing doors
[D1 10:21:49 elevator_1] At floor 3
[D1 10:21:49 elevator_1] Stopped at floor 3
[D1 10:21:49 elevator_1] Opening doors
[D1 10:21:52 elevator_2] Closed doors
[D1 10:21:52 elevator_1] Opened doors
[D1 10:21:52 citizen_48] Left elevator_1, arrived at floor 3
[D1 10:21:52 citizen_21] Left elevator_1, arrived at floor 3
[D1 10:22:02 elevator_2] At floor 0
[D1 10:22:02 elevator_2] Stopped at floor 0
[D1 10:22:02 elevator_2] Opening doors
[D1 10:22:04 elevator_1] Closing doors
[D1 10:22:05 elevator_2] Opened doors
[D1 10:22:05 citizen_15] Left elevator_2, arrived at floor 0
[D1 10:22:05 citizen_15] Left the building
[D1 10:22:07 elevator_1] Closed doors
[D1 10:22:16 citizen_61] Entered the building, will visit 4 floors in total
[D1 10:22:16 citizen_61] Time to go to floor 2 and stay there for 00:19:40
[D1 10:22:16 floor_0] citizen_61 entered the queue
[D1 10:22:16 floor_0] citizen_61 found an empty queue and will be served immediately
[D1 10:22:16 elevator_2] Summoned to floor 0 from floor 0
[D1 10:22:16 citizen_61] Entered elevator_2, going to floor 2
[D1 10:22:16 floor_0] citizen_61 is leaving the queue
[D1 10:22:16 floor_0] The queue is now empty
[D1 10:22:17 elevator_2] Closing doors
[D1 10:22:17 elevator_1] At floor 4
[D1 10:22:17 elevator_1] Stopped at floor 4
[D1 10:22:17 elevator_1] Opening doors
[D1 10:22:20 elevator_2] Closed doors
[D1 10:22:20 elevator_1] Opened doors
[D1 10:22:20 elevator_2] Changing direction to Up
[D1 10:22:20 citizen_59] Left elevator_1, arrived at floor 4
[D1 10:22:22 citizen_50] Time to go to floor 4 and stay there for 00:28:29
[D1 10:22:22 floor_2] citizen_50 entered the queue
[D1 10:22:22 floor_2] citizen_50 found an empty queue and will be served immediately
[D1 10:22:22 elevator_1] Summoned to floor 2 from floor 4
[D1 10:22:22 elevator_2] Summoned to floor 2 from floor 0
[D1 10:22:30 elevator_2] At floor 1
[D1 10:22:32 elevator_1] Closing doors
[D1 10:22:35 elevator_1] Closed doors
[D1 10:22:40 elevator_2] At floor 2
[D1 10:22:40 elevator_2] Stopped at floor 2
[D1 10:22:40 elevator_2] Opening doors
[D1 10:22:43 elevator_2] Opened doors
[D1 10:22:43 citizen_61] Left elevator_2, arrived at floor 2
[D1 10:22:43 citizen_50] Entered elevator_2, going to floor 4
[D1 10:22:43 floor_2] citizen_50 is leaving the queue
[D1 10:22:43 floor_2] The queue is now empty
[D1 10:22:45 elevator_1] At floor 5
[D1 10:22:45 elevator_1] Stopped at floor 5
[D1 10:22:45 elevator_1] Opening doors
[D1 10:22:48 elevator_1] Opened doors
[D1 10:22:48 citizen_7] Entered elevator_1, going to floor 3
[D1 10:22:48 floor_5] citizen_7 is leaving the queue
[D1 10:22:48 floor_5] The queue is now empty
[D1 10:22:55 elevator_2] Closing doors
[D1 10:22:58 elevator_2] Closed doors
[D1 10:23:00 elevator_1] Closing doors
[D1 10:23:03 elevator_1] Closed doors
[D1 10:23:03 elevator_1] Changing direction to Down
[D1 10:23:08 elevator_2] At floor 3
[D1 10:23:08 elevator_2] Stopped at floor 3
[D1 10:23:08 elevator_2] Opening doors
[D1 10:23:11 elevator_2] Opened doors
[D1 10:23:11 citizen_12] Entered elevator_2, going to floor 2
[D1 10:23:11 floor_3] citizen_12 is leaving the queue
[D1 10:23:11 floor_3] The queue is now empty
[D1 10:23:13 elevator_1] At floor 4
[D1 10:23:23 elevator_2] Closing doors
[D1 10:23:23 elevator_1] At floor 3
[D1 10:23:23 elevator_1] Stopped at floor 3
[D1 10:23:23 elevator_1] Opening doors
[D1 10:23:26 elevator_2] Closed doors
[D1 10:23:26 elevator_1] Opened doors
[D1 10:23:26 citizen_7] Left elevator_1, arrived at floor 3
[D1 10:23:27 citizen_62] Entered the building, will visit 4 floors in total
[D1 10:23:27 citizen_62] Time to go to floor 3 and stay there for 00:27:08
[D1 10:23:27 floor_0] citizen_62 entered the queue
[D1 10:23:27 floor_0] citizen_62 found an empty queue and will be served immediately
[D1 10:23:27 elevator_1] Summoned to floor 0 from floor 3
[D1 10:23:27 elevator_2] Summoned to floor 0 from floor 3
[D1 10:23:36 elevator_2] At floor 4
[D1 10:23:36 elevator_2] Stopped at floor 4
[D1 10:23:36 elevator_2] Opening doors
[D1 10:23:38 elevator_1] Closing doors
[D1 10:23:39 elevator_2] Opened doors
[D1 10:23:39 citizen_50] Left elevator_2, arrived at floor 4
[D1 10:23:41 elevator_1] Closed doors
[D1 10:23:51 citizen_37] Time to go to floor 5 and stay there for 00:35:33
[D1 10:23:51 floor_1] citizen_37 entered the queue
[D1 10:23:51 floor_1] citizen_37 found an empty queue and will be served immediately
[D1 10:23:51 elevator_1] Summoned to floor 1 from floor 3
[D1 10:23:51 elevator_2] Closing doors
[D1 10:23:51 elevator_1] At floor 2
[D1 10:23:51 elevator_1] Stopped at floor 2
[D1 10:23:51 elevator_1] Opening doors
[D1 10:23:54 elevator_2] Closed doors
[D1 10:23:54 elevator_1] Opened doors
[D1 10:23:54 elevator_2] Changing direction to Down
[D1 10:24:04 elevator_2] At floor 3
[D1 10:24:06 elevator_1] Closing doors
[D1 10:24:09 elevator_1] Closed doors
[D1 10:24:14 elevator_2] At floor 2
[D1 10:24:14 elevator_2] Stopped at floor 2
[D1 10:24:14 elevator_2] Opening doors
[D1 10:24:17 elevator_2] Opened doors
[D1 10:24:17 citizen_12] Left elevator_2, arrived at floor 2
[D1 10:24:19 elevator_1] At floor 1
[D1 10:24:19 elevator_1] Stopped at floor 1
[D1 10:24:19 elevator_1] Opening doors
[D1 10:24:22 elevator_1] Opened doors
[D1 10:24:22 citizen_37] Entered elevator_1, going to floor 5
[D1 10:24:22 floor_1] citizen_37 is leaving the queue
[D1 10:24:22 floor_1] The queue is now empty
[D1 10:24:29 elevator_2] Closing doors
[D1 10:24:32 elevator_2] Closed doors
[D1 10:24:34 elevator_1] Closing doors
[D1 10:24:37 elevator_1] Closed doors
[D1 10:24:42 elevator_2] At floor 1
[D1 10:24:47 elevator_1] At floor 0
[D1 10:24:47 elevator_1] Stopped at floor 0
[D1 10:24:47 elevator_1] Opening doors
[D1 10:24:50 elevator_1] Opened doors
[D1 10:24:50 citizen_62] Entered elevator_1, going to floor 3
[D1 10:24:50 floor_0] citizen_62 is leaving the queue
[D1 10:24:50 floor_0] The queue is now empty
[D1 10:24:52 elevator_2] At floor 0
[D1 10:24:52 elevator_2] Stopped at floor 0
[D1 10:24:52 elevator_2] Opening doors
[D1 10:24:55 elevator_2] Opened doors
[D1 10:25:02 elevator_1] Closing doors
[D1 10:25:05 elevator_1] Closed doors
[D1 10:25:05 elevator_1] Changing direction to Up
[D1 10:25:07 elevator_2] Closing doors
[D1 10:25:10 elevator_2] Closed doors
[D1 10:25:10 elevator_2] Resting at floor 0
[D1 10:25:13 citizen_34] Time to go to floor 2 and stay there for 00:29:46
[D1 10:25:13 floor_1] citizen_34 entered the queue
[D1 10:25:13 floor_1] citizen_34 found an empty queue and will be served immediately
[D1 10:25:13 elevator_1] Summoned to floor 1 from floor 0
[D1 10:25:13 elevator_2] Summoned to floor 1 from floor 0
[D1 10:25:13 elevator_2] Sprung into motion, heading Up
[D1 10:25:15 elevator_1] At floor 1
[D1 10:25:15 elevator_1] Stopped at floor 1
[D1 10:25:15 elevator_1] Opening doors
[D1 10:25:18 citizen_63] Entered the building, will visit 2 floors in total
[D1 10:25:18 citizen_63] Time to go to floor 1 and stay there for 00:37:33
[D1 10:25:18 floor_0] citizen_63 entered the queue
[D1 10:25:18 floor_0] citizen_63 found an empty queue and will be served immediately
[D1 10:25:18 elevator_2] Summoned to floor 0 from floor 0
[D1 10:25:18 elevator_1] Opened doors
[D1 10:25:18 citizen_34] Entered elevator_1, going to floor 2
[D1 10:25:18 floor_1] citizen_34 is leaving the queue
[D1 10:25:18 floor_1] The queue is now empty
[D1 10:25:23 elevator_2] At floor 1
[D1 10:25:23 elevator_2] Stopped at floor 1
[D1 10:25:23 elevator_2] Opening doors
[D1 10:25:26 elevator_2] Opened doors
[D1 10:25:30 elevator_1] Closing doors
[D1 10:25:33 elevator_1] Closed doors
[D1 10:25:35 citizen_29] Time to go to floor 5 and stay there for 00:37:50
[D1 10:25:35 floor_4] citizen_29 entered the queue
[D1 10:25:35 floor_4] citizen_29 found an empty queue and will be served immediately
[D1 10:25:35 elevator_1] Summoned to floor 4 from floor 1
[D1 10:25:35 elevator_2] Summoned to floor 4 from floor 1
[D1 10:25:38 elevator_2] Closing doors
[D1 10:25:41 elevator_2] Closed doors
[D1 10:25:43 elevator_1] At floor 2
[D1 10:25:43 elevator_1] Stopped at floor 2
[D1 10:25:43 elevator_1] Opening doors
[D1 10:25:46 elevator_1] Opened doors
[D1 10:25:46 citizen_34] Left elevator_1, arrived at floor 2
[D1 10:25:51 elevator_2] At floor 2
[D1 10:25:58 elevator_1] Closing doors
[D1 10:26:01 elevator_2] At floor 3
[D1 10:26:01 elevator_1] Closed doors
[D1 10:26:11 elevator_2] At floor 4
[D1 10:26:11 elevator_2] Stopped at floor 4
[D1 10:26:11 elevator_2] Opening doors
[D1 10:26:11 elevator_1] At floor 3
[D1 10:26:11 elevator_1] Stopped at floor 3
[D1 10:26:11 elevator_1] Opening doors
[D1 10:26:14 elevator_2] Opened doors
[D1 10:26:14 elevator_1] Opened doors
[D1 10:26:14 citizen_62] Left elevator_1, arrived at floor 3
[D1 10:26:14 citizen_29] Entered elevator_2, going to floor 5
[D1 10:26:14 floor_4] citizen_29 is leaving the queue
[D1 10:26:14 floor_4] The queue is now empty
[D1 10:26:26 elevator_2] Closing doors
[D1 10:26:26 elevator_1] Closing doors
[D1 10:26:29 elevator_2] Closed doors
[D1 10:26:29 elevator_1] Closed doors
[D1 10:26:39 elevator_2] At floor 5
[D1 10:26:39 elevator_2] Stopped at floor 5
[D1 10:26:39 elevator_2] Opening doors
[D1 10:26:39 elevator_1] At floor 4
[D1 10:26:39 elevator_1] Stopped at floor 4
[D1 10:26:39 elevator_1] Opening doors
[D1 10:26:42 elevator_2] Opened doors
[D1 10:26:42 elevator_1] Opened doors
[D1 10:26:42 citizen_29] Left elevator_2, arrived at floor 5
[D1 10:26:44 citizen_43] Time to go to floor 2 and stay there for 00:26:39
[D1 10:26:44 floor_3] citizen_43 entered the queue
[D1 10:26:44 floor_3] citizen_43 found an empty queue and will be served immediately
[D1 10:26:44 elevator_1] Summoned to floor 3 from floor 4
[D1 10:26:45 citizen_52] Time to go to floor 1 and stay there for 00:35:37
[D1 10:26:45 floor_4] citizen_52 entered the queue
[D1 10:26:45 floor_4] citizen_52 found an empty queue and will be served immediately
[D1 10:26:45 elevator_1] Summoned to floor 4 from floor 4
[D1 10:26:45 citizen_52] Entered elevator_1, going to floor 1
[D1 10:26:45 floor_4] citizen_52 is leaving the queue
[D1 10:26:45 floor_4] The queue is now empty
[D1 10:26:54 elevator_2] Closing doors
[D1 10:26:54 elevator_1] Closing doors
[D1 10:26:57 elevator_2] Closed doors
[D1 10:26:57 elevator_1] Closed doors
[D1 10:26:57 elevator_2] Changing direction to Down
[D1 10:27:07 elevator_2] At floor 4
[D1 10:27:07 elevator_1] At floor 5
[D1 10:27:07 elevator_1] Stopped at floor 5
[D1 10:27:07 elevator_1] Opening doors
[D1 10:27:10 elevator_1] Opened doors
[D1 10:27:10 citizen_37] Left elevator_1, arrived at floor 5
[D1 10:27:14 citizen_53] Time to go to floor 3 and stay there for 00:34:06
[D1 10:27:14 floor_1] citizen_53 entered the queue
[D1 10:27:14 floor_1] citizen_53 found an empty queue and will be served immediately
[D1 10:27:14 elevator_2] Summoned to floor 1 from floor 4
[D1 10:27:17 elevator_2] At floor 3
[D1 10:27:22 elevator_1] Closing doors
[D1 10:27:25 elevator_1] Closed doors
[D1 10:27:25 elevator_1] Changing direction to Down
[D1 10:27:27 elevator_2] At floor 2
[D1 10:27:35 elevator_1] At floor 4
[D1 10:27:37 elevator_2] At floor 1
[D1 10:27:37 elevator_2] Stopped at floor 1
[D1 10:27:37 elevator_2] Opening doors
[D1 10:27:40 elevator_2] Opened doors
[D1 10:27:40 citizen_53] Entered elevator_2, going to floor 3
[D1 10:27:40 floor_1] citizen_53 is leaving the queue
[D1 10:27:40 floor_1] The queue is now empty
[D1 10:27:45 elevator_1] At floor 3
[D1 10:27:45 elevator_1] Stopped at floor 3
[D1 10:27:45 elevator_1] Opening doors
[D1 10:27:48 elevator_1] Opened doors
[D1 10:27:48 citizen_43] Entered elevator_1, going to floor 2
[D1 10:27:48 floor_3] citizen_43 is leaving the queue
[D1 10:27:48 floor_3] The queue is now empty
[D1 10:27:52 elevator_2] Closing doors
[D1 10:27:55 elevator_2] Closed doors
[D1 10:28:00 elevator_1] Closing doors
[D1 10:28:03 elevator_1] Closed doors
[D1 10:28:05 elevator_2] At floor 0
[D1 10:28:05 elevator_2] Stopped at floor 0
[D1 10:28:05 elevator_2] Opening doors
[D1 10:28:08 elevator_2] Opened doors
[D1 10:28:08 citizen_63] Entered elevator_2, going to floor 1
[D1 10:28:08 floor_0] citizen_63 is leaving the queue
[D1 10:28:08 floor_0] The queue is now empty
[D1 10:28:13 elevator_1] At floor 2
[D1 10:28:13 elevator_1] Stopped at floor 2
[D1 10:28:13 elevator_1] Opening doors
[D1 10:28:15 citizen_64] Entered the building, will visit 3 floors in total
[D1 10:28:15 citizen_64] Time to go to floor 2 and stay there for 00:39:56
[D1 10:28:15 floor_0] citizen_64 entered the queue
[D1 10:28:15 floor_0] citizen_64 found an empty queue and will be served immediately
[D1 10:28:15 elevator_2] Summoned to floor 0 from floor 0
[D1 10:28:15 citizen_64] Entered elevator_2, going to floor 2
[D1 10:28:15 floor_0] citizen_64 is leaving the queue
[D1 10:28:15 floor_0] The queue is now empty
[D1 10:28:16 elevator_1] Opened doors
[D1 10:28:16 citizen_43] Left elevator_1, arrived at floor 2
[D1 10:28:18 citizen_14] Time to go to floor 2 and stay there for 00:33:30
[D1 10:28:18 floor_1] citizen_14 entered the queue
[D1 10:28:18 floor_1] citizen_14 found an empty queue and will be served immediately
[D1 10:28:18 elevator_1] Summoned to floor 1 from floor 2
[D1 10:28:18 elevator_2] Summoned to floor 1 from floor 0
[D1 10:28:20 elevator_2] Closing doors
[D1 10:28:23 elevator_2] Closed doors
[D1 10:28:23 elevator_2] Changing direction to Up
[D1 10:28:28 elevator_1] Closing doors
[D1 10:28:31 elevator_1] Closed doors
[D1 10:28:33 elevator_2] At floor 1
[D1 10:28:33 elevator_2] Stopped at floor 1
[D1 10:28:33 elevator_2] Opening doors
[D1 10:28:36 elevator_2] Opened doors
[D1 10:28:36 citizen_63] Left elevator_2, arrived at floor 1
[D1 10:28:36 citizen_14] Entered elevator_2, going to floor 2
[D1 10:28:36 floor_1] citizen_14 is leaving the queue
[D1 10:28:36 floor_1] The queue is now empty
[D1 10:28:41 elevator_1] At floor 1
[D1 10:28:41 elevator_1] Stopped at floor 1
[D1 10:28:41 elevator_1] Opening doors
[D1 10:28:43 citizen_1] Time to go to the ground floor and leave
[D1 10:28:43 floor_5] citizen_1 entered the queue
[D1 10:28:43 floor_5] citizen_1 found an empty queue and will be served immediately
[D1 10:28:43 elevator_1] Summoned to floor 5 from floor 1
[D1 10:28:43 elevator_2] Summoned to floor 5 from floor 1
[D1 10:28:44 elevator_1] Opened doors
[D1 10:28:44 citizen_52] Left elevator_1, arrived at floor 1
[D1 10:28:48 elevator_2] Closing doors
[D1 10:28:51 elevator_2] Closed doors
[D1 10:28:56 elevator_1] Closing doors
[D1 10:28:59 elevator_1] Closed doors
[D1 10:28:59 elevator_1] Changing direction to Up
[D1 10:29:01 elevator_2] At floor 2
[D1 10:29:01 elevator_2] Stopped at floor 2
[D1 10:29:01 elevator_2] Opening doors
[D1 10:29:04 elevator_2] Opened doors
[D1 10:29:04 citizen_64] Left elevator_2, arrived at floor 2
[D1 10:29:04 citizen_14] Left elevator_2, arrived at floor 2
[D1 10:29:09 elevator_1] At floor 2
[D1 10:29:15 citizen_40] Time to go to floor 4 and stay there for 00:33:14
[D1 10:29:15 floor_1] citizen_40 entered the queue
[D1 10:29:15 floor_1] citizen_40 found an empty queue and will be served immediately
[D1 10:29:15 elevator_1] Summoned to floor 1 from floor 2
[D1 10:29:15 elevator_2] Summoned to floor 1 from floor 2
[D1 10:29:16 elevator_2] Closing doors
[D1 10:29:19 elevator_1] At floor 3
[D1 10:29:19 elevator_2] Closed doors
[D1 10:29:29 elevator_1] At floor 4
[D1 10:29:29 elevator_2] At floor 3
[D1 10:29:29 elevator_2] Stopped at floor 3
[D1 10:29:29 elevator_2] Opening doors
[D1 10:29:32 elevator_2] Opened doors
[D1 10:29:32 citizen_53] Left elevator_2, arrived at floor 3
[D1 10:29:39 elevator_1] At floor 5
[D1 10:29:39 elevator_1] Stopped at floor 5
[D1 10:29:39 elevator_1] Opening doors
[D1 10:29:42 elevator_1] Opened doors
[D1 10:29:42 citizen_1] Entered elevator_1, going to floor 0
[D1 10:29:42 floor_5] citizen_1 is leaving the queue
[D1 10:29:42 floor_5] The queue is now empty
[D1 10:29:44 elevator_2] Closing doors
[D1 10:29:47 elevator_2] Closed doors
[D1 10:29:54 elevator_1] Closing doors
[D1 10:29:57 elevator_2] At floor 4
[D1 10:29:57 elevator_1] Closed doors
[D1 10:29:57 elevator_1] Changing direction to Down
[D1 10:30:07 elevator_2] At floor 5
[D1 10:30:07 elevator_2] Stopped at floor 5
[D1 10:30:07 elevator_2] Opening doors
[D1 10:30:07 elevator_1] At floor 4
[D1 10:30:10 elevator_2] Opened doors
[D1 10:30:17 elevator_1] At floor 3
[D1 10:30:22 elevator_2] Closing doors
[D1 10:30:25 elevator_2] Closed doors
[D1 10:30:25 elevator_2] Changing direction to Down
[D1 10:30:26 citizen_65] Entered the building, will visit 1 floors in total
[D1 10:30:26 citizen_65] Time to go to floor 3 and stay there for 00:43:21
[D1 10:30:26 floor_0] citizen_65 entered the queue
[D1 10:30:26 floor_0] citizen_65 found an empty queue and will be served immediately
[D1 10:30:26 elevator_1] Summoned to floor 0 from floor 3
[D1 10:30:27 elevator_1] At floor 2
[D1 10:30:35 elevator_2] At floor 4
[D1 10:30:37 elevator_1] At floor 1
[D1 10:30:37 elevator_1] Stopped at floor 1
[D1 10:30:37 elevator_1] Opening doors
[D1 10:30:40 elevator_1] Opened doors
[D1 10:30:40 citizen_40] Entered elevator_1, going to floor 4
[D1 10:30:40 floor_1] citizen_40 is leaving the queue
[D1 10:30:40 floor_1] The queue is now empty
[D1 10:30:45 elevator_2] At floor 3
[D1 10:30:52 elevator_1] Closing doors
[D1 10:30:55 elevator_2] At floor 2
[D1 10:30:55 elevator_1] Closed doors
[D1 10:31:05 elevator_2] At floor 1
[D1 10:31:05 elevator_2] Stopped at floor 1
[D1 10:31:05 elevator_2] Opening doors
[D1 10:31:05 elevator_1] At floor 0
[D1 10:31:05 elevator_1] Stopped at floor 0
[D1 10:31:05 elevator_1] Opening doors
[D1 10:31:08 elevator_2] Opened doors
[D1 10:31:08 elevator_1] Opened doors
[D1 10:31:08 citizen_1] Left elevator_1, arrived at floor 0
[D1 10:31:08 citizen_1] Left the building
[D1 10:31:08 citizen_65] Entered elevator_1, going to floor 3
[D1 10:31:08 floor_0] citizen_65 is leaving the queue
[D1 10:31:08 floor_0] The queue is now empty
[D1 10:31:20 elevator_2] Closing doors
[D1 10:31:20 elevator_1] Closing doors
[D1 10:31:23 elevator_2] Closed doors
[D1 10:31:23 elevator_1] Closed doors
[D1 10:31:23 elevator_2] Resting at floor 1
[D1 10:31:23 elevator_1] Changing direction to Up
[D1 10:31:28 citizen_32] Time to go to floor 1 and stay there for 00:32:12
[D1 10:31:28 floor_3] citizen_32 entered the queue
[D1 10:31:28 floor_3] citizen_32 found an empty queue and will be served immediately
[D1 10:31:28 elevator_2] Summoned to floor 3 from floor 1
[D1 10:31:28 elevator_2] Sprung into motion, heading Up
[D1 10:31:32 citizen_66] Entered the building, will visit 3 floors in total
[D1 10:31:32 citizen_66] Time to go to floor 1 and stay there for 00:31:32
[D1 10:31:32 floor_0] citizen_66 entered the queue
[D1 10:31:32 floor_0] citizen_66 found an empty queue and will be served immediately
[D1 10:31:32 elevator_1] Summoned to floor 0 from floor 0
[D1 10:31:33 elevator_1] At floor 1
[D1 10:31:38 elevator_2] At floor 2
[D1 10:31:43 elevator_1] At floor 2
[D1 10:31:48 elevator_2] At floor 3
[D1 10:31:48 elevator_2] Stopped at floor 3
[D1 10:31:48 elevator_2] Opening doors
[D1 10:31:51 elevator_2] Opened doors
[D1 10:31:51 citizen_32] Entered elevator_2, going to floor 1
[D1 10:31:51 floor_3] citizen_32 is leaving the queue
[D1 10:31:51 floor_3] The queue is now empty
[D1 10:31:53 elevator_1] At floor 3
[D1 10:31:53 elevator_1] Stopped at floor 3
[D1 10:31:53 elevator_1] Opening doors
[D1 10:31:56 elevator_1] Opened doors
[D1 10:31:56 citizen_65] Left elevator_1, arrived at floor 3
[D1 10:32:03 elevator_2] Closing doors
[D1 10:32:06 elevator_2] Closed doors
[D1 10:32:06 elevator_2] Changing direction to Down
[D1 10:32:08 elevator_1] Closing doors
[D1 10:32:11 elevator_1] Closed doors
[D1 10:32:16 elevator_2] At floor 2
[D1 10:32:21 elevator_1] At floor 4
[D1 10:32:21 elevator_1] Stopped at floor 4
[D1 10:32:21 elevator_1] Opening doors
[D1 10:32:24 elevator_1] Opened doors
[D1 10:32:24 citizen_40] Left elevator_1, arrived at floor 4
[D1 10:32:26 elevator_2] At floor 1
[D1 10:32:26 elevator_2] Stopped at floor 1
[D1 10:32:26 elevator_2] Opening doors
[D1 10:32:26 citizen_44] Time to go to floor 3 and stay there for 00:35:31
[D1 10:32:26 floor_2] citizen_44 entered the queue
[D1 10:32:26 floor_2] citizen_44 found an empty queue and will be served immediately
[D1 10:32:26 elevator_2] Summoned to floor 2 from floor 1
[D1 10:32:29 elevator_2] Opened doors
[D1 10:32:29 citizen_32] Left elevator_2, arrived at floor 1
[D1 10:32:36 elevator_1] Closing doors
[D1 10:32:39 elevator_1] Closed doors
[D1 10:32:39 elevator_1] Changing direction to Down
[D1 10:32:41 elevator_2] Closing doors
[D1 10:32:44 elevator_2] Closed doors
[D1 10:32:44 elevator_2] Changing direction to Up
[D1 10:32:49 elevator_1] At floor 3
[D1 10:32:54 elevator_2] At floor 2
[D1 10:32:54 elevator_2] Stopped at floor 2
[D1 10:32:54 elevator_2] Opening doors
[D1 10:32:55 citizen_25] Time to go to floor 5 and stay there for 00:31:36
[D1 10:32:55 floor_2] citizen_25 entered the queue
[D1 10:32:55 floor_2] citizen_25 is queued along with 0 other arrivals in front of it
[D1 10:32:57 elevator_2] Opened doors
[D1 10:32:57 citizen_44] Entered elevator_2, going to floor 3
[D1 10:32:57 floor_2] citizen_44 is leaving the queue
[D1 10:32:57 floor_2] citizen_25 was served
[D1 10:32:57 elevator_2] Summoned to floor 2 from floor 2
[D1 10:32:57 citizen_25] Entered elevator_2, going to floor 5
[D1 10:32:57 floor_2] citizen_25 is leaving the queue
[D1 10:32:57 floor_2] The queue is now empty
[D1 10:32:59 elevator_1] At floor 2
[D1 10:33:09 elevator_2] Closing doors
[D1 10:33:09 elevator_1] At floor 1
[D1 10:33:12 elevator_2] Closed doors
[D1 10:33:19 elevator_1] At floor 0
[D1 10:33:19 elevator_1] Stopped at floor 0
[D1 10:33:19 elevator_1] Opening doors
[D1 10:33:22 elevator_2] At floor 3
[D1 10:33:22 elevator_2] Stopped at floor 3
[D1 10:33:22 elevator_2] Opening doors
[D1 10:33:22 elevator_1] Opened doors
[D1 10:33:22 citizen_66] Entered elevator_1, going to floor 1
[D1 10:33:22 floor_0] citizen_66 is leaving the queue
[D1 10:33:22 floor_0] The queue is now empty
[D1 10:33:25 elevator_2] Opened doors
[D1 10:33:25 citizen_44] Left elevator_2, arrived at floor 3
[D1 10:33:34 elevator_1] Closing doors
[D1 10:33:36 citizen_67] Entered the building, will visit 6 floors in total
[D1 10:33:36 citizen_67] Time to go to floor 5 and stay there for 00:35:50
[D1 10:33:36 floor_0] citizen_67 entered the queue
[D1 10:33:36 floor_0] citizen_67 found an empty queue and will be served immediately
[D1 10:33:36 elevator_1] Summoned to floor 0 from floor 0
[D1 10:33:37 elevator_2] Closing doors
[D1 10:33:37 elevator_1] Reopening doors
[D1 10:33:37 citizen_67] Entered elevator_1, going to floor 5
[D1 10:33:37 floor_0] citizen_67 is leaving the queue
[D1 10:33:37 floor_0] The queue is now empty
[D1 10:33:40 elevator_2] Closed doors
[D1 10:33:49 elevator_1] Closing doors
[D1 10:33:50 elevator_2] At floor 4
[D1 10:33:51 citizen_51] Time to go to floor 4 and stay there for 00:33:16
[D1 10:33:51 floor_1] citizen_51 entered the queue
[D1 10:33:51 floor_1] citizen_51 found an empty queue and will be served immediately
[D1 10:33:51 elevator_1] Summoned to floor 1 from floor 0
[D1 10:33:52 elevator_1] Closed doors
[D1 10:33:52 elevator_1] Changing direction to Up
[D1 10:34:00 elevator_2] At floor 5
[D1 10:34:00 elevator_2] Stopped at floor 5
[D1 10:34:00 elevator_2] Opening doors
[D1 10:34:02 elevator_1] At floor 1
[D1 10:34:02 elevator_1] Stopped at floor 1
[D1 10:34:02 elevator_1] Opening doors
[D1 10:34:03 elevator_2] Opened doors
[D1 10:34:03 citizen_25] Left elevator_2, arrived at floor 5
[D1 10:34:05 elevator_1] Opened doors
[D1 10:34:05 citizen_66] Left elevator_1, arrived at floor 1
[D1 10:34:05 citizen_51] Entered elevator_1, going to floor 4
[D1 10:34:05 floor_1] citizen_51 is leaving the queue
[D1 10:34:05 floor_1] The queue is now empty
[D1 10:34:15 elevator_2] Closing doors
[D1 10:34:17 elevator_1] Closing doors
[D1 10:34:18 elevator_2] Closed doors
[D1 10:34:18 elevator_2] Resting at floor 5
[D1 10:34:20 elevator_1] Closed doors
[D1 10:34:22 citizen_31] Time to go to floor 4 and stay there for 00:27:16
[D1 10:34:22 floor_5] citizen_31 entered the queue
[D1 10:34:22 floor_5] citizen_31 found an empty queue and will be served immediately
[D1 10:34:22 elevator_2] Summoned to floor 5 from floor 5
[D1 10:34:22 elevator_2] Opening doors
[D1 10:34:25 elevator_2] Opened doors
[D1 10:34:25 citizen_31] Entered elevator_2, going to floor 4
[D1 10:34:25 floor_5] citizen_31 is leaving the queue
[D1 10:34:25 floor_5] The queue is now empty
[D1 10:34:28 citizen_27] Time to go to the ground floor and leave
[D1 10:34:28 floor_1] citizen_27 entered the queue
[D1 10:34:28 floor_1] citizen_27 found an empty queue and will be served immediately
[D1 10:34:28 elevator_1] Summoned to floor 1 from floor 1
[D1 10:34:30 elevator_1] At floor 2
[D1 10:34:37 elevator_2] Closing doors
[D1 10:34:40 elevator_1] At floor 3
[D1 10:34:40 elevator_2] Closed doors
[D1 10:34:40 elevator_2] Sprung into motion, heading Down
[D1 10:34:50 elevator_1] At floor 4
[D1 10:34:50 elevator_1] Stopped at floor 4
[D1 10:34:50 elevator_1] Opening doors
[D1 10:34:50 elevator_2] At floor 4
[D1 10:34:50 elevator_2] Stopped at floor 4
[D1 10:34:50 elevator_2] Opening doors
[D1 10:34:53 elevator_1] Opened doors
[D1 10:34:53 elevator_2] Opened doors
[D1 10:34:53 citizen_51] Left elevator_1, arrived at floor 4
[D1 10:34:53 citizen_31] Left elevator_2, arrived at floor 4
[D1 10:34:57 citizen_36] Time to go to floor 4 and stay there for 00:22:50
[D1 10:34:57 floor_3] citizen_36 entered the queue
[D1 10:34:57 floor_3] citizen_36 found an empty queue and will be served immediately
[D1 10:34:57 elevator_1] Summoned to floor 3 from floor 4
[D1 10:34:57 elevator_2] Summoned to floor 3 from floor 4
[D1 10:35:05 elevator_1] Closing doors
[D1 10:35:05 elevator_2] Closing doors
[D1 10:35:08 elevator_1] Closed doors
[D1 10:35:08 elevator_2] Closed doors
[D1 10:35:18 elevator_1] At floor 5
[D1 10:35:18 elevator_1] Stopped at floor 5
[D1 10:35:18 elevator_1] Opening doors
[D1 10:35:18 elevator_2] At floor 3
[D1 10:35:18 elevator_2] Stopped at floor 3
[D1 10:35:18 elevator_2] Opening doors
[D1 10:35:21 elevator_1] Opened doors
[D1 10:35:21 elevator_2] Opened doors
[D1 10:35:21 citizen_67] Left elevator_1, arrived at floor 5
[D1 10:35:21 citizen_36] Entered elevator_2, going to floor 4
[D1 10:35:21 floor_3] citizen_36 is leaving the queue
[D1 10:35:21 floor_3] The queue is now empty
[D1 10:35:33 elevator_2] Closing doors
[D1 10:35:33 elevator_1] Closing doors
[D1 10:35:36 elevator_2] Closed doors
[D1 10:35:36 elevator_1] Closed doors
[D1 10:35:36 elevator_2] Changing direction to Up
[D1 10:35:36 elevator_1] Changing direction to Down
[D1 10:35:44 citizen_38] Time to go to floor 5 and stay there for 00:29:39
[D1 10:35:44 floor_2] citizen_38 entered the queue
[D1 10:35:44 floor_2] citizen_38 found an empty queue and will be served immediately
[D1 10:35:44 elevator_2] Summoned to floor 2 from floor 3
[D1 10:35:46 elevator_2] At floor 4
[D1 10:35:46 elevator_2] Stopped at floor 4
[D1 10:35:46 elevator_2] Opening doors
[D1 10:35:46 elevator_1] At floor 4
[D1 10:35:49 citizen_68] Entered the building, will visit 5 floors in total
[D1 10:35:49 citizen_68] Time to go to floor 4 and stay there for 00:30:45
[D1 10:35:49 floor_0] citizen_68 entered the queue
[D1 10:35:49 floor_0] citizen_68 found an empty queue and will be served immediately
[D1 10:35:49 elevator_1] Summoned to floor 0 from floor 4
[D1 10:35:49 elevator_2] Summoned to floor 0 from floor 4
[D1 10:35:49 elevator_2] Opened doors
[D1 10:35:49 citizen_36] Left elevator_2, arrived at floor 4
[D1 10:35:56 elevator_1] At floor 3
[D1 10:35:56 elevator_1] Stopped at floor 3
[D1 10:35:56 elevator_1] Opening doors
[D1 10:35:59 elevator_1] Opened doors
[D1 10:36:01 elevator_2] Closing doors
[D1 10:36:04 elevator_2] Closed doors
[D1 10:36:04 elevator_2] Changing direction to Down
[D1 10:36:11 elevator_1] Closing doors
[D1 10:36:14 elevator_2] At floor 3
[D1 10:36:14 elevator_1] Closed doors
[D1 10:36:24 elevator_2] At floor 2
[D1 10:36:24 elevator_2] Stopped at floor 2
[D1 10:36:24 elevator_2] Opening doors
[D1 10:36:24 elevator_1] At floor 2
[D1 10:36:27 elevator_2] Opened doors
[D1 10:36:27 citizen_38] Entered elevator_2, going to floor 5
[D1 10:36:27 floor_2] citizen_38 is leaving the queue
[D1 10:36:27 floor_2] The queue is now empty
[D1 10:36:34 elevator_1] At floor 1
[D1 10:36:34 elevator_1] Stopped at floor 1
[D1 10:36:34 elevator_1] Opening doors
[D1 10:36:37 elevator_1] Opened doors
[D1 10:36:37 citizen_27] Entered elevator_1, going to floor 0
[D1 10:36:37 floor_1] citizen_27 is leaving the queue
[D1 10:36:37 floor_1] The queue is now empty
[D1 10:36:39 elevator_2] Closing doors
[D1 10:36:42 elevator_2] Closed doors
[D1 10:36:49 elevator_1] Closing doors
[D1 10:36:52 elevator_2] At floor 1
[D1 10:36:52 elevator_1] Closed doors
[D1 10:37:02 elevator_2] At floor 0
[D1 10:37:02 elevator_2] Stopped at floor 0
[D1 10:37:02 elevator_2] Opening doors
[D1 10:37:02 elevator_1] At floor 0
[D1 10:37:02 elevator_1] Stopped at floor 0
[D1 10:37:02 elevator_1] Opening doors
[D1 10:37:05 elevator_2] Opened doors
[D1 10:37:05 elevator_1] Opened doors
[D1 10:37:05 citizen_27] Left elevator_1, arrived at floor 0
[D1 10:37:05 citizen_27] Left the building
[D1 10:37:05 citizen_68] Entered elevator_2, going to floor 4
[D1 10:37:05 floor_0] citizen_68 is leaving the queue
[D1 10:37:05 floor_0] The queue is now empty
[D1 10:37:09 citizen_56] Time to go to floor 2 and stay there for 00:33:51
[D1 10:37:09 floor_1] citizen_56 entered the queue
[D1 10:37:09 floor_1] citizen_56 found an empty queue and will be served immediately
[D1 10:37:09 elevator_1] Summoned to floor 1 from floor 0
[D1 10:37:09 elevator_2] Summoned to floor 1 from floor 0
[D1 10:37:17 elevator_1] Closing doors
[D1 10:37:17 elevator_2] Closing doors
[D1 10:37:20 elevator_1] Closed doors
[D1 10:37:20 elevator_2] Closed doors
[D1 10:37:20 elevator_1] Changing direction to Up
[D1 10:37:20 elevator_2] Changing direction to Up
[D1 10:37:30 elevator_1] At floor 1
[D1 10:37:30 elevator_1] Stopped at floor 1
[D1 10:37:30 elevator_1] Opening doors
[D1 10:37:30 elevator_2] At floor 1
[D1 10:37:30 elevator_2] Stopped at floor 1
[D1 10:37:30 elevator_2] Opening doors
[D1 10:37:33 elevator_1] Opened doors
[D1 10:37:33 elevator_2] Opened doors
[D1 10:37:33 citizen_56] Entered elevator_1, going to floor 2
[D1 10:37:33 floor_1] citizen_56 is leaving the queue
[D1 10:37:33 floor_1] The queue is now empty
[D1 10:37:45 elevator_1] Closing doors
[D1 10:37:45 elevator_2] Closing doors
[D1 10:37:48 elevator_1] Closed doors
[D1 10:37:48 elevator_2] Closed doors
[D1 10:37:58 elevator_1] At floor 2
[D1 10:37:58 elevator_1] Stopped at floor 2
[D1 10:37:58 elevator_1] Opening doors
[D1 10:37:58 elevator_2] At floor 2
[D1 10:38:01 elevator_1] Opened doors
[D1 10:38:01 citizen_56] Left elevator_1, arrived at floor 2
[D1 10:38:03 citizen_69] Entered the building, will visit 4 floors in total
[D1 10:38:03 citizen_69] Time to go to floor 3 and stay there for 00:33:30
[D1 10:38:03 floor_0] citizen_69 entered the queue
[D1 10:38:03 floor_0] citizen_69 found an empty queue and will be served immediately
[D1 10:38:03 elevator_1] Summoned to floor 0 from floor 2
[D1 10:38:03 elevator_2] Summoned to floor 0 from floor 2
[D1 10:38:07 citizen_22] Time to go to the ground floor and leave
[D1 10:38:07 floor_4] citizen_22 entered the queue
[D1 10:38:07 floor_4] citizen_22 found an empty queue and will be served immediately
[D1 10:38:07 elevator_1] Summoned to floor 4 from floor 2
[D1 10:38:07 elevator_2] Summoned to floor 4 from floor 2
[D1 10:38:08 elevator_2] At floor 3
[D1 10:38:13 elevator_1] Closing doors
[D1 10:38:16 elevator_1] Closed doors
[D1 10:38:17 citizen_54] Time to go to floor 1 and stay there for 00:35:15
[D1 10:38:17 floor_2] citizen_54 entered the queue
[D1 10:38:17 floor_2] citizen_54 found an empty queue and will be served immediately
[D1 10:38:17 elevator_1] Summoned to floor 2 from floor 2
[D1 10:38:18 elevator_2] At floor 4
[D1 10:38:18 elevator_2] Stopped at floor 4
[D1 10:38:18 elevator_2] Opening doors
[D1 10:38:21 elevator_2] Opened doors
[D1 10:38:21 citizen_68] Left elevator_2, arrived at floor 4
[D1 10:38:21 citizen_22] Entered elevator_2, going to floor 0
[D1 10:38:21 floor_4] citizen_22 is leaving the queue
[D1 10:38:21 floor_4] The queue is now empty
[D1 10:38:26 elevator_1] At floor 3
[D1 10:38:32 citizen_55] Time to go to floor 4 and stay there for 00:46:06
[D1 10:38:32 floor_1] citizen_55 entered the queue
[D1 10:38:32 floor_1] citizen_55 found an empty queue and will be served immediately
[D1 10:38:32 elevator_1] Summoned to floor 1 from floor 3
[D1 10:38:33 elevator_2] Closing doors
[D1 10:38:36 elevator_1] At floor 4
[D1 10:38:36 elevator_1] Stopped at floor 4
[D1 10:38:36 elevator_1] Opening doors
[D1 10:38:36 elevator_2] Closed doors
[D1 10:38:39 elevator_1] Opened doors
[D1 10:38:46 elevator_2] At floor 5
[D1 10:38:46 elevator_2] Stopped at floor 5
[D1 10:38:46 elevator_2] Opening doors
[D1 10:38:49 elevator_2] Opened doors
[D1 10:38:49 citizen_38] Left elevator_2, arrived at floor 5
[D1 10:38:51 elevator_1] Closing doors
[D1 10:38:54 elevator_1] Closed doors
[D1 10:38:54 elevator_1] Changing direction to Down
[D1 10:39:01 elevator_2] Closing doors
[D1 10:39:04 elevator_1] At floor 3
[D1 10:39:04 elevator_2] Closed doors
[D1 10:39:04 elevator_2] Changing direction to Down
[D1 10:39:14 elevator_1] At floor 2
[D1 10:39:14 elevator_1] Stopped at floor 2
[D1 10:39:14 elevator_1] Opening doors
[D1 10:39:14 elevator_2] At floor 4
[D1 10:39:17 elevator_1] Opened doors
[D1 10:39:17 citizen_54] Entered elevator_1, going to floor 1
[D1 10:39:17 floor_2] citizen_54 is leaving the queue
[D1 10:39:17 floor_2] The queue is now empty
[D1 10:39:24 elevator_2] At floor 3
[D1 10:39:29 elevator_1] Closing doors
[D1 10:39:32 elevator_1] Closed doors
[D1 10:39:34 elevator_2] At floor 2
[D1 10:39:42 elevator_1] At floor 1
[D1 10:39:42 elevator_1] Stopped at floor 1
[D1 10:39:42 elevator_1] Opening doors
[D1 10:39:44 elevator_2] At floor 1
[D1 10:39:45 elevator_1] Opened doors
[D1 10:39:45 citizen_54] Left elevator_1, arrived at floor 1
[D1 10:39:45 citizen_55] Entered elevator_1, going to floor 4
[D1 10:39:45 floor_1] citizen_55 is leaving the queue
[D1 10:39:45 floor_1] The queue is now empty
[D1 10:39:51 citizen_49] Time to go to floor 1 and stay there for 00:24:21
[D1 10:39:51 floor_5] citizen_49 entered the queue
[D1 10:39:51 floor_5] citizen_49 found an empty queue and will be served immediately
[D1 10:39:51 elevator_1] Summoned to floor 5 from floor 1
[D1 10:39:51 elevator_2] Summoned to floor 5 from floor 1
[D1 10:39:54 elevator_2] At floor 0
[D1 10:39:54 elevator_2] Stopped at floor 0
[D1 10:39:54 elevator_2] Opening doors
[D1 10:39:57 elevator_1] Closing doors
[D1 10:39:57 elevator_2] Opened doors
[D1 10:39:57 citizen_22] Left elevator_2, arrived at floor 0
[D1 10:39:57 citizen_22] Left the building
[D1 10:39:57 citizen_69] Entered elevator_2, going to floor 3
[D1 10:39:57 floor_0] citizen_69 is leaving the queue
[D1 10:39:57 floor_0] The queue is now empty
[D1 10:40:00 elevator_1] Closed doors
[D1 10:40:09 elevator_2] Closing doors
[D1 10:40:10 elevator_1] At floor 0
[D1 10:40:10 elevator_1] Stopped at floor 0
[D1 10:40:10 elevator_1] Opening doors
[D1 10:40:12 elevator_2] Closed doors
[D1 10:40:12 elevator_2] Changing direction to Up
[D1 10:40:13 elevator_1] Opened doors
[D1 10:40:18 citizen_10] Time to go to the ground floor and leave
[D1 10:40:18 floor_4] citizen_10 entered the queue
[D1 10:40:18 floor_4] citizen_10 found an empty queue and will be served immediately
[D1 10:40:18 elevator_1] Summoned to floor 4 from floor 0
[D1 10:40:18 elevator_2] Summoned to floor 4 from floor 0
[D1 10:40:22 elevator_2] At floor 1
[D1 10:40:25 elevator_1] Closing doors
[D1 10:40:28 elevator_1] Closed doors
[D1 10:40:28 elevator_1] Changing direction to Up
[D1 10:40:32 elevator_2] At floor 2
[D1 10:40:38 elevator_1] At floor 1
[D1 10:40:42 elevator_2] At floor 3
[D1 10:40:42 elevator_2] Stopped at floor 3
[D1 10:40:42 elevator_2] Opening doors
[D1 10:40:45 elevator_2] Opened doors
[D1 10:40:45 citizen_69] Left elevator_2, arrived at floor 3
[D1 10:40:48 elevator_1] At floor 2
[D1 10:40:57 elevator_2] Closing doors
[D1 10:40:58 elevator_1] At floor 3
[D1 10:41:00 elevator_2] Closed doors
[D1 10:41:02 citizen_26] Time to go to the ground floor and leave
[D1 10:41:02 floor_3] citizen_26 entered the queue
[D1 10:41:02 floor_3] citizen_26 found an empty queue and will be served immediately
[D1 10:41:02 elevator_1] Summoned to floor 3 from floor 3
[D1 10:41:02 elevator_2] Summoned to floor 3 from floor 3
[D1 10:41:08 elevator_1] At floor 4
[D1 10:41:08 elevator_1] Stopped at floor 4
[D1 10:41:08 elevator_1] Opening doors
[D1 10:41:10 elevator_2] At floor 4
[D1 10:41:10 elevator_2] Stopped at floor 4
[D1 10:41:10 elevator_2] Opening doors
[D1 10:41:11 elevator_1] Opened doors
[D1 10:41:11 citizen_55] Left elevator_1, arrived at floor 4
[D1 10:41:11 citizen_10] Entered elevator_1, going to floor 0
[D1 10:41:11 floor_4] citizen_10 is leaving the queue
[D1 10:41:11 floor_4] The queue is now empty
[D1 10:41:13 elevator_2] Opened doors
[D1 10:41:23 elevator_1] Closing doors
[D1 10:41:25 elevator_2] Closing doors
[D1 10:41:26 elevator_1] Closed doors
[D1 10:41:28 elevator_2] Closed doors
[D1 10:41:36 elevator_1] At floor 5
[D1 10:41:36 elevator_1] Stopped at floor 5
[D1 10:41:36 elevator_1] Opening doors
[D1 10:41:38 elevator_2] At floor 5
[D1 10:41:38 elevator_2] Stopped at floor 5
[D1 10:41:38 elevator_2] Opening doors
[D1 10:41:39 elevator_1] Opened doors
[D1 10:41:39 citizen_49] Entered elevator_1, going to floor 1
[D1 10:41:39 floor_5] citizen_49 is leaving the queue
[D1 10:41:39 floor_5] The queue is now empty
[D1 10:41:41 elevator_2] Opened doors
[D1 10:41:51 elevator_1] Closing doors
[D1 10:41:53 elevator_2] Closing doors
[D1 10:41:54 elevator_1] Closed doors
[D1 10:41:54 elevator_1] Changing direction to Down
[D1 10:41:56 citizen_21] Time to go to floor 5 and stay there for 00:24:40
[D1 10:41:56 floor_3] citizen_21 entered the queue
[D1 10:41:56 floor_3] citizen_21 is queued along with 0 other arrivals in front of it
[D1 10:41:56 elevator_2] Closed doors
[D1 10:41:56 elevator_2] Changing direction to Down
[D1 10:42:04 elevator_1] At floor 4
[D1 10:42:06 elevator_2] At floor 4
[D1 10:42:13 citizen_70] Entered the building, will visit 4 floors in total
[D1 10:42:13 citizen_70] Time to go to floor 5 and stay there for 00:41:46
[D1 10:42:13 floor_0] citizen_70 entered the queue
[D1 10:42:13 floor_0] citizen_70 found an empty queue and will be served immediately
[D1 10:42:13 elevator_1] Summoned to floor 0 from floor 4
[D1 10:42:13 elevator_2] Summoned to floor 0 from floor 4
[D1 10:42:14 elevator_1] At floor 3
[D1 10:42:14 elevator_1] Stopped at floor 3
[D1 10:42:14 elevator_1] Opening doors
[D1 10:42:14 citizen_39] Time to go to floor 5 and stay there for 00:26:40
[D1 10:42:14 floor_1] citizen_39 entered the queue
[D1 10:42:14 floor_1] citizen_39 found an empty queue and will be served immediately
[D1 10:42:14 elevator_1] Summoned to floor 1 from floor 3
[D1 10:42:16 elevator_2] At floor 3
[D1 10:42:16 elevator_2] Stopped at floor 3
[D1 10:42:16 elevator_2] Opening doors
[D1 10:42:17 elevator_1] Opened doors
[D1 10:42:17 citizen_26] Entered elevator_1, going to floor 0
[D1 10:42:17 floor_3] citizen_26 is leaving the queue
[D1 10:42:17 floor_3] citizen_21 was served
[D1 10:42:17 elevator_1] Summoned to floor 3 from floor 3
[D1 10:42:17 elevator_2] Summoned to floor 3 from floor 3
[D1 10:42:17 citizen_21] Entered elevator_1, going to floor 5
[D1 10:42:17 floor_3] citizen_21 is leaving the queue
[D1 10:42:17 floor_3] The queue is now empty
[D1 10:42:19 elevator_2] Opened doors
[D1 10:42:23 citizen_61] Time to go to floor 5 and stay there for 00:33:31
[D1 10:42:23 floor_2] citizen_61 entered the queue
[D1 10:42:23 floor_2] citizen_61 found an empty queue and will be served immediately
[D1 10:42:23 elevator_1] Summoned to floor 2 from floor 3
[D1 10:42:23 elevator_2] Summoned to floor 2 from floor 3
[D1 10:42:29 elevator_1] Closing doors
[D1 10:42:31 elevator_2] Closing doors
[D1 10:42:32 elevator_1] Closed doors
[D1 10:42:34 elevator_2] Closed doors
[D1 10:42:42 elevator_1] At floor 2
[D1 10:42:42 elevator_1] Stopped at floor 2
[D1 10:42:42 elevator_1] Opening doors
[D1 10:42:43 citizen_58] Time to go to floor 3 and stay there for 00:33:20
[D1 10:42:43 floor_1] citizen_58 entered the queue
[D1 10:42:43 floor_1] citizen_58 is queued along with 0 other arrivals in front of it
[D1 10:42:44 elevator_2] At floor 2
[D1 10:42:44 elevator_2] Stopped at floor 2
[D1 10:42:44 elevator_2] Opening doors
[D1 10:42:45 elevator_1] Opened doors
[D1 10:42:45 citizen_61] Cannot enter elevator_1, it is full
[D1 10:42:47 elevator_2] Opened doors
[D1 10:42:47 citizen_61] Entered elevator_2, going to floor 5
[D1 10:42:47 floor_2] citizen_61 is leaving the queue
[D1 10:42:47 floor_2] The queue is now empty
[D1 10:42:57 elevator_1] Closing doors
[D1 10:42:57 citizen_35] Time to go to the ground floor and leave
[D1 10:42:57 floor_3] citizen_35 entered the queue
[D1 10:42:57 floor_3] citizen_35 found an empty queue and will be served immediately
[D1 10:42:57 elevator_1] Summoned to floor 3 from floor 2
[D1 10:42:57 elevator_2] Summoned to floor 3 from floor 2
[D1 10:42:59 elevator_2] Closing doors
[D1 10:43:00 elevator_1] Closed doors
[D1 10:43:02 elevator_2] Closed doors
[D1 10:43:10 elevator_1] At floor 1
[D1 10:43:10 elevator_1] Stopped at floor 1
[D1 10:43:10 elevator_1] Opening doors
[D1 10:43:12 elevator_2] At floor 1
[D1 10:43:13 elevator_1] Opened doors
[D1 10:43:13 citizen_49] Left elevator_1, arrived at floor 1
[D1 10:43:13 citizen_39] Entered elevator_1, going to floor 5
[D1 10:43:13 floor_1] citizen_39 is leaving the queue
[D1 10:43:13 floor_1] citizen_58 was served
[D1 10:43:13 elevator_1] Summoned to floor 1 from floor 1
[D1 10:43:13 elevator_2] Summoned to floor 1 from floor 1
[D1 10:43:13 citizen_58] Cannot enter elevator_1, it is full
[D1 10:43:14 citizen_19] Time to go to the ground floor and leave
[D1 10:43:14 floor_2] citizen_19 entered the queue
[D1 10:43:14 floor_2] citizen_19 found an empty queue and will be served immediately
[D1 10:43:14 elevator_1] Summoned to floor 2 from floor 1
[D1 10:43:14 elevator_2] Summoned to floor 2 from floor 1
[D1 10:43:22 elevator_2] At floor 0
[D1 10:43:22 elevator_2] Stopped at floor 0
[D1 10:43:22 elevator_2] Opening doors
[D1 10:43:25 elevator_1] Closing doors
[D1 10:43:25 elevator_2] Opened doors
[D1 10:43:25 citizen_70] Entered elevator_2, going to floor 5
[D1 10:43:25 floor_0] citizen_70 is leaving the queue
[D1 10:43:25 floor_0] The queue is now empty
[D1 10:43:28 elevator_1] Closed doors
[D1 10:43:37 elevator_2] Closing doors
[D1 10:43:38 elevator_1] At floor 0
[D1 10:43:38 elevator_1] Stopped at floor 0
[D1 10:43:38 elevator_1] Opening doors
[D1 10:43:40 elevator_2] Closed doors
[D1 10:43:40 elevator_2] Changing direction to Up
[D1 10:43:41 elevator_1] Opened doors
[D1 10:43:41 citizen_10] Left elevator_1, arrived at floor 0
[D1 10:43:41 citizen_26] Left elevator_1, arrived at floor 0
[D1 10:43:41 citizen_10] Left the building
[D1 10:43:41 citizen_26] Left the building
[D1 10:43:50 elevator_2] At floor 1
[D1 10:43:50 elevator_2] Stopped at floor 1
[D1 10:43:50 elevator_2] Opening doors
[D1 10:43:53 elevator_1] Closing doors
[D1 10:43:53 elevator_2] Opened doors
[D1 10:43:53 citizen_58] Entered elevator_2, going to floor 3
[D1 10:43:53 floor_1] citizen_58 is leaving the queue
[D1 10:43:53 floor_1] The queue is now empty
[D1 10:43:56 elevator_1] Closed doors
[D1 10:43:56 elevator_1] Changing direction to Up
[D1 10:44:05 elevator_2] Closing doors
[D1 10:44:06 elevator_1] At floor 1
[D1 10:44:08 elevator_2] Closed doors
[D1 10:44:16 elevator_1] At floor 2
[D1 10:44:16 elevator_1] Stopped at floor 2
[D1 10:44:16 elevator_1] Opening doors
[D1 10:44:18 elevator_2] At floor 2
[D1 10:44:18 elevator_2] Stopped at floor 2
[D1 10:44:18 elevator_2] Opening doors
[D1 10:44:19 elevator_1] Opened doors
[D1 10:44:19 citizen_19] Entered elevator_1, going to floor 0
[D1 10:44:19 floor_2] citizen_19 is leaving the queue
[D1 10:44:19 floor_2] The queue is now empty
[D1 10:44:21 elevator_2] Opened doors
[D1 10:44:31 elevator_1] Closing doors
[D1 10:44:33 elevator_2] Closing doors
[D1 10:44:34 elevator_1] Closed doors
[D1 10:44:36 elevator_2] Closed doors
[D1 10:44:44 elevator_1] At floor 3
[D1 10:44:44 elevator_1] Stopped at floor 3
[D1 10:44:44 elevator_1] Opening doors
[D1 10:44:46 elevator_2] At floor 3
[D1 10:44:46 elevator_2] Stopped at floor 3
[D1 10:44:46 elevator_2] Opening doors
[D1 10:44:47 elevator_1] Opened doors
[D1 10:44:47 citizen_35] Entered elevator_1, going to floor 0
[D1 10:44:47 floor_3] citizen_35 is leaving the queue
[D1 10:44:47 floor_3] The queue is now empty
[D1 10:44:49 elevator_2] Opened doors
[D1 10:44:49 citizen_58] Left elevator_2, arrived at floor 3
[D1 10:44:59 elevator_1] Closing doors
[D1 10:45:01 elevator_2] Closing doors
[D1 10:45:02 elevator_1] Closed doors
[D1 10:45:04 elevator_2] Closed doors
[D1 10:45:12 elevator_1] At floor 4
[D1 10:45:12 citizen_71] Entered the building, will visit 5 floors in total
[D1 10:45:12 citizen_71] Time to go to floor 5 and stay there for 00:39:50
[D1 10:45:12 floor_0] citizen_71 entered the queue
[D1 10:45:12 floor_0] citizen_71 found an empty queue and will be served immediately
[D1 10:45:12 elevator_2] Summoned to floor 0 from floor 3
[D1 10:45:14 elevator_2] At floor 4
[D1 10:45:19 citizen_12] Time to go to the ground floor and leave
[D1 10:45:19 floor_2] citizen_12 entered the queue
[D1 10:45:19 floor_2] citizen_12 found an empty queue and will be served immediately
[D1 10:45:19 elevator_1] Summoned to floor 2 from floor 4
[D1 10:45:19 elevator_2] Summoned to floor 2 from floor 4
[D1 10:45:22 elevator_1] At floor 5
[D1 10:45:22 elevator_1] Stopped at floor 5
[D1 10:45:22 elevator_1] Opening doors
[D1 10:45:24 elevator_2] At floor 5
[D1 10:45:24 elevator_2] Stopped at floor 5
[D1 10:45:24 elevator_2] Opening doors
[D1 10:45:25 elevator_1] Opened doors
[D1 10:45:25 citizen_21] Left elevator_1, arrived at floor 5
[D1 10:45:25 citizen_39] Left elevator_1, arrived at floor 5
[D1 10:45:27 elevator_2] Opened doors
[D1 10:45:27 citizen_61] Left elevator_2, arrived at floor 5
[D1 10:45:27 citizen_70] Left elevator_2, arrived at floor 5
[D1 10:45:37 elevator_1] Closing doors
[D1 10:45:39 elevator_2] Closing doors
[D1 10:45:40 elevator_1] Closed doors
[D1 10:45:40 elevator_1] Changing direction to Down
[D1 10:45:42 elevator_2] Closed doors
[D1 10:45:42 elevator_2] Changing direction to Down
[D1 10:45:50 elevator_1] At floor 4
[D1 10:45:52 elevator_2] At floor 4
[D1 10:46:00 elevator_1] At floor 3
[D1 10:46:02 elevator_2] At floor 3
[D1 10:46:10 elevator_1] At floor 2
[D1 10:46:10 elevator_1] Stopped at floor 2
[D1 10:46:10 elevator_1] Opening doors
[D1 10:46:12 elevator_2] At floor 2
[D1 10:46:12 elevator_2] Stopped at floor 2
[D1 10:46:12 elevator_2] Opening doors
[D1 10:46:13 elevator_1] Opened doors
[D1 10:46:13 citizen_12] Entered elevator_1, going to floor 0
[D1 10:46:13 floor_2] citizen_12 is leaving the queue
[D1 10:46:13 floor_2] The queue is now empty
[D1 10:46:15 elevator_2] Opened doors
[D1 10:46:25 elevator_1] Closing doors
[D1 10:46:27 elevator_2] Closing doors
[D1 10:46:28 elevator_1] Closed doors
[D1 10:46:30 elevator_2] Closed doors
[D1 10:46:38 elevator_1] At floor 1
[D1 10:46:40 elevator_2] At floor 1
[D1 10:46:48 elevator_1] At floor 0
[D1 10:46:48 elevator_1] Stopped at floor 0
[D1 10:46:48 elevator_1] Opening doors
[D1 10:46:49 citizen_72] Entered the building, will visit 4 floors in total
[D1 10:46:49 citizen_72] Time to go to floor 1 and stay there for 00:25:07
[D1 10:46:49 floor_0] citizen_72 entered the queue
[D1 10:46:49 floor_0] citizen_72 is queued along with 0 other arrivals in front of it
[D1 10:46:50 elevator_2] At floor 0
[D1 10:46:50 elevator_2] Stopped at floor 0
[D1 10:46:50 elevator_2] Opening doors
[D1 10:46:51 elevator_1] Opened doors
[D1 10:46:51 citizen_19] Left elevator_1, arrived at floor 0
[D1 10:46:51 citizen_35] Left elevator_1, arrived at floor 0
[D1 10:46:51 citizen_12] Left elevator_1, arrived at floor 0
[D1 10:46:51 citizen_19] Left the building
[D1 10:46:51 citizen_35] Left the building
[D1 10:46:51 citizen_12] Left the building
[D1 10:46:53 elevator_2] Opened doors
[D1 10:46:53 citizen_71] Entered elevator_2, going to floor 5
[D1 10:46:53 floor_0] citizen_71 is leaving the queue
[D1 10:46:53 floor_0] citizen_72 was served
[D1 10:46:53 elevator_1] Summoned to floor 0 from floor 0
[D1 10:46:53 elevator_2] Summoned to floor 0 from floor 0
[D1 10:46:53 citizen_72] Entered elevator_1, going to floor 1
[D1 10:46:53 floor_0] citizen_72 is leaving the queue
[D1 10:46:53 floor_0] The queue is now empty
[D1 10:47:03 elevator_1] Closing doors
[D1 10:47:03 citizen_48] Time to go to floor 2 and stay there for 00:31:46
[D1 10:47:03 floor_3] citizen_48 entered the queue
[D1 10:47:03 floor_3] citizen_48 found an empty queue and will be served immediately
[D1 10:47:03 elevator_1] Summoned to floor 3 from floor 0
[D1 10:47:03 elevator_2] Summoned to floor 3 from floor 0
[D1 10:47:04 citizen_46] Time to go to floor 5 and stay there for 00:13:13
[D1 10:47:04 floor_2] citizen_46 entered the queue
[D1 10:47:04 floor_2] citizen_46 found an empty queue and will be served immediately
[D1 10:47:04 elevator_1] Summoned to floor 2 from floor 0
[D1 10:47:04 elevator_2] Summoned to floor 2 from floor 0
[D1 10:47:05 elevator_2] Closing doors
[D1 10:47:06 elevator_1] Closed doors
[D1 10:47:06 elevator_1] Changing direction to Up
[D1 10:47:08 elevator_2] Closed doors
[D1 10:47:08 elevator_2] Changing direction to Up
[D1 10:47:16 elevator_1] At floor 1
[D1 10:47:16 elevator_1] Stopped at floor 1
[D1 10:47:16 elevator_1] Opening doors
[D1 10:47:18 elevator_2] At floor 1
[D1 10:47:19 elevator_1] Opened doors
[D1 10:47:19 citizen_72] Left elevator_1, arrived at floor 1
[D1 10:47:21 citizen_33] Time to go to the ground floor and leave
[D1 10:47:21 floor_2] citizen_33 entered the queue
[D1 10:47:21 floor_2] citizen_33 is queued along with 0 other arrivals in front of it
[D1 10:47:28 elevator_2] At floor 2
[D1 10:47:28 elevator_2] Stopped at floor 2
[D1 10:47:28 elevator_2] Opening doors
[D1 10:47:31 elevator_1] Closing doors
[D1 10:47:31 elevator_2] Opened doors
[D1 10:47:31 citizen_46] Entered elevator_2, going to floor 5
[D1 10:47:31 floor_2] citizen_46 is leaving the queue
[D1 10:47:31 floor_2] citizen_33 was served
[D1 10:47:31 elevator_2] Summoned to floor 2 from floor 2
[D1 10:47:31 citizen_33] Entered elevator_2, going to floor 0
[D1 10:47:31 floor_2] citizen_33 is leaving the queue
[D1 10:47:31 floor_2] The queue is now empty
[D1 10:47:34 elevator_1] Closed doors
[D1 10:47:43 elevator_2] Closing doors
[D1 10:47:44 elevator_1] At floor 2
[D1 10:47:44 elevator_1] Stopped at floor 2
[D1 10:47:44 elevator_1] Opening doors
[D1 10:47:46 elevator_2] Closed doors
[D1 10:47:47 elevator_1] Opened doors
[D1 10:47:56 elevator_2] At floor 3
[D1 10:47:56 elevator_2] Stopped at floor 3
[D1 10:47:56 elevator_2] Opening doors
[D1 10:47:59 elevator_1] Closing doors
[D1 10:47:59 elevator_2] Opened doors
[D1 10:47:59 citizen_48] Entered elevator_2, going to floor 2
[D1 10:47:59 floor_3] citizen_48 is leaving the queue
[D1 10:47:59 floor_3] The queue is now empty
[D1 10:48:02 elevator_1] Closed doors
[D1 10:48:11 citizen_73] Entered the building, will visit 3 floors in total
[D1 10:48:11 citizen_73] Time to go to floor 4 and stay there for 00:21:49
[D1 10:48:11 floor_0] citizen_73 entered the queue
[D1 10:48:11 floor_0] citizen_73 found an empty queue and will be served immediately
[D1 10:48:11 elevator_1] Summoned to floor 0 from floor 2
[D1 10:48:11 elevator_2] Closing doors
[D1 10:48:12 elevator_1] At floor 3
[D1 10:48:12 elevator_1] Stopped at floor 3
[D1 10:48:12 elevator_1] Opening doors
[D1 10:48:14 elevator_2] Closed doors
[D1 10:48:15 elevator_1] Opened doors
[D1 10:48:24 elevator_2] At floor 4
[D1 10:48:27 elevator_1] Closing doors
[D1 10:48:30 elevator_1] Closed doors
[D1 10:48:30 elevator_1] Changing direction to Down
[D1 10:48:34 elevator_2] At floor 5
[D1 10:48:34 elevator_2] Stopped at floor 5
[D1 10:48:34 elevator_2] Opening doors
[D1 10:48:37 elevator_2] Opened doors
[D1 10:48:37 citizen_71] Left elevator_2, arrived at floor 5
[D1 10:48:37 citizen_46] Left elevator_2, arrived at floor 5
[D1 10:48:40 elevator_1] At floor 2
[D1 10:48:44 citizen_57] Time to go to floor 4 and stay there for 00:37:28
[D1 10:48:44 floor_3] citizen_57 entered the queue
[D1 10:48:44 floor_3] citizen_57 found an empty queue and will be served immediately
[D1 10:48:44 elevator_1] Summoned to floor 3 from floor 2
[D1 10:48:49 elevator_2] Closing doors
[D1 10:48:50 elevator_1] At floor 1
[D1 10:48:52 elevator_2] Closed doors
[D1 10:48:52 elevator_2] Changing direction to Down
[D1 10:49:00 elevator_1] At floor 0
[D1 10:49:00 elevator_1] Stopped at floor 0
[D1 10:49:00 elevator_1] Opening doors
[D1 10:49:02 elevator_2] At floor 4
[D1 10:49:03 elevator_1] Opened doors
[D1 10:49:03 citizen_73] Entered elevator_1, going to floor 4
[D1 10:49:03 floor_0] citizen_73 is leaving the queue
[D1 10:49:03 floor_0] The queue is now empty
[D1 10:49:12 elevator_2] At floor 3
[D1 10:49:15 elevator_1] Closing doors
[D1 10:49:18 elevator_1] Closed doors
[D1 10:49:18 elevator_1] Changing direction to Up
[D1 10:49:22 elevator_2] At floor 2
[D1 10:49:22 elevator_2] Stopped at floor 2
[D1 10:49:22 elevator_2] Opening doors
[D1 10:49:25 elevator_2] Opened doors
[D1 10:49:25 citizen_48] Left elevator_2, arrived at floor 2
[D1 10:49:28 elevator_1] At floor 1
[D1 10:49:37 elevator_2] Closing doors
[D1 10:49:38 elevator_1] At floor 2
[D1 10:49:40 elevator_2] Closed doors
[D1 10:49:48 elevator_1] At floor 3
[D1 10:49:48 elevator_1] Stopped at floor 3
[D1 10:49:48 elevator_1] Opening doors
[D1 10:49:50 elevator_2] At floor 1
[D1 10:49:51 elevator_1] Opened doors
[D1 10:49:51 citizen_57] Entered elevator_1, going to floor 4
[D1 10:49:51 floor_3] citizen_57 is leaving the queue
[D1 10:49:51 floor_3] The queue is now empty
[D1 10:50:00 elevator_2] At floor 0
[D1 10:50:00 elevator_2] Stopped at floor 0
[D1 10:50:00 elevator_2] Opening doors
[D1 10:50:03 elevator_1] Closing doors
[D1 10:50:03 elevator_2] Opened doors
[D1 10:50:03 citizen_33] Left elevator_2, arrived at floor 0
[D1 10:50:03 citizen_33] Left the building
[D1 10:50:04 citizen_20] Time to go to the ground floor and leave
[D1 10:50:04 floor_3] citizen_20 entered the queue
[D1 10:50:04 floor_3] citizen_20 found an empty queue and will be served immediately
[D1 10:50:04 elevator_1] Summoned to floor 3 from floor 3
[D1 10:50:06 elevator_1] Reopening doors
[D1 10:50:06 citizen_20] Entered elevator_1, going to floor 0
[D1 10:50:06 floor_3] citizen_20 is leaving the queue
[D1 10:50:06 floor_3] The queue is now empty
[D1 10:50:15 elevator_2] Closing doors
[D1 10:50:18 elevator_1] Closing doors
[D1 10:50:18 elevator_2] Closed doors
[D1 10:50:18 elevator_2] Resting at floor 0
[D1 10:50:21 elevator_1] Closed doors
[D1 10:50:31 elevator_1] At floor 4
[D1 10:50:31 elevator_1] Stopped at floor 4
[D1 10:50:31 elevator_1] Opening doors
[D1 10:50:34 elevator_1] Opened doors
[D1 10:50:34 citizen_73] Left elevator_1, arrived at floor 4
[D1 10:50:34 citizen_57] Left elevator_1, arrived at floor 4
[D1 10:50:46 elevator_1] Closing doors
[D1 10:50:49 elevator_1] Closed doors
[D1 10:50:49 elevator_1] Changing direction to Down
[D1 10:50:59 elevator_1] At floor 3
[D1 10:51:01 citizen_74] Entered the building, will visit 4 floors in total
[D1 10:51:01 citizen_74] Time to go to floor 1 and stay there for 00:27:44
[D1 10:51:01 floor_0] citizen_74 entered the queue
[D1 10:51:01 floor_0] citizen_74 found an empty queue and will be served immediately
[D1 10:51:01 elevator_2] Summoned to floor 0 from floor 0
[D1 10:51:01 elevator_2] Opening doors
[D1 10:51:04 elevator_2] Opened doors
[D1 10:51:04 citizen_74] Entered elevator_2, going to floor 1
[D1 10:51:04 floor_0] citizen_74 is leaving the queue
[D1 10:51:04 floor_0] The queue is now empty
[D1 10:51:09 elevator_1] At floor 2
[D1 10:51:16 elevator_2] Closing doors
[D1 10:51:19 elevator_1] At floor 1
[D1 10:51:19 elevator_2] Closed doors
[D1 10:51:19 elevator_2] Sprung into motion, heading Up
[D1 10:51:29 elevator_1] At floor 0
[D1 10:51:29 elevator_1] Stopped at floor 0
[D1 10:51:29 elevator_1] Opening doors
[D1 10:51:29 elevator_2] At floor 1
[D1 10:51:29 elevator_2] Stopped at floor 1
[D1 10:51:29 elevator_2] Opening doors
[D1 10:51:32 elevator_1] Opened doors
[D1 10:51:32 elevator_2] Opened doors
[D1 10:51:32 citizen_20] Left elevator_1, arrived at floor 0
[D1 10:51:32 citizen_74] Left elevator_2, arrived at floor 1
[D1 10:51:32 citizen_20] Left the building
[D1 10:51:44 elevator_2] Closing doors
[D1 10:51:44 elevator_1] Closing doors
[D1 10:51:47 elevator_2] Closed doors
[D1 10:51:47 elevator_1] Closed doors
[D1 10:51:47 elevator_2] Resting at floor 1
[D1 10:51:47 elevator_1] Resting at floor 0
[D1 10:52:00 citizen_30] Time to go to floor 5 and stay there for 00:30:13
[D1 10:52:00 floor_1] citizen_30 entered the queue
[D1 10:52:00 floor_1] citizen_30 found an empty queue and will be served immediately
[D1 10:52:00 elevator_2] Summoned to floor 1 from floor 1
[D1 10:52:00 elevator_2] Opening doors
[D1 10:52:03 elevator_2] Opened doors
[D1 10:52:03 citizen_30] Entered elevator_2, going to floor 5
[D1 10:52:03 floor_1] citizen_30 is leaving the queue
[D1 10:52:03 floor_1] The queue is now empty
[D1 10:52:08 citizen_50] Time to go to floor 1 and stay there for 00:41:30
[D1 10:52:08 floor_4] citizen_50 entered the queue
[D1 10:52:08 floor_4] citizen_50 found an empty queue and will be served immediately
[D1 10:52:08 elevator_2] Summoned to floor 4 from floor 1
[D1 10:52:15 elevator_2] Closing doors
[D1 10:52:18 elevator_2] Closed doors
[D1 10:52:18 elevator_2] Sprung into motion, heading Up
[D1 10:52:28 citizen_2] Time to go to floor 3 and stay there for 00:23:37
[D1 10:52:28 floor_1] citizen_2 entered the queue
[D1 10:52:28 floor_1] citizen_2 found an empty queue and will be served immediately
[D1 10:52:28 elevator_2] Summoned to floor 1 from floor 1
[D1 10:52:28 elevator_2] At floor 2
[D1 10:52:37 citizen_7] Time to go to the ground floor and leave
[D1 10:52:37 floor_3] citizen_7 entered the queue
[D1 10:52:37 floor_3] citizen_7 found an empty queue and will be served immediately
[D1 10:52:37 elevator_2] Summoned to floor 3 from floor 2
[D1 10:52:38 elevator_2] At floor 3
[D1 10:52:38 elevator_2] Stopped at floor 3
[D1 10:52:38 elevator_2] Opening doors
[D1 10:52:41 elevator_2] Opened doors
[D1 10:52:41 citizen_7] Entered elevator_2, going to floor 0
[D1 10:52:41 floor_3] citizen_7 is leaving the queue
[D1 10:52:41 floor_3] The queue is now empty
[D1 10:52:52 citizen_24] Time to go to the ground floor and leave
[D1 10:52:52 floor_2] citizen_24 entered the queue
[D1 10:52:52 floor_2] citizen_24 found an empty queue and will be served immediately
[D1 10:52:52 elevator_2] Summoned to floor 2 from floor 3
[D1 10:52:53 elevator_2] Closing doors
[D1 10:52:56 elevator_2] Closed doors
[D1 10:53:06 elevator_2] At floor 4
[D1 10:53:06 elevator_2] Stopped at floor 4
[D1 10:53:06 elevator_2] Opening doors
[D1 10:53:09 elevator_2] Opened doors
[D1 10:53:09 citizen_50] Entered elevator_2, going to floor 1
[D1 10:53:09 floor_4] citizen_50 is leaving the queue
[D1 10:53:09 floor_4] The queue is now empty
[D1 10:53:16 citizen_45] Time to go to floor 5 and stay there for 00:34:14
[D1 10:53:16 floor_3] citizen_45 entered the queue
[D1 10:53:16 floor_3] citizen_45 found an empty queue and will be served immediately
[D1 10:53:16 elevator_2] Summoned to floor 3 from floor 4
[D1 10:53:21 elevator_2] Closing doors
[D1 10:53:22 citizen_62] Time to go to floor 1 and stay there for 00:19:22
[D1 10:53:22 floor_3] citizen_62 entered the queue
[D1 10:53:22 floor_3] citizen_62 is queued along with 0 other arrivals in front of it
[D1 10:53:24 elevator_2] Closed doors
[D1 10:53:34 elevator_2] At floor 5
[D1 10:53:34 elevator_2] Stopped at floor 5
[D1 10:53:34 elevator_2] Opening doors
[D1 10:53:37 elevator_2] Opened doors
[D1 10:53:37 citizen_30] Left elevator_2, arrived at floor 5
[D1 10:53:49 elevator_2] Closing doors
[D1 10:53:52 elevator_2] Closed doors
[D1 10:53:52 elevator_2] Changing direction to Down
[D1 10:54:02 elevator_2] At floor 4
[D1 10:54:12 elevator_2] At floor 3
[D1 10:54:12 elevator_2] Stopped at floor 3
[D1 10:54:12 elevator_2] Opening doors
[D1 10:54:15 citizen_75] Entered the building, will visit 3 floors in total
[D1 10:54:15 citizen_75] Time to go to floor 1 and stay there for 00:32:43
[D1 10:54:15 floor_0] citizen_75 entered the queue
[D1 10:54:15 floor_0] citizen_75 found an empty queue and will be served immediately
[D1 10:54:15 elevator_1] Summoned to floor 0 from floor 0
[D1 10:54:15 elevator_1] Opening doors
[D1 10:54:15 elevator_2] Opened doors
[D1 10:54:15 citizen_45] Entered elevator_2, going to floor 5
[D1 10:54:15 floor_3] citizen_45 is leaving the queue
[D1 10:54:15 floor_3] citizen_62 was served
[D1 10:54:15 elevator_2] Summoned to floor 3 from floor 3
[D1 10:54:15 citizen_62] Entered elevator_2, going to floor 1
[D1 10:54:15 floor_3] citizen_62 is leaving the queue
[D1 10:54:15 floor_3] The queue is now empty
[D1 10:54:18 elevator_1] Opened doors
[D1 10:54:18 citizen_75] Entered elevator_1, going to floor 1
[D1 10:54:18 floor_0] citizen_75 is leaving the queue
[D1 10:54:18 floor_0] The queue is now empty
[D1 10:54:27 elevator_2] Closing doors
[D1 10:54:30 elevator_1] Closing doors
[D1 10:54:30 elevator_2] Closed doors
[D1 10:54:33 citizen_42] Time to go to floor 2 and stay there for 00:21:44
[D1 10:54:33 floor_3] citizen_42 entered the queue
[D1 10:54:33 floor_3] citizen_42 found an empty queue and will be served immediately
[D1 10:54:33 elevator_2] Summoned to floor 3 from floor 3
[D1 10:54:33 elevator_1] Closed doors
[D1 10:54:33 elevator_1] Sprung into motion, heading Up
[D1 10:54:40 elevator_2] At floor 2
[D1 10:54:40 elevator_2] Stopped at floor 2
[D1 10:54:40 elevator_2] Opening doors
[D1 10:54:43 elevator_1] At floor 1
[D1 10:54:43 elevator_1] Stopped at floor 1
[D1 10:54:43 elevator_1] Opening doors
[D1 10:54:43 elevator_2] Opened doors
[D1 10:54:43 citizen_24] Cannot enter elevator_2, it is full
[D1 10:54:43 citizen_24] All elevators were full, trying to summon them again
[D1 10:54:46 elevator_1] Opened doors
[D1 10:54:46 citizen_75] Left elevator_1, arrived at floor 1
[D1 10:54:47 citizen_41] Time to go to floor 4 and stay there for 00:32:31
[D1 10:54:47 floor_2] citizen_41 entered the queue
[D1 10:54:47 floor_2] citizen_41 is queued along with 0 other arrivals in front of it
[D1 10:54:48 citizen_28] Time to go to floor 1 and stay there for 00:26:58
[D1 10:54:48 floor_4] citizen_28 entered the queue
[D1 10:54:48 floor_4] citizen_28 found an empty queue and will be served immediately
[D1 10:54:48 elevator_2] Summoned to floor 4 from floor 2
[D1 10:54:55 elevator_2] Closing doors
[D1 10:54:55 citizen_43] Time to go to floor 5 and stay there for 00:39:41
[D1 10:54:55 floor_2] citizen_43 entered the queue
[D1 10:54:55 floor_2] citizen_43 is queued along with 1 other arrivals in front of it
[D1 10:54:58 elevator_1] Closing doors
[D1 10:54:58 elevator_2] Closed doors
[D1 10:54:59 elevator_2] Summoned to floor 2 from floor 2
[D1 10:55:01 elevator_1] Closed doors
[D1 10:55:01 elevator_1] Resting at floor 1
[D1 10:55:08 elevator_2] At floor 1
[D1 10:55:08 elevator_2] Stopped at floor 1
[D1 10:55:08 elevator_2] Opening doors
[D1 10:55:11 elevator_2] Opened doors
[D1 10:55:11 citizen_50] Left elevator_2, arrived at floor 1
[D1 10:55:11 citizen_62] Left elevator_2, arrived at floor 1
[D1 10:55:11 citizen_2] Entered elevator_2, going to floor 3
[D1 10:55:11 floor_1] citizen_2 is leaving the queue
[D1 10:55:11 floor_1] The queue is now empty
[D1 10:55:23 elevator_2] Closing doors
[D1 10:55:26 elevator_2] Closed doors
[D1 10:55:32 citizen_34] Time to go to floor 3 and stay there for 00:29:15
[D1 10:55:32 floor_2] citizen_34 entered the queue
[D1 10:55:32 floor_2] citizen_34 is queued along with 2 other arrivals in front of it
[D1 10:55:36 elevator_2] At floor 0
[D1 10:55:36 elevator_2] Stopped at floor 0
[D1 10:55:36 elevator_2] Opening doors
[D1 10:55:39 elevator_2] Opened doors
[D1 10:55:39 citizen_7] Left elevator_2, arrived at floor 0
[D1 10:55:39 citizen_7] Left the building
[D1 10:55:50 citizen_76] Entered the building, will visit 4 floors in total
[D1 10:55:50 citizen_76] Time to go to floor 5 and stay there for 00:27:03
[D1 10:55:50 floor_0] citizen_76 entered the queue
[D1 10:55:50 floor_0] citizen_76 found an empty queue and will be served immediately
[D1 10:55:50 elevator_2] Summoned to floor 0 from floor 0
[D1 10:55:50 citizen_76] Entered elevator_2, going to floor 5
[D1 10:55:50 floor_0] citizen_76 is leaving the queue
[D1 10:55:50 floor_0] The queue is now empty
[D1 10:55:51 elevator_2] Closing doors
[D1 10:55:54 elevator_2] Closed doors
[D1 10:55:54 elevator_2] Changing direction to Up
[D1 10:56:04 elevator_2] At floor 1
[D1 10:56:14 elevator_2] At floor 2
[D1 10:56:14 elevator_2] Stopped at floor 2
[D1 10:56:14 elevator_2] Opening doors
[D1 10:56:17 elevator_2] Opened doors
[D1 10:56:17 citizen_24] Entered elevator_2, going to floor 0
[D1 10:56:17 floor_2] citizen_24 is leaving the queue
[D1 10:56:17 floor_2] citizen_41 was served
[D1 10:56:17 elevator_2] Summoned to floor 2 from floor 2
[D1 10:56:17 citizen_41] Cannot enter elevator_2, it is full
[D1 10:56:17 citizen_41] All elevators were full, trying to summon them again
[D1 10:56:29 elevator_2] Closing doors
[D1 10:56:32 elevator_2] Closed doors
[D1 10:56:33 elevator_2] Summoned to floor 2 from floor 2
[D1 10:56:42 elevator_2] At floor 3
[D1 10:56:42 elevator_2] Stopped at floor 3
[D1 10:56:42 elevator_2] Opening doors
[D1 10:56:45 elevator_2] Opened doors
[D1 10:56:45 citizen_2] Left elevator_2, arrived at floor 3
[D1 10:56:45 citizen_42] Entered elevator_2, going to floor 2
[D1 10:56:45 floor_3] citizen_42 is leaving the queue
[D1 10:56:45 floor_3] The queue is now empty
[D1 10:56:57 elevator_2] Closing doors
[D1 10:56:58 citizen_77] Entered the building, will visit 5 floors in total
[D1 10:56:58 citizen_77] Time to go to floor 3 and stay there for 00:34:07
[D1 10:56:58 floor_0] citizen_77 entered the queue
[D1 10:56:58 floor_0] citizen_77 found an empty queue and will be served immediately
[D1 10:56:58 elevator_1] Summoned to floor 0 from floor 1
[D1 10:56:58 elevator_1] Sprung into motion, heading Down
[D1 10:57:00 elevator_2] Closed doors
[D1 10:57:08 elevator_1] At floor 0
[D1 10:57:08 elevator_1] Stopped at floor 0
[D1 10:57:08 elevator_1] Opening doors
[D1 10:57:10 elevator_2] At floor 4
[D1 10:57:10 elevator_2] Stopped at floor 4
[D1 10:57:10 elevator_2] Opening doors
[D1 10:57:11 elevator_1] Opened doors
[D1 10:57:11 citizen_77] Entered elevator_1, going to floor 3
[D1 10:57:11 floor_0] citizen_77 is leaving the queue
[D1 10:57:11 floor_0] The queue is now empty
[D1 10:57:13 elevator_2] Opened doors
[D1 10:57:13 citizen_28] Cannot enter elevator_2, it is full
[D1 10:57:13 citizen_28] All elevators were full, trying to summon them again
[D1 10:57:19 citizen_18] Time to go to floor 3 and stay there for 00:34:35
[D1 10:57:19 floor_4] citizen_18 entered the queue
[D1 10:57:19 floor_4] citizen_18 is queued along with 0 other arrivals in front of it
[D1 10:57:23 elevator_1] Closing doors
[D1 10:57:25 elevator_2] Closing doors
[D1 10:57:26 elevator_1] Closed doors
[D1 10:57:26 elevator_1] Changing direction to Up
[D1 10:57:28 elevator_2] Closed doors
[D1 10:57:29 elevator_2] Summoned to floor 4 from floor 4
[D1 10:57:36 elevator_1] At floor 1
[D1 10:57:38 elevator_2] At floor 5
[D1 10:57:38 elevator_2] Stopped at floor 5
[D1 10:57:38 elevator_2] Opening doors
[D1 10:57:41 elevator_2] Opened doors
[D1 10:57:41 citizen_45] Left elevator_2, arrived at floor 5
[D1 10:57:41 citizen_76] Left elevator_2, arrived at floor 5
[D1 10:57:46 elevator_1] At floor 2
[D1 10:57:53 elevator_2] Closing doors
[D1 10:57:56 elevator_1] At floor 3
[D1 10:57:56 elevator_1] Stopped at floor 3
[D1 10:57:56 elevator_1] Opening doors
[D1 10:57:56 elevator_2] Closed doors
[D1 10:57:56 elevator_2] Changing direction to Down
[D1 10:57:59 elevator_1] Opened doors
[D1 10:57:59 citizen_77] Left elevator_1, arrived at floor 3
[D1 10:58:06 elevator_2] At floor 4
[D1 10:58:06 elevator_2] Stopped at floor 4
[D1 10:58:06 elevator_2] Opening doors
[D1 10:58:09 elevator_2] Opened doors
[D1 10:58:09 citizen_28] Entered elevator_2, going to floor 1
[D1 10:58:09 floor_4] citizen_28 is leaving the queue
[D1 10:58:09 floor_4] citizen_18 was served
[D1 10:58:09 elevator_2] Summoned to floor 4 from floor 4
[D1 10:58:09 citizen_18] Entered elevator_2, going to floor 3
[D1 10:58:09 floor_4] citizen_18 is leaving the queue
[D1 10:58:09 floor_4] The queue is now empty
[D1 10:58:11 elevator_1] Closing doors
[D1 10:58:14 elevator_1] Closed doors
[D1 10:58:14 elevator_1] Resting at floor 3
[D1 10:58:21 elevator_2] Closing doors
[D1 10:58:24 elevator_2] Closed doors
[D1 10:58:34 elevator_2] At floor 3
[D1 10:58:34 elevator_2] Stopped at floor 3
[D1 10:58:34 elevator_2] Opening doors
[D1 10:58:37 elevator_2] Opened doors
[D1 10:58:37 citizen_18] Left elevator_2, arrived at floor 3
[D1 10:58:39 citizen_36] Time to go to floor 2 and stay there for 00:22:22
[D1 10:58:39 floor_4] citizen_36 entered the queue
[D1 10:58:39 floor_4] citizen_36 found an empty queue and will be served immediately
[D1 10:58:39 elevator_1] Summoned to floor 4 from floor 3
[D1 10:58:39 elevator_1] Sprung into motion, heading Up
[D1 10:58:39 elevator_2] Summoned to floor 4 from floor 3
[D1 10:58:49 elevator_2] Closing doors
[D1 10:58:49 elevator_1] At floor 4
[D1 10:58:49 elevator_1] Stopped at floor 4
[D1 10:58:49 elevator_1] Opening doors
[D1 10:58:52 elevator_2] Closed doors
[D1 10:58:52 elevator_1] Opened doors
[D1 10:58:52 citizen_36] Entered elevator_1, going to floor 2
[D1 10:58:52 floor_4] citizen_36 is leaving the queue
[D1 10:58:52 floor_4] The queue is now empty
[D1 10:59:02 elevator_2] At floor 2
[D1 10:59:02 elevator_2] Stopped at floor 2
[D1 10:59:02 elevator_2] Opening doors
[D1 10:59:04 elevator_1] Closing doors
[D1 10:59:05 elevator_2] Opened doors
[D1 10:59:05 citizen_42] Left elevator_2, arrived at floor 2
[D1 10:59:05 citizen_41] Entered elevator_2, going to floor 4
[D1 10:59:05 floor_2] citizen_41 is leaving the queue
[D1 10:59:05 floor_2] citizen_43 was served
[D1 10:59:05 elevator_2] Summoned to floor 2 from floor 2
[D1 10:59:05 citizen_43] Entered elevator_2, going to floor 5
[D1 10:59:05 floor_2] citizen_43 is leaving the queue
[D1 10:59:05 floor_2] citizen_34 was served
[D1 10:59:05 elevator_2] Summoned to floor 2 from floor 2
[D1 10:59:05 citizen_34] Cannot enter elevator_2, it is full
[D1 10:59:05 citizen_34] All elevators were full, trying to summon them again
[D1 10:59:07 elevator_1] Closed doors
[D1 10:59:07 elevator_1] Changing direction to Down
[D1 10:59:17 elevator_2] Closing doors
[D1 10:59:17 elevator_1] At floor 3
[D1 10:59:20 elevator_2] Closed doors
[D1 10:59:21 elevator_2] Summoned to floor 2 from floor 2
[D1 10:59:27 elevator_1] At floor 2
[D1 10:59:27 elevator_1] Stopped at floor 2
[D1 10:59:27 elevator_1] Opening doors
[D1 10:59:30 elevator_2] At floor 1
[D1 10:59:30 elevator_2] Stopped at floor 1
[D1 10:59:30 elevator_2] Opening doors
[D1 10:59:30 elevator_1] Opened doors
[D1 10:59:30 citizen_36] Left elevator_1, arrived at floor 2
[D1 10:59:33 elevator_2] Opened doors
[D1 10:59:33 citizen_28] Left elevator_2, arrived at floor 1
[D1 10:59:42 elevator_1] Closing doors
[D1 10:59:45 elevator_2] Closing doors
[D1 10:59:45 elevator_1] Closed doors
[D1 10:59:45 elevator_1] Resting at floor 2
[D1 10:59:48 elevator_2] Closed doors
[D1 10:59:58 elevator_2] At floor 0
[D1 10:59:58 elevator_2] Stopped at floor 0
[D1 10:59:58 elevator_2] Opening doors
[D1 11:00:01 elevator_2] Opened doors
[D1 11:00:01 citizen_24] Left elevator_2, arrived at floor 0
[D1 11:00:01 citizen_24] Left the building
[D1 11:00:13 elevator_2] Closing doors
[D1 11:00:16 elevator_2] Closed doors
[D1 11:00:16 elevator_2] Changing direction to Up
[D1 11:00:26 elevator_2] At floor 1
[D1 11:00:32 citizen_78] Entered the building, will visit 4 floors in total
[D1 11:00:32 citizen_78] Time to go to floor 5 and stay there for 00:23:18
[D1 11:00:32 floor_0] citizen_78 entered the queue
[D1 11:00:32 floor_0] citizen_78 found an empty queue and will be served immediately
[D1 11:00:32 elevator_2] Summoned to floor 0 from floor 1
[D1 11:00:36 elevator_2] At floor 2
[D1 11:00:36 elevator_2] Stopped at floor 2
[D1 11:00:36 elevator_2] Opening doors
[D1 11:00:39 elevator_2] Opened doors
[D1 11:00:39 citizen_34] Entered elevator_2, going to floor 3
[D1 11:00:39 floor_2] citizen_34 is leaving the queue
[D1 11:00:39 floor_2] The queue is now empty
[D1 11:00:51 elevator_2] Closing doors
[D1 11:00:54 elevator_2] Closed doors
[D1 11:01:04 elevator_2] At floor 3
[D1 11:01:04 elevator_2] Stopped at floor 3
[D1 11:01:04 elevator_2] Opening doors
[D1 11:01:07 elevator_2] Opened doors
[D1 11:01:07 citizen_34] Left elevator_2, arrived at floor 3
[D1 11:01:08 citizen_60] Time to go to floor 5 and stay there for 00:28:34
[D1 11:01:08 floor_1] citizen_60 entered the queue
[D1 11:01:08 floor_1] citizen_60 found an empty queue and will be served immediately
[D1 11:01:08 elevator_1] Summoned to floor 1 from floor 2
[D1 11:01:08 elevator_1] Sprung into motion, heading Down
[D1 11:01:18 elevator_1] At floor 1
[D1 11:01:18 elevator_1] Stopped at floor 1
[D1 11:01:18 elevator_1] Opening doors
[D1 11:01:19 elevator_2] Closing doors
[D1 11:01:21 elevator_1] Opened doors
[D1 11:01:21 citizen_60] Entered elevator_1, going to floor 5
[D1 11:01:21 floor_1] citizen_60 is leaving the queue
[D1 11:01:21 floor_1] The queue is now empty
[D1 11:01:22 elevator_2] Closed doors
[D1 11:01:32 elevator_2] At floor 4
[D1 11:01:32 elevator_2] Stopped at floor 4
[D1 11:01:32 elevator_2] Opening doors
[D1 11:01:33 elevator_1] Closing doors
[D1 11:01:35 elevator_2] Opened doors
[D1 11:01:35 citizen_41] Left elevator_2, arrived at floor 4
[D1 11:01:36 elevator_1] Closed doors
[D1 11:01:36 elevator_1] Changing direction to Up
[D1 11:01:41 citizen_79] Entered the building, will visit 4 floors in total
[D1 11:01:41 citizen_79] Time to go to floor 1 and stay there for 00:33:57
[D1 11:01:41 floor_0] citizen_79 entered the queue
[D1 11:01:41 floor_0] citizen_79 is queued along with 0 other arrivals in front of it
[D1 11:01:46 elevator_1] At floor 2
[D1 11:01:47 elevator_2] Closing doors
[D1 11:01:50 citizen_46] Time to go to floor 4 and stay there for 00:16:54
[D1 11:01:50 floor_5] citizen_46 entered the queue
[D1 11:01:50 floor_5] citizen_46 found an empty queue and will be served immediately
[D1 11:01:50 elevator_2] Summoned to floor 5 from floor 4
[D1 11:01:50 elevator_2] Closed doors
[D1 11:01:56 elevator_1] At floor 3
[D1 11:02:00 elevator_2] At floor 5
[D1 11:02:00 elevator_2] Stopped at floor 5
[D1 11:02:00 elevator_2] Opening doors
[D1 11:02:03 elevator_2] Opened doors
[D1 11:02:03 citizen_43] Left elevator_2, arrived at floor 5
[D1 11:02:03 citizen_46] Entered elevator_2, going to floor 4
[D1 11:02:03 floor_5] citizen_46 is leaving the queue
[D1 11:02:03 floor_5] The queue is now empty
[D1 11:02:06 elevator_1] At floor 4
[D1 11:02:09 citizen_31] Time to go to the ground floor and leave
[D1 11:02:09 floor_4] citizen_31 entered the queue
[D1 11:02:09 floor_4] citizen_31 found an empty queue and will be served immediately
[D1 11:02:09 elevator_1] Summoned to floor 4 from floor 4
[D1 11:02:15 elevator_2] Closing doors
[D1 11:02:16 elevator_1] At floor 5
[D1 11:02:16 elevator_1] Stopped at floor 5
[D1 11:02:16 elevator_1] Opening doors
[D1 11:02:18 elevator_2] Closed doors
[D1 11:02:18 elevator_2] Changing direction to Down
[D1 11:02:19 elevator_1] Opened doors
[D1 11:02:19 citizen_60] Left elevator_1, arrived at floor 5
[D1 11:02:28 elevator_2] At floor 4
[D1 11:02:28 elevator_2] Stopped at floor 4
[D1 11:02:28 elevator_2] Opening doors
[D1 11:02:31 elevator_1] Closing doors
[D1 11:02:31 elevator_2] Opened doors
[D1 11:02:31 citizen_46] Left elevator_2, arrived at floor 4
[D1 11:02:34 citizen_14] Time to go to floor 3 and stay there for 00:25:28
[D1 11:02:34 floor_2] citizen_14 entered the queue
[D1 11:02:34 floor_2] citizen_14 found an empty queue and will be served immediately
[D1 11:02:34 elevator_2] Summoned to floor 2 from floor 4
[D1 11:02:34 elevator_1] Closed doors
[D1 11:02:34 elevator_1] Changing direction to Down
[D1 11:02:43 citizen_37] Time to go to the ground floor and leave
[D1 11:02:43 floor_5] citizen_37 entered the queue
[D1 11:02:43 floor_5] citizen_37 found an empty queue and will be served immediately
[D1 11:02:43 elevator_1] Summoned to floor 5 from floor 5
[D1 11:02:43 elevator_2] Closing doors
[D1 11:02:44 elevator_1] At floor 4
[D1 11:02:44 elevator_1] Stopped at floor 4
[D1 11:02:44 elevator_1] Opening doors
[D1 11:02:46 elevator_2] Closed doors
[D1 11:02:47 elevator_1] Opened doors
[D1 11:02:47 citizen_31] Entered elevator_1, going to floor 0
[D1 11:02:47 floor_4] citizen_31 is leaving the queue
[D1 11:02:47 floor_4] The queue is now empty
[D1 11:02:56 elevator_2] At floor 3
[D1 11:02:59 elevator_1] Closing doors
[D1 11:03:02 elevator_1] Closed doors
[D1 11:03:06 elevator_2] At floor 2
[D1 11:03:06 elevator_2] Stopped at floor 2
[D1 11:03:06 elevator_2] Opening doors
[D1 11:03:09 elevator_2] Opened doors
[D1 11:03:09 citizen_14] Entered elevator_2, going to floor 3
[D1 11:03:09 floor_2] citizen_14 is leaving the queue
[D1 11:03:09 floor_2] The queue is now empty
[D1 11:03:12 elevator_1] At floor 3
[D1 11:03:21 elevator_2] Closing doors
[D1 11:03:22 elevator_1] At floor 2
[D1 11:03:24 elevator_2] Closed doors
[D1 11:03:32 elevator_1] At floor 1
[D1 11:03:34 elevator_2] At floor 1
[D1 11:03:38 citizen_53] Time to go to floor 1 and stay there for 00:48:01
[D1 11:03:38 floor_3] citizen_53 entered the queue
[D1 11:03:38 floor_3] citizen_53 found an empty queue and will be served immediately
[D1 11:03:38 elevator_1] Summoned to floor 3 from floor 1
[D1 11:03:38 elevator_2] Summoned to floor 3 from floor 1
[D1 11:03:42 elevator_1] At floor 0
[D1 11:03:42 elevator_1] Stopped at floor 0
[D1 11:03:42 elevator_1] Opening doors
[D1 11:03:44 elevator_2] At floor 0
[D1 11:03:44 elevator_2] Stopped at floor 0
[D1 11:03:44 elevator_2] Opening doors
[D1 11:03:45 elevator_1] Opened doors
[D1 11:03:45 citizen_31] Left elevator_1, arrived at floor 0
[D1 11:03:45 citizen_31] Left the building
[D1 11:03:47 elevator_2] Opened doors
[D1 11:03:47 citizen_59] Time to go to floor 3 and stay there for 00:21:05
[D1 11:03:47 floor_4] citizen_59 entered the queue
[D1 11:03:47 floor_4] citizen_59 found an empty queue and will be served immediately
[D1 11:03:47 elevator_1] Summoned to floor 4 from floor 0
[D1 11:03:47 elevator_2] Summoned to floor 4 from floor 0
[D1 11:03:47 citizen_78] Entered elevator_2, going to floor 5
[D1 11:03:47 floor_0] citizen_78 is leaving the queue
[D1 11:03:47 floor_0] citizen_79 was served
[D1 11:03:47 elevator_1] Summoned to floor 0 from floor 0
[D1 11:03:47 elevator_2] Summoned to floor 0 from floor 0
[D1 11:03:47 citizen_79] Entered elevator_1, going to floor 1
[D1 11:03:47 floor_0] citizen_79 is leaving the queue
[D1 11:03:47 floor_0] The queue is now empty
[D1 11:03:57 elevator_1] Closing doors
[D1 11:03:59 elevator_2] Closing doors
[D1 11:04:00 elevator_1] Closed doors
[D1 11:04:00 elevator_1] Changing direction to Up
[D1 11:04:02 elevator_2] Closed doors
[D1 11:04:02 elevator_2] Changing direction to Up
[D1 11:04:10 elevator_1] At floor 1
[D1 11:04:10 elevator_1] Stopped at floor 1
[D1 11:04:10 elevator_1] Opening doors
[D1 11:04:11 citizen_47] Time to go to floor 5 and stay there for 00:33:00
[D1 11:04:11 floor_1] citizen_47 entered the queue
[D1 11:04:11 floor_1] citizen_47 found an empty queue and will be served immediately
[D1 11:04:11 elevator_1] Summoned to floor 1 from floor 1
[D1 11:04:12 elevator_2] At floor 1
[D1 11:04:13 elevator_1] Opened doors
[D1 11:04:13 citizen_79] Left elevator_1, arrived at floor 1
[D1 11:04:13 citizen_47] Entered elevator_1, going to floor 5
[D1 11:04:13 floor_1] citizen_47 is leaving the queue
[D1 11:04:13 floor_1] The queue is now empty
[D1 11:04:21 citizen_52] Time to go to floor 2 and stay there for 00:32:54
[D1 11:04:21 floor_1] citizen_52 entered the queue
[D1 11:04:21 floor_1] citizen_52 found an empty queue and will be served immediately
[D1 11:04:21 elevator_1] Summoned to floor 1 from floor 1
[D1 11:04:21 elevator_2] Summoned to floor 1 from floor 1
[D1 11:04:21 citizen_52] Entered elevator_1, going to floor 2
[D1 11:04:21 floor_1] citizen_52 is leaving the queue
[D1 11:04:21 floor_1] The queue is now empty
[D1 11:04:22 elevator_2] At floor 2
[D1 11:04:25 elevator_1] Closing doors
[D1 11:04:28 elevator_1] Closed doors
[D1 11:04:32 citizen_29] Time to go to the ground floor and leave
[D1 11:04:32 floor_5] citizen_29 entered the queue
[D1 11:04:32 floor_5] citizen_29 is queued along with 0 other arrivals in front of it
[D1 11:04:32 elevator_2] At floor 3
[D1 11:04:32 elevator_2] Stopped at floor 3
[D1 11:04:32 elevator_2] Opening doors
[D1 11:04:35 elevator_2] Opened doors
[D1 11:04:35 citizen_14] Left elevator_2, arrived at floor 3
[D1 11:04:35 citizen_53] Entered elevator_2, going to floor 1
[D1 11:04:35 floor_3] citizen_53 is leaving the queue
[D1 11:04:35 floor_3] The queue is now empty
[D1 11:04:38 elevator_1] At floor 2
[D1 11:04:38 elevator_1] Stopped at floor 2
[D1 11:04:38 elevator_1] Opening doors
[D1 11:04:41 citizen_32] Time to go to floor 5 and stay there for 00:48:32
[D1 11:04:41 floor_1] citizen_32 entered the queue
[D1 11:04:41 floor_1] citizen_32 found an empty queue and will be served immediately
[D1 11:04:41 elevator_1] Summoned to floor 1 from floor 2
[D1 11:04:41 elevator_1] Opened doors
[D1 11:04:41 citizen_52] Left elevator_1, arrived at floor 2
[D1 11:04:47 elevator_2] Closing doors
[D1 11:04:50 elevator_2] Closed doors
[D1 11:04:53 elevator_1] Closing doors
[D1 11:04:56 elevator_1] Closed doors
[D1 11:05:00 elevator_2] At floor 4
[D1 11:05:00 elevator_2] Stopped at floor 4
[D1 11:05:00 elevator_2] Opening doors
[D1 11:05:03 elevator_2] Opened doors
[D1 11:05:03 citizen_59] Entered elevator_2, going to floor 3
[D1 11:05:03 floor_4] citizen_59 is leaving the queue
[D1 11:05:03 floor_4] The queue is now empty
[D1 11:05:06 elevator_1] At floor 3
[D1 11:05:06 elevator_1] Stopped at floor 3
[D1 11:05:06 elevator_1] Opening doors
[D1 11:05:09 elevator_1] Opened doors
[D1 11:05:15 elevator_2] Closing doors
[D1 11:05:18 elevator_2] Closed doors
[D1 11:05:21 elevator_1] Closing doors
[D1 11:05:24 elevator_1] Closed doors
[D1 11:05:28 elevator_2] At floor 5
[D1 11:05:28 elevator_2] Stopped at floor 5
[D1 11:05:28 elevator_2] Opening doors
[D1 11:05:31 elevator_2] Opened doors
[D1 11:05:31 citizen_78] Left elevator_2, arrived at floor 5
[D1 11:05:34 elevator_1] At floor 4
[D1 11:05:34 elevator_1] Stopped at floor 4
[D1 11:05:34 elevator_1] Opening doors
[D1 11:05:37 citizen_66] Time to go to floor 3 and stay there for 00:24:09
[D1 11:05:37 floor_1] citizen_66 entered the queue
[D1 11:05:37 floor_1] citizen_66 is queued along with 0 other arrivals in front of it
[D1 11:05:37 elevator_1] Opened doors
[D1 11:05:38 citizen_40] Time to go to the ground floor and leave
[D1 11:05:38 floor_4] citizen_40 entered the queue
[D1 11:05:38 floor_4] citizen_40 found an empty queue and will be served immediately
[D1 11:05:38 elevator_1] Summoned to floor 4 from floor 4
[D1 11:05:38 citizen_40] Entered elevator_1, going to floor 0
[D1 11:05:38 floor_4] citizen_40 is leaving the queue
[D1 11:05:38 floor_4] The queue is now empty
[D1 11:05:39 citizen_25] Time to go to floor 2 and stay there for 00:22:20
[D1 11:05:39 floor_5] citizen_25 entered the queue
[D1 11:05:39 floor_5] citizen_25 is queued along with 1 other arrivals in front of it
[D1 11:05:43 elevator_2] Closing doors
[D1 11:05:46 elevator_2] Closed doors
[D1 11:05:46 elevator_2] Changing direction to Down
[D1 11:05:49 elevator_1] Closing doors
[D1 11:05:52 elevator_1] Closed doors
[D1 11:05:56 elevator_2] At floor 4
[D1 11:06:02 elevator_1] At floor 5
[D1 11:06:02 elevator_1] Stopped at floor 5
[D1 11:06:02 elevator_1] Opening doors
[D1 11:06:05 elevator_1] Opened doors
[D1 11:06:05 citizen_47] Left elevator_1, arrived at floor 5
[D1 11:06:05 citizen_37] Entered elevator_1, going to floor 0
[D1 11:06:05 floor_5] citizen_37 is leaving the queue
[D1 11:06:05 floor_5] citizen_29 was served
[D1 11:06:05 elevator_1] Summoned to floor 5 from floor 5
[D1 11:06:05 citizen_29] Entered elevator_1, going to floor 0
[D1 11:06:05 floor_5] citizen_29 is leaving the queue
[D1 11:06:05 floor_5] citizen_25 was served
[D1 11:06:05 elevator_1] Summoned to floor 5 from floor 5
[D1 11:06:05 citizen_25] Entered elevator_1, going to floor 2
[D1 11:06:05 floor_5] citizen_25 is leaving the queue
[D1 11:06:05 floor_5] The queue is now empty
[D1 11:06:06 elevator_2] At floor 3
[D1 11:06:06 elevator_2] Stopped at floor 3
[D1 11:06:06 elevator_2] Opening doors
[D1 11:06:09 citizen_63] Time to go to floor 5 and stay there for 00:32:56
[D1 11:06:09 floor_1] citizen_63 entered the queue
[D1 11:06:09 floor_1] citizen_63 is queued along with 1 other arrivals in front of it
[D1 11:06:09 elevator_2] Opened doors
[D1 11:06:09 citizen_59] Left elevator_2, arrived at floor 3
[D1 11:06:17 elevator_1] Closing doors
[D1 11:06:20 elevator_1] Closed doors
[D1 11:06:20 elevator_1] Changing direction to Down
[D1 11:06:21 elevator_2] Closing doors
[D1 11:06:24 elevator_2] Closed doors
[D1 11:06:30 elevator_1] At floor 4
[D1 11:06:34 elevator_2] At floor 2
[D1 11:06:40 elevator_1] At floor 3
[D1 11:06:44 elevator_2] At floor 1
[D1 11:06:44 elevator_2] Stopped at floor 1
[D1 11:06:44 elevator_2] Opening doors
[D1 11:06:47 elevator_2] Opened doors
[D1 11:06:47 citizen_53] Left elevator_2, arrived at floor 1
[D1 11:06:50 elevator_1] At floor 2
[D1 11:06:50 elevator_1] Stopped at floor 2
[D1 11:06:50 elevator_1] Opening doors
[D1 11:06:53 elevator_1] Opened doors
[D1 11:06:53 citizen_25] Left elevator_1, arrived at floor 2
[D1 11:06:59 elevator_2] Closing doors
[D1 11:07:02 elevator_2] Closed doors
[D1 11:07:02 elevator_2] Resting at floor 1
[D1 11:07:05 elevator_1] Closing doors
[D1 11:07:08 elevator_1] Closed doors
[D1 11:07:18 elevator_1] At floor 1
[D1 11:07:18 elevator_1] Stopped at floor 1
[D1 11:07:18 elevator_1] Opening doors
[D1 11:07:21 elevator_1] Opened doors
[D1 11:07:21 citizen_32] Entered elevator_1, going to floor 5
[D1 11:07:21 floor_1] citizen_32 is leaving the queue
[D1 11:07:21 floor_1] citizen_66 was served
[D1 11:07:21 elevator_1] Summoned to floor 1 from floor 1
[D1 11:07:21 elevator_2] Summoned to floor 1 from floor 1
[D1 11:07:21 elevator_2] Opening doors
[D1 11:07:21 citizen_66] Cannot enter elevator_1, it is full
[D1 11:07:24 elevator_2] Opened doors
[D1 11:07:24 citizen_66] Entered elevator_2, going to floor 3
[D1 11:07:24 floor_1] citizen_66 is leaving the queue
[D1 11:07:24 floor_1] citizen_63 was served
[D1 11:07:24 elevator_1] Summoned to floor 1 from floor 1
[D1 11:07:24 elevator_2] Summoned to floor 1 from floor 1
[D1 11:07:24 citizen_63] Cannot enter elevator_1, it is full
[D1 11:07:24 citizen_63] Entered elevator_2, going to floor 5
[D1 11:07:24 floor_1] citizen_63 is leaving the queue
[D1 11:07:24 floor_1] The queue is now empty
[D1 11:07:33 elevator_1] Closing doors
[D1 11:07:34 citizen_49] Time to go to the ground floor and leave
[D1 11:07:34 floor_1] citizen_49 entered the queue
[D1 11:07:34 floor_1] citizen_49 found an empty queue and will be served immediately
[D1 11:07:34 elevator_1] Summoned to floor 1 from floor 1
[D1 11:07:34 elevator_2] Summoned to floor 1 from floor 1
[D1 11:07:34 citizen_49] Entered elevator_2, going to floor 0
[D1 11:07:34 floor_1] citizen_49 is leaving the queue
[D1 11:07:34 floor_1] The queue is now empty
[D1 11:07:36 elevator_2] Closing doors
[D1 11:07:36 elevator_1] Reopening doors
[D1 11:07:36 citizen_80] Entered the building, will visit 5 floors in total
[D1 11:07:36 citizen_80] Time to go to floor 2 and stay there for 00:46:17
[D1 11:07:36 floor_0] citizen_80 entered the queue
[D1 11:07:36 floor_0] citizen_80 found an empty queue and will be served immediately
[D1 11:07:36 elevator_1] Summoned to floor 0 from floor 1
[D1 11:07:36 elevator_2] Summoned to floor 0 from floor 1
[D1 11:07:39 elevator_2] Closed doors
[D1 11:07:39 elevator_2] Sprung into motion, heading Up
[D1 11:07:48 elevator_1] Closing doors
[D1 11:07:49 elevator_2] At floor 2
[D1 11:07:51 elevator_1] Closed doors
[D1 11:07:59 elevator_2] At floor 3
[D1 11:07:59 elevator_2] Stopped at floor 3
[D1 11:07:59 elevator_2] Opening doors
[D1 11:08:01 elevator_1] At floor 0
[D1 11:08:01 elevator_1] Stopped at floor 0
[D1 11:08:01 elevator_1] Opening doors
[D1 11:08:02 elevator_2] Opened doors
[D1 11:08:02 citizen_66] Left elevator_2, arrived at floor 3
[D1 11:08:04 elevator_1] Opened doors
[D1 11:08:04 citizen_40] Left elevator_1, arrived at floor 0
[D1 11:08:04 citizen_37] Left elevator_1, arrived at floor 0
[D1 11:08:04 citizen_29] Left elevator_1, arrived at floor 0
[D1 11:08:04 citizen_40] Left the building
[D1 11:08:04 citizen_37] Left the building
[D1 11:08:04 citizen_29] Left the building
[D1 11:08:04 citizen_80] Entered elevator_1, going to floor 2
[D1 11:08:04 floor_0] citizen_80 is leaving the queue
[D1 11:08:04 floor_0] The queue is now empty
[D1 11:08:09 citizen_51] Time to go to floor 5 and stay there for 00:36:46
[D1 11:08:09 floor_4] citizen_51 entered the queue
[D1 11:08:09 floor_4] citizen_51 found an empty queue and will be served immediately
[D1 11:08:09 elevator_2] Summoned to floor 4 from floor 3
[D1 11:08:14 elevator_2] Closing doors
[D1 11:08:16 elevator_1] Closing doors
[D1 11:08:17 elevator_2] Closed doors
[D1 11:08:19 elevator_1] Closed doors
[D1 11:08:19 elevator_1] Changing direction to Up
[D1 11:08:27 elevator_2] At floor 4
[D1 11:08:27 elevator_2] Stopped at floor 4
[D1 11:08:27 elevator_2] Opening doors
[D1 11:08:28 citizen_38] Time to go to floor 3 and stay there for 00:35:50
[D1 11:08:28 floor_5] citizen_38 entered the queue
[D1 11:08:28 floor_5] citizen_38 found an empty queue and will be served immediately
[D1 11:08:28 elevator_2] Summoned to floor 5 from floor 4
[D1 11:08:29 elevator_1] At floor 1
[D1 11:08:30 elevator_2] Opened doors
[D1 11:08:30 citizen_51] Entered elevator_2, going to floor 5
[D1 11:08:30 floor_4] citizen_51 is leaving the queue
[D1 11:08:30 floor_4] The queue is now empty
[D1 11:08:39 elevator_1] At floor 2
[D1 11:08:39 elevator_1] Stopped at floor 2
[D1 11:08:39 elevator_1] Opening doors
[D1 11:08:42 elevator_2] Closing doors
[D1 11:08:42 elevator_1] Opened doors
[D1 11:08:42 citizen_80] Left elevator_1, arrived at floor 2
[D1 11:08:45 elevator_2] Closed doors
[D1 11:08:54 elevator_1] Closing doors
[D1 11:08:55 elevator_2] At floor 5
[D1 11:08:55 elevator_2] Stopped at floor 5
[D1 11:08:55 elevator_2] Opening doors
[D1 11:08:56 citizen_44] Time to go to floor 2 and stay there for 00:22:15
[D1 11:08:56 floor_3] citizen_44 entered the queue
[D1 11:08:56 floor_3] citizen_44 found an empty queue and will be served immediately
[D1 11:08:56 elevator_1] Summoned to floor 3 from floor 2
[D1 11:08:57 elevator_1] Closed doors
[D1 11:08:58 elevator_2] Opened doors
[D1 11:08:58 citizen_63] Left elevator_2, arrived at floor 5
[D1 11:08:58 citizen_51] Left elevator_2, arrived at floor 5
[D1 11:08:58 citizen_38] Entered elevator_2, going to floor 3
[D1 11:08:58 floor_5] citizen_38 is leaving the queue
[D1 11:08:58 floor_5] The queue is now empty
[D1 11:09:00 citizen_64] Time to go to floor 5 and stay there for 00:27:19
[D1 11:09:00 floor_2] citizen_64 entered the queue
[D1 11:09:00 floor_2] citizen_64 found an empty queue and will be served immediately
[D1 11:09:00 elevator_1] Summoned to floor 2 from floor 2
[D1 11:09:06 citizen_68] Time to go to floor 5 and stay there for 00:26:53
[D1 11:09:06 floor_4] citizen_68 entered the queue
[D1 11:09:06 floor_4] citizen_68 found an empty queue and will be served immediately
[D1 11:09:06 elevator_2] Summoned to floor 4 from floor 5
[D1 11:09:07 elevator_1] At floor 3
[D1 11:09:07 elevator_1] Stopped at floor 3
[D1 11:09:07 elevator_1] Opening doors
[D1 11:09:10 elevator_2] Closing doors
[D1 11:09:10 elevator_1] Opened doors
[D1 11:09:10 citizen_44] Entered elevator_1, going to floor 2
[D1 11:09:10 floor_3] citizen_44 is leaving the queue
[D1 11:09:10 floor_3] The queue is now empty
[D1 11:09:13 elevator_2] Closed doors
[D1 11:09:13 elevator_2] Changing direction to Down
[D1 11:09:22 elevator_1] Closing doors
[D1 11:09:23 elevator_2] At floor 4
[D1 11:09:23 elevator_2] Stopped at floor 4
[D1 11:09:23 elevator_2] Opening doors
[D1 11:09:25 elevator_1] Closed doors
[D1 11:09:26 elevator_2] Opened doors
[D1 11:09:26 citizen_68] Entered elevator_2, going to floor 5
[D1 11:09:26 floor_4] citizen_68 is leaving the queue
[D1 11:09:26 floor_4] The queue is now empty
[D1 11:09:35 elevator_1] At floor 4
[D1 11:09:38 elevator_2] Closing doors
[D1 11:09:41 elevator_2] Closed doors
[D1 11:09:45 elevator_1] At floor 5
[D1 11:09:45 elevator_1] Stopped at floor 5
[D1 11:09:45 elevator_1] Opening doors
[D1 11:09:48 elevator_1] Opened doors
[D1 11:09:48 citizen_32] Left elevator_1, arrived at floor 5
[D1 11:09:51 elevator_2] At floor 3
[D1 11:09:51 elevator_2] Stopped at floor 3
[D1 11:09:51 elevator_2] Opening doors
[D1 11:09:54 elevator_2] Opened doors
[D1 11:09:54 citizen_38] Left elevator_2, arrived at floor 3
[D1 11:10:00 elevator_1] Closing doors
[D1 11:10:03 elevator_1] Closed doors
[D1 11:10:03 elevator_1] Changing direction to Down
[D1 11:10:05 citizen_21] Time to go to floor 2 and stay there for 00:33:14
[D1 11:10:05 floor_5] citizen_21 entered the queue
[D1 11:10:05 floor_5] citizen_21 found an empty queue and will be served immediately
[D1 11:10:05 elevator_1] Summoned to floor 5 from floor 5
[D1 11:10:06 elevator_2] Closing doors
[D1 11:10:09 elevator_2] Closed doors
[D1 11:10:13 elevator_1] At floor 4
[D1 11:10:19 elevator_2] At floor 2
[D1 11:10:23 elevator_1] At floor 3
[D1 11:10:28 citizen_81] Entered the building, will visit 4 floors in total
[D1 11:10:28 citizen_81] Time to go to floor 1 and stay there for 00:39:40
[D1 11:10:28 floor_0] citizen_81 entered the queue
[D1 11:10:28 floor_0] citizen_81 found an empty queue and will be served immediately
[D1 11:10:28 elevator_2] Summoned to floor 0 from floor 2
[D1 11:10:29 elevator_2] At floor 1
[D1 11:10:33 elevator_1] At floor 2
[D1 11:10:33 elevator_1] Stopped at floor 2
[D1 11:10:33 elevator_1] Opening doors
[D1 11:10:36 elevator_1] Opened doors
[D1 11:10:36 citizen_44] Left elevator_1, arrived at floor 2
[D1 11:10:36 citizen_64] Entered elevator_1, going to floor 5
[D1 11:10:36 floor_2] citizen_64 is leaving the queue
[D1 11:10:36 floor_2] The queue is now empty
[D1 11:10:39 elevator_2] At floor 0
[D1 11:10:39 elevator_2] Stopped at floor 0
[D1 11:10:39 elevator_2] Opening doors
[D1 11:10:42 elevator_2] Opened doors
[D1 11:10:42 citizen_49] Left elevator_2, arrived at floor 0
[D1 11:10:42 citizen_49] Left the building
[D1 11:10:42 citizen_81] Entered elevator_2, going to floor 1
[D1 11:10:42 floor_0] citizen_81 is leaving the queue
[D1 11:10:42 floor_0] The queue is now empty
[D1 11:10:48 elevator_1] Closing doors
[D1 11:10:51 elevator_1] Closed doors
[D1 11:10:51 elevator_1] Changing direction to Up
[D1 11:10:54 elevator_2] Closing doors
[D1 11:10:57 elevator_2] Closed doors
[D1 11:10:57 elevator_2] Changing direction to Up
[D1 11:11:01 elevator_1] At floor 3
[D1 11:11:07 elevator_2] At floor 1
[D1 11:11:07 elevator_2] Stopped at floor 1
[D1 11:11:07 elevator_2] Opening doors
[D1 11:11:10 elevator_2] Opened doors
[D1 11:11:10 citizen_81] Left elevator_2, arrived at floor 1
[D1 11:11:11 citizen_67] Time to go to floor 2 and stay there for 00:27:35
[D1 11:11:11 floor_5] citizen_67 entered the queue
[D1 11:11:11 floor_5] citizen_67 is queued along with 0 other arrivals in front of it
[D1 11:11:11 elevator_1] At floor 4
[D1 11:11:21 elevator_1] At floor 5
[D1 11:11:21 elevator_1] Stopped at floor 5
[D1 11:11:21 elevator_1] Opening doors
[D1 11:11:22 elevator_2] Closing doors
[D1 11:11:24 elevator_1] Opened doors
[D1 11:11:24 citizen_64] Left elevator_1, arrived at floor 5
[D1 11:11:24 citizen_21] Entered elevator_1, going to floor 2
[D1 11:11:24 floor_5] citizen_21 is leaving the queue
[D1 11:11:24 floor_5] citizen_67 was served
[D1 11:11:24 elevator_1] Summoned to floor 5 from floor 5
[D1 11:11:24 citizen_67] Entered elevator_1, going to floor 2
[D1 11:11:24 floor_5] citizen_67 is leaving the queue
[D1 11:11:24 floor_5] The queue is now empty
[D1 11:11:25 elevator_2] Closed doors
[D1 11:11:35 elevator_2] At floor 2
[D1 11:11:36 elevator_1] Closing doors
[D1 11:11:39 elevator_1] Closed doors
[D1 11:11:39 elevator_1] Changing direction to Down
[D1 11:11:45 elevator_2] At floor 3
[D1 11:11:49 elevator_1] At floor 4
[D1 11:11:52 citizen_56] Time to go to floor 1 and stay there for 00:23:32
[D1 11:11:52 floor_2] citizen_56 entered the queue
[D1 11:11:52 floor_2] citizen_56 found an empty queue and will be served immediately
[D1 11:11:52 elevator_2] Summoned to floor 2 from floor 3
[D1 11:11:53 citizen_82] Entered the building, will visit 4 floors in total
[D1 11:11:53 citizen_82] Time to go to floor 3 and stay there for 00:21:13
[D1 11:11:53 floor_0] citizen_82 entered the queue
[D1 11:11:53 floor_0] citizen_82 found an empty queue and will be served immediately
[D1 11:11:53 elevator_2] Summoned to floor 0 from floor 3
[D1 11:11:55 elevator_2] At floor 4
[D1 11:11:59 elevator_1] At floor 3
[D1 11:12:05 citizen_39] Time to go to floor 1 and stay there for 00:30:26
[D1 11:12:05 floor_5] citizen_39 entered the queue
[D1 11:12:05 floor_5] citizen_39 found an empty queue and will be served immediately
[D1 11:12:05 elevator_2] Summoned to floor 5 from floor 4
[D1 11:12:05 elevator_2] At floor 5
[D1 11:12:05 elevator_2] Stopped at floor 5
[D1 11:12:05 elevator_2] Opening doors
[D1 11:12:08 elevator_2] Opened doors
[D1 11:12:08 citizen_68] Left elevator_2, arrived at floor 5
[D1 11:12:08 citizen_39] Entered elevator_2, going to floor 1
[D1 11:12:08 floor_5] citizen_39 is leaving the queue
[D1 11:12:08 floor_5] The queue is now empty
[D1 11:12:09 elevator_1] At floor 2
[D1 11:12:09 elevator_1] Stopped at floor 2
[D1 11:12:09 elevator_1] Opening doors
[D1 11:12:12 elevator_1] Opened doors
[D1 11:12:12 citizen_21] Left elevator_1, arrived at floor 2
[D1 11:12:12 citizen_67] Left elevator_1, arrived at floor 2
[D1 11:12:20 elevator_2] Closing doors
[D1 11:12:23 citizen_73] Time to go to floor 5 and stay there for 00:30:36
[D1 11:12:23 floor_4] citizen_73 entered the queue
[D1 11:12:23 floor_4] citizen_73 found an empty queue and will be served immediately
[D1 11:12:23 elevator_2] Summoned to floor 4 from floor 5
[D1 11:12:23 elevator_2] Closed doors
[D1 11:12:23 elevator_2] Changing direction to Down
[D1 11:12:24 elevator_1] Closing doors
[D1 11:12:26 citizen_72] Time to go to floor 4 and stay there for 00:31:20
[D1 11:12:26 floor_1] citizen_72 entered the queue
[D1 11:12:26 floor_1] citizen_72 found an empty queue and will be served immediately
[D1 11:12:26 elevator_1] Summoned to floor 1 from floor 2
[D1 11:12:27 elevator_1] Closed doors
[D1 11:12:33 elevator_2] At floor 4
[D1 11:12:33 elevator_2] Stopped at floor 4
[D1 11:12:33 elevator_2] Opening doors
[D1 11:12:36 elevator_2] Opened doors
[D1 11:12:36 citizen_73] Entered elevator_2, going to floor 5
[D1 11:12:36 floor_4] citizen_73 is leaving the queue
[D1 11:12:36 floor_4] The queue is now empty
[D1 11:12:37 elevator_1] At floor 1
[D1 11:12:37 elevator_1] Stopped at floor 1
[D1 11:12:37 elevator_1] Opening doors
[D1 11:12:40 elevator_1] Opened doors
[D1 11:12:40 citizen_72] Entered elevator_1, going to floor 4
[D1 11:12:40 floor_1] citizen_72 is leaving the queue
[D1 11:12:40 floor_1] The queue is now empty
[D1 11:12:48 elevator_2] Closing doors
[D1 11:12:51 elevator_2] Closed doors
[D1 11:12:52 elevator_1] Closing doors
[D1 11:12:55 elevator_1] Closed doors
[D1 11:12:55 elevator_1] Changing direction to Up
[D1 11:13:01 elevator_2] At floor 3
[D1 11:13:04 citizen_83] Entered the building, will visit 4 floors in total
[D1 11:13:04 citizen_83] Time to go to floor 5 and stay there for 00:32:17
[D1 11:13:04 floor_0] citizen_83 entered the queue
[D1 11:13:04 floor_0] citizen_83 is queued along with 0 other arrivals in front of it
[D1 11:13:05 elevator_1] At floor 2
[D1 11:13:11 elevator_2] At floor 2
[D1 11:13:11 elevator_2] Stopped at floor 2
[D1 11:13:11 elevator_2] Opening doors
[D1 11:13:14 elevator_2] Opened doors
[D1 11:13:14 citizen_56] Entered elevator_2, going to floor 1
[D1 11:13:14 floor_2] citizen_56 is leaving the queue
[D1 11:13:14 floor_2] The queue is now empty
[D1 11:13:15 elevator_1] At floor 3
[D1 11:13:25 elevator_1] At floor 4
[D1 11:13:25 elevator_1] Stopped at floor 4
[D1 11:13:25 elevator_1] Opening doors
[D1 11:13:26 elevator_2] Closing doors
[D1 11:13:28 elevator_1] Opened doors
[D1 11:13:28 citizen_72] Left elevator_1, arrived at floor 4
[D1 11:13:29 elevator_2] Closed doors
[D1 11:13:39 elevator_2] At floor 1
[D1 11:13:39 elevator_2] Stopped at floor 1
[D1 11:13:39 elevator_2] Opening doors
[D1 11:13:40 elevator_1] Closing doors
[D1 11:13:42 elevator_2] Opened doors
[D1 11:13:42 citizen_39] Left elevator_2, arrived at floor 1
[D1 11:13:42 citizen_56] Left elevator_2, arrived at floor 1
[D1 11:13:43 elevator_1] Closed doors
[D1 11:13:43 elevator_1] Resting at floor 4
[D1 11:13:54 elevator_2] Closing doors
[D1 11:13:57 elevator_2] Closed doors
[D1 11:14:07 elevator_2] At floor 0
[D1 11:14:07 elevator_2] Stopped at floor 0
[D1 11:14:07 elevator_2] Opening doors
[D1 11:14:10 elevator_2] Opened doors
[D1 11:14:10 citizen_82] Entered elevator_2, going to floor 3
[D1 11:14:10 floor_0] citizen_82 is leaving the queue
[D1 11:14:10 floor_0] citizen_83 was served
[D1 11:14:10 elevator_2] Summoned to floor 0 from floor 0
[D1 11:14:10 citizen_83] Entered elevator_2, going to floor 5
[D1 11:14:10 floor_0] citizen_83 is leaving the queue
[D1 11:14:10 floor_0] The queue is now empty
[D1 11:14:15 citizen_69] Time to go to floor 1 and stay there for 00:33:56
[D1 11:14:15 floor_3] citizen_69 entered the queue
[D1 11:14:15 floor_3] citizen_69 found an empty queue and will be served immediately
[D1 11:14:15 elevator_1] Summoned to floor 3 from floor 4
[D1 11:14:15 elevator_1] Sprung into motion, heading Down
[D1 11:14:22 elevator_2] Closing doors
[D1 11:14:25 elevator_1] At floor 3
[D1 11:14:25 elevator_1] Stopped at floor 3
[D1 11:14:25 elevator_1] Opening doors
[D1 11:14:25 elevator_2] Closed doors
[D1 11:14:25 elevator_2] Changing direction to Up
[D1 11:14:28 elevator_1] Opened doors
[D1 11:14:28 citizen_69] Entered elevator_1, going to floor 1
[D1 11:14:28 floor_3] citizen_69 is leaving the queue
[D1 11:14:28 floor_3] The queue is now empty
[D1 11:14:33 citizen_62] Time to go to floor 4 and stay there for 00:34:32
[D1 11:14:33 floor_1] citizen_62 entered the queue
[D1 11:14:33 floor_1] citizen_62 found an empty queue and will be served immediately
[D1 11:14:33 elevator_2] Summoned to floor 1 from floor 0
[D1 11:14:35 elevator_2] At floor 1
[D1 11:14:35 elevator_2] Stopped at floor 1
[D1 11:14:35 elevator_2] Opening doors
[D1 11:14:38 elevator_2] Opened doors
[D1 11:14:38 citizen_62] Entered elevator_2, going to floor 4
[D1 11:14:38 floor_1] citizen_62 is leaving the queue
[D1 11:14:38 floor_1] The queue is now empty
[D1 11:14:40 elevator_1] Closing doors
[D1 11:14:43 elevator_1] Closed doors
[D1 11:14:50 elevator_2] Closing doors
[D1 11:14:53 elevator_1] At floor 2
[D1 11:14:53 elevator_2] Closed doors
[D1 11:15:00 citizen_54] Time to go to floor 4 and stay there for 00:28:32
[D1 11:15:00 floor_1] citizen_54 entered the queue
[D1 11:15:00 floor_1] citizen_54 found an empty queue and will be served immediately
[D1 11:15:00 elevator_2] Summoned to floor 1 from floor 1
[D1 11:15:03 elevator_1] At floor 1
[D1 11:15:03 elevator_1] Stopped at floor 1
[D1 11:15:03 elevator_1] Opening doors
[D1 11:15:03 elevator_2] At floor 2
[D1 11:15:06 elevator_1] Opened doors
[D1 11:15:06 citizen_69] Left elevator_1, arrived at floor 1
[D1 11:15:13 elevator_2] At floor 3
[D1 11:15:13 elevator_2] Stopped at floor 3
[D1 11:15:13 elevator_2] Opening doors
[D1 11:15:16 elevator_2] Opened doors
[D1 11:15:16 citizen_82] Left elevator_2, arrived at floor 3
[D1 11:15:17 citizen_65] Time to go to the ground floor and leave
[D1 11:15:17 floor_3] citizen_65 entered the queue
[D1 11:15:17 floor_3] citizen_65 found an empty queue and will be served immediately
[D1 11:15:17 elevator_2] Summoned to floor 3 from floor 3
[D1 11:15:17 citizen_65] Entered elevator_2, going to floor 0
[D1 11:15:17 floor_3] citizen_65 is leaving the queue
[D1 11:15:17 floor_3] The queue is now empty
[D1 11:15:18 elevator_1] Closing doors
[D1 11:15:21 elevator_1] Closed doors
[D1 11:15:21 elevator_1] Resting at floor 1
[D1 11:15:28 elevator_2] Closing doors
[D1 11:15:31 elevator_2] Closed doors
[D1 11:15:41 elevator_2] At floor 4
[D1 11:15:41 elevator_2] Stopped at floor 4
[D1 11:15:41 elevator_2] Opening doors
[D1 11:15:44 elevator_2] Opened doors
[D1 11:15:44 citizen_62] Left elevator_2, arrived at floor 4
[D1 11:15:56 elevator_2] Closing doors
[D1 11:15:59 elevator_2] Closed doors
[D1 11:16:09 elevator_2] At floor 5
[D1 11:16:09 elevator_2] Stopped at floor 5
[D1 11:16:09 elevator_2] Opening doors
[D1 11:16:12 elevator_2] Opened doors
[D1 11:16:12 citizen_73] Left elevator_2, arrived at floor 5
[D1 11:16:12 citizen_83] Left elevator_2, arrived at floor 5
[D1 11:16:24 elevator_2] Closing doors
[D1 11:16:27 elevator_2] Closed doors
[D1 11:16:27 elevator_2] Changing direction to Down
[D1 11:16:37 elevator_2] At floor 4
[D1 11:16:47 elevator_2] At floor 3
[D1 11:16:57 elevator_2] At floor 2
[D1 11:17:07 elevator_2] At floor 1
[D1 11:17:07 elevator_2] Stopped at floor 1
[D1 11:17:07 elevator_2] Opening doors
[D1 11:17:10 elevator_2] Opened doors
[D1 11:17:10 citizen_54] Entered elevator_2, going to floor 4
[D1 11:17:10 floor_1] citizen_54 is leaving the queue
[D1 11:17:10 floor_1] The queue is now empty
[D1 11:17:22 elevator_2] Closing doors
[D1 11:17:25 elevator_2] Closed doors
[D1 11:17:35 elevator_2] At floor 0
[D1 11:17:35 elevator_2] Stopped at floor 0
[D1 11:17:35 elevator_2] Opening doors
[D1 11:17:38 elevator_2] Opened doors
[D1 11:17:38 citizen_65] Left elevator_2, arrived at floor 0
[D1 11:17:38 citizen_65] Left the building
[D1 11:17:50 elevator_2] Closing doors
[D1 11:17:53 elevator_2] Closed doors
[D1 11:17:53 elevator_2] Changing direction to Up
[D1 11:18:03 elevator_2] At floor 1
[D1 11:18:09 citizen_58] Time to go to the ground floor and leave
[D1 11:18:09 floor_3] citizen_58 entered the queue
[D1 11:18:09 floor_3] citizen_58 found an empty queue and will be served immediately
[D1 11:18:09 elevator_1] Summoned to floor 3 from floor 1
[D1 11:18:09 elevator_1] Sprung into motion, heading Up
[D1 11:18:09 elevator_2] Summoned to floor 3 from floor 1
[D1 11:18:13 elevator_2] At floor 2
[D1 11:18:19 elevator_1] At floor 2
[D1 11:18:23 elevator_2] At floor 3
[D1 11:18:23 elevator_2] Stopped at floor 3
[D1 11:18:23 elevator_2] Opening doors
[D1 11:18:26 elevator_2] Opened doors
[D1 11:18:26 citizen_58] Entered elevator_2, going to floor 0
[D1 11:18:26 floor_3] citizen_58 is leaving the queue
[D1 11:18:26 floor_3] The queue is now empty
[D1 11:18:29 elevator_1] At floor 3
[D1 11:18:29 elevator_1] Stopped at floor 3
[D1 11:18:29 elevator_1] Opening doors
[D1 11:18:32 elevator_1] Opened doors
[D1 11:18:38 elevator_2] Closing doors
[D1 11:18:41 elevator_2] Closed doors
[D1 11:18:44 elevator_1] Closing doors
[D1 11:18:47 elevator_1] Closed doors
[D1 11:18:47 elevator_1] Resting at floor 3
[D1 11:18:51 elevator_2] At floor 4
[D1 11:18:51 elevator_2] Stopped at floor 4
[D1 11:18:51 elevator_2] Opening doors
[D1 11:18:54 elevator_2] Opened doors
[D1 11:18:54 citizen_54] Left elevator_2, arrived at floor 4
[D1 11:18:58 citizen_61] Time to go to floor 3 and stay there for 00:29:50
[D1 11:18:58 floor_5] citizen_61 entered the queue
[D1 11:18:58 floor_5] citizen_61 found an empty queue and will be served immediately
[D1 11:18:58 elevator_2] Summoned to floor 5 from floor 4
[D1 11:19:06 elevator_2] Closing doors
[D1 11:19:09 elevator_2] Closed doors
[D1 11:19:16 citizen_74] Time to go to floor 5 and stay there for 00:40:59
[D1 11:19:16 floor_1] citizen_74 entered the queue
[D1 11:19:16 floor_1] citizen_74 found an empty queue and will be served immediately
[D1 11:19:16 elevator_1] Summoned to floor 1 from floor 3
[D1 11:19:16 elevator_1] Sprung into motion, heading Down
[D1 11:19:19 elevator_2] At floor 5
[D1 11:19:19 elevator_2] Stopped at floor 5
[D1 11:19:19 elevator_2] Opening doors
[D1 11:19:22 elevator_2] Opened doors
[D1 11:19:22 citizen_61] Entered elevator_2, going to floor 3
[D1 11:19:22 floor_5] citizen_61 is leaving the queue
[D1 11:19:22 floor_5] The queue is now empty
[D1 11:19:25 citizen_46] Time to go to floor 1 and stay there for 00:31:36
[D1 11:19:25 floor_4] citizen_46 entered the queue
[D1 11:19:25 floor_4] citizen_46 found an empty queue and will be served immediately
[D1 11:19:25 elevator_1] Summoned to floor 4 from floor 3
[D1 11:19:25 elevator_2] Summoned to floor 4 from floor 5
[D1 11:19:26 elevator_1] At floor 2
[D1 11:19:34 elevator_2] Closing doors
[D1 11:19:36 elevator_1] At floor 1
[D1 11:19:36 elevator_1] Stopped at floor 1
[D1 11:19:36 elevator_1] Opening doors
[D1 11:19:37 elevator_2] Closed doors
[D1 11:19:37 elevator_2] Changing direction to Down
[D1 11:19:39 elevator_1] Opened doors
[D1 11:19:39 citizen_74] Entered elevator_1, going to floor 5
[D1 11:19:39 floor_1] citizen_74 is leaving the queue
[D1 11:19:39 floor_1] The queue is now empty
[D1 11:19:47 elevator_2] At floor 4
[D1 11:19:47 elevator_2] Stopped at floor 4
[D1 11:19:47 elevator_2] Opening doors
[D1 11:19:50 elevator_2] Opened doors
[D1 11:19:50 citizen_46] Entered elevator_2, going to floor 1
[D1 11:19:50 floor_4] citizen_46 is leaving the queue
[D1 11:19:50 floor_4] The queue is now empty
[D1 11:19:51 elevator_1] Closing doors
[D1 11:19:54 elevator_1] Closed doors
[D1 11:19:54 elevator_1] Changing direction to Up
[D1 11:20:02 elevator_2] Closing doors
[D1 11:20:04 elevator_1] At floor 2
[D1 11:20:05 elevator_2] Closed doors
[D1 11:20:14 elevator_1] At floor 3
[D1 11:20:15 elevator_2] At floor 3
[D1 11:20:15 elevator_2] Stopped at floor 3
[D1 11:20:15 elevator_2] Opening doors
[D1 11:20:18 elevator_2] Opened doors
[D1 11:20:18 citizen_61] Left elevator_2, arrived at floor 3
[D1 11:20:22 citizen_2] Time to go to the ground floor and leave
[D1 11:20:22 floor_3] citizen_2 entered the queue
[D1 11:20:22 floor_3] citizen_2 found an empty queue and will be served immediately
[D1 11:20:22 elevator_1] Summoned to floor 3 from floor 3
[D1 11:20:22 elevator_2] Summoned to floor 3 from floor 3
[D1 11:20:22 citizen_2] Entered elevator_2, going to floor 0
[D1 11:20:22 floor_3] citizen_2 is leaving the queue
[D1 11:20:22 floor_3] The queue is now empty
[D1 11:20:24 elevator_1] At floor 4
[D1 11:20:24 elevator_1] Stopped at floor 4
[D1 11:20:24 elevator_1] Opening doors
[D1 11:20:27 elevator_1] Opened doors
[D1 11:20:30 elevator_2] Closing doors
[D1 11:20:33 elevator_2] Closed doors
[D1 11:20:39 elevator_1] Closing doors
[D1 11:20:42 elevator_1] Closed doors
[D1 11:20:43 elevator_2] At floor 2
[D1 11:20:49 citizen_42] Time to go to the ground floor and leave
[D1 11:20:49 floor_2] citizen_42 entered the queue
[D1 11:20:49 floor_2] citizen_42 found an empty queue and will be served immediately
[D1 11:20:49 elevator_2] Summoned to floor 2 from floor 2
[D1 11:20:52 elevator_1] At floor 5
[D1 11:20:52 elevator_1] Stopped at floor 5
[D1 11:20:52 elevator_1] Opening doors
[D1 11:20:53 elevator_2] At floor 1
[D1 11:20:53 elevator_2] Stopped at floor 1
[D1 11:20:53 elevator_2] Opening doors
[D1 11:20:55 elevator_1] Opened doors
[D1 11:20:55 citizen_74] Left elevator_1, arrived at floor 5
[D1 11:20:56 elevator_2] Opened doors
[D1 11:20:56 citizen_46] Left elevator_2, arrived at floor 1
[D1 11:21:04 citizen_84] Entered the building, will visit 5 floors in total
[D1 11:21:04 citizen_84] Time to go to floor 2 and stay there for 00:21:26
[D1 11:21:04 floor_0] citizen_84 entered the queue
[D1 11:21:04 floor_0] citizen_84 found an empty queue and will be served immediately
[D1 11:21:04 elevator_2] Summoned to floor 0 from floor 1
[D1 11:21:07 elevator_1] Closing doors
[D1 11:21:08 elevator_2] Closing doors
[D1 11:21:10 elevator_1] Closed doors
[D1 11:21:10 elevator_1] Changing direction to Down
[D1 11:21:11 citizen_48] Time to go to floor 1 and stay there for 00:28:01
[D1 11:21:11 floor_2] citizen_48 entered the queue
[D1 11:21:11 floor_2] citizen_48 is queued along with 0 other arrivals in front of it
[D1 11:21:11 elevator_2] Closed doors
[D1 11:21:20 elevator_1] At floor 4
[D1 11:21:21 elevator_2] At floor 0
[D1 11:21:21 elevator_2] Stopped at floor 0
[D1 11:21:21 elevator_2] Opening doors
[D1 11:21:24 elevator_2] Opened doors
[D1 11:21:24 citizen_58] Left elevator_2, arrived at floor 0
[D1 11:21:24 citizen_2] Left elevator_2, arrived at floor 0
[D1 11:21:24 citizen_58] Left the building
[D1 11:21:24 citizen_2] Left the building
[D1 11:21:24 citizen_84] Entered elevator_2, going to floor 2
[D1 11:21:24 floor_0] citizen_84 is leaving the queue
[D1 11:21:24 floor_0] The queue is now empty
[D1 11:21:30 elevator_1] At floor 3
[D1 11:21:30 elevator_1] Stopped at floor 3
[D1 11:21:30 elevator_1] Opening doors
[D1 11:21:33 elevator_1] Opened doors
[D1 11:21:36 elevator_2] Closing doors
[D1 11:21:39 elevator_2] Closed doors
[D1 11:21:39 elevator_2] Changing direction to Up
[D1 11:21:45 elevator_1] Closing doors
[D1 11:21:48 elevator_1] Closed doors
[D1 11:21:48 elevator_1] Resting at floor 3
[D1 11:21:49 elevator_2] At floor 1
[D1 11:21:52 citizen_36] Time to go to floor 4 and stay there for 00:32:34
[D1 11:21:52 floor_2] citizen_36 entered the queue
[D1 11:21:52 floor_2] citizen_36 is queued along with 1 other arrivals in front of it
[D1 11:21:59 elevator_2] At floor 2
[D1 11:21:59 elevator_2] Stopped at floor 2
[D1 11:21:59 elevator_2] Opening doors
[D1 11:22:02 elevator_2] Opened doors
[D1 11:22:02 citizen_84] Left elevator_2, arrived at floor 2
[D1 11:22:02 citizen_42] Entered elevator_2, going to floor 0
[D1 11:22:02 floor_2] citizen_42 is leaving the queue
[D1 11:22:02 floor_2] citizen_48 was served
[D1 11:22:02 elevator_2] Summoned to floor 2 from floor 2
[D1 11:22:02 citizen_48] Entered elevator_2, going to floor 1
[D1 11:22:02 floor_2] citizen_48 is leaving the queue
[D1 11:22:02 floor_2] citizen_36 was served
[D1 11:22:02 elevator_2] Summoned to floor 2 from floor 2
[D1 11:22:02 citizen_36] Entered elevator_2, going to floor 4
[D1 11:22:02 floor_2] citizen_36 is leaving the queue
[D1 11:22:02 floor_2] The queue is now empty
[D1 11:22:14 elevator_2] Closing doors
[D1 11:22:17 elevator_2] Closed doors
[D1 11:22:27 elevator_2] At floor 3
[D1 11:22:37 elevator_2] At floor 4
[D1 11:22:37 elevator_2] Stopped at floor 4
[D1 11:22:37 elevator_2] Opening doors
[D1 11:22:40 elevator_2] Opened doors
[D1 11:22:40 citizen_36] Left elevator_2, arrived at floor 4
[D1 11:22:52 elevator_2] Closing doors
[D1 11:22:55 elevator_2] Closed doors
[D1 11:22:55 elevator_2] Changing direction to Down
[D1 11:23:05 elevator_2] At floor 3
[D1 11:23:14 citizen_85] Entered the building, will visit 3 floors in total
[D1 11:23:14 citizen_85] Time to go to floor 1 and stay there for 00:38:43
[D1 11:23:14 floor_0] citizen_85 entered the queue
[D1 11:23:14 floor_0] citizen_85 found an empty queue and will be served immediately
[D1 11:23:14 elevator_1] Summoned to floor 0 from floor 3
[D1 11:23:14 elevator_1] Sprung into motion, heading Down
[D1 11:23:14 elevator_2] Summoned to floor 0 from floor 3
[D1 11:23:15 elevator_2] At floor 2
[D1 11:23:24 elevator_1] At floor 2
[D1 11:23:25 elevator_2] At floor 1
[D1 11:23:25 elevator_2] Stopped at floor 1
[D1 11:23:25 elevator_2] Opening doors
[D1 11:23:28 elevator_2] Opened doors
[D1 11:23:28 citizen_48] Left elevator_2, arrived at floor 1
[D1 11:23:34 elevator_1] At floor 1
[D1 11:23:40 elevator_2] Closing doors
[D1 11:23:43 elevator_2] Closed doors
[D1 11:23:44 elevator_1] At floor 0
[D1 11:23:44 elevator_1] Stopped at floor 0
[D1 11:23:44 elevator_1] Opening doors
[D1 11:23:47 elevator_1] Opened doors
[D1 11:23:47 citizen_85] Entered elevator_1, going to floor 1
[D1 11:23:47 floor_0] citizen_85 is leaving the queue
[D1 11:23:47 floor_0] The queue is now empty
[D1 11:23:50 citizen_30] Time to go to floor 4 and stay there for 00:18:00
[D1 11:23:50 floor_5] citizen_30 entered the queue
[D1 11:23:50 floor_5] citizen_30 found an empty queue and will be served immediately
[D1 11:23:50 elevator_2] Summoned to floor 5 from floor 1
[D1 11:23:53 elevator_2] At floor 0
[D1 11:23:53 elevator_2] Stopped at floor 0
[D1 11:23:53 elevator_2] Opening doors
[D1 11:23:56 elevator_2] Opened doors
[D1 11:23:56 citizen_42] Left elevator_2, arrived at floor 0
[D1 11:23:56 citizen_42] Left the building
[D1 11:23:59 elevator_1] Closing doors
[D1 11:24:02 elevator_1] Closed doors
[D1 11:24:02 elevator_1] Changing direction to Up
[D1 11:24:08 elevator_2] Closing doors
[D1 11:24:11 elevator_2] Closed doors
[D1 11:24:11 elevator_2] Changing direction to Up
[D1 11:24:12 elevator_1] At floor 1
[D1 11:24:12 elevator_1] Stopped at floor 1
[D1 11:24:12 elevator_1] Opening doors
[D1 11:24:15 elevator_1] Opened doors
[D1 11:24:15 citizen_85] Left elevator_1, arrived at floor 1
[D1 11:24:21 elevator_2] At floor 1
[D1 11:24:27 elevator_1] Closing doors
[D1 11:24:30 elevator_1] Closed doors
[D1 11:24:30 elevator_1] Resting at floor 1
[D1 11:24:31 elevator_2] At floor 2
[D1 11:24:41 elevator_2] At floor 3
[D1 11:24:44 citizen_76] Time to go to floor 3 and stay there for 00:33:10
[D1 11:24:44 floor_5] citizen_76 entered the queue
[D1 11:24:44 floor_5] citizen_76 is queued along with 0 other arrivals in front of it
[D1 11:24:51 elevator_2] At floor 4
[D1 11:25:01 elevator_2] At floor 5
[D1 11:25:01 elevator_2] Stopped at floor 5
[D1 11:25:01 elevator_2] Opening doors
[D1 11:25:04 elevator_2] Opened doors
[D1 11:25:04 citizen_30] Entered elevator_2, going to floor 4
[D1 11:25:04 floor_5] citizen_30 is leaving the queue
[D1 11:25:04 floor_5] citizen_76 was served
[D1 11:25:04 elevator_2] Summoned to floor 5 from floor 5
[D1 11:25:04 citizen_76] Entered elevator_2, going to floor 3
[D1 11:25:04 floor_5] citizen_76 is leaving the queue
[D1 11:25:04 floor_5] The queue is now empty
[D1 11:25:16 elevator_2] Closing doors
[D1 11:25:19 elevator_2] Closed doors
[D1 11:25:19 elevator_2] Changing direction to Down
[D1 11:25:29 citizen_86] Entered the building, will visit 4 floors in total
[D1 11:25:29 citizen_86] Time to go to floor 1 and stay there for 00:25:41
[D1 11:25:29 floor_0] citizen_86 entered the queue
[D1 11:25:29 floor_0] citizen_86 found an empty queue and will be served immediately
[D1 11:25:29 elevator_1] Summoned to floor 0 from floor 1
[D1 11:25:29 elevator_1] Sprung into motion, heading Down
[D1 11:25:29 elevator_2] At floor 4
[D1 11:25:29 elevator_2] Stopped at floor 4
[D1 11:25:29 elevator_2] Opening doors
[D1 11:25:32 elevator_2] Opened doors
[D1 11:25:32 citizen_30] Left elevator_2, arrived at floor 4
[D1 11:25:39 elevator_1] At floor 0
[D1 11:25:39 elevator_1] Stopped at floor 0
[D1 11:25:39 elevator_1] Opening doors
[D1 11:25:42 elevator_1] Opened doors
[D1 11:25:42 citizen_86] Entered elevator_1, going to floor 1
[D1 11:25:42 floor_0] citizen_86 is leaving the queue
[D1 11:25:42 floor_0] The queue is now empty
[D1 11:25:44 elevator_2] Closing doors
[D1 11:25:47 elevator_2] Closed doors
[D1 11:25:54 elevator_1] Closing doors
[D1 11:25:57 elevator_2] At floor 3
[D1 11:25:57 elevator_2] Stopped at floor 3
[D1 11:25:57 elevator_2] Opening doors
[D1 11:25:57 elevator_1] Closed doors
[D1 11:25:57 elevator_1] Changing direction to Up
[D1 11:26:00 elevator_2] Opened doors
[D1 11:26:00 citizen_76] Left elevator_2, arrived at floor 3
[D1 11:26:07 elevator_1] At floor 1
[D1 11:26:07 elevator_1] Stopped at floor 1
[D1 11:26:07 elevator_1] Opening doors
[D1 11:26:10 elevator_1] Opened doors
[D1 11:26:10 citizen_86] Left elevator_1, arrived at floor 1
[D1 11:26:12 elevator_2] Closing doors
[D1 11:26:15 elevator_2] Closed doors
[D1 11:26:15 elevator_2] Resting at floor 3
[D1 11:26:22 elevator_1] Closing doors
[D1 11:26:25 elevator_1] Closed doors
[D1 11:26:25 elevator_1] Resting at floor 1
[D1 11:26:31 citizen_28] Time to go to floor 5 and stay there for 00:22:43
[D1 11:26:31 floor_1] citizen_28 entered the queue
[D1 11:26:31 floor_1] citizen_28 found an empty queue and will be served immediately
[D1 11:26:31 elevator_1] Summoned to floor 1 from floor 1
[D1 11:26:31 elevator_1] Opening doors
[D1 11:26:34 elevator_1] Opened doors
[D1 11:26:34 citizen_28] Entered elevator_1, going to floor 5
[D1 11:26:34 floor_1] citizen_28 is leaving the queue
[D1 11:26:34 floor_1] The queue is now empty
[D1 11:26:46 elevator_1] Closing doors
[D1 11:26:49 elevator_1] Closed doors
[D1 11:26:49 elevator_1] Sprung into motion, heading Up
[D1 11:26:59 elevator_1] At floor 2
[D1 11:27:03 citizen_87] Entered the building, will visit 2 floors in total
[D1 11:27:03 citizen_87] Time to go to floor 2 and stay there for 00:29:11
[D1 11:27:03 floor_0] citizen_87 entered the queue
[D1 11:27:03 floor_0] citizen_87 found an empty queue and will be served immediately
[D1 11:27:03 elevator_1] Summoned to floor 0 from floor 2
[D1 11:27:09 elevator_1] At floor 3
[D1 11:27:13 citizen_70] Time to go to floor 1 and stay there for 00:36:13
[D1 11:27:13 floor_5] citizen_70 entered the queue
[D1 11:27:13 floor_5] citizen_70 found an empty queue and will be served immediately
[D1 11:27:13 elevator_1] Summoned to floor 5 from floor 3
[D1 11:27:13 elevator_2] Summoned to floor 5 from floor 3
[D1 11:27:13 elevator_2] Sprung into motion, heading Up
[D1 11:27:14 citizen_59] Time to go to the ground floor and leave
[D1 11:27:14 floor_3] citizen_59 entered the queue
[D1 11:27:14 floor_3] citizen_59 found an empty queue and will be served immediately
[D1 11:27:14 elevator_1] Summoned to floor 3 from floor 3
[D1 11:27:14 elevator_2] Summoned to floor 3 from floor 3
[D1 11:27:17 citizen_55] Time to go to floor 1 and stay there for 00:27:13
[D1 11:27:17 floor_4] citizen_55 entered the queue
[D1 11:27:17 floor_4] citizen_55 found an empty queue and will be served immediately
[D1 11:27:17 elevator_1] Summoned to floor 4 from floor 3
[D1 11:27:17 elevator_2] Summoned to floor 4 from floor 3
[D1 11:27:19 elevator_1] At floor 4
[D1 11:27:19 elevator_1] Stopped at floor 4
[D1 11:27:19 elevator_1] Opening doors
[D1 11:27:22 elevator_1] Opened doors
[D1 11:27:22 citizen_55] Entered elevator_1, going to floor 1
[D1 11:27:22 floor_4] citizen_55 is leaving the queue
[D1 11:27:22 floor_4] The queue is now empty
[D1 11:27:23 elevator_2] At floor 4
[D1 11:27:23 elevator_2] Stopped at floor 4
[D1 11:27:23 elevator_2] Opening doors
[D1 11:27:26 elevator_2] Opened doors
[D1 11:27:29 citizen_75] Time to go to floor 4 and stay there for 00:21:02
[D1 11:27:29 floor_1] citizen_75 entered the queue
[D1 11:27:29 floor_1] citizen_75 found an empty queue and will be served immediately
[D1 11:27:29 elevator_1] Summoned to floor 1 from floor 4
[D1 11:27:29 elevator_2] Summoned to floor 1 from floor 4
[D1 11:27:34 elevator_1] Closing doors
[D1 11:27:37 elevator_1] Closed doors
[D1 11:27:38 elevator_2] Closing doors
[D1 11:27:41 elevator_2] Closed doors
[D1 11:27:47 elevator_1] At floor 5
[D1 11:27:47 elevator_1] Stopped at floor 5
[D1 11:27:47 elevator_1] Opening doors
[D1 11:27:50 elevator_1] Opened doors
[D1 11:27:50 citizen_28] Left elevator_1, arrived at floor 5
[D1 11:27:50 citizen_70] Entered elevator_1, going to floor 1
[D1 11:27:50 floor_5] citizen_70 is leaving the queue
[D1 11:27:50 floor_5] The queue is now empty
[D1 11:27:51 elevator_2] At floor 5
[D1 11:27:51 elevator_2] Stopped at floor 5
[D1 11:27:51 elevator_2] Opening doors
[D1 11:27:54 elevator_2] Opened doors
[D1 11:28:02 citizen_57] Time to go to floor 5 and stay there for 00:37:35
[D1 11:28:02 floor_4] citizen_57 entered the queue
[D1 11:28:02 floor_4] citizen_57 found an empty queue and will be served immediately
[D1 11:28:02 elevator_1] Summoned to floor 4 from floor 5
[D1 11:28:02 elevator_2] Summoned to floor 4 from floor 5
[D1 11:28:02 elevator_1] Closing doors
[D1 11:28:05 elevator_1] Closed doors
[D1 11:28:05 elevator_1] Changing direction to Down
[D1 11:28:06 elevator_2] Closing doors
[D1 11:28:09 elevator_2] Closed doors
[D1 11:28:09 elevator_2] Changing direction to Down
[D1 11:28:15 elevator_1] At floor 4
[D1 11:28:15 elevator_1] Stopped at floor 4
[D1 11:28:15 elevator_1] Opening doors
[D1 11:28:18 elevator_1] Opened doors
[D1 11:28:18 citizen_57] Entered elevator_1, going to floor 5
[D1 11:28:18 floor_4] citizen_57 is leaving the queue
[D1 11:28:18 floor_4] The queue is now empty
[D1 11:28:19 elevator_2] At floor 4
[D1 11:28:19 elevator_2] Stopped at floor 4
[D1 11:28:19 elevator_2] Opening doors
[D1 11:28:22 elevator_2] Opened doors
[D1 11:28:27 citizen_71] Time to go to floor 1 and stay there for 00:36:41
[D1 11:28:27 floor_5] citizen_71 entered the queue
[D1 11:28:27 floor_5] citizen_71 found an empty queue and will be served immediately
[D1 11:28:27 elevator_1] Summoned to floor 5 from floor 4
[D1 11:28:27 elevator_2] Summoned to floor 5 from floor 4
[D1 11:28:30 elevator_1] Closing doors
[D1 11:28:33 elevator_1] Closed doors
[D1 11:28:34 elevator_2] Closing doors
[D1 11:28:37 elevator_2] Closed doors
[D1 11:28:43 elevator_1] At floor 3
[D1 11:28:43 elevator_1] Stopped at floor 3
[D1 11:28:43 elevator_1] Opening doors
[D1 11:28:46 elevator_1] Opened doors
[D1 11:28:46 citizen_59] Entered elevator_1, going to floor 0
[D1 11:28:46 floor_3] citizen_59 is leaving the queue
[D1 11:28:46 floor_3] The queue is now empty
[D1 11:28:47 elevator_2] At floor 3
[D1 11:28:47 elevator_2] Stopped at floor 3
[D1 11:28:47 elevator_2] Opening doors
[D1 11:28:49 citizen_78] Time to go to floor 4 and stay there for 00:29:33
[D1 11:28:49 floor_5] citizen_78 entered the queue
[D1 11:28:49 floor_5] citizen_78 is queued along with 0 other arrivals in front of it
[D1 11:28:50 elevator_2] Opened doors
[D1 11:28:58 elevator_1] Closing doors
[D1 11:29:01 elevator_1] Closed doors
[D1 11:29:02 elevator_2] Closing doors
[D1 11:29:05 elevator_2] Closed doors
[D1 11:29:07 citizen_88] Entered the building, will visit 4 floors in total
[D1 11:29:07 citizen_88] Time to go to floor 4 and stay there for 00:35:32
[D1 11:29:07 floor_0] citizen_88 entered the queue
[D1 11:29:07 floor_0] citizen_88 is queued along with 0 other arrivals in front of it
[D1 11:29:11 elevator_1] At floor 2
[D1 11:29:13 citizen_25] Time to go to the ground floor and leave
[D1 11:29:13 floor_2] citizen_25 entered the queue
[D1 11:29:13 floor_2] citizen_25 found an empty queue and will be served immediately
[D1 11:29:13 elevator_1] Summoned to floor 2 from floor 2
[D1 11:29:15 elevator_2] At floor 2
[D1 11:29:21 elevator_1] At floor 1
[D1 11:29:21 elevator_1] Stopped at floor 1
[D1 11:29:21 elevator_1] Opening doors
[D1 11:29:24 elevator_1] Opened doors
[D1 11:29:24 citizen_55] Left elevator_1, arrived at floor 1
[D1 11:29:24 citizen_70] Left elevator_1, arrived at floor 1
[D1 11:29:24 citizen_75] Entered elevator_1, going to floor 4
[D1 11:29:24 floor_1] citizen_75 is leaving the queue
[D1 11:29:24 floor_1] The queue is now empty
[D1 11:29:25 elevator_2] At floor 1
[D1 11:29:25 elevator_2] Stopped at floor 1
[D1 11:29:25 elevator_2] Opening doors
[D1 11:29:28 elevator_2] Opened doors
[D1 11:29:36 elevator_1] Closing doors
[D1 11:29:39 elevator_1] Closed doors
[D1 11:29:40 elevator_2] Closing doors
[D1 11:29:43 elevator_2] Closed doors
[D1 11:29:43 elevator_2] Changing direction to Up
[D1 11:29:49 elevator_1] At floor 0
[D1 11:29:49 elevator_1] Stopped at floor 0
[D1 11:29:49 elevator_1] Opening doors
[D1 11:29:52 elevator_1] Opened doors
[D1 11:29:52 citizen_59] Left elevator_1, arrived at floor 0
[D1 11:29:52 citizen_59] Left the building
[D1 11:29:52 citizen_87] Entered elevator_1, going to floor 2
[D1 11:29:52 floor_0] citizen_87 is leaving the queue
[D1 11:29:52 floor_0] citizen_88 was served
[D1 11:29:52 elevator_1] Summoned to floor 0 from floor 0
[D1 11:29:52 citizen_88] Entered elevator_1, going to floor 4
[D1 11:29:52 floor_0] citizen_88 is leaving the queue
[D1 11:29:52 floor_0] The queue is now empty
[D1 11:29:53 elevator_2] At floor 2
[D1 11:30:03 citizen_14] Time to go to floor 4 and stay there for 00:28:01
[D1 11:30:03 floor_3] citizen_14 entered the queue
[D1 11:30:03 floor_3] citizen_14 found an empty queue and will be served immediately
[D1 11:30:03 elevator_2] Summoned to floor 3 from floor 2
[D1 11:30:03 elevator_2] At floor 3
[D1 11:30:03 elevator_2] Stopped at floor 3
[D1 11:30:03 elevator_2] Opening doors
[D1 11:30:04 elevator_1] Closing doors
[D1 11:30:06 elevator_2] Opened doors
[D1 11:30:06 citizen_14] Entered elevator_2, going to floor 4
[D1 11:30:06 floor_3] citizen_14 is leaving the queue
[D1 11:30:06 floor_3] The queue is now empty
[D1 11:30:07 elevator_1] Closed doors
[D1 11:30:07 elevator_1] Changing direction to Up
[D1 11:30:17 elevator_1] At floor 1
[D1 11:30:18 elevator_2] Closing doors
[D1 11:30:21 elevator_2] Closed doors
[D1 11:30:22 citizen_34] Time to go to floor 5 and stay there for 00:25:10
[D1 11:30:22 floor_3] citizen_34 entered the queue
[D1 11:30:22 floor_3] citizen_34 found an empty queue and will be served immediately
[D1 11:30:22 elevator_2] Summoned to floor 3 from floor 3
[D1 11:30:27 elevator_1] At floor 2
[D1 11:30:27 elevator_1] Stopped at floor 2
[D1 11:30:27 elevator_1] Opening doors
[D1 11:30:30 elevator_1] Opened doors
[D1 11:30:30 citizen_87] Left elevator_1, arrived at floor 2
[D1 11:30:30 citizen_25] Entered elevator_1, going to floor 0
[D1 11:30:30 floor_2] citizen_25 is leaving the queue
[D1 11:30:30 floor_2] The queue is now empty
[D1 11:30:31 elevator_2] At floor 4
[D1 11:30:31 elevator_2] Stopped at floor 4
[D1 11:30:31 elevator_2] Opening doors
[D1 11:30:34 elevator_2] Opened doors
[D1 11:30:34 citizen_14] Left elevator_2, arrived at floor 4
[D1 11:30:42 elevator_1] Closing doors
[D1 11:30:45 elevator_1] Closed doors
[D1 11:30:46 elevator_2] Closing doors
[D1 11:30:49 elevator_2] Closed doors
[D1 11:30:53 citizen_60] Time to go to floor 1 and stay there for 00:25:07
[D1 11:30:53 floor_5] citizen_60 entered the queue
[D1 11:30:53 floor_5] citizen_60 is queued along with 1 other arrivals in front of it
[D1 11:30:55 elevator_1] At floor 3
[D1 11:30:59 elevator_2] At floor 5
[D1 11:30:59 elevator_2] Stopped at floor 5
[D1 11:30:59 elevator_2] Opening doors
[D1 11:31:02 elevator_2] Opened doors
[D1 11:31:02 citizen_71] Entered elevator_2, going to floor 1
[D1 11:31:02 floor_5] citizen_71 is leaving the queue
[D1 11:31:02 floor_5] citizen_78 was served
[D1 11:31:02 elevator_2] Summoned to floor 5 from floor 5
[D1 11:31:02 citizen_78] Entered elevator_2, going to floor 4
[D1 11:31:02 floor_5] citizen_78 is leaving the queue
[D1 11:31:02 floor_5] citizen_60 was served
[D1 11:31:02 elevator_2] Summoned to floor 5 from floor 5
[D1 11:31:02 citizen_60] Entered elevator_2, going to floor 1
[D1 11:31:02 floor_5] citizen_60 is leaving the queue
[D1 11:31:02 floor_5] The queue is now empty
[D1 11:31:05 elevator_1] At floor 4
[D1 11:31:05 elevator_1] Stopped at floor 4
[D1 11:31:05 elevator_1] Opening doors
[D1 11:31:08 elevator_1] Opened doors
[D1 11:31:08 citizen_75] Left elevator_1, arrived at floor 4
[D1 11:31:08 citizen_88] Left elevator_1, arrived at floor 4
[D1 11:31:14 elevator_2] Closing doors
[D1 11:31:17 elevator_2] Closed doors
[D1 11:31:17 elevator_2] Changing direction to Down
[D1 11:31:20 elevator_1] Closing doors
[D1 11:31:23 elevator_1] Closed doors
[D1 11:31:27 elevator_2] At floor 4
[D1 11:31:27 elevator_2] Stopped at floor 4
[D1 11:31:27 elevator_2] Opening doors
[D1 11:31:30 elevator_2] Opened doors
[D1 11:31:30 citizen_78] Left elevator_2, arrived at floor 4
[D1 11:31:33 elevator_1] At floor 5
[D1 11:31:33 elevator_1] Stopped at floor 5
[D1 11:31:33 elevator_1] Opening doors
[D1 11:31:36 elevator_1] Opened doors
[D1 11:31:36 citizen_57] Left elevator_1, arrived at floor 5
[D1 11:31:42 elevator_2] Closing doors
[D1 11:31:45 elevator_2] Closed doors
[D1 11:31:48 elevator_1] Closing doors
[D1 11:31:51 elevator_1] Closed doors
[D1 11:31:51 elevator_1] Changing direction to Down
[D1 11:31:55 citizen_45] Time to go to floor 3 and stay there for 00:33:43
[D1 11:31:55 floor_5] citizen_45 entered the queue
[D1 11:31:55 floor_5] citizen_45 found an empty queue and will be served immediately
[D1 11:31:55 elevator_1] Summoned to floor 5 from floor 5
[D1 11:31:55 elevator_2] At floor 3
[D1 11:31:55 elevator_2] Stopped at floor 3
[D1 11:31:55 elevator_2] Opening doors
[D1 11:31:58 elevator_2] Opened doors
[D1 11:31:58 citizen_34] Entered elevator_2, going to floor 5
[D1 11:31:58 floor_3] citizen_34 is leaving the queue
[D1 11:31:58 floor_3] The queue is now empty
[D1 11:32:01 elevator_1] At floor 4
[D1 11:32:06 citizen_77] Time to go to floor 1 and stay there for 00:36:52
[D1 11:32:06 floor_3] citizen_77 entered the queue
[D1 11:32:06 floor_3] citizen_77 found an empty queue and will be served immediately
[D1 11:32:06 elevator_2] Summoned to floor 3 from floor 3
[D1 11:32:06 citizen_77] Entered elevator_2, going to floor 1
[D1 11:32:06 floor_3] citizen_77 is leaving the queue
[D1 11:32:06 floor_3] The queue is now empty
[D1 11:32:10 elevator_2] Closing doors
[D1 11:32:11 elevator_1] At floor 3
[D1 11:32:11 citizen_66] Time to go to floor 2 and stay there for 00:33:31
[D1 11:32:11 floor_3] citizen_66 entered the queue
[D1 11:32:11 floor_3] citizen_66 found an empty queue and will be served immediately
[D1 11:32:11 elevator_1] Summoned to floor 3 from floor 3
[D1 11:32:11 elevator_2] Summoned to floor 3 from floor 3
[D1 11:32:13 elevator_2] Reopening doors
[D1 11:32:13 citizen_66] Cannot enter elevator_2, it is full
[D1 11:32:21 elevator_1] At floor 2
[D1 11:32:25 elevator_2] Closing doors
[D1 11:32:28 elevator_2] Closed doors
[D1 11:32:31 elevator_1] At floor 1
[D1 11:32:38 elevator_2] At floor 2
[D1 11:32:41 elevator_1] At floor 0
[D1 11:32:41 elevator_1] Stopped at floor 0
[D1 11:32:41 elevator_1] Opening doors
[D1 11:32:44 elevator_1] Opened doors
[D1 11:32:44 citizen_25] Left elevator_1, arrived at floor 0
[D1 11:32:44 citizen_25] Left the building
[D1 11:32:48 elevator_2] At floor 1
[D1 11:32:48 elevator_2] Stopped at floor 1
[D1 11:32:48 elevator_2] Opening doors
[D1 11:32:51 citizen_44] Time to go to floor 1 and stay there for 00:38:21
[D1 11:32:51 floor_2] citizen_44 entered the queue
[D1 11:32:51 floor_2] citizen_44 found an empty queue and will be served immediately
[D1 11:32:51 elevator_2] Summoned to floor 2 from floor 1
[D1 11:32:51 elevator_2] Opened doors
[D1 11:32:51 citizen_71] Left elevator_2, arrived at floor 1
[D1 11:32:51 citizen_60] Left elevator_2, arrived at floor 1
[D1 11:32:51 citizen_77] Left elevator_2, arrived at floor 1
[D1 11:32:56 elevator_1] Closing doors
[D1 11:32:59 elevator_1] Closed doors
[D1 11:32:59 elevator_1] Changing direction to Up
[D1 11:33:02 citizen_89] Entered the building, will visit 4 floors in total
[D1 11:33:02 citizen_89] Time to go to floor 4 and stay there for 00:29:03
[D1 11:33:02 floor_0] citizen_89 entered the queue
[D1 11:33:02 floor_0] citizen_89 found an empty queue and will be served immediately
[D1 11:33:02 elevator_1] Summoned to floor 0 from floor 0
[D1 11:33:03 elevator_2] Closing doors
[D1 11:33:06 elevator_2] Closed doors
[D1 11:33:06 elevator_2] Changing direction to Up
[D1 11:33:09 elevator_1] At floor 1
[D1 11:33:12 citizen_18] Time to go to floor 4 and stay there for 00:24:11
[D1 11:33:12 floor_3] citizen_18 entered the queue
[D1 11:33:12 floor_3] citizen_18 is queued along with 0 other arrivals in front of it
[D1 11:33:16 elevator_2] At floor 2
[D1 11:33:16 elevator_2] Stopped at floor 2
[D1 11:33:16 elevator_2] Opening doors
[D1 11:33:19 elevator_1] At floor 2
[D1 11:33:19 elevator_2] Opened doors
[D1 11:33:19 citizen_44] Entered elevator_2, going to floor 1
[D1 11:33:19 floor_2] citizen_44 is leaving the queue
[D1 11:33:19 floor_2] The queue is now empty
[D1 11:33:29 elevator_1] At floor 3
[D1 11:33:29 elevator_1] Stopped at floor 3
[D1 11:33:29 elevator_1] Opening doors
[D1 11:33:31 elevator_2] Closing doors
[D1 11:33:32 elevator_1] Opened doors
[D1 11:33:32 citizen_66] Entered elevator_1, going to floor 2
[D1 11:33:32 floor_3] citizen_66 is leaving the queue
[D1 11:33:32 floor_3] citizen_18 was served
[D1 11:33:32 elevator_1] Summoned to floor 3 from floor 3
[D1 11:33:32 citizen_18] Entered elevator_1, going to floor 4
[D1 11:33:32 floor_3] citizen_18 is leaving the queue
[D1 11:33:32 floor_3] The queue is now empty
[D1 11:33:34 elevator_2] Closed doors
[D1 11:33:44 elevator_1] Closing doors
[D1 11:33:44 elevator_2] At floor 3
[D1 11:33:47 elevator_1] Closed doors
[D1 11:33:54 elevator_2] At floor 4
[D1 11:33:57 elevator_1] At floor 4
[D1 11:33:57 elevator_1] Stopped at floor 4
[D1 11:33:57 elevator_1] Opening doors
[D1 11:34:00 elevator_1] Opened doors
[D1 11:34:00 citizen_18] Left elevator_1, arrived at floor 4
[D1 11:34:04 elevator_2] At floor 5
[D1 11:34:04 elevator_2] Stopped at floor 5
[D1 11:34:04 elevator_2] Opening doors
[D1 11:34:06 citizen_41] Time to go to floor 3 and stay there for 00:22:00
[D1 11:34:06 floor_4] citizen_41 entered the queue
[D1 11:34:06 floor_4] citizen_41 found an empty queue and will be served immediately
[D1 11:34:06 elevator_1] Summoned to floor 4 from floor 4
[D1 11:34:06 citizen_41] Entered elevator_1, going to floor 3
[D1 11:34:06 floor_4] citizen_41 is leaving the queue
[D1 11:34:06 floor_4] The queue is now empty
[D1 11:34:07 elevator_2] Opened doors
[D1 11:34:07 citizen_34] Left elevator_2, arrived at floor 5
[D1 11:34:12 elevator_1] Closing doors
[D1 11:34:15 elevator_1] Closed doors
[D1 11:34:19 elevator_2] Closing doors
[D1 11:34:22 elevator_2] Closed doors
[D1 11:34:22 elevator_2] Changing direction to Down
[D1 11:34:25 elevator_1] At floor 5
[D1 11:34:25 elevator_1] Stopped at floor 5
[D1 11:34:25 elevator_1] Opening doors
[D1 11:34:28 elevator_1] Opened doors
[D1 11:34:28 citizen_45] Entered elevator_1, going to floor 3
[D1 11:34:28 floor_5] citizen_45 is leaving the queue
[D1 11:34:28 floor_5] The queue is now empty
[D1 11:34:32 elevator_2] At floor 4
[D1 11:34:40 elevator_1] Closing doors
[D1 11:34:42 elevator_2] At floor 3
[D1 11:34:43 elevator_1] Closed doors
[D1 11:34:43 elevator_1] Changing direction to Down
[D1 11:34:52 elevator_2] At floor 2
[D1 11:34:53 elevator_1] At floor 4
[D1 11:34:54 citizen_90] Entered the building, will visit 1 floors in total
[D1 11:34:54 citizen_90] Time to go to floor 2 and stay there for 00:23:12
[D1 11:34:54 floor_0] citizen_90 entered the queue
[D1 11:34:54 floor_0] citizen_90 is queued along with 0 other arrivals in front of it
[D1 11:35:02 elevator_2] At floor 1
[D1 11:35:02 elevator_2] Stopped at floor 1
[D1 11:35:02 elevator_2] Opening doors
[D1 11:35:03 elevator_1] At floor 3
[D1 11:35:03 elevator_1] Stopped at floor 3
[D1 11:35:03 elevator_1] Opening doors
[D1 11:35:05 elevator_2] Opened doors
[D1 11:35:05 citizen_44] Left elevator_2, arrived at floor 1
[D1 11:35:06 elevator_1] Opened doors
[D1 11:35:06 citizen_41] Left elevator_1, arrived at floor 3
[D1 11:35:06 citizen_45] Left elevator_1, arrived at floor 3
[D1 11:35:17 elevator_2] Closing doors
[D1 11:35:18 elevator_1] Closing doors
[D1 11:35:20 elevator_2] Closed doors
[D1 11:35:20 elevator_2] Resting at floor 1
[D1 11:35:21 elevator_1] Closed doors
[D1 11:35:31 elevator_1] At floor 2
[D1 11:35:31 elevator_1] Stopped at floor 2
[D1 11:35:31 elevator_1] Opening doors
[D1 11:35:34 elevator_1] Opened doors
[D1 11:35:34 citizen_66] Left elevator_1, arrived at floor 2
[D1 11:35:46 elevator_1] Closing doors
[D1 11:35:49 elevator_1] Closed doors
[D1 11:35:59 elevator_1] At floor 1
[D1 11:36:09 elevator_1] At floor 0
[D1 11:36:09 elevator_1] Stopped at floor 0
[D1 11:36:09 elevator_1] Opening doors
[D1 11:36:12 elevator_1] Opened doors
[D1 11:36:12 citizen_89] Entered elevator_1, going to floor 4
[D1 11:36:12 floor_0] citizen_89 is leaving the queue
[D1 11:36:12 floor_0] citizen_90 was served
[D1 11:36:12 elevator_1] Summoned to floor 0 from floor 0
[D1 11:36:12 citizen_90] Entered elevator_1, going to floor 2
[D1 11:36:12 floor_0] citizen_90 is leaving the queue
[D1 11:36:12 floor_0] The queue is now empty
[D1 11:36:24 elevator_1] Closing doors
[D1 11:36:27 elevator_1] Closed doors
[D1 11:36:27 elevator_1] Changing direction to Up
[D1 11:36:29 citizen_82] Time to go to floor 4 and stay there for 00:44:43
[D1 11:36:29 floor_3] citizen_82 entered the queue
[D1 11:36:29 floor_3] citizen_82 found an empty queue and will be served immediately
[D1 11:36:29 elevator_2] Summoned to floor 3 from floor 1
[D1 11:36:29 elevator_2] Sprung into motion, heading Up
[D1 11:36:37 elevator_1] At floor 1
[D1 11:36:39 elevator_2] At floor 2
[D1 11:36:41 citizen_50] Time to go to floor 5 and stay there for 00:43:04
[D1 11:36:41 floor_1] citizen_50 entered the queue
[D1 11:36:41 floor_1] citizen_50 found an empty queue and will be served immediately
[D1 11:36:41 elevator_1] Summoned to floor 1 from floor 1
[D1 11:36:47 elevator_1] At floor 2
[D1 11:36:47 elevator_1] Stopped at floor 2
[D1 11:36:47 elevator_1] Opening doors
[D1 11:36:49 elevator_2] At floor 3
[D1 11:36:49 elevator_2] Stopped at floor 3
[D1 11:36:49 elevator_2] Opening doors
[D1 11:36:50 elevator_1] Opened doors
[D1 11:36:50 citizen_90] Left elevator_1, arrived at floor 2
[D1 11:36:52 elevator_2] Opened doors
[D1 11:36:52 citizen_82] Entered elevator_2, going to floor 4
[D1 11:36:52 floor_3] citizen_82 is leaving the queue
[D1 11:36:52 floor_3] The queue is now empty
[D1 11:37:01 citizen_91] Entered the building, will visit 4 floors in total
[D1 11:37:01 citizen_91] Time to go to floor 1 and stay there for 00:36:59
[D1 11:37:01 floor_0] citizen_91 entered the queue
[D1 11:37:01 floor_0] citizen_91 found an empty queue and will be served immediately
[D1 11:37:01 elevator_1] Summoned to floor 0 from floor 2
[D1 11:37:02 elevator_1] Closing doors
[D1 11:37:04 elevator_2] Closing doors
[D1 11:37:05 elevator_1] Closed doors
[D1 11:37:07 elevator_2] Closed doors
[D1 11:37:14 citizen_56] Time to go to the ground floor and leave
[D1 11:37:14 floor_1] citizen_56 entered the queue
[D1 11:37:14 floor_1] citizen_56 is queued along with 0 other arrivals in front of it
[D1 11:37:15 elevator_1] At floor 3
[D1 11:37:17 elevator_2] At floor 4
[D1 11:37:17 elevator_2] Stopped at floor 4
[D1 11:37:17 elevator_2] Opening doors
[D1 11:37:20 elevator_2] Opened doors
[D1 11:37:20 citizen_82] Left elevator_2, arrived at floor 4
[D1 11:37:25 elevator_1] At floor 4
[D1 11:37:25 elevator_1] Stopped at floor 4
[D1 11:37:25 elevator_1] Opening doors
[D1 11:37:28 elevator_1] Opened doors
[D1 11:37:28 citizen_89] Left elevator_1, arrived at floor 4
[D1 11:37:32 elevator_2] Closing doors
[D1 11:37:35 citizen_52] Time to go to floor 3 and stay there for 00:33:31
[D1 11:37:35 floor_2] citizen_52 entered the queue
[D1 11:37:35 floor_2] citizen_52 found an empty queue and will be served immediately
[D1 11:37:35 elevator_1] Summoned to floor 2 from floor 4
[D1 11:37:35 elevator_2] Summoned to floor 2 from floor 4
[D1 11:37:35 elevator_2] Closed doors
[D1 11:37:35 elevator_2] Changing direction to Down
[D1 11:37:40 elevator_1] Closing doors
[D1 11:37:43 elevator_1] Closed doors
[D1 11:37:43 elevator_1] Changing direction to Down
[D1 11:37:45 elevator_2] At floor 3
[D1 11:37:53 elevator_1] At floor 3
[D1 11:37:55 elevator_2] At floor 2
[D1 11:37:55 elevator_2] Stopped at floor 2
[D1 11:37:55 elevator_2] Opening doors
[D1 11:37:58 elevator_2] Opened doors
[D1 11:37:58 citizen_52] Entered elevator_2, going to floor 3
[D1 11:37:58 floor_2] citizen_52 is leaving the queue
[D1 11:37:58 floor_2] The queue is now empty
[D1 11:38:03 elevator_1] At floor 2
[D1 11:38:03 elevator_1] Stopped at floor 2
[D1 11:38:03 elevator_1] Opening doors
[D1 11:38:06 elevator_1] Opened doors
[D1 11:38:10 citizen_79] Time to go to floor 5 and stay there for 00:30:04
[D1 11:38:10 floor_1] citizen_79 entered the queue
[D1 11:38:10 floor_1] citizen_79 is queued along with 1 other arrivals in front of it
[D1 11:38:10 elevator_2] Closing doors
[D1 11:38:13 elevator_2] Closed doors
[D1 11:38:13 elevator_2] Changing direction to Up
[D1 11:38:18 elevator_1] Closing doors
[D1 11:38:21 elevator_1] Closed doors
[D1 11:38:23 elevator_2] At floor 3
[D1 11:38:23 elevator_2] Stopped at floor 3
[D1 11:38:23 elevator_2] Opening doors
[D1 11:38:26 elevator_2] Opened doors
[D1 11:38:26 citizen_52] Left elevator_2, arrived at floor 3
[D1 11:38:31 elevator_1] At floor 1
[D1 11:38:31 elevator_1] Stopped at floor 1
[D1 11:38:31 elevator_1] Opening doors
[D1 11:38:34 elevator_1] Opened doors
[D1 11:38:34 citizen_50] Entered elevator_1, going to floor 5
[D1 11:38:34 floor_1] citizen_50 is leaving the queue
[D1 11:38:34 floor_1] citizen_56 was served
[D1 11:38:34 elevator_1] Summoned to floor 1 from floor 1
[D1 11:38:34 citizen_56] Entered elevator_1, going to floor 0
[D1 11:38:34 floor_1] citizen_56 is leaving the queue
[D1 11:38:34 floor_1] citizen_79 was served
[D1 11:38:34 elevator_1] Summoned to floor 1 from floor 1
[D1 11:38:34 citizen_79] Entered elevator_1, going to floor 5
[D1 11:38:34 floor_1] citizen_79 is leaving the queue
[D1 11:38:34 floor_1] The queue is now empty
[D1 11:38:38 elevator_2] Closing doors
[D1 11:38:41 elevator_2] Closed doors
[D1 11:38:41 elevator_2] Resting at floor 3
[D1 11:38:43 citizen_64] Time to go to floor 3 and stay there for 00:37:38
[D1 11:38:43 floor_5] citizen_64 entered the queue
[D1 11:38:43 floor_5] citizen_64 found an empty queue and will be served immediately
[D1 11:38:43 elevator_2] Summoned to floor 5 from floor 3
[D1 11:38:43 elevator_2] Sprung into motion, heading Up
[D1 11:38:46 elevator_1] Closing doors
[D1 11:38:49 elevator_1] Closed doors
[D1 11:38:53 elevator_2] At floor 4
[D1 11:38:59 elevator_1] At floor 0
[D1 11:38:59 elevator_1] Stopped at floor 0
[D1 11:38:59 elevator_1] Opening doors
[D1 11:39:01 citizen_68] Time to go to floor 4 and stay there for 00:38:51
[D1 11:39:01 floor_5] citizen_68 entered the queue
[D1 11:39:01 floor_5] citizen_68 is queued along with 0 other arrivals in front of it
[D1 11:39:02 elevator_1] Opened doors
[D1 11:39:02 citizen_56] Left elevator_1, arrived at floor 0
[D1 11:39:02 citizen_56] Left the building
[D1 11:39:02 citizen_91] Entered elevator_1, going to floor 1
[D1 11:39:02 floor_0] citizen_91 is leaving the queue
[D1 11:39:02 floor_0] The queue is now empty
[D1 11:39:03 elevator_2] At floor 5
[D1 11:39:03 elevator_2] Stopped at floor 5
[D1 11:39:03 elevator_2] Opening doors
[D1 11:39:05 citizen_47] Time to go to the ground floor and leave
[D1 11:39:05 floor_5] citizen_47 entered the queue
[D1 11:39:05 floor_5] citizen_47 is queued along with 1 other arrivals in front of it
[D1 11:39:06 elevator_2] Opened doors
[D1 11:39:06 citizen_64] Entered elevator_2, going to floor 3
[D1 11:39:06 floor_5] citizen_64 is leaving the queue
[D1 11:39:06 floor_5] citizen_68 was served
[D1 11:39:06 elevator_2] Summoned to floor 5 from floor 5
[D1 11:39:06 citizen_68] Entered elevator_2, going to floor 4
[D1 11:39:06 floor_5] citizen_68 is leaving the queue
[D1 11:39:06 floor_5] citizen_47 was served
[D1 11:39:06 elevator_2] Summoned to floor 5 from floor 5
[D1 11:39:06 citizen_47] Entered elevator_2, going to floor 0
[D1 11:39:06 floor_5] citizen_47 is leaving the queue
[D1 11:39:06 floor_5] The queue is now empty
[D1 11:39:14 elevator_1] Closing doors
[D1 11:39:17 elevator_1] Closed doors
[D1 11:39:17 elevator_1] Changing direction to Up
[D1 11:39:18 elevator_2] Closing doors
[D1 11:39:21 elevator_2] Closed doors
[D1 11:39:21 elevator_2] Changing direction to Down
[D1 11:39:27 elevator_1] At floor 1
[D1 11:39:27 elevator_1] Stopped at floor 1
[D1 11:39:27 elevator_1] Opening doors
[D1 11:39:27 citizen_92] Entered the building, will visit 3 floors in total
[D1 11:39:27 citizen_92] Time to go to floor 2 and stay there for 00:26:44
[D1 11:39:27 floor_0] citizen_92 entered the queue
[D1 11:39:27 floor_0] citizen_92 found an empty queue and will be served immediately
[D1 11:39:27 elevator_1] Summoned to floor 0 from floor 1
[D1 11:39:30 elevator_1] Opened doors
[D1 11:39:30 citizen_91] Left elevator_1, arrived at floor 1
[D1 11:39:31 elevator_2] At floor 4
[D1 11:39:31 elevator_2] Stopped at floor 4
[D1 11:39:31 elevator_2] Opening doors
[D1 11:39:34 elevator_2] Opened doors
[D1 11:39:34 citizen_68] Left elevator_2, arrived at floor 4
[D1 11:39:42 elevator_1] Closing doors
[D1 11:39:45 elevator_1] Closed doors
[D1 11:39:46 elevator_2] Closing doors
[D1 11:39:47 citizen_67] Time to go to floor 5 and stay there for 00:43:56
[D1 11:39:47 floor_2] citizen_67 entered the queue
[D1 11:39:47 floor_2] citizen_67 found an empty queue and will be served immediately
[D1 11:39:47 elevator_1] Summoned to floor 2 from floor 1
[D1 11:39:49 elevator_2] Closed doors
[D1 11:39:55 elevator_1] At floor 2
[D1 11:39:55 elevator_1] Stopped at floor 2
[D1 11:39:55 elevator_1] Opening doors
[D1 11:39:58 elevator_1] Opened doors
[D1 11:39:58 citizen_67] Entered elevator_1, going to floor 5
[D1 11:39:58 floor_2] citizen_67 is leaving the queue
[D1 11:39:58 floor_2] The queue is now empty
[D1 11:39:59 elevator_2] At floor 3
[D1 11:39:59 elevator_2] Stopped at floor 3
[D1 11:39:59 elevator_2] Opening doors
[D1 11:40:02 elevator_2] Opened doors
[D1 11:40:02 citizen_64] Left elevator_2, arrived at floor 3
[D1 11:40:10 elevator_1] Closing doors
[D1 11:40:13 elevator_1] Closed doors
[D1 11:40:14 elevator_2] Closing doors
[D1 11:40:17 elevator_2] Closed doors
[D1 11:40:23 elevator_1] At floor 3
[D1 11:40:27 elevator_2] At floor 2
[D1 11:40:33 elevator_1] At floor 4
[D1 11:40:37 elevator_2] At floor 1
[D1 11:40:39 citizen_93] Entered the building, will visit 4 floors in total
[D1 11:40:39 citizen_93] Time to go to floor 5 and stay there for 00:42:33
[D1 11:40:39 floor_0] citizen_93 entered the queue
[D1 11:40:39 floor_0] citizen_93 is queued along with 0 other arrivals in front of it
[D1 11:40:43 elevator_1] At floor 5
[D1 11:40:43 elevator_1] Stopped at floor 5
[D1 11:40:43 elevator_1] Opening doors
[D1 11:40:46 elevator_1] Opened doors
[D1 11:40:46 citizen_50] Left elevator_1, arrived at floor 5
[D1 11:40:46 citizen_79] Left elevator_1, arrived at floor 5
[D1 11:40:46 citizen_67] Left elevator_1, arrived at floor 5
[D1 11:40:47 elevator_2] At floor 0
[D1 11:40:47 elevator_2] Stopped at floor 0
[D1 11:40:47 elevator_2] Opening doors
[D1 11:40:50 elevator_2] Opened doors
[D1 11:40:50 citizen_47] Left elevator_2, arrived at floor 0
[D1 11:40:50 citizen_47] Left the building
[D1 11:40:58 elevator_1] Closing doors
[D1 11:41:01 elevator_1] Closed doors
[D1 11:41:01 elevator_1] Changing direction to Down
[D1 11:41:02 elevator_2] Closing doors
[D1 11:41:05 elevator_2] Closed doors
[D1 11:41:05 elevator_2] Resting at floor 0
[D1 11:41:11 elevator_1] At floor 4
[D1 11:41:21 elevator_1] At floor 3
[D1 11:41:31 elevator_1] At floor 2
[D1 11:41:41 elevator_1] At floor 1
[D1 11:41:43 citizen_94] Entered the building, will visit 3 floors in total
[D1 11:41:43 citizen_94] Time to go to floor 3 and stay there for 00:39:15
[D1 11:41:43 floor_0] citizen_94 entered the queue
[D1 11:41:43 floor_0] citizen_94 is queued along with 1 other arrivals in front of it
[D1 11:41:44 citizen_43] Time to go to floor 1 and stay there for 00:19:45
[D1 11:41:44 floor_5] citizen_43 entered the queue
[D1 11:41:44 floor_5] citizen_43 found an empty queue and will be served immediately
[D1 11:41:44 elevator_1] Summoned to floor 5 from floor 1
[D1 11:41:51 elevator_1] At floor 0
[D1 11:41:51 elevator_1] Stopped at floor 0
[D1 11:41:51 elevator_1] Opening doors
[D1 11:41:54 citizen_63] Time to go to the ground floor and leave
[D1 11:41:54 floor_5] citizen_63 entered the queue
[D1 11:41:54 floor_5] citizen_63 is queued along with 0 other arrivals in front of it
[D1 11:41:54 elevator_1] Opened doors
[D1 11:41:54 citizen_92] Entered elevator_1, going to floor 2
[D1 11:41:54 floor_0] citizen_92 is leaving the queue
[D1 11:41:54 floor_0] citizen_93 was served
[D1 11:41:54 elevator_1] Summoned to floor 0 from floor 0
[D1 11:41:54 elevator_2] Summoned to floor 0 from floor 0
[D1 11:41:54 elevator_2] Opening doors
[D1 11:41:54 citizen_93] Entered elevator_1, going to floor 5
[D1 11:41:54 floor_0] citizen_93 is leaving the queue
[D1 11:41:54 floor_0] citizen_94 was served
[D1 11:41:54 elevator_1] Summoned to floor 0 from floor 0
[D1 11:41:54 elevator_2] Summoned to floor 0 from floor 0
[D1 11:41:54 citizen_94] Entered elevator_1, going to floor 3
[D1 11:41:54 floor_0] citizen_94 is leaving the queue
[D1 11:41:54 floor_0] The queue is now empty
[D1 11:41:57 elevator_2] Opened doors
[D1 11:42:06 elevator_1] Closing doors
[D1 11:42:09 elevator_2] Closing doors
[D1 11:42:09 elevator_1] Closed doors
[D1 11:42:09 elevator_1] Changing direction to Up
[D1 11:42:12 elevator_2] Closed doors
[D1 11:42:19 elevator_1] At floor 1
[D1 11:42:29 elevator_1] At floor 2
[D1 11:42:29 elevator_1] Stopped at floor 2
[D1 11:42:29 elevator_1] Opening doors
[D1 11:42:32 elevator_1] Opened doors
[D1 11:42:32 citizen_92] Left elevator_1, arrived at floor 2
[D1 11:42:44 elevator_1] Closing doors
[D1 11:42:47 elevator_1] Closed doors
[D1 11:42:53 citizen_95] Entered the building, will visit 4 floors in total
[D1 11:42:53 citizen_95] Time to go to floor 5 and stay there for 00:37:22
[D1 11:42:53 floor_0] citizen_95 entered the queue
[D1 11:42:53 floor_0] citizen_95 found an empty queue and will be served immediately
[D1 11:42:53 elevator_2] Summoned to floor 0 from floor 0
[D1 11:42:53 elevator_2] Opening doors
[D1 11:42:56 elevator_2] Opened doors
[D1 11:42:56 citizen_95] Entered elevator_2, going to floor 5
[D1 11:42:56 floor_0] citizen_95 is leaving the queue
[D1 11:42:56 floor_0] The queue is now empty
[D1 11:42:57 elevator_1] At floor 3
[D1 11:42:57 elevator_1] Stopped at floor 3
[D1 11:42:57 elevator_1] Opening doors
[D1 11:43:00 elevator_1] Opened doors
[D1 11:43:00 citizen_94] Left elevator_1, arrived at floor 3
[D1 11:43:08 elevator_2] Closing doors
[D1 11:43:11 elevator_2] Closed doors
[D1 11:43:11 elevator_2] Sprung into motion, heading Up
[D1 11:43:12 elevator_1] Closing doors
[D1 11:43:15 elevator_1] Closed doors
[D1 11:43:21 elevator_2] At floor 1
[D1 11:43:25 elevator_1] At floor 4
[D1 11:43:28 citizen_84] Time to go to floor 5 and stay there for 00:16:59
[D1 11:43:28 floor_2] citizen_84 entered the queue
[D1 11:43:28 floor_2] citizen_84 found an empty queue and will be served immediately
[D1 11:43:28 elevator_2] Summoned to floor 2 from floor 1
[D1 11:43:31 elevator_2] At floor 2
[D1 11:43:31 elevator_2] Stopped at floor 2
[D1 11:43:31 elevator_2] Opening doors
[D1 11:43:32 citizen_30] Time to go to the ground floor and leave
[D1 11:43:32 floor_4] citizen_30 entered the queue
[D1 11:43:32 floor_4] citizen_30 found an empty queue and will be served immediately
[D1 11:43:32 elevator_1] Summoned to floor 4 from floor 4
[D1 11:43:34 elevator_2] Opened doors
[D1 11:43:34 citizen_84] Entered elevator_2, going to floor 5
[D1 11:43:34 floor_2] citizen_84 is leaving the queue
[D1 11:43:34 floor_2] The queue is now empty
[D1 11:43:35 elevator_1] At floor 5
[D1 11:43:35 elevator_1] Stopped at floor 5
[D1 11:43:35 elevator_1] Opening doors
[D1 11:43:38 elevator_1] Opened doors
[D1 11:43:38 citizen_93] Left elevator_1, arrived at floor 5
[D1 11:43:38 citizen_43] Entered elevator_1, going to floor 1
[D1 11:43:38 floor_5] citizen_43 is leaving the queue
[D1 11:43:38 floor_5] citizen_63 was served
[D1 11:43:38 elevator_1] Summoned to floor 5 from floor 5
[D1 11:43:38 citizen_63] Entered elevator_1, going to floor 0
[D1 11:43:38 floor_5] citizen_63 is leaving the queue
[D1 11:43:38 floor_5] The queue is now empty
[D1 11:43:46 elevator_2] Closing doors
[D1 11:43:49 elevator_2] Closed doors
[D1 11:43:50 elevator_1] Closing doors
[D1 11:43:53 elevator_1] Closed doors
[D1 11:43:53 elevator_1] Changing direction to Down
[D1 11:43:59 elevator_2] At floor 3
[D1 11:44:03 elevator_1] At floor 4
[D1 11:44:03 elevator_1] Stopped at floor 4
[D1 11:44:03 elevator_1] Opening doors
[D1 11:44:06 elevator_1] Opened doors
[D1 11:44:06 citizen_30] Entered elevator_1, going to floor 0
[D1 11:44:06 floor_4] citizen_30 is leaving the queue
[D1 11:44:06 floor_4] The queue is now empty
[D1 11:44:08 citizen_39] Time to go to the ground floor and leave
[D1 11:44:08 floor_1] citizen_39 entered the queue
[D1 11:44:08 floor_1] citizen_39 found an empty queue and will be served immediately
[D1 11:44:08 elevator_2] Summoned to floor 1 from floor 3
[D1 11:44:09 elevator_2] At floor 4
[D1 11:44:15 citizen_96] Entered the building, will visit 4 floors in total
[D1 11:44:15 citizen_96] Time to go to floor 4 and stay there for 00:28:23
[D1 11:44:15 floor_0] citizen_96 entered the queue
[D1 11:44:15 floor_0] citizen_96 found an empty queue and will be served immediately
[D1 11:44:15 elevator_1] Summoned to floor 0 from floor 4
[D1 11:44:15 elevator_2] Summoned to floor 0 from floor 4
[D1 11:44:18 elevator_1] Closing doors
[D1 11:44:19 elevator_2] At floor 5
[D1 11:44:19 elevator_2] Stopped at floor 5
[D1 11:44:19 elevator_2] Opening doors
[D1 11:44:21 elevator_1] Closed doors
[D1 11:44:22 elevator_2] Opened doors
[D1 11:44:22 citizen_95] Left elevator_2, arrived at floor 5
[D1 11:44:22 citizen_84] Left elevator_2, arrived at floor 5
[D1 11:44:31 elevator_1] At floor 3
[D1 11:44:34 elevator_2] Closing doors
[D1 11:44:37 elevator_2] Closed doors
[D1 11:44:37 elevator_2] Changing direction to Down
[D1 11:44:41 elevator_1] At floor 2
[D1 11:44:47 elevator_2] At floor 4
[D1 11:44:48 citizen_72] Time to go to floor 2 and stay there for 00:32:46
[D1 11:44:48 floor_4] citizen_72 entered the queue
[D1 11:44:48 floor_4] citizen_72 found an empty queue and will be served immediately
[D1 11:44:48 elevator_2] Summoned to floor 4 from floor 4
[D1 11:44:51 elevator_1] At floor 1
[D1 11:44:51 elevator_1] Stopped at floor 1
[D1 11:44:51 elevator_1] Opening doors
[D1 11:44:54 elevator_1] Opened doors
[D1 11:44:54 citizen_43] Left elevator_1, arrived at floor 1
[D1 11:44:57 elevator_2] At floor 3
[D1 11:45:06 elevator_1] Closing doors
[D1 11:45:07 elevator_2] At floor 2
[D1 11:45:09 elevator_1] Closed doors
[D1 11:45:17 elevator_2] At floor 1
[D1 11:45:17 elevator_2] Stopped at floor 1
[D1 11:45:17 elevator_2] Opening doors
[D1 11:45:19 elevator_1] At floor 0
[D1 11:45:19 elevator_1] Stopped at floor 0
[D1 11:45:19 elevator_1] Opening doors
[D1 11:45:20 elevator_2] Opened doors
[D1 11:45:20 citizen_39] Entered elevator_2, going to floor 0
[D1 11:45:20 floor_1] citizen_39 is leaving the queue
[D1 11:45:20 floor_1] The queue is now empty
[D1 11:45:22 elevator_1] Opened doors
[D1 11:45:22 citizen_63] Left elevator_1, arrived at floor 0
[D1 11:45:22 citizen_30] Left elevator_1, arrived at floor 0
[D1 11:45:22 citizen_63] Left the building
[D1 11:45:22 citizen_30] Left the building
[D1 11:45:22 citizen_96] Entered elevator_1, going to floor 4
[D1 11:45:22 floor_0] citizen_96 is leaving the queue
[D1 11:45:22 floor_0] The queue is now empty
[D1 11:45:26 citizen_21] Time to go to the ground floor and leave
[D1 11:45:26 floor_2] citizen_21 entered the queue
[D1 11:45:26 floor_2] citizen_21 found an empty queue and will be served immediately
[D1 11:45:26 elevator_2] Summoned to floor 2 from floor 1
[D1 11:45:32 elevator_2] Closing doors
[D1 11:45:34 elevator_1] Closing doors
[D1 11:45:35 elevator_2] Closed doors
[D1 11:45:37 elevator_1] Closed doors
[D1 11:45:37 elevator_1] Changing direction to Up
[D1 11:45:44 citizen_38] Time to go to floor 4 and stay there for 00:31:38
[D1 11:45:44 floor_3] citizen_38 entered the queue
[D1 11:45:44 floor_3] citizen_38 found an empty queue and will be served immediately
[D1 11:45:44 elevator_2] Summoned to floor 3 from floor 1
[D1 11:45:44 citizen_51] Time to go to floor 4 and stay there for 00:27:04
[D1 11:45:44 floor_5] citizen_51 entered the queue
[D1 11:45:44 floor_5] citizen_51 found an empty queue and will be served immediately
[D1 11:45:44 elevator_2] Summoned to floor 5 from floor 1
[D1 11:45:45 elevator_2] At floor 0
[D1 11:45:45 elevator_2] Stopped at floor 0
[D1 11:45:45 elevator_2] Opening doors
[D1 11:45:47 elevator_1] At floor 1
[D1 11:45:48 elevator_2] Opened doors
[D1 11:45:48 citizen_39] Left elevator_2, arrived at floor 0
[D1 11:45:48 citizen_39] Left the building
[D1 11:45:57 elevator_1] At floor 2
[D1 11:46:00 elevator_2] Closing doors
[D1 11:46:03 elevator_2] Closed doors
[D1 11:46:03 elevator_2] Changing direction to Up
[D1 11:46:07 elevator_1] At floor 3
[D1 11:46:13 elevator_2] At floor 1
[D1 11:46:14 citizen_97] Entered the building, will visit 3 floors in total
[D1 11:46:14 citizen_97] Time to go to floor 2 and stay there for 00:20:57
[D1 11:46:14 floor_0] citizen_97 entered the queue
[D1 11:46:14 floor_0] citizen_97 found an empty queue and will be served immediately
[D1 11:46:14 elevator_2] Summoned to floor 0 from floor 1
[D1 11:46:17 elevator_1] At floor 4
[D1 11:46:17 elevator_1] Stopped at floor 4
[D1 11:46:17 elevator_1] Opening doors
[D1 11:46:20 elevator_1] Opened doors
[D1 11:46:20 citizen_96] Left elevator_1, arrived at floor 4
[D1 11:46:23 elevator_2] At floor 2
[D1 11:46:23 elevator_2] Stopped at floor 2
[D1 11:46:23 elevator_2] Opening doors
[D1 11:46:26 elevator_2] Opened doors
[D1 11:46:26 citizen_21] Entered elevator_2, going to floor 0
[D1 11:46:26 floor_2] citizen_21 is leaving the queue
[D1 11:46:26 floor_2] The queue is now empty
[D1 11:46:32 elevator_1] Closing doors
[D1 11:46:35 elevator_1] Closed doors
[D1 11:46:35 elevator_1] Resting at floor 4
[D1 11:46:38 elevator_2] Closing doors
[D1 11:46:41 elevator_2] Closed doors
[D1 11:46:48 citizen_73] Time to go to floor 2 and stay there for 00:30:01
[D1 11:46:48 floor_5] citizen_73 entered the queue
[D1 11:46:48 floor_5] citizen_73 is queued along with 0 other arrivals in front of it
[D1 11:46:51 elevator_2] At floor 3
[D1 11:46:51 elevator_2] Stopped at floor 3
[D1 11:46:51 elevator_2] Opening doors
[D1 11:46:54 elevator_2] Opened doors
[D1 11:46:54 citizen_38] Entered elevator_2, going to floor 4
[D1 11:46:54 floor_3] citizen_38 is leaving the queue
[D1 11:46:54 floor_3] The queue is now empty
[D1 11:47:06 elevator_2] Closing doors
[D1 11:47:09 elevator_2] Closed doors
[D1 11:47:19 elevator_2] At floor 4
[D1 11:47:19 elevator_2] Stopped at floor 4
[D1 11:47:19 elevator_2] Opening doors
[D1 11:47:22 elevator_2] Opened doors
[D1 11:47:22 citizen_38] Left elevator_2, arrived at floor 4
[D1 11:47:22 citizen_72] Entered elevator_2, going to floor 2
[D1 11:47:22 floor_4] citizen_72 is leaving the queue
[D1 11:47:22 floor_4] The queue is now empty
[D1 11:47:26 citizen_54] Time to go to floor 2 and stay there for 00:28:14
[D1 11:47:26 floor_4] citizen_54 entered the queue
[D1 11:47:26 floor_4] citizen_54 found an empty queue and will be served immediately
[D1 11:47:26 elevator_1] Summoned to floor 4 from floor 4
[D1 11:47:26 elevator_1] Opening doors
[D1 11:47:26 elevator_2] Summoned to floor 4 from floor 4
[D1 11:47:26 citizen_54] Entered elevator_2, going to floor 2
[D1 11:47:26 floor_4] citizen_54 is leaving the queue
[D1 11:47:26 floor_4] The queue is now empty
[D1 11:47:29 elevator_1] Opened doors
[D1 11:47:34 elevator_2] Closing doors
[D1 11:47:37 elevator_2] Closed doors
[D1 11:47:41 elevator_1] Closing doors
[D1 11:47:44 elevator_1] Closed doors
[D1 11:47:47 elevator_2] At floor 5
[D1 11:47:47 elevator_2] Stopped at floor 5
[D1 11:47:47 elevator_2] Opening doors
[D1 11:47:50 elevator_2] Opened doors
[D1 11:47:50 citizen_51] Entered elevator_2, going to floor 4
[D1 11:47:50 floor_5] citizen_51 is leaving the queue
[D1 11:47:50 floor_5] citizen_73 was served
[D1 11:47:50 elevator_2] Summoned to floor 5 from floor 5
[D1 11:47:50 citizen_73] Cannot enter elevator_2, it is full
[D1 11:47:50 citizen_73] All elevators were full, trying to summon them again
[D1 11:48:02 elevator_2] Closing doors
[D1 11:48:05 elevator_2] Closed doors
[D1 11:48:05 elevator_2] Changing direction to Down
[D1 11:48:06 elevator_2] Summoned to floor 5 from floor 5
[D1 11:48:15 elevator_2] At floor 4
[D1 11:48:15 elevator_2] Stopped at floor 4
[D1 11:48:15 elevator_2] Opening doors
[D1 11:48:18 elevator_2] Opened doors
[D1 11:48:18 citizen_51] Left elevator_2, arrived at floor 4
[D1 11:48:29 citizen_83] Time to go to floor 2 and stay there for 00:18:51
[D1 11:48:29 floor_5] citizen_83 entered the queue
[D1 11:48:29 floor_5] citizen_83 is queued along with 0 other arrivals in front of it
[D1 11:48:30 elevator_2] Closing doors
[D1 11:48:33 elevator_2] Closed doors
[D1 11:48:43 elevator_2] At floor 3
[D1 11:48:53 elevator_2] At floor 2
[D1 11:48:53 elevator_2] Stopped at floor 2
[D1 11:48:53 elevator_2] Opening doors
[D1 11:48:56 elevator_2] Opened doors
[D1 11:48:56 citizen_72] Left elevator_2, arrived at floor 2
[D1 11:48:56 citizen_54] Left elevator_2, arrived at floor 2
[D1 11:49:02 citizen_69] Time to go to floor 5 and stay there for 00:24:59
[D1 11:49:02 floor_1] citizen_69 entered the queue
[D1 11:49:02 floor_1] citizen_69 found an empty queue and will be served immediately
[D1 11:49:02 elevator_2] Summoned to floor 1 from floor 2
[D1 11:49:08 elevator_2] Closing doors
[D1 11:49:11 elevator_2] Closed doors
[D1 11:49:18 citizen_98] Entered the building, will visit 5 floors in total
[D1 11:49:18 citizen_98] Time to go to floor 3 and stay there for 00:23:34
[D1 11:49:18 floor_0] citizen_98 entered the queue
[D1 11:49:18 floor_0] citizen_98 is queued along with 0 other arrivals in front of it
[D1 11:49:21 elevator_2] At floor 1
[D1 11:49:21 elevator_2] Stopped at floor 1
[D1 11:49:21 elevator_2] Opening doors
[D1 11:49:24 elevator_2] Opened doors
[D1 11:49:24 citizen_69] Entered elevator_2, going to floor 5
[D1 11:49:24 floor_1] citizen_69 is leaving the queue
[D1 11:49:24 floor_1] The queue is now empty
[D1 11:49:36 elevator_2] Closing doors
[D1 11:49:39 elevator_2] Closed doors
[D1 11:49:49 elevator_2] At floor 0
[D1 11:49:49 elevator_2] Stopped at floor 0
[D1 11:49:49 elevator_2] Opening doors
[D1 11:49:52 elevator_2] Opened doors
[D1 11:49:52 citizen_21] Left elevator_2, arrived at floor 0
[D1 11:49:52 citizen_21] Left the building
[D1 11:49:52 citizen_97] Entered elevator_2, going to floor 2
[D1 11:49:52 floor_0] citizen_97 is leaving the queue
[D1 11:49:52 floor_0] citizen_98 was served
[D1 11:49:52 elevator_2] Summoned to floor 0 from floor 0
[D1 11:49:52 citizen_98] Entered elevator_2, going to floor 3
[D1 11:49:52 floor_0] citizen_98 is leaving the queue
[D1 11:49:52 floor_0] The queue is now empty
[D1 11:50:04 elevator_2] Closing doors
[D1 11:50:07 elevator_2] Closed doors
[D1 11:50:07 elevator_2] Changing direction to Up
[D1 11:50:08 citizen_61] Time to go to floor 5 and stay there for 00:42:25
[D1 11:50:08 floor_3] citizen_61 entered the queue
[D1 11:50:08 floor_3] citizen_61 found an empty queue and will be served immediately
[D1 11:50:08 elevator_1] Summoned to floor 3 from floor 4
[D1 11:50:08 elevator_1] Sprung into motion, heading Down
[D1 11:50:16 citizen_62] Time to go to floor 3 and stay there for 00:33:30
[D1 11:50:16 floor_4] citizen_62 entered the queue
[D1 11:50:16 floor_4] citizen_62 found an empty queue and will be served immediately
[D1 11:50:16 elevator_1] Summoned to floor 4 from floor 4
[D1 11:50:17 elevator_2] At floor 1
[D1 11:50:18 elevator_1] At floor 3
[D1 11:50:18 elevator_1] Stopped at floor 3
[D1 11:50:18 elevator_1] Opening doors
[D1 11:50:21 elevator_1] Opened doors
[D1 11:50:21 citizen_61] Entered elevator_1, going to floor 5
[D1 11:50:21 floor_3] citizen_61 is leaving the queue
[D1 11:50:21 floor_3] The queue is now empty
[D1 11:50:27 elevator_2] At floor 2
[D1 11:50:27 elevator_2] Stopped at floor 2
[D1 11:50:27 elevator_2] Opening doors
[D1 11:50:30 elevator_2] Opened doors
[D1 11:50:30 citizen_97] Left elevator_2, arrived at floor 2
[D1 11:50:33 elevator_1] Closing doors
[D1 11:50:33 citizen_28] Time to go to the ground floor and leave
[D1 11:50:33 floor_5] citizen_28 entered the queue
[D1 11:50:33 floor_5] citizen_28 is queued along with 1 other arrivals in front of it
[D1 11:50:36 elevator_1] Closed doors
[D1 11:50:36 elevator_1] Changing direction to Up
[D1 11:50:42 elevator_2] Closing doors
[D1 11:50:45 elevator_2] Closed doors
[D1 11:50:46 elevator_1] At floor 4
[D1 11:50:46 elevator_1] Stopped at floor 4
[D1 11:50:46 elevator_1] Opening doors
[D1 11:50:49 elevator_1] Opened doors
[D1 11:50:49 citizen_62] Entered elevator_1, going to floor 3
[D1 11:50:49 floor_4] citizen_62 is leaving the queue
[D1 11:50:49 floor_4] The queue is now empty
[D1 11:50:50 citizen_81] Time to go to floor 4 and stay there for 00:26:54
[D1 11:50:50 floor_1] citizen_81 entered the queue
[D1 11:50:50 floor_1] citizen_81 found an empty queue and will be served immediately
[D1 11:50:50 elevator_2] Summoned to floor 1 from floor 2
[D1 11:50:50 citizen_99] Entered the building, will visit 5 floors in total
[D1 11:50:50 citizen_99] Time to go to floor 5 and stay there for 00:35:43
[D1 11:50:50 floor_0] citizen_99 entered the queue
[D1 11:50:50 floor_0] citizen_99 found an empty queue and will be served immediately
[D1 11:50:50 elevator_2] Summoned to floor 0 from floor 2
[D1 11:50:55 elevator_2] At floor 3
[D1 11:50:55 elevator_2] Stopped at floor 3
[D1 11:50:55 elevator_2] Opening doors
[D1 11:50:58 elevator_2] Opened doors
[D1 11:50:58 citizen_98] Left elevator_2, arrived at floor 3
[D1 11:51:01 elevator_1] Closing doors
[D1 11:51:04 elevator_1] Closed doors
[D1 11:51:10 elevator_2] Closing doors
[D1 11:51:13 elevator_2] Closed doors
[D1 11:51:14 elevator_1] At floor 5
[D1 11:51:14 elevator_1] Stopped at floor 5
[D1 11:51:14 elevator_1] Opening doors
[D1 11:51:17 elevator_1] Opened doors
[D1 11:51:17 citizen_61] Left elevator_1, arrived at floor 5
[D1 11:51:23 elevator_2] At floor 4
[D1 11:51:29 citizen_48] Time to go to the ground floor and leave
[D1 11:51:29 floor_1] citizen_48 entered the queue
[D1 11:51:29 floor_1] citizen_48 is queued along with 0 other arrivals in front of it
[D1 11:51:29 elevator_1] Closing doors
[D1 11:51:32 elevator_1] Closed doors
[D1 11:51:32 elevator_1] Changing direction to Down
[D1 11:51:33 elevator_2] At floor 5
[D1 11:51:33 elevator_2] Stopped at floor 5
[D1 11:51:33 elevator_2] Opening doors
[D1 11:51:36 elevator_2] Opened doors
[D1 11:51:36 citizen_69] Left elevator_2, arrived at floor 5
[D1 11:51:36 citizen_73] Entered elevator_2, going to floor 2
[D1 11:51:36 floor_5] citizen_73 is leaving the queue
[D1 11:51:36 floor_5] citizen_83 was served
[D1 11:51:36 elevator_1] Summoned to floor 5 from floor 5
[D1 11:51:36 elevator_2] Summoned to floor 5 from floor 5
[D1 11:51:36 citizen_83] Entered elevator_2, going to floor 2
[D1 11:51:36 floor_5] citizen_83 is leaving the queue
[D1 11:51:36 floor_5] citizen_28 was served
[D1 11:51:36 elevator_1] Summoned to floor 5 from floor 5
[D1 11:51:36 elevator_2] Summoned to floor 5 from floor 5
[D1 11:51:36 citizen_28] Entered elevator_2, going to floor 0
[D1 11:51:36 floor_5] citizen_28 is leaving the queue
[D1 11:51:36 floor_5] The queue is now empty
[D1 11:51:42 elevator_1] At floor 4
[D1 11:51:48 elevator_2] Closing doors
[D1 11:51:51 citizen_86] Time to go to floor 2 and stay there for 00:39:34
[D1 11:51:51 floor_1] citizen_86 entered the queue
[D1 11:51:51 floor_1] citizen_86 is queued along with 1 other arrivals in front of it
[D1 11:51:51 elevator_2] Closed doors
[D1 11:51:51 elevator_2] Changing direction to Down
[D1 11:51:52 elevator_1] At floor 3
[D1 11:51:52 elevator_1] Stopped at floor 3
[D1 11:51:52 elevator_1] Opening doors
[D1 11:51:55 elevator_1] Opened doors
[D1 11:51:55 citizen_62] Left elevator_1, arrived at floor 3
[D1 11:52:01 elevator_2] At floor 4
[D1 11:52:07 elevator_1] Closing doors
[D1 11:52:10 citizen_75] Time to go to floor 3 and stay there for 00:26:06
[D1 11:52:10 floor_4] citizen_75 entered the queue
[D1 11:52:10 floor_4] citizen_75 found an empty queue and will be served immediately
[D1 11:52:10 elevator_2] Summoned to floor 4 from floor 4
[D1 11:52:10 elevator_1] Closed doors
[D1 11:52:10 elevator_1] Changing direction to Up
[D1 11:52:11 elevator_2] At floor 3
[D1 11:52:20 elevator_1] At floor 4
[D1 11:52:21 elevator_2] At floor 2
[D1 11:52:21 elevator_2] Stopped at floor 2
[D1 11:52:21 elevator_2] Opening doors
[D1 11:52:24 elevator_2] Opened doors
[D1 11:52:24 citizen_73] Left elevator_2, arrived at floor 2
[D1 11:52:24 citizen_83] Left elevator_2, arrived at floor 2
[D1 11:52:30 elevator_1] At floor 5
[D1 11:52:30 elevator_1] Stopped at floor 5
[D1 11:52:30 elevator_1] Opening doors
[D1 11:52:32 citizen_46] Time to go to the ground floor and leave
[D1 11:52:32 floor_1] citizen_46 entered the queue
[D1 11:52:32 floor_1] citizen_46 is queued along with 2 other arrivals in front of it
[D1 11:52:33 elevator_1] Opened doors
[D1 11:52:36 elevator_2] Closing doors
[D1 11:52:39 elevator_2] Closed doors
[D1 11:52:45 elevator_1] Closing doors
[D1 11:52:48 elevator_1] Closed doors
[D1 11:52:48 elevator_1] Resting at floor 5
[D1 11:52:49 elevator_2] At floor 1
[D1 11:52:49 elevator_2] Stopped at floor 1
[D1 11:52:49 elevator_2] Opening doors
[D1 11:52:52 elevator_2] Opened doors
[D1 11:52:52 citizen_81] Entered elevator_2, going to floor 4
[D1 11:52:52 floor_1] citizen_81 is leaving the queue
[D1 11:52:52 floor_1] citizen_48 was served
[D1 11:52:52 elevator_2] Summoned to floor 1 from floor 1
[D1 11:52:52 citizen_48] Entered elevator_2, going to floor 0
[D1 11:52:52 floor_1] citizen_48 is leaving the queue
[D1 11:52:52 floor_1] citizen_86 was served
[D1 11:52:52 elevator_2] Summoned to floor 1 from floor 1
[D1 11:52:52 citizen_86] Entered elevator_2, going to floor 2
[D1 11:52:52 floor_1] citizen_86 is leaving the queue
[D1 11:52:52 floor_1] citizen_46 was served
[D1 11:52:52 elevator_2] Summoned to floor 1 from floor 1
[D1 11:52:52 citizen_46] Cannot enter elevator_2, it is full
[D1 11:52:52 citizen_46] All elevators were full, trying to summon them again
[D1 11:53:04 elevator_2] Closing doors
[D1 11:53:06 citizen_100] Entered the building, will visit 2 floors in total
[D1 11:53:06 citizen_100] Time to go to floor 4 and stay there for 00:32:32
[D1 11:53:06 floor_0] citizen_100 entered the queue
[D1 11:53:06 floor_0] citizen_100 is queued along with 0 other arrivals in front of it
[D1 11:53:07 elevator_2] Closed doors
[D1 11:53:08 elevator_2] Summoned to floor 1 from floor 1
[D1 11:53:17 elevator_2] At floor 0
[D1 11:53:17 elevator_2] Stopped at floor 0
[D1 11:53:17 elevator_2] Opening doors
[D1 11:53:20 elevator_2] Opened doors
[D1 11:53:20 citizen_28] Left elevator_2, arrived at floor 0
[D1 11:53:20 citizen_48] Left elevator_2, arrived at floor 0
[D1 11:53:20 citizen_28] Left the building
[D1 11:53:20 citizen_48] Left the building
[D1 11:53:20 citizen_99] Entered elevator_2, going to floor 5
[D1 11:53:20 floor_0] citizen_99 is leaving the queue
[D1 11:53:20 floor_0] citizen_100 was served
[D1 11:53:20 elevator_2] Summoned to floor 0 from floor 0
[D1 11:53:20 citizen_100] Entered elevator_2, going to floor 4
[D1 11:53:20 floor_0] citizen_100 is leaving the queue
[D1 11:53:20 floor_0] The queue is now empty
[D1 11:53:32 elevator_2] Closing doors
[D1 11:53:35 elevator_2] Closed doors
[D1 11:53:35 elevator_2] Changing direction to Up
[D1 11:53:45 elevator_2] At floor 1
[D1 11:53:45 elevator_2] Stopped at floor 1
[D1 11:53:45 elevator_2] Opening doors
[D1 11:53:48 elevator_2] Opened doors
[D1 11:53:48 citizen_46] Cannot enter elevator_2, it is full
[D1 11:53:48 citizen_46] All elevators were full, trying to summon them again
[D1 11:54:00 elevator_2] Closing doors
[D1 11:54:03 elevator_2] Closed doors
[D1 11:54:04 elevator_2] Summoned to floor 1 from floor 1
[D1 11:54:13 elevator_2] At floor 2
[D1 11:54:13 elevator_2] Stopped at floor 2
[D1 11:54:13 elevator_2] Opening doors
[D1 11:54:16 elevator_2] Opened doors
[D1 11:54:16 citizen_86] Left elevator_2, arrived at floor 2
[D1 11:54:28 elevator_2] Closing doors
[D1 11:54:31 elevator_2] Closed doors
[D1 11:54:41 elevator_2] At floor 3
[D1 11:54:48 citizen_53] Time to go to the ground floor and leave
[D1 11:54:48 floor_1] citizen_53 entered the queue
[D1 11:54:48 floor_1] citizen_53 is queued along with 0 other arrivals in front of it
[D1 11:54:51 elevator_2] At floor 4
[D1 11:54:51 elevator_2] Stopped at floor 4
[D1 11:54:51 elevator_2] Opening doors
[D1 11:54:54 elevator_2] Opened doors
[D1 11:54:54 citizen_81] Left elevator_2, arrived at floor 4
[D1 11:54:54 citizen_100] Left elevator_2, arrived at floor 4
[D1 11:54:54 citizen_75] Entered elevator_2, going to floor 3
[D1 11:54:54 floor_4] citizen_75 is leaving the queue
[D1 11:54:54 floor_4] The queue is now empty
[D1 11:54:59 citizen_80] Time to go to floor 1 and stay there for 00:28:38
[D1 11:54:59 floor_2] citizen_80 entered the queue
[D1 11:54:59 floor_2] citizen_80 found an empty queue and will be served immediately
[D1 11:54:59 elevator_2] Summoned to floor 2 from floor 4
[D1 11:55:06 elevator_2] Closing doors
[D1 11:55:09 elevator_2] Closed doors
[D1 11:55:14 citizen_36] Time to go to the ground floor and leave
[D1 11:55:14 floor_4] citizen_36 entered the queue
[D1 11:55:14 floor_4] citizen_36 found an empty queue and will be served immediately
[D1 11:55:14 elevator_2] Summoned to floor 4 from floor 4
[D1 11:55:19 elevator_2] At floor 5
[D1 11:55:19 elevator_2] Stopped at floor 5
[D1 11:55:19 elevator_2] Opening doors
[D1 11:55:22 elevator_2] Opened doors
[D1 11:55:22 citizen_99] Left elevator_2, arrived at floor 5
[D1 11:55:34 elevator_2] Closing doors
[D1 11:55:37 elevator_2] Closed doors
[D1 11:55:37 elevator_2] Changing direction to Down
[D1 11:55:47 elevator_2] At floor 4
[D1 11:55:47 elevator_2] Stopped at floor 4
[D1 11:55:47 elevator_2] Opening doors
[D1 11:55:50 elevator_2] Opened doors
[D1 11:55:50 citizen_36] Entered elevator_2, going to floor 0
[D1 11:55:50 floor_4] citizen_36 is leaving the queue
[D1 11:55:50 floor_4] The queue is now empty
[D1 11:56:02 elevator_2] Closing doors
[D1 11:56:05 elevator_2] Closed doors
[D1 11:56:15 elevator_2] At floor 3
[D1 11:56:15 elevator_2] Stopped at floor 3
[D1 11:56:15 elevator_2] Opening doors
[D1 11:56:18 elevator_2] Opened doors
[D1 11:56:18 citizen_75] Left elevator_2, arrived at floor 3
[D1 11:56:30 elevator_2] Closing doors
[D1 11:56:33 elevator_2] Closed doors
[D1 11:56:37 citizen_55] Time to go to the ground floor and leave
[D1 11:56:37 floor_1] citizen_55 entered the queue
[D1 11:56:37 floor_1] citizen_55 is queued along with 1 other arrivals in front of it
[D1 11:56:41 citizen_101] Entered the building, will visit 4 floors in total
[D1 11:56:41 citizen_101] Time to go to floor 2 and stay there for 00:36:01
[D1 11:56:41 floor_0] citizen_101 entered the queue
[D1 11:56:41 floor_0] citizen_101 found an empty queue and will be served immediately
[D1 11:56:41 elevator_2] Summoned to floor 0 from floor 3
[D1 11:56:43 elevator_2] At floor 2
[D1 11:56:43 elevator_2] Stopped at floor 2
[D1 11:56:43 elevator_2] Opening doors
[D1 11:56:46 elevator_2] Opened doors
[D1 11:56:46 citizen_80] Entered elevator_2, going to floor 1
[D1 11:56:46 floor_2] citizen_80 is leaving the queue
[D1 11:56:46 floor_2] The queue is now empty
[D1 11:56:58 elevator_2] Closing doors
[D1 11:57:01 elevator_2] Closed doors
[D1 11:57:06 citizen_41] Time to go to the ground floor and leave
[D1 11:57:06 floor_3] citizen_41 entered the queue
[D1 11:57:06 floor_3] citizen_41 found an empty queue and will be served immediately
[D1 11:57:06 elevator_2] Summoned to floor 3 from floor 2
[D1 11:57:11 elevator_2] At floor 1
[D1 11:57:11 elevator_2] Stopped at floor 1
[D1 11:57:11 elevator_2] Opening doors
[D1 11:57:14 elevator_2] Opened doors
[D1 11:57:14 citizen_80] Left elevator_2, arrived at floor 1
[D1 11:57:14 citizen_46] Entered elevator_2, going to floor 0
[D1 11:57:14 floor_1] citizen_46 is leaving the queue
[D1 11:57:14 floor_1] citizen_53 was served
[D1 11:57:14 elevator_2] Summoned to floor 1 from floor 1
[D1 11:57:14 citizen_53] Entered elevator_2, going to floor 0
[D1 11:57:14 floor_1] citizen_53 is leaving the queue
[D1 11:57:14 floor_1] citizen_55 was served
[D1 11:57:14 elevator_2] Summoned to floor 1 from floor 1
[D1 11:57:14 citizen_55] Entered elevator_2, going to floor 0
[D1 11:57:14 floor_1] citizen_55 is leaving the queue
[D1 11:57:14 floor_1] The queue is now empty
[D1 11:57:26 elevator_2] Closing doors
[D1 11:57:29 elevator_2] Closed doors
[D1 11:57:39 elevator_2] At floor 0
[D1 11:57:39 elevator_2] Stopped at floor 0
[D1 11:57:39 elevator_2] Opening doors
[D1 11:57:42 elevator_2] Opened doors
[D1 11:57:42 citizen_36] Left elevator_2, arrived at floor 0
[D1 11:57:42 citizen_46] Left elevator_2, arrived at floor 0
[D1 11:57:42 citizen_53] Left elevator_2, arrived at floor 0
[D1 11:57:42 citizen_55] Left elevator_2, arrived at floor 0
[D1 11:57:42 citizen_36] Left the building
[D1 11:57:42 citizen_55] Left the building
[D1 11:57:42 citizen_46] Left the building
[D1 11:57:42 citizen_53] Left the building
[D1 11:57:42 citizen_101] Entered elevator_2, going to floor 2
[D1 11:57:42 floor_0] citizen_101 is leaving the queue
[D1 11:57:42 floor_0] The queue is now empty
[D1 11:57:54 elevator_2] Closing doors
[D1 11:57:57 elevator_2] Closed doors
[D1 11:57:57 elevator_2] Changing direction to Up
[D1 11:57:58 citizen_60] Time to go to floor 2 and stay there for 00:28:28
[D1 11:57:58 floor_1] citizen_60 entered the queue
[D1 11:57:58 floor_1] citizen_60 found an empty queue and will be served immediately
[D1 11:57:58 elevator_2] Summoned to floor 1 from floor 0
[D1 11:58:07 elevator_2] At floor 1
[D1 11:58:07 elevator_2] Stopped at floor 1
[D1 11:58:07 elevator_2] Opening doors
[D1 11:58:10 elevator_2] Opened doors
[D1 11:58:10 citizen_60] Entered elevator_2, going to floor 2
[D1 11:58:10 floor_1] citizen_60 is leaving the queue
[D1 11:58:10 floor_1] The queue is now empty
[D1 11:58:11 citizen_18] Time to go to the ground floor and leave
[D1 11:58:11 floor_4] citizen_18 entered the queue
[D1 11:58:11 floor_4] citizen_18 found an empty queue and will be served immediately
[D1 11:58:11 elevator_1] Summoned to floor 4 from floor 5
[D1 11:58:11 elevator_1] Sprung into motion, heading Down
[D1 11:58:20 citizen_32] Time to go to floor 1 and stay there for 00:38:07
[D1 11:58:20 floor_5] citizen_32 entered the queue
[D1 11:58:20 floor_5] citizen_32 found an empty queue and will be served immediately
[D1 11:58:20 elevator_1] Summoned to floor 5 from floor 5
[D1 11:58:21 elevator_1] At floor 4
[D1 11:58:21 elevator_1] Stopped at floor 4
[D1 11:58:21 elevator_1] Opening doors
[D1 11:58:22 elevator_2] Closing doors
[D1 11:58:24 elevator_1] Opened doors
[D1 11:58:24 citizen_18] Entered elevator_1, going to floor 0
[D1 11:58:24 floor_4] citizen_18 is leaving the queue
[D1 11:58:24 floor_4] The queue is now empty
[D1 11:58:25 elevator_2] Closed doors
[D1 11:58:35 citizen_14] Time to go to the ground floor and leave
[D1 11:58:35 floor_4] citizen_14 entered the queue
[D1 11:58:35 floor_4] citizen_14 found an empty queue and will be served immediately
[D1 11:58:35 elevator_1] Summoned to floor 4 from floor 4
[D1 11:58:35 citizen_14] Entered elevator_1, going to floor 0
[D1 11:58:35 floor_4] citizen_14 is leaving the queue
[D1 11:58:35 floor_4] The queue is now empty
[D1 11:58:35 elevator_2] At floor 2
[D1 11:58:35 elevator_2] Stopped at floor 2
[D1 11:58:35 elevator_2] Opening doors
[D1 11:58:36 elevator_1] Closing doors
[D1 11:58:38 elevator_2] Opened doors
[D1 11:58:38 citizen_101] Left elevator_2, arrived at floor 2
[D1 11:58:38 citizen_60] Left elevator_2, arrived at floor 2
[D1 11:58:39 elevator_1] Closed doors
[D1 11:58:49 elevator_1] At floor 3
[D1 11:58:50 elevator_2] Closing doors
[D1 11:58:53 elevator_2] Closed doors
[D1 11:58:59 elevator_1] At floor 2
[D1 11:59:03 elevator_2] At floor 3
[D1 11:59:03 elevator_2] Stopped at floor 3
[D1 11:59:03 elevator_2] Opening doors
[D1 11:59:06 elevator_2] Opened doors
[D1 11:59:06 citizen_41] Entered elevator_2, going to floor 0
[D1 11:59:06 floor_3] citizen_41 is leaving the queue
[D1 11:59:06 floor_3] The queue is now empty
[D1 11:59:09 elevator_1] At floor 1
[D1 11:59:10 citizen_76] Time to go to floor 1 and stay there for 00:40:43
[D1 11:59:10 floor_3] citizen_76 entered the queue
[D1 11:59:10 floor_3] citizen_76 found an empty queue and will be served immediately
[D1 11:59:10 elevator_2] Summoned to floor 3 from floor 3
[D1 11:59:10 citizen_76] Entered elevator_2, going to floor 1
[D1 11:59:10 floor_3] citizen_76 is leaving the queue
[D1 11:59:10 floor_3] The queue is now empty
[D1 11:59:17 citizen_34] Time to go to the ground floor and leave
[D1 11:59:17 floor_5] citizen_34 entered the queue
[D1 11:59:17 floor_5] citizen_34 is queued along with 0 other arrivals in front of it
[D1 11:59:18 elevator_2] Closing doors
[D1 11:59:19 elevator_1] At floor 0
[D1 11:59:19 elevator_1] Stopped at floor 0
[D1 11:59:19 elevator_1] Opening doors
[D1 11:59:21 elevator_2] Closed doors
[D1 11:59:21 elevator_2] Changing direction to Down
[D1 11:59:22 elevator_1] Opened doors
[D1 11:59:22 citizen_18] Left elevator_1, arrived at floor 0
[D1 11:59:22 citizen_14] Left elevator_1, arrived at floor 0
[D1 11:59:22 citizen_18] Left the building
[D1 11:59:22 citizen_14] Left the building
[D1 11:59:31 elevator_2] At floor 2
[D1 11:59:34 elevator_1] Closing doors
[D1 11:59:37 elevator_1] Closed doors
[D1 11:59:37 elevator_1] Changing direction to Up
[D1 11:59:41 citizen_87] Time to go to floor 5 and stay there for 00:37:21
[D1 11:59:41 floor_2] citizen_87 entered the queue
[D1 11:59:41 floor_2] citizen_87 found an empty queue and will be served immediately
[D1 11:59:41 elevator_2] Summoned to floor 2 from floor 2
[D1 11:59:41 elevator_2] At floor 1
[D1 11:59:41 elevator_2] Stopped at floor 1
[D1 11:59:41 elevator_2] Opening doors
[D1 11:59:42 citizen_102] Entered the building, will visit 5 floors in total
[D1 11:59:42 citizen_102] Time to go to floor 3 and stay there for 00:30:19
[D1 11:59:42 floor_0] citizen_102 entered the queue
[D1 11:59:42 floor_0] citizen_102 found an empty queue and will be served immediately
[D1 11:59:42 elevator_1] Summoned to floor 0 from floor 0
[D1 11:59:44 elevator_2] Opened doors
[D1 11:59:44 citizen_76] Left elevator_2, arrived at floor 1
[D1 11:59:47 elevator_1] At floor 1
[D1 11:59:56 elevator_2] Closing doors
[D1 11:59:57 elevator_1] At floor 2
[D1 11:59:59 elevator_2] Closed doors
[D1 12:00:02 citizen_90] Time to go to the ground floor and leave
[D1 12:00:02 floor_2] citizen_90 entered the queue
[D1 12:00:02 floor_2] citizen_90 is queued along with 0 other arrivals in front of it
[D1 12:00:07 elevator_1] At floor 3
[D1 12:00:09 elevator_2] At floor 0
[D1 12:00:09 elevator_2] Stopped at floor 0
[D1 12:00:09 elevator_2] Opening doors
[D1 12:00:12 elevator_2] Opened doors
[D1 12:00:12 citizen_41] Left elevator_2, arrived at floor 0
[D1 12:00:12 citizen_41] Left the building
[D1 12:00:17 elevator_1] At floor 4
[D1 12:00:24 elevator_2] Closing doors
[D1 12:00:27 elevator_1] At floor 5
[D1 12:00:27 elevator_1] Stopped at floor 5
[D1 12:00:27 elevator_1] Opening doors
[D1 12:00:27 elevator_2] Closed doors
[D1 12:00:27 elevator_2] Changing direction to Up
[D1 12:00:30 elevator_1] Opened doors
[D1 12:00:30 citizen_32] Entered elevator_1, going to floor 1
[D1 12:00:30 floor_5] citizen_32 is leaving the queue
[D1 12:00:30 floor_5] citizen_34 was served
[D1 12:00:30 elevator_1] Summoned to floor 5 from floor 5
[D1 12:00:30 citizen_34] Entered elevator_1, going to floor 0
[D1 12:00:30 floor_5] citizen_34 is leaving the queue
[D1 12:00:30 floor_5] The queue is now empty
[D1 12:00:37 elevator_2] At floor 1
[D1 12:00:42 elevator_1] Closing doors
[D1 12:00:45 elevator_1] Closed doors
[D1 12:00:45 elevator_1] Changing direction to Down
[D1 12:00:47 elevator_2] At floor 2
[D1 12:00:47 elevator_2] Stopped at floor 2
[D1 12:00:47 elevator_2] Opening doors
[D1 12:00:50 elevator_2] Opened doors
[D1 12:00:50 citizen_87] Entered elevator_2, going to floor 5
[D1 12:00:50 floor_2] citizen_87 is leaving the queue
[D1 12:00:50 floor_2] citizen_90 was served
[D1 12:00:50 elevator_2] Summoned to floor 2 from floor 2
[D1 12:00:50 citizen_90] Entered elevator_2, going to floor 0
[D1 12:00:50 floor_2] citizen_90 is leaving the queue
[D1 12:00:50 floor_2] The queue is now empty
[D1 12:00:55 elevator_1] At floor 4
[D1 12:01:02 elevator_2] Closing doors
[D1 12:01:03 citizen_78] Time to go to floor 5 and stay there for 00:28:34
[D1 12:01:03 floor_4] citizen_78 entered the queue
[D1 12:01:03 floor_4] citizen_78 found an empty queue and will be served immediately
[D1 12:01:03 elevator_1] Summoned to floor 4 from floor 4
[D1 12:01:05 elevator_1] At floor 3
[D1 12:01:05 elevator_2] Closed doors
[D1 12:01:15 elevator_1] At floor 2
[D1 12:01:15 elevator_2] At floor 3
[D1 12:01:21 citizen_84] Time to go to floor 2 and stay there for 00:32:33
[D1 12:01:21 floor_5] citizen_84 entered the queue
[D1 12:01:21 floor_5] citizen_84 found an empty queue and will be served immediately
[D1 12:01:21 elevator_2] Summoned to floor 5 from floor 3
[D1 12:01:25 elevator_1] At floor 1
[D1 12:01:25 elevator_1] Stopped at floor 1
[D1 12:01:25 elevator_1] Opening doors
[D1 12:01:25 elevator_2] At floor 4
[D1 12:01:28 elevator_1] Opened doors
[D1 12:01:28 citizen_32] Left elevator_1, arrived at floor 1
[D1 12:01:35 elevator_2] At floor 5
[D1 12:01:35 elevator_2] Stopped at floor 5
[D1 12:01:35 elevator_2] Opening doors
[D1 12:01:38 elevator_2] Opened doors
[D1 12:01:38 citizen_87] Left elevator_2, arrived at floor 5
[D1 12:01:38 citizen_84] Entered elevator_2, going to floor 2
[D1 12:01:38 floor_5] citizen_84 is leaving the queue
[D1 12:01:38 floor_5] The queue is now empty
[D1 12:01:40 elevator_1] Closing doors
[D1 12:01:43 elevator_1] Closed doors
[D1 12:01:44 citizen_103] Entered the building, will visit 4 floors in total
[D1 12:01:44 citizen_103] Time to go to floor 5 and stay there for 00:28:05
[D1 12:01:44 floor_0] citizen_103 entered the queue
[D1 12:01:44 floor_0] citizen_103 is queued along with 0 other arrivals in front of it
[D1 12:01:50 elevator_2] Closing doors
[D1 12:01:53 elevator_1] At floor 0
[D1 12:01:53 elevator_1] Stopped at floor 0
[D1 12:01:53 elevator_1] Opening doors
[D1 12:01:53 elevator_2] Closed doors
[D1 12:01:53 elevator_2] Changing direction to Down
[D1 12:01:54 citizen_74] Time to go to floor 1 and stay there for 00:26:39
[D1 12:01:54 floor_5] citizen_74 entered the queue
[D1 12:01:54 floor_5] citizen_74 found an empty queue and will be served immediately
[D1 12:01:54 elevator_2] Summoned to floor 5 from floor 5
[D1 12:01:56 elevator_1] Opened doors
[D1 12:01:56 citizen_34] Left elevator_1, arrived at floor 0
[D1 12:01:56 citizen_34] Left the building
[D1 12:01:56 citizen_102] Entered elevator_1, going to floor 3
[D1 12:01:56 floor_0] citizen_102 is leaving the queue
[D1 12:01:56 floor_0] citizen_103 was served
[D1 12:01:56 elevator_1] Summoned to floor 0 from floor 0
[D1 12:01:56 citizen_103] Entered elevator_1, going to floor 5
[D1 12:01:56 floor_0] citizen_103 is leaving the queue
[D1 12:01:56 floor_0] The queue is now empty
[D1 12:02:03 elevator_2] At floor 4
[D1 12:02:08 elevator_1] Closing doors
[D1 12:02:11 elevator_1] Closed doors
[D1 12:02:11 elevator_1] Changing direction to Up
[D1 12:02:13 elevator_2] At floor 3
[D1 12:02:21 elevator_1] At floor 1
[D1 12:02:23 elevator_2] At floor 2
[D1 12:02:23 elevator_2] Stopped at floor 2
[D1 12:02:23 elevator_2] Opening doors
[D1 12:02:26 elevator_2] Opened doors
[D1 12:02:26 citizen_84] Left elevator_2, arrived at floor 2
[D1 12:02:31 elevator_1] At floor 2
[D1 12:02:38 elevator_2] Closing doors
[D1 12:02:41 elevator_1] At floor 3
[D1 12:02:41 elevator_1] Stopped at floor 3
[D1 12:02:41 elevator_1] Opening doors
[D1 12:02:41 elevator_2] Closed doors
[D1 12:02:44 elevator_1] Opened doors
[D1 12:02:44 citizen_102] Left elevator_1, arrived at floor 3
[D1 12:02:51 elevator_2] At floor 1
[D1 12:02:56 elevator_1] Closing doors
[D1 12:02:58 citizen_85] Time to go to floor 5 and stay there for 00:30:31
[D1 12:02:58 floor_1] citizen_85 entered the queue
[D1 12:02:58 floor_1] citizen_85 found an empty queue and will be served immediately
[D1 12:02:58 elevator_2] Summoned to floor 1 from floor 1
[D1 12:02:59 elevator_1] Closed doors
[D1 12:03:01 elevator_2] At floor 0
[D1 12:03:01 elevator_2] Stopped at floor 0
[D1 12:03:01 elevator_2] Opening doors
[D1 12:03:04 elevator_2] Opened doors
[D1 12:03:04 citizen_90] Left elevator_2, arrived at floor 0
[D1 12:03:04 citizen_90] Left the building
[D1 12:03:09 elevator_1] At floor 4
[D1 12:03:09 elevator_1] Stopped at floor 4
[D1 12:03:09 elevator_1] Opening doors
[D1 12:03:12 elevator_1] Opened doors
[D1 12:03:12 citizen_78] Entered elevator_1, going to floor 5
[D1 12:03:12 floor_4] citizen_78 is leaving the queue
[D1 12:03:12 floor_4] The queue is now empty
[D1 12:03:16 elevator_2] Closing doors
[D1 12:03:19 elevator_2] Closed doors
[D1 12:03:19 elevator_2] Changing direction to Up
[D1 12:03:24 elevator_1] Closing doors
[D1 12:03:25 citizen_104] Entered the building, will visit 5 floors in total
[D1 12:03:25 citizen_104] Time to go to floor 2 and stay there for 00:22:32
[D1 12:03:25 floor_0] citizen_104 entered the queue
[D1 12:03:25 floor_0] citizen_104 found an empty queue and will be served immediately
[D1 12:03:25 elevator_2] Summoned to floor 0 from floor 0
[D1 12:03:27 elevator_1] Closed doors
[D1 12:03:29 elevator_2] At floor 1
[D1 12:03:29 elevator_2] Stopped at floor 1
[D1 12:03:29 elevator_2] Opening doors
[D1 12:03:32 elevator_2] Opened doors
[D1 12:03:32 citizen_85] Entered elevator_2, going to floor 5
[D1 12:03:32 floor_1] citizen_85 is leaving the queue
[D1 12:03:32 floor_1] The queue is now empty
[D1 12:03:37 elevator_1] At floor 5
[D1 12:03:37 elevator_1] Stopped at floor 5
[D1 12:03:37 elevator_1] Opening doors
[D1 12:03:40 elevator_1] Opened doors
[D1 12:03:40 citizen_103] Left elevator_1, arrived at floor 5
[D1 12:03:40 citizen_78] Left elevator_1, arrived at floor 5
[D1 12:03:44 elevator_2] Closing doors
[D1 12:03:47 elevator_2] Closed doors
[D1 12:03:52 elevator_1] Closing doors
[D1 12:03:55 elevator_1] Closed doors
[D1 12:03:55 elevator_1] Resting at floor 5
[D1 12:03:57 elevator_2] At floor 2
[D1 12:04:07 elevator_2] At floor 3
[D1 12:04:17 elevator_2] At floor 4
[D1 12:04:27 elevator_2] At floor 5
[D1 12:04:27 elevator_2] Stopped at floor 5
[D1 12:04:27 elevator_2] Opening doors
[D1 12:04:30 elevator_2] Opened doors
[D1 12:04:30 citizen_85] Left elevator_2, arrived at floor 5
[D1 12:04:30 citizen_74] Entered elevator_2, going to floor 1
[D1 12:04:30 floor_5] citizen_74 is leaving the queue
[D1 12:04:30 floor_5] The queue is now empty
[D1 12:04:39 citizen_43] Time to go to the ground floor and leave
[D1 12:04:39 floor_1] citizen_43 entered the queue
[D1 12:04:39 floor_1] citizen_43 found an empty queue and will be served immediately
[D1 12:04:39 elevator_1] Summoned to floor 1 from floor 5
[D1 12:04:39 elevator_1] Sprung into motion, heading Down
[D1 12:04:39 elevator_2] Summoned to floor 1 from floor 5
[D1 12:04:42 elevator_2] Closing doors
[D1 12:04:45 elevator_2] Closed doors
[D1 12:04:45 elevator_2] Changing direction to Down
[D1 12:04:49 elevator_1] At floor 4
[D1 12:04:55 elevator_2] At floor 4
[D1 12:04:59 elevator_1] At floor 3
[D1 12:05:05 elevator_2] At floor 3
[D1 12:05:09 elevator_1] At floor 2
[D1 12:05:15 elevator_2] At floor 2
[D1 12:05:19 elevator_1] At floor 1
[D1 12:05:19 elevator_1] Stopped at floor 1
[D1 12:05:19 elevator_1] Opening doors
[D1 12:05:22 elevator_1] Opened doors
[D1 12:05:22 citizen_43] Entered elevator_1, going to floor 0
[D1 12:05:22 floor_1] citizen_43 is leaving the queue
[D1 12:05:22 floor_1] The queue is now empty
[D1 12:05:25 elevator_2] At floor 1
[D1 12:05:25 elevator_2] Stopped at floor 1
[D1 12:05:25 elevator_2] Opening doors
[D1 12:05:28 elevator_2] Opened doors
[D1 12:05:28 citizen_74] Left elevator_2, arrived at floor 1
[D1 12:05:34 elevator_1] Closing doors
[D1 12:05:37 citizen_70] Time to go to floor 5 and stay there for 00:24:37
[D1 12:05:37 floor_1] citizen_70 entered the queue
[D1 12:05:37 floor_1] citizen_70 found an empty queue and will be served immediately
[D1 12:05:37 elevator_1] Summoned to floor 1 from floor 1
[D1 12:05:37 elevator_2] Summoned to floor 1 from floor 1
[D1 12:05:37 citizen_70] Entered elevator_2, going to floor 5
[D1 12:05:37 floor_1] citizen_70 is leaving the queue
[D1 12:05:37 floor_1] The queue is now empty
[D1 12:05:37 elevator_1] Reopening doors
[D1 12:05:40 elevator_2] Closing doors
[D1 12:05:43 elevator_2] Closed doors
[D1 12:05:49 elevator_1] Closing doors
[D1 12:05:52 elevator_1] Closed doors
[D1 12:05:53 elevator_2] At floor 0
[D1 12:05:53 elevator_2] Stopped at floor 0
[D1 12:05:53 elevator_2] Opening doors
[D1 12:05:56 elevator_2] Opened doors
[D1 12:05:56 citizen_104] Entered elevator_2, going to floor 2
[D1 12:05:56 floor_0] citizen_104 is leaving the queue
[D1 12:05:56 floor_0] The queue is now empty
[D1 12:06:02 elevator_1] At floor 0
[D1 12:06:02 elevator_1] Stopped at floor 0
[D1 12:06:02 elevator_1] Opening doors
[D1 12:06:05 elevator_1] Opened doors
[D1 12:06:05 citizen_43] Left elevator_1, arrived at floor 0
[D1 12:06:05 citizen_43] Left the building
[D1 12:06:08 citizen_105] Entered the building, will visit 3 floors in total
[D1 12:06:08 citizen_105] Time to go to floor 1 and stay there for 00:16:31
[D1 12:06:08 floor_0] citizen_105 entered the queue
[D1 12:06:08 floor_0] citizen_105 found an empty queue and will be served immediately
[D1 12:06:08 elevator_1] Summoned to floor 0 from floor 0
[D1 12:06:08 elevator_2] Summoned to floor 0 from floor 0
[D1 12:06:08 citizen_105] Entered elevator_1, going to floor 1
[D1 12:06:08 floor_0] citizen_105 is leaving the queue
[D1 12:06:08 floor_0] The queue is now empty
[D1 12:06:08 elevator_2] Closing doors
[D1 12:06:11 elevator_2] Closed doors
[D1 12:06:11 elevator_2] Changing direction to Up
[D1 12:06:17 elevator_1] Closing doors
[D1 12:06:20 elevator_1] Closed doors
[D1 12:06:20 elevator_1] Changing direction to Up
[D1 12:06:21 elevator_2] At floor 1
[D1 12:06:30 elevator_1] At floor 1
[D1 12:06:30 elevator_1] Stopped at floor 1
[D1 12:06:30 elevator_1] Opening doors
[D1 12:06:31 citizen_89] Time to go to floor 3 and stay there for 00:09:10
[D1 12:06:31 floor_4] citizen_89 entered the queue
[D1 12:06:31 floor_4] citizen_89 found an empty queue and will be served immediately
[D1 12:06:31 elevator_1] Summoned to floor 4 from floor 1
[D1 12:06:31 elevator_2] Summoned to floor 4 from floor 1
[D1 12:06:31 elevator_2] At floor 2
[D1 12:06:31 elevator_2] Stopped at floor 2
[D1 12:06:31 elevator_2] Opening doors
[D1 12:06:33 elevator_1] Opened doors
[D1 12:06:33 citizen_105] Left elevator_1, arrived at floor 1
[D1 12:06:34 elevator_2] Opened doors
[D1 12:06:34 citizen_104] Left elevator_2, arrived at floor 2
[D1 12:06:40 citizen_88] Time to go to floor 1 and stay there for 00:37:50
[D1 12:06:40 floor_4] citizen_88 entered the queue
[D1 12:06:40 floor_4] citizen_88 is queued along with 0 other arrivals in front of it
[D1 12:06:45 elevator_1] Closing doors
[D1 12:06:46 elevator_2] Closing doors
[D1 12:06:48 elevator_1] Closed doors
[D1 12:06:49 elevator_2] Closed doors
[D1 12:06:58 elevator_1] At floor 2
[D1 12:06:59 elevator_2] At floor 3
[D1 12:07:08 elevator_1] At floor 3
[D1 12:07:09 elevator_2] At floor 4
[D1 12:07:09 elevator_2] Stopped at floor 4
[D1 12:07:09 elevator_2] Opening doors
[D1 12:07:12 elevator_2] Opened doors
[D1 12:07:12 citizen_89] Entered elevator_2, going to floor 3
[D1 12:07:12 floor_4] citizen_89 is leaving the queue
[D1 12:07:12 floor_4] citizen_88 was served
[D1 12:07:12 elevator_2] Summoned to floor 4 from floor 4
[D1 12:07:12 citizen_88] Entered elevator_2, going to floor 1
[D1 12:07:12 floor_4] citizen_88 is leaving the queue
[D1 12:07:12 floor_4] The queue is now empty
[D1 12:07:18 elevator_1] At floor 4
[D1 12:07:18 elevator_1] Stopped at floor 4
[D1 12:07:18 elevator_1] Opening doors
[D1 12:07:21 elevator_1] Opened doors
[D1 12:07:24 elevator_2] Closing doors
[D1 12:07:27 elevator_2] Closed doors
[D1 12:07:33 elevator_1] Closing doors
[D1 12:07:36 elevator_1] Closed doors
[D1 12:07:36 elevator_1] Resting at floor 4
[D1 12:07:37 elevator_2] At floor 5
[D1 12:07:37 elevator_2] Stopped at floor 5
[D1 12:07:37 elevator_2] Opening doors
[D1 12:07:40 elevator_2] Opened doors
[D1 12:07:40 citizen_70] Left elevator_2, arrived at floor 5
[D1 12:07:52 elevator_2] Closing doors
[D1 12:07:54 citizen_106] Entered the building, will visit 4 floors in total
[D1 12:07:54 citizen_106] Time to go to floor 2 and stay there for 00:27:45
[D1 12:07:54 floor_0] citizen_106 entered the queue
[D1 12:07:54 floor_0] citizen_106 found an empty queue and will be served immediately
[D1 12:07:54 elevator_1] Summoned to floor 0 from floor 4
[D1 12:07:54 elevator_1] Sprung into motion, heading Down
[D1 12:07:55 elevator_2] Closed doors
[D1 12:07:55 elevator_2] Changing direction to Down
[D1 12:08:04 elevator_1] At floor 3
[D1 12:08:05 elevator_2] At floor 4
[D1 12:08:14 elevator_1] At floor 2
[D1 12:08:15 elevator_2] At floor 3
[D1 12:08:15 elevator_2] Stopped at floor 3
[D1 12:08:15 elevator_2] Opening doors
[D1 12:08:18 elevator_2] Opened doors
[D1 12:08:18 citizen_89] Left elevator_2, arrived at floor 3
[D1 12:08:24 elevator_1] At floor 1
[D1 12:08:30 elevator_2] Closing doors
[D1 12:08:33 elevator_2] Closed doors
[D1 12:08:34 elevator_1] At floor 0
[D1 12:08:34 elevator_1] Stopped at floor 0
[D1 12:08:34 elevator_1] Opening doors
[D1 12:08:37 elevator_1] Opened doors
[D1 12:08:37 citizen_106] Entered elevator_1, going to floor 2
[D1 12:08:37 floor_0] citizen_106 is leaving the queue
[D1 12:08:37 floor_0] The queue is now empty
[D1 12:08:43 elevator_2] At floor 2
[D1 12:08:49 citizen_45] Time to go to the ground floor and leave
[D1 12:08:49 floor_3] citizen_45 entered the queue
[D1 12:08:49 floor_3] citizen_45 found an empty queue and will be served immediately
[D1 12:08:49 elevator_2] Summoned to floor 3 from floor 2
[D1 12:08:49 elevator_1] Closing doors
[D1 12:08:52 elevator_1] Closed doors
[D1 12:08:52 elevator_1] Changing direction to Up
[D1 12:08:53 elevator_2] At floor 1
[D1 12:08:53 elevator_2] Stopped at floor 1
[D1 12:08:53 elevator_2] Opening doors
[D1 12:08:56 elevator_2] Opened doors
[D1 12:08:56 citizen_88] Left elevator_2, arrived at floor 1
[D1 12:09:02 elevator_1] At floor 1
[D1 12:09:05 citizen_66] Time to go to the ground floor and leave
[D1 12:09:05 floor_2] citizen_66 entered the queue
[D1 12:09:05 floor_2] citizen_66 found an empty queue and will be served immediately
[D1 12:09:05 elevator_1] Summoned to floor 2 from floor 1
[D1 12:09:05 elevator_2] Summoned to floor 2 from floor 1
[D1 12:09:08 elevator_2] Closing doors
[D1 12:09:11 citizen_57] Time to go to floor 3 and stay there for 00:26:15
[D1 12:09:11 floor_5] citizen_57 entered the queue
[D1 12:09:11 floor_5] citizen_57 found an empty queue and will be served immediately
[D1 12:09:11 elevator_1] Summoned to floor 5 from floor 1
[D1 12:09:11 elevator_2] Summoned to floor 5 from floor 1
[D1 12:09:11 elevator_2] Closed doors
[D1 12:09:11 elevator_2] Changing direction to Up
[D1 12:09:12 elevator_1] At floor 2
[D1 12:09:12 elevator_1] Stopped at floor 2
[D1 12:09:12 elevator_1] Opening doors
[D1 12:09:15 elevator_1] Opened doors
[D1 12:09:15 citizen_106] Left elevator_1, arrived at floor 2
[D1 12:09:15 citizen_66] Entered elevator_1, going to floor 0
[D1 12:09:15 floor_2] citizen_66 is leaving the queue
[D1 12:09:15 floor_2] The queue is now empty
[D1 12:09:16 citizen_92] Time to go to floor 3 and stay there for 00:24:54
[D1 12:09:16 floor_2] citizen_92 entered the queue
[D1 12:09:16 floor_2] citizen_92 found an empty queue and will be served immediately
[D1 12:09:16 elevator_1] Summoned to floor 2 from floor 2
[D1 12:09:16 citizen_92] Entered elevator_1, going to floor 3
[D1 12:09:16 floor_2] citizen_92 is leaving the queue
[D1 12:09:16 floor_2] The queue is now empty
[D1 12:09:21 elevator_2] At floor 2
[D1 12:09:21 elevator_2] Stopped at floor 2
[D1 12:09:21 elevator_2] Opening doors
[D1 12:09:24 elevator_2] Opened doors
[D1 12:09:27 elevator_1] Closing doors
[D1 12:09:30 elevator_1] Closed doors
[D1 12:09:32 citizen_71] Time to go to floor 2 and stay there for 00:18:29
[D1 12:09:32 floor_1] citizen_71 entered the queue
[D1 12:09:32 floor_1] citizen_71 found an empty queue and will be served immediately
[D1 12:09:32 elevator_1] Summoned to floor 1 from floor 2
[D1 12:09:32 elevator_2] Summoned to floor 1 from floor 2
[D1 12:09:36 elevator_2] Closing doors
[D1 12:09:39 elevator_2] Closed doors
[D1 12:09:40 elevator_1] At floor 3
[D1 12:09:40 elevator_1] Stopped at floor 3
[D1 12:09:40 elevator_1] Opening doors
[D1 12:09:43 citizen_77] Time to go to floor 3 and stay there for 00:32:33
[D1 12:09:43 floor_1] citizen_77 entered the queue
[D1 12:09:43 floor_1] citizen_77 is queued along with 0 other arrivals in front of it
[D1 12:09:43 elevator_1] Opened doors
[D1 12:09:43 citizen_92] Left elevator_1, arrived at floor 3
[D1 12:09:49 elevator_2] At floor 3
[D1 12:09:49 elevator_2] Stopped at floor 3
[D1 12:09:49 elevator_2] Opening doors
[D1 12:09:52 elevator_2] Opened doors
[D1 12:09:52 citizen_45] Entered elevator_2, going to floor 0
[D1 12:09:52 floor_3] citizen_45 is leaving the queue
[D1 12:09:52 floor_3] The queue is now empty
[D1 12:09:55 elevator_1] Closing doors
[D1 12:09:58 elevator_1] Closed doors
[D1 12:10:04 elevator_2] Closing doors
[D1 12:10:07 elevator_2] Closed doors
[D1 12:10:08 elevator_1] At floor 4
[D1 12:10:17 elevator_2] At floor 4
[D1 12:10:18 elevator_1] At floor 5
[D1 12:10:18 elevator_1] Stopped at floor 5
[D1 12:10:18 elevator_1] Opening doors
[D1 12:10:21 elevator_1] Opened doors
[D1 12:10:21 citizen_57] Entered elevator_1, going to floor 3
[D1 12:10:21 floor_5] citizen_57 is leaving the queue
[D1 12:10:21 floor_5] The queue is now empty
[D1 12:10:27 elevator_2] At floor 5
[D1 12:10:27 elevator_2] Stopped at floor 5
[D1 12:10:27 elevator_2] Opening doors
[D1 12:10:30 elevator_2] Opened doors
[D1 12:10:33 elevator_1] Closing doors
[D1 12:10:36 elevator_1] Closed doors
[D1 12:10:36 elevator_1] Changing direction to Down
[D1 12:10:41 citizen_107] Entered the building, will visit 6 floors in total
[D1 12:10:41 citizen_107] Time to go to floor 5 and stay there for 00:31:00
[D1 12:10:41 floor_0] citizen_107 entered the queue
[D1 12:10:41 floor_0] citizen_107 found an empty queue and will be served immediately
[D1 12:10:41 elevator_1] Summoned to floor 0 from floor 5
[D1 12:10:41 elevator_2] Summoned to floor 0 from floor 5
[D1 12:10:42 elevator_2] Closing doors
[D1 12:10:45 elevator_2] Closed doors
[D1 12:10:45 elevator_2] Changing direction to Down
[D1 12:10:46 elevator_1] At floor 4
[D1 12:10:50 citizen_79] Time to go to floor 3 and stay there for 00:13:39
[D1 12:10:50 floor_5] citizen_79 entered the queue
[D1 12:10:50 floor_5] citizen_79 found an empty queue and will be served immediately
[D1 12:10:50 elevator_2] Summoned to floor 5 from floor 5
[D1 12:10:55 elevator_2] At floor 4
[D1 12:10:56 elevator_1] At floor 3
[D1 12:10:56 elevator_1] Stopped at floor 3
[D1 12:10:56 elevator_1] Opening doors
[D1 12:10:59 elevator_1] Opened doors
[D1 12:10:59 citizen_57] Left elevator_1, arrived at floor 3
[D1 12:11:05 elevator_2] At floor 3
[D1 12:11:11 elevator_1] Closing doors
[D1 12:11:14 elevator_1] Closed doors
[D1 12:11:15 citizen_83] Time to go to floor 4 and stay there for 00:17:21
[D1 12:11:15 floor_2] citizen_83 entered the queue
[D1 12:11:15 floor_2] citizen_83 found an empty queue and will be served immediately
[D1 12:11:15 elevator_1] Summoned to floor 2 from floor 3
[D1 12:11:15 elevator_2] Summoned to floor 2 from floor 3
[D1 12:11:15 elevator_2] At floor 2
[D1 12:11:15 elevator_2] Stopped at floor 2
[D1 12:11:15 elevator_2] Opening doors
[D1 12:11:18 elevator_2] Opened doors
[D1 12:11:18 citizen_83] Entered elevator_2, going to floor 4
[D1 12:11:18 floor_2] citizen_83 is leaving the queue
[D1 12:11:18 floor_2] The queue is now empty
[D1 12:11:24 elevator_1] At floor 2
[D1 12:11:24 elevator_1] Stopped at floor 2
[D1 12:11:24 elevator_1] Opening doors
[D1 12:11:27 citizen_97] Time to go to floor 3 and stay there for 00:28:51
[D1 12:11:27 floor_2] citizen_97 entered the queue
[D1 12:11:27 floor_2] citizen_97 found an empty queue and will be served immediately
[D1 12:11:27 elevator_1] Summoned to floor 2 from floor 2
[D1 12:11:27 elevator_2] Summoned to floor 2 from floor 2
[D1 12:11:27 citizen_97] Entered elevator_2, going to floor 3
[D1 12:11:27 floor_2] citizen_97 is leaving the queue
[D1 12:11:27 floor_2] The queue is now empty
[D1 12:11:27 elevator_1] Opened doors
[D1 12:11:30 elevator_2] Closing doors
[D1 12:11:33 elevator_2] Closed doors
[D1 12:11:39 elevator_1] Closing doors
[D1 12:11:42 elevator_1] Closed doors
[D1 12:11:43 elevator_2] At floor 1
[D1 12:11:43 elevator_2] Stopped at floor 1
[D1 12:11:43 elevator_2] Opening doors
[D1 12:11:46 elevator_2] Opened doors
[D1 12:11:46 citizen_71] Entered elevator_2, going to floor 2
[D1 12:11:46 floor_1] citizen_71 is leaving the queue
[D1 12:11:46 floor_1] citizen_77 was served
[D1 12:11:46 elevator_2] Summoned to floor 1 from floor 1
[D1 12:11:46 citizen_77] Cannot enter elevator_2, it is full
[D1 12:11:46 citizen_77] All elevators were full, trying to summon them again
[D1 12:11:52 elevator_1] At floor 1
[D1 12:11:52 elevator_1] Stopped at floor 1
[D1 12:11:52 elevator_1] Opening doors
[D1 12:11:55 elevator_1] Opened doors
[D1 12:11:57 citizen_52] Time to go to floor 4 and stay there for 00:45:18
[D1 12:11:57 floor_3] citizen_52 entered the queue
[D1 12:11:57 floor_3] citizen_52 found an empty queue and will be served immediately
[D1 12:11:57 elevator_1] Summoned to floor 3 from floor 1
[D1 12:11:57 elevator_2] Summoned to floor 3 from floor 1
[D1 12:11:58 elevator_2] Closing doors
[D1 12:12:01 elevator_2] Closed doors
[D1 12:12:02 elevator_1] Summoned to floor 1 from floor 1
[D1 12:12:02 elevator_2] Summoned to floor 1 from floor 1
[D1 12:12:02 citizen_77] Entered elevator_1, going to floor 3
[D1 12:12:02 floor_1] citizen_77 is leaving the queue
[D1 12:12:02 floor_1] The queue is now empty
[D1 12:12:07 elevator_1] Closing doors
[D1 12:12:10 elevator_1] Closed doors
[D1 12:12:11 elevator_2] At floor 0
[D1 12:12:11 elevator_2] Stopped at floor 0
[D1 12:12:11 elevator_2] Opening doors
[D1 12:12:14 elevator_2] Opened doors
[D1 12:12:14 citizen_45] Left elevator_2, arrived at floor 0
[D1 12:12:14 citizen_45] Left the building
[D1 12:12:14 citizen_107] Entered elevator_2, going to floor 5
[D1 12:12:14 floor_0] citizen_107 is leaving the queue
[D1 12:12:14 floor_0] The queue is now empty
[D1 12:12:20 elevator_1] At floor 0
[D1 12:12:20 elevator_1] Stopped at floor 0
[D1 12:12:20 elevator_1] Opening doors
[D1 12:12:23 elevator_1] Opened doors
[D1 12:12:23 citizen_66] Left elevator_1, arrived at floor 0
[D1 12:12:23 citizen_66] Left the building
[D1 12:12:26 elevator_2] Closing doors
[D1 12:12:29 elevator_2] Closed doors
[D1 12:12:29 elevator_2] Changing direction to Up
[D1 12:12:35 elevator_1] Closing doors
[D1 12:12:38 elevator_1] Closed doors
[D1 12:12:38 elevator_1] Changing direction to Up
[D1 12:12:39 elevator_2] At floor 1
[D1 12:12:39 elevator_2] Stopped at floor 1
[D1 12:12:39 elevator_2] Opening doors
[D1 12:12:42 elevator_2] Opened doors
[D1 12:12:48 elevator_1] At floor 1
[D1 12:12:54 elevator_2] Closing doors
[D1 12:12:57 elevator_2] Closed doors
[D1 12:12:58 elevator_1] At floor 2
[D1 12:13:07 elevator_2] At floor 2
[D1 12:13:07 elevator_2] Stopped at floor 2
[D1 12:13:07 elevator_2] Opening doors
[D1 12:13:08 elevator_1] At floor 3
[D1 12:13:08 elevator_1] Stopped at floor 3
[D1 12:13:08 elevator_1] Opening doors
[D1 12:13:10 elevator_2] Opened doors
[D1 12:13:10 citizen_71] Left elevator_2, arrived at floor 2
[D1 12:13:11 elevator_1] Opened doors
[D1 12:13:11 citizen_77] Left elevator_1, arrived at floor 3
[D1 12:13:11 citizen_52] Entered elevator_1, going to floor 4
[D1 12:13:11 floor_3] citizen_52 is leaving the queue
[D1 12:13:11 floor_3] The queue is now empty
[D1 12:13:22 elevator_2] Closing doors
[D1 12:13:23 elevator_1] Closing doors
[D1 12:13:25 elevator_2] Closed doors
[D1 12:13:26 citizen_44] Time to go to floor 4 and stay there for 00:14:48
[D1 12:13:26 floor_1] citizen_44 entered the queue
[D1 12:13:26 floor_1] citizen_44 found an empty queue and will be served immediately
[D1 12:13:26 elevator_2] Summoned to floor 1 from floor 2
[D1 12:13:26 elevator_1] Closed doors
[D1 12:13:33 citizen_108] Entered the building, will visit 3 floors in total
[D1 12:13:33 citizen_108] Time to go to floor 3 and stay there for 00:14:08
[D1 12:13:33 floor_0] citizen_108 entered the queue
[D1 12:13:33 floor_0] citizen_108 found an empty queue and will be served immediately
[D1 12:13:33 elevator_2] Summoned to floor 0 from floor 2
[D1 12:13:35 elevator_2] At floor 3
[D1 12:13:35 elevator_2] Stopped at floor 3
[D1 12:13:35 elevator_2] Opening doors
[D1 12:13:36 elevator_1] At floor 4
[D1 12:13:36 elevator_1] Stopped at floor 4
[D1 12:13:36 elevator_1] Opening doors
[D1 12:13:38 elevator_2] Opened doors
[D1 12:13:38 citizen_97] Left elevator_2, arrived at floor 3
[D1 12:13:39 elevator_1] Opened doors
[D1 12:13:39 citizen_52] Left elevator_1, arrived at floor 4
[D1 12:13:50 elevator_2] Closing doors
[D1 12:13:51 elevator_1] Closing doors
[D1 12:13:53 elevator_2] Closed doors
[D1 12:13:54 elevator_1] Closed doors
[D1 12:13:54 elevator_1] Resting at floor 4
[D1 12:14:03 elevator_2] At floor 4
[D1 12:14:03 elevator_2] Stopped at floor 4
[D1 12:14:03 elevator_2] Opening doors
[D1 12:14:06 elevator_2] Opened doors
[D1 12:14:06 citizen_83] Left elevator_2, arrived at floor 4
[D1 12:14:18 elevator_2] Closing doors
[D1 12:14:21 elevator_2] Closed doors
[D1 12:14:31 elevator_2] At floor 5
[D1 12:14:31 elevator_2] Stopped at floor 5
[D1 12:14:31 elevator_2] Opening doors
[D1 12:14:32 citizen_98] Time to go to floor 4 and stay there for 00:33:01
[D1 12:14:32 floor_3] citizen_98 entered the queue
[D1 12:14:32 floor_3] citizen_98 found an empty queue and will be served immediately
[D1 12:14:32 elevator_1] Summoned to floor 3 from floor 4
[D1 12:14:32 elevator_1] Sprung into motion, heading Down
[D1 12:14:34 elevator_2] Opened doors
[D1 12:14:34 citizen_107] Left elevator_2, arrived at floor 5
[D1 12:14:34 citizen_79] Entered elevator_2, going to floor 3
[D1 12:14:34 floor_5] citizen_79 is leaving the queue
[D1 12:14:34 floor_5] The queue is now empty
[D1 12:14:42 elevator_1] At floor 3
[D1 12:14:42 elevator_1] Stopped at floor 3
[D1 12:14:42 elevator_1] Opening doors
[D1 12:14:43 citizen_96] Time to go to floor 2 and stay there for 00:30:09
[D1 12:14:43 floor_4] citizen_96 entered the queue
[D1 12:14:43 floor_4] citizen_96 found an empty queue and will be served immediately
[D1 12:14:43 elevator_1] Summoned to floor 4 from floor 3
[D1 12:14:43 elevator_2] Summoned to floor 4 from floor 5
[D1 12:14:45 elevator_1] Opened doors
[D1 12:14:45 citizen_98] Entered elevator_1, going to floor 4
[D1 12:14:45 floor_3] citizen_98 is leaving the queue
[D1 12:14:45 floor_3] The queue is now empty
[D1 12:14:46 elevator_2] Closing doors
[D1 12:14:49 elevator_2] Closed doors
[D1 12:14:49 elevator_2] Changing direction to Down
[D1 12:14:57 elevator_1] Closing doors
[D1 12:14:59 elevator_2] At floor 4
[D1 12:14:59 elevator_2] Stopped at floor 4
[D1 12:14:59 elevator_2] Opening doors
[D1 12:15:00 elevator_1] Closed doors
[D1 12:15:00 elevator_1] Changing direction to Up
[D1 12:15:02 elevator_2] Opened doors
[D1 12:15:02 citizen_96] Entered elevator_2, going to floor 2
[D1 12:15:02 floor_4] citizen_96 is leaving the queue
[D1 12:15:02 floor_4] The queue is now empty
[D1 12:15:07 citizen_109] Entered the building, will visit 5 floors in total
[D1 12:15:07 citizen_109] Time to go to floor 2 and stay there for 00:23:53
[D1 12:15:07 floor_0] citizen_109 entered the queue
[D1 12:15:07 floor_0] citizen_109 is queued along with 0 other arrivals in front of it
[D1 12:15:10 elevator_1] At floor 4
[D1 12:15:10 elevator_1] Stopped at floor 4
[D1 12:15:10 elevator_1] Opening doors
[D1 12:15:13 elevator_1] Opened doors
[D1 12:15:13 citizen_98] Left elevator_1, arrived at floor 4
[D1 12:15:14 elevator_2] Closing doors
[D1 12:15:17 elevator_2] Closed doors
[D1 12:15:22 citizen_51] Time to go to floor 1 and stay there for 00:19:22
[D1 12:15:22 floor_4] citizen_51 entered the queue
[D1 12:15:22 floor_4] citizen_51 found an empty queue and will be served immediately
[D1 12:15:22 elevator_1] Summoned to floor 4 from floor 4
[D1 12:15:22 elevator_2] Summoned to floor 4 from floor 4
[D1 12:15:22 citizen_51] Entered elevator_1, going to floor 1
[D1 12:15:22 floor_4] citizen_51 is leaving the queue
[D1 12:15:22 floor_4] The queue is now empty
[D1 12:15:25 elevator_1] Closing doors
[D1 12:15:27 elevator_2] At floor 3
[D1 12:15:27 elevator_2] Stopped at floor 3
[D1 12:15:27 elevator_2] Opening doors
[D1 12:15:28 elevator_1] Closed doors
[D1 12:15:28 elevator_1] Changing direction to Down
[D1 12:15:30 elevator_2] Opened doors
[D1 12:15:30 citizen_79] Left elevator_2, arrived at floor 3
[D1 12:15:38 elevator_1] At floor 3
[D1 12:15:42 elevator_2] Closing doors
[D1 12:15:45 elevator_2] Closed doors
[D1 12:15:48 elevator_1] At floor 2
[D1 12:15:55 elevator_2] At floor 2
[D1 12:15:55 elevator_2] Stopped at floor 2
[D1 12:15:55 elevator_2] Opening doors
[D1 12:15:58 elevator_1] At floor 1
[D1 12:15:58 elevator_1] Stopped at floor 1
[D1 12:15:58 elevator_1] Opening doors
[D1 12:15:58 elevator_2] Opened doors
[D1 12:15:58 citizen_96] Left elevator_2, arrived at floor 2
[D1 12:16:01 elevator_1] Opened doors
[D1 12:16:01 citizen_51] Left elevator_1, arrived at floor 1
[D1 12:16:10 elevator_2] Closing doors
[D1 12:16:13 elevator_1] Closing doors
[D1 12:16:13 elevator_2] Closed doors
[D1 12:16:16 elevator_1] Closed doors
[D1 12:16:16 elevator_1] Resting at floor 1
[D1 12:16:23 elevator_2] At floor 1
[D1 12:16:23 elevator_2] Stopped at floor 1
[D1 12:16:23 elevator_2] Opening doors
[D1 12:16:26 elevator_2] Opened doors
[D1 12:16:26 citizen_44] Entered elevator_2, going to floor 4
[D1 12:16:26 floor_1] citizen_44 is leaving the queue
[D1 12:16:26 floor_1] The queue is now empty
[D1 12:16:29 citizen_91] Time to go to floor 2 and stay there for 00:29:09
[D1 12:16:29 floor_1] citizen_91 entered the queue
[D1 12:16:29 floor_1] citizen_91 found an empty queue and will be served immediately
[D1 12:16:29 elevator_1] Summoned to floor 1 from floor 1
[D1 12:16:29 elevator_1] Opening doors
[D1 12:16:29 elevator_2] Summoned to floor 1 from floor 1
[D1 12:16:29 citizen_91] Entered elevator_2, going to floor 2
[D1 12:16:29 floor_1] citizen_91 is leaving the queue
[D1 12:16:29 floor_1] The queue is now empty
[D1 12:16:30 citizen_110] Entered the building, will visit 4 floors in total
[D1 12:16:30 citizen_110] Time to go to floor 3 and stay there for 00:26:26
[D1 12:16:30 floor_0] citizen_110 entered the queue
[D1 12:16:30 floor_0] citizen_110 is queued along with 1 other arrivals in front of it
[D1 12:16:32 elevator_1] Opened doors
[D1 12:16:35 citizen_69] Time to go to floor 4 and stay there for 00:26:48
[D1 12:16:35 floor_5] citizen_69 entered the queue
[D1 12:16:35 floor_5] citizen_69 found an empty queue and will be served immediately
[D1 12:16:35 elevator_1] Summoned to floor 5 from floor 1
[D1 12:16:35 elevator_2] Summoned to floor 5 from floor 1
[D1 12:16:38 elevator_2] Closing doors
[D1 12:16:41 elevator_2] Closed doors
[D1 12:16:44 elevator_1] Closing doors
[D1 12:16:47 elevator_1] Closed doors
[D1 12:16:47 elevator_1] Sprung into motion, heading Up
[D1 12:16:51 elevator_2] At floor 0
[D1 12:16:51 elevator_2] Stopped at floor 0
[D1 12:16:51 elevator_2] Opening doors
[D1 12:16:54 elevator_2] Opened doors
[D1 12:16:54 citizen_108] Entered elevator_2, going to floor 3
[D1 12:16:54 floor_0] citizen_108 is leaving the queue
[D1 12:16:54 floor_0] citizen_109 was served
[D1 12:16:54 elevator_2] Summoned to floor 0 from floor 0
[D1 12:16:54 citizen_109] Entered elevator_2, going to floor 2
[D1 12:16:54 floor_0] citizen_109 is leaving the queue
[D1 12:16:54 floor_0] citizen_110 was served
[D1 12:16:54 elevator_2] Summoned to floor 0 from floor 0
[D1 12:16:54 citizen_110] Cannot enter elevator_2, it is full
[D1 12:16:54 citizen_110] All elevators were full, trying to summon them again
[D1 12:16:57 elevator_1] At floor 2
[D1 12:17:06 elevator_2] Closing doors
[D1 12:17:07 elevator_1] At floor 3
[D1 12:17:09 elevator_2] Closed doors
[D1 12:17:09 elevator_2] Changing direction to Up
[D1 12:17:10 citizen_54] Time to go to the ground floor and leave
[D1 12:17:10 floor_2] citizen_54 entered the queue
[D1 12:17:10 floor_2] citizen_54 found an empty queue and will be served immediately
[D1 12:17:10 elevator_1] Summoned to floor 2 from floor 3
[D1 12:17:10 elevator_2] Summoned to floor 0 from floor 0
[D1 12:17:17 elevator_1] At floor 4
[D1 12:17:19 elevator_2] At floor 1
[D1 12:17:27 elevator_1] At floor 5
[D1 12:17:27 elevator_1] Stopped at floor 5
[D1 12:17:27 elevator_1] Opening doors
[D1 12:17:28 citizen_89] Time to go to floor 1 and stay there for 00:29:33
[D1 12:17:28 floor_3] citizen_89 entered the queue
[D1 12:17:28 floor_3] citizen_89 found an empty queue and will be served immediately
[D1 12:17:28 elevator_1] Summoned to floor 3 from floor 5
[D1 12:17:28 elevator_2] Summoned to floor 3 from floor 1
[D1 12:17:29 elevator_2] At floor 2
[D1 12:17:29 elevator_2] Stopped at floor 2
[D1 12:17:29 elevator_2] Opening doors
[D1 12:17:30 elevator_1] Opened doors
[D1 12:17:30 citizen_69] Entered elevator_1, going to floor 4
[D1 12:17:30 floor_5] citizen_69 is leaving the queue
[D1 12:17:30 floor_5] The queue is now empty
[D1 12:17:32 elevator_2] Opened doors
[D1 12:17:32 citizen_91] Left elevator_2, arrived at floor 2
[D1 12:17:32 citizen_109] Left elevator_2, arrived at floor 2
[D1 12:17:40 citizen_64] Time to go to the ground floor and leave
[D1 12:17:40 floor_3] citizen_64 entered the queue
[D1 12:17:40 floor_3] citizen_64 is queued along with 0 other arrivals in front of it
[D1 12:17:42 elevator_1] Closing doors
[D1 12:17:44 elevator_2] Closing doors
[D1 12:17:45 elevator_1] Closed doors
[D1 12:17:45 elevator_1] Changing direction to Down
[D1 12:17:47 elevator_2] Closed doors
[D1 12:17:55 elevator_1] At floor 4
[D1 12:17:55 elevator_1] Stopped at floor 4
[D1 12:17:55 elevator_1] Opening doors
[D1 12:17:57 elevator_2] At floor 3
[D1 12:17:57 elevator_2] Stopped at floor 3
[D1 12:17:57 elevator_2] Opening doors
[D1 12:17:58 elevator_1] Opened doors
[D1 12:17:58 citizen_69] Left elevator_1, arrived at floor 4
[D1 12:18:00 elevator_2] Opened doors
[D1 12:18:00 citizen_108] Left elevator_2, arrived at floor 3
[D1 12:18:00 citizen_89] Entered elevator_2, going to floor 1
[D1 12:18:00 floor_3] citizen_89 is leaving the queue
[D1 12:18:00 floor_3] citizen_64 was served
[D1 12:18:00 elevator_2] Summoned to floor 3 from floor 3
[D1 12:18:00 citizen_64] Entered elevator_2, going to floor 0
[D1 12:18:00 floor_3] citizen_64 is leaving the queue
[D1 12:18:00 floor_3] The queue is now empty
[D1 12:18:10 elevator_1] Closing doors
[D1 12:18:12 elevator_2] Closing doors
[D1 12:18:13 elevator_1] Closed doors
[D1 12:18:15 elevator_2] Closed doors
[D1 12:18:23 elevator_1] At floor 3
[D1 12:18:23 elevator_1] Stopped at floor 3
[D1 12:18:23 elevator_1] Opening doors
[D1 12:18:25 citizen_68] Time to go to floor 1 and stay there for 00:31:54
[D1 12:18:25 floor_4] citizen_68 entered the queue
[D1 12:18:25 floor_4] citizen_68 found an empty queue and will be served immediately
[D1 12:18:25 elevator_1] Summoned to floor 4 from floor 3
[D1 12:18:25 elevator_2] Summoned to floor 4 from floor 3
[D1 12:18:25 elevator_2] At floor 4
[D1 12:18:25 elevator_2] Stopped at floor 4
[D1 12:18:25 elevator_2] Opening doors
[D1 12:18:26 elevator_1] Opened doors
[D1 12:18:28 elevator_2] Opened doors
[D1 12:18:28 citizen_44] Left elevator_2, arrived at floor 4
[D1 12:18:28 citizen_68] Entered elevator_2, going to floor 1
[D1 12:18:28 floor_4] citizen_68 is leaving the queue
[D1 12:18:28 floor_4] The queue is now empty
[D1 12:18:38 elevator_1] Closing doors
[D1 12:18:40 elevator_2] Closing doors
[D1 12:18:41 elevator_1] Closed doors
[D1 12:18:43 elevator_2] Closed doors
[D1 12:18:51 elevator_1] At floor 2
[D1 12:18:51 elevator_1] Stopped at floor 2
[D1 12:18:51 elevator_1] Opening doors
[D1 12:18:53 elevator_2] At floor 5
[D1 12:18:53 elevator_2] Stopped at floor 5
[D1 12:18:53 elevator_2] Opening doors
[D1 12:18:54 elevator_1] Opened doors
[D1 12:18:54 citizen_54] Entered elevator_1, going to floor 0
[D1 12:18:54 floor_2] citizen_54 is leaving the queue
[D1 12:18:54 floor_2] The queue is now empty
[D1 12:18:56 elevator_2] Opened doors
[D1 12:19:00 citizen_38] Time to go to the ground floor and leave
[D1 12:19:00 floor_4] citizen_38 entered the queue
[D1 12:19:00 floor_4] citizen_38 found an empty queue and will be served immediately
[D1 12:19:00 elevator_2] Summoned to floor 4 from floor 5
[D1 12:19:06 elevator_1] Closing doors
[D1 12:19:08 elevator_2] Closing doors
[D1 12:19:09 elevator_1] Closed doors
[D1 12:19:11 elevator_2] Closed doors
[D1 12:19:11 elevator_2] Changing direction to Down
[D1 12:19:19 elevator_1] At floor 1
[D1 12:19:21 elevator_2] At floor 4
[D1 12:19:21 elevator_2] Stopped at floor 4
[D1 12:19:21 elevator_2] Opening doors
[D1 12:19:24 elevator_2] Opened doors
[D1 12:19:24 citizen_38] Entered elevator_2, going to floor 0
[D1 12:19:24 floor_4] citizen_38 is leaving the queue
[D1 12:19:24 floor_4] The queue is now empty
[D1 12:19:29 elevator_1] At floor 0
[D1 12:19:29 elevator_1] Stopped at floor 0
[D1 12:19:29 elevator_1] Opening doors
[D1 12:19:32 elevator_1] Opened doors
[D1 12:19:32 citizen_54] Left elevator_1, arrived at floor 0
[D1 12:19:32 citizen_54] Left the building
[D1 12:19:36 elevator_2] Closing doors
[D1 12:19:39 elevator_2] Closed doors
[D1 12:19:44 elevator_1] Closing doors
[D1 12:19:47 elevator_1] Closed doors
[D1 12:19:47 elevator_1] Changing direction to Up
[D1 12:19:49 elevator_2] At floor 3
[D1 12:19:50 citizen_111] Entered the building, will visit 4 floors in total
[D1 12:19:50 citizen_111] Time to go to floor 2 and stay there for 00:35:26
[D1 12:19:50 floor_0] citizen_111 entered the queue
[D1 12:19:50 floor_0] citizen_111 is queued along with 0 other arrivals in front of it
[D1 12:19:57 elevator_1] At floor 1
[D1 12:19:59 elevator_2] At floor 2
[D1 12:20:07 elevator_1] At floor 2
[D1 12:20:09 elevator_2] At floor 1
[D1 12:20:09 elevator_2] Stopped at floor 1
[D1 12:20:09 elevator_2] Opening doors
[D1 12:20:12 elevator_2] Opened doors
[D1 12:20:12 citizen_89] Left elevator_2, arrived at floor 1
[D1 12:20:12 citizen_68] Left elevator_2, arrived at floor 1
[D1 12:20:17 elevator_1] At floor 3
[D1 12:20:24 elevator_2] Closing doors
[D1 12:20:27 elevator_1] At floor 4
[D1 12:20:27 elevator_1] Stopped at floor 4
[D1 12:20:27 elevator_1] Opening doors
[D1 12:20:27 elevator_2] Closed doors
[D1 12:20:30 elevator_1] Opened doors
[D1 12:20:37 elevator_2] At floor 0
[D1 12:20:37 elevator_2] Stopped at floor 0
[D1 12:20:37 elevator_2] Opening doors
[D1 12:20:40 elevator_2] Opened doors
[D1 12:20:40 citizen_64] Left elevator_2, arrived at floor 0
[D1 12:20:40 citizen_38] Left elevator_2, arrived at floor 0
[D1 12:20:40 citizen_64] Left the building
[D1 12:20:40 citizen_38] Left the building
[D1 12:20:40 citizen_110] Entered elevator_2, going to floor 3
[D1 12:20:40 floor_0] citizen_110 is leaving the queue
[D1 12:20:40 floor_0] citizen_111 was served
[D1 12:20:40 elevator_2] Summoned to floor 0 from floor 0
[D1 12:20:40 citizen_111] Entered elevator_2, going to floor 2
[D1 12:20:40 floor_0] citizen_111 is leaving the queue
[D1 12:20:40 floor_0] The queue is now empty
[D1 12:20:42 elevator_1] Closing doors
[D1 12:20:45 elevator_1] Closed doors
[D1 12:20:45 elevator_1] Resting at floor 4
[D1 12:20:52 elevator_2] Closing doors
[D1 12:20:55 elevator_2] Closed doors
[D1 12:20:55 elevator_2] Changing direction to Up
[D1 12:21:03 citizen_112] Entered the building, will visit 3 floors in total
[D1 12:21:03 citizen_112] Time to go to floor 5 and stay there for 00:37:53
[D1 12:21:03 floor_0] citizen_112 entered the queue
[D1 12:21:03 floor_0] citizen_112 found an empty queue and will be served immediately
[D1 12:21:03 elevator_2] Summoned to floor 0 from floor 0
[D1 12:21:05 elevator_2] At floor 1
[D1 12:21:15 elevator_2] At floor 2
[D1 12:21:15 elevator_2] Stopped at floor 2
[D1 12:21:15 elevator_2] Opening doors
[D1 12:21:18 elevator_2] Opened doors
[D1 12:21:18 citizen_111] Left elevator_2, arrived at floor 2
[D1 12:21:30 elevator_2] Closing doors
[D1 12:21:33 elevator_2] Closed doors
[D1 12:21:42 citizen_72] Time to go to floor 1 and stay there for 00:23:45
[D1 12:21:42 floor_2] citizen_72 entered the queue
[D1 12:21:42 floor_2] citizen_72 found an empty queue and will be served immediately
[D1 12:21:42 elevator_2] Summoned to floor 2 from floor 2
[D1 12:21:43 elevator_2] At floor 3
[D1 12:21:43 elevator_2] Stopped at floor 3
[D1 12:21:43 elevator_2] Opening doors
[D1 12:21:44 citizen_95] Time to go to floor 3 and stay there for 00:40:22
[D1 12:21:44 floor_5] citizen_95 entered the queue
[D1 12:21:44 floor_5] citizen_95 found an empty queue and will be served immediately
[D1 12:21:44 elevator_1] Summoned to floor 5 from floor 4
[D1 12:21:44 elevator_1] Sprung into motion, heading Up
[D1 12:21:46 elevator_2] Opened doors
[D1 12:21:46 citizen_110] Left elevator_2, arrived at floor 3
[D1 12:21:48 citizen_81] Time to go to floor 1 and stay there for 00:25:48
[D1 12:21:48 floor_4] citizen_81 entered the queue
[D1 12:21:48 floor_4] citizen_81 found an empty queue and will be served immediately
[D1 12:21:48 elevator_1] Summoned to floor 4 from floor 4
[D1 12:21:54 elevator_1] At floor 5
[D1 12:21:54 elevator_1] Stopped at floor 5
[D1 12:21:54 elevator_1] Opening doors
[D1 12:21:57 elevator_1] Opened doors
[D1 12:21:57 citizen_95] Entered elevator_1, going to floor 3
[D1 12:21:57 floor_5] citizen_95 is leaving the queue
[D1 12:21:57 floor_5] The queue is now empty
[D1 12:21:58 elevator_2] Closing doors
[D1 12:22:01 elevator_2] Closed doors
[D1 12:22:01 elevator_2] Changing direction to Down
[D1 12:22:03 citizen_82] Time to go to floor 2 and stay there for 00:24:01
[D1 12:22:03 floor_4] citizen_82 entered the queue
[D1 12:22:03 floor_4] citizen_82 is queued along with 0 other arrivals in front of it
[D1 12:22:09 elevator_1] Closing doors
[D1 12:22:11 elevator_2] At floor 2
[D1 12:22:11 elevator_2] Stopped at floor 2
[D1 12:22:11 elevator_2] Opening doors
[D1 12:22:12 elevator_1] Closed doors
[D1 12:22:12 elevator_1] Changing direction to Down
[D1 12:22:14 elevator_2] Opened doors
[D1 12:22:14 citizen_72] Entered elevator_2, going to floor 1
[D1 12:22:14 floor_2] citizen_72 is leaving the queue
[D1 12:22:14 floor_2] The queue is now empty
[D1 12:22:15 citizen_94] Time to go to floor 4 and stay there for 00:35:41
[D1 12:22:15 floor_3] citizen_94 entered the queue
[D1 12:22:15 floor_3] citizen_94 found an empty queue and will be served immediately
[D1 12:22:15 elevator_2] Summoned to floor 3 from floor 2
[D1 12:22:22 elevator_1] At floor 4
[D1 12:22:22 elevator_1] Stopped at floor 4
[D1 12:22:22 elevator_1] Opening doors
[D1 12:22:24 citizen_75] Time to go to the ground floor and leave
[D1 12:22:24 floor_3] citizen_75 entered the queue
[D1 12:22:24 floor_3] citizen_75 is queued along with 0 other arrivals in front of it
[D1 12:22:25 elevator_1] Opened doors
[D1 12:22:25 citizen_73] Time to go to the ground floor and leave
[D1 12:22:25 floor_2] citizen_73 entered the queue
[D1 12:22:25 floor_2] citizen_73 found an empty queue and will be served immediately
[D1 12:22:25 elevator_2] Summoned to floor 2 from floor 2
[D1 12:22:25 citizen_73] Entered elevator_2, going to floor 0
[D1 12:22:25 floor_2] citizen_73 is leaving the queue
[D1 12:22:25 floor_2] The queue is now empty
[D1 12:22:25 citizen_81] Entered elevator_1, going to floor 1
[D1 12:22:25 floor_4] citizen_81 is leaving the queue
[D1 12:22:25 floor_4] citizen_82 was served
[D1 12:22:25 elevator_1] Summoned to floor 4 from floor 4
[D1 12:22:25 citizen_82] Entered elevator_1, going to floor 2
[D1 12:22:25 floor_4] citizen_82 is leaving the queue
[D1 12:22:25 floor_4] The queue is now empty
[D1 12:22:26 elevator_2] Closing doors
[D1 12:22:29 elevator_2] Closed doors
[D1 12:22:37 elevator_1] Closing doors
[D1 12:22:39 elevator_2] At floor 1
[D1 12:22:39 elevator_2] Stopped at floor 1
[D1 12:22:39 elevator_2] Opening doors
[D1 12:22:40 elevator_1] Closed doors
[D1 12:22:42 elevator_2] Opened doors
[D1 12:22:42 citizen_72] Left elevator_2, arrived at floor 1
[D1 12:22:50 elevator_1] At floor 3
[D1 12:22:50 elevator_1] Stopped at floor 3
[D1 12:22:50 elevator_1] Opening doors
[D1 12:22:53 elevator_1] Opened doors
[D1 12:22:53 citizen_95] Left elevator_1, arrived at floor 3
[D1 12:22:54 elevator_2] Closing doors
[D1 12:22:57 elevator_2] Closed doors
[D1 12:23:04 citizen_105] Time to go to floor 4 and stay there for 00:18:05
[D1 12:23:04 floor_1] citizen_105 entered the queue
[D1 12:23:04 floor_1] citizen_105 found an empty queue and will be served immediately
[D1 12:23:04 elevator_2] Summoned to floor 1 from floor 1
[D1 12:23:05 elevator_1] Closing doors
[D1 12:23:07 elevator_2] At floor 0
[D1 12:23:07 elevator_2] Stopped at floor 0
[D1 12:23:07 elevator_2] Opening doors
[D1 12:23:08 elevator_1] Closed doors
[D1 12:23:10 elevator_2] Opened doors
[D1 12:23:10 citizen_73] Left elevator_2, arrived at floor 0
[D1 12:23:10 citizen_73] Left the building
[D1 12:23:10 citizen_112] Entered elevator_2, going to floor 5
[D1 12:23:10 floor_0] citizen_112 is leaving the queue
[D1 12:23:10 floor_0] The queue is now empty
[D1 12:23:18 elevator_1] At floor 2
[D1 12:23:18 elevator_1] Stopped at floor 2
[D1 12:23:18 elevator_1] Opening doors
[D1 12:23:21 elevator_1] Opened doors
[D1 12:23:21 citizen_82] Left elevator_1, arrived at floor 2
[D1 12:23:22 elevator_2] Closing doors
[D1 12:23:25 elevator_2] Closed doors
[D1 12:23:25 elevator_2] Changing direction to Up
[D1 12:23:33 elevator_1] Closing doors
[D1 12:23:35 elevator_2] At floor 1
[D1 12:23:35 elevator_2] Stopped at floor 1
[D1 12:23:35 elevator_2] Opening doors
[D1 12:23:36 elevator_1] Closed doors
[D1 12:23:38 elevator_2] Opened doors
[D1 12:23:38 citizen_105] Entered elevator_2, going to floor 4
[D1 12:23:38 floor_1] citizen_105 is leaving the queue
[D1 12:23:38 floor_1] The queue is now empty
[D1 12:23:46 elevator_1] At floor 1
[D1 12:23:46 elevator_1] Stopped at floor 1
[D1 12:23:46 elevator_1] Opening doors
[D1 12:23:49 elevator_1] Opened doors
[D1 12:23:49 citizen_81] Left elevator_1, arrived at floor 1
[D1 12:23:50 citizen_50] Time to go to the ground floor and leave
[D1 12:23:50 floor_5] citizen_50 entered the queue
[D1 12:23:50 floor_5] citizen_50 found an empty queue and will be served immediately
[D1 12:23:50 elevator_1] Summoned to floor 5 from floor 1
[D1 12:23:50 elevator_2] Summoned to floor 5 from floor 1
[D1 12:23:50 elevator_2] Closing doors
[D1 12:23:53 elevator_2] Closed doors
[D1 12:24:01 elevator_1] Closing doors
[D1 12:24:03 elevator_2] At floor 2
[D1 12:24:04 elevator_1] Closed doors
[D1 12:24:04 elevator_1] Changing direction to Up
[D1 12:24:13 elevator_2] At floor 3
[D1 12:24:13 elevator_2] Stopped at floor 3
[D1 12:24:13 elevator_2] Opening doors
[D1 12:24:14 elevator_1] At floor 2
[D1 12:24:16 elevator_2] Opened doors
[D1 12:24:16 citizen_94] Entered elevator_2, going to floor 4
[D1 12:24:16 floor_3] citizen_94 is leaving the queue
[D1 12:24:16 floor_3] citizen_75 was served
[D1 12:24:16 elevator_2] Summoned to floor 3 from floor 3
[D1 12:24:16 citizen_75] Entered elevator_2, going to floor 0
[D1 12:24:16 floor_3] citizen_75 is leaving the queue
[D1 12:24:16 floor_3] The queue is now empty
[D1 12:24:24 elevator_1] At floor 3
[D1 12:24:28 elevator_2] Closing doors
[D1 12:24:31 elevator_2] Closed doors
[D1 12:24:34 elevator_1] At floor 4
[D1 12:24:41 elevator_2] At floor 4
[D1 12:24:41 elevator_2] Stopped at floor 4
[D1 12:24:41 elevator_2] Opening doors
[D1 12:24:42 citizen_67] Time to go to floor 3 and stay there for 00:19:02
[D1 12:24:42 floor_5] citizen_67 entered the queue
[D1 12:24:42 floor_5] citizen_67 is queued along with 0 other arrivals in front of it
[D1 12:24:44 elevator_1] At floor 5
[D1 12:24:44 elevator_1] Stopped at floor 5
[D1 12:24:44 elevator_1] Opening doors
[D1 12:24:44 elevator_2] Opened doors
[D1 12:24:44 citizen_105] Left elevator_2, arrived at floor 4
[D1 12:24:44 citizen_94] Left elevator_2, arrived at floor 4
[D1 12:24:47 elevator_1] Opened doors
[D1 12:24:47 citizen_50] Entered elevator_1, going to floor 0
[D1 12:24:47 floor_5] citizen_50 is leaving the queue
[D1 12:24:47 floor_5] citizen_67 was served
[D1 12:24:47 elevator_1] Summoned to floor 5 from floor 5
[D1 12:24:47 citizen_67] Entered elevator_1, going to floor 3
[D1 12:24:47 floor_5] citizen_67 is leaving the queue
[D1 12:24:47 floor_5] The queue is now empty
[D1 12:24:56 elevator_2] Closing doors
[D1 12:24:59 elevator_1] Closing doors
[D1 12:24:59 elevator_2] Closed doors
[D1 12:25:02 elevator_1] Closed doors
[D1 12:25:02 elevator_1] Changing direction to Down
[D1 12:25:09 elevator_2] At floor 5
[D1 12:25:09 elevator_2] Stopped at floor 5
[D1 12:25:09 elevator_2] Opening doors
[D1 12:25:12 elevator_1] At floor 4
[D1 12:25:12 elevator_2] Opened doors
[D1 12:25:12 citizen_112] Left elevator_2, arrived at floor 5
[D1 12:25:22 elevator_1] At floor 3
[D1 12:25:22 elevator_1] Stopped at floor 3
[D1 12:25:22 elevator_1] Opening doors
[D1 12:25:24 elevator_2] Closing doors
[D1 12:25:25 citizen_62] Time to go to the ground floor and leave
[D1 12:25:25 floor_3] citizen_62 entered the queue
[D1 12:25:25 floor_3] citizen_62 found an empty queue and will be served immediately
[D1 12:25:25 elevator_1] Summoned to floor 3 from floor 3
[D1 12:25:25 elevator_1] Opened doors
[D1 12:25:25 citizen_67] Left elevator_1, arrived at floor 3
[D1 12:25:25 citizen_62] Entered elevator_1, going to floor 0
[D1 12:25:25 floor_3] citizen_62 is leaving the queue
[D1 12:25:25 floor_3] The queue is now empty
[D1 12:25:27 elevator_2] Closed doors
[D1 12:25:27 elevator_2] Changing direction to Down
[D1 12:25:37 elevator_1] Closing doors
[D1 12:25:37 elevator_2] At floor 4
[D1 12:25:40 elevator_1] Closed doors
[D1 12:25:47 elevator_2] At floor 3
[D1 12:25:50 elevator_1] At floor 2
[D1 12:25:52 citizen_80] Time to go to floor 4 and stay there for 00:31:42
[D1 12:25:52 floor_1] citizen_80 entered the queue
[D1 12:25:52 floor_1] citizen_80 found an empty queue and will be served immediately
[D1 12:25:52 elevator_1] Summoned to floor 1 from floor 2
[D1 12:25:57 elevator_2] At floor 2
[D1 12:26:00 elevator_1] At floor 1
[D1 12:26:00 elevator_1] Stopped at floor 1
[D1 12:26:00 elevator_1] Opening doors
[D1 12:26:03 elevator_1] Opened doors
[D1 12:26:03 citizen_80] Entered elevator_1, going to floor 4
[D1 12:26:03 floor_1] citizen_80 is leaving the queue
[D1 12:26:03 floor_1] The queue is now empty
[D1 12:26:07 elevator_2] At floor 1
[D1 12:26:11 citizen_93] Time to go to floor 3 and stay there for 00:23:14
[D1 12:26:11 floor_5] citizen_93 entered the queue
[D1 12:26:11 floor_5] citizen_93 found an empty queue and will be served immediately
[D1 12:26:11 elevator_1] Summoned to floor 5 from floor 1
[D1 12:26:11 elevator_2] Summoned to floor 5 from floor 1
[D1 12:26:15 elevator_1] Closing doors
[D1 12:26:17 elevator_2] At floor 0
[D1 12:26:17 elevator_2] Stopped at floor 0
[D1 12:26:17 elevator_2] Opening doors
[D1 12:26:18 elevator_1] Closed doors
[D1 12:26:20 elevator_2] Opened doors
[D1 12:26:20 citizen_75] Left elevator_2, arrived at floor 0
[D1 12:26:20 citizen_75] Left the building
[D1 12:26:28 elevator_1] At floor 0
[D1 12:26:28 elevator_1] Stopped at floor 0
[D1 12:26:28 elevator_1] Opening doors
[D1 12:26:31 elevator_1] Opened doors
[D1 12:26:31 citizen_50] Left elevator_1, arrived at floor 0
[D1 12:26:31 citizen_62] Left elevator_1, arrived at floor 0
[D1 12:26:31 citizen_50] Left the building
[D1 12:26:31 citizen_62] Left the building
[D1 12:26:32 elevator_2] Closing doors
[D1 12:26:35 elevator_2] Closed doors
[D1 12:26:35 elevator_2] Changing direction to Up
[D1 12:26:43 elevator_1] Closing doors
[D1 12:26:44 citizen_113] Entered the building, will visit 4 floors in total
[D1 12:26:44 citizen_113] Time to go to floor 2 and stay there for 00:33:10
[D1 12:26:44 floor_0] citizen_113 entered the queue
[D1 12:26:44 floor_0] citizen_113 found an empty queue and will be served immediately
[D1 12:26:44 elevator_1] Summoned to floor 0 from floor 0
[D1 12:26:44 elevator_2] Summoned to floor 0 from floor 0
[D1 12:26:45 elevator_2] At floor 1
[D1 12:26:46 elevator_1] Reopening doors
[D1 12:26:46 citizen_113] Entered elevator_1, going to floor 2
[D1 12:26:46 floor_0] citizen_113 is leaving the queue
[D1 12:26:46 floor_0] The queue is now empty
[D1 12:26:55 elevator_2] At floor 2
[D1 12:26:58 elevator_1] Closing doors
[D1 12:27:01 elevator_1] Closed doors
[D1 12:27:01 elevator_1] Changing direction to Up
[D1 12:27:05 elevator_2] At floor 3
[D1 12:27:06 citizen_60] Time to go to the ground floor and leave
[D1 12:27:06 floor_2] citizen_60 entered the queue
[D1 12:27:06 floor_2] citizen_60 found an empty queue and will be served immediately
[D1 12:27:06 elevator_2] Summoned to floor 2 from floor 3
[D1 12:27:11 elevator_1] At floor 1
[D1 12:27:15 elevator_2] At floor 4
[D1 12:27:21 elevator_1] At floor 2
[D1 12:27:21 elevator_1] Stopped at floor 2
[D1 12:27:21 elevator_1] Opening doors
[D1 12:27:24 elevator_1] Opened doors
[D1 12:27:24 citizen_113] Left elevator_1, arrived at floor 2
[D1 12:27:25 elevator_2] At floor 5
[D1 12:27:25 elevator_2] Stopped at floor 5
[D1 12:27:25 elevator_2] Opening doors
[D1 12:27:26 citizen_100] Time to go to floor 2 and stay there for 00:26:27
[D1 12:27:26 floor_4] citizen_100 entered the queue
[D1 12:27:26 floor_4] citizen_100 found an empty queue and will be served immediately
[D1 12:27:26 elevator_2] Summoned to floor 4 from floor 5
[D1 12:27:28 elevator_2] Opened doors
[D1 12:27:28 citizen_93] Entered elevator_2, going to floor 3
[D1 12:27:28 floor_5] citizen_93 is leaving the queue
[D1 12:27:28 floor_5] The queue is now empty
[D1 12:27:36 elevator_1] Closing doors
[D1 12:27:39 elevator_1] Closed doors
[D1 12:27:40 elevator_2] Closing doors
[D1 12:27:43 elevator_2] Closed doors
[D1 12:27:43 elevator_2] Changing direction to Down
[D1 12:27:49 elevator_1] At floor 3
[D1 12:27:53 elevator_2] At floor 4
[D1 12:27:53 elevator_2] Stopped at floor 4
[D1 12:27:53 elevator_2] Opening doors
[D1 12:27:56 elevator_2] Opened doors
[D1 12:27:56 citizen_100] Entered elevator_2, going to floor 2
[D1 12:27:56 floor_4] citizen_100 is leaving the queue
[D1 12:27:56 floor_4] The queue is now empty
[D1 12:27:59 elevator_1] At floor 4
[D1 12:27:59 elevator_1] Stopped at floor 4
[D1 12:27:59 elevator_1] Opening doors
[D1 12:28:02 elevator_1] Opened doors
[D1 12:28:02 citizen_80] Left elevator_1, arrived at floor 4
[D1 12:28:08 elevator_2] Closing doors
[D1 12:28:11 elevator_2] Closed doors
[D1 12:28:14 elevator_1] Closing doors
[D1 12:28:17 elevator_1] Closed doors
[D1 12:28:21 elevator_2] At floor 3
[D1 12:28:21 elevator_2] Stopped at floor 3
[D1 12:28:21 elevator_2] Opening doors
[D1 12:28:24 elevator_2] Opened doors
[D1 12:28:24 citizen_93] Left elevator_2, arrived at floor 3
[D1 12:28:27 elevator_1] At floor 5
[D1 12:28:27 elevator_1] Stopped at floor 5
[D1 12:28:27 elevator_1] Opening doors
[D1 12:28:30 elevator_1] Opened doors
[D1 12:28:36 elevator_2] Closing doors
[D1 12:28:39 citizen_114] Entered the building, will visit 3 floors in total
[D1 12:28:39 citizen_114] Time to go to floor 5 and stay there for 00:38:49
[D1 12:28:39 floor_0] citizen_114 entered the queue
[D1 12:28:39 floor_0] citizen_114 found an empty queue and will be served immediately
[D1 12:28:39 elevator_2] Summoned to floor 0 from floor 3
[D1 12:28:39 elevator_2] Closed doors
[D1 12:28:42 elevator_1] Closing doors
[D1 12:28:45 elevator_1] Closed doors
[D1 12:28:45 elevator_1] Resting at floor 5
[D1 12:28:49 elevator_2] At floor 2
[D1 12:28:49 elevator_2] Stopped at floor 2
[D1 12:28:49 elevator_2] Opening doors
[D1 12:28:52 elevator_2] Opened doors
[D1 12:28:52 citizen_100] Left elevator_2, arrived at floor 2
[D1 12:28:52 citizen_60] Entered elevator_2, going to floor 0
[D1 12:28:52 floor_2] citizen_60 is leaving the queue
[D1 12:28:52 floor_2] The queue is now empty
[D1 12:29:04 elevator_2] Closing doors
[D1 12:29:06 citizen_104] Time to go to floor 4 and stay there for 00:22:59
[D1 12:29:06 floor_2] citizen_104 entered the queue
[D1 12:29:06 floor_2] citizen_104 found an empty queue and will be served immediately
[D1 12:29:06 elevator_2] Summoned to floor 2 from floor 2
[D1 12:29:07 elevator_2] Reopening doors
[D1 12:29:07 citizen_104] Entered elevator_2, going to floor 4
[D1 12:29:07 floor_2] citizen_104 is leaving the queue
[D1 12:29:07 floor_2] The queue is now empty
[D1 12:29:09 citizen_79] Time to go to floor 1 and stay there for 00:34:31
[D1 12:29:09 floor_3] citizen_79 entered the queue
[D1 12:29:09 floor_3] citizen_79 found an empty queue and will be served immediately
[D1 12:29:09 elevator_2] Summoned to floor 3 from floor 2
[D1 12:29:19 elevator_2] Closing doors
[D1 12:29:22 elevator_2] Closed doors
[D1 12:29:32 elevator_2] At floor 1
[D1 12:29:42 elevator_2] At floor 0
[D1 12:29:42 elevator_2] Stopped at floor 0
[D1 12:29:42 elevator_2] Opening doors
[D1 12:29:45 elevator_2] Opened doors
[D1 12:29:45 citizen_60] Left elevator_2, arrived at floor 0
[D1 12:29:45 citizen_60] Left the building
[D1 12:29:45 citizen_114] Entered elevator_2, going to floor 5
[D1 12:29:45 floor_0] citizen_114 is leaving the queue
[D1 12:29:45 floor_0] The queue is now empty
[D1 12:29:57 elevator_2] Closing doors
[D1 12:30:00 elevator_2] Closed doors
[D1 12:30:00 elevator_2] Changing direction to Up
[D1 12:30:10 elevator_2] At floor 1
[D1 12:30:20 elevator_2] At floor 2
[D1 12:30:30 elevator_2] At floor 3
[D1 12:30:30 elevator_2] Stopped at floor 3
[D1 12:30:30 elevator_2] Opening doors
[D1 12:30:33 elevator_2] Opened doors
[D1 12:30:33 citizen_79] Entered elevator_2, going to floor 1
[D1 12:30:33 floor_3] citizen_79 is leaving the queue
[D1 12:30:33 floor_3] The queue is now empty
[D1 12:30:45 elevator_2] Closing doors
[D1 12:30:48 elevator_2] Closed doors
[D1 12:30:58 elevator_2] At floor 4
[D1 12:30:58 elevator_2] Stopped at floor 4
[D1 12:30:58 elevator_2] Opening doors
[D1 12:31:01 elevator_2] Opened doors
[D1 12:31:01 citizen_104] Left elevator_2, arrived at floor 4
[D1 12:31:05 citizen_99] Time to go to floor 3 and stay there for 00:43:31
[D1 12:31:05 floor_5] citizen_99 entered the queue
[D1 12:31:05 floor_5] citizen_99 found an empty queue and will be served immediately
[D1 12:31:05 elevator_1] Summoned to floor 5 from floor 5
[D1 12:31:05 elevator_1] Opening doors
[D1 12:31:08 elevator_1] Opened doors
[D1 12:31:08 citizen_99] Entered elevator_1, going to floor 3
[D1 12:31:08 floor_5] citizen_99 is leaving the queue
[D1 12:31:08 floor_5] The queue is now empty
[D1 12:31:13 elevator_2] Closing doors
[D1 12:31:16 elevator_2] Closed doors
[D1 12:31:20 elevator_1] Closing doors
[D1 12:31:23 elevator_1] Closed doors
[D1 12:31:23 elevator_1] Sprung into motion, heading Down
[D1 12:31:26 elevator_2] At floor 5
[D1 12:31:26 elevator_2] Stopped at floor 5
[D1 12:31:26 elevator_2] Opening doors
[D1 12:31:27 citizen_83] Time to go to floor 1 and stay there for 00:32:53
[D1 12:31:27 floor_4] citizen_83 entered the queue
[D1 12:31:27 floor_4] citizen_83 found an empty queue and will be served immediately
[D1 12:31:27 elevator_1] Summoned to floor 4 from floor 5
[D1 12:31:27 elevator_2] Summoned to floor 4 from floor 5
[D1 12:31:29 elevator_2] Opened doors
[D1 12:31:29 citizen_114] Left elevator_2, arrived at floor 5
[D1 12:31:33 elevator_1] At floor 4
[D1 12:31:33 elevator_1] Stopped at floor 4
[D1 12:31:33 elevator_1] Opening doors
[D1 12:31:36 elevator_1] Opened doors
[D1 12:31:36 citizen_83] Entered elevator_1, going to floor 1
[D1 12:31:36 floor_4] citizen_83 is leaving the queue
[D1 12:31:36 floor_4] The queue is now empty
[D1 12:31:39 citizen_71] Time to go to floor 3 and stay there for 00:21:00
[D1 12:31:39 floor_2] citizen_71 entered the queue
[D1 12:31:39 floor_2] citizen_71 found an empty queue and will be served immediately
[D1 12:31:39 elevator_1] Summoned to floor 2 from floor 4
[D1 12:31:41 elevator_2] Closing doors
[D1 12:31:44 elevator_2] Closed doors
[D1 12:31:44 elevator_2] Changing direction to Down
[D1 12:31:45 citizen_103] Time to go to floor 3 and stay there for 00:42:16
[D1 12:31:45 floor_5] citizen_103 entered the queue
[D1 12:31:45 floor_5] citizen_103 found an empty queue and will be served immediately
[D1 12:31:45 elevator_2] Summoned to floor 5 from floor 5
[D1 12:31:48 elevator_1] Closing doors
[D1 12:31:51 elevator_1] Closed doors
[D1 12:31:54 elevator_2] At floor 4
[D1 12:31:54 elevator_2] Stopped at floor 4
[D1 12:31:54 elevator_2] Opening doors
[D1 12:31:57 elevator_2] Opened doors
[D1 12:32:01 elevator_1] At floor 3
[D1 12:32:01 elevator_1] Stopped at floor 3
[D1 12:32:01 elevator_1] Opening doors
[D1 12:32:04 elevator_1] Opened doors
[D1 12:32:04 citizen_99] Left elevator_1, arrived at floor 3
[D1 12:32:07 citizen_74] Time to go to floor 2 and stay there for 00:41:15
[D1 12:32:07 floor_1] citizen_74 entered the queue
[D1 12:32:07 floor_1] citizen_74 found an empty queue and will be served immediately
[D1 12:32:07 elevator_1] Summoned to floor 1 from floor 3
[D1 12:32:08 citizen_108] Time to go to floor 2 and stay there for 00:33:21
[D1 12:32:08 floor_3] citizen_108 entered the queue
[D1 12:32:08 floor_3] citizen_108 found an empty queue and will be served immediately
[D1 12:32:08 elevator_1] Summoned to floor 3 from floor 3
[D1 12:32:08 citizen_108] Entered elevator_1, going to floor 2
[D1 12:32:08 floor_3] citizen_108 is leaving the queue
[D1 12:32:08 floor_3] The queue is now empty
[D1 12:32:08 citizen_115] Entered the building, will visit 3 floors in total
[D1 12:32:08 citizen_115] Time to go to floor 2 and stay there for 00:39:02
[D1 12:32:08 floor_0] citizen_115 entered the queue
[D1 12:32:08 floor_0] citizen_115 found an empty queue and will be served immediately
[D1 12:32:08 elevator_1] Summoned to floor 0 from floor 3
[D1 12:32:09 elevator_2] Closing doors
[D1 12:32:12 elevator_2] Closed doors
[D1 12:32:14 citizen_78] Time to go to floor 2 and stay there for 00:23:18
[D1 12:32:14 floor_5] citizen_78 entered the queue
[D1 12:32:14 floor_5] citizen_78 is queued along with 0 other arrivals in front of it
[D1 12:32:16 elevator_1] Closing doors
[D1 12:32:17 citizen_70] Time to go to floor 1 and stay there for 00:36:48
[D1 12:32:17 floor_5] citizen_70 entered the queue
[D1 12:32:17 floor_5] citizen_70 is queued along with 1 other arrivals in front of it
[D1 12:32:19 elevator_1] Closed doors
[D1 12:32:22 elevator_2] At floor 3
[D1 12:32:29 elevator_1] At floor 2
[D1 12:32:29 elevator_1] Stopped at floor 2
[D1 12:32:29 elevator_1] Opening doors
[D1 12:32:32 elevator_2] At floor 2
[D1 12:32:32 elevator_1] Opened doors
[D1 12:32:32 citizen_108] Left elevator_1, arrived at floor 2
[D1 12:32:32 citizen_71] Entered elevator_1, going to floor 3
[D1 12:32:32 floor_2] citizen_71 is leaving the queue
[D1 12:32:32 floor_2] The queue is now empty
[D1 12:32:42 elevator_2] At floor 1
[D1 12:32:42 elevator_2] Stopped at floor 1
[D1 12:32:42 elevator_2] Opening doors
[D1 12:32:44 elevator_1] Closing doors
[D1 12:32:45 elevator_2] Opened doors
[D1 12:32:45 citizen_79] Left elevator_2, arrived at floor 1
[D1 12:32:47 elevator_1] Closed doors
[D1 12:32:57 elevator_2] Closing doors
[D1 12:32:57 elevator_1] At floor 1
[D1 12:32:57 elevator_1] Stopped at floor 1
[D1 12:32:57 elevator_1] Opening doors
[D1 12:33:00 elevator_2] Closed doors
[D1 12:33:00 elevator_1] Opened doors
[D1 12:33:00 elevator_2] Changing direction to Up
[D1 12:33:00 citizen_83] Left elevator_1, arrived at floor 1
[D1 12:33:00 citizen_74] Entered elevator_1, going to floor 2
[D1 12:33:00 floor_1] citizen_74 is leaving the queue
[D1 12:33:00 floor_1] The queue is now empty
[D1 12:33:03 citizen_102] Time to go to floor 4 and stay there for 00:26:54
[D1 12:33:03 floor_3] citizen_102 entered the queue
[D1 12:33:03 floor_3] citizen_102 found an empty queue and will be served immediately
[D1 12:33:03 elevator_1] Summoned to floor 3 from floor 1
[D1 12:33:03 elevator_2] Summoned to floor 3 from floor 1
[D1 12:33:10 elevator_2] At floor 2
[D1 12:33:12 elevator_1] Closing doors
[D1 12:33:15 elevator_1] Closed doors
[D1 12:33:16 citizen_44] Time to go to the ground floor and leave
[D1 12:33:16 floor_4] citizen_44 entered the queue
[D1 12:33:16 floor_4] citizen_44 found an empty queue and will be served immediately
[D1 12:33:16 elevator_2] Summoned to floor 4 from floor 2
[D1 12:33:20 elevator_2] At floor 3
[D1 12:33:20 elevator_2] Stopped at floor 3
[D1 12:33:20 elevator_2] Opening doors
[D1 12:33:23 elevator_2] Opened doors
[D1 12:33:23 citizen_102] Entered elevator_2, going to floor 4
[D1 12:33:23 floor_3] citizen_102 is leaving the queue
[D1 12:33:23 floor_3] The queue is now empty
[D1 12:33:25 elevator_1] At floor 0
[D1 12:33:25 elevator_1] Stopped at floor 0
[D1 12:33:25 elevator_1] Opening doors
[D1 12:33:28 elevator_1] Opened doors
[D1 12:33:28 citizen_115] Entered elevator_1, going to floor 2
[D1 12:33:28 floor_0] citizen_115 is leaving the queue
[D1 12:33:28 floor_0] The queue is now empty
[D1 12:33:35 citizen_116] Entered the building, will visit 6 floors in total
[D1 12:33:35 citizen_116] Time to go to floor 1 and stay there for 00:29:33
[D1 12:33:35 floor_0] citizen_116 entered the queue
[D1 12:33:35 floor_0] citizen_116 found an empty queue and will be served immediately
[D1 12:33:35 elevator_1] Summoned to floor 0 from floor 0
[D1 12:33:35 citizen_116] Entered elevator_1, going to floor 1
[D1 12:33:35 floor_0] citizen_116 is leaving the queue
[D1 12:33:35 floor_0] The queue is now empty
[D1 12:33:35 elevator_2] Closing doors
[D1 12:33:38 elevator_2] Closed doors
[D1 12:33:40 elevator_1] Closing doors
[D1 12:33:42 citizen_61] Time to go to the ground floor and leave
[D1 12:33:42 floor_5] citizen_61 entered the queue
[D1 12:33:42 floor_5] citizen_61 is queued along with 2 other arrivals in front of it
[D1 12:33:43 elevator_1] Closed doors
[D1 12:33:43 elevator_1] Changing direction to Up
[D1 12:33:48 elevator_2] At floor 4
[D1 12:33:48 elevator_2] Stopped at floor 4
[D1 12:33:48 elevator_2] Opening doors
[D1 12:33:50 citizen_86] Time to go to floor 1 and stay there for 00:25:50
[D1 12:33:50 floor_2] citizen_86 entered the queue
[D1 12:33:50 floor_2] citizen_86 found an empty queue and will be served immediately
[D1 12:33:50 elevator_1] Summoned to floor 2 from floor 0
[D1 12:33:50 elevator_2] Summoned to floor 2 from floor 4
[D1 12:33:51 elevator_2] Opened doors
[D1 12:33:51 citizen_102] Left elevator_2, arrived at floor 4
[D1 12:33:51 citizen_44] Entered elevator_2, going to floor 0
[D1 12:33:51 floor_4] citizen_44 is leaving the queue
[D1 12:33:51 floor_4] The queue is now empty
[D1 12:33:53 elevator_1] At floor 1
[D1 12:33:53 elevator_1] Stopped at floor 1
[D1 12:33:53 elevator_1] Opening doors
[D1 12:33:56 elevator_1] Opened doors
[D1 12:33:56 citizen_116] Left elevator_1, arrived at floor 1
[D1 12:34:03 elevator_2] Closing doors
[D1 12:34:06 elevator_2] Closed doors
[D1 12:34:08 elevator_1] Closing doors
[D1 12:34:11 elevator_1] Closed doors
[D1 12:34:16 elevator_2] At floor 5
[D1 12:34:16 elevator_2] Stopped at floor 5
[D1 12:34:16 elevator_2] Opening doors
[D1 12:34:19 elevator_2] Opened doors
[D1 12:34:19 citizen_103] Entered elevator_2, going to floor 3
[D1 12:34:19 floor_5] citizen_103 is leaving the queue
[D1 12:34:19 floor_5] citizen_78 was served
[D1 12:34:19 elevator_2] Summoned to floor 5 from floor 5
[D1 12:34:19 citizen_78] Entered elevator_2, going to floor 2
[D1 12:34:19 floor_5] citizen_78 is leaving the queue
[D1 12:34:19 floor_5] citizen_70 was served
[D1 12:34:19 elevator_2] Summoned to floor 5 from floor 5
[D1 12:34:19 citizen_70] Entered elevator_2, going to floor 1
[D1 12:34:19 floor_5] citizen_70 is leaving the queue
[D1 12:34:19 floor_5] citizen_61 was served
[D1 12:34:19 elevator_2] Summoned to floor 5 from floor 5
[D1 12:34:19 citizen_61] Cannot enter elevator_2, it is full
[D1 12:34:19 citizen_61] All elevators were full, trying to summon them again
[D1 12:34:21 elevator_1] At floor 2
[D1 12:34:21 elevator_1] Stopped at floor 2
[D1 12:34:21 elevator_1] Opening doors
[D1 12:34:24 elevator_1] Opened doors
[D1 12:34:24 citizen_74] Left elevator_1, arrived at floor 2
[D1 12:34:24 citizen_115] Left elevator_1, arrived at floor 2
[D1 12:34:24 citizen_86] Entered elevator_1, going to floor 1
[D1 12:34:24 floor_2] citizen_86 is leaving the queue
[D1 12:34:24 floor_2] The queue is now empty
[D1 12:34:31 elevator_2] Closing doors
[D1 12:34:34 elevator_2] Closed doors
[D1 12:34:34 elevator_2] Changing direction to Down
[D1 12:34:35 elevator_2] Summoned to floor 5 from floor 5
[D1 12:34:36 elevator_1] Closing doors
[D1 12:34:37 citizen_92] Time to go to floor 4 and stay there for 00:37:10
[D1 12:34:37 floor_3] citizen_92 entered the queue
[D1 12:34:37 floor_3] citizen_92 found an empty queue and will be served immediately
[D1 12:34:37 elevator_1] Summoned to floor 3 from floor 2
[D1 12:34:39 elevator_1] Closed doors
[D1 12:34:39 citizen_101] Time to go to floor 3 and stay there for 00:31:29
[D1 12:34:39 floor_2] citizen_101 entered the queue
[D1 12:34:39 floor_2] citizen_101 found an empty queue and will be served immediately
[D1 12:34:39 elevator_1] Summoned to floor 2 from floor 2
[D1 12:34:39 elevator_1] Opening doors
[D1 12:34:42 elevator_1] Opened doors
[D1 12:34:42 citizen_101] Entered elevator_1, going to floor 3
[D1 12:34:42 floor_2] citizen_101 is leaving the queue
[D1 12:34:42 floor_2] The queue is now empty
[D1 12:34:44 elevator_2] At floor 4
[D1 12:34:49 elevator_1] At floor 3
[D1 12:34:49 elevator_1] Stopped at floor 3
[D1 12:34:49 citizen_71] Left elevator_1, arrived at floor 3
[D1 12:34:49 citizen_101] Left elevator_1, arrived at floor 3
[D1 12:34:49 citizen_92] Entered elevator_1, going to floor 4
[D1 12:34:49 floor_3] citizen_92 is leaving the queue
[D1 12:34:49 floor_3] The queue is now empty
[D1 12:34:54 elevator_1] Closing doors
[D1 12:34:54 elevator_2] At floor 3
[D1 12:34:54 elevator_2] Stopped at floor 3
[D1 12:34:54 elevator_2] Opening doors
[D1 12:34:57 elevator_1] Closed doors
[D1 12:34:57 elevator_2] Opened doors
[D1 12:34:57 citizen_103] Left elevator_2, arrived at floor 3
[D1 12:34:59 citizen_84] Time to go to floor 3 and stay there for 00:40:15
[D1 12:34:59 floor_2] citizen_84 entered the queue
[D1 12:34:59 floor_2] citizen_84 found an empty queue and will be served immediately
[D1 12:34:59 elevator_1] Summoned to floor 2 from floor 3
[D1 12:34:59 elevator_2] Summoned to floor 2 from floor 3
[D1 12:35:01 citizen_85] Time to go to floor 3 and stay there for 00:39:05
[D1 12:35:01 floor_5] citizen_85 entered the queue
[D1 12:35:01 floor_5] citizen_85 is queued along with 0 other arrivals in front of it
[D1 12:35:07 elevator_1] At floor 4
[D1 12:35:07 elevator_1] Stopped at floor 4
[D1 12:35:07 elevator_1] Opening doors
[D1 12:35:09 elevator_2] Closing doors
[D1 12:35:10 elevator_1] Opened doors
[D1 12:35:10 citizen_92] Left elevator_1, arrived at floor 4
[D1 12:35:12 elevator_2] Closed doors
[D1 12:35:22 elevator_1] Closing doors
[D1 12:35:22 elevator_2] At floor 2
[D1 12:35:22 elevator_2] Stopped at floor 2
[D1 12:35:22 elevator_2] Opening doors
[D1 12:35:23 citizen_51] Time to go to the ground floor and leave
[D1 12:35:23 floor_1] citizen_51 entered the queue
[D1 12:35:23 floor_1] citizen_51 found an empty queue and will be served immediately
[D1 12:35:23 elevator_2] Summoned to floor 1 from floor 2
[D1 12:35:25 elevator_1] Closed doors
[D1 12:35:25 elevator_2] Opened doors
[D1 12:35:25 elevator_1] Changing direction to Down
[D1 12:35:25 citizen_78] Left elevator_2, arrived at floor 2
[D1 12:35:25 citizen_84] Entered elevator_2, going to floor 3
[D1 12:35:25 floor_2] citizen_84 is leaving the queue
[D1 12:35:25 floor_2] The queue is now empty
[D1 12:35:35 elevator_1] At floor 3
[D1 12:35:37 elevator_2] Closing doors
[D1 12:35:40 elevator_2] Closed doors
[D1 12:35:45 elevator_1] At floor 2
[D1 12:35:45 elevator_1] Stopped at floor 2
[D1 12:35:45 elevator_1] Opening doors
[D1 12:35:48 elevator_1] Opened doors
[D1 12:35:50 elevator_2] At floor 1
[D1 12:35:50 elevator_2] Stopped at floor 1
[D1 12:35:50 elevator_2] Opening doors
[D1 12:35:53 elevator_2] Opened doors
[D1 12:35:53 citizen_70] Left elevator_2, arrived at floor 1
[D1 12:35:53 citizen_51] Entered elevator_2, going to floor 0
[D1 12:35:53 floor_1] citizen_51 is leaving the queue
[D1 12:35:53 floor_1] The queue is now empty
[D1 12:36:00 elevator_1] Closing doors
[D1 12:36:03 elevator_1] Closed doors
[D1 12:36:05 elevator_2] Closing doors
[D1 12:36:08 elevator_2] Closed doors
[D1 12:36:09 citizen_117] Entered the building, will visit 2 floors in total
[D1 12:36:09 citizen_117] Time to go to floor 1 and stay there for 00:37:50
[D1 12:36:09 floor_0] citizen_117 entered the queue
[D1 12:36:09 floor_0] citizen_117 found an empty queue and will be served immediately
[D1 12:36:09 elevator_2] Summoned to floor 0 from floor 1
[D1 12:36:13 elevator_1] At floor 1
[D1 12:36:13 elevator_1] Stopped at floor 1
[D1 12:36:13 elevator_1] Opening doors
[D1 12:36:16 elevator_1] Opened doors
[D1 12:36:16 citizen_86] Left elevator_1, arrived at floor 1
[D1 12:36:18 elevator_2] At floor 0
[D1 12:36:18 elevator_2] Stopped at floor 0
[D1 12:36:18 elevator_2] Opening doors
[D1 12:36:21 elevator_2] Opened doors
[D1 12:36:21 citizen_44] Left elevator_2, arrived at floor 0
[D1 12:36:21 citizen_51] Left elevator_2, arrived at floor 0
[D1 12:36:21 citizen_44] Left the building
[D1 12:36:21 citizen_51] Left the building
[D1 12:36:21 citizen_117] Entered elevator_2, going to floor 1
[D1 12:36:21 floor_0] citizen_117 is leaving the queue
[D1 12:36:21 floor_0] The queue is now empty
[D1 12:36:28 elevator_1] Closing doors
[D1 12:36:31 elevator_1] Closed doors
[D1 12:36:31 elevator_1] Resting at floor 1
[D1 12:36:33 elevator_2] Closing doors
[D1 12:36:36 elevator_2] Closed doors
[D1 12:36:36 elevator_2] Changing direction to Up
[D1 12:36:46 elevator_2] At floor 1
[D1 12:36:46 elevator_2] Stopped at floor 1
[D1 12:36:46 elevator_2] Opening doors
[D1 12:36:49 elevator_2] Opened doors
[D1 12:36:49 citizen_117] Left elevator_2, arrived at floor 1
[D1 12:37:00 citizen_106] Time to go to floor 3 and stay there for 00:37:27
[D1 12:37:00 floor_2] citizen_106 entered the queue
[D1 12:37:00 floor_2] citizen_106 found an empty queue and will be served immediately
[D1 12:37:00 elevator_1] Summoned to floor 2 from floor 1
[D1 12:37:00 elevator_1] Sprung into motion, heading Up
[D1 12:37:00 elevator_2] Summoned to floor 2 from floor 1
[D1 12:37:01 elevator_2] Closing doors
[D1 12:37:04 elevator_2] Closed doors
[D1 12:37:10 elevator_1] At floor 2
[D1 12:37:10 elevator_1] Stopped at floor 2
[D1 12:37:10 elevator_1] Opening doors
[D1 12:37:13 elevator_1] Opened doors
[D1 12:37:13 citizen_106] Entered elevator_1, going to floor 3
[D1 12:37:13 floor_2] citizen_106 is leaving the queue
[D1 12:37:13 floor_2] The queue is now empty
[D1 12:37:14 elevator_2] At floor 2
[D1 12:37:14 elevator_2] Stopped at floor 2
[D1 12:37:14 elevator_2] Opening doors
[D1 12:37:14 citizen_57] Time to go to the ground floor and leave
[D1 12:37:14 floor_3] citizen_57 entered the queue
[D1 12:37:14 floor_3] citizen_57 found an empty queue and will be served immediately
[D1 12:37:14 elevator_1] Summoned to floor 3 from floor 2
[D1 12:37:14 elevator_2] Summoned to floor 3 from floor 2
[D1 12:37:17 elevator_2] Opened doors
[D1 12:37:25 elevator_1] Closing doors
[D1 12:37:28 elevator_1] Closed doors
[D1 12:37:29 elevator_2] Closing doors
[D1 12:37:32 elevator_2] Closed doors
[D1 12:37:38 citizen_118] Entered the building, will visit 4 floors in total
[D1 12:37:38 citizen_118] Time to go to floor 2 and stay there for 00:24:08
[D1 12:37:38 floor_0] citizen_118 entered the queue
[D1 12:37:38 floor_0] citizen_118 found an empty queue and will be served immediately
[D1 12:37:38 elevator_1] Summoned to floor 0 from floor 2
[D1 12:37:38 elevator_2] Summoned to floor 0 from floor 2
[D1 12:37:38 elevator_1] At floor 3
[D1 12:37:38 elevator_1] Stopped at floor 3
[D1 12:37:38 elevator_1] Opening doors
[D1 12:37:41 elevator_1] Opened doors
[D1 12:37:41 citizen_106] Left elevator_1, arrived at floor 3
[D1 12:37:41 citizen_57] Entered elevator_1, going to floor 0
[D1 12:37:41 floor_3] citizen_57 is leaving the queue
[D1 12:37:41 floor_3] The queue is now empty
[D1 12:37:42 elevator_2] At floor 3
[D1 12:37:42 elevator_2] Stopped at floor 3
[D1 12:37:42 elevator_2] Opening doors
[D1 12:37:45 elevator_2] Opened doors
[D1 12:37:45 citizen_84] Left elevator_2, arrived at floor 3
[D1 12:37:53 elevator_1] Closing doors
[D1 12:37:56 elevator_1] Closed doors
[D1 12:37:56 elevator_1] Changing direction to Down
[D1 12:37:57 elevator_2] Closing doors
[D1 12:38:00 elevator_2] Closed doors
[D1 12:38:06 elevator_1] At floor 2
[D1 12:38:10 elevator_2] At floor 4
[D1 12:38:16 elevator_1] At floor 1
[D1 12:38:20 elevator_2] At floor 5
[D1 12:38:20 elevator_2] Stopped at floor 5
[D1 12:38:20 elevator_2] Opening doors
[D1 12:38:23 elevator_2] Opened doors
[D1 12:38:23 citizen_61] Entered elevator_2, going to floor 0
[D1 12:38:23 floor_5] citizen_61 is leaving the queue
[D1 12:38:23 floor_5] citizen_85 was served
[D1 12:38:23 elevator_2] Summoned to floor 5 from floor 5
[D1 12:38:23 citizen_85] Entered elevator_2, going to floor 3
[D1 12:38:23 floor_5] citizen_85 is leaving the queue
[D1 12:38:23 floor_5] The queue is now empty
[D1 12:38:26 elevator_1] At floor 0
[D1 12:38:26 elevator_1] Stopped at floor 0
[D1 12:38:26 elevator_1] Opening doors
[D1 12:38:29 elevator_1] Opened doors
[D1 12:38:29 citizen_57] Left elevator_1, arrived at floor 0
[D1 12:38:29 citizen_57] Left the building
[D1 12:38:29 citizen_118] Entered elevator_1, going to floor 2
[D1 12:38:29 floor_0] citizen_118 is leaving the queue
[D1 12:38:29 floor_0] The queue is now empty
[D1 12:38:35 elevator_2] Closing doors
[D1 12:38:38 elevator_2] Closed doors
[D1 12:38:38 elevator_2] Changing direction to Down
[D1 12:38:41 citizen_119] Entered the building, will visit 2 floors in total
[D1 12:38:41 citizen_119] Time to go to floor 4 and stay there for 00:24:39
[D1 12:38:41 floor_0] citizen_119 entered the queue
[D1 12:38:41 floor_0] citizen_119 found an empty queue and will be served immediately
[D1 12:38:41 elevator_1] Summoned to floor 0 from floor 0
[D1 12:38:41 citizen_119] Entered elevator_1, going to floor 4
[D1 12:38:41 floor_0] citizen_119 is leaving the queue
[D1 12:38:41 floor_0] The queue is now empty
[D1 12:38:41 elevator_1] Closing doors
[D1 12:38:44 elevator_1] Closed doors
[D1 12:38:44 elevator_1] Changing direction to Up
[D1 12:38:48 elevator_2] At floor 4
[D1 12:38:54 elevator_1] At floor 1
[D1 12:38:58 elevator_2] At floor 3
[D1 12:38:58 elevator_2] Stopped at floor 3
[D1 12:38:58 elevator_2] Opening doors
[D1 12:38:59 citizen_87] Time to go to the ground floor and leave
[D1 12:38:59 floor_5] citizen_87 entered the queue
[D1 12:38:59 floor_5] citizen_87 found an empty queue and will be served immediately
[D1 12:38:59 elevator_2] Summoned to floor 5 from floor 3
[D1 12:39:01 elevator_2] Opened doors
[D1 12:39:01 citizen_85] Left elevator_2, arrived at floor 3
[D1 12:39:04 elevator_1] At floor 2
[D1 12:39:04 elevator_1] Stopped at floor 2
[D1 12:39:04 elevator_1] Opening doors
[D1 12:39:07 elevator_1] Opened doors
[D1 12:39:07 citizen_118] Left elevator_1, arrived at floor 2
[D1 12:39:13 elevator_2] Closing doors
[D1 12:39:16 elevator_2] Closed doors
[D1 12:39:19 elevator_1] Closing doors
[D1 12:39:22 elevator_1] Closed doors
[D1 12:39:26 elevator_2] At floor 2
[D1 12:39:32 elevator_1] At floor 3
[D1 12:39:35 citizen_32] Time to go to the ground floor and leave
[D1 12:39:35 floor_1] citizen_32 entered the queue
[D1 12:39:35 floor_1] citizen_32 found an empty queue and will be served immediately
[D1 12:39:35 elevator_2] Summoned to floor 1 from floor 2
[D1 12:39:36 elevator_2] At floor 1
[D1 12:39:36 elevator_2] Stopped at floor 1
[D1 12:39:36 elevator_2] Opening doors
[D1 12:39:39 elevator_2] Opened doors
[D1 12:39:39 citizen_32] Entered elevator_2, going to floor 0
[D1 12:39:39 floor_1] citizen_32 is leaving the queue
[D1 12:39:39 floor_1] The queue is now empty
[D1 12:39:42 elevator_1] At floor 4
[D1 12:39:42 elevator_1] Stopped at floor 4
[D1 12:39:42 elevator_1] Opening doors
[D1 12:39:45 elevator_1] Opened doors
[D1 12:39:45 citizen_119] Left elevator_1, arrived at floor 4
[D1 12:39:51 elevator_2] Closing doors
[D1 12:39:54 elevator_2] Closed doors
[D1 12:39:57 elevator_1] Closing doors
[D1 12:40:00 elevator_1] Closed doors
[D1 12:40:00 elevator_1] Resting at floor 4
[D1 12:40:04 elevator_2] At floor 0
[D1 12:40:04 elevator_2] Stopped at floor 0
[D1 12:40:04 elevator_2] Opening doors
[D1 12:40:07 elevator_2] Opened doors
[D1 12:40:07 citizen_61] Left elevator_2, arrived at floor 0
[D1 12:40:07 citizen_32] Left elevator_2, arrived at floor 0
[D1 12:40:07 citizen_61] Left the building
[D1 12:40:07 citizen_32] Left the building
[D1 12:40:19 elevator_2] Closing doors
[D1 12:40:22 elevator_2] Closed doors
[D1 12:40:22 elevator_2] Changing direction to Up
[D1 12:40:27 citizen_76] Time to go to floor 2 and stay there for 00:27:22
[D1 12:40:27 floor_1] citizen_76 entered the queue
[D1 12:40:27 floor_1] citizen_76 found an empty queue and will be served immediately
[D1 12:40:27 elevator_2] Summoned to floor 1 from floor 0
[D1 12:40:29 citizen_120] Entered the building, will visit 5 floors in total
[D1 12:40:29 citizen_120] Time to go to floor 4 and stay there for 00:34:39
[D1 12:40:29 floor_0] citizen_120 entered the queue
[D1 12:40:29 floor_0] citizen_120 found an empty queue and will be served immediately
[D1 12:40:29 elevator_2] Summoned to floor 0 from floor 0
[D1 12:40:32 elevator_2] At floor 1
[D1 12:40:32 elevator_2] Stopped at floor 1
[D1 12:40:32 elevator_2] Opening doors
[D1 12:40:35 elevator_2] Opened doors
[D1 12:40:35 citizen_76] Entered elevator_2, going to floor 2
[D1 12:40:35 floor_1] citizen_76 is leaving the queue
[D1 12:40:35 floor_1] The queue is now empty
[D1 12:40:47 elevator_2] Closing doors
[D1 12:40:50 elevator_2] Closed doors
[D1 12:41:00 elevator_2] At floor 2
[D1 12:41:00 elevator_2] Stopped at floor 2
[D1 12:41:00 elevator_2] Opening doors
[D1 12:41:03 elevator_2] Opened doors
[D1 12:41:03 citizen_76] Left elevator_2, arrived at floor 2
[D1 12:41:15 elevator_2] Closing doors
[D1 12:41:18 elevator_2] Closed doors
[D1 12:41:25 citizen_109] Time to go to floor 4 and stay there for 00:42:57
[D1 12:41:25 floor_2] citizen_109 entered the queue
[D1 12:41:25 floor_2] citizen_109 found an empty queue and will be served immediately
[D1 12:41:25 elevator_2] Summoned to floor 2 from floor 2
[D1 12:41:28 elevator_2] At floor 3
[D1 12:41:38 elevator_2] At floor 4
[D1 12:41:48 elevator_2] At floor 5
[D1 12:41:48 elevator_2] Stopped at floor 5
[D1 12:41:48 elevator_2] Opening doors
[D1 12:41:51 elevator_2] Opened doors
[D1 12:41:51 citizen_87] Entered elevator_2, going to floor 0
[D1 12:41:51 floor_5] citizen_87 is leaving the queue
[D1 12:41:51 floor_5] The queue is now empty
[D1 12:42:03 elevator_2] Closing doors
[D1 12:42:06 elevator_2] Closed doors
[D1 12:42:06 elevator_2] Changing direction to Down
[D1 12:42:16 elevator_2] At floor 4
[D1 12:42:26 elevator_2] At floor 3
[D1 12:42:29 citizen_97] Time to go to floor 2 and stay there for 00:27:32
[D1 12:42:29 floor_3] citizen_97 entered the queue
[D1 12:42:29 floor_3] citizen_97 found an empty queue and will be served immediately
[D1 12:42:29 elevator_2] Summoned to floor 3 from floor 3
[D1 12:42:36 elevator_2] At floor 2
[D1 12:42:36 elevator_2] Stopped at floor 2
[D1 12:42:36 elevator_2] Opening doors
[D1 12:42:39 elevator_2] Opened doors
[D1 12:42:39 citizen_109] Entered elevator_2, going to floor 4
[D1 12:42:39 floor_2] citizen_109 is leaving the queue
[D1 12:42:39 floor_2] The queue is now empty
[D1 12:42:49 citizen_105] Time to go to floor 2 and stay there for 00:30:07
[D1 12:42:49 floor_4] citizen_105 entered the queue
[D1 12:42:49 floor_4] citizen_105 found an empty queue and will be served immediately
[D1 12:42:49 elevator_1] Summoned to floor 4 from floor 4
[D1 12:42:49 elevator_1] Opening doors
[D1 12:42:51 elevator_2] Closing doors
[D1 12:42:52 elevator_1] Opened doors
[D1 12:42:52 citizen_105] Entered elevator_1, going to floor 2
[D1 12:42:52 floor_4] citizen_105 is leaving the queue
[D1 12:42:52 floor_4] The queue is now empty
[D1 12:42:54 elevator_2] Closed doors
[D1 12:42:57 citizen_121] Entered the building, will visit 4 floors in total
[D1 12:42:57 citizen_121] Time to go to floor 2 and stay there for 00:36:33
[D1 12:42:57 floor_0] citizen_121 entered the queue
[D1 12:42:57 floor_0] citizen_121 is queued along with 0 other arrivals in front of it
[D1 12:43:04 elevator_1] Closing doors
[D1 12:43:04 elevator_2] At floor 1
[D1 12:43:07 elevator_1] Closed doors
[D1 12:43:07 elevator_1] Sprung into motion, heading Down
[D1 12:43:14 elevator_2] At floor 0
[D1 12:43:14 elevator_2] Stopped at floor 0
[D1 12:43:14 elevator_2] Opening doors
[D1 12:43:17 elevator_1] At floor 3
[D1 12:43:17 elevator_2] Opened doors
[D1 12:43:17 citizen_87] Left elevator_2, arrived at floor 0
[D1 12:43:17 citizen_87] Left the building
[D1 12:43:17 citizen_120] Entered elevator_2, going to floor 4
[D1 12:43:17 floor_0] citizen_120 is leaving the queue
[D1 12:43:17 floor_0] citizen_121 was served
[D1 12:43:17 elevator_2] Summoned to floor 0 from floor 0
[D1 12:43:17 citizen_121] Entered elevator_2, going to floor 2
[D1 12:43:17 floor_0] citizen_121 is leaving the queue
[D1 12:43:17 floor_0] The queue is now empty
[D1 12:43:27 elevator_1] At floor 2
[D1 12:43:27 elevator_1] Stopped at floor 2
[D1 12:43:27 elevator_1] Opening doors
[D1 12:43:29 elevator_2] Closing doors
[D1 12:43:30 elevator_1] Opened doors
[D1 12:43:30 citizen_105] Left elevator_1, arrived at floor 2
[D1 12:43:32 elevator_2] Closed doors
[D1 12:43:32 elevator_2] Changing direction to Up
[D1 12:43:42 elevator_1] Closing doors
[D1 12:43:42 elevator_2] At floor 1
[D1 12:43:45 elevator_1] Closed doors
[D1 12:43:45 elevator_1] Resting at floor 2
[D1 12:43:52 elevator_2] At floor 2
[D1 12:43:52 elevator_2] Stopped at floor 2
[D1 12:43:52 elevator_2] Opening doors
[D1 12:43:55 elevator_2] Opened doors
[D1 12:43:55 citizen_121] Left elevator_2, arrived at floor 2
[D1 12:44:07 elevator_2] Closing doors
[D1 12:44:10 elevator_2] Closed doors
[D1 12:44:20 elevator_2] At floor 3
[D1 12:44:20 elevator_2] Stopped at floor 3
[D1 12:44:20 elevator_2] Opening doors
[D1 12:44:23 elevator_2] Opened doors
[D1 12:44:23 citizen_97] Entered elevator_2, going to floor 2
[D1 12:44:23 floor_3] citizen_97 is leaving the queue
[D1 12:44:23 floor_3] The queue is now empty
[D1 12:44:27 citizen_67] Time to go to floor 1 and stay there for 00:23:23
[D1 12:44:27 floor_3] citizen_67 entered the queue
[D1 12:44:27 floor_3] citizen_67 found an empty queue and will be served immediately
[D1 12:44:27 elevator_2] Summoned to floor 3 from floor 3
[D1 12:44:27 citizen_67] Entered elevator_2, going to floor 1
[D1 12:44:27 floor_3] citizen_67 is leaving the queue
[D1 12:44:27 floor_3] The queue is now empty
[D1 12:44:35 elevator_2] Closing doors
[D1 12:44:38 elevator_2] Closed doors
[D1 12:44:45 citizen_122] Entered the building, will visit 4 floors in total
[D1 12:44:45 citizen_122] Time to go to floor 1 and stay there for 00:25:31
[D1 12:44:45 floor_0] citizen_122 entered the queue
[D1 12:44:45 floor_0] citizen_122 found an empty queue and will be served immediately
[D1 12:44:45 elevator_1] Summoned to floor 0 from floor 2
[D1 12:44:45 elevator_1] Sprung into motion, heading Down
[D1 12:44:46 citizen_69] Time to go to the ground floor and leave
[D1 12:44:46 floor_4] citizen_69 entered the queue
[D1 12:44:46 floor_4] citizen_69 found an empty queue and will be served immediately
[D1 12:44:46 elevator_2] Summoned to floor 4 from floor 3
[D1 12:44:48 elevator_2] At floor 4
[D1 12:44:48 elevator_2] Stopped at floor 4
[D1 12:44:48 elevator_2] Opening doors
[D1 12:44:51 elevator_2] Opened doors
[D1 12:44:51 citizen_109] Left elevator_2, arrived at floor 4
[D1 12:44:51 citizen_120] Left elevator_2, arrived at floor 4
[D1 12:44:51 citizen_69] Entered elevator_2, going to floor 0
[D1 12:44:51 floor_4] citizen_69 is leaving the queue
[D1 12:44:51 floor_4] The queue is now empty
[D1 12:44:55 elevator_1] At floor 1
[D1 12:45:03 elevator_2] Closing doors
[D1 12:45:05 elevator_1] At floor 0
[D1 12:45:05 elevator_1] Stopped at floor 0
[D1 12:45:05 elevator_1] Opening doors
[D1 12:45:06 elevator_2] Closed doors
[D1 12:45:06 elevator_2] Changing direction to Down
[D1 12:45:08 elevator_1] Opened doors
[D1 12:45:08 citizen_122] Entered elevator_1, going to floor 1
[D1 12:45:08 floor_0] citizen_122 is leaving the queue
[D1 12:45:08 floor_0] The queue is now empty
[D1 12:45:16 elevator_2] At floor 3
[D1 12:45:20 elevator_1] Closing doors
[D1 12:45:23 elevator_1] Closed doors
[D1 12:45:23 elevator_1] Changing direction to Up
[D1 12:45:26 elevator_2] At floor 2
[D1 12:45:26 elevator_2] Stopped at floor 2
[D1 12:45:26 elevator_2] Opening doors
[D1 12:45:29 elevator_2] Opened doors
[D1 12:45:29 citizen_97] Left elevator_2, arrived at floor 2
[D1 12:45:33 elevator_1] At floor 1
[D1 12:45:33 elevator_1] Stopped at floor 1
[D1 12:45:33 elevator_1] Opening doors
[D1 12:45:34 citizen_107] Time to go to floor 2 and stay there for 00:35:05
[D1 12:45:34 floor_5] citizen_107 entered the queue
[D1 12:45:34 floor_5] citizen_107 found an empty queue and will be served immediately
[D1 12:45:34 elevator_2] Summoned to floor 5 from floor 2
[D1 12:45:36 elevator_1] Opened doors
[D1 12:45:36 citizen_122] Left elevator_1, arrived at floor 1
[D1 12:45:41 elevator_2] Closing doors
[D1 12:45:44 citizen_77] Time to go to floor 2 and stay there for 00:23:59
[D1 12:45:44 floor_3] citizen_77 entered the queue
[D1 12:45:44 floor_3] citizen_77 found an empty queue and will be served immediately
[D1 12:45:44 elevator_2] Summoned to floor 3 from floor 2
[D1 12:45:44 elevator_2] Closed doors
[D1 12:45:48 elevator_1] Closing doors
[D1 12:45:51 elevator_1] Closed doors
[D1 12:45:51 elevator_1] Resting at floor 1
[D1 12:45:54 elevator_2] At floor 1
[D1 12:45:54 elevator_2] Stopped at floor 1
[D1 12:45:54 elevator_2] Opening doors
[D1 12:45:57 elevator_2] Opened doors
[D1 12:45:57 citizen_67] Left elevator_2, arrived at floor 1
[D1 12:46:07 citizen_96] Time to go to floor 3 and stay there for 00:22:09
[D1 12:46:07 floor_2] citizen_96 entered the queue
[D1 12:46:07 floor_2] citizen_96 found an empty queue and will be served immediately
[D1 12:46:07 elevator_1] Summoned to floor 2 from floor 1
[D1 12:46:07 elevator_1] Sprung into motion, heading Up
[D1 12:46:07 elevator_2] Summoned to floor 2 from floor 1
[D1 12:46:09 elevator_2] Closing doors
[D1 12:46:12 elevator_2] Closed doors
[D1 12:46:17 elevator_1] At floor 2
[D1 12:46:17 elevator_1] Stopped at floor 2
[D1 12:46:17 elevator_1] Opening doors
[D1 12:46:20 elevator_1] Opened doors
[D1 12:46:20 citizen_96] Entered elevator_1, going to floor 3
[D1 12:46:20 floor_2] citizen_96 is leaving the queue
[D1 12:46:20 floor_2] The queue is now empty
[D1 12:46:22 elevator_2] At floor 0
[D1 12:46:22 elevator_2] Stopped at floor 0
[D1 12:46:22 elevator_2] Opening doors
[D1 12:46:25 elevator_2] Opened doors
[D1 12:46:25 citizen_69] Left elevator_2, arrived at floor 0
[D1 12:46:25 citizen_69] Left the building
[D1 12:46:27 citizen_72] Time to go to the ground floor and leave
[D1 12:46:27 floor_1] citizen_72 entered the queue
[D1 12:46:27 floor_1] citizen_72 found an empty queue and will be served immediately
[D1 12:46:27 elevator_1] Summoned to floor 1 from floor 2
[D1 12:46:27 elevator_2] Summoned to floor 1 from floor 0
[D1 12:46:32 elevator_1] Closing doors
[D1 12:46:35 elevator_1] Closed doors
[D1 12:46:37 elevator_2] Closing doors
[D1 12:46:40 elevator_2] Closed doors
[D1 12:46:40 elevator_2] Changing direction to Up
[D1 12:46:41 citizen_91] Time to go to floor 1 and stay there for 00:24:03
[D1 12:46:41 floor_2] citizen_91 entered the queue
[D1 12:46:41 floor_2] citizen_91 found an empty queue and will be served immediately
[D1 12:46:41 elevator_1] Summoned to floor 2 from floor 2
[D1 12:46:45 elevator_1] At floor 3
[D1 12:46:45 elevator_1] Stopped at floor 3
[D1 12:46:45 elevator_1] Opening doors
[D1 12:46:46 citizen_88] Time to go to floor 3 and stay there for 00:36:02
[D1 12:46:46 floor_1] citizen_88 entered the queue
[D1 12:46:46 floor_1] citizen_88 is queued along with 0 other arrivals in front of it
[D1 12:46:48 elevator_1] Opened doors
[D1 12:46:48 citizen_96] Left elevator_1, arrived at floor 3
[D1 12:46:50 elevator_2] At floor 1
[D1 12:46:50 elevator_2] Stopped at floor 1
[D1 12:46:50 elevator_2] Opening doors
[D1 12:46:53 elevator_2] Opened doors
[D1 12:46:53 citizen_72] Entered elevator_2, going to floor 0
[D1 12:46:53 floor_1] citizen_72 is leaving the queue
[D1 12:46:53 floor_1] citizen_88 was served
[D1 12:46:53 elevator_2] Summoned to floor 1 from floor 1
[D1 12:46:53 citizen_88] Entered elevator_2, going to floor 3
[D1 12:46:53 floor_1] citizen_88 is leaving the queue
[D1 12:46:53 floor_1] The queue is now empty
[D1 12:47:00 elevator_1] Closing doors
[D1 12:47:03 elevator_1] Closed doors
[D1 12:47:03 elevator_1] Changing direction to Down
[D1 12:47:05 elevator_2] Closing doors
[D1 12:47:08 elevator_2] Closed doors
[D1 12:47:13 elevator_1] At floor 2
[D1 12:47:13 elevator_1] Stopped at floor 2
[D1 12:47:13 elevator_1] Opening doors
[D1 12:47:16 elevator_1] Opened doors
[D1 12:47:16 citizen_91] Entered elevator_1, going to floor 1
[D1 12:47:16 floor_2] citizen_91 is leaving the queue
[D1 12:47:16 floor_2] The queue is now empty
[D1 12:47:18 elevator_2] At floor 2
[D1 12:47:18 elevator_2] Stopped at floor 2
[D1 12:47:18 elevator_2] Opening doors
[D1 12:47:21 elevator_2] Opened doors
[D1 12:47:22 citizen_82] Time to go to floor 4 and stay there for 00:31:16
[D1 12:47:22 floor_2] citizen_82 entered the queue
[D1 12:47:22 floor_2] citizen_82 found an empty queue and will be served immediately
[D1 12:47:22 elevator_1] Summoned to floor 2 from floor 2
[D1 12:47:22 elevator_2] Summoned to floor 2 from floor 2
[D1 12:47:22 citizen_82] Entered elevator_1, going to floor 4
[D1 12:47:22 floor_2] citizen_82 is leaving the queue
[D1 12:47:22 floor_2] The queue is now empty
[D1 12:47:28 elevator_1] Closing doors
[D1 12:47:31 elevator_1] Closed doors
[D1 12:47:33 elevator_2] Closing doors
[D1 12:47:36 elevator_2] Closed doors
[D1 12:47:41 elevator_1] At floor 1
[D1 12:47:41 elevator_1] Stopped at floor 1
[D1 12:47:41 elevator_1] Opening doors
[D1 12:47:44 elevator_1] Opened doors
[D1 12:47:44 citizen_91] Left elevator_1, arrived at floor 1
[D1 12:47:46 elevator_2] At floor 3
[D1 12:47:46 elevator_2] Stopped at floor 3
[D1 12:47:46 elevator_2] Opening doors
[D1 12:47:49 elevator_2] Opened doors
[D1 12:47:49 citizen_88] Left elevator_2, arrived at floor 3
[D1 12:47:49 citizen_77] Entered elevator_2, going to floor 2
[D1 12:47:49 floor_3] citizen_77 is leaving the queue
[D1 12:47:49 floor_3] The queue is now empty
[D1 12:47:56 elevator_1] Closing doors
[D1 12:47:59 elevator_1] Closed doors
[D1 12:47:59 elevator_1] Changing direction to Up
[D1 12:48:01 elevator_2] Closing doors
[D1 12:48:04 elevator_2] Closed doors
[D1 12:48:09 elevator_1] At floor 2
[D1 12:48:12 citizen_110] Time to go to floor 2 and stay there for 00:21:42
[D1 12:48:12 floor_3] citizen_110 entered the queue
[D1 12:48:12 floor_3] citizen_110 found an empty queue and will be served immediately
[D1 12:48:12 elevator_2] Summoned to floor 3 from floor 3
[D1 12:48:13 citizen_123] Entered the building, will visit 4 floors in total
[D1 12:48:13 citizen_123] Time to go to floor 1 and stay there for 00:30:44
[D1 12:48:13 floor_0] citizen_123 entered the queue
[D1 12:48:13 floor_0] citizen_123 found an empty queue and will be served immediately
[D1 12:48:13 elevator_1] Summoned to floor 0 from floor 2
[D1 12:48:14 elevator_2] At floor 4
[D1 12:48:14 citizen_98] Time to go to floor 3 and stay there for 00:35:08
[D1 12:48:14 floor_4] citizen_98 entered the queue
[D1 12:48:14 floor_4] citizen_98 found an empty queue and will be served immediately
[D1 12:48:14 elevator_2] Summoned to floor 4 from floor 4
[D1 12:48:19 elevator_1] At floor 3
[D1 12:48:24 elevator_2] At floor 5
[D1 12:48:24 elevator_2] Stopped at floor 5
[D1 12:48:24 elevator_2] Opening doors
[D1 12:48:27 elevator_2] Opened doors
[D1 12:48:27 citizen_107] Entered elevator_2, going to floor 2
[D1 12:48:27 floor_5] citizen_107 is leaving the queue
[D1 12:48:27 floor_5] The queue is now empty
[D1 12:48:29 elevator_1] At floor 4
[D1 12:48:29 elevator_1] Stopped at floor 4
[D1 12:48:29 elevator_1] Opening doors
[D1 12:48:32 elevator_1] Opened doors
[D1 12:48:32 citizen_82] Left elevator_1, arrived at floor 4
[D1 12:48:39 elevator_2] Closing doors
[D1 12:48:42 elevator_2] Closed doors
[D1 12:48:42 elevator_2] Changing direction to Down
[D1 12:48:44 elevator_1] Closing doors
[D1 12:48:47 elevator_1] Closed doors
[D1 12:48:47 elevator_1] Changing direction to Down
[D1 12:48:52 elevator_2] At floor 4
[D1 12:48:52 elevator_2] Stopped at floor 4
[D1 12:48:52 elevator_2] Opening doors
[D1 12:48:55 elevator_2] Opened doors
[D1 12:48:55 citizen_98] Entered elevator_2, going to floor 3
[D1 12:48:55 floor_4] citizen_98 is leaving the queue
[D1 12:48:55 floor_4] The queue is now empty
[D1 12:48:57 elevator_1] At floor 3
[D1 12:49:07 elevator_2] Closing doors
[D1 12:49:07 elevator_1] At floor 2
[D1 12:49:10 elevator_2] Closed doors
[D1 12:49:17 elevator_1] At floor 1
[D1 12:49:20 elevator_2] At floor 3
[D1 12:49:20 elevator_2] Stopped at floor 3
[D1 12:49:20 elevator_2] Opening doors
[D1 12:49:23 elevator_2] Opened doors
[D1 12:49:23 citizen_98] Left elevator_2, arrived at floor 3
[D1 12:49:23 citizen_110] Entered elevator_2, going to floor 2
[D1 12:49:23 floor_3] citizen_110 is leaving the queue
[D1 12:49:23 floor_3] The queue is now empty
[D1 12:49:27 elevator_1] At floor 0
[D1 12:49:27 elevator_1] Stopped at floor 0
[D1 12:49:27 elevator_1] Opening doors
[D1 12:49:30 elevator_1] Opened doors
[D1 12:49:30 citizen_123] Entered elevator_1, going to floor 1
[D1 12:49:30 floor_0] citizen_123 is leaving the queue
[D1 12:49:30 floor_0] The queue is now empty
[D1 12:49:35 elevator_2] Closing doors
[D1 12:49:37 citizen_81] Time to go to floor 3 and stay there for 00:26:46
[D1 12:49:37 floor_1] citizen_81 entered the queue
[D1 12:49:37 floor_1] citizen_81 found an empty queue and will be served immediately
[D1 12:49:37 elevator_1] Summoned to floor 1 from floor 0
[D1 12:49:38 elevator_2] Closed doors
[D1 12:49:42 elevator_1] Closing doors
[D1 12:49:45 citizen_89] Time to go to floor 3 and stay there for 00:22:11
[D1 12:49:45 floor_1] citizen_89 entered the queue
[D1 12:49:45 floor_1] citizen_89 is queued along with 0 other arrivals in front of it
[D1 12:49:45 elevator_1] Closed doors
[D1 12:49:45 elevator_1] Changing direction to Up
[D1 12:49:48 elevator_2] At floor 2
[D1 12:49:48 elevator_2] Stopped at floor 2
[D1 12:49:48 elevator_2] Opening doors
[D1 12:49:51 elevator_2] Opened doors
[D1 12:49:51 citizen_77] Left elevator_2, arrived at floor 2
[D1 12:49:51 citizen_107] Left elevator_2, arrived at floor 2
[D1 12:49:51 citizen_110] Left elevator_2, arrived at floor 2
[D1 12:49:55 elevator_1] At floor 1
[D1 12:49:55 elevator_1] Stopped at floor 1
[D1 12:49:55 elevator_1] Opening doors
[D1 12:49:58 elevator_1] Opened doors
[D1 12:49:58 citizen_123] Left elevator_1, arrived at floor 1
[D1 12:49:58 citizen_81] Entered elevator_1, going to floor 3
[D1 12:49:58 floor_1] citizen_81 is leaving the queue
[D1 12:49:58 floor_1] citizen_89 was served
[D1 12:49:58 elevator_1] Summoned to floor 1 from floor 1
[D1 12:49:58 citizen_89] Entered elevator_1, going to floor 3
[D1 12:49:58 floor_1] citizen_89 is leaving the queue
[D1 12:49:58 floor_1] The queue is now empty
[D1 12:50:03 elevator_2] Closing doors
[D1 12:50:06 elevator_2] Closed doors
[D1 12:50:10 elevator_1] Closing doors
[D1 12:50:13 elevator_1] Closed doors
[D1 12:50:16 elevator_2] At floor 1
[D1 12:50:23 elevator_1] At floor 2
[D1 12:50:26 elevator_2] At floor 0
[D1 12:50:26 elevator_2] Stopped at floor 0
[D1 12:50:26 elevator_2] Opening doors
[D1 12:50:29 elevator_2] Opened doors
[D1 12:50:29 citizen_72] Left elevator_2, arrived at floor 0
[D1 12:50:29 citizen_72] Left the building
[D1 12:50:33 elevator_1] At floor 3
[D1 12:50:33 elevator_1] Stopped at floor 3
[D1 12:50:33 elevator_1] Opening doors
[D1 12:50:36 elevator_1] Opened doors
[D1 12:50:36 citizen_81] Left elevator_1, arrived at floor 3
[D1 12:50:36 citizen_89] Left elevator_1, arrived at floor 3
[D1 12:50:41 elevator_2] Closing doors
[D1 12:50:44 elevator_2] Closed doors
[D1 12:50:44 elevator_2] Resting at floor 0
[D1 12:50:48 elevator_1] Closing doors
[D1 12:50:51 elevator_1] Closed doors
[D1 12:50:51 elevator_1] Resting at floor 3
[D1 12:51:16 citizen_124] Entered the building, will visit 5 floors in total
[D1 12:51:16 citizen_124] Time to go to floor 4 and stay there for 00:34:41
[D1 12:51:16 floor_0] citizen_124 entered the queue
[D1 12:51:16 floor_0] citizen_124 found an empty queue and will be served immediately
[D1 12:51:16 elevator_2] Summoned to floor 0 from floor 0
[D1 12:51:16 elevator_2] Opening doors
[D1 12:51:19 elevator_2] Opened doors
[D1 12:51:19 citizen_124] Entered elevator_2, going to floor 4
[D1 12:51:19 floor_0] citizen_124 is leaving the queue
[D1 12:51:19 floor_0] The queue is now empty
[D1 12:51:31 elevator_2] Closing doors
[D1 12:51:34 elevator_2] Closed doors
[D1 12:51:34 elevator_2] Sprung into motion, heading Up
[D1 12:51:38 citizen_93] Time to go to floor 1 and stay there for 00:19:13
[D1 12:51:38 floor_3] citizen_93 entered the queue
[D1 12:51:38 floor_3] citizen_93 found an empty queue and will be served immediately
[D1 12:51:38 elevator_1] Summoned to floor 3 from floor 3
[D1 12:51:38 elevator_1] Opening doors
[D1 12:51:41 elevator_1] Opened doors
[D1 12:51:41 citizen_93] Entered elevator_1, going to floor 1
[D1 12:51:41 floor_3] citizen_93 is leaving the queue
[D1 12:51:41 floor_3] The queue is now empty
[D1 12:51:44 elevator_2] At floor 1
[D1 12:51:53 elevator_1] Closing doors
[D1 12:51:54 elevator_2] At floor 2
[D1 12:51:56 elevator_1] Closed doors
[D1 12:51:56 elevator_1] Sprung into motion, heading Down
[D1 12:52:04 elevator_2] At floor 3
[D1 12:52:06 elevator_1] At floor 2
[D1 12:52:06 citizen_68] Time to go to floor 3 and stay there for 00:32:52
[D1 12:52:06 floor_1] citizen_68 entered the queue
[D1 12:52:06 floor_1] citizen_68 found an empty queue and will be served immediately
[D1 12:52:06 elevator_1] Summoned to floor 1 from floor 2
[D1 12:52:14 elevator_2] At floor 4
[D1 12:52:14 elevator_2] Stopped at floor 4
[D1 12:52:14 elevator_2] Opening doors
[D1 12:52:16 elevator_1] At floor 1
[D1 12:52:16 elevator_1] Stopped at floor 1
[D1 12:52:16 elevator_1] Opening doors
[D1 12:52:17 elevator_2] Opened doors
[D1 12:52:17 citizen_124] Left elevator_2, arrived at floor 4
[D1 12:52:19 elevator_1] Opened doors
[D1 12:52:19 citizen_93] Left elevator_1, arrived at floor 1
[D1 12:52:19 citizen_68] Entered elevator_1, going to floor 3
[D1 12:52:19 floor_1] citizen_68 is leaving the queue
[D1 12:52:19 floor_1] The queue is now empty
[D1 12:52:29 elevator_2] Closing doors
[D1 12:52:30 citizen_125] Entered the building, will visit 5 floors in total
[D1 12:52:30 citizen_125] Time to go to floor 2 and stay there for 00:27:59
[D1 12:52:30 floor_0] citizen_125 entered the queue
[D1 12:52:30 floor_0] citizen_125 found an empty queue and will be served immediately
[D1 12:52:30 elevator_1] Summoned to floor 0 from floor 1
[D1 12:52:31 elevator_1] Closing doors
[D1 12:52:32 elevator_2] Closed doors
[D1 12:52:32 elevator_2] Resting at floor 4
[D1 12:52:34 elevator_1] Closed doors
[D1 12:52:44 elevator_1] At floor 0
[D1 12:52:44 elevator_1] Stopped at floor 0
[D1 12:52:44 elevator_1] Opening doors
[D1 12:52:47 elevator_1] Opened doors
[D1 12:52:47 citizen_125] Entered elevator_1, going to floor 2
[D1 12:52:47 floor_0] citizen_125 is leaving the queue
[D1 12:52:47 floor_0] The queue is now empty
[D1 12:52:59 elevator_1] Closing doors
[D1 12:53:02 elevator_1] Closed doors
[D1 12:53:02 elevator_1] Changing direction to Up
[D1 12:53:12 elevator_1] At floor 1
[D1 12:53:22 elevator_1] At floor 2
[D1 12:53:22 elevator_1] Stopped at floor 2
[D1 12:53:22 elevator_1] Opening doors
[D1 12:53:25 elevator_1] Opened doors
[D1 12:53:25 citizen_125] Left elevator_1, arrived at floor 2
[D1 12:53:37 elevator_1] Closing doors
[D1 12:53:40 elevator_1] Closed doors
[D1 12:53:50 elevator_1] At floor 3
[D1 12:53:50 elevator_1] Stopped at floor 3
[D1 12:53:50 elevator_1] Opening doors
[D1 12:53:53 elevator_1] Opened doors
[D1 12:53:53 citizen_68] Left elevator_1, arrived at floor 3
[D1 12:54:00 citizen_104] Time to go to floor 1 and stay there for 00:22:22
[D1 12:54:00 floor_4] citizen_104 entered the queue
[D1 12:54:00 floor_4] citizen_104 found an empty queue and will be served immediately
[D1 12:54:00 elevator_2] Summoned to floor 4 from floor 4
[D1 12:54:00 elevator_2] Opening doors
[D1 12:54:03 elevator_2] Opened doors
[D1 12:54:03 citizen_104] Entered elevator_2, going to floor 1
[D1 12:54:03 floor_4] citizen_104 is leaving the queue
[D1 12:54:03 floor_4] The queue is now empty
[D1 12:54:05 elevator_1] Closing doors
[D1 12:54:08 elevator_1] Closed doors
[D1 12:54:08 elevator_1] Resting at floor 3
[D1 12:54:15 elevator_2] Closing doors
[D1 12:54:18 elevator_2] Closed doors
[D1 12:54:18 elevator_2] Sprung into motion, heading Down
[D1 12:54:28 elevator_2] At floor 3
[D1 12:54:38 elevator_2] At floor 2
[D1 12:54:48 elevator_2] At floor 1
[D1 12:54:48 elevator_2] Stopped at floor 1
[D1 12:54:48 elevator_2] Opening doors
[D1 12:54:51 elevator_2] Opened doors
[D1 12:54:51 citizen_104] Left elevator_2, arrived at floor 1
[D1 12:55:03 elevator_2] Closing doors
[D1 12:55:06 elevator_2] Closed doors
[D1 12:55:06 elevator_2] Resting at floor 1
[D1 12:55:10 citizen_126] Entered the building, will visit 3 floors in total
[D1 12:55:10 citizen_126] Time to go to floor 1 and stay there for 00:30:31
[D1 12:55:10 floor_0] citizen_126 entered the queue
[D1 12:55:10 floor_0] citizen_126 found an empty queue and will be served immediately
[D1 12:55:10 elevator_2] Summoned to floor 0 from floor 1
[D1 12:55:10 elevator_2] Sprung into motion, heading Down
[D1 12:55:19 citizen_100] Time to go to the ground floor and leave
[D1 12:55:19 floor_2] citizen_100 entered the queue
[D1 12:55:19 floor_2] citizen_100 found an empty queue and will be served immediately
[D1 12:55:19 elevator_1] Summoned to floor 2 from floor 3
[D1 12:55:19 elevator_1] Sprung into motion, heading Down
[D1 12:55:19 elevator_2] Summoned to floor 2 from floor 1
[D1 12:55:20 elevator_2] At floor 0
[D1 12:55:20 elevator_2] Stopped at floor 0
[D1 12:55:20 elevator_2] Opening doors
[D1 12:55:23 elevator_2] Opened doors
[D1 12:55:23 citizen_126] Entered elevator_2, going to floor 1
[D1 12:55:23 floor_0] citizen_126 is leaving the queue
[D1 12:55:23 floor_0] The queue is now empty
[D1 12:55:29 elevator_1] At floor 2
[D1 12:55:29 elevator_1] Stopped at floor 2
[D1 12:55:29 elevator_1] Opening doors
[D1 12:55:32 elevator_1] Opened doors
[D1 12:55:32 citizen_100] Entered elevator_1, going to floor 0
[D1 12:55:32 floor_2] citizen_100 is leaving the queue
[D1 12:55:32 floor_2] The queue is now empty
[D1 12:55:35 elevator_2] Closing doors
[D1 12:55:38 elevator_2] Closed doors
[D1 12:55:38 elevator_2] Changing direction to Up
[D1 12:55:44 elevator_1] Closing doors
[D1 12:55:47 elevator_1] Closed doors
[D1 12:55:48 elevator_2] At floor 1
[D1 12:55:48 elevator_2] Stopped at floor 1
[D1 12:55:48 elevator_2] Opening doors
[D1 12:55:49 citizen_71] Time to go to floor 5 and stay there for 00:34:50
[D1 12:55:49 floor_3] citizen_71 entered the queue
[D1 12:55:49 floor_3] citizen_71 found an empty queue and will be served immediately
[D1 12:55:49 elevator_1] Summoned to floor 3 from floor 2
[D1 12:55:51 elevator_2] Opened doors
[D1 12:55:51 citizen_126] Left elevator_2, arrived at floor 1
[D1 12:55:57 elevator_1] At floor 1
[D1 12:56:03 elevator_2] Closing doors
[D1 12:56:06 elevator_2] Closed doors
[D1 12:56:07 elevator_1] At floor 0
[D1 12:56:07 elevator_1] Stopped at floor 0
[D1 12:56:07 elevator_1] Opening doors
[D1 12:56:10 elevator_1] Opened doors
[D1 12:56:10 citizen_100] Left elevator_1, arrived at floor 0
[D1 12:56:10 citizen_100] Left the building
[D1 12:56:14 citizen_127] Entered the building, will visit 5 floors in total
[D1 12:56:14 citizen_127] Time to go to floor 5 and stay there for 00:36:01
[D1 12:56:14 floor_0] citizen_127 entered the queue
[D1 12:56:14 floor_0] citizen_127 found an empty queue and will be served immediately
[D1 12:56:14 elevator_1] Summoned to floor 0 from floor 0
[D1 12:56:14 citizen_127] Entered elevator_1, going to floor 5
[D1 12:56:14 floor_0] citizen_127 is leaving the queue
[D1 12:56:14 floor_0] The queue is now empty
[D1 12:56:16 elevator_2] At floor 2
[D1 12:56:16 elevator_2] Stopped at floor 2
[D1 12:56:16 elevator_2] Opening doors
[D1 12:56:19 elevator_2] Opened doors
[D1 12:56:22 elevator_1] Closing doors
[D1 12:56:25 elevator_1] Closed doors
[D1 12:56:25 elevator_1] Changing direction to Up
[D1 12:56:31 elevator_2] Closing doors
[D1 12:56:34 elevator_2] Closed doors
[D1 12:56:34 elevator_2] Resting at floor 2
[D1 12:56:35 elevator_1] At floor 1
[D1 12:56:44 citizen_111] Time to go to floor 3 and stay there for 00:33:15
[D1 12:56:44 floor_2] citizen_111 entered the queue
[D1 12:56:44 floor_2] citizen_111 found an empty queue and will be served immediately
[D1 12:56:44 elevator_2] Summoned to floor 2 from floor 2
[D1 12:56:44 elevator_2] Opening doors
[D1 12:56:45 elevator_1] At floor 2
[D1 12:56:47 elevator_2] Opened doors
[D1 12:56:47 citizen_111] Entered elevator_2, going to floor 3
[D1 12:56:47 floor_2] citizen_111 is leaving the queue
[D1 12:56:47 floor_2] The queue is now empty
[D1 12:56:55 elevator_1] At floor 3
[D1 12:56:55 elevator_1] Stopped at floor 3
[D1 12:56:55 elevator_1] Opening doors
[D1 12:56:58 elevator_1] Opened doors
[D1 12:56:58 citizen_71] Entered elevator_1, going to floor 5
[D1 12:56:58 floor_3] citizen_71 is leaving the queue
[D1 12:56:58 floor_3] The queue is now empty
[D1 12:56:59 elevator_2] Closing doors
[D1 12:57:02 elevator_2] Closed doors
[D1 12:57:02 elevator_2] Sprung into motion, heading Up
[D1 12:57:10 elevator_1] Closing doors
[D1 12:57:12 elevator_2] At floor 3
[D1 12:57:12 elevator_2] Stopped at floor 3
[D1 12:57:12 elevator_2] Opening doors
[D1 12:57:13 elevator_1] Closed doors
[D1 12:57:15 elevator_2] Opened doors
[D1 12:57:15 citizen_111] Left elevator_2, arrived at floor 3
[D1 12:57:23 elevator_1] At floor 4
[D1 12:57:27 elevator_2] Closing doors
[D1 12:57:30 elevator_2] Closed doors
[D1 12:57:30 elevator_2] Resting at floor 3
[D1 12:57:33 elevator_1] At floor 5
[D1 12:57:33 elevator_1] Stopped at floor 5
[D1 12:57:33 elevator_1] Opening doors
[D1 12:57:36 elevator_1] Opened doors
[D1 12:57:36 citizen_127] Left elevator_1, arrived at floor 5
[D1 12:57:36 citizen_71] Left elevator_1, arrived at floor 5
[D1 12:57:48 elevator_1] Closing doors
[D1 12:57:51 elevator_1] Closed doors
[D1 12:57:51 elevator_1] Resting at floor 5
[D1 12:57:53 citizen_128] Entered the building, will visit 6 floors in total
[D1 12:57:53 citizen_128] Time to go to floor 2 and stay there for 00:23:10
[D1 12:57:53 floor_0] citizen_128 entered the queue
[D1 12:57:53 floor_0] citizen_128 found an empty queue and will be served immediately
[D1 12:57:53 elevator_2] Summoned to floor 0 from floor 3
[D1 12:57:53 elevator_2] Sprung into motion, heading Down
[D1 12:58:03 elevator_2] At floor 2
[D1 12:58:13 elevator_2] At floor 1
[D1 12:58:23 elevator_2] At floor 0
[D1 12:58:23 elevator_2] Stopped at floor 0
[D1 12:58:23 elevator_2] Opening doors
[D1 12:58:26 elevator_2] Opened doors
[D1 12:58:26 citizen_128] Entered elevator_2, going to floor 2
[D1 12:58:26 floor_0] citizen_128 is leaving the queue
[D1 12:58:26 floor_0] The queue is now empty
[D1 12:58:38 elevator_2] Closing doors
[D1 12:58:41 elevator_2] Closed doors
[D1 12:58:41 elevator_2] Changing direction to Up
[D1 12:58:43 citizen_78] Time to go to the ground floor and leave
[D1 12:58:43 floor_2] citizen_78 entered the queue
[D1 12:58:43 floor_2] citizen_78 found an empty queue and will be served immediately
[D1 12:58:43 elevator_2] Summoned to floor 2 from floor 0
[D1 12:58:51 elevator_2] At floor 1
[D1 12:58:57 citizen_52] Time to go to the ground floor and leave
[D1 12:58:57 floor_4] citizen_52 entered the queue
[D1 12:58:57 floor_4] citizen_52 found an empty queue and will be served immediately
[D1 12:58:57 elevator_1] Summoned to floor 4 from floor 5
[D1 12:58:57 elevator_1] Sprung into motion, heading Down
[D1 12:59:01 elevator_2] At floor 2
[D1 12:59:01 elevator_2] Stopped at floor 2
[D1 12:59:01 elevator_2] Opening doors
[D1 12:59:04 elevator_2] Opened doors
[D1 12:59:04 citizen_128] Left elevator_2, arrived at floor 2
[D1 12:59:04 citizen_78] Entered elevator_2, going to floor 0
[D1 12:59:04 floor_2] citizen_78 is leaving the queue
[D1 12:59:04 floor_2] The queue is now empty
[D1 12:59:07 elevator_1] At floor 4
[D1 12:59:07 elevator_1] Stopped at floor 4
[D1 12:59:07 elevator_1] Opening doors
[D1 12:59:10 elevator_1] Opened doors
[D1 12:59:10 citizen_52] Entered elevator_1, going to floor 0
[D1 12:59:10 floor_4] citizen_52 is leaving the queue
[D1 12:59:10 floor_4] The queue is now empty
[D1 12:59:16 elevator_2] Closing doors
[D1 12:59:19 elevator_2] Closed doors
[D1 12:59:19 elevator_2] Changing direction to Down
[D1 12:59:22 elevator_1] Closing doors
[D1 12:59:25 elevator_1] Closed doors
[D1 12:59:29 elevator_2] At floor 1
[D1 12:59:35 elevator_1] At floor 3
[D1 12:59:39 elevator_2] At floor 0
[D1 12:59:39 elevator_2] Stopped at floor 0
[D1 12:59:39 elevator_2] Opening doors
[D1 12:59:42 elevator_2] Opened doors
[D1 12:59:42 citizen_78] Left elevator_2, arrived at floor 0
[D1 12:59:42 citizen_78] Left the building
[D1 12:59:44 citizen_80] Time to go to floor 5 and stay there for 00:23:47
[D1 12:59:44 floor_4] citizen_80 entered the queue
[D1 12:59:44 floor_4] citizen_80 found an empty queue and will be served immediately
[D1 12:59:44 elevator_1] Summoned to floor 4 from floor 3
[D1 12:59:45 elevator_1] At floor 2
[D1 12:59:54 elevator_2] Closing doors
[D1 12:59:55 elevator_1] At floor 1
[D1 12:59:57 elevator_2] Closed doors
[D1 12:59:57 elevator_2] Resting at floor 0
[D1 13:00:05 elevator_1] At floor 0
[D1 13:00:05 elevator_1] Stopped at floor 0
[D1 13:00:05 elevator_1] Opening doors
[D1 13:00:08 elevator_1] Opened doors
[D1 13:00:08 citizen_52] Left elevator_1, arrived at floor 0
[D1 13:00:08 citizen_52] Left the building
[D1 13:00:20 elevator_1] Closing doors
[D1 13:00:23 elevator_1] Closed doors
[D1 13:00:23 elevator_1] Changing direction to Up
[D1 13:00:25 citizen_94] Time to go to floor 1 and stay there for 00:17:20
[D1 13:00:25 floor_4] citizen_94 entered the queue
[D1 13:00:25 floor_4] citizen_94 is queued along with 0 other arrivals in front of it
[D1 13:00:33 elevator_1] At floor 1
[D1 13:00:34 citizen_113] Time to go to floor 4 and stay there for 00:37:53
[D1 13:00:34 floor_2] citizen_113 entered the queue
[D1 13:00:34 floor_2] citizen_113 found an empty queue and will be served immediately
[D1 13:00:34 elevator_1] Summoned to floor 2 from floor 1
[D1 13:00:43 elevator_1] At floor 2
[D1 13:00:43 elevator_1] Stopped at floor 2
[D1 13:00:43 elevator_1] Opening doors
[D1 13:00:45 citizen_102] Time to go to floor 5 and stay there for 00:31:53
[D1 13:00:45 floor_4] citizen_102 entered the queue
[D1 13:00:45 floor_4] citizen_102 is queued along with 1 other arrivals in front of it
[D1 13:00:46 elevator_1] Opened doors
[D1 13:00:46 citizen_113] Entered elevator_1, going to floor 4
[D1 13:00:46 floor_2] citizen_113 is leaving the queue
[D1 13:00:46 floor_2] The queue is now empty
[D1 13:00:58 elevator_1] Closing doors
[D1 13:01:01 elevator_1] Closed doors
[D1 13:01:11 elevator_1] At floor 3
[D1 13:01:21 elevator_1] At floor 4
[D1 13:01:21 elevator_1] Stopped at floor 4
[D1 13:01:21 elevator_1] Opening doors
[D1 13:01:24 elevator_1] Opened doors
[D1 13:01:24 citizen_113] Left elevator_1, arrived at floor 4
[D1 13:01:24 citizen_80] Entered elevator_1, going to floor 5
[D1 13:01:24 floor_4] citizen_80 is leaving the queue
[D1 13:01:24 floor_4] citizen_94 was served
[D1 13:01:24 elevator_1] Summoned to floor 4 from floor 4
[D1 13:01:24 citizen_94] Entered elevator_1, going to floor 1
[D1 13:01:24 floor_4] citizen_94 is leaving the queue
[D1 13:01:24 floor_4] citizen_102 was served
[D1 13:01:24 elevator_1] Summoned to floor 4 from floor 4
[D1 13:01:24 citizen_102] Entered elevator_1, going to floor 5
[D1 13:01:24 floor_4] citizen_102 is leaving the queue
[D1 13:01:24 floor_4] The queue is now empty
[D1 13:01:36 elevator_1] Closing doors
[D1 13:01:39 elevator_1] Closed doors
[D1 13:01:49 elevator_1] At floor 5
[D1 13:01:49 elevator_1] Stopped at floor 5
[D1 13:01:49 elevator_1] Opening doors
[D1 13:01:52 elevator_1] Opened doors
[D1 13:01:52 citizen_80] Left elevator_1, arrived at floor 5
[D1 13:01:52 citizen_102] Left elevator_1, arrived at floor 5
[D1 13:02:04 elevator_1] Closing doors
[D1 13:02:06 citizen_86] Time to go to floor 4 and stay there for 00:29:35
[D1 13:02:06 floor_1] citizen_86 entered the queue
[D1 13:02:06 floor_1] citizen_86 found an empty queue and will be served immediately
[D1 13:02:06 elevator_2] Summoned to floor 1 from floor 0
[D1 13:02:06 elevator_2] Sprung into motion, heading Up
[D1 13:02:07 elevator_1] Closed doors
[D1 13:02:07 elevator_1] Changing direction to Down
[D1 13:02:16 elevator_2] At floor 1
[D1 13:02:16 elevator_2] Stopped at floor 1
[D1 13:02:16 elevator_2] Opening doors
[D1 13:02:17 elevator_1] At floor 4
[D1 13:02:19 elevator_2] Opened doors
[D1 13:02:19 citizen_86] Entered elevator_2, going to floor 4
[D1 13:02:19 floor_1] citizen_86 is leaving the queue
[D1 13:02:19 floor_1] The queue is now empty
[D1 13:02:27 elevator_1] At floor 3
[D1 13:02:31 elevator_2] Closing doors
[D1 13:02:34 elevator_2] Closed doors
[D1 13:02:37 elevator_1] At floor 2
[D1 13:02:44 elevator_2] At floor 2
[D1 13:02:47 elevator_1] At floor 1
[D1 13:02:47 elevator_1] Stopped at floor 1
[D1 13:02:47 elevator_1] Opening doors
[D1 13:02:50 elevator_1] Opened doors
[D1 13:02:50 citizen_94] Left elevator_1, arrived at floor 1
[D1 13:02:54 elevator_2] At floor 3
[D1 13:03:02 elevator_1] Closing doors
[D1 13:03:04 elevator_2] At floor 4
[D1 13:03:04 elevator_2] Stopped at floor 4
[D1 13:03:04 elevator_2] Opening doors
[D1 13:03:05 citizen_112] Time to go to floor 3 and stay there for 00:39:49
[D1 13:03:05 floor_5] citizen_112 entered the queue
[D1 13:03:05 floor_5] citizen_112 found an empty queue and will be served immediately
[D1 13:03:05 elevator_2] Summoned to floor 5 from floor 4
[D1 13:03:05 elevator_1] Closed doors
[D1 13:03:05 elevator_1] Resting at floor 1
[D1 13:03:07 elevator_2] Opened doors
[D1 13:03:07 citizen_86] Left elevator_2, arrived at floor 4
[D1 13:03:15 citizen_118] Time to go to floor 1 and stay there for 00:35:19
[D1 13:03:15 floor_2] citizen_118 entered the queue
[D1 13:03:15 floor_2] citizen_118 found an empty queue and will be served immediately
[D1 13:03:15 elevator_1] Summoned to floor 2 from floor 1
[D1 13:03:15 elevator_1] Sprung into motion, heading Up
[D1 13:03:15 citizen_95] Time to go to floor 1 and stay there for 00:21:19
[D1 13:03:15 floor_3] citizen_95 entered the queue
[D1 13:03:15 floor_3] citizen_95 found an empty queue and will be served immediately
[D1 13:03:15 elevator_2] Summoned to floor 3 from floor 4
[D1 13:03:19 elevator_2] Closing doors
[D1 13:03:22 elevator_2] Closed doors
[D1 13:03:25 elevator_1] At floor 2
[D1 13:03:25 elevator_1] Stopped at floor 2
[D1 13:03:25 elevator_1] Opening doors
[D1 13:03:28 elevator_1] Opened doors
[D1 13:03:28 citizen_118] Entered elevator_1, going to floor 1
[D1 13:03:28 floor_2] citizen_118 is leaving the queue
[D1 13:03:28 floor_2] The queue is now empty
[D1 13:03:29 citizen_116] Time to go to floor 3 and stay there for 00:18:23
[D1 13:03:29 floor_1] citizen_116 entered the queue
[D1 13:03:29 floor_1] citizen_116 found an empty queue and will be served immediately
[D1 13:03:29 elevator_1] Summoned to floor 1 from floor 2
[D1 13:03:32 elevator_2] At floor 5
[D1 13:03:32 elevator_2] Stopped at floor 5
[D1 13:03:32 elevator_2] Opening doors
[D1 13:03:35 elevator_2] Opened doors
[D1 13:03:35 citizen_112] Entered elevator_2, going to floor 3
[D1 13:03:35 floor_5] citizen_112 is leaving the queue
[D1 13:03:35 floor_5] The queue is now empty
[D1 13:03:40 elevator_1] Closing doors
[D1 13:03:43 elevator_1] Closed doors
[D1 13:03:43 elevator_1] Changing direction to Down
[D1 13:03:47 elevator_2] Closing doors
[D1 13:03:50 elevator_2] Closed doors
[D1 13:03:50 elevator_2] Changing direction to Down
[D1 13:03:53 elevator_1] At floor 1
[D1 13:03:53 elevator_1] Stopped at floor 1
[D1 13:03:53 elevator_1] Opening doors
[D1 13:03:56 elevator_1] Opened doors
[D1 13:03:56 citizen_118] Left elevator_1, arrived at floor 1
[D1 13:03:56 citizen_116] Entered elevator_1, going to floor 3
[D1 13:03:56 floor_1] citizen_116 is leaving the queue
[D1 13:03:56 floor_1] The queue is now empty
[D1 13:04:00 elevator_2] At floor 4
[D1 13:04:08 elevator_1] Closing doors
[D1 13:04:10 elevator_2] At floor 3
[D1 13:04:10 elevator_2] Stopped at floor 3
[D1 13:04:10 elevator_2] Opening doors
[D1 13:04:11 elevator_1] Closed doors
[D1 13:04:11 elevator_1] Changing direction to Up
[D1 13:04:13 elevator_2] Opened doors
[D1 13:04:13 citizen_112] Left elevator_2, arrived at floor 3
[D1 13:04:13 citizen_95] Entered elevator_2, going to floor 1
[D1 13:04:13 floor_3] citizen_95 is leaving the queue
[D1 13:04:13 floor_3] The queue is now empty
[D1 13:04:21 elevator_1] At floor 2
[D1 13:04:24 citizen_119] Time to go to floor 3 and stay there for 00:28:18
[D1 13:04:24 floor_4] citizen_119 entered the queue
[D1 13:04:24 floor_4] citizen_119 found an empty queue and will be served immediately
[D1 13:04:24 elevator_2] Summoned to floor 4 from floor 3
[D1 13:04:25 elevator_2] Closing doors
[D1 13:04:28 elevator_2] Closed doors
[D1 13:04:31 elevator_1] At floor 3
[D1 13:04:31 elevator_1] Stopped at floor 3
[D1 13:04:31 elevator_1] Opening doors
[D1 13:04:34 elevator_1] Opened doors
[D1 13:04:34 citizen_116] Left elevator_1, arrived at floor 3
[D1 13:04:35 citizen_129] Entered the building, will visit 7 floors in total
[D1 13:04:35 citizen_129] Time to go to floor 5 and stay there for 00:34:30
[D1 13:04:35 floor_0] citizen_129 entered the queue
[D1 13:04:35 floor_0] citizen_129 found an empty queue and will be served immediately
[D1 13:04:35 elevator_1] Summoned to floor 0 from floor 3
[D1 13:04:35 elevator_2] Summoned to floor 0 from floor 3
[D1 13:04:38 elevator_2] At floor 2
[D1 13:04:46 elevator_1] Closing doors
[D1 13:04:48 elevator_2] At floor 1
[D1 13:04:48 elevator_2] Stopped at floor 1
[D1 13:04:48 elevator_2] Opening doors
[D1 13:04:49 elevator_1] Closed doors
[D1 13:04:49 elevator_1] Changing direction to Down
[D1 13:04:51 elevator_2] Opened doors
[D1 13:04:51 citizen_95] Left elevator_2, arrived at floor 1
[D1 13:04:59 elevator_1] At floor 2
[D1 13:05:03 elevator_2] Closing doors
[D1 13:05:06 elevator_2] Closed doors
[D1 13:05:09 elevator_1] At floor 1
[D1 13:05:16 elevator_2] At floor 0
[D1 13:05:16 elevator_2] Stopped at floor 0
[D1 13:05:16 elevator_2] Opening doors
[D1 13:05:19 elevator_1] At floor 0
[D1 13:05:19 elevator_1] Stopped at floor 0
[D1 13:05:19 elevator_1] Opening doors
[D1 13:05:19 elevator_2] Opened doors
[D1 13:05:19 citizen_129] Entered elevator_2, going to floor 5
[D1 13:05:19 floor_0] citizen_129 is leaving the queue
[D1 13:05:19 floor_0] The queue is now empty
[D1 13:05:22 elevator_1] Opened doors
[D1 13:05:31 elevator_2] Closing doors
[D1 13:05:34 elevator_1] Closing doors
[D1 13:05:34 elevator_2] Closed doors
[D1 13:05:34 elevator_2] Changing direction to Up
[D1 13:05:37 elevator_1] Closed doors
[D1 13:05:37 elevator_1] Resting at floor 0
[D1 13:05:44 elevator_2] At floor 1
[D1 13:05:53 citizen_108] Time to go to floor 3 and stay there for 00:31:21
[D1 13:05:53 floor_2] citizen_108 entered the queue
[D1 13:05:53 floor_2] citizen_108 found an empty queue and will be served immediately
[D1 13:05:53 elevator_2] Summoned to floor 2 from floor 1
[D1 13:05:53 citizen_83] Time to go to the ground floor and leave
[D1 13:05:53 floor_1] citizen_83 entered the queue
[D1 13:05:53 floor_1] citizen_83 found an empty queue and will be served immediately
[D1 13:05:53 elevator_2] Summoned to floor 1 from floor 1
[D1 13:05:54 elevator_2] At floor 2
[D1 13:05:54 elevator_2] Stopped at floor 2
[D1 13:05:54 elevator_2] Opening doors
[D1 13:05:57 elevator_2] Opened doors
[D1 13:05:57 citizen_108] Entered elevator_2, going to floor 3
[D1 13:05:57 floor_2] citizen_108 is leaving the queue
[D1 13:05:57 floor_2] The queue is now empty
[D1 13:06:09 elevator_2] Closing doors
[D1 13:06:12 elevator_2] Closed doors
[D1 13:06:18 citizen_101] Time to go to floor 4 and stay there for 00:29:28
[D1 13:06:18 floor_3] citizen_101 entered the queue
[D1 13:06:18 floor_3] citizen_101 found an empty queue and will be served immediately
[D1 13:06:18 elevator_2] Summoned to floor 3 from floor 2
[D1 13:06:22 elevator_2] At floor 3
[D1 13:06:22 elevator_2] Stopped at floor 3
[D1 13:06:22 elevator_2] Opening doors
[D1 13:06:25 elevator_2] Opened doors
[D1 13:06:25 citizen_108] Left elevator_2, arrived at floor 3
[D1 13:06:25 citizen_101] Entered elevator_2, going to floor 4
[D1 13:06:25 floor_3] citizen_101 is leaving the queue
[D1 13:06:25 floor_3] The queue is now empty
[D1 13:06:37 elevator_2] Closing doors
[D1 13:06:40 elevator_2] Closed doors
[D1 13:06:50 elevator_2] At floor 4
[D1 13:06:50 elevator_2] Stopped at floor 4
[D1 13:06:50 elevator_2] Opening doors
[D1 13:06:53 elevator_2] Opened doors
[D1 13:06:53 citizen_101] Left elevator_2, arrived at floor 4
[D1 13:06:53 citizen_119] Entered elevator_2, going to floor 3
[D1 13:06:53 floor_4] citizen_119 is leaving the queue
[D1 13:06:53 floor_4] The queue is now empty
[D1 13:07:05 elevator_2] Closing doors
[D1 13:07:08 elevator_2] Closed doors
[D1 13:07:16 citizen_79] Time to go to the ground floor and leave
[D1 13:07:16 floor_1] citizen_79 entered the queue
[D1 13:07:16 floor_1] citizen_79 is queued along with 0 other arrivals in front of it
[D1 13:07:18 elevator_2] At floor 5
[D1 13:07:18 elevator_2] Stopped at floor 5
[D1 13:07:18 elevator_2] Opening doors
[D1 13:07:21 elevator_2] Opened doors
[D1 13:07:21 citizen_129] Left elevator_2, arrived at floor 5
[D1 13:07:33 elevator_2] Closing doors
[D1 13:07:36 elevator_2] Closed doors
[D1 13:07:36 elevator_2] Changing direction to Down
[D1 13:07:46 elevator_2] At floor 4
[D1 13:07:56 elevator_2] At floor 3
[D1 13:07:56 elevator_2] Stopped at floor 3
[D1 13:07:56 elevator_2] Opening doors
[D1 13:07:59 elevator_2] Opened doors
[D1 13:07:59 citizen_119] Left elevator_2, arrived at floor 3
[D1 13:08:11 elevator_2] Closing doors
[D1 13:08:14 elevator_2] Closed doors
[D1 13:08:24 elevator_2] At floor 2
[D1 13:08:25 citizen_76] Time to go to the ground floor and leave
[D1 13:08:25 floor_2] citizen_76 entered the queue
[D1 13:08:25 floor_2] citizen_76 found an empty queue and will be served immediately
[D1 13:08:25 elevator_2] Summoned to floor 2 from floor 2
[D1 13:08:34 elevator_2] At floor 1
[D1 13:08:34 elevator_2] Stopped at floor 1
[D1 13:08:34 elevator_2] Opening doors
[D1 13:08:37 elevator_2] Opened doors
[D1 13:08:37 citizen_83] Entered elevator_2, going to floor 0
[D1 13:08:37 floor_1] citizen_83 is leaving the queue
[D1 13:08:37 floor_1] citizen_79 was served
[D1 13:08:37 elevator_2] Summoned to floor 1 from floor 1
[D1 13:08:37 citizen_79] Entered elevator_2, going to floor 0
[D1 13:08:37 floor_1] citizen_79 is leaving the queue
[D1 13:08:37 floor_1] The queue is now empty
[D1 13:08:49 elevator_2] Closing doors
[D1 13:08:52 elevator_2] Closed doors
[D1 13:08:57 citizen_96] Time to go to floor 5 and stay there for 00:23:00
[D1 13:08:57 floor_3] citizen_96 entered the queue
[D1 13:08:57 floor_3] citizen_96 found an empty queue and will be served immediately
[D1 13:08:57 elevator_2] Summoned to floor 3 from floor 1
[D1 13:09:02 elevator_2] At floor 0
[D1 13:09:02 elevator_2] Stopped at floor 0
[D1 13:09:02 elevator_2] Opening doors
[D1 13:09:05 elevator_2] Opened doors
[D1 13:09:05 citizen_83] Left elevator_2, arrived at floor 0
[D1 13:09:05 citizen_79] Left elevator_2, arrived at floor 0
[D1 13:09:05 citizen_83] Left the building
[D1 13:09:05 citizen_79] Left the building
[D1 13:09:17 elevator_2] Closing doors
[D1 13:09:20 citizen_67] Time to go to floor 4 and stay there for 00:34:32
[D1 13:09:20 floor_1] citizen_67 entered the queue
[D1 13:09:20 floor_1] citizen_67 found an empty queue and will be served immediately
[D1 13:09:20 elevator_1] Summoned to floor 1 from floor 0
[D1 13:09:20 elevator_1] Sprung into motion, heading Up
[D1 13:09:20 elevator_2] Summoned to floor 1 from floor 0
[D1 13:09:20 elevator_2] Closed doors
[D1 13:09:20 elevator_2] Changing direction to Up
[D1 13:09:30 elevator_1] At floor 1
[D1 13:09:30 elevator_1] Stopped at floor 1
[D1 13:09:30 elevator_1] Opening doors
[D1 13:09:30 elevator_2] At floor 1
[D1 13:09:30 elevator_2] Stopped at floor 1
[D1 13:09:30 elevator_2] Opening doors
[D1 13:09:33 elevator_1] Opened doors
[D1 13:09:33 elevator_2] Opened doors
[D1 13:09:33 citizen_67] Entered elevator_1, going to floor 4
[D1 13:09:33 floor_1] citizen_67 is leaving the queue
[D1 13:09:33 floor_1] The queue is now empty
[D1 13:09:45 elevator_1] Closing doors
[D1 13:09:45 elevator_2] Closing doors
[D1 13:09:48 elevator_1] Closed doors
[D1 13:09:48 elevator_2] Closed doors
[D1 13:09:58 elevator_1] At floor 2
[D1 13:09:58 elevator_2] At floor 2
[D1 13:09:58 elevator_2] Stopped at floor 2
[D1 13:09:58 elevator_2] Opening doors
[D1 13:10:01 elevator_2] Opened doors
[D1 13:10:01 citizen_76] Entered elevator_2, going to floor 0
[D1 13:10:01 floor_2] citizen_76 is leaving the queue
[D1 13:10:01 floor_2] The queue is now empty
[D1 13:10:03 citizen_130] Entered the building, will visit 4 floors in total
[D1 13:10:03 citizen_130] Time to go to floor 2 and stay there for 00:27:43
[D1 13:10:03 floor_0] citizen_130 entered the queue
[D1 13:10:03 floor_0] citizen_130 found an empty queue and will be served immediately
[D1 13:10:03 elevator_1] Summoned to floor 0 from floor 2
[D1 13:10:03 elevator_2] Summoned to floor 0 from floor 2
[D1 13:10:08 elevator_1] At floor 3
[D1 13:10:13 elevator_2] Closing doors
[D1 13:10:16 elevator_2] Closed doors
[D1 13:10:18 citizen_114] Time to go to floor 4 and stay there for 00:28:07
[D1 13:10:18 floor_5] citizen_114 entered the queue
[D1 13:10:18 floor_5] citizen_114 found an empty queue and will be served immediately
[D1 13:10:18 elevator_1] Summoned to floor 5 from floor 3
[D1 13:10:18 elevator_1] At floor 4
[D1 13:10:18 elevator_1] Stopped at floor 4
[D1 13:10:18 elevator_1] Opening doors
[D1 13:10:21 elevator_1] Opened doors
[D1 13:10:21 citizen_67] Left elevator_1, arrived at floor 4
[D1 13:10:26 elevator_2] At floor 3
[D1 13:10:26 elevator_2] Stopped at floor 3
[D1 13:10:26 elevator_2] Opening doors
[D1 13:10:29 elevator_2] Opened doors
[D1 13:10:29 citizen_96] Entered elevator_2, going to floor 5
[D1 13:10:29 floor_3] citizen_96 is leaving the queue
[D1 13:10:29 floor_3] The queue is now empty
[D1 13:10:33 elevator_1] Closing doors
[D1 13:10:36 elevator_1] Closed doors
[D1 13:10:41 elevator_2] Closing doors
[D1 13:10:44 elevator_2] Closed doors
[D1 13:10:46 elevator_1] At floor 5
[D1 13:10:46 elevator_1] Stopped at floor 5
[D1 13:10:46 elevator_1] Opening doors
[D1 13:10:49 elevator_1] Opened doors
[D1 13:10:49 citizen_114] Entered elevator_1, going to floor 4
[D1 13:10:49 floor_5] citizen_114 is leaving the queue
[D1 13:10:49 floor_5] The queue is now empty
[D1 13:10:54 elevator_2] At floor 4
[D1 13:11:01 elevator_1] Closing doors
[D1 13:11:04 elevator_2] At floor 5
[D1 13:11:04 elevator_2] Stopped at floor 5
[D1 13:11:04 elevator_2] Opening doors
[D1 13:11:04 elevator_1] Closed doors
[D1 13:11:04 elevator_1] Changing direction to Down
[D1 13:11:07 citizen_122] Time to go to floor 5 and stay there for 00:16:11
[D1 13:11:07 floor_1] citizen_122 entered the queue
[D1 13:11:07 floor_1] citizen_122 found an empty queue and will be served immediately
[D1 13:11:07 elevator_1] Summoned to floor 1 from floor 5
[D1 13:11:07 elevator_2] Summoned to floor 1 from floor 5
[D1 13:11:07 elevator_2] Opened doors
[D1 13:11:07 citizen_96] Left elevator_2, arrived at floor 5
[D1 13:11:14 elevator_1] At floor 4
[D1 13:11:14 elevator_1] Stopped at floor 4
[D1 13:11:14 elevator_1] Opening doors
[D1 13:11:17 elevator_1] Opened doors
[D1 13:11:17 citizen_114] Left elevator_1, arrived at floor 4
[D1 13:11:19 elevator_2] Closing doors
[D1 13:11:22 elevator_2] Closed doors
[D1 13:11:22 elevator_2] Changing direction to Down
[D1 13:11:29 elevator_1] Closing doors
[D1 13:11:32 citizen_93] Time to go to floor 2 and stay there for 00:42:51
[D1 13:11:32 floor_1] citizen_93 entered the queue
[D1 13:11:32 floor_1] citizen_93 is queued along with 0 other arrivals in front of it
[D1 13:11:32 elevator_2] At floor 4
[D1 13:11:32 elevator_1] Closed doors
[D1 13:11:33 citizen_131] Entered the building, will visit 2 floors in total
[D1 13:11:33 citizen_131] Time to go to floor 5 and stay there for 00:38:19
[D1 13:11:33 floor_0] citizen_131 entered the queue
[D1 13:11:33 floor_0] citizen_131 is queued along with 0 other arrivals in front of it
[D1 13:11:33 citizen_110] Time to go to floor 5 and stay there for 00:29:48
[D1 13:11:33 floor_2] citizen_110 entered the queue
[D1 13:11:33 floor_2] citizen_110 found an empty queue and will be served immediately
[D1 13:11:33 elevator_1] Summoned to floor 2 from floor 4
[D1 13:11:33 elevator_2] Summoned to floor 2 from floor 4
[D1 13:11:42 elevator_2] At floor 3
[D1 13:11:42 elevator_1] At floor 3
[D1 13:11:47 citizen_91] Time to go to floor 2 and stay there for 00:17:33
[D1 13:11:47 floor_1] citizen_91 entered the queue
[D1 13:11:47 floor_1] citizen_91 is queued along with 1 other arrivals in front of it
[D1 13:11:52 elevator_2] At floor 2
[D1 13:11:52 elevator_2] Stopped at floor 2
[D1 13:11:52 elevator_2] Opening doors
[D1 13:11:52 elevator_1] At floor 2
[D1 13:11:52 elevator_1] Stopped at floor 2
[D1 13:11:52 elevator_1] Opening doors
[D1 13:11:55 elevator_2] Opened doors
[D1 13:11:55 elevator_1] Opened doors
[D1 13:11:55 citizen_110] Entered elevator_2, going to floor 5
[D1 13:11:55 floor_2] citizen_110 is leaving the queue
[D1 13:11:55 floor_2] The queue is now empty
[D1 13:12:07 elevator_2] Closing doors
[D1 13:12:07 elevator_1] Closing doors
[D1 13:12:10 elevator_2] Closed doors
[D1 13:12:10 elevator_1] Closed doors
[D1 13:12:20 elevator_2] At floor 1
[D1 13:12:20 elevator_2] Stopped at floor 1
[D1 13:12:20 elevator_2] Opening doors
[D1 13:12:20 elevator_1] At floor 1
[D1 13:12:20 elevator_1] Stopped at floor 1
[D1 13:12:20 elevator_1] Opening doors
[D1 13:12:20 citizen_92] Time to go to the ground floor and leave
[D1 13:12:20 floor_4] citizen_92 entered the queue
[D1 13:12:20 floor_4] citizen_92 found an empty queue and will be served immediately
[D1 13:12:20 elevator_1] Summoned to floor 4 from floor 1
[D1 13:12:20 elevator_2] Summoned to floor 4 from floor 1
[D1 13:12:23 elevator_2] Opened doors
[D1 13:12:23 elevator_1] Opened doors
[D1 13:12:23 citizen_122] Entered elevator_2, going to floor 5
[D1 13:12:23 floor_1] citizen_122 is leaving the queue
[D1 13:12:23 floor_1] citizen_93 was served
[D1 13:12:23 elevator_1] Summoned to floor 1 from floor 1
[D1 13:12:23 elevator_2] Summoned to floor 1 from floor 1
[D1 13:12:23 citizen_93] Entered elevator_1, going to floor 2
[D1 13:12:23 floor_1] citizen_93 is leaving the queue
[D1 13:12:23 floor_1] citizen_91 was served
[D1 13:12:23 elevator_1] Summoned to floor 1 from floor 1
[D1 13:12:23 elevator_2] Summoned to floor 1 from floor 1
[D1 13:12:23 citizen_91] Entered elevator_1, going to floor 2
[D1 13:12:23 floor_1] citizen_91 is leaving the queue
[D1 13:12:23 floor_1] The queue is now empty
[D1 13:12:35 elevator_2] Closing doors
[D1 13:12:35 elevator_1] Closing doors
[D1 13:12:38 elevator_2] Closed doors
[D1 13:12:38 elevator_1] Closed doors
[D1 13:12:41 citizen_70] Time to go to the ground floor and leave
[D1 13:12:41 floor_1] citizen_70 entered the queue
[D1 13:12:41 floor_1] citizen_70 found an empty queue and will be served immediately
[D1 13:12:41 elevator_1] Summoned to floor 1 from floor 1
[D1 13:12:41 elevator_2] Summoned to floor 1 from floor 1
[D1 13:12:47 citizen_89] Time to go to the ground floor and leave
[D1 13:12:47 floor_3] citizen_89 entered the queue
[D1 13:12:47 floor_3] citizen_89 found an empty queue and will be served immediately
[D1 13:12:47 elevator_1] Summoned to floor 3 from floor 1
[D1 13:12:47 elevator_2] Summoned to floor 3 from floor 1
[D1 13:12:48 elevator_2] At floor 0
[D1 13:12:48 elevator_2] Stopped at floor 0
[D1 13:12:48 elevator_2] Opening doors
[D1 13:12:48 elevator_1] At floor 0
[D1 13:12:48 elevator_1] Stopped at floor 0
[D1 13:12:48 elevator_1] Opening doors
[D1 13:12:51 elevator_2] Opened doors
[D1 13:12:51 elevator_1] Opened doors
[D1 13:12:51 citizen_76] Left elevator_2, arrived at floor 0
[D1 13:12:51 citizen_76] Left the building
[D1 13:12:51 citizen_130] Entered elevator_2, going to floor 2
[D1 13:12:51 floor_0] citizen_130 is leaving the queue
[D1 13:12:51 floor_0] citizen_131 was served
[D1 13:12:51 elevator_1] Summoned to floor 0 from floor 0
[D1 13:12:51 elevator_2] Summoned to floor 0 from floor 0
[D1 13:12:51 citizen_131] Entered elevator_1, going to floor 5
[D1 13:12:51 floor_0] citizen_131 is leaving the queue
[D1 13:12:51 floor_0] The queue is now empty
[D1 13:13:01 citizen_97] Time to go to the ground floor and leave
[D1 13:13:01 floor_2] citizen_97 entered the queue
[D1 13:13:01 floor_2] citizen_97 found an empty queue and will be served immediately
[D1 13:13:01 elevator_1] Summoned to floor 2 from floor 0
[D1 13:13:01 elevator_2] Summoned to floor 2 from floor 0
[D1 13:13:03 elevator_1] Closing doors
[D1 13:13:03 elevator_2] Closing doors
[D1 13:13:06 elevator_1] Closed doors
[D1 13:13:06 elevator_2] Closed doors
[D1 13:13:06 elevator_1] Changing direction to Up
[D1 13:13:06 elevator_2] Changing direction to Up
[D1 13:13:15 citizen_132] Entered the building, will visit 3 floors in total
[D1 13:13:15 citizen_132] Time to go to floor 4 and stay there for 00:38:09
[D1 13:13:15 floor_0] citizen_132 entered the queue
[D1 13:13:15 floor_0] citizen_132 found an empty queue and will be served immediately
[D1 13:13:15 elevator_1] Summoned to floor 0 from floor 0
[D1 13:13:15 elevator_2] Summoned to floor 0 from floor 0
[D1 13:13:16 elevator_1] At floor 1
[D1 13:13:16 elevator_1] Stopped at floor 1
[D1 13:13:16 elevator_1] Opening doors
[D1 13:13:16 elevator_2] At floor 1
[D1 13:13:16 elevator_2] Stopped at floor 1
[D1 13:13:16 elevator_2] Opening doors
[D1 13:13:19 elevator_1] Opened doors
[D1 13:13:19 elevator_2] Opened doors
[D1 13:13:19 citizen_70] Entered elevator_1, going to floor 0
[D1 13:13:19 floor_1] citizen_70 is leaving the queue
[D1 13:13:19 floor_1] The queue is now empty
[D1 13:13:26 citizen_115] Time to go to floor 3 and stay there for 00:18:57
[D1 13:13:26 floor_2] citizen_115 entered the queue
[D1 13:13:26 floor_2] citizen_115 is queued along with 0 other arrivals in front of it
[D1 13:13:31 elevator_2] Closing doors
[D1 13:13:31 elevator_1] Closing doors
[D1 13:13:34 elevator_2] Closed doors
[D1 13:13:34 elevator_1] Closed doors
[D1 13:13:37 citizen_105] Time to go to the ground floor and leave
[D1 13:13:37 floor_2] citizen_105 entered the queue
[D1 13:13:37 floor_2] citizen_105 is queued along with 1 other arrivals in front of it
[D1 13:13:44 elevator_2] At floor 2
[D1 13:13:44 elevator_2] Stopped at floor 2
[D1 13:13:44 elevator_2] Opening doors
[D1 13:13:44 elevator_1] At floor 2
[D1 13:13:44 elevator_1] Stopped at floor 2
[D1 13:13:44 elevator_1] Opening doors
[D1 13:13:47 elevator_2] Opened doors
[D1 13:13:47 elevator_1] Opened doors
[D1 13:13:47 citizen_130] Left elevator_2, arrived at floor 2
[D1 13:13:47 citizen_93] Left elevator_1, arrived at floor 2
[D1 13:13:47 citizen_91] Left elevator_1, arrived at floor 2
[D1 13:13:47 citizen_97] Entered elevator_2, going to floor 0
[D1 13:13:47 floor_2] citizen_97 is leaving the queue
[D1 13:13:47 floor_2] citizen_115 was served
[D1 13:13:47 elevator_1] Summoned to floor 2 from floor 2
[D1 13:13:47 elevator_2] Summoned to floor 2 from floor 2
[D1 13:13:47 citizen_115] Entered elevator_1, going to floor 3
[D1 13:13:47 floor_2] citizen_115 is leaving the queue
[D1 13:13:47 floor_2] citizen_105 was served
[D1 13:13:47 elevator_1] Summoned to floor 2 from floor 2
[D1 13:13:47 elevator_2] Summoned to floor 2 from floor 2
[D1 13:13:47 citizen_105] Entered elevator_1, going to floor 0
[D1 13:13:47 floor_2] citizen_105 is leaving the queue
[D1 13:13:47 floor_2] The queue is now empty
[D1 13:13:50 citizen_77] Time to go to floor 1 and stay there for 00:17:08
[D1 13:13:50 floor_2] citizen_77 entered the queue
[D1 13:13:50 floor_2] citizen_77 found an empty queue and will be served immediately
[D1 13:13:50 elevator_1] Summoned to floor 2 from floor 2
[D1 13:13:50 elevator_2] Summoned to floor 2 from floor 2
[D1 13:13:50 citizen_77] Cannot enter elevator_1, it is full
[D1 13:13:50 citizen_77] Entered elevator_2, going to floor 1
[D1 13:13:50 floor_2] citizen_77 is leaving the queue
[D1 13:13:50 floor_2] The queue is now empty
[D1 13:13:59 elevator_2] Closing doors
[D1 13:13:59 elevator_1] Closing doors
[D1 13:14:02 elevator_2] Closed doors
[D1 13:14:02 elevator_1] Closed doors
[D1 13:14:12 elevator_2] At floor 3
[D1 13:14:12 elevator_2] Stopped at floor 3
[D1 13:14:12 elevator_2] Opening doors
[D1 13:14:12 elevator_1] At floor 3
[D1 13:14:12 elevator_1] Stopped at floor 3
[D1 13:14:12 elevator_1] Opening doors
[D1 13:14:15 elevator_2] Opened doors
[D1 13:14:15 elevator_1] Opened doors
[D1 13:14:15 citizen_115] Left elevator_1, arrived at floor 3
[D1 13:14:15 citizen_89] Cannot enter elevator_2, it is full
[D1 13:14:15 citizen_89] Entered elevator_1, going to floor 0
[D1 13:14:15 floor_3] citizen_89 is leaving the queue
[D1 13:14:15 floor_3] The queue is now empty
[D1 13:14:27 elevator_1] Closing doors
[D1 13:14:27 elevator_2] Closing doors
[D1 13:14:30 elevator_1] Closed doors
[D1 13:14:30 elevator_2] Closed doors
[D1 13:14:39 citizen_117] Time to go to floor 5 and stay there for 00:24:36
[D1 13:14:39 floor_1] citizen_117 entered the queue
[D1 13:14:39 floor_1] citizen_117 found an empty queue and will be served immediately
[D1 13:14:39 elevator_1] Summoned to floor 1 from floor 3
[D1 13:14:39 elevator_2] Summoned to floor 1 from floor 3
[D1 13:14:40 elevator_1] At floor 4
[D1 13:14:40 elevator_1] Stopped at floor 4
[D1 13:14:40 elevator_1] Opening doors
[D1 13:14:40 elevator_2] At floor 4
[D1 13:14:40 elevator_2] Stopped at floor 4
[D1 13:14:40 elevator_2] Opening doors
[D1 13:14:43 elevator_1] Opened doors
[D1 13:14:43 elevator_2] Opened doors
[D1 13:14:43 citizen_92] Cannot enter elevator_1, it is full
[D1 13:14:43 citizen_92] Cannot enter elevator_2, it is full
[D1 13:14:43 citizen_92] All elevators were full, trying to summon them again
[D1 13:14:51 citizen_133] Entered the building, will visit 5 floors in total
[D1 13:14:51 citizen_133] Time to go to floor 1 and stay there for 00:24:04
[D1 13:14:51 floor_0] citizen_133 entered the queue
[D1 13:14:51 floor_0] citizen_133 is queued along with 0 other arrivals in front of it
[D1 13:14:55 elevator_1] Closing doors
[D1 13:14:55 elevator_2] Closing doors
[D1 13:14:58 elevator_1] Closed doors
[D1 13:14:58 elevator_2] Closed doors
[D1 13:14:59 elevator_1] Summoned to floor 4 from floor 4
[D1 13:14:59 elevator_2] Summoned to floor 4 from floor 4
[D1 13:15:08 citizen_106] Time to go to floor 4 and stay there for 00:36:06
[D1 13:15:08 floor_3] citizen_106 entered the queue
[D1 13:15:08 floor_3] citizen_106 found an empty queue and will be served immediately
[D1 13:15:08 elevator_1] Summoned to floor 3 from floor 4
[D1 13:15:08 elevator_2] Summoned to floor 3 from floor 4
[D1 13:15:08 elevator_1] At floor 5
[D1 13:15:08 elevator_1] Stopped at floor 5
[D1 13:15:08 elevator_1] Opening doors
[D1 13:15:08 elevator_2] At floor 5
[D1 13:15:08 elevator_2] Stopped at floor 5
[D1 13:15:08 elevator_2] Opening doors
[D1 13:15:11 elevator_1] Opened doors
[D1 13:15:11 elevator_2] Opened doors
[D1 13:15:11 citizen_131] Left elevator_1, arrived at floor 5
[D1 13:15:11 citizen_110] Left elevator_2, arrived at floor 5
[D1 13:15:11 citizen_122] Left elevator_2, arrived at floor 5
[D1 13:15:23 elevator_1] Closing doors
[D1 13:15:23 elevator_2] Closing doors
[D1 13:15:26 elevator_1] Closed doors
[D1 13:15:26 elevator_2] Closed doors
[D1 13:15:26 elevator_1] Changing direction to Down
[D1 13:15:26 elevator_2] Changing direction to Down
[D1 13:15:35 citizen_99] Time to go to floor 4 and stay there for 00:27:59
[D1 13:15:35 floor_3] citizen_99 entered the queue
[D1 13:15:35 floor_3] citizen_99 is queued along with 0 other arrivals in front of it
[D1 13:15:36 elevator_1] At floor 4
[D1 13:15:36 elevator_1] Stopped at floor 4
[D1 13:15:36 elevator_1] Opening doors
[D1 13:15:36 elevator_2] At floor 4
[D1 13:15:36 elevator_2] Stopped at floor 4
[D1 13:15:36 elevator_2] Opening doors
[D1 13:15:39 citizen_74] Time to go to the ground floor and leave
[D1 13:15:39 floor_2] citizen_74 entered the queue
[D1 13:15:39 floor_2] citizen_74 found an empty queue and will be served immediately
[D1 13:15:39 elevator_1] Summoned to floor 2 from floor 4
[D1 13:15:39 elevator_2] Summoned to floor 2 from floor 4
[D1 13:15:39 elevator_1] Opened doors
[D1 13:15:39 elevator_2] Opened doors
[D1 13:15:39 citizen_92] Entered elevator_1, going to floor 0
[D1 13:15:39 floor_4] citizen_92 is leaving the queue
[D1 13:15:39 floor_4] The queue is now empty
[D1 13:15:51 elevator_1] Closing doors
[D1 13:15:51 elevator_2] Closing doors
[D1 13:15:54 elevator_1] Closed doors
[D1 13:15:54 elevator_2] Closed doors
[D1 13:16:01 citizen_134] Entered the building, will visit 4 floors in total
[D1 13:16:01 citizen_134] Time to go to floor 5 and stay there for 00:43:16
[D1 13:16:01 floor_0] citizen_134 entered the queue
[D1 13:16:01 floor_0] citizen_134 is queued along with 1 other arrivals in front of it
[D1 13:16:04 elevator_1] At floor 3
[D1 13:16:04 elevator_1] Stopped at floor 3
[D1 13:16:04 elevator_1] Opening doors
[D1 13:16:04 elevator_2] At floor 3
[D1 13:16:04 elevator_2] Stopped at floor 3
[D1 13:16:04 elevator_2] Opening doors
[D1 13:16:07 elevator_1] Opened doors
[D1 13:16:07 elevator_2] Opened doors
[D1 13:16:07 citizen_106] Cannot enter elevator_1, it is full
[D1 13:16:07 citizen_106] Entered elevator_2, going to floor 4
[D1 13:16:07 floor_3] citizen_106 is leaving the queue
[D1 13:16:07 floor_3] citizen_99 was served
[D1 13:16:07 elevator_1] Summoned to floor 3 from floor 3
[D1 13:16:07 elevator_2] Summoned to floor 3 from floor 3
[D1 13:16:07 citizen_99] Cannot enter elevator_1, it is full
[D1 13:16:07 citizen_99] Entered elevator_2, going to floor 4
[D1 13:16:07 floor_3] citizen_99 is leaving the queue
[D1 13:16:07 floor_3] The queue is now empty
[D1 13:16:19 elevator_1] Closing doors
[D1 13:16:19 elevator_2] Closing doors
[D1 13:16:22 elevator_1] Closed doors
[D1 13:16:22 elevator_2] Closed doors
[D1 13:16:32 elevator_1] At floor 2
[D1 13:16:32 elevator_1] Stopped at floor 2
[D1 13:16:32 elevator_1] Opening doors
[D1 13:16:32 elevator_2] At floor 2
[D1 13:16:32 elevator_2] Stopped at floor 2
[D1 13:16:32 elevator_2] Opening doors
[D1 13:16:35 elevator_1] Opened doors
[D1 13:16:35 elevator_2] Opened doors
[D1 13:16:35 citizen_74] Cannot enter elevator_1, it is full
[D1 13:16:35 citizen_74] Cannot enter elevator_2, it is full
[D1 13:16:35 citizen_74] All elevators were full, trying to summon them again
[D1 13:16:47 elevator_1] Closing doors
[D1 13:16:47 elevator_2] Closing doors
[D1 13:16:50 elevator_1] Closed doors
[D1 13:16:50 elevator_2] Closed doors
[D1 13:16:51 elevator_1] Summoned to floor 2 from floor 2
[D1 13:16:51 elevator_2] Summoned to floor 2 from floor 2
[D1 13:17:00 elevator_1] At floor 1
[D1 13:17:00 elevator_1] Stopped at floor 1
[D1 13:17:00 elevator_1] Opening doors
[D1 13:17:00 elevator_2] At floor 1
[D1 13:17:00 elevator_2] Stopped at floor 1
[D1 13:17:00 elevator_2] Opening doors
[D1 13:17:03 elevator_1] Opened doors
[D1 13:17:03 elevator_2] Opened doors
[D1 13:17:03 citizen_77] Left elevator_2, arrived at floor 1
[D1 13:17:03 citizen_117] Cannot enter elevator_1, it is full
[D1 13:17:03 citizen_117] Entered elevator_2, going to floor 5
[D1 13:17:03 floor_1] citizen_117 is leaving the queue
[D1 13:17:03 floor_1] The queue is now empty
[D1 13:17:13 citizen_104] Time to go to floor 5 and stay there for 00:34:08
[D1 13:17:13 floor_1] citizen_104 entered the queue
[D1 13:17:13 floor_1] citizen_104 found an empty queue and will be served immediately
[D1 13:17:13 elevator_1] Summoned to floor 1 from floor 1
[D1 13:17:13 elevator_2] Summoned to floor 1 from floor 1
[D1 13:17:13 citizen_104] Cannot enter elevator_1, it is full
[D1 13:17:13 citizen_104] Cannot enter elevator_2, it is full
[D1 13:17:13 citizen_104] All elevators were full, trying to summon them again
[D1 13:17:13 citizen_103] Time to go to floor 1 and stay there for 00:20:23
[D1 13:17:13 floor_3] citizen_103 entered the queue
[D1 13:17:13 floor_3] citizen_103 found an empty queue and will be served immediately
[D1 13:17:13 elevator_1] Summoned to floor 3 from floor 1
[D1 13:17:13 elevator_2] Summoned to floor 3 from floor 1
[D1 13:17:15 elevator_1] Closing doors
[D1 13:17:15 elevator_2] Closing doors
[D1 13:17:18 elevator_1] Closed doors
[D1 13:17:18 elevator_2] Closed doors
[D1 13:17:22 citizen_81] Time to go to the ground floor and leave
[D1 13:17:22 floor_3] citizen_81 entered the queue
[D1 13:17:22 floor_3] citizen_81 is queued along with 0 other arrivals in front of it
[D1 13:17:28 elevator_1] At floor 0
[D1 13:17:28 elevator_1] Stopped at floor 0
[D1 13:17:28 elevator_1] Opening doors
[D1 13:17:28 elevator_2] At floor 0
[D1 13:17:28 elevator_2] Stopped at floor 0
[D1 13:17:28 elevator_2] Opening doors
[D1 13:17:29 elevator_1] Summoned to floor 1 from floor 0
[D1 13:17:29 elevator_2] Summoned to floor 1 from floor 0
[D1 13:17:31 elevator_1] Opened doors
[D1 13:17:31 elevator_2] Opened doors
[D1 13:17:31 citizen_70] Left elevator_1, arrived at floor 0
[D1 13:17:31 citizen_105] Left elevator_1, arrived at floor 0
[D1 13:17:31 citizen_89] Left elevator_1, arrived at floor 0
[D1 13:17:31 citizen_92] Left elevator_1, arrived at floor 0
[D1 13:17:31 citizen_97] Left elevator_2, arrived at floor 0
[D1 13:17:31 citizen_92] Left the building
[D1 13:17:31 citizen_97] Left the building
[D1 13:17:31 citizen_132] Entered elevator_2, going to floor 4
[D1 13:17:31 floor_0] citizen_132 is leaving the queue
[D1 13:17:31 floor_0] citizen_133 was served
[D1 13:17:31 citizen_70] Left the building
[D1 13:17:31 citizen_105] Left the building
[D1 13:17:31 elevator_1] Summoned to floor 0 from floor 0
[D1 13:17:31 elevator_2] Summoned to floor 0 from floor 0
[D1 13:17:31 citizen_133] Entered elevator_1, going to floor 1
[D1 13:17:31 floor_0] citizen_133 is leaving the queue
[D1 13:17:31 floor_0] citizen_134 was served
[D1 13:17:31 elevator_1] Summoned to floor 0 from floor 0
[D1 13:17:31 elevator_2] Summoned to floor 0 from floor 0
[D1 13:17:31 citizen_134] Entered elevator_1, going to floor 5
[D1 13:17:31 floor_0] citizen_134 is leaving the queue
[D1 13:17:31 floor_0] The queue is now empty
[D1 13:17:31 citizen_89] Left the building
[D1 13:17:43 elevator_1] Closing doors
[D1 13:17:43 elevator_2] Closing doors
[D1 13:17:46 elevator_1] Closed doors
[D1 13:17:46 elevator_2] Closed doors
[D1 13:17:46 elevator_1] Changing direction to Up
[D1 13:17:46 elevator_2] Changing direction to Up
[D1 13:17:56 elevator_1] At floor 1
[D1 13:17:56 elevator_1] Stopped at floor 1
[D1 13:17:56 elevator_1] Opening doors
[D1 13:17:56 elevator_2] At floor 1
[D1 13:17:56 elevator_2] Stopped at floor 1
[D1 13:17:56 elevator_2] Opening doors
[D1 13:17:59 elevator_1] Opened doors
[D1 13:17:59 elevator_2] Opened doors
[D1 13:17:59 citizen_133] Left elevator_1, arrived at floor 1
[D1 13:17:59 citizen_104] Entered elevator_1, going to floor 5
[D1 13:17:59 floor_1] citizen_104 is leaving the queue
[D1 13:17:59 floor_1] The queue is now empty
[D1 13:18:00 citizen_84] Time to go to floor 2 and stay there for 00:17:22
[D1 13:18:00 floor_3] citizen_84 entered the queue
[D1 13:18:00 floor_3] citizen_84 is queued along with 1 other arrivals in front of it
[D1 13:18:06 citizen_85] Time to go to the ground floor and leave
[D1 13:18:06 floor_3] citizen_85 entered the queue
[D1 13:18:06 floor_3] citizen_85 is queued along with 2 other arrivals in front of it
[D1 13:18:11 elevator_1] Closing doors
[D1 13:18:11 elevator_2] Closing doors
[D1 13:18:14 elevator_1] Closed doors
[D1 13:18:14 elevator_2] Closed doors
[D1 13:18:24 elevator_1] At floor 2
[D1 13:18:24 elevator_1] Stopped at floor 2
[D1 13:18:24 elevator_1] Opening doors
[D1 13:18:24 elevator_2] At floor 2
[D1 13:18:24 elevator_2] Stopped at floor 2
[D1 13:18:24 elevator_2] Opening doors
[D1 13:18:27 elevator_1] Opened doors
[D1 13:18:27 elevator_2] Opened doors
[D1 13:18:27 citizen_74] Entered elevator_1, going to floor 0
[D1 13:18:27 floor_2] citizen_74 is leaving the queue
[D1 13:18:27 floor_2] The queue is now empty
[D1 13:18:36 citizen_135] Entered the building, will visit 3 floors in total
[D1 13:18:36 citizen_135] Time to go to floor 4 and stay there for 00:32:51
[D1 13:18:36 floor_0] citizen_135 entered the queue
[D1 13:18:36 floor_0] citizen_135 found an empty queue and will be served immediately
[D1 13:18:36 elevator_1] Summoned to floor 0 from floor 2
[D1 13:18:36 elevator_2] Summoned to floor 0 from floor 2
[D1 13:18:39 elevator_1] Closing doors
[D1 13:18:39 elevator_2] Closing doors
[D1 13:18:42 elevator_1] Closed doors
[D1 13:18:42 elevator_2] Closed doors
[D1 13:18:52 elevator_1] At floor 3
[D1 13:18:52 elevator_1] Stopped at floor 3
[D1 13:18:52 elevator_1] Opening doors
[D1 13:18:52 elevator_2] At floor 3
[D1 13:18:52 elevator_2] Stopped at floor 3
[D1 13:18:52 elevator_2] Opening doors
[D1 13:18:55 elevator_1] Opened doors
[D1 13:18:55 elevator_2] Opened doors
[D1 13:18:55 citizen_103] Entered elevator_1, going to floor 1
[D1 13:18:55 floor_3] citizen_103 is leaving the queue
[D1 13:18:55 floor_3] citizen_81 was served
[D1 13:18:55 elevator_1] Summoned to floor 3 from floor 3
[D1 13:18:55 elevator_2] Summoned to floor 3 from floor 3
[D1 13:18:55 citizen_81] Cannot enter elevator_1, it is full
[D1 13:18:55 citizen_81] Cannot enter elevator_2, it is full
[D1 13:18:55 citizen_81] All elevators were full, trying to summon them again
[D1 13:19:07 elevator_1] Closing doors
[D1 13:19:07 elevator_2] Closing doors
[D1 13:19:10 elevator_1] Closed doors
[D1 13:19:10 elevator_2] Closed doors
[D1 13:19:11 elevator_1] Summoned to floor 3 from floor 3
[D1 13:19:11 elevator_2] Summoned to floor 3 from floor 3
[D1 13:19:20 elevator_1] At floor 4
[D1 13:19:20 elevator_2] At floor 4
[D1 13:19:20 elevator_2] Stopped at floor 4
[D1 13:19:20 elevator_2] Opening doors
[D1 13:19:23 elevator_2] Opened doors
[D1 13:19:23 citizen_106] Left elevator_2, arrived at floor 4
[D1 13:19:23 citizen_99] Left elevator_2, arrived at floor 4
[D1 13:19:23 citizen_132] Left elevator_2, arrived at floor 4
[D1 13:19:30 elevator_1] At floor 5
[D1 13:19:30 elevator_1] Stopped at floor 5
[D1 13:19:30 elevator_1] Opening doors
[D1 13:19:30 citizen_120] Time to go to floor 3 and stay there for 00:31:47
[D1 13:19:30 floor_4] citizen_120 entered the queue
[D1 13:19:30 floor_4] citizen_120 found an empty queue and will be served immediately
[D1 13:19:30 elevator_2] Summoned to floor 4 from floor 4
[D1 13:19:30 citizen_120] Entered elevator_2, going to floor 3
[D1 13:19:30 floor_4] citizen_120 is leaving the queue
[D1 13:19:30 floor_4] The queue is now empty
[D1 13:19:33 elevator_1] Opened doors
[D1 13:19:33 citizen_134] Left elevator_1, arrived at floor 5
[D1 13:19:33 citizen_104] Left elevator_1, arrived at floor 5
[D1 13:19:35 elevator_2] Closing doors
[D1 13:19:38 elevator_2] Closed doors
[D1 13:19:45 elevator_1] Closing doors
[D1 13:19:48 citizen_82] Time to go to the ground floor and leave
[D1 13:19:48 floor_4] citizen_82 entered the queue
[D1 13:19:48 floor_4] citizen_82 found an empty queue and will be served immediately
[D1 13:19:48 elevator_2] Summoned to floor 4 from floor 4
[D1 13:19:48 elevator_2] At floor 5
[D1 13:19:48 elevator_2] Stopped at floor 5
[D1 13:19:48 elevator_2] Opening doors
[D1 13:19:48 elevator_1] Closed doors
[D1 13:19:48 elevator_1] Changing direction to Down
[D1 13:19:51 elevator_2] Opened doors
[D1 13:19:51 citizen_117] Left elevator_2, arrived at floor 5
[D1 13:19:58 elevator_1] At floor 4
[D1 13:20:03 elevator_2] Closing doors
[D1 13:20:06 elevator_2] Closed doors
[D1 13:20:06 elevator_2] Changing direction to Down
[D1 13:20:08 elevator_1] At floor 3
[D1 13:20:08 elevator_1] Stopped at floor 3
[D1 13:20:08 elevator_1] Opening doors
[D1 13:20:10 citizen_94] Time to go to the ground floor and leave
[D1 13:20:10 floor_1] citizen_94 entered the queue
[D1 13:20:10 floor_1] citizen_94 found an empty queue and will be served immediately
[D1 13:20:10 elevator_1] Summoned to floor 1 from floor 3
[D1 13:20:11 elevator_1] Opened doors
[D1 13:20:11 citizen_81] Entered elevator_1, going to floor 0
[D1 13:20:11 floor_3] citizen_81 is leaving the queue
[D1 13:20:11 floor_3] citizen_84 was served
[D1 13:20:11 elevator_1] Summoned to floor 3 from floor 3
[D1 13:20:11 citizen_84] Entered elevator_1, going to floor 2
[D1 13:20:11 floor_3] citizen_84 is leaving the queue
[D1 13:20:11 floor_3] citizen_85 was served
[D1 13:20:11 elevator_1] Summoned to floor 3 from floor 3
[D1 13:20:11 citizen_85] Cannot enter elevator_1, it is full
[D1 13:20:11 citizen_85] All elevators were full, trying to summon them again
[D1 13:20:16 elevator_2] At floor 4
[D1 13:20:16 elevator_2] Stopped at floor 4
[D1 13:20:16 elevator_2] Opening doors
[D1 13:20:19 elevator_2] Opened doors
[D1 13:20:19 citizen_82] Entered elevator_2, going to floor 0
[D1 13:20:19 floor_4] citizen_82 is leaving the queue
[D1 13:20:19 floor_4] The queue is now empty
[D1 13:20:23 elevator_1] Closing doors
[D1 13:20:26 elevator_1] Closed doors
[D1 13:20:27 elevator_1] Summoned to floor 3 from floor 3
[D1 13:20:28 citizen_121] Time to go to floor 4 and stay there for 00:26:34
[D1 13:20:28 floor_2] citizen_121 entered the queue
[D1 13:20:28 floor_2] citizen_121 found an empty queue and will be served immediately
[D1 13:20:28 elevator_1] Summoned to floor 2 from floor 3
[D1 13:20:31 elevator_2] Closing doors
[D1 13:20:34 elevator_2] Closed doors
[D1 13:20:36 elevator_1] At floor 2
[D1 13:20:36 elevator_1] Stopped at floor 2
[D1 13:20:36 elevator_1] Opening doors
[D1 13:20:39 elevator_1] Opened doors
[D1 13:20:39 citizen_84] Left elevator_1, arrived at floor 2
[D1 13:20:39 citizen_121] Entered elevator_1, going to floor 4
[D1 13:20:39 floor_2] citizen_121 is leaving the queue
[D1 13:20:39 floor_2] The queue is now empty
[D1 13:20:42 citizen_123] Time to go to floor 4 and stay there for 00:37:35
[D1 13:20:42 floor_1] citizen_123 entered the queue
[D1 13:20:42 floor_1] citizen_123 is queued along with 0 other arrivals in front of it
[D1 13:20:44 elevator_2] At floor 3
[D1 13:20:44 elevator_2] Stopped at floor 3
[D1 13:20:44 elevator_2] Opening doors
[D1 13:20:47 elevator_2] Opened doors
[D1 13:20:47 citizen_120] Left elevator_2, arrived at floor 3
[D1 13:20:51 elevator_1] Closing doors
[D1 13:20:54 elevator_1] Closed doors
[D1 13:20:59 elevator_2] Closing doors
[D1 13:21:00 citizen_136] Entered the building, will visit 3 floors in total
[D1 13:21:00 citizen_136] Time to go to floor 5 and stay there for 00:30:22
[D1 13:21:00 floor_0] citizen_136 entered the queue
[D1 13:21:00 floor_0] citizen_136 is queued along with 0 other arrivals in front of it
[D1 13:21:02 elevator_2] Closed doors
[D1 13:21:04 elevator_1] At floor 1
[D1 13:21:04 elevator_1] Stopped at floor 1
[D1 13:21:04 elevator_1] Opening doors
[D1 13:21:07 elevator_1] Opened doors
[D1 13:21:07 citizen_103] Left elevator_1, arrived at floor 1
[D1 13:21:07 citizen_94] Entered elevator_1, going to floor 0
[D1 13:21:07 floor_1] citizen_94 is leaving the queue
[D1 13:21:07 floor_1] citizen_123 was served
[D1 13:21:07 elevator_1] Summoned to floor 1 from floor 1
[D1 13:21:07 citizen_123] Cannot enter elevator_1, it is full
[D1 13:21:07 citizen_123] All elevators were full, trying to summon them again
[D1 13:21:12 elevator_2] At floor 2
[D1 13:21:19 elevator_1] Closing doors
[D1 13:21:22 elevator_2] At floor 1
[D1 13:21:22 elevator_1] Closed doors
[D1 13:21:23 elevator_1] Summoned to floor 1 from floor 1
[D1 13:21:23 elevator_2] Summoned to floor 1 from floor 1
[D1 13:21:24 citizen_125] Time to go to floor 5 and stay there for 00:25:47
[D1 13:21:24 floor_2] citizen_125 entered the queue
[D1 13:21:24 floor_2] citizen_125 found an empty queue and will be served immediately
[D1 13:21:24 elevator_1] Summoned to floor 2 from floor 1
[D1 13:21:24 elevator_2] Summoned to floor 2 from floor 1
[D1 13:21:32 elevator_2] At floor 0
[D1 13:21:32 elevator_2] Stopped at floor 0
[D1 13:21:32 elevator_2] Opening doors
[D1 13:21:32 elevator_1] At floor 0
[D1 13:21:32 elevator_1] Stopped at floor 0
[D1 13:21:32 elevator_1] Opening doors
[D1 13:21:35 elevator_2] Opened doors
[D1 13:21:35 elevator_1] Opened doors
[D1 13:21:35 citizen_82] Left elevator_2, arrived at floor 0
[D1 13:21:35 citizen_74] Left elevator_1, arrived at floor 0
[D1 13:21:35 citizen_81] Left elevator_1, arrived at floor 0
[D1 13:21:35 citizen_94] Left elevator_1, arrived at floor 0
[D1 13:21:35 citizen_94] Left the building
[D1 13:21:35 citizen_135] Entered elevator_2, going to floor 4
[D1 13:21:35 citizen_81] Left the building
[D1 13:21:35 floor_0] citizen_135 is leaving the queue
[D1 13:21:35 floor_0] citizen_136 was served
[D1 13:21:35 elevator_1] Summoned to floor 0 from floor 0
[D1 13:21:35 elevator_2] Summoned to floor 0 from floor 0
[D1 13:21:35 citizen_136] Entered elevator_1, going to floor 5
[D1 13:21:35 floor_0] citizen_136 is leaving the queue
[D1 13:21:35 floor_0] The queue is now empty
[D1 13:21:35 citizen_82] Left the building
[D1 13:21:35 citizen_74] Left the building
[D1 13:21:47 elevator_2] Closing doors
[D1 13:21:47 elevator_1] Closing doors
[D1 13:21:50 elevator_2] Closed doors
[D1 13:21:50 elevator_1] Closed doors
[D1 13:21:50 elevator_2] Changing direction to Up
[D1 13:21:50 elevator_1] Changing direction to Up
[D1 13:22:00 elevator_2] At floor 1
[D1 13:22:00 elevator_2] Stopped at floor 1
[D1 13:22:00 elevator_2] Opening doors
[D1 13:22:00 elevator_1] At floor 1
[D1 13:22:00 elevator_1] Stopped at floor 1
[D1 13:22:00 elevator_1] Opening doors
[D1 13:22:03 elevator_2] Opened doors
[D1 13:22:03 elevator_1] Opened doors
[D1 13:22:03 citizen_123] Entered elevator_2, going to floor 4
[D1 13:22:03 floor_1] citizen_123 is leaving the queue
[D1 13:22:03 floor_1] The queue is now empty
[D1 13:22:14 citizen_128] Time to go to floor 4 and stay there for 00:31:05
[D1 13:22:14 floor_2] citizen_128 entered the queue
[D1 13:22:14 floor_2] citizen_128 is queued along with 0 other arrivals in front of it
[D1 13:22:15 elevator_1] Closing doors
[D1 13:22:15 elevator_2] Closing doors
[D1 13:22:18 elevator_1] Closed doors
[D1 13:22:18 elevator_2] Closed doors
[D1 13:22:28 elevator_1] At floor 2
[D1 13:22:28 elevator_1] Stopped at floor 2
[D1 13:22:28 elevator_1] Opening doors
[D1 13:22:28 elevator_2] At floor 2
[D1 13:22:28 elevator_2] Stopped at floor 2
[D1 13:22:28 elevator_2] Opening doors
[D1 13:22:31 elevator_1] Opened doors
[D1 13:22:31 elevator_2] Opened doors
[D1 13:22:31 citizen_125] Entered elevator_1, going to floor 5
[D1 13:22:31 floor_2] citizen_125 is leaving the queue
[D1 13:22:31 floor_2] citizen_128 was served
[D1 13:22:31 elevator_1] Summoned to floor 2 from floor 2
[D1 13:22:31 elevator_2] Summoned to floor 2 from floor 2
[D1 13:22:31 citizen_128] Entered elevator_1, going to floor 4
[D1 13:22:31 floor_2] citizen_128 is leaving the queue
[D1 13:22:31 floor_2] The queue is now empty
[D1 13:22:43 elevator_1] Closing doors
[D1 13:22:43 elevator_2] Closing doors
[D1 13:22:43 citizen_137] Entered the building, will visit 3 floors in total
[D1 13:22:43 citizen_137] Time to go to floor 3 and stay there for 00:26:52
[D1 13:22:43 floor_0] citizen_137 entered the queue
[D1 13:22:43 floor_0] citizen_137 found an empty queue and will be served immediately
[D1 13:22:43 elevator_1] Summoned to floor 0 from floor 2
[D1 13:22:43 elevator_2] Summoned to floor 0 from floor 2
[D1 13:22:46 elevator_1] Closed doors
[D1 13:22:46 elevator_2] Closed doors
[D1 13:22:56 elevator_1] At floor 3
[D1 13:22:56 elevator_1] Stopped at floor 3
[D1 13:22:56 elevator_1] Opening doors
[D1 13:22:56 elevator_2] At floor 3
[D1 13:22:57 citizen_116] Time to go to floor 5 and stay there for 00:18:08
[D1 13:22:57 floor_3] citizen_116 entered the queue
[D1 13:22:57 floor_3] citizen_116 is queued along with 0 other arrivals in front of it
[D1 13:22:59 elevator_1] Opened doors
[D1 13:22:59 citizen_85] Cannot enter elevator_1, it is full
[D1 13:22:59 citizen_85] All elevators were full, trying to summon them again
[D1 13:23:06 elevator_2] At floor 4
[D1 13:23:06 elevator_2] Stopped at floor 4
[D1 13:23:06 elevator_2] Opening doors
[D1 13:23:09 elevator_2] Opened doors
[D1 13:23:09 citizen_135] Left elevator_2, arrived at floor 4
[D1 13:23:09 citizen_123] Left elevator_2, arrived at floor 4
[D1 13:23:11 elevator_1] Closing doors
[D1 13:23:14 elevator_1] Closed doors
[D1 13:23:15 elevator_1] Summoned to floor 3 from floor 3
[D1 13:23:21 elevator_2] Closing doors
[D1 13:23:24 elevator_1] At floor 4
[D1 13:23:24 elevator_1] Stopped at floor 4
[D1 13:23:24 elevator_1] Opening doors
[D1 13:23:24 elevator_2] Closed doors
[D1 13:23:24 elevator_2] Changing direction to Down
[D1 13:23:27 elevator_1] Opened doors
[D1 13:23:27 citizen_121] Left elevator_1, arrived at floor 4
[D1 13:23:27 citizen_128] Left elevator_1, arrived at floor 4
[D1 13:23:34 elevator_2] At floor 3
[D1 13:23:39 elevator_1] Closing doors
[D1 13:23:42 elevator_1] Closed doors
[D1 13:23:44 elevator_2] At floor 2
[D1 13:23:51 citizen_88] Time to go to floor 4 and stay there for 00:37:18
[D1 13:23:51 floor_3] citizen_88 entered the queue
[D1 13:23:51 floor_3] citizen_88 is queued along with 1 other arrivals in front of it
[D1 13:23:52 elevator_1] At floor 5
[D1 13:23:52 elevator_1] Stopped at floor 5
[D1 13:23:52 elevator_1] Opening doors
[D1 13:23:54 elevator_2] At floor 1
[D1 13:23:55 elevator_1] Opened doors
[D1 13:23:55 citizen_136] Left elevator_1, arrived at floor 5
[D1 13:23:55 citizen_125] Left elevator_1, arrived at floor 5
[D1 13:24:04 elevator_2] At floor 0
[D1 13:24:04 elevator_2] Stopped at floor 0
[D1 13:24:04 elevator_2] Opening doors
[D1 13:24:07 elevator_1] Closing doors
[D1 13:24:07 elevator_2] Opened doors
[D1 13:24:07 citizen_137] Entered elevator_2, going to floor 3
[D1 13:24:07 floor_0] citizen_137 is leaving the queue
[D1 13:24:07 floor_0] The queue is now empty
[D1 13:24:10 elevator_1] Closed doors
[D1 13:24:10 elevator_1] Changing direction to Down
[D1 13:24:19 elevator_2] Closing doors
[D1 13:24:20 elevator_1] At floor 4
[D1 13:24:22 elevator_2] Closed doors
[D1 13:24:22 elevator_2] Changing direction to Up
[D1 13:24:29 citizen_138] Entered the building, will visit 3 floors in total
[D1 13:24:29 citizen_138] Time to go to floor 3 and stay there for 00:31:24
[D1 13:24:29 floor_0] citizen_138 entered the queue
[D1 13:24:29 floor_0] citizen_138 found an empty queue and will be served immediately
[D1 13:24:29 elevator_2] Summoned to floor 0 from floor 0
[D1 13:24:30 elevator_1] At floor 3
[D1 13:24:30 elevator_1] Stopped at floor 3
[D1 13:24:30 elevator_1] Opening doors
[D1 13:24:31 citizen_98] Time to go to floor 5 and stay there for 00:33:01
[D1 13:24:31 floor_3] citizen_98 entered the queue
[D1 13:24:31 floor_3] citizen_98 is queued along with 2 other arrivals in front of it
[D1 13:24:32 elevator_2] At floor 1
[D1 13:24:33 elevator_1] Opened doors
[D1 13:24:33 citizen_85] Entered elevator_1, going to floor 0
[D1 13:24:33 floor_3] citizen_85 is leaving the queue
[D1 13:24:33 floor_3] citizen_116 was served
[D1 13:24:33 elevator_1] Summoned to floor 3 from floor 3
[D1 13:24:33 citizen_116] Entered elevator_1, going to floor 5
[D1 13:24:33 floor_3] citizen_116 is leaving the queue
[D1 13:24:33 floor_3] citizen_88 was served
[D1 13:24:33 elevator_1] Summoned to floor 3 from floor 3
[D1 13:24:33 citizen_88] Entered elevator_1, going to floor 4
[D1 13:24:33 floor_3] citizen_88 is leaving the queue
[D1 13:24:33 floor_3] citizen_98 was served
[D1 13:24:33 elevator_1] Summoned to floor 3 from floor 3
[D1 13:24:33 citizen_98] Entered elevator_1, going to floor 5
[D1 13:24:33 floor_3] citizen_98 is leaving the queue
[D1 13:24:33 floor_3] The queue is now empty
[D1 13:24:42 elevator_2] At floor 2
[D1 13:24:45 elevator_1] Closing doors
[D1 13:24:48 elevator_1] Closed doors
[D1 13:24:52 elevator_2] At floor 3
[D1 13:24:52 elevator_2] Stopped at floor 3
[D1 13:24:52 elevator_2] Opening doors
[D1 13:24:55 elevator_2] Opened doors
[D1 13:24:55 citizen_137] Left elevator_2, arrived at floor 3
[D1 13:24:56 citizen_107] Time to go to floor 3 and stay there for 00:21:31
[D1 13:24:56 floor_2] citizen_107 entered the queue
[D1 13:24:56 floor_2] citizen_107 found an empty queue and will be served immediately
[D1 13:24:56 elevator_1] Summoned to floor 2 from floor 3
[D1 13:24:56 elevator_2] Summoned to floor 2 from floor 3
[D1 13:24:58 elevator_1] At floor 2
[D1 13:24:58 elevator_1] Stopped at floor 2
[D1 13:24:58 elevator_1] Opening doors
[D1 13:25:01 elevator_1] Opened doors
[D1 13:25:01 citizen_107] Cannot enter elevator_1, it is full
[D1 13:25:07 elevator_2] Closing doors
[D1 13:25:10 elevator_2] Closed doors
[D1 13:25:10 elevator_2] Changing direction to Down
[D1 13:25:13 elevator_1] Closing doors
[D1 13:25:16 elevator_1] Closed doors
[D1 13:25:20 elevator_2] At floor 2
[D1 13:25:20 elevator_2] Stopped at floor 2
[D1 13:25:20 elevator_2] Opening doors
[D1 13:25:23 elevator_2] Opened doors
[D1 13:25:23 citizen_107] Entered elevator_2, going to floor 3
[D1 13:25:23 floor_2] citizen_107 is leaving the queue
[D1 13:25:23 floor_2] The queue is now empty
[D1 13:25:26 elevator_1] At floor 1
[D1 13:25:35 elevator_2] Closing doors
[D1 13:25:36 elevator_1] At floor 0
[D1 13:25:36 elevator_1] Stopped at floor 0
[D1 13:25:36 elevator_1] Opening doors
[D1 13:25:38 elevator_2] Closed doors
[D1 13:25:39 citizen_80] Time to go to floor 1 and stay there for 00:34:20
[D1 13:25:39 floor_5] citizen_80 entered the queue
[D1 13:25:39 floor_5] citizen_80 found an empty queue and will be served immediately
[D1 13:25:39 elevator_2] Summoned to floor 5 from floor 2
[D1 13:25:39 elevator_1] Opened doors
[D1 13:25:39 citizen_85] Left elevator_1, arrived at floor 0
[D1 13:25:39 citizen_85] Left the building
[D1 13:25:48 elevator_2] At floor 1
[D1 13:25:51 elevator_1] Closing doors
[D1 13:25:54 elevator_1] Closed doors
[D1 13:25:54 elevator_1] Changing direction to Up
[D1 13:25:58 elevator_2] At floor 0
[D1 13:25:58 elevator_2] Stopped at floor 0
[D1 13:25:58 elevator_2] Opening doors
[D1 13:26:01 elevator_2] Opened doors
[D1 13:26:01 citizen_138] Entered elevator_2, going to floor 3
[D1 13:26:01 floor_0] citizen_138 is leaving the queue
[D1 13:26:01 floor_0] The queue is now empty
[D1 13:26:04 elevator_1] At floor 1
[D1 13:26:10 citizen_95] Time to go to floor 2 and stay there for 00:40:43
[D1 13:26:10 floor_1] citizen_95 entered the queue
[D1 13:26:10 floor_1] citizen_95 found an empty queue and will be served immediately
[D1 13:26:10 elevator_1] Summoned to floor 1 from floor 1
[D1 13:26:13 elevator_2] Closing doors
[D1 13:26:14 elevator_1] At floor 2
[D1 13:26:16 elevator_2] Closed doors
[D1 13:26:16 elevator_2] Changing direction to Up
[D1 13:26:22 citizen_126] Time to go to floor 3 and stay there for 00:28:35
[D1 13:26:22 floor_1] citizen_126 entered the queue
[D1 13:26:22 floor_1] citizen_126 is queued along with 0 other arrivals in front of it
[D1 13:26:24 elevator_1] At floor 3
[D1 13:26:26 elevator_2] At floor 1
[D1 13:26:34 elevator_1] At floor 4
[D1 13:26:34 elevator_1] Stopped at floor 4
[D1 13:26:34 elevator_1] Opening doors
[D1 13:26:36 elevator_2] At floor 2
[D1 13:26:37 elevator_1] Opened doors
[D1 13:26:37 citizen_88] Left elevator_1, arrived at floor 4
[D1 13:26:45 citizen_68] Time to go to the ground floor and leave
[D1 13:26:45 floor_3] citizen_68 entered the queue
[D1 13:26:45 floor_3] citizen_68 found an empty queue and will be served immediately
[D1 13:26:45 elevator_1] Summoned to floor 3 from floor 4
[D1 13:26:45 elevator_2] Summoned to floor 3 from floor 2
[D1 13:26:46 elevator_2] At floor 3
[D1 13:26:46 elevator_2] Stopped at floor 3
[D1 13:26:46 elevator_2] Opening doors
[D1 13:26:49 elevator_1] Closing doors
[D1 13:26:49 elevator_2] Opened doors
[D1 13:26:49 citizen_107] Left elevator_2, arrived at floor 3
[D1 13:26:49 citizen_138] Left elevator_2, arrived at floor 3
[D1 13:26:49 citizen_68] Entered elevator_2, going to floor 0
[D1 13:26:49 floor_3] citizen_68 is leaving the queue
[D1 13:26:49 floor_3] The queue is now empty
[D1 13:26:52 elevator_1] Closed doors
[D1 13:26:58 citizen_124] Time to go to floor 2 and stay there for 00:33:12
[D1 13:26:58 floor_4] citizen_124 entered the queue
[D1 13:26:58 floor_4] citizen_124 found an empty queue and will be served immediately
[D1 13:26:58 elevator_1] Summoned to floor 4 from floor 4
[D1 13:27:01 elevator_2] Closing doors
[D1 13:27:02 elevator_1] At floor 5
[D1 13:27:02 elevator_1] Stopped at floor 5
[D1 13:27:02 elevator_1] Opening doors
[D1 13:27:04 elevator_2] Closed doors
[D1 13:27:05 elevator_1] Opened doors
[D1 13:27:05 citizen_116] Left elevator_1, arrived at floor 5
[D1 13:27:05 citizen_98] Left elevator_1, arrived at floor 5
[D1 13:27:14 elevator_2] At floor 4
[D1 13:27:17 elevator_1] Closing doors
[D1 13:27:20 elevator_1] Closed doors
[D1 13:27:20 elevator_1] Changing direction to Down
[D1 13:27:24 elevator_2] At floor 5
[D1 13:27:24 elevator_2] Stopped at floor 5
[D1 13:27:24 elevator_2] Opening doors
[D1 13:27:27 elevator_2] Opened doors
[D1 13:27:27 citizen_80] Entered elevator_2, going to floor 1
[D1 13:27:27 floor_5] citizen_80 is leaving the queue
[D1 13:27:27 floor_5] The queue is now empty
[D1 13:27:30 elevator_1] At floor 4
[D1 13:27:30 elevator_1] Stopped at floor 4
[D1 13:27:30 elevator_1] Opening doors
[D1 13:27:33 elevator_1] Opened doors
[D1 13:27:33 citizen_124] Entered elevator_1, going to floor 2
[D1 13:27:33 floor_4] citizen_124 is leaving the queue
[D1 13:27:33 floor_4] The queue is now empty
[D1 13:27:39 elevator_2] Closing doors
[D1 13:27:42 elevator_2] Closed doors
[D1 13:27:42 elevator_2] Changing direction to Down
[D1 13:27:45 elevator_1] Closing doors
[D1 13:27:48 citizen_109] Time to go to floor 5 and stay there for 00:21:44
[D1 13:27:48 floor_4] citizen_109 entered the queue
[D1 13:27:48 floor_4] citizen_109 found an empty queue and will be served immediately
[D1 13:27:48 elevator_1] Summoned to floor 4 from floor 4
[D1 13:27:48 elevator_1] Reopening doors
[D1 13:27:48 citizen_109] Entered elevator_1, going to floor 5
[D1 13:27:48 floor_4] citizen_109 is leaving the queue
[D1 13:27:48 floor_4] The queue is now empty
[D1 13:27:52 elevator_2] At floor 4
[D1 13:28:00 elevator_1] Closing doors
[D1 13:28:02 elevator_2] At floor 3
[D1 13:28:03 elevator_1] Closed doors
[D1 13:28:12 elevator_2] At floor 2
[D1 13:28:13 elevator_1] At floor 3
[D1 13:28:13 elevator_1] Stopped at floor 3
[D1 13:28:13 elevator_1] Opening doors
[D1 13:28:16 elevator_1] Opened doors
[D1 13:28:22 elevator_2] At floor 1
[D1 13:28:22 elevator_2] Stopped at floor 1
[D1 13:28:22 elevator_2] Opening doors
[D1 13:28:23 citizen_139] Entered the building, will visit 4 floors in total
[D1 13:28:23 citizen_139] Time to go to floor 5 and stay there for 00:25:19
[D1 13:28:23 floor_0] citizen_139 entered the queue
[D1 13:28:23 floor_0] citizen_139 found an empty queue and will be served immediately
[D1 13:28:23 elevator_2] Summoned to floor 0 from floor 1
[D1 13:28:25 elevator_2] Opened doors
[D1 13:28:25 citizen_80] Left elevator_2, arrived at floor 1
[D1 13:28:28 elevator_1] Closing doors
[D1 13:28:31 elevator_1] Closed doors
[D1 13:28:37 elevator_2] Closing doors
[D1 13:28:40 elevator_2] Closed doors
[D1 13:28:41 elevator_1] At floor 2
[D1 13:28:41 elevator_1] Stopped at floor 2
[D1 13:28:41 elevator_1] Opening doors
[D1 13:28:44 elevator_1] Opened doors
[D1 13:28:44 citizen_124] Left elevator_1, arrived at floor 2
[D1 13:28:50 elevator_2] At floor 0
[D1 13:28:50 elevator_2] Stopped at floor 0
[D1 13:28:50 elevator_2] Opening doors
[D1 13:28:53 elevator_2] Opened doors
[D1 13:28:53 citizen_68] Left elevator_2, arrived at floor 0
[D1 13:28:53 citizen_68] Left the building
[D1 13:28:53 citizen_139] Entered elevator_2, going to floor 5
[D1 13:28:53 floor_0] citizen_139 is leaving the queue
[D1 13:28:53 floor_0] The queue is now empty
[D1 13:28:56 elevator_1] Closing doors
[D1 13:28:59 elevator_1] Closed doors
[D1 13:29:05 elevator_2] Closing doors
[D1 13:29:08 elevator_2] Closed doors
[D1 13:29:08 elevator_2] Changing direction to Up
[D1 13:29:09 elevator_1] At floor 1
[D1 13:29:09 elevator_1] Stopped at floor 1
[D1 13:29:09 elevator_1] Opening doors
[D1 13:29:12 elevator_1] Opened doors
[D1 13:29:12 citizen_95] Entered elevator_1, going to floor 2
[D1 13:29:12 floor_1] citizen_95 is leaving the queue
[D1 13:29:12 floor_1] citizen_126 was served
[D1 13:29:12 elevator_1] Summoned to floor 1 from floor 1
[D1 13:29:12 citizen_126] Entered elevator_1, going to floor 3
[D1 13:29:12 floor_1] citizen_126 is leaving the queue
[D1 13:29:12 floor_1] The queue is now empty
[D1 13:29:18 elevator_2] At floor 1
[D1 13:29:24 elevator_1] Closing doors
[D1 13:29:27 elevator_1] Closed doors
[D1 13:29:27 elevator_1] Changing direction to Up
[D1 13:29:28 elevator_2] At floor 2
[D1 13:29:37 elevator_1] At floor 2
[D1 13:29:37 elevator_1] Stopped at floor 2
[D1 13:29:37 elevator_1] Opening doors
[D1 13:29:38 elevator_2] At floor 3
[D1 13:29:40 elevator_1] Opened doors
[D1 13:29:40 citizen_95] Left elevator_1, arrived at floor 2
[D1 13:29:43 citizen_140] Entered the building, will visit 4 floors in total
[D1 13:29:43 citizen_140] Time to go to floor 4 and stay there for 00:42:10
[D1 13:29:43 floor_0] citizen_140 entered the queue
[D1 13:29:43 floor_0] citizen_140 found an empty queue and will be served immediately
[D1 13:29:43 elevator_1] Summoned to floor 0 from floor 2
[D1 13:29:48 elevator_2] At floor 4
[D1 13:29:52 elevator_1] Closing doors
[D1 13:29:55 elevator_1] Closed doors
[D1 13:29:58 elevator_2] At floor 5
[D1 13:29:58 elevator_2] Stopped at floor 5
[D1 13:29:58 elevator_2] Opening doors
[D1 13:30:01 elevator_2] Opened doors
[D1 13:30:01 citizen_139] Left elevator_2, arrived at floor 5
[D1 13:30:05 elevator_1] At floor 3
[D1 13:30:05 elevator_1] Stopped at floor 3
[D1 13:30:05 elevator_1] Opening doors
[D1 13:30:08 elevator_1] Opened doors
[D1 13:30:08 citizen_126] Left elevator_1, arrived at floor 3
[D1 13:30:13 elevator_2] Closing doors
[D1 13:30:16 elevator_2] Closed doors
[D1 13:30:16 elevator_2] Resting at floor 5
[D1 13:30:20 elevator_1] Closing doors
[D1 13:30:23 elevator_1] Closed doors
[D1 13:30:30 citizen_111] Time to go to floor 5 and stay there for 00:37:40
[D1 13:30:30 floor_3] citizen_111 entered the queue
[D1 13:30:30 floor_3] citizen_111 found an empty queue and will be served immediately
[D1 13:30:30 elevator_1] Summoned to floor 3 from floor 3
[D1 13:30:33 elevator_1] At floor 4
[D1 13:30:43 elevator_1] At floor 5
[D1 13:30:43 elevator_1] Stopped at floor 5
[D1 13:30:43 elevator_1] Opening doors
[D1 13:30:46 elevator_1] Opened doors
[D1 13:30:46 citizen_109] Left elevator_1, arrived at floor 5
[D1 13:30:58 elevator_1] Closing doors
[D1 13:31:01 elevator_1] Closed doors
[D1 13:31:01 elevator_1] Changing direction to Down
[D1 13:31:11 elevator_1] At floor 4
[D1 13:31:20 citizen_91] Time to go to the ground floor and leave
[D1 13:31:20 floor_2] citizen_91 entered the queue
[D1 13:31:20 floor_2] citizen_91 found an empty queue and will be served immediately
[D1 13:31:20 elevator_1] Summoned to floor 2 from floor 4
[D1 13:31:21 elevator_1] At floor 3
[D1 13:31:21 elevator_1] Stopped at floor 3
[D1 13:31:21 elevator_1] Opening doors
[D1 13:31:22 citizen_122] Time to go to floor 3 and stay there for 00:28:15
[D1 13:31:22 floor_5] citizen_122 entered the queue
[D1 13:31:22 floor_5] citizen_122 found an empty queue and will be served immediately
[D1 13:31:22 elevator_2] Summoned to floor 5 from floor 5
[D1 13:31:22 elevator_2] Opening doors
[D1 13:31:24 elevator_1] Opened doors
[D1 13:31:24 citizen_111] Entered elevator_1, going to floor 5
[D1 13:31:24 floor_3] citizen_111 is leaving the queue
[D1 13:31:24 floor_3] The queue is now empty
[D1 13:31:25 elevator_2] Opened doors
[D1 13:31:25 citizen_122] Entered elevator_2, going to floor 3
[D1 13:31:25 floor_5] citizen_122 is leaving the queue
[D1 13:31:25 floor_5] The queue is now empty
[D1 13:31:36 elevator_1] Closing doors
[D1 13:31:37 elevator_2] Closing doors
[D1 13:31:39 elevator_1] Closed doors
[D1 13:31:40 elevator_2] Closed doors
[D1 13:31:40 elevator_2] Sprung into motion, heading Down
[D1 13:31:41 citizen_141] Entered the building, will visit 4 floors in total
[D1 13:31:41 citizen_141] Time to go to floor 4 and stay there for 00:29:04
[D1 13:31:41 floor_0] citizen_141 entered the queue
[D1 13:31:41 floor_0] citizen_141 is queued along with 0 other arrivals in front of it
[D1 13:31:49 elevator_1] At floor 2
[D1 13:31:49 elevator_1] Stopped at floor 2
[D1 13:31:49 elevator_1] Opening doors
[D1 13:31:50 elevator_2] At floor 4
[D1 13:31:52 elevator_1] Opened doors
[D1 13:31:52 citizen_91] Entered elevator_1, going to floor 0
[D1 13:31:52 floor_2] citizen_91 is leaving the queue
[D1 13:31:52 floor_2] The queue is now empty
[D1 13:32:00 elevator_2] At floor 3
[D1 13:32:00 elevator_2] Stopped at floor 3
[D1 13:32:00 elevator_2] Opening doors
[D1 13:32:03 elevator_2] Opened doors
[D1 13:32:03 citizen_122] Left elevator_2, arrived at floor 3
[D1 13:32:04 elevator_1] Closing doors
[D1 13:32:07 elevator_1] Closed doors
[D1 13:32:15 elevator_2] Closing doors
[D1 13:32:17 elevator_1] At floor 1
[D1 13:32:18 elevator_2] Closed doors
[D1 13:32:18 elevator_2] Resting at floor 3
[D1 13:32:26 citizen_71] Time to go to the ground floor and leave
[D1 13:32:26 floor_5] citizen_71 entered the queue
[D1 13:32:26 floor_5] citizen_71 found an empty queue and will be served immediately
[D1 13:32:26 elevator_2] Summoned to floor 5 from floor 3
[D1 13:32:26 elevator_2] Sprung into motion, heading Up
[D1 13:32:27 elevator_1] At floor 0
[D1 13:32:27 elevator_1] Stopped at floor 0
[D1 13:32:27 elevator_1] Opening doors
[D1 13:32:30 elevator_1] Opened doors
[D1 13:32:30 citizen_91] Left elevator_1, arrived at floor 0
[D1 13:32:30 citizen_91] Left the building
[D1 13:32:30 citizen_140] Entered elevator_1, going to floor 4
[D1 13:32:30 floor_0] citizen_140 is leaving the queue
[D1 13:32:30 floor_0] citizen_141 was served
[D1 13:32:30 elevator_1] Summoned to floor 0 from floor 0
[D1 13:32:30 citizen_141] Entered elevator_1, going to floor 4
[D1 13:32:30 floor_0] citizen_141 is leaving the queue
[D1 13:32:30 floor_0] The queue is now empty
[D1 13:32:36 elevator_2] At floor 4
[D1 13:32:42 elevator_1] Closing doors
[D1 13:32:42 citizen_86] Time to go to the ground floor and leave
[D1 13:32:42 floor_4] citizen_86 entered the queue
[D1 13:32:42 floor_4] citizen_86 found an empty queue and will be served immediately
[D1 13:32:42 elevator_2] Summoned to floor 4 from floor 4
[D1 13:32:45 elevator_1] Closed doors
[D1 13:32:45 elevator_1] Changing direction to Up
[D1 13:32:46 elevator_2] At floor 5
[D1 13:32:46 elevator_2] Stopped at floor 5
[D1 13:32:46 elevator_2] Opening doors
[D1 13:32:49 elevator_2] Opened doors
[D1 13:32:49 citizen_71] Entered elevator_2, going to floor 0
[D1 13:32:49 floor_5] citizen_71 is leaving the queue
[D1 13:32:49 floor_5] The queue is now empty
[D1 13:32:55 elevator_1] At floor 1
[D1 13:33:01 citizen_142] Entered the building, will visit 3 floors in total
[D1 13:33:01 citizen_142] Time to go to floor 4 and stay there for 00:26:47
[D1 13:33:01 floor_0] citizen_142 entered the queue
[D1 13:33:01 floor_0] citizen_142 found an empty queue and will be served immediately
[D1 13:33:01 elevator_1] Summoned to floor 0 from floor 1
[D1 13:33:01 elevator_2] Closing doors
[D1 13:33:04 elevator_2] Closed doors
[D1 13:33:04 elevator_2] Changing direction to Down
[D1 13:33:05 elevator_1] At floor 2
[D1 13:33:12 citizen_115] Time to go to floor 1 and stay there for 00:27:06
[D1 13:33:12 floor_3] citizen_115 entered the queue
[D1 13:33:12 floor_3] citizen_115 found an empty queue and will be served immediately
[D1 13:33:12 elevator_1] Summoned to floor 3 from floor 2
[D1 13:33:14 elevator_2] At floor 4
[D1 13:33:14 elevator_2] Stopped at floor 4
[D1 13:33:14 elevator_2] Opening doors
[D1 13:33:15 elevator_1] At floor 3
[D1 13:33:15 elevator_1] Stopped at floor 3
[D1 13:33:15 elevator_1] Opening doors
[D1 13:33:17 elevator_2] Opened doors
[D1 13:33:17 citizen_86] Entered elevator_2, going to floor 0
[D1 13:33:17 floor_4] citizen_86 is leaving the queue
[D1 13:33:17 floor_4] The queue is now empty
[D1 13:33:18 elevator_1] Opened doors
[D1 13:33:18 citizen_115] Entered elevator_1, going to floor 1
[D1 13:33:18 floor_3] citizen_115 is leaving the queue
[D1 13:33:18 floor_3] The queue is now empty
[D1 13:33:29 elevator_2] Closing doors
[D1 13:33:30 elevator_1] Closing doors
[D1 13:33:32 elevator_2] Closed doors
[D1 13:33:33 elevator_1] Closed doors
[D1 13:33:37 citizen_127] Time to go to floor 3 and stay there for 00:29:52
[D1 13:33:37 floor_5] citizen_127 entered the queue
[D1 13:33:37 floor_5] citizen_127 found an empty queue and will be served immediately
[D1 13:33:37 elevator_2] Summoned to floor 5 from floor 4
[D1 13:33:42 elevator_2] At floor 3
[D1 13:33:43 elevator_1] At floor 4
[D1 13:33:43 elevator_1] Stopped at floor 4
[D1 13:33:43 elevator_1] Opening doors
[D1 13:33:45 citizen_102] Time to go to floor 4 and stay there for 00:24:42
[D1 13:33:45 floor_5] citizen_102 entered the queue
[D1 13:33:45 floor_5] citizen_102 is queued along with 0 other arrivals in front of it
[D1 13:33:46 elevator_1] Opened doors
[D1 13:33:46 citizen_140] Left elevator_1, arrived at floor 4
[D1 13:33:46 citizen_141] Left elevator_1, arrived at floor 4
[D1 13:33:52 elevator_2] At floor 2
[D1 13:33:58 elevator_1] Closing doors
[D1 13:34:01 elevator_1] Closed doors
[D1 13:34:02 elevator_2] At floor 1
[D1 13:34:07 citizen_96] Time to go to the ground floor and leave
[D1 13:34:07 floor_5] citizen_96 entered the queue
[D1 13:34:07 floor_5] citizen_96 is queued along with 1 other arrivals in front of it
[D1 13:34:11 citizen_77] Time to go to the ground floor and leave
[D1 13:34:11 floor_1] citizen_77 entered the queue
[D1 13:34:11 floor_1] citizen_77 found an empty queue and will be served immediately
[D1 13:34:11 elevator_2] Summoned to floor 1 from floor 1
[D1 13:34:11 elevator_1] At floor 5
[D1 13:34:11 elevator_1] Stopped at floor 5
[D1 13:34:11 elevator_1] Opening doors
[D1 13:34:12 elevator_2] At floor 0
[D1 13:34:12 elevator_2] Stopped at floor 0
[D1 13:34:12 elevator_2] Opening doors
[D1 13:34:14 elevator_1] Opened doors
[D1 13:34:14 citizen_111] Left elevator_1, arrived at floor 5
[D1 13:34:15 elevator_2] Opened doors
[D1 13:34:15 citizen_71] Left elevator_2, arrived at floor 0
[D1 13:34:15 citizen_86] Left elevator_2, arrived at floor 0
[D1 13:34:15 citizen_71] Left the building
[D1 13:34:15 citizen_86] Left the building
[D1 13:34:26 elevator_1] Closing doors
[D1 13:34:27 elevator_2] Closing doors
[D1 13:34:29 elevator_1] Closed doors
[D1 13:34:29 elevator_1] Changing direction to Down
[D1 13:34:30 elevator_2] Closed doors
[D1 13:34:30 elevator_2] Changing direction to Up
[D1 13:34:39 elevator_1] At floor 4
[D1 13:34:40 elevator_2] At floor 1
[D1 13:34:40 elevator_2] Stopped at floor 1
[D1 13:34:40 elevator_2] Opening doors
[D1 13:34:43 elevator_2] Opened doors
[D1 13:34:43 citizen_77] Entered elevator_2, going to floor 0
[D1 13:34:43 floor_1] citizen_77 is leaving the queue
[D1 13:34:43 floor_1] The queue is now empty
[D1 13:34:49 elevator_1] At floor 3
[D1 13:34:55 elevator_2] Closing doors
[D1 13:34:58 elevator_2] Closed doors
[D1 13:34:59 elevator_1] At floor 2
[D1 13:35:08 elevator_2] At floor 2
[D1 13:35:09 citizen_143] Entered the building, will visit 6 floors in total
[D1 13:35:09 citizen_143] Time to go to floor 3 and stay there for 00:28:41
[D1 13:35:09 floor_0] citizen_143 entered the queue
[D1 13:35:09 floor_0] citizen_143 is queued along with 0 other arrivals in front of it
[D1 13:35:09 elevator_1] At floor 1
[D1 13:35:09 elevator_1] Stopped at floor 1
[D1 13:35:09 elevator_1] Opening doors
[D1 13:35:12 elevator_1] Opened doors
[D1 13:35:12 citizen_115] Left elevator_1, arrived at floor 1
[D1 13:35:18 elevator_2] At floor 3
[D1 13:35:24 elevator_1] Closing doors
[D1 13:35:27 elevator_1] Closed doors
[D1 13:35:28 elevator_2] At floor 4
[D1 13:35:37 elevator_1] At floor 0
[D1 13:35:37 elevator_1] Stopped at floor 0
[D1 13:35:37 elevator_1] Opening doors
[D1 13:35:38 elevator_2] At floor 5
[D1 13:35:38 elevator_2] Stopped at floor 5
[D1 13:35:38 elevator_2] Opening doors
[D1 13:35:40 elevator_1] Opened doors
[D1 13:35:40 citizen_142] Entered elevator_1, going to floor 4
[D1 13:35:40 floor_0] citizen_142 is leaving the queue
[D1 13:35:40 floor_0] citizen_143 was served
[D1 13:35:40 elevator_1] Summoned to floor 0 from floor 0
[D1 13:35:40 citizen_143] Entered elevator_1, going to floor 3
[D1 13:35:40 floor_0] citizen_143 is leaving the queue
[D1 13:35:40 floor_0] The queue is now empty
[D1 13:35:41 elevator_2] Opened doors
[D1 13:35:41 citizen_127] Entered elevator_2, going to floor 3
[D1 13:35:41 floor_5] citizen_127 is leaving the queue
[D1 13:35:41 floor_5] citizen_102 was served
[D1 13:35:41 elevator_2] Summoned to floor 5 from floor 5
[D1 13:35:41 citizen_102] Entered elevator_2, going to floor 4
[D1 13:35:41 floor_5] citizen_102 is leaving the queue
[D1 13:35:41 floor_5] citizen_96 was served
[D1 13:35:41 elevator_2] Summoned to floor 5 from floor 5
[D1 13:35:41 citizen_96] Entered elevator_2, going to floor 0
[D1 13:35:41 floor_5] citizen_96 is leaving the queue
[D1 13:35:41 floor_5] The queue is now empty
[D1 13:35:52 elevator_1] Closing doors
[D1 13:35:53 elevator_2] Closing doors
[D1 13:35:55 elevator_1] Closed doors
[D1 13:35:55 elevator_1] Changing direction to Up
[D1 13:35:56 elevator_2] Closed doors
[D1 13:35:56 elevator_2] Changing direction to Down
[D1 13:36:05 elevator_1] At floor 1
[D1 13:36:06 elevator_2] At floor 4
[D1 13:36:06 elevator_2] Stopped at floor 4
[D1 13:36:06 elevator_2] Opening doors
[D1 13:36:09 elevator_2] Opened doors
[D1 13:36:09 citizen_102] Left elevator_2, arrived at floor 4
[D1 13:36:15 elevator_1] At floor 2
[D1 13:36:17 citizen_119] Time to go to the ground floor and leave
[D1 13:36:17 floor_3] citizen_119 entered the queue
[D1 13:36:17 floor_3] citizen_119 found an empty queue and will be served immediately
[D1 13:36:17 elevator_1] Summoned to floor 3 from floor 2
[D1 13:36:17 elevator_2] Summoned to floor 3 from floor 4
[D1 13:36:21 citizen_101] Time to go to floor 3 and stay there for 00:40:08
[D1 13:36:21 floor_4] citizen_101 entered the queue
[D1 13:36:21 floor_4] citizen_101 found an empty queue and will be served immediately
[D1 13:36:21 elevator_2] Summoned to floor 4 from floor 4
[D1 13:36:21 citizen_101] Entered elevator_2, going to floor 3
[D1 13:36:21 floor_4] citizen_101 is leaving the queue
[D1 13:36:21 floor_4] The queue is now empty
[D1 13:36:21 elevator_2] Closing doors
[D1 13:36:24 elevator_2] Closed doors
[D1 13:36:25 elevator_1] At floor 3
[D1 13:36:25 elevator_1] Stopped at floor 3
[D1 13:36:25 elevator_1] Opening doors
[D1 13:36:28 elevator_1] Opened doors
[D1 13:36:28 citizen_143] Left elevator_1, arrived at floor 3
[D1 13:36:28 citizen_119] Entered elevator_1, going to floor 0
[D1 13:36:28 floor_3] citizen_119 is leaving the queue
[D1 13:36:28 floor_3] The queue is now empty
[D1 13:36:34 elevator_2] At floor 3
[D1 13:36:34 elevator_2] Stopped at floor 3
[D1 13:36:34 elevator_2] Opening doors
[D1 13:36:37 elevator_2] Opened doors
[D1 13:36:37 citizen_127] Left elevator_2, arrived at floor 3
[D1 13:36:37 citizen_101] Left elevator_2, arrived at floor 3
[D1 13:36:40 elevator_1] Closing doors
[D1 13:36:43 elevator_1] Closed doors
[D1 13:36:49 elevator_2] Closing doors
[D1 13:36:52 elevator_2] Closed doors
[D1 13:36:53 elevator_1] At floor 4
[D1 13:36:53 elevator_1] Stopped at floor 4
[D1 13:36:53 elevator_1] Opening doors
[D1 13:36:56 elevator_1] Opened doors
[D1 13:36:56 citizen_142] Left elevator_1, arrived at floor 4
[D1 13:37:02 elevator_2] At floor 2
[D1 13:37:08 elevator_1] Closing doors
[D1 13:37:11 elevator_1] Closed doors
[D1 13:37:11 elevator_1] Changing direction to Down
[D1 13:37:12 elevator_2] At floor 1
[D1 13:37:21 elevator_1] At floor 3
[D1 13:37:22 elevator_2] At floor 0
[D1 13:37:22 elevator_2] Stopped at floor 0
[D1 13:37:22 elevator_2] Opening doors
[D1 13:37:25 elevator_2] Opened doors
[D1 13:37:25 citizen_77] Left elevator_2, arrived at floor 0
[D1 13:37:25 citizen_96] Left elevator_2, arrived at floor 0
[D1 13:37:25 citizen_77] Left the building
[D1 13:37:25 citizen_96] Left the building
[D1 13:37:31 elevator_1] At floor 2
[D1 13:37:37 elevator_2] Closing doors
[D1 13:37:40 elevator_2] Closed doors
[D1 13:37:40 elevator_2] Resting at floor 0
[D1 13:37:41 elevator_1] At floor 1
[D1 13:37:46 citizen_108] Time to go to the ground floor and leave
[D1 13:37:46 floor_3] citizen_108 entered the queue
[D1 13:37:46 floor_3] citizen_108 found an empty queue and will be served immediately
[D1 13:37:46 elevator_1] Summoned to floor 3 from floor 1
[D1 13:37:51 elevator_1] At floor 0
[D1 13:37:51 elevator_1] Stopped at floor 0
[D1 13:37:51 elevator_1] Opening doors
[D1 13:37:54 elevator_1] Opened doors
[D1 13:37:54 citizen_119] Left elevator_1, arrived at floor 0
[D1 13:37:54 citizen_119] Left the building
[D1 13:38:01 citizen_84] Time to go to the ground floor and leave
[D1 13:38:01 floor_2] citizen_84 entered the queue
[D1 13:38:01 floor_2] citizen_84 found an empty queue and will be served immediately
[D1 13:38:01 elevator_1] Summoned to floor 2 from floor 0
[D1 13:38:01 elevator_2] Summoned to floor 2 from floor 0
[D1 13:38:01 elevator_2] Sprung into motion, heading Up
[D1 13:38:06 elevator_1] Closing doors
[D1 13:38:09 elevator_1] Closed doors
[D1 13:38:09 elevator_1] Changing direction to Up
[D1 13:38:11 elevator_2] At floor 1
[D1 13:38:19 elevator_1] At floor 1
[D1 13:38:21 elevator_2] At floor 2
[D1 13:38:21 elevator_2] Stopped at floor 2
[D1 13:38:21 elevator_2] Opening doors
[D1 13:38:24 elevator_2] Opened doors
[D1 13:38:24 citizen_84] Entered elevator_2, going to floor 0
[D1 13:38:24 floor_2] citizen_84 is leaving the queue
[D1 13:38:24 floor_2] The queue is now empty
[D1 13:38:29 elevator_1] At floor 2
[D1 13:38:29 elevator_1] Stopped at floor 2
[D1 13:38:29 elevator_1] Opening doors
[D1 13:38:32 elevator_1] Opened doors
[D1 13:38:36 elevator_2] Closing doors
[D1 13:38:39 elevator_2] Closed doors
[D1 13:38:39 elevator_2] Changing direction to Down
[D1 13:38:44 elevator_1] Closing doors
[D1 13:38:47 elevator_1] Closed doors
[D1 13:38:49 elevator_2] At floor 1
[D1 13:38:55 citizen_144] Entered the building, will visit 4 floors in total
[D1 13:38:55 citizen_144] Time to go to floor 4 and stay there for 00:31:32
[D1 13:38:55 floor_0] citizen_144 entered the queue
[D1 13:38:55 floor_0] citizen_144 found an empty queue and will be served immediately
[D1 13:38:55 elevator_2] Summoned to floor 0 from floor 1
[D1 13:38:57 elevator_1] At floor 3
[D1 13:38:57 elevator_1] Stopped at floor 3
[D1 13:38:57 elevator_1] Opening doors
[D1 13:38:59 elevator_2] At floor 0
[D1 13:38:59 elevator_2] Stopped at floor 0
[D1 13:38:59 elevator_2] Opening doors
[D1 13:39:00 elevator_1] Opened doors
[D1 13:39:00 citizen_108] Entered elevator_1, going to floor 0
[D1 13:39:00 floor_3] citizen_108 is leaving the queue
[D1 13:39:00 floor_3] The queue is now empty
[D1 13:39:02 elevator_2] Opened doors
[D1 13:39:02 citizen_84] Left elevator_2, arrived at floor 0
[D1 13:39:02 citizen_84] Left the building
[D1 13:39:02 citizen_144] Entered elevator_2, going to floor 4
[D1 13:39:02 floor_0] citizen_144 is leaving the queue
[D1 13:39:02 floor_0] The queue is now empty
[D1 13:39:12 elevator_1] Closing doors
[D1 13:39:14 elevator_2] Closing doors
[D1 13:39:15 citizen_118] Time to go to floor 3 and stay there for 00:39:50
[D1 13:39:15 floor_1] citizen_118 entered the queue
[D1 13:39:15 floor_1] citizen_118 found an empty queue and will be served immediately
[D1 13:39:15 elevator_2] Summoned to floor 1 from floor 0
[D1 13:39:15 elevator_1] Closed doors
[D1 13:39:15 elevator_1] Changing direction to Down
[D1 13:39:17 citizen_113] Time to go to floor 2 and stay there for 00:42:39
[D1 13:39:17 floor_4] citizen_113 entered the queue
[D1 13:39:17 floor_4] citizen_113 found an empty queue and will be served immediately
[D1 13:39:17 elevator_1] Summoned to floor 4 from floor 3
[D1 13:39:17 elevator_2] Closed doors
[D1 13:39:17 elevator_2] Changing direction to Up
[D1 13:39:24 citizen_114] Time to go to floor 5 and stay there for 00:26:47
[D1 13:39:24 floor_4] citizen_114 entered the queue
[D1 13:39:24 floor_4] citizen_114 is queued along with 0 other arrivals in front of it
[D1 13:39:25 elevator_1] At floor 2
[D1 13:39:27 elevator_2] At floor 1
[D1 13:39:27 elevator_2] Stopped at floor 1
[D1 13:39:27 elevator_2] Opening doors
[D1 13:39:30 elevator_2] Opened doors
[D1 13:39:30 citizen_118] Entered elevator_2, going to floor 3
[D1 13:39:30 floor_1] citizen_118 is leaving the queue
[D1 13:39:30 floor_1] The queue is now empty
[D1 13:39:35 elevator_1] At floor 1
[D1 13:39:42 elevator_2] Closing doors
[D1 13:39:45 elevator_1] At floor 0
[D1 13:39:45 elevator_1] Stopped at floor 0
[D1 13:39:45 elevator_1] Opening doors
[D1 13:39:45 elevator_2] Closed doors
[D1 13:39:48 elevator_1] Opened doors
[D1 13:39:48 citizen_108] Left elevator_1, arrived at floor 0
[D1 13:39:48 citizen_108] Left the building
[D1 13:39:55 elevator_2] At floor 2
[D1 13:40:00 elevator_1] Closing doors
[D1 13:40:03 elevator_1] Closed doors
[D1 13:40:03 elevator_1] Changing direction to Up
[D1 13:40:05 elevator_2] At floor 3
[D1 13:40:05 elevator_2] Stopped at floor 3
[D1 13:40:05 elevator_2] Opening doors
[D1 13:40:08 elevator_2] Opened doors
[D1 13:40:08 citizen_118] Left elevator_2, arrived at floor 3
[D1 13:40:13 elevator_1] At floor 1
[D1 13:40:20 elevator_2] Closing doors
[D1 13:40:23 elevator_1] At floor 2
[D1 13:40:23 elevator_2] Closed doors
[D1 13:40:33 elevator_1] At floor 3
[D1 13:40:33 elevator_2] At floor 4
[D1 13:40:33 elevator_2] Stopped at floor 4
[D1 13:40:33 elevator_2] Opening doors
[D1 13:40:36 elevator_2] Opened doors
[D1 13:40:36 citizen_144] Left elevator_2, arrived at floor 4
[D1 13:40:43 elevator_1] At floor 4
[D1 13:40:43 elevator_1] Stopped at floor 4
[D1 13:40:43 elevator_1] Opening doors
[D1 13:40:46 elevator_1] Opened doors
[D1 13:40:46 citizen_113] Entered elevator_1, going to floor 2
[D1 13:40:46 floor_4] citizen_113 is leaving the queue
[D1 13:40:46 floor_4] citizen_114 was served
[D1 13:40:46 elevator_1] Summoned to floor 4 from floor 4
[D1 13:40:46 elevator_2] Summoned to floor 4 from floor 4
[D1 13:40:46 citizen_114] Entered elevator_1, going to floor 5
[D1 13:40:46 floor_4] citizen_114 is leaving the queue
[D1 13:40:46 floor_4] The queue is now empty
[D1 13:40:48 elevator_2] Closing doors
[D1 13:40:51 elevator_2] Closed doors
[D1 13:40:51 elevator_2] Resting at floor 4
[D1 13:40:58 elevator_1] Closing doors
[D1 13:41:01 elevator_1] Closed doors
[D1 13:41:11 elevator_1] At floor 5
[D1 13:41:11 elevator_1] Stopped at floor 5
[D1 13:41:11 elevator_1] Opening doors
[D1 13:41:14 elevator_1] Opened doors
[D1 13:41:14 citizen_114] Left elevator_1, arrived at floor 5
[D1 13:41:26 elevator_1] Closing doors
[D1 13:41:29 elevator_1] Closed doors
[D1 13:41:29 elevator_1] Changing direction to Down
[D1 13:41:30 citizen_130] Time to go to floor 1 and stay there for 00:27:00
[D1 13:41:30 floor_2] citizen_130 entered the queue
[D1 13:41:30 floor_2] citizen_130 found an empty queue and will be served immediately
[D1 13:41:30 elevator_2] Summoned to floor 2 from floor 4
[D1 13:41:30 elevator_2] Sprung into motion, heading Down
[D1 13:41:30 citizen_103] Time to go to floor 4 and stay there for 00:23:16
[D1 13:41:30 floor_1] citizen_103 entered the queue
[D1 13:41:30 floor_1] citizen_103 found an empty queue and will be served immediately
[D1 13:41:30 elevator_2] Summoned to floor 1 from floor 4
[D1 13:41:39 elevator_1] At floor 4
[D1 13:41:40 elevator_2] At floor 3
[D1 13:41:49 citizen_145] Entered the building, will visit 3 floors in total
[D1 13:41:49 citizen_145] Time to go to floor 3 and stay there for 00:30:51
[D1 13:41:49 floor_0] citizen_145 entered the queue
[D1 13:41:49 floor_0] citizen_145 found an empty queue and will be served immediately
[D1 13:41:49 elevator_2] Summoned to floor 0 from floor 3
[D1 13:41:49 elevator_1] At floor 3
[D1 13:41:50 elevator_2] At floor 2
[D1 13:41:50 elevator_2] Stopped at floor 2
[D1 13:41:50 elevator_2] Opening doors
[D1 13:41:51 citizen_129] Time to go to floor 2 and stay there for 00:19:08
[D1 13:41:51 floor_5] citizen_129 entered the queue
[D1 13:41:51 floor_5] citizen_129 found an empty queue and will be served immediately
[D1 13:41:51 elevator_1] Summoned to floor 5 from floor 3
[D1 13:41:53 elevator_2] Opened doors
[D1 13:41:53 citizen_130] Entered elevator_2, going to floor 1
[D1 13:41:53 floor_2] citizen_130 is leaving the queue
[D1 13:41:53 floor_2] The queue is now empty
[D1 13:41:59 elevator_1] At floor 2
[D1 13:41:59 elevator_1] Stopped at floor 2
[D1 13:41:59 elevator_1] Opening doors
[D1 13:42:02 elevator_1] Opened doors
[D1 13:42:02 citizen_113] Left elevator_1, arrived at floor 2
[D1 13:42:03 citizen_133] Time to go to floor 5 and stay there for 00:21:41
[D1 13:42:03 floor_1] citizen_133 entered the queue
[D1 13:42:03 floor_1] citizen_133 is queued along with 0 other arrivals in front of it
[D1 13:42:05 elevator_2] Closing doors
[D1 13:42:08 elevator_2] Closed doors
[D1 13:42:14 elevator_1] Closing doors
[D1 13:42:17 elevator_1] Closed doors
[D1 13:42:17 elevator_1] Changing direction to Up
[D1 13:42:18 elevator_2] At floor 1
[D1 13:42:18 elevator_2] Stopped at floor 1
[D1 13:42:18 elevator_2] Opening doors
[D1 13:42:21 elevator_2] Opened doors
[D1 13:42:21 citizen_130] Left elevator_2, arrived at floor 1
[D1 13:42:21 citizen_103] Entered elevator_2, going to floor 4
[D1 13:42:21 floor_1] citizen_103 is leaving the queue
[D1 13:42:21 floor_1] citizen_133 was served
[D1 13:42:21 elevator_2] Summoned to floor 1 from floor 1
[D1 13:42:21 citizen_133] Entered elevator_2, going to floor 5
[D1 13:42:21 floor_1] citizen_133 is leaving the queue
[D1 13:42:21 floor_1] The queue is now empty
[D1 13:42:27 elevator_1] At floor 3
[D1 13:42:33 elevator_2] Closing doors
[D1 13:42:36 elevator_2] Closed doors
[D1 13:42:37 elevator_1] At floor 4
[D1 13:42:46 elevator_2] At floor 0
[D1 13:42:46 elevator_2] Stopped at floor 0
[D1 13:42:46 elevator_2] Opening doors
[D1 13:42:47 elevator_1] At floor 5
[D1 13:42:47 elevator_1] Stopped at floor 5
[D1 13:42:47 elevator_1] Opening doors
[D1 13:42:49 elevator_2] Opened doors
[D1 13:42:49 citizen_145] Entered elevator_2, going to floor 3
[D1 13:42:49 floor_0] citizen_145 is leaving the queue
[D1 13:42:49 floor_0] The queue is now empty
[D1 13:42:50 elevator_1] Opened doors
[D1 13:42:50 citizen_129] Entered elevator_1, going to floor 2
[D1 13:42:50 floor_5] citizen_129 is leaving the queue
[D1 13:42:50 floor_5] The queue is now empty
[D1 13:43:01 elevator_2] Closing doors
[D1 13:43:02 elevator_1] Closing doors
[D1 13:43:04 elevator_2] Closed doors
[D1 13:43:04 elevator_2] Changing direction to Up
[D1 13:43:05 elevator_1] Closed doors
[D1 13:43:05 elevator_1] Changing direction to Down
[D1 13:43:14 elevator_2] At floor 1
[D1 13:43:15 elevator_1] At floor 4
[D1 13:43:24 elevator_2] At floor 2
[D1 13:43:25 elevator_1] At floor 3
[D1 13:43:27 citizen_146] Entered the building, will visit 5 floors in total
[D1 13:43:27 citizen_146] Time to go to floor 5 and stay there for 00:18:01
[D1 13:43:27 floor_0] citizen_146 entered the queue
[D1 13:43:27 floor_0] citizen_146 found an empty queue and will be served immediately
[D1 13:43:27 elevator_2] Summoned to floor 0 from floor 2
[D1 13:43:34 elevator_2] At floor 3
[D1 13:43:34 elevator_2] Stopped at floor 3
[D1 13:43:34 elevator_2] Opening doors
[D1 13:43:35 elevator_1] At floor 2
[D1 13:43:35 elevator_1] Stopped at floor 2
[D1 13:43:35 elevator_1] Opening doors
[D1 13:43:37 elevator_2] Opened doors
[D1 13:43:37 citizen_145] Left elevator_2, arrived at floor 3
[D1 13:43:38 elevator_1] Opened doors
[D1 13:43:38 citizen_129] Left elevator_1, arrived at floor 2
[D1 13:43:49 elevator_2] Closing doors
[D1 13:43:50 elevator_1] Closing doors
[D1 13:43:52 elevator_2] Closed doors
[D1 13:43:53 elevator_1] Closed doors
[D1 13:43:53 elevator_1] Resting at floor 2
[D1 13:44:02 elevator_2] At floor 4
[D1 13:44:02 elevator_2] Stopped at floor 4
[D1 13:44:02 elevator_2] Opening doors
[D1 13:44:02 citizen_112] Time to go to floor 4 and stay there for 00:43:21
[D1 13:44:02 floor_3] citizen_112 entered the queue
[D1 13:44:02 floor_3] citizen_112 found an empty queue and will be served immediately
[D1 13:44:02 elevator_1] Summoned to floor 3 from floor 2
[D1 13:44:02 elevator_1] Sprung into motion, heading Up
[D1 13:44:02 elevator_2] Summoned to floor 3 from floor 4
[D1 13:44:05 elevator_2] Opened doors
[D1 13:44:05 citizen_103] Left elevator_2, arrived at floor 4
[D1 13:44:12 elevator_1] At floor 3
[D1 13:44:12 elevator_1] Stopped at floor 3
[D1 13:44:12 elevator_1] Opening doors
[D1 13:44:15 elevator_1] Opened doors
[D1 13:44:15 citizen_112] Entered elevator_1, going to floor 4
[D1 13:44:15 floor_3] citizen_112 is leaving the queue
[D1 13:44:15 floor_3] The queue is now empty
[D1 13:44:17 elevator_2] Closing doors
[D1 13:44:20 elevator_2] Closed doors
[D1 13:44:27 citizen_117] Time to go to the ground floor and leave
[D1 13:44:27 floor_5] citizen_117 entered the queue
[D1 13:44:27 floor_5] citizen_117 found an empty queue and will be served immediately
[D1 13:44:27 elevator_2] Summoned to floor 5 from floor 4
[D1 13:44:27 elevator_1] Closing doors
[D1 13:44:30 elevator_2] At floor 5
[D1 13:44:30 elevator_2] Stopped at floor 5
[D1 13:44:30 elevator_2] Opening doors
[D1 13:44:30 elevator_1] Closed doors
[D1 13:44:33 elevator_2] Opened doors
[D1 13:44:33 citizen_133] Left elevator_2, arrived at floor 5
[D1 13:44:33 citizen_117] Entered elevator_2, going to floor 0
[D1 13:44:33 floor_5] citizen_117 is leaving the queue
[D1 13:44:33 floor_5] The queue is now empty
[D1 13:44:40 elevator_1] At floor 4
[D1 13:44:40 elevator_1] Stopped at floor 4
[D1 13:44:40 elevator_1] Opening doors
[D1 13:44:43 elevator_1] Opened doors
[D1 13:44:43 citizen_112] Left elevator_1, arrived at floor 4
[D1 13:44:45 elevator_2] Closing doors
[D1 13:44:48 elevator_2] Closed doors
[D1 13:44:48 elevator_2] Changing direction to Down
[D1 13:44:53 citizen_67] Time to go to the ground floor and leave
[D1 13:44:53 floor_4] citizen_67 entered the queue
[D1 13:44:53 floor_4] citizen_67 found an empty queue and will be served immediately
[D1 13:44:53 elevator_1] Summoned to floor 4 from floor 4
[D1 13:44:53 citizen_67] Entered elevator_1, going to floor 0
[D1 13:44:53 floor_4] citizen_67 is leaving the queue
[D1 13:44:53 floor_4] The queue is now empty
[D1 13:44:55 elevator_1] Closing doors
[D1 13:44:58 elevator_2] At floor 4
[D1 13:44:58 elevator_1] Closed doors
[D1 13:44:58 elevator_1] Changing direction to Down
[D1 13:44:59 citizen_110] Time to go to floor 2 and stay there for 00:26:37
[D1 13:44:59 floor_5] citizen_110 entered the queue
[D1 13:44:59 floor_5] citizen_110 found an empty queue and will be served immediately
[D1 13:44:59 elevator_1] Summoned to floor 5 from floor 4
[D1 13:44:59 elevator_2] Summoned to floor 5 from floor 4
[D1 13:45:08 elevator_2] At floor 3
[D1 13:45:08 elevator_2] Stopped at floor 3
[D1 13:45:08 elevator_2] Opening doors
[D1 13:45:08 elevator_1] At floor 3
[D1 13:45:11 elevator_2] Opened doors
[D1 13:45:13 citizen_116] Time to go to floor 2 and stay there for 00:22:26
[D1 13:45:13 floor_5] citizen_116 entered the queue
[D1 13:45:13 floor_5] citizen_116 is queued along with 0 other arrivals in front of it
[D1 13:45:18 elevator_1] At floor 2
[D1 13:45:23 elevator_2] Closing doors
[D1 13:45:26 elevator_2] Closed doors
[D1 13:45:28 elevator_1] At floor 1
[D1 13:45:29 citizen_147] Entered the building, will visit 4 floors in total
[D1 13:45:29 citizen_147] Time to go to floor 3 and stay there for 00:16:28
[D1 13:45:29 floor_0] citizen_147 entered the queue
[D1 13:45:29 floor_0] citizen_147 is queued along with 0 other arrivals in front of it
[D1 13:45:36 elevator_2] At floor 2
[D1 13:45:38 elevator_1] At floor 0
[D1 13:45:38 elevator_1] Stopped at floor 0
[D1 13:45:38 elevator_1] Opening doors
[D1 13:45:41 elevator_1] Opened doors
[D1 13:45:41 citizen_67] Left elevator_1, arrived at floor 0
[D1 13:45:41 citizen_67] Left the building
[D1 13:45:46 elevator_2] At floor 1
[D1 13:45:53 elevator_1] Closing doors
[D1 13:45:56 elevator_2] At floor 0
[D1 13:45:56 elevator_2] Stopped at floor 0
[D1 13:45:56 elevator_2] Opening doors
[D1 13:45:56 elevator_1] Closed doors
[D1 13:45:56 elevator_1] Changing direction to Up
[D1 13:45:59 elevator_2] Opened doors
[D1 13:45:59 citizen_117] Left elevator_2, arrived at floor 0
[D1 13:45:59 citizen_117] Left the building
[D1 13:45:59 citizen_146] Entered elevator_2, going to floor 5
[D1 13:45:59 floor_0] citizen_146 is leaving the queue
[D1 13:45:59 floor_0] citizen_147 was served
[D1 13:45:59 elevator_1] Summoned to floor 0 from floor 0
[D1 13:45:59 elevator_2] Summoned to floor 0 from floor 0
[D1 13:45:59 citizen_147] Entered elevator_2, going to floor 3
[D1 13:45:59 floor_0] citizen_147 is leaving the queue
[D1 13:45:59 floor_0] The queue is now empty
[D1 13:46:06 elevator_1] At floor 1
[D1 13:46:11 elevator_2] Closing doors
[D1 13:46:14 elevator_2] Closed doors
[D1 13:46:14 elevator_2] Changing direction to Up
[D1 13:46:16 elevator_1] At floor 2
[D1 13:46:24 elevator_2] At floor 1
[D1 13:46:26 elevator_1] At floor 3
[D1 13:46:34 citizen_148] Entered the building, will visit 3 floors in total
[D1 13:46:34 citizen_148] Time to go to floor 1 and stay there for 00:33:41
[D1 13:46:34 floor_0] citizen_148 entered the queue
[D1 13:46:34 floor_0] citizen_148 found an empty queue and will be served immediately
[D1 13:46:34 elevator_2] Summoned to floor 0 from floor 1
[D1 13:46:34 elevator_2] At floor 2
[D1 13:46:36 elevator_1] At floor 4
[D1 13:46:44 elevator_2] At floor 3
[D1 13:46:44 elevator_2] Stopped at floor 3
[D1 13:46:44 elevator_2] Opening doors
[D1 13:46:46 elevator_1] At floor 5
[D1 13:46:46 elevator_1] Stopped at floor 5
[D1 13:46:46 elevator_1] Opening doors
[D1 13:46:47 elevator_2] Opened doors
[D1 13:46:47 citizen_147] Left elevator_2, arrived at floor 3
[D1 13:46:49 elevator_1] Opened doors
[D1 13:46:49 citizen_110] Entered elevator_1, going to floor 2
[D1 13:46:49 floor_5] citizen_110 is leaving the queue
[D1 13:46:49 floor_5] citizen_116 was served
[D1 13:46:49 elevator_1] Summoned to floor 5 from floor 5
[D1 13:46:49 citizen_116] Entered elevator_1, going to floor 2
[D1 13:46:49 floor_5] citizen_116 is leaving the queue
[D1 13:46:49 floor_5] The queue is now empty
[D1 13:46:59 elevator_2] Closing doors
[D1 13:47:01 elevator_1] Closing doors
[D1 13:47:02 elevator_2] Closed doors
[D1 13:47:04 elevator_1] Closed doors
[D1 13:47:04 elevator_1] Changing direction to Down
[D1 13:47:12 elevator_2] At floor 4
[D1 13:47:14 elevator_1] At floor 4
[D1 13:47:22 citizen_99] Time to go to floor 3 and stay there for 00:25:36
[D1 13:47:22 floor_4] citizen_99 entered the queue
[D1 13:47:22 floor_4] citizen_99 found an empty queue and will be served immediately
[D1 13:47:22 elevator_1] Summoned to floor 4 from floor 4
[D1 13:47:22 elevator_2] Summoned to floor 4 from floor 4
[D1 13:47:22 elevator_2] At floor 5
[D1 13:47:22 elevator_2] Stopped at floor 5
[D1 13:47:22 elevator_2] Opening doors
[D1 13:47:24 elevator_1] At floor 3
[D1 13:47:25 elevator_2] Opened doors
[D1 13:47:25 citizen_146] Left elevator_2, arrived at floor 5
[D1 13:47:34 elevator_1] At floor 2
[D1 13:47:34 elevator_1] Stopped at floor 2
[D1 13:47:34 elevator_1] Opening doors
[D1 13:47:37 elevator_2] Closing doors
[D1 13:47:37 elevator_1] Opened doors
[D1 13:47:37 citizen_110] Left elevator_1, arrived at floor 2
[D1 13:47:37 citizen_116] Left elevator_1, arrived at floor 2
[D1 13:47:40 elevator_2] Closed doors
[D1 13:47:40 elevator_2] Changing direction to Down
[D1 13:47:49 elevator_1] Closing doors
[D1 13:47:50 elevator_2] At floor 4
[D1 13:47:50 elevator_2] Stopped at floor 4
[D1 13:47:50 elevator_2] Opening doors
[D1 13:47:52 elevator_1] Closed doors
[D1 13:47:53 elevator_2] Opened doors
[D1 13:47:53 citizen_99] Entered elevator_2, going to floor 3
[D1 13:47:53 floor_4] citizen_99 is leaving the queue
[D1 13:47:53 floor_4] The queue is now empty
[D1 13:48:02 elevator_1] At floor 1
[D1 13:48:05 elevator_2] Closing doors
[D1 13:48:08 elevator_2] Closed doors
[D1 13:48:12 elevator_1] At floor 0
[D1 13:48:12 elevator_1] Stopped at floor 0
[D1 13:48:12 elevator_1] Opening doors
[D1 13:48:15 elevator_1] Opened doors
[D1 13:48:18 elevator_2] At floor 3
[D1 13:48:18 elevator_2] Stopped at floor 3
[D1 13:48:18 elevator_2] Opening doors
[D1 13:48:20 citizen_107] Time to go to floor 1 and stay there for 00:23:40
[D1 13:48:20 floor_3] citizen_107 entered the queue
[D1 13:48:20 floor_3] citizen_107 found an empty queue and will be served immediately
[D1 13:48:20 elevator_2] Summoned to floor 3 from floor 3
[D1 13:48:21 elevator_2] Opened doors
[D1 13:48:21 citizen_99] Left elevator_2, arrived at floor 3
[D1 13:48:21 citizen_107] Entered elevator_2, going to floor 1
[D1 13:48:21 floor_3] citizen_107 is leaving the queue
[D1 13:48:21 floor_3] The queue is now empty
[D1 13:48:24 citizen_149] Entered the building, will visit 5 floors in total
[D1 13:48:24 citizen_149] Time to go to floor 3 and stay there for 00:30:57
[D1 13:48:24 floor_0] citizen_149 entered the queue
[D1 13:48:24 floor_0] citizen_149 is queued along with 0 other arrivals in front of it
[D1 13:48:27 elevator_1] Closing doors
[D1 13:48:30 elevator_1] Closed doors
[D1 13:48:30 elevator_1] Changing direction to Up
[D1 13:48:33 elevator_2] Closing doors
[D1 13:48:36 elevator_2] Closed doors
[D1 13:48:40 elevator_1] At floor 1
[D1 13:48:46 elevator_2] At floor 2
[D1 13:48:50 elevator_1] At floor 2
[D1 13:48:56 elevator_2] At floor 1
[D1 13:48:56 elevator_2] Stopped at floor 1
[D1 13:48:56 elevator_2] Opening doors
[D1 13:48:59 elevator_2] Opened doors
[D1 13:48:59 citizen_107] Left elevator_2, arrived at floor 1
[D1 13:49:00 elevator_1] At floor 3
[D1 13:49:10 elevator_1] At floor 4
[D1 13:49:10 elevator_1] Stopped at floor 4
[D1 13:49:10 elevator_1] Opening doors
[D1 13:49:11 elevator_2] Closing doors
[D1 13:49:13 elevator_1] Opened doors
[D1 13:49:14 elevator_2] Closed doors
[D1 13:49:24 elevator_2] At floor 0
[D1 13:49:24 elevator_2] Stopped at floor 0
[D1 13:49:24 elevator_2] Opening doors
[D1 13:49:25 elevator_1] Closing doors
[D1 13:49:27 elevator_2] Opened doors
[D1 13:49:27 citizen_148] Entered elevator_2, going to floor 1
[D1 13:49:27 floor_0] citizen_148 is leaving the queue
[D1 13:49:27 floor_0] citizen_149 was served
[D1 13:49:27 elevator_2] Summoned to floor 0 from floor 0
[D1 13:49:27 citizen_149] Entered elevator_2, going to floor 3
[D1 13:49:27 floor_0] citizen_149 is leaving the queue
[D1 13:49:27 floor_0] The queue is now empty
[D1 13:49:28 elevator_1] Closed doors
[D1 13:49:28 elevator_1] Resting at floor 4
[D1 13:49:39 elevator_2] Closing doors
[D1 13:49:42 citizen_125] Time to go to floor 1 and stay there for 00:25:00
[D1 13:49:42 floor_5] citizen_125 entered the queue
[D1 13:49:42 floor_5] citizen_125 found an empty queue and will be served immediately
[D1 13:49:42 elevator_1] Summoned to floor 5 from floor 4
[D1 13:49:42 elevator_1] Sprung into motion, heading Up
[D1 13:49:42 elevator_2] Closed doors
[D1 13:49:42 elevator_2] Changing direction to Up
[D1 13:49:52 elevator_1] At floor 5
[D1 13:49:52 elevator_1] Stopped at floor 5
[D1 13:49:52 elevator_1] Opening doors
[D1 13:49:52 elevator_2] At floor 1
[D1 13:49:52 elevator_2] Stopped at floor 1
[D1 13:49:52 elevator_2] Opening doors
[D1 13:49:55 elevator_1] Opened doors
[D1 13:49:55 elevator_2] Opened doors
[D1 13:49:55 citizen_148] Left elevator_2, arrived at floor 1
[D1 13:49:55 citizen_125] Entered elevator_1, going to floor 1
[D1 13:49:55 floor_5] citizen_125 is leaving the queue
[D1 13:49:55 floor_5] The queue is now empty
[D1 13:50:01 citizen_121] Time to go to floor 1 and stay there for 00:21:59
[D1 13:50:01 floor_4] citizen_121 entered the queue
[D1 13:50:01 floor_4] citizen_121 found an empty queue and will be served immediately
[D1 13:50:01 elevator_1] Summoned to floor 4 from floor 5
[D1 13:50:07 elevator_1] Closing doors
[D1 13:50:07 elevator_2] Closing doors
[D1 13:50:10 elevator_1] Closed doors
[D1 13:50:10 elevator_2] Closed doors
[D1 13:50:10 elevator_1] Changing direction to Down
[D1 13:50:20 elevator_1] At floor 4
[D1 13:50:20 elevator_1] Stopped at floor 4
[D1 13:50:20 elevator_1] Opening doors
[D1 13:50:20 elevator_2] At floor 2
[D1 13:50:23 elevator_1] Opened doors
[D1 13:50:23 citizen_121] Entered elevator_1, going to floor 1
[D1 13:50:23 floor_4] citizen_121 is leaving the queue
[D1 13:50:23 floor_4] The queue is now empty
[D1 13:50:24 citizen_150] Entered the building, will visit 2 floors in total
[D1 13:50:24 citizen_150] Time to go to floor 1 and stay there for 00:39:33
[D1 13:50:24 floor_0] citizen_150 entered the queue
[D1 13:50:24 floor_0] citizen_150 found an empty queue and will be served immediately
[D1 13:50:24 elevator_2] Summoned to floor 0 from floor 2
[D1 13:50:30 elevator_2] At floor 3
[D1 13:50:30 elevator_2] Stopped at floor 3
[D1 13:50:30 elevator_2] Opening doors
[D1 13:50:33 elevator_2] Opened doors
[D1 13:50:33 citizen_149] Left elevator_2, arrived at floor 3
[D1 13:50:35 elevator_1] Closing doors
[D1 13:50:38 elevator_1] Closed doors
[D1 13:50:45 elevator_2] Closing doors
[D1 13:50:48 elevator_1] At floor 3
[D1 13:50:48 elevator_2] Closed doors
[D1 13:50:48 elevator_2] Changing direction to Down
[D1 13:50:58 elevator_1] At floor 2
[D1 13:50:58 elevator_2] At floor 2
[D1 13:51:08 elevator_1] At floor 1
[D1 13:51:08 elevator_1] Stopped at floor 1
[D1 13:51:08 elevator_1] Opening doors
[D1 13:51:08 elevator_2] At floor 1
[D1 13:51:11 elevator_1] Opened doors
[D1 13:51:11 citizen_125] Left elevator_1, arrived at floor 1
[D1 13:51:11 citizen_121] Left elevator_1, arrived at floor 1
[D1 13:51:18 elevator_2] At floor 0
[D1 13:51:18 elevator_2] Stopped at floor 0
[D1 13:51:18 elevator_2] Opening doors
[D1 13:51:21 elevator_2] Opened doors
[D1 13:51:21 citizen_150] Entered elevator_2, going to floor 1
[D1 13:51:21 floor_0] citizen_150 is leaving the queue
[D1 13:51:21 floor_0] The queue is now empty
[D1 13:51:23 elevator_1] Closing doors
[D1 13:51:26 elevator_1] Closed doors
[D1 13:51:26 elevator_1] Resting at floor 1
[D1 13:51:33 elevator_2] Closing doors
[D1 13:51:35 citizen_151] Entered the building, will visit 3 floors in total
[D1 13:51:35 citizen_151] Time to go to floor 2 and stay there for 00:31:13
[D1 13:51:35 floor_0] citizen_151 entered the queue
[D1 13:51:35 floor_0] citizen_151 found an empty queue and will be served immediately
[D1 13:51:35 elevator_2] Summoned to floor 0 from floor 0
[D1 13:51:36 elevator_2] Reopening doors
[D1 13:51:36 citizen_151] Entered elevator_2, going to floor 2
[D1 13:51:36 floor_0] citizen_151 is leaving the queue
[D1 13:51:36 floor_0] The queue is now empty
[D1 13:51:47 citizen_137] Time to go to floor 5 and stay there for 00:36:41
[D1 13:51:47 floor_3] citizen_137 entered the queue
[D1 13:51:47 floor_3] citizen_137 found an empty queue and will be served immediately
[D1 13:51:47 elevator_1] Summoned to floor 3 from floor 1
[D1 13:51:47 elevator_1] Sprung into motion, heading Up
[D1 13:51:48 elevator_2] Closing doors
[D1 13:51:51 elevator_2] Closed doors
[D1 13:51:51 elevator_2] Changing direction to Up
[D1 13:51:57 elevator_1] At floor 2
[D1 13:52:01 elevator_2] At floor 1
[D1 13:52:01 elevator_2] Stopped at floor 1
[D1 13:52:01 elevator_2] Opening doors
[D1 13:52:04 elevator_2] Opened doors
[D1 13:52:04 citizen_150] Left elevator_2, arrived at floor 1
[D1 13:52:07 elevator_1] At floor 3
[D1 13:52:07 elevator_1] Stopped at floor 3
[D1 13:52:07 elevator_1] Opening doors
[D1 13:52:10 elevator_1] Opened doors
[D1 13:52:10 citizen_137] Entered elevator_1, going to floor 5
[D1 13:52:10 floor_3] citizen_137 is leaving the queue
[D1 13:52:10 floor_3] The queue is now empty
[D1 13:52:16 elevator_2] Closing doors
[D1 13:52:19 elevator_2] Closed doors
[D1 13:52:22 elevator_1] Closing doors
[D1 13:52:25 elevator_1] Closed doors
[D1 13:52:29 elevator_2] At floor 2
[D1 13:52:29 elevator_2] Stopped at floor 2
[D1 13:52:29 elevator_2] Opening doors
[D1 13:52:30 citizen_109] Time to go to floor 3 and stay there for 00:33:23
[D1 13:52:30 floor_5] citizen_109 entered the queue
[D1 13:52:30 floor_5] citizen_109 found an empty queue and will be served immediately
[D1 13:52:30 elevator_1] Summoned to floor 5 from floor 3
[D1 13:52:32 elevator_2] Opened doors
[D1 13:52:32 citizen_151] Left elevator_2, arrived at floor 2
[D1 13:52:34 citizen_120] Time to go to floor 4 and stay there for 00:32:42
[D1 13:52:34 floor_3] citizen_120 entered the queue
[D1 13:52:34 floor_3] citizen_120 found an empty queue and will be served immediately
[D1 13:52:34 elevator_1] Summoned to floor 3 from floor 3
[D1 13:52:35 elevator_1] At floor 4
[D1 13:52:44 elevator_2] Closing doors
[D1 13:52:45 elevator_1] At floor 5
[D1 13:52:45 elevator_1] Stopped at floor 5
[D1 13:52:45 elevator_1] Opening doors
[D1 13:52:47 elevator_2] Closed doors
[D1 13:52:47 elevator_2] Resting at floor 2
[D1 13:52:48 elevator_1] Opened doors
[D1 13:52:48 citizen_137] Left elevator_1, arrived at floor 5
[D1 13:52:48 citizen_109] Entered elevator_1, going to floor 3
[D1 13:52:48 floor_5] citizen_109 is leaving the queue
[D1 13:52:48 floor_5] The queue is now empty
[D1 13:53:00 elevator_1] Closing doors
[D1 13:53:03 elevator_1] Closed doors
[D1 13:53:03 elevator_1] Changing direction to Down
[D1 13:53:13 elevator_1] At floor 4
[D1 13:53:19 citizen_152] Entered the building, will visit 5 floors in total
[D1 13:53:19 citizen_152] Time to go to floor 5 and stay there for 00:35:08
[D1 13:53:19 floor_0] citizen_152 entered the queue
[D1 13:53:19 floor_0] citizen_152 found an empty queue and will be served immediately
[D1 13:53:19 elevator_2] Summoned to floor 0 from floor 2
[D1 13:53:19 elevator_2] Sprung into motion, heading Down
[D1 13:53:23 elevator_1] At floor 3
[D1 13:53:23 elevator_1] Stopped at floor 3
[D1 13:53:23 elevator_1] Opening doors
[D1 13:53:26 elevator_1] Opened doors
[D1 13:53:26 citizen_109] Left elevator_1, arrived at floor 3
[D1 13:53:26 citizen_120] Entered elevator_1, going to floor 4
[D1 13:53:26 floor_3] citizen_120 is leaving the queue
[D1 13:53:26 floor_3] The queue is now empty
[D1 13:53:29 elevator_2] At floor 1
[D1 13:53:30 citizen_131] Time to go to floor 3 and stay there for 00:24:02
[D1 13:53:30 floor_5] citizen_131 entered the queue
[D1 13:53:30 floor_5] citizen_131 found an empty queue and will be served immediately
[D1 13:53:30 elevator_1] Summoned to floor 5 from floor 3
[D1 13:53:38 elevator_1] Closing doors
[D1 13:53:39 elevator_2] At floor 0
[D1 13:53:39 elevator_2] Stopped at floor 0
[D1 13:53:39 elevator_2] Opening doors
[D1 13:53:41 citizen_104] Time to go to floor 4 and stay there for 00:35:26
[D1 13:53:41 floor_5] citizen_104 entered the queue
[D1 13:53:41 floor_5] citizen_104 is queued along with 0 other arrivals in front of it
[D1 13:53:41 elevator_1] Closed doors
[D1 13:53:41 elevator_1] Changing direction to Up
[D1 13:53:42 elevator_2] Opened doors
[D1 13:53:42 citizen_152] Entered elevator_2, going to floor 5
[D1 13:53:42 floor_0] citizen_152 is leaving the queue
[D1 13:53:42 floor_0] The queue is now empty
[D1 13:53:51 elevator_1] At floor 4
[D1 13:53:51 elevator_1] Stopped at floor 4
[D1 13:53:51 elevator_1] Opening doors
[D1 13:53:54 elevator_2] Closing doors
[D1 13:53:54 elevator_1] Opened doors
[D1 13:53:54 citizen_120] Left elevator_1, arrived at floor 4
[D1 13:53:57 elevator_2] Closed doors
[D1 13:53:57 elevator_2] Changing direction to Up
[D1 13:54:06 elevator_1] Closing doors
[D1 13:54:07 elevator_2] At floor 1
[D1 13:54:09 elevator_1] Closed doors
[D1 13:54:17 citizen_136] Time to go to floor 4 and stay there for 00:28:46
[D1 13:54:17 floor_5] citizen_136 entered the queue
[D1 13:54:17 floor_5] citizen_136 is queued along with 1 other arrivals in front of it
[D1 13:54:17 elevator_2] At floor 2
[D1 13:54:19 elevator_1] At floor 5
[D1 13:54:19 elevator_1] Stopped at floor 5
[D1 13:54:19 elevator_1] Opening doors
[D1 13:54:22 elevator_1] Opened doors
[D1 13:54:22 citizen_131] Entered elevator_1, going to floor 3
[D1 13:54:22 floor_5] citizen_131 is leaving the queue
[D1 13:54:22 floor_5] citizen_104 was served
[D1 13:54:22 elevator_1] Summoned to floor 5 from floor 5
[D1 13:54:22 citizen_104] Entered elevator_1, going to floor 4
[D1 13:54:22 floor_5] citizen_104 is leaving the queue
[D1 13:54:22 floor_5] citizen_136 was served
[D1 13:54:22 elevator_1] Summoned to floor 5 from floor 5
[D1 13:54:22 citizen_136] Entered elevator_1, going to floor 4
[D1 13:54:22 floor_5] citizen_136 is leaving the queue
[D1 13:54:22 floor_5] The queue is now empty
[D1 13:54:27 elevator_2] At floor 3
[D1 13:54:32 citizen_128] Time to go to floor 3 and stay there for 00:30:16
[D1 13:54:32 floor_4] citizen_128 entered the queue
[D1 13:54:32 floor_4] citizen_128 found an empty queue and will be served immediately
[D1 13:54:32 elevator_1] Summoned to floor 4 from floor 5
[D1 13:54:32 elevator_2] Summoned to floor 4 from floor 3
[D1 13:54:34 elevator_1] Closing doors
[D1 13:54:37 elevator_2] At floor 4
[D1 13:54:37 elevator_2] Stopped at floor 4
[D1 13:54:37 elevator_2] Opening doors
[D1 13:54:37 elevator_1] Closed doors
[D1 13:54:37 elevator_1] Changing direction to Down
[D1 13:54:40 elevator_2] Opened doors
[D1 13:54:40 citizen_128] Entered elevator_2, going to floor 3
[D1 13:54:40 floor_4] citizen_128 is leaving the queue
[D1 13:54:40 floor_4] The queue is now empty
[D1 13:54:46 citizen_153] Entered the building, will visit 4 floors in total
[D1 13:54:46 citizen_153] Time to go to floor 4 and stay there for 00:33:38
[D1 13:54:46 floor_0] citizen_153 entered the queue
[D1 13:54:46 floor_0] citizen_153 found an empty queue and will be served immediately
[D1 13:54:46 elevator_2] Summoned to floor 0 from floor 4
[D1 13:54:47 elevator_1] At floor 4
[D1 13:54:47 elevator_1] Stopped at floor 4
[D1 13:54:47 elevator_1] Opening doors
[D1 13:54:50 elevator_1] Opened doors
[D1 13:54:50 citizen_104] Left elevator_1, arrived at floor 4
[D1 13:54:50 citizen_136] Left elevator_1, arrived at floor 4
[D1 13:54:52 elevator_2] Closing doors
[D1 13:54:55 elevator_2] Closed doors
[D1 13:55:02 elevator_1] Closing doors
[D1 13:55:05 elevator_2] At floor 5
[D1 13:55:05 elevator_2] Stopped at floor 5
[D1 13:55:05 elevator_2] Opening doors
[D1 13:55:05 elevator_1] Closed doors
[D1 13:55:08 elevator_2] Opened doors
[D1 13:55:08 citizen_152] Left elevator_2, arrived at floor 5
[D1 13:55:15 elevator_1] At floor 3
[D1 13:55:15 elevator_1] Stopped at floor 3
[D1 13:55:15 elevator_1] Opening doors
[D1 13:55:18 elevator_1] Opened doors
[D1 13:55:18 citizen_131] Left elevator_1, arrived at floor 3
[D1 13:55:20 citizen_139] Time to go to floor 3 and stay there for 00:43:58
[D1 13:55:20 floor_5] citizen_139 entered the queue
[D1 13:55:20 floor_5] citizen_139 found an empty queue and will be served immediately
[D1 13:55:20 elevator_2] Summoned to floor 5 from floor 5
[D1 13:55:20 citizen_139] Entered elevator_2, going to floor 3
[D1 13:55:20 floor_5] citizen_139 is leaving the queue
[D1 13:55:20 floor_5] The queue is now empty
[D1 13:55:20 elevator_2] Closing doors
[D1 13:55:23 elevator_2] Closed doors
[D1 13:55:23 elevator_2] Changing direction to Down
[D1 13:55:29 citizen_106] Time to go to floor 3 and stay there for 00:21:10
[D1 13:55:29 floor_4] citizen_106 entered the queue
[D1 13:55:29 floor_4] citizen_106 found an empty queue and will be served immediately
[D1 13:55:29 elevator_1] Summoned to floor 4 from floor 3
[D1 13:55:29 elevator_2] Summoned to floor 4 from floor 5
[D1 13:55:30 elevator_1] Closing doors
[D1 13:55:33 elevator_2] At floor 4
[D1 13:55:33 elevator_2] Stopped at floor 4
[D1 13:55:33 elevator_2] Opening doors
[D1 13:55:33 elevator_1] Closed doors
[D1 13:55:33 elevator_1] Changing direction to Up
[D1 13:55:36 elevator_2] Opened doors
[D1 13:55:36 citizen_106] Entered elevator_2, going to floor 3
[D1 13:55:36 floor_4] citizen_106 is leaving the queue
[D1 13:55:36 floor_4] The queue is now empty
[D1 13:55:43 elevator_1] At floor 4
[D1 13:55:43 elevator_1] Stopped at floor 4
[D1 13:55:43 elevator_1] Opening doors
[D1 13:55:46 elevator_1] Opened doors
[D1 13:55:48 elevator_2] Closing doors
[D1 13:55:51 elevator_2] Closed doors
[D1 13:55:58 elevator_1] Closing doors
[D1 13:56:00 citizen_135] Time to go to floor 2 and stay there for 00:32:15
[D1 13:56:00 floor_4] citizen_135 entered the queue
[D1 13:56:00 floor_4] citizen_135 found an empty queue and will be served immediately
[D1 13:56:00 elevator_1] Summoned to floor 4 from floor 4
[D1 13:56:00 elevator_2] Summoned to floor 4 from floor 4
[D1 13:56:01 elevator_2] At floor 3
[D1 13:56:01 elevator_2] Stopped at floor 3
[D1 13:56:01 elevator_2] Opening doors
[D1 13:56:01 elevator_1] Reopening doors
[D1 13:56:01 citizen_135] Entered elevator_1, going to floor 2
[D1 13:56:01 floor_4] citizen_135 is leaving the queue
[D1 13:56:01 floor_4] The queue is now empty
[D1 13:56:04 elevator_2] Opened doors
[D1 13:56:04 citizen_128] Left elevator_2, arrived at floor 3
[D1 13:56:04 citizen_139] Left elevator_2, arrived at floor 3
[D1 13:56:04 citizen_106] Left elevator_2, arrived at floor 3
[D1 13:56:13 elevator_1] Closing doors
[D1 13:56:16 elevator_2] Closing doors
[D1 13:56:16 elevator_1] Closed doors
[D1 13:56:16 elevator_1] Changing direction to Down
[D1 13:56:19 elevator_2] Closed doors
[D1 13:56:26 elevator_1] At floor 3
[D1 13:56:29 elevator_2] At floor 2
[D1 13:56:36 elevator_1] At floor 2
[D1 13:56:36 elevator_1] Stopped at floor 2
[D1 13:56:36 elevator_1] Opening doors
[D1 13:56:38 citizen_93] Time to go to the ground floor and leave
[D1 13:56:38 floor_2] citizen_93 entered the queue
[D1 13:56:38 floor_2] citizen_93 found an empty queue and will be served immediately
[D1 13:56:38 elevator_1] Summoned to floor 2 from floor 2
[D1 13:56:38 elevator_2] Summoned to floor 2 from floor 2
[D1 13:56:39 elevator_2] At floor 1
[D1 13:56:39 elevator_1] Opened doors
[D1 13:56:39 citizen_135] Left elevator_1, arrived at floor 2
[D1 13:56:39 citizen_93] Entered elevator_1, going to floor 0
[D1 13:56:39 floor_2] citizen_93 is leaving the queue
[D1 13:56:39 floor_2] The queue is now empty
[D1 13:56:49 elevator_2] At floor 0
[D1 13:56:49 elevator_2] Stopped at floor 0
[D1 13:56:49 elevator_2] Opening doors
[D1 13:56:51 elevator_1] Closing doors
[D1 13:56:52 elevator_2] Opened doors
[D1 13:56:52 citizen_153] Entered elevator_2, going to floor 4
[D1 13:56:52 floor_0] citizen_153 is leaving the queue
[D1 13:56:52 floor_0] The queue is now empty
[D1 13:56:54 elevator_1] Closed doors
[D1 13:57:04 elevator_2] Closing doors
[D1 13:57:04 elevator_1] At floor 1
[D1 13:57:07 elevator_2] Closed doors
[D1 13:57:07 elevator_2] Changing direction to Up
[D1 13:57:14 elevator_1] At floor 0
[D1 13:57:14 elevator_1] Stopped at floor 0
[D1 13:57:14 elevator_1] Opening doors
[D1 13:57:17 elevator_2] At floor 1
[D1 13:57:17 elevator_1] Opened doors
[D1 13:57:17 citizen_93] Left elevator_1, arrived at floor 0
[D1 13:57:17 citizen_93] Left the building
[D1 13:57:27 elevator_2] At floor 2
[D1 13:57:27 elevator_2] Stopped at floor 2
[D1 13:57:27 elevator_2] Opening doors
[D1 13:57:29 elevator_1] Closing doors
[D1 13:57:30 elevator_2] Opened doors
[D1 13:57:32 citizen_154] Entered the building, will visit 4 floors in total
[D1 13:57:32 citizen_154] Time to go to floor 4 and stay there for 00:25:56
[D1 13:57:32 floor_0] citizen_154 entered the queue
[D1 13:57:32 floor_0] citizen_154 found an empty queue and will be served immediately
[D1 13:57:32 elevator_1] Summoned to floor 0 from floor 0
[D1 13:57:32 citizen_132] Time to go to floor 3 and stay there for 00:28:32
[D1 13:57:32 floor_4] citizen_132 entered the queue
[D1 13:57:32 floor_4] citizen_132 found an empty queue and will be served immediately
[D1 13:57:32 elevator_2] Summoned to floor 4 from floor 2
[D1 13:57:32 elevator_1] Reopening doors
[D1 13:57:32 citizen_154] Entered elevator_1, going to floor 4
[D1 13:57:32 floor_0] citizen_154 is leaving the queue
[D1 13:57:32 floor_0] The queue is now empty
[D1 13:57:42 elevator_2] Closing doors
[D1 13:57:44 elevator_1] Closing doors
[D1 13:57:45 elevator_2] Closed doors
[D1 13:57:47 elevator_1] Closed doors
[D1 13:57:47 elevator_1] Changing direction to Up
[D1 13:57:55 elevator_2] At floor 3
[D1 13:57:57 elevator_1] At floor 1
[D1 13:58:05 elevator_2] At floor 4
[D1 13:58:05 elevator_2] Stopped at floor 4
[D1 13:58:05 elevator_2] Opening doors
[D1 13:58:07 elevator_1] At floor 2
[D1 13:58:08 elevator_2] Opened doors
[D1 13:58:08 citizen_153] Left elevator_2, arrived at floor 4
[D1 13:58:08 citizen_132] Entered elevator_2, going to floor 3
[D1 13:58:08 floor_4] citizen_132 is leaving the queue
[D1 13:58:08 floor_4] The queue is now empty
[D1 13:58:13 citizen_138] Time to go to floor 1 and stay there for 00:38:26
[D1 13:58:13 floor_3] citizen_138 entered the queue
[D1 13:58:13 floor_3] citizen_138 found an empty queue and will be served immediately
[D1 13:58:13 elevator_1] Summoned to floor 3 from floor 2
[D1 13:58:13 elevator_2] Summoned to floor 3 from floor 4
[D1 13:58:17 elevator_1] At floor 3
[D1 13:58:17 elevator_1] Stopped at floor 3
[D1 13:58:17 elevator_1] Opening doors
[D1 13:58:20 elevator_2] Closing doors
[D1 13:58:20 elevator_1] Opened doors
[D1 13:58:20 citizen_138] Entered elevator_1, going to floor 1
[D1 13:58:20 floor_3] citizen_138 is leaving the queue
[D1 13:58:20 floor_3] The queue is now empty
[D1 13:58:23 elevator_2] Closed doors
[D1 13:58:23 elevator_2] Changing direction to Down
[D1 13:58:32 elevator_1] Closing doors
[D1 13:58:33 elevator_2] At floor 3
[D1 13:58:33 elevator_2] Stopped at floor 3
[D1 13:58:33 elevator_2] Opening doors
[D1 13:58:35 elevator_1] Closed doors
[D1 13:58:36 elevator_2] Opened doors
[D1 13:58:36 citizen_132] Left elevator_2, arrived at floor 3
[D1 13:58:43 citizen_126] Time to go to floor 5 and stay there for 00:18:47
[D1 13:58:43 floor_3] citizen_126 entered the queue
[D1 13:58:43 floor_3] citizen_126 found an empty queue and will be served immediately
[D1 13:58:43 elevator_1] Summoned to floor 3 from floor 3
[D1 13:58:43 elevator_2] Summoned to floor 3 from floor 3
[D1 13:58:43 citizen_126] Entered elevator_2, going to floor 5
[D1 13:58:43 floor_3] citizen_126 is leaving the queue
[D1 13:58:43 floor_3] The queue is now empty
[D1 13:58:45 elevator_1] At floor 4
[D1 13:58:45 elevator_1] Stopped at floor 4
[D1 13:58:45 elevator_1] Opening doors
[D1 13:58:48 elevator_2] Closing doors
[D1 13:58:48 elevator_1] Opened doors
[D1 13:58:48 citizen_154] Left elevator_1, arrived at floor 4
[D1 13:58:51 elevator_2] Closed doors
[D1 13:58:51 elevator_2] Changing direction to Up
[D1 13:59:00 elevator_1] Closing doors
[D1 13:59:01 elevator_2] At floor 4
[D1 13:59:03 elevator_1] Closed doors
[D1 13:59:03 elevator_1] Changing direction to Down
[D1 13:59:11 elevator_2] At floor 5
[D1 13:59:11 elevator_2] Stopped at floor 5
[D1 13:59:11 elevator_2] Opening doors
[D1 13:59:13 elevator_1] At floor 3
[D1 13:59:13 elevator_1] Stopped at floor 3
[D1 13:59:13 elevator_1] Opening doors
[D1 13:59:14 elevator_2] Opened doors
[D1 13:59:14 citizen_126] Left elevator_2, arrived at floor 5
[D1 13:59:16 elevator_1] Opened doors
[D1 13:59:26 elevator_2] Closing doors
[D1 13:59:28 elevator_1] Closing doors
[D1 13:59:29 elevator_2] Closed doors
[D1 13:59:29 elevator_2] Resting at floor 5
[D1 13:59:31 elevator_1] Closed doors
[D1 13:59:41 elevator_1] At floor 2
[D1 13:59:51 elevator_1] At floor 1
[D1 13:59:51 elevator_1] Stopped at floor 1
[D1 13:59:51 elevator_1] Opening doors
[D1 13:59:54 elevator_1] Opened doors
[D1 13:59:54 citizen_138] Left elevator_1, arrived at floor 1
[D1 14:00:06 citizen_98] Time to go to floor 4 and stay there for 00:21:17
[D1 14:00:06 floor_5] citizen_98 entered the queue
[D1 14:00:06 floor_5] citizen_98 found an empty queue and will be served immediately
[D1 14:00:06 elevator_2] Summoned to floor 5 from floor 5
[D1 14:00:06 elevator_2] Opening doors
[D1 14:00:06 elevator_1] Closing doors
[D1 14:00:09 elevator_2] Opened doors
[D1 14:00:09 elevator_1] Closed doors
[D1 14:00:09 elevator_1] Resting at floor 1
[D1 14:00:09 citizen_98] Entered elevator_2, going to floor 4
[D1 14:00:09 floor_5] citizen_98 is leaving the queue
[D1 14:00:09 floor_5] The queue is now empty
[D1 14:00:18 citizen_122] Time to go to floor 1 and stay there for 00:25:49
[D1 14:00:18 floor_3] citizen_122 entered the queue
[D1 14:00:18 floor_3] citizen_122 found an empty queue and will be served immediately
[D1 14:00:18 elevator_1] Summoned to floor 3 from floor 1
[D1 14:00:18 elevator_1] Sprung into motion, heading Up
[D1 14:00:18 elevator_2] Summoned to floor 3 from floor 5
[D1 14:00:21 elevator_2] Closing doors
[D1 14:00:24 elevator_2] Closed doors
[D1 14:00:24 elevator_2] Sprung into motion, heading Down
[D1 14:00:28 elevator_1] At floor 2
[D1 14:00:34 elevator_2] At floor 4
[D1 14:00:34 elevator_2] Stopped at floor 4
[D1 14:00:34 elevator_2] Opening doors
[D1 14:00:37 elevator_2] Opened doors
[D1 14:00:37 citizen_98] Left elevator_2, arrived at floor 4
[D1 14:00:38 citizen_155] Entered the building, will visit 5 floors in total
[D1 14:00:38 citizen_155] Time to go to floor 2 and stay there for 00:32:35
[D1 14:00:38 floor_0] citizen_155 entered the queue
[D1 14:00:38 floor_0] citizen_155 found an empty queue and will be served immediately
[D1 14:00:38 elevator_1] Summoned to floor 0 from floor 2
[D1 14:00:38 elevator_1] At floor 3
[D1 14:00:38 elevator_1] Stopped at floor 3
[D1 14:00:38 elevator_1] Opening doors
[D1 14:00:41 elevator_1] Opened doors
[D1 14:00:41 citizen_122] Entered elevator_1, going to floor 1
[D1 14:00:41 floor_3] citizen_122 is leaving the queue
[D1 14:00:41 floor_3] The queue is now empty
[D1 14:00:44 citizen_123] Time to go to floor 1 and stay there for 00:34:10
[D1 14:00:44 floor_4] citizen_123 entered the queue
[D1 14:00:44 floor_4] citizen_123 found an empty queue and will be served immediately
[D1 14:00:44 elevator_2] Summoned to floor 4 from floor 4
[D1 14:00:44 citizen_123] Entered elevator_2, going to floor 1
[D1 14:00:44 floor_4] citizen_123 is leaving the queue
[D1 14:00:44 floor_4] The queue is now empty
[D1 14:00:49 elevator_2] Closing doors
[D1 14:00:51 citizen_102] Time to go to floor 5 and stay there for 00:29:51
[D1 14:00:51 floor_4] citizen_102 entered the queue
[D1 14:00:51 floor_4] citizen_102 found an empty queue and will be served immediately
[D1 14:00:51 elevator_2] Summoned to floor 4 from floor 4
[D1 14:00:52 elevator_2] Reopening doors
[D1 14:00:52 citizen_102] Entered elevator_2, going to floor 5
[D1 14:00:52 floor_4] citizen_102 is leaving the queue
[D1 14:00:52 floor_4] The queue is now empty
[D1 14:00:53 elevator_1] Closing doors
[D1 14:00:56 elevator_1] Closed doors
[D1 14:00:56 elevator_1] Changing direction to Down
[D1 14:01:04 elevator_2] Closing doors
[D1 14:01:06 elevator_1] At floor 2
[D1 14:01:07 elevator_2] Closed doors
[D1 14:01:16 elevator_1] At floor 1
[D1 14:01:16 elevator_1] Stopped at floor 1
[D1 14:01:16 elevator_1] Opening doors
[D1 14:01:17 elevator_2] At floor 3
[D1 14:01:17 elevator_2] Stopped at floor 3
[D1 14:01:17 elevator_2] Opening doors
[D1 14:01:19 elevator_1] Opened doors
[D1 14:01:19 citizen_122] Left elevator_1, arrived at floor 1
[D1 14:01:20 elevator_2] Opened doors
[D1 14:01:31 elevator_1] Closing doors
[D1 14:01:32 elevator_2] Closing doors
[D1 14:01:34 elevator_1] Closed doors
[D1 14:01:35 elevator_2] Closed doors
[D1 14:01:44 elevator_1] At floor 0
[D1 14:01:44 elevator_1] Stopped at floor 0
[D1 14:01:44 elevator_1] Opening doors
[D1 14:01:45 elevator_2] At floor 2
[D1 14:01:47 elevator_1] Opened doors
[D1 14:01:47 citizen_155] Entered elevator_1, going to floor 2
[D1 14:01:47 floor_0] citizen_155 is leaving the queue
[D1 14:01:47 floor_0] The queue is now empty
[D1 14:01:55 citizen_156] Entered the building, will visit 4 floors in total
[D1 14:01:55 citizen_156] Time to go to floor 4 and stay there for 00:32:03
[D1 14:01:55 floor_0] citizen_156 entered the queue
[D1 14:01:55 floor_0] citizen_156 found an empty queue and will be served immediately
[D1 14:01:55 elevator_1] Summoned to floor 0 from floor 0
[D1 14:01:55 citizen_156] Entered elevator_1, going to floor 4
[D1 14:01:55 floor_0] citizen_156 is leaving the queue
[D1 14:01:55 floor_0] The queue is now empty
[D1 14:01:55 elevator_2] At floor 1
[D1 14:01:55 elevator_2] Stopped at floor 1
[D1 14:01:55 elevator_2] Opening doors
[D1 14:01:56 citizen_124] Time to go to floor 5 and stay there for 00:24:19
[D1 14:01:56 floor_2] citizen_124 entered the queue
[D1 14:01:56 floor_2] citizen_124 found an empty queue and will be served immediately
[D1 14:01:56 elevator_2] Summoned to floor 2 from floor 1
[D1 14:01:58 elevator_2] Opened doors
[D1 14:01:58 citizen_123] Left elevator_2, arrived at floor 1
[D1 14:01:59 elevator_1] Closing doors
[D1 14:02:02 elevator_1] Closed doors
[D1 14:02:02 elevator_1] Changing direction to Up
[D1 14:02:10 elevator_2] Closing doors
[D1 14:02:12 elevator_1] At floor 1
[D1 14:02:13 elevator_2] Closed doors
[D1 14:02:13 elevator_2] Changing direction to Up
[D1 14:02:18 citizen_115] Time to go to the ground floor and leave
[D1 14:02:18 floor_1] citizen_115 entered the queue
[D1 14:02:18 floor_1] citizen_115 found an empty queue and will be served immediately
[D1 14:02:18 elevator_1] Summoned to floor 1 from floor 1
[D1 14:02:18 elevator_2] Summoned to floor 1 from floor 1
[D1 14:02:22 elevator_1] At floor 2
[D1 14:02:22 elevator_1] Stopped at floor 2
[D1 14:02:22 elevator_1] Opening doors
[D1 14:02:23 elevator_2] At floor 2
[D1 14:02:23 elevator_2] Stopped at floor 2
[D1 14:02:23 elevator_2] Opening doors
[D1 14:02:25 elevator_1] Opened doors
[D1 14:02:25 citizen_155] Left elevator_1, arrived at floor 2
[D1 14:02:26 elevator_2] Opened doors
[D1 14:02:26 citizen_124] Entered elevator_2, going to floor 5
[D1 14:02:26 floor_2] citizen_124 is leaving the queue
[D1 14:02:26 floor_2] The queue is now empty
[D1 14:02:37 elevator_1] Closing doors
[D1 14:02:38 elevator_2] Closing doors
[D1 14:02:40 elevator_1] Closed doors
[D1 14:02:41 elevator_2] Closed doors
[D1 14:02:45 citizen_80] Time to go to the ground floor and leave
[D1 14:02:45 floor_1] citizen_80 entered the queue
[D1 14:02:45 floor_1] citizen_80 is queued along with 0 other arrivals in front of it
[D1 14:02:46 citizen_129] Time to go to floor 5 and stay there for 00:30:08
[D1 14:02:46 floor_2] citizen_129 entered the queue
[D1 14:02:46 floor_2] citizen_129 found an empty queue and will be served immediately
[D1 14:02:46 elevator_1] Summoned to floor 2 from floor 2
[D1 14:02:46 elevator_2] Summoned to floor 2 from floor 2
[D1 14:02:49 citizen_134] Time to go to floor 3 and stay there for 00:34:15
[D1 14:02:49 floor_5] citizen_134 entered the queue
[D1 14:02:49 floor_5] citizen_134 found an empty queue and will be served immediately
[D1 14:02:49 elevator_1] Summoned to floor 5 from floor 2
[D1 14:02:49 elevator_2] Summoned to floor 5 from floor 2
[D1 14:02:50 citizen_141] Time to go to floor 5 and stay there for 00:25:25
[D1 14:02:50 floor_4] citizen_141 entered the queue
[D1 14:02:50 floor_4] citizen_141 found an empty queue and will be served immediately
[D1 14:02:50 elevator_1] Summoned to floor 4 from floor 2
[D1 14:02:50 elevator_2] Summoned to floor 4 from floor 2
[D1 14:02:50 elevator_1] At floor 3
[D1 14:02:51 elevator_2] At floor 3
[D1 14:03:00 elevator_1] At floor 4
[D1 14:03:00 elevator_1] Stopped at floor 4
[D1 14:03:00 elevator_1] Opening doors
[D1 14:03:01 elevator_2] At floor 4
[D1 14:03:01 elevator_2] Stopped at floor 4
[D1 14:03:01 elevator_2] Opening doors
[D1 14:03:03 elevator_1] Opened doors
[D1 14:03:03 citizen_156] Left elevator_1, arrived at floor 4
[D1 14:03:03 citizen_141] Entered elevator_1, going to floor 5
[D1 14:03:03 floor_4] citizen_141 is leaving the queue
[D1 14:03:03 floor_4] The queue is now empty
[D1 14:03:04 elevator_2] Opened doors
[D1 14:03:07 citizen_157] Entered the building, will visit 4 floors in total
[D1 14:03:07 citizen_157] Time to go to floor 4 and stay there for 00:34:38
[D1 14:03:07 floor_0] citizen_157 entered the queue
[D1 14:03:07 floor_0] citizen_157 found an empty queue and will be served immediately
[D1 14:03:07 elevator_1] Summoned to floor 0 from floor 4
[D1 14:03:07 elevator_2] Summoned to floor 0 from floor 4
[D1 14:03:15 elevator_1] Closing doors
[D1 14:03:15 citizen_147] Time to go to floor 1 and stay there for 00:37:25
[D1 14:03:15 floor_3] citizen_147 entered the queue
[D1 14:03:15 floor_3] citizen_147 found an empty queue and will be served immediately
[D1 14:03:15 elevator_1] Summoned to floor 3 from floor 4
[D1 14:03:15 elevator_2] Summoned to floor 3 from floor 4
[D1 14:03:16 elevator_2] Closing doors
[D1 14:03:18 elevator_1] Closed doors
[D1 14:03:19 elevator_2] Closed doors
[D1 14:03:28 elevator_1] At floor 5
[D1 14:03:28 elevator_1] Stopped at floor 5
[D1 14:03:28 elevator_1] Opening doors
[D1 14:03:29 elevator_2] At floor 5
[D1 14:03:29 elevator_2] Stopped at floor 5
[D1 14:03:29 elevator_2] Opening doors
[D1 14:03:31 elevator_1] Opened doors
[D1 14:03:31 citizen_141] Left elevator_1, arrived at floor 5
[D1 14:03:31 citizen_134] Entered elevator_1, going to floor 3
[D1 14:03:31 floor_5] citizen_134 is leaving the queue
[D1 14:03:31 floor_5] The queue is now empty
[D1 14:03:32 elevator_2] Opened doors
[D1 14:03:32 citizen_102] Left elevator_2, arrived at floor 5
[D1 14:03:32 citizen_124] Left elevator_2, arrived at floor 5
[D1 14:03:43 elevator_1] Closing doors
[D1 14:03:43 citizen_142] Time to go to floor 3 and stay there for 00:36:54
[D1 14:03:43 floor_4] citizen_142 entered the queue
[D1 14:03:43 floor_4] citizen_142 found an empty queue and will be served immediately
[D1 14:03:43 elevator_1] Summoned to floor 4 from floor 5
[D1 14:03:43 elevator_2] Summoned to floor 4 from floor 5
[D1 14:03:44 elevator_2] Closing doors
[D1 14:03:46 elevator_1] Closed doors
[D1 14:03:46 elevator_1] Changing direction to Down
[D1 14:03:47 elevator_2] Closed doors
[D1 14:03:47 elevator_2] Changing direction to Down
[D1 14:03:55 citizen_88] Time to go to the ground floor and leave
[D1 14:03:55 floor_4] citizen_88 entered the queue
[D1 14:03:55 floor_4] citizen_88 is queued along with 0 other arrivals in front of it
[D1 14:03:56 elevator_1] At floor 4
[D1 14:03:56 elevator_1] Stopped at floor 4
[D1 14:03:56 elevator_1] Opening doors
[D1 14:03:57 elevator_2] At floor 4
[D1 14:03:57 elevator_2] Stopped at floor 4
[D1 14:03:57 elevator_2] Opening doors
[D1 14:03:59 elevator_1] Opened doors
[D1 14:03:59 citizen_142] Entered elevator_1, going to floor 3
[D1 14:03:59 floor_4] citizen_142 is leaving the queue
[D1 14:03:59 floor_4] citizen_88 was served
[D1 14:03:59 elevator_1] Summoned to floor 4 from floor 4
[D1 14:03:59 elevator_2] Summoned to floor 4 from floor 4
[D1 14:03:59 citizen_88] Entered elevator_1, going to floor 0
[D1 14:03:59 floor_4] citizen_88 is leaving the queue
[D1 14:03:59 floor_4] The queue is now empty
[D1 14:04:00 elevator_2] Opened doors
[D1 14:04:11 elevator_1] Closing doors
[D1 14:04:12 elevator_2] Closing doors
[D1 14:04:14 elevator_1] Closed doors
[D1 14:04:15 elevator_2] Closed doors
[D1 14:04:24 elevator_1] At floor 3
[D1 14:04:24 elevator_1] Stopped at floor 3
[D1 14:04:24 elevator_1] Opening doors
[D1 14:04:25 elevator_2] At floor 3
[D1 14:04:25 elevator_2] Stopped at floor 3
[D1 14:04:25 elevator_2] Opening doors
[D1 14:04:27 elevator_1] Opened doors
[D1 14:04:27 citizen_134] Left elevator_1, arrived at floor 3
[D1 14:04:27 citizen_142] Left elevator_1, arrived at floor 3
[D1 14:04:27 citizen_147] Entered elevator_1, going to floor 1
[D1 14:04:27 floor_3] citizen_147 is leaving the queue
[D1 14:04:27 floor_3] The queue is now empty
[D1 14:04:28 elevator_2] Opened doors
[D1 14:04:39 elevator_1] Closing doors
[D1 14:04:40 elevator_2] Closing doors
[D1 14:04:42 elevator_1] Closed doors
[D1 14:04:43 elevator_2] Closed doors
[D1 14:04:52 elevator_1] At floor 2
[D1 14:04:52 elevator_1] Stopped at floor 2
[D1 14:04:52 elevator_1] Opening doors
[D1 14:04:53 elevator_2] At floor 2
[D1 14:04:53 elevator_2] Stopped at floor 2
[D1 14:04:53 elevator_2] Opening doors
[D1 14:04:55 elevator_1] Opened doors
[D1 14:04:55 citizen_129] Entered elevator_1, going to floor 5
[D1 14:04:55 floor_2] citizen_129 is leaving the queue
[D1 14:04:55 floor_2] The queue is now empty
[D1 14:04:56 elevator_2] Opened doors
[D1 14:05:07 elevator_1] Closing doors
[D1 14:05:08 elevator_2] Closing doors
[D1 14:05:09 citizen_143] Time to go to floor 2 and stay there for 00:29:58
[D1 14:05:09 floor_3] citizen_143 entered the queue
[D1 14:05:09 floor_3] citizen_143 found an empty queue and will be served immediately
[D1 14:05:09 elevator_1] Summoned to floor 3 from floor 2
[D1 14:05:09 elevator_2] Summoned to floor 3 from floor 2
[D1 14:05:10 elevator_1] Closed doors
[D1 14:05:11 elevator_2] Closed doors
[D1 14:05:20 elevator_1] At floor 1
[D1 14:05:20 elevator_1] Stopped at floor 1
[D1 14:05:20 elevator_1] Opening doors
[D1 14:05:21 elevator_2] At floor 1
[D1 14:05:21 elevator_2] Stopped at floor 1
[D1 14:05:21 elevator_2] Opening doors
[D1 14:05:23 elevator_1] Opened doors
[D1 14:05:23 citizen_147] Left elevator_1, arrived at floor 1
[D1 14:05:23 citizen_115] Entered elevator_1, going to floor 0
[D1 14:05:23 floor_1] citizen_115 is leaving the queue
[D1 14:05:23 floor_1] citizen_80 was served
[D1 14:05:23 elevator_1] Summoned to floor 1 from floor 1
[D1 14:05:23 elevator_2] Summoned to floor 1 from floor 1
[D1 14:05:23 citizen_80] Entered elevator_1, going to floor 0
[D1 14:05:23 floor_1] citizen_80 is leaving the queue
[D1 14:05:23 floor_1] The queue is now empty
[D1 14:05:24 citizen_158] Entered the building, will visit 4 floors in total
[D1 14:05:24 citizen_158] Time to go to floor 3 and stay there for 00:22:32
[D1 14:05:24 floor_0] citizen_158 entered the queue
[D1 14:05:24 floor_0] citizen_158 is queued along with 0 other arrivals in front of it
[D1 14:05:24 elevator_2] Opened doors
[D1 14:05:26 citizen_146] Time to go to floor 2 and stay there for 00:34:11
[D1 14:05:26 floor_5] citizen_146 entered the queue
[D1 14:05:26 floor_5] citizen_146 found an empty queue and will be served immediately
[D1 14:05:26 elevator_1] Summoned to floor 5 from floor 1
[D1 14:05:26 elevator_2] Summoned to floor 5 from floor 1
[D1 14:05:35 elevator_1] Closing doors
[D1 14:05:36 elevator_2] Closing doors
[D1 14:05:38 elevator_1] Closed doors
[D1 14:05:39 elevator_2] Closed doors
[D1 14:05:48 elevator_1] At floor 0
[D1 14:05:48 elevator_1] Stopped at floor 0
[D1 14:05:48 elevator_1] Opening doors
[D1 14:05:49 elevator_2] At floor 0
[D1 14:05:49 elevator_2] Stopped at floor 0
[D1 14:05:49 elevator_2] Opening doors
[D1 14:05:51 elevator_1] Opened doors
[D1 14:05:51 citizen_88] Left elevator_1, arrived at floor 0
[D1 14:05:51 citizen_115] Left elevator_1, arrived at floor 0
[D1 14:05:51 citizen_80] Left elevator_1, arrived at floor 0
[D1 14:05:51 citizen_88] Left the building
[D1 14:05:51 citizen_157] Entered elevator_1, going to floor 4
[D1 14:05:51 citizen_115] Left the building
[D1 14:05:51 citizen_80] Left the building
[D1 14:05:51 floor_0] citizen_157 is leaving the queue
[D1 14:05:51 floor_0] citizen_158 was served
[D1 14:05:51 elevator_1] Summoned to floor 0 from floor 0
[D1 14:05:51 elevator_2] Summoned to floor 0 from floor 0
[D1 14:05:51 citizen_158] Entered elevator_1, going to floor 3
[D1 14:05:51 floor_0] citizen_158 is leaving the queue
[D1 14:05:51 floor_0] The queue is now empty
[D1 14:05:52 elevator_2] Opened doors
[D1 14:06:03 elevator_1] Closing doors
[D1 14:06:04 elevator_2] Closing doors
[D1 14:06:06 elevator_1] Closed doors
[D1 14:06:06 elevator_1] Changing direction to Up
[D1 14:06:07 elevator_2] Closed doors
[D1 14:06:07 elevator_2] Changing direction to Up
[D1 14:06:14 citizen_133] Time to go to floor 2 and stay there for 00:45:04
[D1 14:06:14 floor_5] citizen_133 entered the queue
[D1 14:06:14 floor_5] citizen_133 is queued along with 0 other arrivals in front of it
[D1 14:06:16 elevator_1] At floor 1
[D1 14:06:17 elevator_2] At floor 1
[D1 14:06:26 elevator_1] At floor 2
[D1 14:06:27 elevator_2] At floor 2
[D1 14:06:29 citizen_127] Time to go to floor 2 and stay there for 00:41:51
[D1 14:06:29 floor_3] citizen_127 entered the queue
[D1 14:06:29 floor_3] citizen_127 is queued along with 0 other arrivals in front of it
[D1 14:06:36 elevator_1] At floor 3
[D1 14:06:36 elevator_1] Stopped at floor 3
[D1 14:06:36 elevator_1] Opening doors
[D1 14:06:37 elevator_2] At floor 3
[D1 14:06:37 elevator_2] Stopped at floor 3
[D1 14:06:37 elevator_2] Opening doors
[D1 14:06:39 elevator_1] Opened doors
[D1 14:06:39 citizen_158] Left elevator_1, arrived at floor 3
[D1 14:06:39 citizen_143] Entered elevator_1, going to floor 2
[D1 14:06:39 floor_3] citizen_143 is leaving the queue
[D1 14:06:39 floor_3] citizen_127 was served
[D1 14:06:39 elevator_1] Summoned to floor 3 from floor 3
[D1 14:06:39 elevator_2] Summoned to floor 3 from floor 3
[D1 14:06:39 citizen_127] Entered elevator_1, going to floor 2
[D1 14:06:39 floor_3] citizen_127 is leaving the queue
[D1 14:06:39 floor_3] The queue is now empty
[D1 14:06:40 elevator_2] Opened doors
[D1 14:06:51 elevator_1] Closing doors
[D1 14:06:52 elevator_2] Closing doors
[D1 14:06:54 elevator_1] Closed doors
[D1 14:06:55 elevator_2] Closed doors
[D1 14:07:04 elevator_1] At floor 4
[D1 14:07:04 elevator_1] Stopped at floor 4
[D1 14:07:04 elevator_1] Opening doors
[D1 14:07:05 elevator_2] At floor 4
[D1 14:07:07 elevator_1] Opened doors
[D1 14:07:07 citizen_157] Left elevator_1, arrived at floor 4
[D1 14:07:15 elevator_2] At floor 5
[D1 14:07:15 elevator_2] Stopped at floor 5
[D1 14:07:15 elevator_2] Opening doors
[D1 14:07:18 elevator_2] Opened doors
[D1 14:07:18 citizen_146] Entered elevator_2, going to floor 2
[D1 14:07:18 floor_5] citizen_146 is leaving the queue
[D1 14:07:18 floor_5] citizen_133 was served
[D1 14:07:18 elevator_2] Summoned to floor 5 from floor 5
[D1 14:07:18 citizen_133] Entered elevator_2, going to floor 2
[D1 14:07:18 floor_5] citizen_133 is leaving the queue
[D1 14:07:18 floor_5] The queue is now empty
[D1 14:07:19 elevator_1] Closing doors
[D1 14:07:21 citizen_103] Time to go to the ground floor and leave
[D1 14:07:21 floor_4] citizen_103 entered the queue
[D1 14:07:21 floor_4] citizen_103 found an empty queue and will be served immediately
[D1 14:07:21 elevator_1] Summoned to floor 4 from floor 4
[D1 14:07:22 elevator_1] Reopening doors
[D1 14:07:22 citizen_103] Entered elevator_1, going to floor 0
[D1 14:07:22 floor_4] citizen_103 is leaving the queue
[D1 14:07:22 floor_4] The queue is now empty
[D1 14:07:23 citizen_159] Entered the building, will visit 5 floors in total
[D1 14:07:23 citizen_159] Time to go to floor 3 and stay there for 00:26:16
[D1 14:07:23 floor_0] citizen_159 entered the queue
[D1 14:07:23 floor_0] citizen_159 found an empty queue and will be served immediately
[D1 14:07:23 elevator_1] Summoned to floor 0 from floor 4
[D1 14:07:30 elevator_2] Closing doors
[D1 14:07:33 elevator_2] Closed doors
[D1 14:07:33 elevator_2] Changing direction to Down
[D1 14:07:34 elevator_1] Closing doors
[D1 14:07:37 elevator_1] Closed doors
[D1 14:07:43 elevator_2] At floor 4
[D1 14:07:47 elevator_1] At floor 5
[D1 14:07:47 elevator_1] Stopped at floor 5
[D1 14:07:47 elevator_1] Opening doors
[D1 14:07:50 elevator_1] Opened doors
[D1 14:07:50 citizen_129] Left elevator_1, arrived at floor 5
[D1 14:07:53 elevator_2] At floor 3
[D1 14:08:01 citizen_114] Time to go to the ground floor and leave
[D1 14:08:01 floor_5] citizen_114 entered the queue
[D1 14:08:01 floor_5] citizen_114 found an empty queue and will be served immediately
[D1 14:08:01 elevator_1] Summoned to floor 5 from floor 5
[D1 14:08:01 citizen_114] Entered elevator_1, going to floor 0
[D1 14:08:01 floor_5] citizen_114 is leaving the queue
[D1 14:08:01 floor_5] The queue is now empty
[D1 14:08:02 elevator_1] Closing doors
[D1 14:08:03 elevator_2] At floor 2
[D1 14:08:03 elevator_2] Stopped at floor 2
[D1 14:08:03 elevator_2] Opening doors
[D1 14:08:05 elevator_1] Closed doors
[D1 14:08:05 elevator_1] Changing direction to Down
[D1 14:08:06 elevator_2] Opened doors
[D1 14:08:06 citizen_146] Left elevator_2, arrived at floor 2
[D1 14:08:06 citizen_133] Left elevator_2, arrived at floor 2
[D1 14:08:15 elevator_1] At floor 4
[D1 14:08:18 elevator_2] Closing doors
[D1 14:08:21 elevator_2] Closed doors
[D1 14:08:21 elevator_2] Resting at floor 2
[D1 14:08:25 elevator_1] At floor 3
[D1 14:08:35 elevator_1] At floor 2
[D1 14:08:35 elevator_1] Stopped at floor 2
[D1 14:08:35 elevator_1] Opening doors
[D1 14:08:38 elevator_1] Opened doors
[D1 14:08:38 citizen_143] Left elevator_1, arrived at floor 2
[D1 14:08:38 citizen_127] Left elevator_1, arrived at floor 2
[D1 14:08:50 elevator_1] Closing doors
[D1 14:08:53 elevator_1] Closed doors
[D1 14:09:03 elevator_1] At floor 1
[D1 14:09:06 citizen_160] Entered the building, will visit 2 floors in total
[D1 14:09:06 citizen_160] Time to go to floor 2 and stay there for 00:18:37
[D1 14:09:06 floor_0] citizen_160 entered the queue
[D1 14:09:06 floor_0] citizen_160 is queued along with 0 other arrivals in front of it
[D1 14:09:13 elevator_1] At floor 0
[D1 14:09:13 elevator_1] Stopped at floor 0
[D1 14:09:13 elevator_1] Opening doors
[D1 14:09:16 elevator_1] Opened doors
[D1 14:09:16 citizen_103] Left elevator_1, arrived at floor 0
[D1 14:09:16 citizen_114] Left elevator_1, arrived at floor 0
[D1 14:09:16 citizen_103] Left the building
[D1 14:09:16 citizen_114] Left the building
[D1 14:09:16 citizen_159] Entered elevator_1, going to floor 3
[D1 14:09:16 floor_0] citizen_159 is leaving the queue
[D1 14:09:16 floor_0] citizen_160 was served
[D1 14:09:16 elevator_1] Summoned to floor 0 from floor 0
[D1 14:09:16 citizen_160] Entered elevator_1, going to floor 2
[D1 14:09:16 floor_0] citizen_160 is leaving the queue
[D1 14:09:16 floor_0] The queue is now empty
[D1 14:09:21 citizen_130] Time to go to floor 5 and stay there for 00:31:28
[D1 14:09:21 floor_1] citizen_130 entered the queue
[D1 14:09:21 floor_1] citizen_130 found an empty queue and will be served immediately
[D1 14:09:21 elevator_1] Summoned to floor 1 from floor 0
[D1 14:09:21 elevator_2] Summoned to floor 1 from floor 2
[D1 14:09:21 elevator_2] Sprung into motion, heading Down
[D1 14:09:28 elevator_1] Closing doors
[D1 14:09:31 elevator_2] At floor 1
[D1 14:09:31 elevator_2] Stopped at floor 1
[D1 14:09:31 elevator_2] Opening doors
[D1 14:09:31 elevator_1] Closed doors
[D1 14:09:31 elevator_1] Changing direction to Up
[D1 14:09:34 elevator_2] Opened doors
[D1 14:09:34 citizen_130] Entered elevator_2, going to floor 5
[D1 14:09:34 floor_1] citizen_130 is leaving the queue
[D1 14:09:34 floor_1] The queue is now empty
[D1 14:09:41 elevator_1] At floor 1
[D1 14:09:41 elevator_1] Stopped at floor 1
[D1 14:09:41 elevator_1] Opening doors
[D1 14:09:44 elevator_1] Opened doors
[D1 14:09:46 elevator_2] Closing doors
[D1 14:09:49 elevator_2] Closed doors
[D1 14:09:49 elevator_2] Changing direction to Up
[D1 14:09:56 elevator_1] Closing doors
[D1 14:09:59 elevator_2] At floor 2
[D1 14:09:59 elevator_1] Closed doors
[D1 14:10:03 citizen_116] Time to go to floor 5 and stay there for 00:23:34
[D1 14:10:03 floor_2] citizen_116 entered the queue
[D1 14:10:03 floor_2] citizen_116 found an empty queue and will be served immediately
[D1 14:10:03 elevator_2] Summoned to floor 2 from floor 2
[D1 14:10:09 elevator_2] At floor 3
[D1 14:10:09 elevator_1] At floor 2
[D1 14:10:09 elevator_1] Stopped at floor 2
[D1 14:10:09 elevator_1] Opening doors
[D1 14:10:12 elevator_1] Opened doors
[D1 14:10:12 citizen_160] Left elevator_1, arrived at floor 2
[D1 14:10:19 elevator_2] At floor 4
[D1 14:10:23 citizen_95] Time to go to the ground floor and leave
[D1 14:10:23 floor_2] citizen_95 entered the queue
[D1 14:10:23 floor_2] citizen_95 is queued along with 0 other arrivals in front of it
[D1 14:10:24 elevator_1] Closing doors
[D1 14:10:27 elevator_1] Closed doors
[D1 14:10:29 elevator_2] At floor 5
[D1 14:10:29 elevator_2] Stopped at floor 5
[D1 14:10:29 elevator_2] Opening doors
[D1 14:10:32 elevator_2] Opened doors
[D1 14:10:32 citizen_130] Left elevator_2, arrived at floor 5
[D1 14:10:37 elevator_1] At floor 3
[D1 14:10:37 elevator_1] Stopped at floor 3
[D1 14:10:37 elevator_1] Opening doors
[D1 14:10:40 elevator_1] Opened doors
[D1 14:10:40 citizen_159] Left elevator_1, arrived at floor 3
[D1 14:10:44 elevator_2] Closing doors
[D1 14:10:47 elevator_2] Closed doors
[D1 14:10:47 elevator_2] Changing direction to Down
[D1 14:10:52 elevator_1] Closing doors
[D1 14:10:55 elevator_1] Closed doors
[D1 14:10:55 elevator_1] Resting at floor 3
[D1 14:10:57 elevator_2] At floor 4
[D1 14:11:07 elevator_2] At floor 3
[D1 14:11:17 elevator_2] At floor 2
[D1 14:11:17 elevator_2] Stopped at floor 2
[D1 14:11:17 elevator_2] Opening doors
[D1 14:11:20 elevator_2] Opened doors
[D1 14:11:20 citizen_116] Entered elevator_2, going to floor 5
[D1 14:11:20 floor_2] citizen_116 is leaving the queue
[D1 14:11:20 floor_2] citizen_95 was served
[D1 14:11:20 elevator_2] Summoned to floor 2 from floor 2
[D1 14:11:20 citizen_95] Entered elevator_2, going to floor 0
[D1 14:11:20 floor_2] citizen_95 is leaving the queue
[D1 14:11:20 floor_2] The queue is now empty
[D1 14:11:32 elevator_2] Closing doors
[D1 14:11:35 elevator_2] Closed doors
[D1 14:11:45 elevator_2] At floor 1
[D1 14:11:54 citizen_111] Time to go to floor 2 and stay there for 00:37:43
[D1 14:11:54 floor_5] citizen_111 entered the queue
[D1 14:11:54 floor_5] citizen_111 found an empty queue and will be served immediately
[D1 14:11:54 elevator_1] Summoned to floor 5 from floor 3
[D1 14:11:54 elevator_1] Sprung into motion, heading Up
[D1 14:11:55 elevator_2] At floor 0
[D1 14:11:55 elevator_2] Stopped at floor 0
[D1 14:11:55 elevator_2] Opening doors
[D1 14:11:58 elevator_2] Opened doors
[D1 14:11:58 citizen_95] Left elevator_2, arrived at floor 0
[D1 14:11:58 citizen_95] Left the building
[D1 14:12:04 elevator_1] At floor 4
[D1 14:12:08 citizen_144] Time to go to floor 2 and stay there for 00:19:35
[D1 14:12:08 floor_4] citizen_144 entered the queue
[D1 14:12:08 floor_4] citizen_144 found an empty queue and will be served immediately
[D1 14:12:08 elevator_1] Summoned to floor 4 from floor 4
[D1 14:12:10 elevator_2] Closing doors
[D1 14:12:13 elevator_2] Closed doors
[D1 14:12:13 elevator_2] Changing direction to Up
[D1 14:12:14 elevator_1] At floor 5
[D1 14:12:14 elevator_1] Stopped at floor 5
[D1 14:12:14 elevator_1] Opening doors
[D1 14:12:17 elevator_1] Opened doors
[D1 14:12:17 citizen_111] Entered elevator_1, going to floor 2
[D1 14:12:17 floor_5] citizen_111 is leaving the queue
[D1 14:12:17 floor_5] The queue is now empty
[D1 14:12:23 elevator_2] At floor 1
[D1 14:12:29 elevator_1] Closing doors
[D1 14:12:32 elevator_1] Closed doors
[D1 14:12:32 elevator_1] Changing direction to Down
[D1 14:12:33 elevator_2] At floor 2
[D1 14:12:39 citizen_107] Time to go to floor 4 and stay there for 00:25:10
[D1 14:12:39 floor_1] citizen_107 entered the queue
[D1 14:12:39 floor_1] citizen_107 found an empty queue and will be served immediately
[D1 14:12:39 elevator_2] Summoned to floor 1 from floor 2
[D1 14:12:42 elevator_1] At floor 4
[D1 14:12:42 elevator_1] Stopped at floor 4
[D1 14:12:42 elevator_1] Opening doors
[D1 14:12:43 elevator_2] At floor 3
[D1 14:12:45 elevator_1] Opened doors
[D1 14:12:45 citizen_144] Entered elevator_1, going to floor 2
[D1 14:12:45 floor_4] citizen_144 is leaving the queue
[D1 14:12:45 floor_4] The queue is now empty
[D1 14:12:53 elevator_2] At floor 4
[D1 14:12:57 elevator_1] Closing doors
[D1 14:13:00 elevator_1] Closed doors
[D1 14:13:03 elevator_2] At floor 5
[D1 14:13:03 elevator_2] Stopped at floor 5
[D1 14:13:03 elevator_2] Opening doors
[D1 14:13:06 elevator_2] Opened doors
[D1 14:13:06 citizen_116] Left elevator_2, arrived at floor 5
[D1 14:13:10 citizen_121] Time to go to floor 3 and stay there for 00:37:10
[D1 14:13:10 floor_1] citizen_121 entered the queue
[D1 14:13:10 floor_1] citizen_121 is queued along with 0 other arrivals in front of it
[D1 14:13:10 elevator_1] At floor 3
[D1 14:13:18 elevator_2] Closing doors
[D1 14:13:20 elevator_1] At floor 2
[D1 14:13:20 elevator_1] Stopped at floor 2
[D1 14:13:20 elevator_1] Opening doors
[D1 14:13:21 elevator_2] Closed doors
[D1 14:13:21 elevator_2] Changing direction to Down
[D1 14:13:23 elevator_1] Opened doors
[D1 14:13:23 citizen_111] Left elevator_1, arrived at floor 2
[D1 14:13:23 citizen_144] Left elevator_1, arrived at floor 2
[D1 14:13:31 elevator_2] At floor 4
[D1 14:13:35 elevator_1] Closing doors
[D1 14:13:38 elevator_1] Closed doors
[D1 14:13:38 elevator_1] Resting at floor 2
[D1 14:13:41 elevator_2] At floor 3
[D1 14:13:51 elevator_2] At floor 2
[D1 14:13:57 citizen_99] Time to go to floor 2 and stay there for 00:18:12
[D1 14:13:57 floor_3] citizen_99 entered the queue
[D1 14:13:57 floor_3] citizen_99 found an empty queue and will be served immediately
[D1 14:13:57 elevator_1] Summoned to floor 3 from floor 2
[D1 14:13:57 elevator_1] Sprung into motion, heading Up
[D1 14:13:57 elevator_2] Summoned to floor 3 from floor 2
[D1 14:14:01 elevator_2] At floor 1
[D1 14:14:01 elevator_2] Stopped at floor 1
[D1 14:14:01 elevator_2] Opening doors
[D1 14:14:04 elevator_2] Opened doors
[D1 14:14:04 citizen_107] Entered elevator_2, going to floor 4
[D1 14:14:04 floor_1] citizen_107 is leaving the queue
[D1 14:14:04 floor_1] citizen_121 was served
[D1 14:14:04 elevator_2] Summoned to floor 1 from floor 1
[D1 14:14:04 citizen_121] Entered elevator_2, going to floor 3
[D1 14:14:04 floor_1] citizen_121 is leaving the queue
[D1 14:14:04 floor_1] The queue is now empty
[D1 14:14:07 elevator_1] At floor 3
[D1 14:14:07 elevator_1] Stopped at floor 3
[D1 14:14:07 elevator_1] Opening doors
[D1 14:14:10 elevator_1] Opened doors
[D1 14:14:10 citizen_99] Entered elevator_1, going to floor 2
[D1 14:14:10 floor_3] citizen_99 is leaving the queue
[D1 14:14:10 floor_3] The queue is now empty
[D1 14:14:14 citizen_110] Time to go to the ground floor and leave
[D1 14:14:14 floor_2] citizen_110 entered the queue
[D1 14:14:14 floor_2] citizen_110 found an empty queue and will be served immediately
[D1 14:14:14 elevator_1] Summoned to floor 2 from floor 3
[D1 14:14:14 elevator_2] Summoned to floor 2 from floor 1
[D1 14:14:16 elevator_2] Closing doors
[D1 14:14:19 elevator_2] Closed doors
[D1 14:14:19 elevator_2] Changing direction to Up
[D1 14:14:22 elevator_1] Closing doors
[D1 14:14:25 elevator_1] Closed doors
[D1 14:14:25 elevator_1] Changing direction to Down
[D1 14:14:28 citizen_145] Time to go to floor 4 and stay there for 00:27:08
[D1 14:14:28 floor_3] citizen_145 entered the queue
[D1 14:14:28 floor_3] citizen_145 found an empty queue and will be served immediately
[D1 14:14:28 elevator_1] Summoned to floor 3 from floor 3
[D1 14:14:29 elevator_2] At floor 2
[D1 14:14:29 elevator_2] Stopped at floor 2
[D1 14:14:29 elevator_2] Opening doors
[D1 14:14:32 elevator_2] Opened doors
[D1 14:14:32 citizen_110] Entered elevator_2, going to floor 0
[D1 14:14:32 floor_2] citizen_110 is leaving the queue
[D1 14:14:32 floor_2] The queue is now empty
[D1 14:14:35 elevator_1] At floor 2
[D1 14:14:35 elevator_1] Stopped at floor 2
[D1 14:14:35 elevator_1] Opening doors
[D1 14:14:38 elevator_1] Opened doors
[D1 14:14:38 citizen_99] Left elevator_1, arrived at floor 2
[D1 14:14:44 elevator_2] Closing doors
[D1 14:14:47 elevator_2] Closed doors
[D1 14:14:50 elevator_1] Closing doors
[D1 14:14:53 elevator_1] Closed doors
[D1 14:14:53 elevator_1] Changing direction to Up
[D1 14:14:57 elevator_2] At floor 3
[D1 14:14:57 elevator_2] Stopped at floor 3
[D1 14:14:57 elevator_2] Opening doors
[D1 14:15:00 elevator_2] Opened doors
[D1 14:15:00 citizen_121] Left elevator_2, arrived at floor 3
[D1 14:15:03 elevator_1] At floor 3
[D1 14:15:03 elevator_1] Stopped at floor 3
[D1 14:15:03 elevator_1] Opening doors
[D1 14:15:06 elevator_1] Opened doors
[D1 14:15:06 citizen_145] Entered elevator_1, going to floor 4
[D1 14:15:06 floor_3] citizen_145 is leaving the queue
[D1 14:15:06 floor_3] The queue is now empty
[D1 14:15:12 elevator_2] Closing doors
[D1 14:15:14 citizen_161] Entered the building, will visit 3 floors in total
[D1 14:15:14 citizen_161] Time to go to floor 5 and stay there for 00:25:01
[D1 14:15:14 floor_0] citizen_161 entered the queue
[D1 14:15:14 floor_0] citizen_161 found an empty queue and will be served immediately
[D1 14:15:14 elevator_1] Summoned to floor 0 from floor 3
[D1 14:15:14 elevator_2] Summoned to floor 0 from floor 3
[D1 14:15:15 elevator_2] Closed doors
[D1 14:15:18 elevator_1] Closing doors
[D1 14:15:21 elevator_1] Closed doors
[D1 14:15:25 elevator_2] At floor 4
[D1 14:15:25 elevator_2] Stopped at floor 4
[D1 14:15:25 elevator_2] Opening doors
[D1 14:15:28 elevator_2] Opened doors
[D1 14:15:28 citizen_107] Left elevator_2, arrived at floor 4
[D1 14:15:31 elevator_1] At floor 4
[D1 14:15:31 elevator_1] Stopped at floor 4
[D1 14:15:31 elevator_1] Opening doors
[D1 14:15:34 elevator_1] Opened doors
[D1 14:15:34 citizen_145] Left elevator_1, arrived at floor 4
[D1 14:15:40 elevator_2] Closing doors
[D1 14:15:43 elevator_2] Closed doors
[D1 14:15:43 elevator_2] Changing direction to Down
[D1 14:15:46 elevator_1] Closing doors
[D1 14:15:49 elevator_1] Closed doors
[D1 14:15:49 elevator_1] Changing direction to Down
[D1 14:15:53 elevator_2] At floor 3
[D1 14:15:56 citizen_140] Time to go to floor 1 and stay there for 00:23:42
[D1 14:15:56 floor_4] citizen_140 entered the queue
[D1 14:15:56 floor_4] citizen_140 found an empty queue and will be served immediately
[D1 14:15:56 elevator_1] Summoned to floor 4 from floor 4
[D1 14:15:59 elevator_1] At floor 3
[D1 14:16:03 elevator_2] At floor 2
[D1 14:16:09 elevator_1] At floor 2
[D1 14:16:11 citizen_125] Time to go to floor 3 and stay there for 00:26:59
[D1 14:16:11 floor_1] citizen_125 entered the queue
[D1 14:16:11 floor_1] citizen_125 found an empty queue and will be served immediately
[D1 14:16:11 elevator_1] Summoned to floor 1 from floor 2
[D1 14:16:11 elevator_2] Summoned to floor 1 from floor 2
[D1 14:16:13 elevator_2] At floor 1
[D1 14:16:13 elevator_2] Stopped at floor 1
[D1 14:16:13 elevator_2] Opening doors
[D1 14:16:16 elevator_2] Opened doors
[D1 14:16:16 citizen_125] Entered elevator_2, going to floor 3
[D1 14:16:16 floor_1] citizen_125 is leaving the queue
[D1 14:16:16 floor_1] The queue is now empty
[D1 14:16:19 elevator_1] At floor 1
[D1 14:16:19 elevator_1] Stopped at floor 1
[D1 14:16:19 elevator_1] Opening doors
[D1 14:16:22 elevator_1] Opened doors
[D1 14:16:28 elevator_2] Closing doors
[D1 14:16:31 elevator_2] Closed doors
[D1 14:16:34 elevator_1] Closing doors
[D1 14:16:37 elevator_1] Closed doors
[D1 14:16:41 elevator_2] At floor 0
[D1 14:16:41 elevator_2] Stopped at floor 0
[D1 14:16:41 elevator_2] Opening doors
[D1 14:16:44 elevator_2] Opened doors
[D1 14:16:44 citizen_110] Left elevator_2, arrived at floor 0
[D1 14:16:44 citizen_110] Left the building
[D1 14:16:44 citizen_161] Entered elevator_2, going to floor 5
[D1 14:16:44 floor_0] citizen_161 is leaving the queue
[D1 14:16:44 floor_0] The queue is now empty
[D1 14:16:45 citizen_101] Time to go to the ground floor and leave
[D1 14:16:45 floor_3] citizen_101 entered the queue
[D1 14:16:45 floor_3] citizen_101 found an empty queue and will be served immediately
[D1 14:16:45 elevator_1] Summoned to floor 3 from floor 1
[D1 14:16:47 elevator_1] At floor 0
[D1 14:16:47 elevator_1] Stopped at floor 0
[D1 14:16:47 elevator_1] Opening doors
[D1 14:16:50 elevator_1] Opened doors
[D1 14:16:56 elevator_2] Closing doors
[D1 14:16:59 elevator_2] Closed doors
[D1 14:16:59 elevator_2] Changing direction to Up
[D1 14:17:00 citizen_162] Entered the building, will visit 4 floors in total
[D1 14:17:00 citizen_162] Time to go to floor 4 and stay there for 00:31:43
[D1 14:17:00 floor_0] citizen_162 entered the queue
[D1 14:17:00 floor_0] citizen_162 found an empty queue and will be served immediately
[D1 14:17:00 elevator_1] Summoned to floor 0 from floor 0
[D1 14:17:00 elevator_2] Summoned to floor 0 from floor 0
[D1 14:17:00 citizen_162] Entered elevator_1, going to floor 4
[D1 14:17:00 floor_0] citizen_162 is leaving the queue
[D1 14:17:00 floor_0] The queue is now empty
[D1 14:17:02 elevator_1] Closing doors
[D1 14:17:05 elevator_1] Closed doors
[D1 14:17:05 elevator_1] Changing direction to Up
[D1 14:17:09 elevator_2] At floor 1
[D1 14:17:14 citizen_106] Time to go to the ground floor and leave
[D1 14:17:14 floor_3] citizen_106 entered the queue
[D1 14:17:14 floor_3] citizen_106 is queued along with 0 other arrivals in front of it
[D1 14:17:15 elevator_1] At floor 1
[D1 14:17:19 elevator_2] At floor 2
[D1 14:17:25 elevator_1] At floor 2
[D1 14:17:29 elevator_2] At floor 3
[D1 14:17:29 elevator_2] Stopped at floor 3
[D1 14:17:29 elevator_2] Opening doors
[D1 14:17:32 elevator_2] Opened doors
[D1 14:17:32 citizen_125] Left elevator_2, arrived at floor 3
[D1 14:17:35 elevator_1] At floor 3
[D1 14:17:35 elevator_1] Stopped at floor 3
[D1 14:17:35 elevator_1] Opening doors
[D1 14:17:38 elevator_1] Opened doors
[D1 14:17:38 citizen_101] Entered elevator_1, going to floor 0
[D1 14:17:38 floor_3] citizen_101 is leaving the queue
[D1 14:17:38 floor_3] citizen_106 was served
[D1 14:17:38 elevator_1] Summoned to floor 3 from floor 3
[D1 14:17:38 elevator_2] Summoned to floor 3 from floor 3
[D1 14:17:38 citizen_106] Entered elevator_1, going to floor 0
[D1 14:17:38 floor_3] citizen_106 is leaving the queue
[D1 14:17:38 floor_3] The queue is now empty
[D1 14:17:44 elevator_2] Closing doors
[D1 14:17:47 elevator_2] Closed doors
[D1 14:17:50 elevator_1] Closing doors
[D1 14:17:53 elevator_1] Closed doors
[D1 14:17:57 elevator_2] At floor 4
[D1 14:18:01 citizen_126] Time to go to the ground floor and leave
[D1 14:18:01 floor_5] citizen_126 entered the queue
[D1 14:18:01 floor_5] citizen_126 found an empty queue and will be served immediately
[D1 14:18:01 elevator_2] Summoned to floor 5 from floor 4
[D1 14:18:03 elevator_1] At floor 4
[D1 14:18:03 elevator_1] Stopped at floor 4
[D1 14:18:03 elevator_1] Opening doors
[D1 14:18:06 elevator_1] Opened doors
[D1 14:18:06 citizen_162] Left elevator_1, arrived at floor 4
[D1 14:18:06 citizen_140] Entered elevator_1, going to floor 1
[D1 14:18:06 floor_4] citizen_140 is leaving the queue
[D1 14:18:06 floor_4] The queue is now empty
[D1 14:18:07 elevator_2] At floor 5
[D1 14:18:07 elevator_2] Stopped at floor 5
[D1 14:18:07 elevator_2] Opening doors
[D1 14:18:10 elevator_2] Opened doors
[D1 14:18:10 citizen_161] Left elevator_2, arrived at floor 5
[D1 14:18:10 citizen_126] Entered elevator_2, going to floor 0
[D1 14:18:10 floor_5] citizen_126 is leaving the queue
[D1 14:18:10 floor_5] The queue is now empty
[D1 14:18:18 elevator_1] Closing doors
[D1 14:18:21 elevator_1] Closed doors
[D1 14:18:21 elevator_1] Changing direction to Down
[D1 14:18:22 elevator_2] Closing doors
[D1 14:18:25 elevator_2] Closed doors
[D1 14:18:25 elevator_2] Changing direction to Down
[D1 14:18:31 elevator_1] At floor 3
[D1 14:18:35 elevator_2] At floor 4
[D1 14:18:41 elevator_1] At floor 2
[D1 14:18:45 elevator_2] At floor 3
[D1 14:18:51 elevator_1] At floor 1
[D1 14:18:51 elevator_1] Stopped at floor 1
[D1 14:18:51 elevator_1] Opening doors
[D1 14:18:54 elevator_1] Opened doors
[D1 14:18:54 citizen_140] Left elevator_1, arrived at floor 1
[D1 14:18:55 elevator_2] At floor 2
[D1 14:19:05 elevator_2] At floor 1
[D1 14:19:06 elevator_1] Closing doors
[D1 14:19:09 elevator_1] Closed doors
[D1 14:19:15 elevator_2] At floor 0
[D1 14:19:15 elevator_2] Stopped at floor 0
[D1 14:19:15 elevator_2] Opening doors
[D1 14:19:18 elevator_2] Opened doors
[D1 14:19:18 citizen_126] Left elevator_2, arrived at floor 0
[D1 14:19:18 citizen_126] Left the building
[D1 14:19:19 elevator_1] At floor 0
[D1 14:19:19 elevator_1] Stopped at floor 0
[D1 14:19:19 elevator_1] Opening doors
[D1 14:19:20 citizen_131] Time to go to the ground floor and leave
[D1 14:19:20 floor_3] citizen_131 entered the queue
[D1 14:19:20 floor_3] citizen_131 found an empty queue and will be served immediately
[D1 14:19:20 elevator_1] Summoned to floor 3 from floor 0
[D1 14:19:20 elevator_2] Summoned to floor 3 from floor 0
[D1 14:19:22 elevator_1] Opened doors
[D1 14:19:22 citizen_101] Left elevator_1, arrived at floor 0
[D1 14:19:22 citizen_106] Left elevator_1, arrived at floor 0
[D1 14:19:22 citizen_101] Left the building
[D1 14:19:22 citizen_106] Left the building
[D1 14:19:30 elevator_2] Closing doors
[D1 14:19:33 elevator_2] Closed doors
[D1 14:19:33 elevator_2] Changing direction to Up
[D1 14:19:34 elevator_1] Closing doors
[D1 14:19:37 elevator_1] Closed doors
[D1 14:19:37 elevator_1] Changing direction to Up
[D1 14:19:43 elevator_2] At floor 1
[D1 14:19:47 elevator_1] At floor 1
[D1 14:19:53 elevator_2] At floor 2
[D1 14:19:57 elevator_1] At floor 2
[D1 14:19:58 citizen_118] Time to go to floor 1 and stay there for 00:24:18
[D1 14:19:58 floor_3] citizen_118 entered the queue
[D1 14:19:58 floor_3] citizen_118 is queued along with 0 other arrivals in front of it
[D1 14:20:03 elevator_2] At floor 3
[D1 14:20:03 elevator_2] Stopped at floor 3
[D1 14:20:03 elevator_2] Opening doors
[D1 14:20:06 elevator_2] Opened doors
[D1 14:20:06 citizen_131] Entered elevator_2, going to floor 0
[D1 14:20:06 floor_3] citizen_131 is leaving the queue
[D1 14:20:06 floor_3] citizen_118 was served
[D1 14:20:06 elevator_2] Summoned to floor 3 from floor 3
[D1 14:20:06 citizen_118] Entered elevator_2, going to floor 1
[D1 14:20:06 floor_3] citizen_118 is leaving the queue
[D1 14:20:06 floor_3] The queue is now empty
[D1 14:20:07 elevator_1] At floor 3
[D1 14:20:07 elevator_1] Stopped at floor 3
[D1 14:20:07 elevator_1] Opening doors
[D1 14:20:10 elevator_1] Opened doors
[D1 14:20:18 elevator_2] Closing doors
[D1 14:20:21 elevator_2] Closed doors
[D1 14:20:21 elevator_2] Changing direction to Down
[D1 14:20:22 elevator_1] Closing doors
[D1 14:20:25 elevator_1] Closed doors
[D1 14:20:25 elevator_1] Resting at floor 3
[D1 14:20:31 elevator_2] At floor 2
[D1 14:20:41 elevator_2] At floor 1
[D1 14:20:41 elevator_2] Stopped at floor 1
[D1 14:20:41 elevator_2] Opening doors
[D1 14:20:44 elevator_2] Opened doors
[D1 14:20:44 citizen_118] Left elevator_2, arrived at floor 1
[D1 14:20:56 elevator_2] Closing doors
[D1 14:20:59 elevator_2] Closed doors
[D1 14:21:09 elevator_2] At floor 0
[D1 14:21:09 elevator_2] Stopped at floor 0
[D1 14:21:09 elevator_2] Opening doors
[D1 14:21:12 elevator_2] Opened doors
[D1 14:21:12 citizen_131] Left elevator_2, arrived at floor 0
[D1 14:21:12 citizen_131] Left the building
[D1 14:21:24 elevator_2] Closing doors
[D1 14:21:27 elevator_2] Closed doors
[D1 14:21:27 elevator_2] Resting at floor 0
[D1 14:21:30 citizen_149] Time to go to floor 2 and stay there for 00:29:17
[D1 14:21:30 floor_3] citizen_149 entered the queue
[D1 14:21:30 floor_3] citizen_149 found an empty queue and will be served immediately
[D1 14:21:30 elevator_1] Summoned to floor 3 from floor 3
[D1 14:21:30 elevator_1] Opening doors
[D1 14:21:33 elevator_1] Opened doors
[D1 14:21:33 citizen_149] Entered elevator_1, going to floor 2
[D1 14:21:33 floor_3] citizen_149 is leaving the queue
[D1 14:21:33 floor_3] The queue is now empty
[D1 14:21:45 elevator_1] Closing doors
[D1 14:21:48 elevator_1] Closed doors
[D1 14:21:48 elevator_1] Sprung into motion, heading Down
[D1 14:21:54 citizen_98] Time to go to the ground floor and leave
[D1 14:21:54 floor_4] citizen_98 entered the queue
[D1 14:21:54 floor_4] citizen_98 found an empty queue and will be served immediately
[D1 14:21:54 elevator_1] Summoned to floor 4 from floor 3
[D1 14:21:58 elevator_1] At floor 2
[D1 14:21:58 elevator_1] Stopped at floor 2
[D1 14:21:58 elevator_1] Opening doors
[D1 14:22:01 elevator_1] Opened doors
[D1 14:22:01 citizen_149] Left elevator_1, arrived at floor 2
[D1 14:22:13 elevator_1] Closing doors
[D1 14:22:16 elevator_1] Closed doors
[D1 14:22:16 elevator_1] Changing direction to Up
[D1 14:22:26 elevator_1] At floor 3
[D1 14:22:36 elevator_1] At floor 4
[D1 14:22:36 elevator_1] Stopped at floor 4
[D1 14:22:36 elevator_1] Opening doors
[D1 14:22:39 elevator_1] Opened doors
[D1 14:22:39 citizen_98] Entered elevator_1, going to floor 0
[D1 14:22:39 floor_4] citizen_98 is leaving the queue
[D1 14:22:39 floor_4] The queue is now empty
[D1 14:22:51 elevator_1] Closing doors
[D1 14:22:54 elevator_1] Closed doors
[D1 14:22:54 elevator_1] Changing direction to Down
[D1 14:23:04 elevator_1] At floor 3
[D1 14:23:14 elevator_1] At floor 2
[D1 14:23:24 elevator_1] At floor 1
[D1 14:23:29 citizen_163] Entered the building, will visit 4 floors in total
[D1 14:23:29 citizen_163] Time to go to floor 4 and stay there for 00:24:47
[D1 14:23:29 floor_0] citizen_163 entered the queue
[D1 14:23:29 floor_0] citizen_163 found an empty queue and will be served immediately
[D1 14:23:29 elevator_2] Summoned to floor 0 from floor 0
[D1 14:23:29 elevator_2] Opening doors
[D1 14:23:32 elevator_2] Opened doors
[D1 14:23:32 citizen_163] Entered elevator_2, going to floor 4
[D1 14:23:32 floor_0] citizen_163 is leaving the queue
[D1 14:23:32 floor_0] The queue is now empty
[D1 14:23:34 elevator_1] At floor 0
[D1 14:23:34 elevator_1] Stopped at floor 0
[D1 14:23:34 elevator_1] Opening doors
[D1 14:23:36 citizen_136] Time to go to floor 1 and stay there for 00:19:52
[D1 14:23:36 floor_4] citizen_136 entered the queue
[D1 14:23:36 floor_4] citizen_136 found an empty queue and will be served immediately
[D1 14:23:36 elevator_1] Summoned to floor 4 from floor 0
[D1 14:23:36 elevator_2] Summoned to floor 4 from floor 0
[D1 14:23:36 citizen_148] Time to go to floor 5 and stay there for 00:50:20
[D1 14:23:36 floor_1] citizen_148 entered the queue
[D1 14:23:36 floor_1] citizen_148 found an empty queue and will be served immediately
[D1 14:23:36 elevator_1] Summoned to floor 1 from floor 0
[D1 14:23:36 elevator_2] Summoned to floor 1 from floor 0
[D1 14:23:37 elevator_1] Opened doors
[D1 14:23:37 citizen_98] Left elevator_1, arrived at floor 0
[D1 14:23:37 citizen_98] Left the building
[D1 14:23:44 elevator_2] Closing doors
[D1 14:23:45 citizen_151] Time to go to floor 3 and stay there for 00:20:19
[D1 14:23:45 floor_2] citizen_151 entered the queue
[D1 14:23:45 floor_2] citizen_151 found an empty queue and will be served immediately
[D1 14:23:45 elevator_1] Summoned to floor 2 from floor 0
[D1 14:23:45 elevator_2] Summoned to floor 2 from floor 0
[D1 14:23:47 elevator_2] Closed doors
[D1 14:23:47 elevator_2] Sprung into motion, heading Up
[D1 14:23:49 elevator_1] Closing doors
[D1 14:23:52 elevator_1] Closed doors
[D1 14:23:52 elevator_1] Changing direction to Up
[D1 14:23:57 elevator_2] At floor 1
[D1 14:23:57 elevator_2] Stopped at floor 1
[D1 14:23:57 elevator_2] Opening doors
[D1 14:24:00 elevator_2] Opened doors
[D1 14:24:00 citizen_148] Entered elevator_2, going to floor 5
[D1 14:24:00 floor_1] citizen_148 is leaving the queue
[D1 14:24:00 floor_1] The queue is now empty
[D1 14:24:02 elevator_1] At floor 1
[D1 14:24:02 elevator_1] Stopped at floor 1
[D1 14:24:02 elevator_1] Opening doors
[D1 14:24:05 elevator_1] Opened doors
[D1 14:24:12 elevator_2] Closing doors
[D1 14:24:15 elevator_2] Closed doors
[D1 14:24:17 elevator_1] Closing doors
[D1 14:24:20 elevator_1] Closed doors
[D1 14:24:25 elevator_2] At floor 2
[D1 14:24:25 elevator_2] Stopped at floor 2
[D1 14:24:25 elevator_2] Opening doors
[D1 14:24:28 elevator_2] Opened doors
[D1 14:24:28 citizen_151] Entered elevator_2, going to floor 3
[D1 14:24:28 floor_2] citizen_151 is leaving the queue
[D1 14:24:28 floor_2] The queue is now empty
[D1 14:24:30 elevator_1] At floor 2
[D1 14:24:30 elevator_1] Stopped at floor 2
[D1 14:24:30 elevator_1] Opening doors
[D1 14:24:33 elevator_1] Opened doors
[D1 14:24:40 elevator_2] Closing doors
[D1 14:24:41 citizen_113] Time to go to floor 1 and stay there for 00:19:46
[D1 14:24:41 floor_2] citizen_113 entered the queue
[D1 14:24:41 floor_2] citizen_113 found an empty queue and will be served immediately
[D1 14:24:41 elevator_1] Summoned to floor 2 from floor 2
[D1 14:24:41 elevator_2] Summoned to floor 2 from floor 2
[D1 14:24:41 citizen_113] Entered elevator_1, going to floor 1
[D1 14:24:41 floor_2] citizen_113 is leaving the queue
[D1 14:24:41 floor_2] The queue is now empty
[D1 14:24:43 elevator_2] Reopening doors
[D1 14:24:44 citizen_154] Time to go to floor 3 and stay there for 00:33:43
[D1 14:24:44 floor_4] citizen_154 entered the queue
[D1 14:24:44 floor_4] citizen_154 is queued along with 0 other arrivals in front of it
[D1 14:24:45 elevator_1] Closing doors
[D1 14:24:48 elevator_1] Closed doors
[D1 14:24:55 elevator_2] Closing doors
[D1 14:24:58 elevator_1] At floor 3
[D1 14:24:58 elevator_2] Closed doors
[D1 14:25:08 elevator_1] At floor 4
[D1 14:25:08 elevator_1] Stopped at floor 4
[D1 14:25:08 elevator_1] Opening doors
[D1 14:25:08 elevator_2] At floor 3
[D1 14:25:08 elevator_2] Stopped at floor 3
[D1 14:25:08 elevator_2] Opening doors
[D1 14:25:11 elevator_1] Opened doors
[D1 14:25:11 elevator_2] Opened doors
[D1 14:25:11 citizen_151] Left elevator_2, arrived at floor 3
[D1 14:25:11 citizen_136] Entered elevator_1, going to floor 1
[D1 14:25:11 floor_4] citizen_136 is leaving the queue
[D1 14:25:11 floor_4] citizen_154 was served
[D1 14:25:11 elevator_1] Summoned to floor 4 from floor 4
[D1 14:25:11 citizen_154] Entered elevator_1, going to floor 3
[D1 14:25:11 floor_4] citizen_154 is leaving the queue
[D1 14:25:11 floor_4] The queue is now empty
[D1 14:25:23 elevator_1] Closing doors
[D1 14:25:23 elevator_2] Closing doors
[D1 14:25:26 elevator_1] Closed doors
[D1 14:25:26 elevator_2] Closed doors
[D1 14:25:26 elevator_1] Changing direction to Down
[D1 14:25:36 elevator_1] At floor 3
[D1 14:25:36 elevator_1] Stopped at floor 3
[D1 14:25:36 elevator_1] Opening doors
[D1 14:25:36 elevator_2] At floor 4
[D1 14:25:36 elevator_2] Stopped at floor 4
[D1 14:25:36 elevator_2] Opening doors
[D1 14:25:39 elevator_1] Opened doors
[D1 14:25:39 elevator_2] Opened doors
[D1 14:25:39 citizen_154] Left elevator_1, arrived at floor 3
[D1 14:25:39 citizen_163] Left elevator_2, arrived at floor 4
[D1 14:25:51 elevator_1] Closing doors
[D1 14:25:51 elevator_2] Closing doors
[D1 14:25:54 elevator_1] Closed doors
[D1 14:25:54 elevator_2] Closed doors
[D1 14:26:04 elevator_1] At floor 2
[D1 14:26:04 elevator_2] At floor 5
[D1 14:26:04 elevator_2] Stopped at floor 5
[D1 14:26:04 elevator_2] Opening doors
[D1 14:26:07 elevator_2] Opened doors
[D1 14:26:07 citizen_148] Left elevator_2, arrived at floor 5
[D1 14:26:13 citizen_164] Entered the building, will visit 4 floors in total
[D1 14:26:13 citizen_164] Time to go to floor 5 and stay there for 00:27:02
[D1 14:26:13 floor_0] citizen_164 entered the queue
[D1 14:26:13 floor_0] citizen_164 found an empty queue and will be served immediately
[D1 14:26:13 elevator_1] Summoned to floor 0 from floor 2
[D1 14:26:14 elevator_1] At floor 1
[D1 14:26:14 elevator_1] Stopped at floor 1
[D1 14:26:14 elevator_1] Opening doors
[D1 14:26:17 elevator_1] Opened doors
[D1 14:26:17 citizen_113] Left elevator_1, arrived at floor 1
[D1 14:26:17 citizen_136] Left elevator_1, arrived at floor 1
[D1 14:26:19 elevator_2] Closing doors
[D1 14:26:20 citizen_128] Time to go to floor 5 and stay there for 00:28:23
[D1 14:26:20 floor_3] citizen_128 entered the queue
[D1 14:26:20 floor_3] citizen_128 found an empty queue and will be served immediately
[D1 14:26:20 elevator_1] Summoned to floor 3 from floor 1
[D1 14:26:20 elevator_2] Summoned to floor 3 from floor 5
[D1 14:26:22 elevator_2] Closed doors
[D1 14:26:22 elevator_2] Changing direction to Down
[D1 14:26:29 elevator_1] Closing doors
[D1 14:26:32 elevator_2] At floor 4
[D1 14:26:32 elevator_1] Closed doors
[D1 14:26:36 citizen_120] Time to go to floor 1 and stay there for 00:32:33
[D1 14:26:36 floor_4] citizen_120 entered the queue
[D1 14:26:36 floor_4] citizen_120 found an empty queue and will be served immediately
[D1 14:26:36 elevator_2] Summoned to floor 4 from floor 4
[D1 14:26:42 elevator_2] At floor 3
[D1 14:26:42 elevator_2] Stopped at floor 3
[D1 14:26:42 elevator_2] Opening doors
[D1 14:26:42 elevator_1] At floor 0
[D1 14:26:42 elevator_1] Stopped at floor 0
[D1 14:26:42 elevator_1] Opening doors
[D1 14:26:45 elevator_2] Opened doors
[D1 14:26:45 elevator_1] Opened doors
[D1 14:26:45 citizen_128] Entered elevator_2, going to floor 5
[D1 14:26:45 citizen_164] Entered elevator_1, going to floor 5
[D1 14:26:45 floor_3] citizen_128 is leaving the queue
[D1 14:26:45 floor_3] The queue is now empty
[D1 14:26:45 floor_0] citizen_164 is leaving the queue
[D1 14:26:45 floor_0] The queue is now empty
[D1 14:26:49 citizen_109] Time to go to floor 5 and stay there for 00:40:18
[D1 14:26:49 floor_3] citizen_109 entered the queue
[D1 14:26:49 floor_3] citizen_109 found an empty queue and will be served immediately
[D1 14:26:49 elevator_2] Summoned to floor 3 from floor 3
[D1 14:26:49 citizen_109] Entered elevator_2, going to floor 5
[D1 14:26:49 floor_3] citizen_109 is leaving the queue
[D1 14:26:49 floor_3] The queue is now empty
[D1 14:26:57 elevator_2] Closing doors
[D1 14:26:57 elevator_1] Closing doors
[D1 14:27:00 elevator_2] Closed doors
[D1 14:27:00 elevator_1] Closed doors
[D1 14:27:00 elevator_2] Changing direction to Up
[D1 14:27:00 elevator_1] Changing direction to Up
[D1 14:27:08 citizen_132] Time to go to floor 2 and stay there for 00:38:46
[D1 14:27:08 floor_3] citizen_132 entered the queue
[D1 14:27:08 floor_3] citizen_132 found an empty queue and will be served immediately
[D1 14:27:08 elevator_2] Summoned to floor 3 from floor 3
[D1 14:27:08 citizen_122] Time to go to the ground floor and leave
[D1 14:27:08 floor_1] citizen_122 entered the queue
[D1 14:27:08 floor_1] citizen_122 found an empty queue and will be served immediately
[D1 14:27:08 elevator_1] Summoned to floor 1 from floor 0
[D1 14:27:10 elevator_2] At floor 4
[D1 14:27:10 elevator_2] Stopped at floor 4
[D1 14:27:10 elevator_2] Opening doors
[D1 14:27:10 elevator_1] At floor 1
[D1 14:27:10 elevator_1] Stopped at floor 1
[D1 14:27:10 elevator_1] Opening doors
[D1 14:27:13 elevator_2] Opened doors
[D1 14:27:13 elevator_1] Opened doors
[D1 14:27:13 citizen_120] Entered elevator_2, going to floor 1
[D1 14:27:13 citizen_122] Entered elevator_1, going to floor 0
[D1 14:27:13 floor_4] citizen_120 is leaving the queue
[D1 14:27:13 floor_4] The queue is now empty
[D1 14:27:13 floor_1] citizen_122 is leaving the queue
[D1 14:27:13 floor_1] The queue is now empty
[D1 14:27:25 elevator_1] Closing doors
[D1 14:27:25 elevator_2] Closing doors
[D1 14:27:28 elevator_1] Closed doors
[D1 14:27:28 elevator_2] Closed doors
[D1 14:27:38 elevator_1] At floor 2
[D1 14:27:38 elevator_2] At floor 5
[D1 14:27:38 elevator_2] Stopped at floor 5
[D1 14:27:38 elevator_2] Opening doors
[D1 14:27:41 elevator_2] Opened doors
[D1 14:27:41 citizen_128] Left elevator_2, arrived at floor 5
[D1 14:27:41 citizen_109] Left elevator_2, arrived at floor 5
[D1 14:27:48 elevator_1] At floor 3
[D1 14:27:48 elevator_1] Stopped at floor 3
[D1 14:27:48 elevator_1] Opening doors
[D1 14:27:51 citizen_124] Time to go to floor 2 and stay there for 00:41:35
[D1 14:27:51 floor_5] citizen_124 entered the queue
[D1 14:27:51 floor_5] citizen_124 found an empty queue and will be served immediately
[D1 14:27:51 elevator_2] Summoned to floor 5 from floor 5
[D1 14:27:51 citizen_124] Entered elevator_2, going to floor 2
[D1 14:27:51 floor_5] citizen_124 is leaving the queue
[D1 14:27:51 floor_5] The queue is now empty
[D1 14:27:51 elevator_1] Opened doors
[D1 14:27:53 elevator_2] Closing doors
[D1 14:27:56 elevator_2] Closed doors
[D1 14:27:56 elevator_2] Changing direction to Down
[D1 14:28:03 elevator_1] Closing doors
[D1 14:28:04 citizen_112] Time to go to the ground floor and leave
[D1 14:28:04 floor_4] citizen_112 entered the queue
[D1 14:28:04 floor_4] citizen_112 found an empty queue and will be served immediately
[D1 14:28:04 elevator_1] Summoned to floor 4 from floor 3
[D1 14:28:04 elevator_2] Summoned to floor 4 from floor 5
[D1 14:28:06 elevator_2] At floor 4
[D1 14:28:06 elevator_2] Stopped at floor 4
[D1 14:28:06 elevator_2] Opening doors
[D1 14:28:06 elevator_1] Closed doors
[D1 14:28:09 elevator_2] Opened doors
[D1 14:28:09 citizen_112] Entered elevator_2, going to floor 0
[D1 14:28:09 floor_4] citizen_112 is leaving the queue
[D1 14:28:09 floor_4] The queue is now empty
[D1 14:28:16 elevator_1] At floor 4
[D1 14:28:16 elevator_1] Stopped at floor 4
[D1 14:28:16 elevator_1] Opening doors
[D1 14:28:19 elevator_1] Opened doors
[D1 14:28:21 elevator_2] Closing doors
[D1 14:28:24 elevator_2] Closed doors
[D1 14:28:31 elevator_1] Closing doors
[D1 14:28:34 elevator_2] At floor 3
[D1 14:28:34 elevator_2] Stopped at floor 3
[D1 14:28:34 elevator_2] Opening doors
[D1 14:28:34 elevator_1] Closed doors
[D1 14:28:37 elevator_2] Opened doors
[D1 14:28:37 citizen_132] Entered elevator_2, going to floor 2
[D1 14:28:37 floor_3] citizen_132 is leaving the queue
[D1 14:28:37 floor_3] The queue is now empty
[D1 14:28:44 elevator_1] At floor 5
[D1 14:28:44 elevator_1] Stopped at floor 5
[D1 14:28:44 elevator_1] Opening doors
[D1 14:28:47 elevator_1] Opened doors
[D1 14:28:47 citizen_164] Left elevator_1, arrived at floor 5
[D1 14:28:49 elevator_2] Closing doors
[D1 14:28:49 citizen_160] Time to go to floor 3 and stay there for 00:42:20
[D1 14:28:49 floor_2] citizen_160 entered the queue
[D1 14:28:49 floor_2] citizen_160 found an empty queue and will be served immediately
[D1 14:28:49 elevator_2] Summoned to floor 2 from floor 3
[D1 14:28:52 elevator_2] Closed doors
[D1 14:28:54 citizen_135] Time to go to floor 4 and stay there for 00:25:22
[D1 14:28:54 floor_2] citizen_135 entered the queue
[D1 14:28:54 floor_2] citizen_135 is queued along with 0 other arrivals in front of it
[D1 14:28:56 citizen_141] Time to go to floor 3 and stay there for 00:33:59
[D1 14:28:56 floor_5] citizen_141 entered the queue
[D1 14:28:56 floor_5] citizen_141 found an empty queue and will be served immediately
[D1 14:28:56 elevator_1] Summoned to floor 5 from floor 5
[D1 14:28:56 citizen_141] Entered elevator_1, going to floor 3
[D1 14:28:56 floor_5] citizen_141 is leaving the queue
[D1 14:28:56 floor_5] The queue is now empty
[D1 14:28:59 elevator_1] Closing doors
[D1 14:29:02 elevator_2] At floor 2
[D1 14:29:02 elevator_2] Stopped at floor 2
[D1 14:29:02 elevator_2] Opening doors
[D1 14:29:02 elevator_1] Closed doors
[D1 14:29:02 elevator_1] Changing direction to Down
[D1 14:29:05 elevator_2] Opened doors
[D1 14:29:05 citizen_124] Left elevator_2, arrived at floor 2
[D1 14:29:05 citizen_132] Left elevator_2, arrived at floor 2
[D1 14:29:05 citizen_160] Entered elevator_2, going to floor 3
[D1 14:29:05 floor_2] citizen_160 is leaving the queue
[D1 14:29:05 floor_2] citizen_135 was served
[D1 14:29:05 elevator_2] Summoned to floor 2 from floor 2
[D1 14:29:05 citizen_135] Entered elevator_2, going to floor 4
[D1 14:29:05 floor_2] citizen_135 is leaving the queue
[D1 14:29:05 floor_2] The queue is now empty
[D1 14:29:11 citizen_158] Time to go to floor 4 and stay there for 00:22:26
[D1 14:29:11 floor_3] citizen_158 entered the queue
[D1 14:29:11 floor_3] citizen_158 found an empty queue and will be served immediately
[D1 14:29:11 elevator_2] Summoned to floor 3 from floor 2
[D1 14:29:12 elevator_1] At floor 4
[D1 14:29:17 elevator_2] Closing doors
[D1 14:29:18 citizen_165] Entered the building, will visit 3 floors in total
[D1 14:29:18 citizen_165] Time to go to floor 3 and stay there for 00:20:15
[D1 14:29:18 floor_0] citizen_165 entered the queue
[D1 14:29:18 floor_0] citizen_165 found an empty queue and will be served immediately
[D1 14:29:18 elevator_2] Summoned to floor 0 from floor 2
[D1 14:29:20 elevator_2] Closed doors
[D1 14:29:22 elevator_1] At floor 3
[D1 14:29:22 elevator_1] Stopped at floor 3
[D1 14:29:22 elevator_1] Opening doors
[D1 14:29:25 elevator_1] Opened doors
[D1 14:29:25 citizen_141] Left elevator_1, arrived at floor 3
[D1 14:29:29 citizen_137] Time to go to floor 3 and stay there for 00:33:49
[D1 14:29:29 floor_5] citizen_137 entered the queue
[D1 14:29:29 floor_5] citizen_137 found an empty queue and will be served immediately
[D1 14:29:29 elevator_1] Summoned to floor 5 from floor 3
[D1 14:29:30 elevator_2] At floor 1
[D1 14:29:30 elevator_2] Stopped at floor 1
[D1 14:29:30 elevator_2] Opening doors
[D1 14:29:33 elevator_2] Opened doors
[D1 14:29:33 citizen_120] Left elevator_2, arrived at floor 1
[D1 14:29:37 elevator_1] Closing doors
[D1 14:29:40 elevator_1] Closed doors
[D1 14:29:45 elevator_2] Closing doors
[D1 14:29:48 elevator_2] Closed doors
[D1 14:29:50 elevator_1] At floor 2
[D1 14:29:58 elevator_2] At floor 0
[D1 14:29:58 elevator_2] Stopped at floor 0
[D1 14:29:58 elevator_2] Opening doors
[D1 14:30:00 elevator_1] At floor 1
[D1 14:30:01 elevator_2] Opened doors
[D1 14:30:01 citizen_112] Left elevator_2, arrived at floor 0
[D1 14:30:01 citizen_112] Left the building
[D1 14:30:01 citizen_165] Entered elevator_2, going to floor 3
[D1 14:30:01 floor_0] citizen_165 is leaving the queue
[D1 14:30:01 floor_0] The queue is now empty
[D1 14:30:10 elevator_1] At floor 0
[D1 14:30:10 elevator_1] Stopped at floor 0
[D1 14:30:10 elevator_1] Opening doors
[D1 14:30:13 elevator_2] Closing doors
[D1 14:30:13 elevator_1] Opened doors
[D1 14:30:13 citizen_122] Left elevator_1, arrived at floor 0
[D1 14:30:13 citizen_122] Left the building
[D1 14:30:16 citizen_152] Time to go to floor 2 and stay there for 00:50:53
[D1 14:30:16 floor_5] citizen_152 entered the queue
[D1 14:30:16 floor_5] citizen_152 is queued along with 0 other arrivals in front of it
[D1 14:30:16 citizen_104] Time to go to the ground floor and leave
[D1 14:30:16 floor_4] citizen_104 entered the queue
[D1 14:30:16 floor_4] citizen_104 found an empty queue and will be served immediately
[D1 14:30:16 elevator_1] Summoned to floor 4 from floor 0
[D1 14:30:16 elevator_2] Summoned to floor 4 from floor 0
[D1 14:30:16 elevator_2] Closed doors
[D1 14:30:16 elevator_2] Changing direction to Up
[D1 14:30:21 citizen_166] Entered the building, will visit 2 floors in total
[D1 14:30:21 citizen_166] Time to go to floor 2 and stay there for 00:28:14
[D1 14:30:21 floor_0] citizen_166 entered the queue
[D1 14:30:21 floor_0] citizen_166 found an empty queue and will be served immediately
[D1 14:30:21 elevator_1] Summoned to floor 0 from floor 0
[D1 14:30:21 elevator_2] Summoned to floor 0 from floor 0
[D1 14:30:21 citizen_166] Entered elevator_1, going to floor 2
[D1 14:30:21 floor_0] citizen_166 is leaving the queue
[D1 14:30:21 floor_0] The queue is now empty
[D1 14:30:25 elevator_1] Closing doors
[D1 14:30:26 elevator_2] At floor 1
[D1 14:30:28 elevator_1] Closed doors
[D1 14:30:28 elevator_1] Changing direction to Up
[D1 14:30:36 elevator_2] At floor 2
[D1 14:30:38 elevator_1] At floor 1
[D1 14:30:46 elevator_2] At floor 3
[D1 14:30:46 elevator_2] Stopped at floor 3
[D1 14:30:46 elevator_2] Opening doors
[D1 14:30:48 elevator_1] At floor 2
[D1 14:30:48 elevator_1] Stopped at floor 2
[D1 14:30:48 elevator_1] Opening doors
[D1 14:30:49 elevator_2] Opened doors
[D1 14:30:49 citizen_160] Left elevator_2, arrived at floor 3
[D1 14:30:49 citizen_165] Left elevator_2, arrived at floor 3
[D1 14:30:49 citizen_158] Entered elevator_2, going to floor 4
[D1 14:30:49 floor_3] citizen_158 is leaving the queue
[D1 14:30:49 floor_3] The queue is now empty
[D1 14:30:51 elevator_1] Opened doors
[D1 14:30:51 citizen_166] Left elevator_1, arrived at floor 2
[D1 14:31:01 elevator_2] Closing doors
[D1 14:31:03 elevator_1] Closing doors
[D1 14:31:04 elevator_2] Closed doors
[D1 14:31:06 elevator_1] Closed doors
[D1 14:31:14 elevator_2] At floor 4
[D1 14:31:14 elevator_2] Stopped at floor 4
[D1 14:31:14 elevator_2] Opening doors
[D1 14:31:16 elevator_1] At floor 3
[D1 14:31:17 elevator_2] Opened doors
[D1 14:31:17 citizen_135] Left elevator_2, arrived at floor 4
[D1 14:31:17 citizen_158] Left elevator_2, arrived at floor 4
[D1 14:31:17 citizen_104] Entered elevator_2, going to floor 0
[D1 14:31:17 floor_4] citizen_104 is leaving the queue
[D1 14:31:17 floor_4] The queue is now empty
[D1 14:31:26 elevator_1] At floor 4
[D1 14:31:26 elevator_1] Stopped at floor 4
[D1 14:31:26 elevator_1] Opening doors
[D1 14:31:29 elevator_2] Closing doors
[D1 14:31:29 elevator_1] Opened doors
[D1 14:31:32 elevator_2] Closed doors
[D1 14:31:32 elevator_2] Changing direction to Down
[D1 14:31:37 citizen_150] Time to go to floor 4 and stay there for 00:28:50
[D1 14:31:37 floor_1] citizen_150 entered the queue
[D1 14:31:37 floor_1] citizen_150 found an empty queue and will be served immediately
[D1 14:31:37 elevator_1] Summoned to floor 1 from floor 4
[D1 14:31:37 elevator_2] Summoned to floor 1 from floor 4
[D1 14:31:41 elevator_1] Closing doors
[D1 14:31:42 elevator_2] At floor 3
[D1 14:31:44 elevator_1] Closed doors
[D1 14:31:46 citizen_153] Time to go to floor 1 and stay there for 00:31:42
[D1 14:31:46 floor_4] citizen_153 entered the queue
[D1 14:31:46 floor_4] citizen_153 found an empty queue and will be served immediately
[D1 14:31:46 elevator_1] Summoned to floor 4 from floor 4
[D1 14:31:52 elevator_2] At floor 2
[D1 14:31:54 elevator_1] At floor 5
[D1 14:31:54 elevator_1] Stopped at floor 5
[D1 14:31:54 elevator_1] Opening doors
[D1 14:31:57 elevator_1] Opened doors
[D1 14:31:57 citizen_137] Entered elevator_1, going to floor 3
[D1 14:31:57 floor_5] citizen_137 is leaving the queue
[D1 14:31:57 floor_5] citizen_152 was served
[D1 14:31:57 elevator_1] Summoned to floor 5 from floor 5
[D1 14:31:57 citizen_152] Entered elevator_1, going to floor 2
[D1 14:31:57 floor_5] citizen_152 is leaving the queue
[D1 14:31:57 floor_5] The queue is now empty
[D1 14:32:02 elevator_2] At floor 1
[D1 14:32:02 elevator_2] Stopped at floor 1
[D1 14:32:02 elevator_2] Opening doors
[D1 14:32:05 elevator_2] Opened doors
[D1 14:32:05 citizen_150] Entered elevator_2, going to floor 4
[D1 14:32:05 floor_1] citizen_150 is leaving the queue
[D1 14:32:05 floor_1] The queue is now empty
[D1 14:32:09 elevator_1] Closing doors
[D1 14:32:12 elevator_1] Closed doors
[D1 14:32:12 elevator_1] Changing direction to Down
[D1 14:32:17 elevator_2] Closing doors
[D1 14:32:20 elevator_2] Closed doors
[D1 14:32:22 elevator_1] At floor 4
[D1 14:32:22 elevator_1] Stopped at floor 4
[D1 14:32:22 elevator_1] Opening doors
[D1 14:32:25 citizen_167] Entered the building, will visit 4 floors in total
[D1 14:32:25 citizen_167] Time to go to floor 1 and stay there for 00:28:42
[D1 14:32:25 floor_0] citizen_167 entered the queue
[D1 14:32:25 floor_0] citizen_167 found an empty queue and will be served immediately
[D1 14:32:25 elevator_2] Summoned to floor 0 from floor 1
[D1 14:32:25 elevator_1] Opened doors
[D1 14:32:25 citizen_153] Entered elevator_1, going to floor 1
[D1 14:32:25 floor_4] citizen_153 is leaving the queue
[D1 14:32:25 floor_4] The queue is now empty
[D1 14:32:30 elevator_2] At floor 0
[D1 14:32:30 elevator_2] Stopped at floor 0
[D1 14:32:30 elevator_2] Opening doors
[D1 14:32:33 elevator_2] Opened doors
[D1 14:32:33 citizen_104] Left elevator_2, arrived at floor 0
[D1 14:32:33 citizen_104] Left the building
[D1 14:32:33 citizen_167] Entered elevator_2, going to floor 1
[D1 14:32:33 floor_0] citizen_167 is leaving the queue
[D1 14:32:33 floor_0] The queue is now empty
[D1 14:32:37 elevator_1] Closing doors
[D1 14:32:40 elevator_1] Closed doors
[D1 14:32:45 elevator_2] Closing doors
[D1 14:32:48 elevator_2] Closed doors
[D1 14:32:48 elevator_2] Changing direction to Up
[D1 14:32:50 citizen_99] Time to go to the ground floor and leave
[D1 14:32:50 floor_2] citizen_99 entered the queue
[D1 14:32:50 floor_2] citizen_99 found an empty queue and will be served immediately
[D1 14:32:50 elevator_1] Summoned to floor 2 from floor 4
[D1 14:32:50 elevator_2] Summoned to floor 2 from floor 0
[D1 14:32:50 elevator_1] At floor 3
[D1 14:32:50 elevator_1] Stopped at floor 3
[D1 14:32:50 elevator_1] Opening doors
[D1 14:32:53 elevator_1] Opened doors
[D1 14:32:53 citizen_137] Left elevator_1, arrived at floor 3
[D1 14:32:58 citizen_144] Time to go to floor 5 and stay there for 00:29:09
[D1 14:32:58 floor_2] citizen_144 entered the queue
[D1 14:32:58 floor_2] citizen_144 is queued along with 0 other arrivals in front of it
[D1 14:32:58 elevator_2] At floor 1
[D1 14:32:58 elevator_2] Stopped at floor 1
[D1 14:32:58 elevator_2] Opening doors
[D1 14:33:01 elevator_2] Opened doors
[D1 14:33:01 citizen_167] Left elevator_2, arrived at floor 1
[D1 14:33:05 elevator_1] Closing doors
[D1 14:33:08 elevator_1] Closed doors
[D1 14:33:13 elevator_2] Closing doors
[D1 14:33:16 elevator_2] Closed doors
[D1 14:33:18 elevator_1] At floor 2
[D1 14:33:18 elevator_1] Stopped at floor 2
[D1 14:33:18 elevator_1] Opening doors
[D1 14:33:21 elevator_1] Opened doors
[D1 14:33:21 citizen_152] Left elevator_1, arrived at floor 2
[D1 14:33:21 citizen_99] Entered elevator_1, going to floor 0
[D1 14:33:21 floor_2] citizen_99 is leaving the queue
[D1 14:33:21 floor_2] citizen_144 was served
[D1 14:33:21 elevator_1] Summoned to floor 2 from floor 2
[D1 14:33:21 citizen_144] Entered elevator_1, going to floor 5
[D1 14:33:21 floor_2] citizen_144 is leaving the queue
[D1 14:33:21 floor_2] The queue is now empty
[D1 14:33:23 citizen_102] Time to go to the ground floor and leave
[D1 14:33:23 floor_5] citizen_102 entered the queue
[D1 14:33:23 floor_5] citizen_102 found an empty queue and will be served immediately
[D1 14:33:23 elevator_1] Summoned to floor 5 from floor 2
[D1 14:33:26 elevator_2] At floor 2
[D1 14:33:26 elevator_2] Stopped at floor 2
[D1 14:33:26 elevator_2] Opening doors
[D1 14:33:29 elevator_2] Opened doors
[D1 14:33:33 elevator_1] Closing doors
[D1 14:33:36 elevator_1] Closed doors
[D1 14:33:41 elevator_2] Closing doors
[D1 14:33:44 elevator_2] Closed doors
[D1 14:33:46 elevator_1] At floor 1
[D1 14:33:46 elevator_1] Stopped at floor 1
[D1 14:33:46 elevator_1] Opening doors
[D1 14:33:49 elevator_1] Opened doors
[D1 14:33:49 citizen_153] Left elevator_1, arrived at floor 1
[D1 14:33:54 elevator_2] At floor 3
[D1 14:34:01 elevator_1] Closing doors
[D1 14:34:04 elevator_2] At floor 4
[D1 14:34:04 elevator_2] Stopped at floor 4
[D1 14:34:04 elevator_2] Opening doors
[D1 14:34:04 elevator_1] Closed doors
[D1 14:34:07 elevator_2] Opened doors
[D1 14:34:07 citizen_150] Left elevator_2, arrived at floor 4
[D1 14:34:14 citizen_168] Entered the building, will visit 3 floors in total
[D1 14:34:14 citizen_168] Time to go to floor 3 and stay there for 00:32:07
[D1 14:34:14 floor_0] citizen_168 entered the queue
[D1 14:34:14 floor_0] citizen_168 found an empty queue and will be served immediately
[D1 14:34:14 elevator_1] Summoned to floor 0 from floor 1
[D1 14:34:14 elevator_1] At floor 0
[D1 14:34:14 elevator_1] Stopped at floor 0
[D1 14:34:14 elevator_1] Opening doors
[D1 14:34:17 elevator_1] Opened doors
[D1 14:34:17 citizen_99] Left elevator_1, arrived at floor 0
[D1 14:34:17 citizen_99] Left the building
[D1 14:34:17 citizen_168] Entered elevator_1, going to floor 3
[D1 14:34:17 floor_0] citizen_168 is leaving the queue
[D1 14:34:17 floor_0] The queue is now empty
[D1 14:34:19 elevator_2] Closing doors
[D1 14:34:22 elevator_2] Closed doors
[D1 14:34:22 elevator_2] Resting at floor 4
[D1 14:34:29 elevator_1] Closing doors
[D1 14:34:32 elevator_1] Closed doors
[D1 14:34:32 elevator_1] Changing direction to Up
[D1 14:34:42 elevator_1] At floor 1
[D1 14:34:52 elevator_1] At floor 2
[D1 14:35:00 citizen_155] Time to go to floor 3 and stay there for 00:19:02
[D1 14:35:00 floor_2] citizen_155 entered the queue
[D1 14:35:00 floor_2] citizen_155 found an empty queue and will be served immediately
[D1 14:35:00 elevator_1] Summoned to floor 2 from floor 2
[D1 14:35:02 elevator_1] At floor 3
[D1 14:35:02 elevator_1] Stopped at floor 3
[D1 14:35:02 elevator_1] Opening doors
[D1 14:35:05 elevator_1] Opened doors
[D1 14:35:05 citizen_168] Left elevator_1, arrived at floor 3
[D1 14:35:06 citizen_156] Time to go to floor 2 and stay there for 00:30:52
[D1 14:35:06 floor_4] citizen_156 entered the queue
[D1 14:35:06 floor_4] citizen_156 found an empty queue and will be served immediately
[D1 14:35:06 elevator_2] Summoned to floor 4 from floor 4
[D1 14:35:06 elevator_2] Opening doors
[D1 14:35:09 elevator_2] Opened doors
[D1 14:35:09 citizen_156] Entered elevator_2, going to floor 2
[D1 14:35:09 floor_4] citizen_156 is leaving the queue
[D1 14:35:09 floor_4] The queue is now empty
[D1 14:35:17 elevator_1] Closing doors
[D1 14:35:20 elevator_1] Closed doors
[D1 14:35:21 elevator_2] Closing doors
[D1 14:35:24 elevator_2] Closed doors
[D1 14:35:24 elevator_2] Sprung into motion, heading Down
[D1 14:35:30 elevator_1] At floor 4
[D1 14:35:34 elevator_2] At floor 3
[D1 14:35:40 elevator_1] At floor 5
[D1 14:35:40 elevator_1] Stopped at floor 5
[D1 14:35:40 elevator_1] Opening doors
[D1 14:35:43 elevator_1] Opened doors
[D1 14:35:43 citizen_144] Left elevator_1, arrived at floor 5
[D1 14:35:43 citizen_102] Entered elevator_1, going to floor 0
[D1 14:35:43 floor_5] citizen_102 is leaving the queue
[D1 14:35:43 floor_5] The queue is now empty
[D1 14:35:44 elevator_2] At floor 2
[D1 14:35:44 elevator_2] Stopped at floor 2
[D1 14:35:44 elevator_2] Opening doors
[D1 14:35:47 elevator_2] Opened doors
[D1 14:35:47 citizen_156] Left elevator_2, arrived at floor 2
[D1 14:35:55 elevator_1] Closing doors
[D1 14:35:58 elevator_1] Closed doors
[D1 14:35:58 elevator_1] Changing direction to Down
[D1 14:35:59 elevator_2] Closing doors
[D1 14:36:02 elevator_2] Closed doors
[D1 14:36:02 elevator_2] Resting at floor 2
[D1 14:36:08 citizen_123] Time to go to floor 5 and stay there for 00:35:00
[D1 14:36:08 floor_1] citizen_123 entered the queue
[D1 14:36:08 floor_1] citizen_123 found an empty queue and will be served immediately
[D1 14:36:08 elevator_2] Summoned to floor 1 from floor 2
[D1 14:36:08 elevator_2] Sprung into motion, heading Down
[D1 14:36:08 elevator_1] At floor 4
[D1 14:36:18 elevator_2] At floor 1
[D1 14:36:18 elevator_2] Stopped at floor 1
[D1 14:36:18 elevator_2] Opening doors
[D1 14:36:18 elevator_1] At floor 3
[D1 14:36:21 elevator_2] Opened doors
[D1 14:36:21 citizen_123] Entered elevator_2, going to floor 5
[D1 14:36:21 floor_1] citizen_123 is leaving the queue
[D1 14:36:21 floor_1] The queue is now empty
[D1 14:36:28 elevator_1] At floor 2
[D1 14:36:28 elevator_1] Stopped at floor 2
[D1 14:36:28 elevator_1] Opening doors
[D1 14:36:31 elevator_1] Opened doors
[D1 14:36:31 citizen_155] Entered elevator_1, going to floor 3
[D1 14:36:31 floor_2] citizen_155 is leaving the queue
[D1 14:36:31 floor_2] The queue is now empty
[D1 14:36:33 elevator_2] Closing doors
[D1 14:36:36 elevator_2] Closed doors
[D1 14:36:36 elevator_2] Changing direction to Up
[D1 14:36:40 citizen_116] Time to go to floor 2 and stay there for 00:32:00
[D1 14:36:40 floor_5] citizen_116 entered the queue
[D1 14:36:40 floor_5] citizen_116 found an empty queue and will be served immediately
[D1 14:36:40 elevator_1] Summoned to floor 5 from floor 2
[D1 14:36:43 elevator_1] Closing doors
[D1 14:36:46 elevator_2] At floor 2
[D1 14:36:46 elevator_1] Closed doors
[D1 14:36:56 citizen_159] Time to go to floor 4 and stay there for 00:19:49
[D1 14:36:56 floor_3] citizen_159 entered the queue
[D1 14:36:56 floor_3] citizen_159 found an empty queue and will be served immediately
[D1 14:36:56 elevator_1] Summoned to floor 3 from floor 2
[D1 14:36:56 elevator_2] Summoned to floor 3 from floor 2
[D1 14:36:56 elevator_2] At floor 3
[D1 14:36:56 elevator_2] Stopped at floor 3
[D1 14:36:56 elevator_2] Opening doors
[D1 14:36:56 elevator_1] At floor 1
[D1 14:36:59 elevator_2] Opened doors
[D1 14:36:59 citizen_159] Entered elevator_2, going to floor 4
[D1 14:36:59 floor_3] citizen_159 is leaving the queue
[D1 14:36:59 floor_3] The queue is now empty
[D1 14:37:06 elevator_1] At floor 0
[D1 14:37:06 elevator_1] Stopped at floor 0
[D1 14:37:06 elevator_1] Opening doors
[D1 14:37:09 elevator_1] Opened doors
[D1 14:37:09 citizen_102] Left elevator_1, arrived at floor 0
[D1 14:37:09 citizen_102] Left the building
[D1 14:37:11 elevator_2] Closing doors
[D1 14:37:14 elevator_2] Closed doors
[D1 14:37:21 elevator_1] Closing doors
[D1 14:37:24 elevator_2] At floor 4
[D1 14:37:24 elevator_2] Stopped at floor 4
[D1 14:37:24 elevator_2] Opening doors
[D1 14:37:24 elevator_1] Closed doors
[D1 14:37:24 elevator_1] Changing direction to Up
[D1 14:37:27 elevator_2] Opened doors
[D1 14:37:27 citizen_159] Left elevator_2, arrived at floor 4
[D1 14:37:34 elevator_1] At floor 1
[D1 14:37:39 elevator_2] Closing doors
[D1 14:37:42 elevator_2] Closed doors
[D1 14:37:44 elevator_1] At floor 2
[D1 14:37:52 elevator_2] At floor 5
[D1 14:37:52 elevator_2] Stopped at floor 5
[D1 14:37:52 elevator_2] Opening doors
[D1 14:37:54 elevator_1] At floor 3
[D1 14:37:54 elevator_1] Stopped at floor 3
[D1 14:37:54 elevator_1] Opening doors
[D1 14:37:55 elevator_2] Opened doors
[D1 14:37:55 citizen_123] Left elevator_2, arrived at floor 5
[D1 14:37:57 elevator_1] Opened doors
[D1 14:37:57 citizen_155] Left elevator_1, arrived at floor 3
[D1 14:37:58 citizen_129] Time to go to floor 1 and stay there for 00:30:43
[D1 14:37:58 floor_5] citizen_129 entered the queue
[D1 14:37:58 floor_5] citizen_129 is queued along with 0 other arrivals in front of it
[D1 14:38:07 elevator_2] Closing doors
[D1 14:38:09 elevator_1] Closing doors
[D1 14:38:10 elevator_2] Closed doors
[D1 14:38:10 elevator_2] Resting at floor 5
[D1 14:38:12 elevator_1] Closed doors
[D1 14:38:20 citizen_138] Time to go to floor 2 and stay there for 00:27:40
[D1 14:38:20 floor_1] citizen_138 entered the queue
[D1 14:38:20 floor_1] citizen_138 found an empty queue and will be served immediately
[D1 14:38:20 elevator_1] Summoned to floor 1 from floor 3
[D1 14:38:22 elevator_1] At floor 4
[D1 14:38:32 elevator_1] At floor 5
[D1 14:38:32 elevator_1] Stopped at floor 5
[D1 14:38:32 elevator_1] Opening doors
[D1 14:38:35 elevator_1] Opened doors
[D1 14:38:35 citizen_116] Entered elevator_1, going to floor 2
[D1 14:38:35 floor_5] citizen_116 is leaving the queue
[D1 14:38:35 floor_5] citizen_129 was served
[D1 14:38:35 elevator_1] Summoned to floor 5 from floor 5
[D1 14:38:35 elevator_2] Summoned to floor 5 from floor 5
[D1 14:38:35 elevator_2] Opening doors
[D1 14:38:35 citizen_129] Entered elevator_1, going to floor 1
[D1 14:38:35 floor_5] citizen_129 is leaving the queue
[D1 14:38:35 floor_5] The queue is now empty
[D1 14:38:36 citizen_143] Time to go to floor 3 and stay there for 00:28:06
[D1 14:38:36 floor_2] citizen_143 entered the queue
[D1 14:38:36 floor_2] citizen_143 found an empty queue and will be served immediately
[D1 14:38:36 elevator_1] Summoned to floor 2 from floor 5
[D1 14:38:36 elevator_2] Summoned to floor 2 from floor 5
[D1 14:38:38 elevator_2] Opened doors
[D1 14:38:42 citizen_134] Time to go to floor 4 and stay there for 00:35:58
[D1 14:38:42 floor_3] citizen_134 entered the queue
[D1 14:38:42 floor_3] citizen_134 found an empty queue and will be served immediately
[D1 14:38:42 elevator_1] Summoned to floor 3 from floor 5
[D1 14:38:42 elevator_2] Summoned to floor 3 from floor 5
[D1 14:38:47 elevator_1] Closing doors
[D1 14:38:50 elevator_2] Closing doors
[D1 14:38:50 elevator_1] Closed doors
[D1 14:38:50 elevator_1] Changing direction to Down
[D1 14:38:53 elevator_2] Closed doors
[D1 14:38:53 elevator_2] Sprung into motion, heading Down
[D1 14:39:00 elevator_1] At floor 4
[D1 14:39:03 elevator_2] At floor 4
[D1 14:39:10 elevator_1] At floor 3
[D1 14:39:10 elevator_1] Stopped at floor 3
[D1 14:39:10 elevator_1] Opening doors
[D1 14:39:13 elevator_2] At floor 3
[D1 14:39:13 elevator_2] Stopped at floor 3
[D1 14:39:13 elevator_2] Opening doors
[D1 14:39:13 elevator_1] Opened doors
[D1 14:39:13 citizen_134] Entered elevator_1, going to floor 4
[D1 14:39:13 floor_3] citizen_134 is leaving the queue
[D1 14:39:13 floor_3] The queue is now empty
[D1 14:39:16 elevator_2] Opened doors
[D1 14:39:25 elevator_1] Closing doors
[D1 14:39:28 elevator_2] Closing doors
[D1 14:39:28 elevator_1] Closed doors
[D1 14:39:31 elevator_2] Closed doors
[D1 14:39:38 elevator_1] At floor 2
[D1 14:39:38 elevator_1] Stopped at floor 2
[D1 14:39:38 elevator_1] Opening doors
[D1 14:39:41 elevator_2] At floor 2
[D1 14:39:41 elevator_2] Stopped at floor 2
[D1 14:39:41 elevator_2] Opening doors
[D1 14:39:41 elevator_1] Opened doors
[D1 14:39:41 citizen_116] Left elevator_1, arrived at floor 2
[D1 14:39:41 citizen_143] Entered elevator_1, going to floor 3
[D1 14:39:41 floor_2] citizen_143 is leaving the queue
[D1 14:39:41 floor_2] The queue is now empty
[D1 14:39:44 elevator_2] Opened doors
[D1 14:39:53 elevator_1] Closing doors
[D1 14:39:56 elevator_2] Closing doors
[D1 14:39:56 elevator_1] Closed doors
[D1 14:39:59 elevator_2] Closed doors
[D1 14:39:59 elevator_2] Resting at floor 2
[D1 14:40:02 citizen_139] Time to go to floor 2 and stay there for 00:39:42
[D1 14:40:02 floor_3] citizen_139 entered the queue
[D1 14:40:02 floor_3] citizen_139 found an empty queue and will be served immediately
[D1 14:40:02 elevator_1] Summoned to floor 3 from floor 2
[D1 14:40:02 elevator_2] Summoned to floor 3 from floor 2
[D1 14:40:02 elevator_2] Sprung into motion, heading Up
[D1 14:40:06 elevator_1] At floor 1
[D1 14:40:06 elevator_1] Stopped at floor 1
[D1 14:40:06 elevator_1] Opening doors
[D1 14:40:09 elevator_1] Opened doors
[D1 14:40:09 citizen_129] Left elevator_1, arrived at floor 1
[D1 14:40:09 citizen_138] Entered elevator_1, going to floor 2
[D1 14:40:09 floor_1] citizen_138 is leaving the queue
[D1 14:40:09 floor_1] The queue is now empty
[D1 14:40:12 elevator_2] At floor 3
[D1 14:40:12 elevator_2] Stopped at floor 3
[D1 14:40:12 elevator_2] Opening doors
[D1 14:40:15 elevator_2] Opened doors
[D1 14:40:15 citizen_139] Entered elevator_2, going to floor 2
[D1 14:40:15 floor_3] citizen_139 is leaving the queue
[D1 14:40:15 floor_3] The queue is now empty
[D1 14:40:21 elevator_1] Closing doors
[D1 14:40:24 elevator_1] Closed doors
[D1 14:40:24 elevator_1] Changing direction to Up
[D1 14:40:27 elevator_2] Closing doors
[D1 14:40:30 elevator_2] Closed doors
[D1 14:40:30 elevator_2] Changing direction to Down
[D1 14:40:34 elevator_1] At floor 2
[D1 14:40:34 elevator_1] Stopped at floor 2
[D1 14:40:34 elevator_1] Opening doors
[D1 14:40:37 elevator_1] Opened doors
[D1 14:40:37 citizen_138] Left elevator_1, arrived at floor 2
[D1 14:40:38 citizen_107] Time to go to floor 5 and stay there for 00:19:45
[D1 14:40:38 floor_4] citizen_107 entered the queue
[D1 14:40:38 floor_4] citizen_107 found an empty queue and will be served immediately
[D1 14:40:38 elevator_2] Summoned to floor 4 from floor 3
[D1 14:40:40 elevator_2] At floor 2
[D1 14:40:40 elevator_2] Stopped at floor 2
[D1 14:40:40 elevator_2] Opening doors
[D1 14:40:43 elevator_2] Opened doors
[D1 14:40:43 citizen_139] Left elevator_2, arrived at floor 2
[D1 14:40:49 elevator_1] Closing doors
[D1 14:40:52 elevator_1] Closed doors
[D1 14:40:55 elevator_2] Closing doors
[D1 14:40:58 elevator_2] Closed doors
[D1 14:40:58 elevator_2] Changing direction to Up
[D1 14:41:02 elevator_1] At floor 3
[D1 14:41:02 elevator_1] Stopped at floor 3
[D1 14:41:02 elevator_1] Opening doors
[D1 14:41:05 elevator_1] Opened doors
[D1 14:41:05 citizen_143] Left elevator_1, arrived at floor 3
[D1 14:41:08 elevator_2] At floor 3
[D1 14:41:17 elevator_1] Closing doors
[D1 14:41:18 elevator_2] At floor 4
[D1 14:41:18 elevator_2] Stopped at floor 4
[D1 14:41:18 elevator_2] Opening doors
[D1 14:41:20 elevator_1] Closed doors
[D1 14:41:21 citizen_142] Time to go to floor 5 and stay there for 00:18:23
[D1 14:41:21 floor_3] citizen_142 entered the queue
[D1 14:41:21 floor_3] citizen_142 found an empty queue and will be served immediately
[D1 14:41:21 elevator_1] Summoned to floor 3 from floor 3
[D1 14:41:21 elevator_2] Opened doors
[D1 14:41:21 citizen_107] Entered elevator_2, going to floor 5
[D1 14:41:21 floor_4] citizen_107 is leaving the queue
[D1 14:41:21 floor_4] The queue is now empty
[D1 14:41:30 elevator_1] At floor 4
[D1 14:41:30 elevator_1] Stopped at floor 4
[D1 14:41:30 elevator_1] Opening doors
[D1 14:41:33 elevator_2] Closing doors
[D1 14:41:33 elevator_1] Opened doors
[D1 14:41:33 citizen_134] Left elevator_1, arrived at floor 4
[D1 14:41:36 elevator_2] Closed doors
[D1 14:41:45 elevator_1] Closing doors
[D1 14:41:45 citizen_157] Time to go to floor 3 and stay there for 00:36:53
[D1 14:41:45 floor_4] citizen_157 entered the queue
[D1 14:41:45 floor_4] citizen_157 found an empty queue and will be served immediately
[D1 14:41:45 elevator_1] Summoned to floor 4 from floor 4
[D1 14:41:45 elevator_2] Summoned to floor 4 from floor 4
[D1 14:41:46 elevator_2] At floor 5
[D1 14:41:46 elevator_2] Stopped at floor 5
[D1 14:41:46 elevator_2] Opening doors
[D1 14:41:48 elevator_1] Reopening doors
[D1 14:41:48 citizen_157] Entered elevator_1, going to floor 3
[D1 14:41:48 floor_4] citizen_157 is leaving the queue
[D1 14:41:48 floor_4] The queue is now empty
[D1 14:41:49 elevator_2] Opened doors
[D1 14:41:49 citizen_107] Left elevator_2, arrived at floor 5
[D1 14:42:00 citizen_130] Time to go to floor 2 and stay there for 00:40:06
[D1 14:42:00 floor_5] citizen_130 entered the queue
[D1 14:42:00 floor_5] citizen_130 found an empty queue and will be served immediately
[D1 14:42:00 elevator_2] Summoned to floor 5 from floor 5
[D1 14:42:00 citizen_130] Entered elevator_2, going to floor 2
[D1 14:42:00 floor_5] citizen_130 is leaving the queue
[D1 14:42:00 floor_5] The queue is now empty
[D1 14:42:00 elevator_1] Closing doors
[D1 14:42:01 elevator_2] Closing doors
[D1 14:42:03 elevator_1] Closed doors
[D1 14:42:03 elevator_1] Changing direction to Down
[D1 14:42:04 elevator_2] Closed doors
[D1 14:42:04 elevator_2] Changing direction to Down
[D1 14:42:13 elevator_1] At floor 3
[D1 14:42:13 elevator_1] Stopped at floor 3
[D1 14:42:13 elevator_1] Opening doors
[D1 14:42:14 elevator_2] At floor 4
[D1 14:42:14 elevator_2] Stopped at floor 4
[D1 14:42:14 elevator_2] Opening doors
[D1 14:42:16 elevator_1] Opened doors
[D1 14:42:16 citizen_157] Left elevator_1, arrived at floor 3
[D1 14:42:16 citizen_142] Entered elevator_1, going to floor 5
[D1 14:42:16 floor_3] citizen_142 is leaving the queue
[D1 14:42:16 floor_3] The queue is now empty
[D1 14:42:17 elevator_2] Opened doors
[D1 14:42:17 citizen_146] Time to go to floor 5 and stay there for 00:32:30
[D1 14:42:17 floor_2] citizen_146 entered the queue
[D1 14:42:17 floor_2] citizen_146 found an empty queue and will be served immediately
[D1 14:42:17 elevator_1] Summoned to floor 2 from floor 3
[D1 14:42:23 citizen_169] Entered the building, will visit 4 floors in total
[D1 14:42:23 citizen_169] Time to go to floor 2 and stay there for 00:42:50
[D1 14:42:23 floor_0] citizen_169 entered the queue
[D1 14:42:23 floor_0] citizen_169 found an empty queue and will be served immediately
[D1 14:42:23 elevator_1] Summoned to floor 0 from floor 3
[D1 14:42:28 elevator_1] Closing doors
[D1 14:42:29 elevator_2] Closing doors
[D1 14:42:31 elevator_1] Closed doors
[D1 14:42:32 elevator_2] Closed doors
[D1 14:42:36 citizen_140] Time to go to floor 3 and stay there for 00:29:37
[D1 14:42:36 floor_1] citizen_140 entered the queue
[D1 14:42:36 floor_1] citizen_140 found an empty queue and will be served immediately
[D1 14:42:36 elevator_1] Summoned to floor 1 from floor 3
[D1 14:42:41 elevator_1] At floor 2
[D1 14:42:41 elevator_1] Stopped at floor 2
[D1 14:42:41 elevator_1] Opening doors
[D1 14:42:42 citizen_145] Time to go to floor 3 and stay there for 00:37:17
[D1 14:42:42 floor_4] citizen_145 entered the queue
[D1 14:42:42 floor_4] citizen_145 found an empty queue and will be served immediately
[D1 14:42:42 elevator_2] Summoned to floor 4 from floor 4
[D1 14:42:42 elevator_2] At floor 3
[D1 14:42:44 elevator_1] Opened doors
[D1 14:42:44 citizen_146] Entered elevator_1, going to floor 5
[D1 14:42:44 floor_2] citizen_146 is leaving the queue
[D1 14:42:44 floor_2] The queue is now empty
[D1 14:42:48 citizen_147] Time to go to floor 4 and stay there for 00:30:29
[D1 14:42:48 floor_1] citizen_147 entered the queue
[D1 14:42:48 floor_1] citizen_147 is queued along with 0 other arrivals in front of it
[D1 14:42:52 elevator_2] At floor 2
[D1 14:42:52 elevator_2] Stopped at floor 2
[D1 14:42:52 elevator_2] Opening doors
[D1 14:42:55 elevator_2] Opened doors
[D1 14:42:55 citizen_130] Left elevator_2, arrived at floor 2
[D1 14:42:56 elevator_1] Closing doors
[D1 14:42:59 elevator_1] Closed doors
[D1 14:43:07 elevator_2] Closing doors
[D1 14:43:09 elevator_1] At floor 1
[D1 14:43:09 elevator_1] Stopped at floor 1
[D1 14:43:09 elevator_1] Opening doors
[D1 14:43:10 elevator_2] Closed doors
[D1 14:43:10 elevator_2] Changing direction to Up
[D1 14:43:11 citizen_161] Time to go to floor 1 and stay there for 00:29:51
[D1 14:43:11 floor_5] citizen_161 entered the queue
[D1 14:43:11 floor_5] citizen_161 found an empty queue and will be served immediately
[D1 14:43:11 elevator_2] Summoned to floor 5 from floor 2
[D1 14:43:12 elevator_1] Opened doors
[D1 14:43:12 citizen_140] Entered elevator_1, going to floor 3
[D1 14:43:12 floor_1] citizen_140 is leaving the queue
[D1 14:43:12 floor_1] citizen_147 was served
[D1 14:43:12 elevator_1] Summoned to floor 1 from floor 1
[D1 14:43:12 citizen_147] Entered elevator_1, going to floor 4
[D1 14:43:12 floor_1] citizen_147 is leaving the queue
[D1 14:43:12 floor_1] The queue is now empty
[D1 14:43:20 elevator_2] At floor 3
[D1 14:43:24 elevator_1] Closing doors
[D1 14:43:27 elevator_1] Closed doors
[D1 14:43:30 elevator_2] At floor 4
[D1 14:43:30 elevator_2] Stopped at floor 4
[D1 14:43:30 elevator_2] Opening doors
[D1 14:43:33 elevator_2] Opened doors
[D1 14:43:33 citizen_145] Entered elevator_2, going to floor 3
[D1 14:43:33 floor_4] citizen_145 is leaving the queue
[D1 14:43:33 floor_4] The queue is now empty
[D1 14:43:37 elevator_1] At floor 0
[D1 14:43:37 elevator_1] Stopped at floor 0
[D1 14:43:37 elevator_1] Opening doors
[D1 14:43:39 citizen_170] Entered the building, will visit 4 floors in total
[D1 14:43:39 citizen_170] Time to go to floor 1 and stay there for 00:22:12
[D1 14:43:39 floor_0] citizen_170 entered the queue
[D1 14:43:39 floor_0] citizen_170 is queued along with 0 other arrivals in front of it
[D1 14:43:40 elevator_1] Opened doors
[D1 14:43:40 citizen_169] Cannot enter elevator_1, it is full
[D1 14:43:40 citizen_169] All elevators were full, trying to summon them again
[D1 14:43:45 elevator_2] Closing doors
[D1 14:43:48 elevator_2] Closed doors
[D1 14:43:52 elevator_1] Closing doors
[D1 14:43:55 elevator_1] Closed doors
[D1 14:43:55 elevator_1] Changing direction to Up
[D1 14:43:56 elevator_1] Summoned to floor 0 from floor 0
[D1 14:43:58 elevator_2] At floor 5
[D1 14:43:58 elevator_2] Stopped at floor 5
[D1 14:43:58 elevator_2] Opening doors
[D1 14:44:01 elevator_2] Opened doors
[D1 14:44:01 citizen_161] Entered elevator_2, going to floor 1
[D1 14:44:01 floor_5] citizen_161 is leaving the queue
[D1 14:44:01 floor_5] The queue is now empty
[D1 14:44:05 elevator_1] At floor 1
[D1 14:44:13 elevator_2] Closing doors
[D1 14:44:15 elevator_1] At floor 2
[D1 14:44:16 elevator_2] Closed doors
[D1 14:44:16 elevator_2] Changing direction to Down
[D1 14:44:25 elevator_1] At floor 3
[D1 14:44:25 elevator_1] Stopped at floor 3
[D1 14:44:25 elevator_1] Opening doors
[D1 14:44:26 elevator_2] At floor 4
[D1 14:44:28 elevator_1] Opened doors
[D1 14:44:28 citizen_140] Left elevator_1, arrived at floor 3
[D1 14:44:31 citizen_125] Time to go to floor 4 and stay there for 00:39:41
[D1 14:44:31 floor_3] citizen_125 entered the queue
[D1 14:44:31 floor_3] citizen_125 found an empty queue and will be served immediately
[D1 14:44:31 elevator_1] Summoned to floor 3 from floor 3
[D1 14:44:31 citizen_125] Entered elevator_1, going to floor 4
[D1 14:44:31 floor_3] citizen_125 is leaving the queue
[D1 14:44:31 floor_3] The queue is now empty
[D1 14:44:36 elevator_2] At floor 3
[D1 14:44:36 elevator_2] Stopped at floor 3
[D1 14:44:36 elevator_2] Opening doors
[D1 14:44:39 elevator_2] Opened doors
[D1 14:44:39 citizen_145] Left elevator_2, arrived at floor 3
[D1 14:44:40 elevator_1] Closing doors
[D1 14:44:43 elevator_1] Closed doors
[D1 14:44:51 elevator_2] Closing doors
[D1 14:44:53 elevator_1] At floor 4
[D1 14:44:53 elevator_1] Stopped at floor 4
[D1 14:44:53 elevator_1] Opening doors
[D1 14:44:54 elevator_2] Closed doors
[D1 14:44:56 elevator_1] Opened doors
[D1 14:44:56 citizen_147] Left elevator_1, arrived at floor 4
[D1 14:44:56 citizen_125] Left elevator_1, arrived at floor 4
[D1 14:45:02 citizen_118] Time to go to the ground floor and leave
[D1 14:45:02 floor_1] citizen_118 entered the queue
[D1 14:45:02 floor_1] citizen_118 found an empty queue and will be served immediately
[D1 14:45:02 elevator_2] Summoned to floor 1 from floor 3
[D1 14:45:04 elevator_2] At floor 2
[D1 14:45:08 elevator_1] Closing doors
[D1 14:45:11 elevator_1] Closed doors
[D1 14:45:14 elevator_2] At floor 1
[D1 14:45:14 elevator_2] Stopped at floor 1
[D1 14:45:14 elevator_2] Opening doors
[D1 14:45:17 elevator_2] Opened doors
[D1 14:45:17 citizen_161] Left elevator_2, arrived at floor 1
[D1 14:45:17 citizen_118] Entered elevator_2, going to floor 0
[D1 14:45:17 floor_1] citizen_118 is leaving the queue
[D1 14:45:17 floor_1] The queue is now empty
[D1 14:45:21 elevator_1] At floor 5
[D1 14:45:21 elevator_1] Stopped at floor 5
[D1 14:45:21 elevator_1] Opening doors
[D1 14:45:24 elevator_1] Opened doors
[D1 14:45:24 citizen_142] Left elevator_1, arrived at floor 5
[D1 14:45:24 citizen_146] Left elevator_1, arrived at floor 5
[D1 14:45:29 elevator_2] Closing doors
[D1 14:45:30 citizen_151] Time to go to floor 4 and stay there for 00:30:45
[D1 14:45:30 floor_3] citizen_151 entered the queue
[D1 14:45:30 floor_3] citizen_151 found an empty queue and will be served immediately
[D1 14:45:30 elevator_1] Summoned to floor 3 from floor 5
[D1 14:45:30 elevator_2] Summoned to floor 3 from floor 1
[D1 14:45:32 elevator_2] Closed doors
[D1 14:45:36 elevator_1] Closing doors
[D1 14:45:39 elevator_1] Closed doors
[D1 14:45:39 elevator_1] Changing direction to Down
[D1 14:45:42 elevator_2] At floor 0
[D1 14:45:42 elevator_2] Stopped at floor 0
[D1 14:45:42 elevator_2] Opening doors
[D1 14:45:45 elevator_2] Opened doors
[D1 14:45:45 citizen_118] Left elevator_2, arrived at floor 0
[D1 14:45:45 citizen_118] Left the building
[D1 14:45:49 elevator_1] At floor 4
[D1 14:45:57 elevator_2] Closing doors
[D1 14:45:59 elevator_1] At floor 3
[D1 14:45:59 elevator_1] Stopped at floor 3
[D1 14:45:59 elevator_1] Opening doors
[D1 14:46:00 elevator_2] Closed doors
[D1 14:46:00 elevator_2] Changing direction to Up
[D1 14:46:02 elevator_1] Opened doors
[D1 14:46:02 citizen_151] Entered elevator_1, going to floor 4
[D1 14:46:02 floor_3] citizen_151 is leaving the queue
[D1 14:46:02 floor_3] The queue is now empty
[D1 14:46:03 citizen_113] Time to go to the ground floor and leave
[D1 14:46:03 floor_1] citizen_113 entered the queue
[D1 14:46:03 floor_1] citizen_113 found an empty queue and will be served immediately
[D1 14:46:03 elevator_2] Summoned to floor 1 from floor 0
[D1 14:46:09 citizen_136] Time to go to the ground floor and leave
[D1 14:46:09 floor_1] citizen_136 entered the queue
[D1 14:46:09 floor_1] citizen_136 is queued along with 0 other arrivals in front of it
[D1 14:46:10 elevator_2] At floor 1
[D1 14:46:10 elevator_2] Stopped at floor 1
[D1 14:46:10 elevator_2] Opening doors
[D1 14:46:13 elevator_2] Opened doors
[D1 14:46:13 citizen_113] Entered elevator_2, going to floor 0
[D1 14:46:13 floor_1] citizen_113 is leaving the queue
[D1 14:46:13 floor_1] citizen_136 was served
[D1 14:46:13 elevator_2] Summoned to floor 1 from floor 1
[D1 14:46:13 citizen_136] Entered elevator_2, going to floor 0
[D1 14:46:13 floor_1] citizen_136 is leaving the queue
[D1 14:46:13 floor_1] The queue is now empty
[D1 14:46:14 elevator_1] Closing doors
[D1 14:46:17 elevator_1] Closed doors
[D1 14:46:25 elevator_2] Closing doors
[D1 14:46:27 elevator_1] At floor 2
[D1 14:46:28 elevator_2] Closed doors
[D1 14:46:37 elevator_1] At floor 1
[D1 14:46:38 elevator_2] At floor 2
[D1 14:46:47 elevator_1] At floor 0
[D1 14:46:47 elevator_1] Stopped at floor 0
[D1 14:46:47 elevator_1] Opening doors
[D1 14:46:48 elevator_2] At floor 3
[D1 14:46:48 elevator_2] Stopped at floor 3
[D1 14:46:48 elevator_2] Opening doors
[D1 14:46:50 elevator_1] Opened doors
[D1 14:46:50 citizen_169] Entered elevator_1, going to floor 2
[D1 14:46:50 floor_0] citizen_169 is leaving the queue
[D1 14:46:50 floor_0] citizen_170 was served
[D1 14:46:50 elevator_1] Summoned to floor 0 from floor 0
[D1 14:46:50 citizen_170] Entered elevator_1, going to floor 1
[D1 14:46:50 floor_0] citizen_170 is leaving the queue
[D1 14:46:50 floor_0] The queue is now empty
[D1 14:46:51 elevator_2] Opened doors
[D1 14:47:02 elevator_1] Closing doors
[D1 14:47:03 elevator_2] Closing doors
[D1 14:47:05 elevator_1] Closed doors
[D1 14:47:05 elevator_1] Changing direction to Up
[D1 14:47:06 elevator_2] Closed doors
[D1 14:47:06 elevator_2] Changing direction to Down
[D1 14:47:15 elevator_1] At floor 1
[D1 14:47:15 elevator_1] Stopped at floor 1
[D1 14:47:15 elevator_1] Opening doors
[D1 14:47:16 elevator_2] At floor 2
[D1 14:47:18 elevator_1] Opened doors
[D1 14:47:18 citizen_170] Left elevator_1, arrived at floor 1
[D1 14:47:26 elevator_2] At floor 1
[D1 14:47:30 elevator_1] Closing doors
[D1 14:47:33 elevator_1] Closed doors
[D1 14:47:36 elevator_2] At floor 0
[D1 14:47:36 elevator_2] Stopped at floor 0
[D1 14:47:36 elevator_2] Opening doors
[D1 14:47:39 elevator_2] Opened doors
[D1 14:47:39 citizen_113] Left elevator_2, arrived at floor 0
[D1 14:47:39 citizen_136] Left elevator_2, arrived at floor 0
[D1 14:47:39 citizen_113] Left the building
[D1 14:47:39 citizen_136] Left the building
[D1 14:47:43 elevator_1] At floor 2
[D1 14:47:43 elevator_1] Stopped at floor 2
[D1 14:47:43 elevator_1] Opening doors
[D1 14:47:46 elevator_1] Opened doors
[D1 14:47:46 citizen_169] Left elevator_1, arrived at floor 2
[D1 14:47:51 elevator_2] Closing doors
[D1 14:47:54 elevator_2] Closed doors
[D1 14:47:54 elevator_2] Resting at floor 0
[D1 14:47:58 elevator_1] Closing doors
[D1 14:48:01 elevator_1] Closed doors
[D1 14:48:04 citizen_171] Entered the building, will visit 4 floors in total
[D1 14:48:04 citizen_171] Time to go to floor 1 and stay there for 00:41:11
[D1 14:48:04 floor_0] citizen_171 entered the queue
[D1 14:48:04 floor_0] citizen_171 found an empty queue and will be served immediately
[D1 14:48:04 elevator_2] Summoned to floor 0 from floor 0
[D1 14:48:04 elevator_2] Opening doors
[D1 14:48:07 elevator_2] Opened doors
[D1 14:48:07 citizen_171] Entered elevator_2, going to floor 1
[D1 14:48:07 floor_0] citizen_171 is leaving the queue
[D1 14:48:07 floor_0] The queue is now empty
[D1 14:48:11 elevator_1] At floor 3
[D1 14:48:19 elevator_2] Closing doors
[D1 14:48:21 elevator_1] At floor 4
[D1 14:48:21 elevator_1] Stopped at floor 4
[D1 14:48:21 elevator_1] Opening doors
[D1 14:48:22 elevator_2] Closed doors
[D1 14:48:22 elevator_2] Sprung into motion, heading Up
[D1 14:48:24 elevator_1] Opened doors
[D1 14:48:24 citizen_151] Left elevator_1, arrived at floor 4
[D1 14:48:32 elevator_2] At floor 1
[D1 14:48:32 elevator_2] Stopped at floor 1
[D1 14:48:32 elevator_2] Opening doors
[D1 14:48:35 elevator_2] Opened doors
[D1 14:48:35 citizen_171] Left elevator_2, arrived at floor 1
[D1 14:48:36 elevator_1] Closing doors
[D1 14:48:39 elevator_1] Closed doors
[D1 14:48:39 elevator_1] Resting at floor 4
[D1 14:48:47 elevator_2] Closing doors
[D1 14:48:50 elevator_2] Closed doors
[D1 14:48:50 elevator_2] Resting at floor 1
[D1 14:49:42 citizen_172] Entered the building, will visit 3 floors in total
[D1 14:49:42 citizen_172] Time to go to floor 2 and stay there for 00:27:34
[D1 14:49:42 floor_0] citizen_172 entered the queue
[D1 14:49:42 floor_0] citizen_172 found an empty queue and will be served immediately
[D1 14:49:42 elevator_2] Summoned to floor 0 from floor 1
[D1 14:49:42 elevator_2] Sprung into motion, heading Down
[D1 14:49:49 citizen_162] Time to go to floor 3 and stay there for 00:39:58
[D1 14:49:49 floor_4] citizen_162 entered the queue
[D1 14:49:49 floor_4] citizen_162 found an empty queue and will be served immediately
[D1 14:49:49 elevator_1] Summoned to floor 4 from floor 4
[D1 14:49:49 elevator_1] Opening doors
[D1 14:49:52 elevator_2] At floor 0
[D1 14:49:52 elevator_2] Stopped at floor 0
[D1 14:49:52 elevator_2] Opening doors
[D1 14:49:52 elevator_1] Opened doors
[D1 14:49:52 citizen_162] Entered elevator_1, going to floor 3
[D1 14:49:52 floor_4] citizen_162 is leaving the queue
[D1 14:49:52 floor_4] The queue is now empty
[D1 14:49:55 elevator_2] Opened doors
[D1 14:49:55 citizen_172] Entered elevator_2, going to floor 2
[D1 14:49:55 floor_0] citizen_172 is leaving the queue
[D1 14:49:55 floor_0] The queue is now empty
[D1 14:50:04 elevator_1] Closing doors
[D1 14:50:07 elevator_2] Closing doors
[D1 14:50:07 elevator_1] Closed doors
[D1 14:50:07 elevator_1] Sprung into motion, heading Down
[D1 14:50:10 elevator_2] Closed doors
[D1 14:50:10 elevator_2] Changing direction to Up
[D1 14:50:17 elevator_1] At floor 3
[D1 14:50:17 elevator_1] Stopped at floor 3
[D1 14:50:17 elevator_1] Opening doors
[D1 14:50:20 elevator_2] At floor 1
[D1 14:50:20 elevator_1] Opened doors
[D1 14:50:20 citizen_162] Left elevator_1, arrived at floor 3
[D1 14:50:26 citizen_163] Time to go to floor 5 and stay there for 00:08:54
[D1 14:50:26 floor_4] citizen_163 entered the queue
[D1 14:50:26 floor_4] citizen_163 found an empty queue and will be served immediately
[D1 14:50:26 elevator_1] Summoned to floor 4 from floor 3
[D1 14:50:29 citizen_127] Time to go to floor 3 and stay there for 00:28:20
[D1 14:50:29 floor_2] citizen_127 entered the queue
[D1 14:50:29 floor_2] citizen_127 found an empty queue and will be served immediately
[D1 14:50:29 elevator_1] Summoned to floor 2 from floor 3
[D1 14:50:29 elevator_2] Summoned to floor 2 from floor 1
[D1 14:50:30 elevator_2] At floor 2
[D1 14:50:30 elevator_2] Stopped at floor 2
[D1 14:50:30 elevator_2] Opening doors
[D1 14:50:32 elevator_1] Closing doors
[D1 14:50:33 elevator_2] Opened doors
[D1 14:50:33 citizen_172] Left elevator_2, arrived at floor 2
[D1 14:50:33 citizen_127] Entered elevator_2, going to floor 3
[D1 14:50:33 floor_2] citizen_127 is leaving the queue
[D1 14:50:33 floor_2] The queue is now empty
[D1 14:50:35 elevator_1] Closed doors
[D1 14:50:45 elevator_2] Closing doors
[D1 14:50:45 elevator_1] At floor 2
[D1 14:50:45 elevator_1] Stopped at floor 2
[D1 14:50:45 elevator_1] Opening doors
[D1 14:50:48 elevator_2] Closed doors
[D1 14:50:48 elevator_1] Opened doors
[D1 14:50:55 citizen_173] Entered the building, will visit 5 floors in total
[D1 14:50:55 citizen_173] Time to go to floor 2 and stay there for 00:21:55
[D1 14:50:55 floor_0] citizen_173 entered the queue
[D1 14:50:55 floor_0] citizen_173 found an empty queue and will be served immediately
[D1 14:50:55 elevator_1] Summoned to floor 0 from floor 2
[D1 14:50:55 elevator_2] Summoned to floor 0 from floor 2
[D1 14:50:58 elevator_2] At floor 3
[D1 14:50:58 elevator_2] Stopped at floor 3
[D1 14:50:58 elevator_2] Opening doors
[D1 14:51:00 elevator_1] Closing doors
[D1 14:51:01 elevator_2] Opened doors
[D1 14:51:01 citizen_127] Left elevator_2, arrived at floor 3
[D1 14:51:03 elevator_1] Closed doors
[D1 14:51:04 citizen_165] Time to go to floor 4 and stay there for 00:37:18
[D1 14:51:04 floor_3] citizen_165 entered the queue
[D1 14:51:04 floor_3] citizen_165 found an empty queue and will be served immediately
[D1 14:51:04 elevator_2] Summoned to floor 3 from floor 3
[D1 14:51:04 citizen_165] Entered elevator_2, going to floor 4
[D1 14:51:04 floor_3] citizen_165 is leaving the queue
[D1 14:51:04 floor_3] The queue is now empty
[D1 14:51:06 citizen_111] Time to go to the ground floor and leave
[D1 14:51:06 floor_2] citizen_111 entered the queue
[D1 14:51:06 floor_2] citizen_111 found an empty queue and will be served immediately
[D1 14:51:06 elevator_1] Summoned to floor 2 from floor 2
[D1 14:51:13 elevator_2] Closing doors
[D1 14:51:13 elevator_1] At floor 1
[D1 14:51:16 elevator_2] Closed doors
[D1 14:51:18 citizen_149] Time to go to floor 4 and stay there for 00:35:37
[D1 14:51:18 floor_2] citizen_149 entered the queue
[D1 14:51:18 floor_2] citizen_149 is queued along with 0 other arrivals in front of it
[D1 14:51:23 elevator_1] At floor 0
[D1 14:51:23 elevator_1] Stopped at floor 0
[D1 14:51:23 elevator_1] Opening doors
[D1 14:51:26 elevator_2] At floor 4
[D1 14:51:26 elevator_2] Stopped at floor 4
[D1 14:51:26 elevator_2] Opening doors
[D1 14:51:26 elevator_1] Opened doors
[D1 14:51:26 citizen_173] Entered elevator_1, going to floor 2
[D1 14:51:26 floor_0] citizen_173 is leaving the queue
[D1 14:51:26 floor_0] The queue is now empty
[D1 14:51:29 elevator_2] Opened doors
[D1 14:51:29 citizen_165] Left elevator_2, arrived at floor 4
[D1 14:51:38 elevator_1] Closing doors
[D1 14:51:41 elevator_2] Closing doors
[D1 14:51:41 elevator_1] Closed doors
[D1 14:51:41 elevator_1] Changing direction to Up
[D1 14:51:44 elevator_2] Closed doors
[D1 14:51:44 elevator_2] Changing direction to Down
[D1 14:51:51 elevator_1] At floor 1
[D1 14:51:54 elevator_2] At floor 3
[D1 14:52:01 elevator_1] At floor 2
[D1 14:52:01 elevator_1] Stopped at floor 2
[D1 14:52:01 elevator_1] Opening doors
[D1 14:52:04 elevator_2] At floor 2
[D1 14:52:04 elevator_1] Opened doors
[D1 14:52:04 citizen_173] Left elevator_1, arrived at floor 2
[D1 14:52:04 citizen_111] Entered elevator_1, going to floor 0
[D1 14:52:04 floor_2] citizen_111 is leaving the queue
[D1 14:52:04 floor_2] citizen_149 was served
[D1 14:52:04 elevator_1] Summoned to floor 2 from floor 2
[D1 14:52:04 elevator_2] Summoned to floor 2 from floor 2
[D1 14:52:04 citizen_149] Entered elevator_1, going to floor 4
[D1 14:52:04 floor_2] citizen_149 is leaving the queue
[D1 14:52:04 floor_2] The queue is now empty
[D1 14:52:10 citizen_121] Time to go to the ground floor and leave
[D1 14:52:10 floor_3] citizen_121 entered the queue
[D1 14:52:10 floor_3] citizen_121 found an empty queue and will be served immediately
[D1 14:52:10 elevator_1] Summoned to floor 3 from floor 2
[D1 14:52:10 elevator_2] Summoned to floor 3 from floor 2
[D1 14:52:14 elevator_2] At floor 1
[D1 14:52:16 elevator_1] Closing doors
[D1 14:52:19 elevator_1] Closed doors
[D1 14:52:24 elevator_2] At floor 0
[D1 14:52:24 elevator_2] Stopped at floor 0
[D1 14:52:24 elevator_2] Opening doors
[D1 14:52:27 elevator_2] Opened doors
[D1 14:52:29 elevator_1] At floor 3
[D1 14:52:29 elevator_1] Stopped at floor 3
[D1 14:52:29 elevator_1] Opening doors
[D1 14:52:29 citizen_174] Entered the building, will visit 4 floors in total
[D1 14:52:29 citizen_174] Time to go to floor 4 and stay there for 00:40:13
[D1 14:52:29 floor_0] citizen_174 entered the queue
[D1 14:52:29 floor_0] citizen_174 found an empty queue and will be served immediately
[D1 14:52:29 elevator_2] Summoned to floor 0 from floor 0
[D1 14:52:29 citizen_174] Entered elevator_2, going to floor 4
[D1 14:52:29 floor_0] citizen_174 is leaving the queue
[D1 14:52:29 floor_0] The queue is now empty
[D1 14:52:32 elevator_1] Opened doors
[D1 14:52:32 citizen_121] Entered elevator_1, going to floor 0
[D1 14:52:32 floor_3] citizen_121 is leaving the queue
[D1 14:52:32 floor_3] The queue is now empty
[D1 14:52:39 elevator_2] Closing doors
[D1 14:52:42 elevator_2] Closed doors
[D1 14:52:42 elevator_2] Changing direction to Up
[D1 14:52:44 elevator_1] Closing doors
[D1 14:52:47 elevator_1] Closed doors
[D1 14:52:52 elevator_2] At floor 1
[D1 14:52:57 elevator_1] At floor 4
[D1 14:52:57 elevator_1] Stopped at floor 4
[D1 14:52:57 elevator_1] Opening doors
[D1 14:53:00 elevator_1] Opened doors
[D1 14:53:00 citizen_149] Left elevator_1, arrived at floor 4
[D1 14:53:00 citizen_163] Entered elevator_1, going to floor 5
[D1 14:53:00 floor_4] citizen_163 is leaving the queue
[D1 14:53:00 floor_4] The queue is now empty
[D1 14:53:02 elevator_2] At floor 2
[D1 14:53:02 elevator_2] Stopped at floor 2
[D1 14:53:02 elevator_2] Opening doors
[D1 14:53:05 elevator_2] Opened doors
[D1 14:53:10 citizen_133] Time to go to floor 1 and stay there for 00:27:57
[D1 14:53:10 floor_2] citizen_133 entered the queue
[D1 14:53:10 floor_2] citizen_133 found an empty queue and will be served immediately
[D1 14:53:10 elevator_2] Summoned to floor 2 from floor 2
[D1 14:53:10 citizen_133] Entered elevator_2, going to floor 1
[D1 14:53:10 floor_2] citizen_133 is leaving the queue
[D1 14:53:10 floor_2] The queue is now empty
[D1 14:53:12 elevator_1] Closing doors
[D1 14:53:15 elevator_1] Closed doors
[D1 14:53:17 elevator_2] Closing doors
[D1 14:53:20 elevator_2] Closed doors
[D1 14:53:25 elevator_1] At floor 5
[D1 14:53:25 elevator_1] Stopped at floor 5
[D1 14:53:25 elevator_1] Opening doors
[D1 14:53:28 elevator_1] Opened doors
[D1 14:53:28 citizen_163] Left elevator_1, arrived at floor 5
[D1 14:53:30 elevator_2] At floor 3
[D1 14:53:30 elevator_2] Stopped at floor 3
[D1 14:53:30 elevator_2] Opening doors
[D1 14:53:33 elevator_2] Opened doors
[D1 14:53:40 elevator_1] Closing doors
[D1 14:53:43 citizen_158] Time to go to floor 2 and stay there for 00:18:35
[D1 14:53:43 floor_4] citizen_158 entered the queue
[D1 14:53:43 floor_4] citizen_158 found an empty queue and will be served immediately
[D1 14:53:43 elevator_1] Summoned to floor 4 from floor 5
[D1 14:53:43 elevator_2] Summoned to floor 4 from floor 3
[D1 14:53:43 elevator_1] Closed doors
[D1 14:53:43 elevator_1] Changing direction to Down
[D1 14:53:45 elevator_2] Closing doors
[D1 14:53:48 elevator_2] Closed doors
[D1 14:53:53 elevator_1] At floor 4
[D1 14:53:53 elevator_1] Stopped at floor 4
[D1 14:53:53 elevator_1] Opening doors
[D1 14:53:56 elevator_1] Opened doors
[D1 14:53:56 citizen_158] Entered elevator_1, going to floor 2
[D1 14:53:56 floor_4] citizen_158 is leaving the queue
[D1 14:53:56 floor_4] The queue is now empty
[D1 14:53:58 elevator_2] At floor 4
[D1 14:53:58 elevator_2] Stopped at floor 4
[D1 14:53:58 elevator_2] Opening doors
[D1 14:54:01 elevator_2] Opened doors
[D1 14:54:01 citizen_174] Left elevator_2, arrived at floor 4
[D1 14:54:08 elevator_1] Closing doors
[D1 14:54:11 elevator_1] Closed doors
[D1 14:54:13 elevator_2] Closing doors
[D1 14:54:16 elevator_2] Closed doors
[D1 14:54:16 elevator_2] Changing direction to Down
[D1 14:54:21 elevator_1] At floor 3
[D1 14:54:26 elevator_2] At floor 3
[D1 14:54:31 elevator_1] At floor 2
[D1 14:54:31 elevator_1] Stopped at floor 2
[D1 14:54:31 elevator_1] Opening doors
[D1 14:54:34 elevator_1] Opened doors
[D1 14:54:34 citizen_158] Left elevator_1, arrived at floor 2
[D1 14:54:36 elevator_2] At floor 2
[D1 14:54:46 elevator_1] Closing doors
[D1 14:54:46 elevator_2] At floor 1
[D1 14:54:46 elevator_2] Stopped at floor 1
[D1 14:54:46 elevator_2] Opening doors
[D1 14:54:49 elevator_1] Closed doors
[D1 14:54:49 elevator_2] Opened doors
[D1 14:54:49 citizen_133] Left elevator_2, arrived at floor 1
[D1 14:54:50 citizen_175] Entered the building, will visit 4 floors in total
[D1 14:54:50 citizen_175] Time to go to floor 2 and stay there for 00:36:54
[D1 14:54:50 floor_0] citizen_175 entered the queue
[D1 14:54:50 floor_0] citizen_175 found an empty queue and will be served immediately
[D1 14:54:50 elevator_2] Summoned to floor 0 from floor 1
[D1 14:54:59 elevator_1] At floor 1
[D1 14:55:01 elevator_2] Closing doors
[D1 14:55:04 elevator_2] Closed doors
[D1 14:55:09 elevator_1] At floor 0
[D1 14:55:09 elevator_1] Stopped at floor 0
[D1 14:55:09 elevator_1] Opening doors
[D1 14:55:12 elevator_1] Opened doors
[D1 14:55:12 citizen_111] Left elevator_1, arrived at floor 0
[D1 14:55:12 citizen_121] Left elevator_1, arrived at floor 0
[D1 14:55:12 citizen_111] Left the building
[D1 14:55:12 citizen_121] Left the building
[D1 14:55:14 elevator_2] At floor 0
[D1 14:55:14 elevator_2] Stopped at floor 0
[D1 14:55:14 elevator_2] Opening doors
[D1 14:55:17 elevator_2] Opened doors
[D1 14:55:17 citizen_175] Entered elevator_2, going to floor 2
[D1 14:55:17 floor_0] citizen_175 is leaving the queue
[D1 14:55:17 floor_0] The queue is now empty
[D1 14:55:24 elevator_1] Closing doors
[D1 14:55:27 elevator_1] Closed doors
[D1 14:55:27 elevator_1] Resting at floor 0
[D1 14:55:29 elevator_2] Closing doors
[D1 14:55:32 elevator_2] Closed doors
[D1 14:55:32 elevator_2] Changing direction to Up
[D1 14:55:42 elevator_2] At floor 1
[D1 14:55:49 citizen_164] Time to go to floor 4 and stay there for 00:13:58
[D1 14:55:49 floor_5] citizen_164 entered the queue
[D1 14:55:49 floor_5] citizen_164 found an empty queue and will be served immediately
[D1 14:55:49 elevator_2] Summoned to floor 5 from floor 1
[D1 14:55:52 elevator_2] At floor 2
[D1 14:55:52 elevator_2] Stopped at floor 2
[D1 14:55:52 elevator_2] Opening doors
[D1 14:55:55 elevator_2] Opened doors
[D1 14:55:55 citizen_175] Left elevator_2, arrived at floor 2
[D1 14:56:04 citizen_128] Time to go to floor 3 and stay there for 00:29:10
[D1 14:56:04 floor_5] citizen_128 entered the queue
[D1 14:56:04 floor_5] citizen_128 is queued along with 0 other arrivals in front of it
[D1 14:56:07 elevator_2] Closing doors
[D1 14:56:10 elevator_2] Closed doors
[D1 14:56:20 elevator_2] At floor 3
[D1 14:56:30 elevator_2] At floor 4
[D1 14:56:39 citizen_135] Time to go to the ground floor and leave
[D1 14:56:39 floor_4] citizen_135 entered the queue
[D1 14:56:39 floor_4] citizen_135 found an empty queue and will be served immediately
[D1 14:56:39 elevator_2] Summoned to floor 4 from floor 4
[D1 14:56:40 citizen_176] Entered the building, will visit 4 floors in total
[D1 14:56:40 citizen_176] Time to go to floor 2 and stay there for 00:07:29
[D1 14:56:40 floor_0] citizen_176 entered the queue
[D1 14:56:40 floor_0] citizen_176 found an empty queue and will be served immediately
[D1 14:56:40 elevator_1] Summoned to floor 0 from floor 0
[D1 14:56:40 elevator_1] Opening doors
[D1 14:56:40 elevator_2] At floor 5
[D1 14:56:40 elevator_2] Stopped at floor 5
[D1 14:56:40 elevator_2] Opening doors
[D1 14:56:43 elevator_1] Opened doors
[D1 14:56:43 elevator_2] Opened doors
[D1 14:56:43 citizen_176] Entered elevator_1, going to floor 2
[D1 14:56:43 floor_0] citizen_176 is leaving the queue
[D1 14:56:43 floor_0] The queue is now empty
[D1 14:56:43 citizen_164] Entered elevator_2, going to floor 4
[D1 14:56:43 floor_5] citizen_164 is leaving the queue
[D1 14:56:43 floor_5] citizen_128 was served
[D1 14:56:43 elevator_2] Summoned to floor 5 from floor 5
[D1 14:56:43 citizen_128] Entered elevator_2, going to floor 3
[D1 14:56:43 floor_5] citizen_128 is leaving the queue
[D1 14:56:43 floor_5] The queue is now empty
[D1 14:56:55 elevator_2] Closing doors
[D1 14:56:55 elevator_1] Closing doors
[D1 14:56:58 elevator_2] Closed doors
[D1 14:56:58 elevator_1] Closed doors
[D1 14:56:58 elevator_2] Changing direction to Down
[D1 14:56:58 elevator_1] Sprung into motion, heading Up
[D1 14:56:59 citizen_155] Time to go to floor 4 and stay there for 00:35:38
[D1 14:56:59 floor_3] citizen_155 entered the queue
[D1 14:56:59 floor_3] citizen_155 found an empty queue and will be served immediately
[D1 14:56:59 elevator_2] Summoned to floor 3 from floor 5
[D1 14:57:08 elevator_2] At floor 4
[D1 14:57:08 elevator_2] Stopped at floor 4
[D1 14:57:08 elevator_2] Opening doors
[D1 14:57:08 elevator_1] At floor 1
[D1 14:57:11 elevator_2] Opened doors
[D1 14:57:11 citizen_164] Left elevator_2, arrived at floor 4
[D1 14:57:11 citizen_135] Entered elevator_2, going to floor 0
[D1 14:57:11 floor_4] citizen_135 is leaving the queue
[D1 14:57:11 floor_4] The queue is now empty
[D1 14:57:16 citizen_159] Time to go to floor 5 and stay there for 00:37:31
[D1 14:57:16 floor_4] citizen_159 entered the queue
[D1 14:57:16 floor_4] citizen_159 found an empty queue and will be served immediately
[D1 14:57:16 elevator_2] Summoned to floor 4 from floor 4
[D1 14:57:16 citizen_159] Entered elevator_2, going to floor 5
[D1 14:57:16 floor_4] citizen_159 is leaving the queue
[D1 14:57:16 floor_4] The queue is now empty
[D1 14:57:18 elevator_1] At floor 2
[D1 14:57:18 elevator_1] Stopped at floor 2
[D1 14:57:18 elevator_1] Opening doors
[D1 14:57:21 elevator_1] Opened doors
[D1 14:57:21 citizen_176] Left elevator_1, arrived at floor 2
[D1 14:57:23 elevator_2] Closing doors
[D1 14:57:26 elevator_2] Closed doors
[D1 14:57:33 elevator_1] Closing doors
[D1 14:57:36 elevator_2] At floor 3
[D1 14:57:36 elevator_2] Stopped at floor 3
[D1 14:57:36 elevator_2] Opening doors
[D1 14:57:36 elevator_1] Closed doors
[D1 14:57:36 elevator_1] Resting at floor 2
[D1 14:57:39 elevator_2] Opened doors
[D1 14:57:39 citizen_128] Left elevator_2, arrived at floor 3
[D1 14:57:39 citizen_155] Entered elevator_2, going to floor 4
[D1 14:57:39 floor_3] citizen_155 is leaving the queue
[D1 14:57:39 floor_3] The queue is now empty
[D1 14:57:51 elevator_2] Closing doors
[D1 14:57:54 elevator_2] Closed doors
[D1 14:58:04 elevator_2] At floor 2
[D1 14:58:12 citizen_177] Entered the building, will visit 3 floors in total
[D1 14:58:12 citizen_177] Time to go to floor 5 and stay there for 00:27:47
[D1 14:58:12 floor_0] citizen_177 entered the queue
[D1 14:58:12 floor_0] citizen_177 found an empty queue and will be served immediately
[D1 14:58:12 elevator_1] Summoned to floor 0 from floor 2
[D1 14:58:12 elevator_1] Sprung into motion, heading Down
[D1 14:58:12 elevator_2] Summoned to floor 0 from floor 2
[D1 14:58:14 elevator_2] At floor 1
[D1 14:58:22 elevator_1] At floor 1
[D1 14:58:24 elevator_2] At floor 0
[D1 14:58:24 elevator_2] Stopped at floor 0
[D1 14:58:24 elevator_2] Opening doors
[D1 14:58:27 elevator_2] Opened doors
[D1 14:58:27 citizen_135] Left elevator_2, arrived at floor 0
[D1 14:58:27 citizen_135] Left the building
[D1 14:58:27 citizen_177] Entered elevator_2, going to floor 5
[D1 14:58:27 floor_0] citizen_177 is leaving the queue
[D1 14:58:27 floor_0] The queue is now empty
[D1 14:58:32 elevator_1] At floor 0
[D1 14:58:32 elevator_1] Stopped at floor 0
[D1 14:58:32 elevator_1] Opening doors
[D1 14:58:35 elevator_1] Opened doors
[D1 14:58:39 elevator_2] Closing doors
[D1 14:58:42 elevator_2] Closed doors
[D1 14:58:42 elevator_2] Changing direction to Up
[D1 14:58:47 elevator_1] Closing doors
[D1 14:58:50 elevator_1] Closed doors
[D1 14:58:50 elevator_1] Resting at floor 0
[D1 14:58:52 elevator_2] At floor 1
[D1 14:59:02 elevator_2] At floor 2
[D1 14:59:05 citizen_166] Time to go to floor 1 and stay there for 00:32:34
[D1 14:59:05 floor_2] citizen_166 entered the queue
[D1 14:59:05 floor_2] citizen_166 found an empty queue and will be served immediately
[D1 14:59:05 elevator_2] Summoned to floor 2 from floor 2
[D1 14:59:12 elevator_2] At floor 3
[D1 14:59:22 citizen_154] Time to go to floor 5 and stay there for 00:21:11
[D1 14:59:22 floor_3] citizen_154 entered the queue
[D1 14:59:22 floor_3] citizen_154 found an empty queue and will be served immediately
[D1 14:59:22 elevator_2] Summoned to floor 3 from floor 3
[D1 14:59:22 elevator_2] At floor 4
[D1 14:59:22 elevator_2] Stopped at floor 4
[D1 14:59:22 elevator_2] Opening doors
[D1 14:59:25 elevator_2] Opened doors
[D1 14:59:25 citizen_155] Left elevator_2, arrived at floor 4
[D1 14:59:34 citizen_178] Entered the building, will visit 4 floors in total
[D1 14:59:34 citizen_178] Time to go to floor 2 and stay there for 00:26:13
[D1 14:59:34 floor_0] citizen_178 entered the queue
[D1 14:59:34 floor_0] citizen_178 found an empty queue and will be served immediately
[D1 14:59:34 elevator_1] Summoned to floor 0 from floor 0
[D1 14:59:34 elevator_1] Opening doors
[D1 14:59:37 elevator_2] Closing doors
[D1 14:59:37 elevator_1] Opened doors
[D1 14:59:37 citizen_178] Entered elevator_1, going to floor 2
[D1 14:59:37 floor_0] citizen_178 is leaving the queue
[D1 14:59:37 floor_0] The queue is now empty
[D1 14:59:40 elevator_2] Closed doors
[D1 14:59:49 elevator_1] Closing doors
[D1 14:59:50 elevator_2] At floor 5
[D1 14:59:50 elevator_2] Stopped at floor 5
[D1 14:59:50 elevator_2] Opening doors
[D1 14:59:52 elevator_1] Closed doors
[D1 14:59:52 elevator_1] Sprung into motion, heading Up
[D1 14:59:53 elevator_2] Opened doors
[D1 14:59:53 citizen_159] Left elevator_2, arrived at floor 5
[D1 14:59:53 citizen_177] Left elevator_2, arrived at floor 5
[D1 15:00:02 elevator_1] At floor 1
[D1 15:00:05 elevator_2] Closing doors
[D1 15:00:08 elevator_2] Closed doors
[D1 15:00:08 elevator_2] Changing direction to Down
[D1 15:00:12 elevator_1] At floor 2
[D1 15:00:12 elevator_1] Stopped at floor 2
[D1 15:00:12 elevator_1] Opening doors
[D1 15:00:15 elevator_1] Opened doors
[D1 15:00:15 citizen_178] Left elevator_1, arrived at floor 2
[D1 15:00:18 elevator_2] At floor 4
[D1 15:00:27 elevator_1] Closing doors
[D1 15:00:28 elevator_2] At floor 3
[D1 15:00:28 elevator_2] Stopped at floor 3
[D1 15:00:28 elevator_2] Opening doors
[D1 15:00:30 elevator_1] Closed doors
[D1 15:00:30 elevator_1] Resting at floor 2
[D1 15:00:31 elevator_2] Opened doors
[D1 15:00:31 citizen_154] Entered elevator_2, going to floor 5
[D1 15:00:31 floor_3] citizen_154 is leaving the queue
[D1 15:00:31 floor_3] The queue is now empty
[D1 15:00:43 elevator_2] Closing doors
[D1 15:00:46 elevator_2] Closed doors
[D1 15:00:56 elevator_2] At floor 2
[D1 15:00:56 elevator_2] Stopped at floor 2
[D1 15:00:56 elevator_2] Opening doors
[D1 15:00:59 elevator_2] Opened doors
[D1 15:00:59 citizen_166] Entered elevator_2, going to floor 1
[D1 15:00:59 floor_2] citizen_166 is leaving the queue
[D1 15:00:59 floor_2] The queue is now empty
[D1 15:01:11 elevator_2] Closing doors
[D1 15:01:14 elevator_2] Closed doors
[D1 15:01:24 elevator_2] At floor 1
[D1 15:01:24 elevator_2] Stopped at floor 1
[D1 15:01:24 elevator_2] Opening doors
[D1 15:01:27 elevator_2] Opened doors
[D1 15:01:27 citizen_166] Left elevator_2, arrived at floor 1
[D1 15:01:34 citizen_107] Time to go to the ground floor and leave
[D1 15:01:34 floor_5] citizen_107 entered the queue
[D1 15:01:34 floor_5] citizen_107 found an empty queue and will be served immediately
[D1 15:01:34 elevator_1] Summoned to floor 5 from floor 2
[D1 15:01:34 elevator_1] Sprung into motion, heading Up
[D1 15:01:39 elevator_2] Closing doors
[D1 15:01:42 elevator_2] Closed doors
[D1 15:01:42 elevator_2] Changing direction to Up
[D1 15:01:43 citizen_167] Time to go to floor 5 and stay there for 00:25:57
[D1 15:01:43 floor_1] citizen_167 entered the queue
[D1 15:01:43 floor_1] citizen_167 found an empty queue and will be served immediately
[D1 15:01:43 elevator_2] Summoned to floor 1 from floor 1
[D1 15:01:44 elevator_1] At floor 3
[D1 15:01:52 elevator_2] At floor 2
[D1 15:01:54 elevator_1] At floor 4
[D1 15:02:02 elevator_2] At floor 3
[D1 15:02:04 elevator_1] At floor 5
[D1 15:02:04 elevator_1] Stopped at floor 5
[D1 15:02:04 elevator_1] Opening doors
[D1 15:02:05 citizen_179] Entered the building, will visit 4 floors in total
[D1 15:02:05 citizen_179] Time to go to floor 5 and stay there for 00:35:11
[D1 15:02:05 floor_0] citizen_179 entered the queue
[D1 15:02:05 floor_0] citizen_179 found an empty queue and will be served immediately
[D1 15:02:05 elevator_2] Summoned to floor 0 from floor 3
[D1 15:02:06 citizen_120] Time to go to floor 4 and stay there for 00:32:21
[D1 15:02:06 floor_1] citizen_120 entered the queue
[D1 15:02:06 floor_1] citizen_120 is queued along with 0 other arrivals in front of it
[D1 15:02:07 elevator_1] Opened doors
[D1 15:02:07 citizen_107] Entered elevator_1, going to floor 0
[D1 15:02:07 floor_5] citizen_107 is leaving the queue
[D1 15:02:07 floor_5] The queue is now empty
[D1 15:02:12 elevator_2] At floor 4
[D1 15:02:19 elevator_1] Closing doors
[D1 15:02:22 citizen_163] Time to go to floor 1 and stay there for 00:24:53
[D1 15:02:22 floor_5] citizen_163 entered the queue
[D1 15:02:22 floor_5] citizen_163 found an empty queue and will be served immediately
[D1 15:02:22 elevator_1] Summoned to floor 5 from floor 5
[D1 15:02:22 elevator_2] At floor 5
[D1 15:02:22 elevator_2] Stopped at floor 5
[D1 15:02:22 elevator_2] Opening doors
[D1 15:02:22 elevator_1] Reopening doors
[D1 15:02:22 citizen_163] Entered elevator_1, going to floor 1
[D1 15:02:22 floor_5] citizen_163 is leaving the queue
[D1 15:02:22 floor_5] The queue is now empty
[D1 15:02:25 elevator_2] Opened doors
[D1 15:02:25 citizen_154] Left elevator_2, arrived at floor 5
[D1 15:02:34 elevator_1] Closing doors
[D1 15:02:37 elevator_2] Closing doors
[D1 15:02:37 elevator_1] Closed doors
[D1 15:02:37 elevator_1] Changing direction to Down
[D1 15:02:40 elevator_2] Closed doors
[D1 15:02:40 elevator_2] Changing direction to Down
[D1 15:02:47 elevator_1] At floor 4
[D1 15:02:50 elevator_2] At floor 4
[D1 15:02:57 citizen_150] Time to go to the ground floor and leave
[D1 15:02:57 floor_4] citizen_150 entered the queue
[D1 15:02:57 floor_4] citizen_150 found an empty queue and will be served immediately
[D1 15:02:57 elevator_1] Summoned to floor 4 from floor 4
[D1 15:02:57 elevator_2] Summoned to floor 4 from floor 4
[D1 15:02:57 elevator_1] At floor 3
[D1 15:03:00 elevator_2] At floor 3
[D1 15:03:07 elevator_1] At floor 2
[D1 15:03:10 elevator_2] At floor 2
[D1 15:03:17 elevator_1] At floor 1
[D1 15:03:17 elevator_1] Stopped at floor 1
[D1 15:03:17 elevator_1] Opening doors
[D1 15:03:20 elevator_2] At floor 1
[D1 15:03:20 elevator_2] Stopped at floor 1
[D1 15:03:20 elevator_2] Opening doors
[D1 15:03:20 elevator_1] Opened doors
[D1 15:03:20 citizen_163] Left elevator_1, arrived at floor 1
[D1 15:03:23 elevator_2] Opened doors
[D1 15:03:23 citizen_167] Entered elevator_2, going to floor 5
[D1 15:03:23 floor_1] citizen_167 is leaving the queue
[D1 15:03:23 floor_1] citizen_120 was served
[D1 15:03:23 elevator_1] Summoned to floor 1 from floor 1
[D1 15:03:23 elevator_2] Summoned to floor 1 from floor 1
[D1 15:03:23 citizen_120] Entered elevator_1, going to floor 4
[D1 15:03:23 floor_1] citizen_120 is leaving the queue
[D1 15:03:23 floor_1] The queue is now empty
[D1 15:03:24 citizen_141] Time to go to floor 2 and stay there for 00:20:32
[D1 15:03:24 floor_3] citizen_141 entered the queue
[D1 15:03:24 floor_3] citizen_141 found an empty queue and will be served immediately
[D1 15:03:24 elevator_1] Summoned to floor 3 from floor 1
[D1 15:03:24 elevator_2] Summoned to floor 3 from floor 1
[D1 15:03:32 elevator_1] Closing doors
[D1 15:03:35 elevator_2] Closing doors
[D1 15:03:35 elevator_1] Closed doors
[D1 15:03:38 elevator_2] Closed doors
[D1 15:03:45 elevator_1] At floor 0
[D1 15:03:45 elevator_1] Stopped at floor 0
[D1 15:03:45 elevator_1] Opening doors
[D1 15:03:47 citizen_142] Time to go to the ground floor and leave
[D1 15:03:47 floor_5] citizen_142 entered the queue
[D1 15:03:47 floor_5] citizen_142 found an empty queue and will be served immediately
[D1 15:03:47 elevator_2] Summoned to floor 5 from floor 1
[D1 15:03:48 elevator_2] At floor 0
[D1 15:03:48 elevator_2] Stopped at floor 0
[D1 15:03:48 elevator_2] Opening doors
[D1 15:03:48 elevator_1] Opened doors
[D1 15:03:48 citizen_107] Left elevator_1, arrived at floor 0
[D1 15:03:48 citizen_107] Left the building
[D1 15:03:51 elevator_2] Opened doors
[D1 15:03:51 citizen_179] Entered elevator_2, going to floor 5
[D1 15:03:51 floor_0] citizen_179 is leaving the queue
[D1 15:03:51 floor_0] The queue is now empty
[D1 15:04:00 elevator_1] Closing doors
[D1 15:04:03 elevator_2] Closing doors
[D1 15:04:03 elevator_1] Closed doors
[D1 15:04:03 elevator_1] Changing direction to Up
[D1 15:04:06 elevator_2] Closed doors
[D1 15:04:06 elevator_2] Changing direction to Up
[D1 15:04:13 elevator_1] At floor 1
[D1 15:04:16 elevator_2] At floor 1
[D1 15:04:18 citizen_180] Entered the building, will visit 4 floors in total
[D1 15:04:18 citizen_180] Time to go to floor 3 and stay there for 00:31:21
[D1 15:04:18 floor_0] citizen_180 entered the queue
[D1 15:04:18 floor_0] citizen_180 found an empty queue and will be served immediately
[D1 15:04:18 elevator_1] Summoned to floor 0 from floor 1
[D1 15:04:18 elevator_2] Summoned to floor 0 from floor 1
[D1 15:04:23 elevator_1] At floor 2
[D1 15:04:26 elevator_2] At floor 2
[D1 15:04:33 elevator_1] At floor 3
[D1 15:04:33 elevator_1] Stopped at floor 3
[D1 15:04:33 elevator_1] Opening doors
[D1 15:04:36 elevator_2] At floor 3
[D1 15:04:36 elevator_2] Stopped at floor 3
[D1 15:04:36 elevator_2] Opening doors
[D1 15:04:36 elevator_1] Opened doors
[D1 15:04:36 citizen_141] Entered elevator_1, going to floor 2
[D1 15:04:36 floor_3] citizen_141 is leaving the queue
[D1 15:04:36 floor_3] The queue is now empty
[D1 15:04:39 elevator_2] Opened doors
[D1 15:04:48 elevator_1] Closing doors
[D1 15:04:50 citizen_176] Time to go to floor 1 and stay there for 00:33:57
[D1 15:04:50 floor_2] citizen_176 entered the queue
[D1 15:04:50 floor_2] citizen_176 found an empty queue and will be served immediately
[D1 15:04:50 elevator_1] Summoned to floor 2 from floor 3
[D1 15:04:50 elevator_2] Summoned to floor 2 from floor 3
[D1 15:04:51 elevator_2] Closing doors
[D1 15:04:51 elevator_1] Closed doors
[D1 15:04:52 citizen_144] Time to go to floor 3 and stay there for 00:40:54
[D1 15:04:52 floor_5] citizen_144 entered the queue
[D1 15:04:52 floor_5] citizen_144 is queued along with 0 other arrivals in front of it
[D1 15:04:54 elevator_2] Closed doors
[D1 15:05:01 elevator_1] At floor 4
[D1 15:05:01 elevator_1] Stopped at floor 4
[D1 15:05:01 elevator_1] Opening doors
[D1 15:05:04 elevator_2] At floor 4
[D1 15:05:04 elevator_2] Stopped at floor 4
[D1 15:05:04 elevator_2] Opening doors
[D1 15:05:04 elevator_1] Opened doors
[D1 15:05:04 citizen_120] Left elevator_1, arrived at floor 4
[D1 15:05:04 citizen_150] Entered elevator_1, going to floor 0
[D1 15:05:04 floor_4] citizen_150 is leaving the queue
[D1 15:05:04 floor_4] The queue is now empty
[D1 15:05:07 elevator_2] Opened doors
[D1 15:05:16 elevator_1] Closing doors
[D1 15:05:19 elevator_2] Closing doors
[D1 15:05:19 elevator_1] Closed doors
[D1 15:05:19 elevator_1] Changing direction to Down
[D1 15:05:22 elevator_2] Closed doors
[D1 15:05:29 elevator_1] At floor 3
[D1 15:05:31 citizen_153] Time to go to floor 5 and stay there for 00:28:04
[D1 15:05:31 floor_1] citizen_153 entered the queue
[D1 15:05:31 floor_1] citizen_153 found an empty queue and will be served immediately
[D1 15:05:31 elevator_1] Summoned to floor 1 from floor 3
[D1 15:05:32 elevator_2] At floor 5
[D1 15:05:32 elevator_2] Stopped at floor 5
[D1 15:05:32 elevator_2] Opening doors
[D1 15:05:35 elevator_2] Opened doors
[D1 15:05:35 citizen_167] Left elevator_2, arrived at floor 5
[D1 15:05:35 citizen_179] Left elevator_2, arrived at floor 5
[D1 15:05:35 citizen_142] Entered elevator_2, going to floor 0
[D1 15:05:35 floor_5] citizen_142 is leaving the queue
[D1 15:05:35 floor_5] citizen_144 was served
[D1 15:05:35 elevator_2] Summoned to floor 5 from floor 5
[D1 15:05:35 citizen_144] Entered elevator_2, going to floor 3
[D1 15:05:35 floor_5] citizen_144 is leaving the queue
[D1 15:05:35 floor_5] The queue is now empty
[D1 15:05:39 elevator_1] At floor 2
[D1 15:05:39 elevator_1] Stopped at floor 2
[D1 15:05:39 elevator_1] Opening doors
[D1 15:05:42 elevator_1] Opened doors
[D1 15:05:42 citizen_141] Left elevator_1, arrived at floor 2
[D1 15:05:42 citizen_176] Entered elevator_1, going to floor 1
[D1 15:05:42 floor_2] citizen_176 is leaving the queue
[D1 15:05:42 floor_2] The queue is now empty
[D1 15:05:47 elevator_2] Closing doors
[D1 15:05:50 elevator_2] Closed doors
[D1 15:05:50 elevator_2] Changing direction to Down
[D1 15:05:54 elevator_1] Closing doors
[D1 15:05:57 elevator_1] Closed doors
[D1 15:06:00 elevator_2] At floor 4
[D1 15:06:07 elevator_1] At floor 1
[D1 15:06:07 elevator_1] Stopped at floor 1
[D1 15:06:07 elevator_1] Opening doors
[D1 15:06:10 elevator_2] At floor 3
[D1 15:06:10 elevator_2] Stopped at floor 3
[D1 15:06:10 elevator_2] Opening doors
[D1 15:06:10 elevator_1] Opened doors
[D1 15:06:10 citizen_176] Left elevator_1, arrived at floor 1
[D1 15:06:10 citizen_153] Entered elevator_1, going to floor 5
[D1 15:06:10 floor_1] citizen_153 is leaving the queue
[D1 15:06:10 floor_1] The queue is now empty
[D1 15:06:13 elevator_2] Opened doors
[D1 15:06:13 citizen_144] Left elevator_2, arrived at floor 3
[D1 15:06:22 elevator_1] Closing doors
[D1 15:06:25 elevator_2] Closing doors
[D1 15:06:25 elevator_1] Closed doors
[D1 15:06:28 elevator_2] Closed doors
[D1 15:06:35 elevator_1] At floor 0
[D1 15:06:35 elevator_1] Stopped at floor 0
[D1 15:06:35 elevator_1] Opening doors
[D1 15:06:38 elevator_2] At floor 2
[D1 15:06:38 elevator_2] Stopped at floor 2
[D1 15:06:38 elevator_2] Opening doors
[D1 15:06:38 elevator_1] Opened doors
[D1 15:06:38 citizen_150] Left elevator_1, arrived at floor 0
[D1 15:06:38 citizen_150] Left the building
[D1 15:06:38 citizen_180] Entered elevator_1, going to floor 3
[D1 15:06:38 floor_0] citizen_180 is leaving the queue
[D1 15:06:38 floor_0] The queue is now empty
[D1 15:06:39 citizen_156] Time to go to floor 5 and stay there for 00:34:26
[D1 15:06:39 floor_2] citizen_156 entered the queue
[D1 15:06:39 floor_2] citizen_156 found an empty queue and will be served immediately
[D1 15:06:39 elevator_2] Summoned to floor 2 from floor 2
[D1 15:06:41 elevator_2] Opened doors
[D1 15:06:41 citizen_156] Entered elevator_2, going to floor 5
[D1 15:06:41 floor_2] citizen_156 is leaving the queue
[D1 15:06:41 floor_2] The queue is now empty
[D1 15:06:42 citizen_137] Time to go to the ground floor and leave
[D1 15:06:42 floor_3] citizen_137 entered the queue
[D1 15:06:42 floor_3] citizen_137 found an empty queue and will be served immediately
[D1 15:06:42 elevator_2] Summoned to floor 3 from floor 2
[D1 15:06:50 elevator_1] Closing doors
[D1 15:06:53 elevator_2] Closing doors
[D1 15:06:53 elevator_1] Closed doors
[D1 15:06:53 elevator_1] Changing direction to Up
[D1 15:06:55 citizen_181] Entered the building, will visit 3 floors in total
[D1 15:06:55 citizen_181] Time to go to floor 5 and stay there for 00:25:51
[D1 15:06:55 floor_0] citizen_181 entered the queue
[D1 15:06:55 floor_0] citizen_181 found an empty queue and will be served immediately
[D1 15:06:55 elevator_1] Summoned to floor 0 from floor 0
[D1 15:06:56 elevator_2] Closed doors
[D1 15:07:03 elevator_1] At floor 1
[D1 15:07:06 elevator_2] At floor 1
[D1 15:07:12 citizen_168] Time to go to floor 1 and stay there for 00:41:06
[D1 15:07:12 floor_3] citizen_168 entered the queue
[D1 15:07:12 floor_3] citizen_168 is queued along with 0 other arrivals in front of it
[D1 15:07:13 elevator_1] At floor 2
[D1 15:07:16 elevator_2] At floor 0
[D1 15:07:16 elevator_2] Stopped at floor 0
[D1 15:07:16 elevator_2] Opening doors
[D1 15:07:19 elevator_2] Opened doors
[D1 15:07:19 citizen_142] Left elevator_2, arrived at floor 0
[D1 15:07:19 citizen_142] Left the building
[D1 15:07:23 elevator_1] At floor 3
[D1 15:07:23 elevator_1] Stopped at floor 3
[D1 15:07:23 elevator_1] Opening doors
[D1 15:07:26 elevator_1] Opened doors
[D1 15:07:26 citizen_180] Left elevator_1, arrived at floor 3
[D1 15:07:31 elevator_2] Closing doors
[D1 15:07:34 elevator_2] Closed doors
[D1 15:07:34 elevator_2] Changing direction to Up
[D1 15:07:38 elevator_1] Closing doors
[D1 15:07:41 elevator_1] Closed doors
[D1 15:07:44 elevator_2] At floor 1
[D1 15:07:51 citizen_132] Time to go to the ground floor and leave
[D1 15:07:51 floor_2] citizen_132 entered the queue
[D1 15:07:51 floor_2] citizen_132 found an empty queue and will be served immediately
[D1 15:07:51 elevator_1] Summoned to floor 2 from floor 3
[D1 15:07:51 elevator_2] Summoned to floor 2 from floor 1
[D1 15:07:51 elevator_1] At floor 4
[D1 15:07:54 elevator_2] At floor 2
[D1 15:07:54 elevator_2] Stopped at floor 2
[D1 15:07:54 elevator_2] Opening doors
[D1 15:07:57 elevator_2] Opened doors
[D1 15:07:57 citizen_132] Entered elevator_2, going to floor 0
[D1 15:07:57 floor_2] citizen_132 is leaving the queue
[D1 15:07:57 floor_2] The queue is now empty
[D1 15:07:59 citizen_109] Time to go to the ground floor and leave
[D1 15:07:59 floor_5] citizen_109 entered the queue
[D1 15:07:59 floor_5] citizen_109 found an empty queue and will be served immediately
[D1 15:07:59 elevator_1] Summoned to floor 5 from floor 4
[D1 15:08:01 elevator_1] At floor 5
[D1 15:08:01 elevator_1] Stopped at floor 5
[D1 15:08:01 elevator_1] Opening doors
[D1 15:08:04 elevator_1] Opened doors
[D1 15:08:04 citizen_153] Left elevator_1, arrived at floor 5
[D1 15:08:04 citizen_109] Entered elevator_1, going to floor 0
[D1 15:08:04 floor_5] citizen_109 is leaving the queue
[D1 15:08:04 floor_5] The queue is now empty
[D1 15:08:09 elevator_2] Closing doors
[D1 15:08:12 elevator_2] Closed doors
[D1 15:08:16 elevator_1] Closing doors
[D1 15:08:17 citizen_138] Time to go to the ground floor and leave
[D1 15:08:17 floor_2] citizen_138 entered the queue
[D1 15:08:17 floor_2] citizen_138 found an empty queue and will be served immediately
[D1 15:08:17 elevator_2] Summoned to floor 2 from floor 2
[D1 15:08:19 elevator_1] Closed doors
[D1 15:08:19 elevator_1] Changing direction to Down
[D1 15:08:22 elevator_2] At floor 3
[D1 15:08:22 elevator_2] Stopped at floor 3
[D1 15:08:22 elevator_2] Opening doors
[D1 15:08:25 elevator_2] Opened doors
[D1 15:08:25 citizen_137] Entered elevator_2, going to floor 0
[D1 15:08:25 floor_3] citizen_137 is leaving the queue
[D1 15:08:25 floor_3] citizen_168 was served
[D1 15:08:25 elevator_2] Summoned to floor 3 from floor 3
[D1 15:08:25 citizen_168] Entered elevator_2, going to floor 1
[D1 15:08:25 floor_3] citizen_168 is leaving the queue
[D1 15:08:25 floor_3] The queue is now empty
[D1 15:08:29 elevator_1] At floor 4
[D1 15:08:37 elevator_2] Closing doors
[D1 15:08:39 elevator_1] At floor 3
[D1 15:08:40 elevator_2] Closed doors
[D1 15:08:49 elevator_1] At floor 2
[D1 15:08:49 elevator_1] Stopped at floor 2
[D1 15:08:49 elevator_1] Opening doors
[D1 15:08:50 elevator_2] At floor 4
[D1 15:08:52 elevator_1] Opened doors
[D1 15:09:00 elevator_2] At floor 5
[D1 15:09:00 elevator_2] Stopped at floor 5
[D1 15:09:00 elevator_2] Opening doors
[D1 15:09:03 elevator_2] Opened doors
[D1 15:09:03 citizen_156] Left elevator_2, arrived at floor 5
[D1 15:09:04 elevator_1] Closing doors
[D1 15:09:07 elevator_1] Closed doors
[D1 15:09:11 citizen_143] Time to go to floor 5 and stay there for 00:32:01
[D1 15:09:11 floor_3] citizen_143 entered the queue
[D1 15:09:11 floor_3] citizen_143 found an empty queue and will be served immediately
[D1 15:09:11 elevator_1] Summoned to floor 3 from floor 2
[D1 15:09:15 elevator_2] Closing doors
[D1 15:09:17 elevator_1] At floor 1
[D1 15:09:18 elevator_2] Closed doors
[D1 15:09:18 elevator_2] Changing direction to Down
[D1 15:09:27 elevator_1] At floor 0
[D1 15:09:27 elevator_1] Stopped at floor 0
[D1 15:09:27 elevator_1] Opening doors
[D1 15:09:28 elevator_2] At floor 4
[D1 15:09:30 elevator_1] Opened doors
[D1 15:09:30 citizen_170] Time to go to floor 2 and stay there for 00:22:43
[D1 15:09:30 floor_1] citizen_170 entered the queue
[D1 15:09:30 floor_1] citizen_170 found an empty queue and will be served immediately
[D1 15:09:30 elevator_1] Summoned to floor 1 from floor 0
[D1 15:09:30 citizen_109] Left elevator_1, arrived at floor 0
[D1 15:09:30 citizen_109] Left the building
[D1 15:09:30 citizen_181] Entered elevator_1, going to floor 5
[D1 15:09:30 floor_0] citizen_181 is leaving the queue
[D1 15:09:30 floor_0] The queue is now empty
[D1 15:09:38 elevator_2] At floor 3
[D1 15:09:42 elevator_1] Closing doors
[D1 15:09:45 elevator_1] Closed doors
[D1 15:09:45 elevator_1] Changing direction to Up
[D1 15:09:48 elevator_2] At floor 2
[D1 15:09:48 elevator_2] Stopped at floor 2
[D1 15:09:48 elevator_2] Opening doors
[D1 15:09:51 elevator_2] Opened doors
[D1 15:09:51 citizen_138] Entered elevator_2, going to floor 0
[D1 15:09:51 floor_2] citizen_138 is leaving the queue
[D1 15:09:51 floor_2] The queue is now empty
[D1 15:09:54 citizen_182] Entered the building, will visit 4 floors in total
[D1 15:09:54 citizen_182] Time to go to floor 3 and stay there for 00:25:08
[D1 15:09:54 floor_0] citizen_182 entered the queue
[D1 15:09:54 floor_0] citizen_182 found an empty queue and will be served immediately
[D1 15:09:54 elevator_1] Summoned to floor 0 from floor 0
[D1 15:09:55 elevator_1] At floor 1
[D1 15:09:55 elevator_1] Stopped at floor 1
[D1 15:09:55 elevator_1] Opening doors
[D1 15:09:58 elevator_1] Opened doors
[D1 15:09:58 citizen_170] Entered elevator_1, going to floor 2
[D1 15:09:58 floor_1] citizen_170 is leaving the queue
[D1 15:09:58 floor_1] The queue is now empty
[D1 15:10:03 elevator_2] Closing doors
[D1 15:10:06 elevator_2] Closed doors
[D1 15:10:10 elevator_1] Closing doors
[D1 15:10:13 elevator_1] Closed doors
[D1 15:10:16 elevator_2] At floor 1
[D1 15:10:16 elevator_2] Stopped at floor 1
[D1 15:10:16 elevator_2] Opening doors
[D1 15:10:19 elevator_2] Opened doors
[D1 15:10:19 citizen_168] Left elevator_2, arrived at floor 1
[D1 15:10:23 elevator_1] At floor 2
[D1 15:10:23 elevator_1] Stopped at floor 2
[D1 15:10:23 elevator_1] Opening doors
[D1 15:10:26 elevator_1] Opened doors
[D1 15:10:26 citizen_170] Left elevator_1, arrived at floor 2
[D1 15:10:31 elevator_2] Closing doors
[D1 15:10:34 elevator_2] Closed doors
[D1 15:10:38 elevator_1] Closing doors
[D1 15:10:40 citizen_124] Time to go to floor 3 and stay there for 00:37:49
[D1 15:10:40 floor_2] citizen_124 entered the queue
[D1 15:10:40 floor_2] citizen_124 found an empty queue and will be served immediately
[D1 15:10:40 elevator_1] Summoned to floor 2 from floor 2
[D1 15:10:41 elevator_1] Reopening doors
[D1 15:10:41 citizen_124] Entered elevator_1, going to floor 3
[D1 15:10:41 floor_2] citizen_124 is leaving the queue
[D1 15:10:41 floor_2] The queue is now empty
[D1 15:10:44 elevator_2] At floor 0
[D1 15:10:44 elevator_2] Stopped at floor 0
[D1 15:10:44 elevator_2] Opening doors
[D1 15:10:47 elevator_2] Opened doors
[D1 15:10:47 citizen_132] Left elevator_2, arrived at floor 0
[D1 15:10:47 citizen_137] Left elevator_2, arrived at floor 0
[D1 15:10:47 citizen_138] Left elevator_2, arrived at floor 0
[D1 15:10:47 citizen_132] Left the building
[D1 15:10:47 citizen_137] Left the building
[D1 15:10:47 citizen_138] Left the building
[D1 15:10:52 citizen_129] Time to go to floor 4 and stay there for 00:23:29
[D1 15:10:52 floor_1] citizen_129 entered the queue
[D1 15:10:52 floor_1] citizen_129 found an empty queue and will be served immediately
[D1 15:10:52 elevator_1] Summoned to floor 1 from floor 2
[D1 15:10:52 elevator_2] Summoned to floor 1 from floor 0
[D1 15:10:53 elevator_1] Closing doors
[D1 15:10:56 elevator_1] Closed doors
[D1 15:10:59 elevator_2] Closing doors
[D1 15:11:02 elevator_2] Closed doors
[D1 15:11:02 elevator_2] Changing direction to Up
[D1 15:11:06 elevator_1] At floor 3
[D1 15:11:06 elevator_1] Stopped at floor 3
[D1 15:11:06 elevator_1] Opening doors
[D1 15:11:09 citizen_164] Time to go to floor 1 and stay there for 00:33:32
[D1 15:11:09 floor_4] citizen_164 entered the queue
[D1 15:11:09 floor_4] citizen_164 found an empty queue and will be served immediately
[D1 15:11:09 elevator_1] Summoned to floor 4 from floor 3
[D1 15:11:09 elevator_1] Opened doors
[D1 15:11:09 citizen_124] Left elevator_1, arrived at floor 3
[D1 15:11:09 citizen_143] Entered elevator_1, going to floor 5
[D1 15:11:09 floor_3] citizen_143 is leaving the queue
[D1 15:11:09 floor_3] The queue is now empty
[D1 15:11:12 elevator_2] At floor 1
[D1 15:11:12 elevator_2] Stopped at floor 1
[D1 15:11:12 elevator_2] Opening doors
[D1 15:11:15 elevator_2] Opened doors
[D1 15:11:15 citizen_129] Entered elevator_2, going to floor 4
[D1 15:11:15 floor_1] citizen_129 is leaving the queue
[D1 15:11:15 floor_1] The queue is now empty
[D1 15:11:21 elevator_1] Closing doors
[D1 15:11:24 elevator_1] Closed doors
[D1 15:11:27 elevator_2] Closing doors
[D1 15:11:30 elevator_2] Closed doors
[D1 15:11:34 elevator_1] At floor 4
[D1 15:11:34 elevator_1] Stopped at floor 4
[D1 15:11:34 elevator_1] Opening doors
[D1 15:11:37 elevator_1] Opened doors
[D1 15:11:37 citizen_164] Entered elevator_1, going to floor 1
[D1 15:11:37 floor_4] citizen_164 is leaving the queue
[D1 15:11:37 floor_4] The queue is now empty
[D1 15:11:40 elevator_2] At floor 2
[D1 15:11:41 citizen_116] Time to go to the ground floor and leave
[D1 15:11:41 floor_2] citizen_116 entered the queue
[D1 15:11:41 floor_2] citizen_116 found an empty queue and will be served immediately
[D1 15:11:41 elevator_2] Summoned to floor 2 from floor 2
[D1 15:11:49 elevator_1] Closing doors
[D1 15:11:50 elevator_2] At floor 3
[D1 15:11:52 elevator_1] Closed doors
[D1 15:12:00 elevator_2] At floor 4
[D1 15:12:00 elevator_2] Stopped at floor 4
[D1 15:12:00 elevator_2] Opening doors
[D1 15:12:02 elevator_1] At floor 5
[D1 15:12:02 elevator_1] Stopped at floor 5
[D1 15:12:02 elevator_1] Opening doors
[D1 15:12:03 elevator_2] Opened doors
[D1 15:12:03 citizen_129] Left elevator_2, arrived at floor 4
[D1 15:12:04 citizen_183] Entered the building, will visit 3 floors in total
[D1 15:12:04 citizen_183] Time to go to floor 3 and stay there for 00:32:46
[D1 15:12:04 floor_0] citizen_183 entered the queue
[D1 15:12:04 floor_0] citizen_183 is queued along with 0 other arrivals in front of it
[D1 15:12:05 elevator_1] Opened doors
[D1 15:12:05 citizen_181] Left elevator_1, arrived at floor 5
[D1 15:12:05 citizen_143] Left elevator_1, arrived at floor 5
[D1 15:12:15 elevator_2] Closing doors
[D1 15:12:17 elevator_1] Closing doors
[D1 15:12:18 elevator_2] Closed doors
[D1 15:12:18 elevator_2] Changing direction to Down
[D1 15:12:20 elevator_1] Closed doors
[D1 15:12:20 elevator_1] Changing direction to Down
[D1 15:12:28 elevator_2] At floor 3
[D1 15:12:30 elevator_1] At floor 4
[D1 15:12:38 elevator_2] At floor 2
[D1 15:12:38 elevator_2] Stopped at floor 2
[D1 15:12:38 elevator_2] Opening doors
[D1 15:12:40 elevator_1] At floor 3
[D1 15:12:41 elevator_2] Opened doors
[D1 15:12:41 citizen_116] Entered elevator_2, going to floor 0
[D1 15:12:41 floor_2] citizen_116 is leaving the queue
[D1 15:12:41 floor_2] The queue is now empty
[D1 15:12:50 elevator_1] At floor 2
[D1 15:12:53 elevator_2] Closing doors
[D1 15:12:55 citizen_123] Time to go to the ground floor and leave
[D1 15:12:55 floor_5] citizen_123 entered the queue
[D1 15:12:55 floor_5] citizen_123 found an empty queue and will be served immediately
[D1 15:12:55 elevator_1] Summoned to floor 5 from floor 2
[D1 15:12:55 elevator_2] Summoned to floor 5 from floor 2
[D1 15:12:56 elevator_2] Closed doors
[D1 15:13:00 elevator_1] At floor 1
[D1 15:13:00 elevator_1] Stopped at floor 1
[D1 15:13:00 elevator_1] Opening doors
[D1 15:13:03 elevator_1] Opened doors
[D1 15:13:03 citizen_164] Left elevator_1, arrived at floor 1
[D1 15:13:06 elevator_2] At floor 1
[D1 15:13:07 citizen_184] Entered the building, will visit 4 floors in total
[D1 15:13:07 citizen_184] Time to go to floor 5 and stay there for 00:25:10
[D1 15:13:07 floor_0] citizen_184 entered the queue
[D1 15:13:07 floor_0] citizen_184 is queued along with 1 other arrivals in front of it
[D1 15:13:09 citizen_160] Time to go to the ground floor and leave
[D1 15:13:09 floor_3] citizen_160 entered the queue
[D1 15:13:09 floor_3] citizen_160 found an empty queue and will be served immediately
[D1 15:13:09 elevator_1] Summoned to floor 3 from floor 1
[D1 15:13:09 elevator_2] Summoned to floor 3 from floor 1
[D1 15:13:09 citizen_158] Time to go to floor 1 and stay there for 00:30:46
[D1 15:13:09 floor_2] citizen_158 entered the queue
[D1 15:13:09 floor_2] citizen_158 found an empty queue and will be served immediately
[D1 15:13:09 elevator_1] Summoned to floor 2 from floor 1
[D1 15:13:09 elevator_2] Summoned to floor 2 from floor 1
[D1 15:13:15 elevator_1] Closing doors
[D1 15:13:16 elevator_2] At floor 0
[D1 15:13:16 elevator_2] Stopped at floor 0
[D1 15:13:16 elevator_2] Opening doors
[D1 15:13:18 elevator_1] Closed doors
[D1 15:13:19 elevator_2] Opened doors
[D1 15:13:19 citizen_116] Left elevator_2, arrived at floor 0
[D1 15:13:19 citizen_116] Left the building
[D1 15:13:28 elevator_1] At floor 0
[D1 15:13:28 elevator_1] Stopped at floor 0
[D1 15:13:28 elevator_1] Opening doors
[D1 15:13:31 elevator_2] Closing doors
[D1 15:13:31 elevator_1] Opened doors
[D1 15:13:31 citizen_182] Entered elevator_1, going to floor 3
[D1 15:13:31 floor_0] citizen_182 is leaving the queue
[D1 15:13:31 floor_0] citizen_183 was served
[D1 15:13:31 elevator_1] Summoned to floor 0 from floor 0
[D1 15:13:31 elevator_2] Summoned to floor 0 from floor 0
[D1 15:13:31 citizen_183] Entered elevator_1, going to floor 3
[D1 15:13:31 floor_0] citizen_183 is leaving the queue
[D1 15:13:31 floor_0] citizen_184 was served
[D1 15:13:31 elevator_1] Summoned to floor 0 from floor 0
[D1 15:13:31 elevator_2] Summoned to floor 0 from floor 0
[D1 15:13:31 citizen_184] Entered elevator_1, going to floor 5
[D1 15:13:31 floor_0] citizen_184 is leaving the queue
[D1 15:13:31 floor_0] The queue is now empty
[D1 15:13:34 elevator_2] Reopening doors
[D1 15:13:43 elevator_1] Closing doors
[D1 15:13:46 elevator_2] Closing doors
[D1 15:13:46 elevator_1] Closed doors
[D1 15:13:46 elevator_1] Changing direction to Up
[D1 15:13:49 elevator_2] Closed doors
[D1 15:13:49 elevator_2] Changing direction to Up
[D1 15:13:56 elevator_1] At floor 1
[D1 15:13:59 elevator_2] At floor 1
[D1 15:13:59 citizen_173] Time to go to floor 3 and stay there for 00:26:40
[D1 15:13:59 floor_2] citizen_173 entered the queue
[D1 15:13:59 floor_2] citizen_173 is queued along with 0 other arrivals in front of it
[D1 15:14:05 citizen_140] Time to go to floor 5 and stay there for 00:18:18
[D1 15:14:05 floor_3] citizen_140 entered the queue
[D1 15:14:05 floor_3] citizen_140 is queued along with 0 other arrivals in front of it
[D1 15:14:06 elevator_1] At floor 2
[D1 15:14:06 elevator_1] Stopped at floor 2
[D1 15:14:06 elevator_1] Opening doors
[D1 15:14:09 elevator_2] At floor 2
[D1 15:14:09 elevator_2] Stopped at floor 2
[D1 15:14:09 elevator_2] Opening doors
[D1 15:14:09 elevator_1] Opened doors
[D1 15:14:09 citizen_158] Entered elevator_1, going to floor 1
[D1 15:14:09 floor_2] citizen_158 is leaving the queue
[D1 15:14:09 floor_2] citizen_173 was served
[D1 15:14:09 elevator_1] Summoned to floor 2 from floor 2
[D1 15:14:09 elevator_2] Summoned to floor 2 from floor 2
[D1 15:14:09 citizen_173] Cannot enter elevator_1, it is full
[D1 15:14:12 elevator_2] Opened doors
[D1 15:14:12 citizen_173] Entered elevator_2, going to floor 3
[D1 15:14:12 floor_2] citizen_173 is leaving the queue
[D1 15:14:12 floor_2] The queue is now empty
[D1 15:14:21 elevator_1] Closing doors
[D1 15:14:24 elevator_2] Closing doors
[D1 15:14:24 elevator_1] Closed doors
[D1 15:14:27 elevator_2] Closed doors
[D1 15:14:34 elevator_1] At floor 3
[D1 15:14:34 elevator_1] Stopped at floor 3
[D1 15:14:34 elevator_1] Opening doors
[D1 15:14:37 elevator_2] At floor 3
[D1 15:14:37 elevator_2] Stopped at floor 3
[D1 15:14:37 elevator_2] Opening doors
[D1 15:14:37 elevator_1] Opened doors
[D1 15:14:37 citizen_182] Left elevator_1, arrived at floor 3
[D1 15:14:37 citizen_183] Left elevator_1, arrived at floor 3
[D1 15:14:37 citizen_160] Entered elevator_1, going to floor 0
[D1 15:14:37 floor_3] citizen_160 is leaving the queue
[D1 15:14:37 floor_3] citizen_140 was served
[D1 15:14:37 elevator_1] Summoned to floor 3 from floor 3
[D1 15:14:37 elevator_2] Summoned to floor 3 from floor 3
[D1 15:14:37 citizen_140] Entered elevator_1, going to floor 5
[D1 15:14:37 floor_3] citizen_140 is leaving the queue
[D1 15:14:37 floor_3] The queue is now empty
[D1 15:14:40 elevator_2] Opened doors
[D1 15:14:40 citizen_173] Left elevator_2, arrived at floor 3
[D1 15:14:49 elevator_1] Closing doors
[D1 15:14:52 elevator_2] Closing doors
[D1 15:14:52 elevator_1] Closed doors
[D1 15:14:55 elevator_2] Closed doors
[D1 15:15:02 elevator_1] At floor 4
[D1 15:15:05 elevator_2] At floor 4
[D1 15:15:08 citizen_161] Time to go to floor 5 and stay there for 00:38:48
[D1 15:15:08 floor_1] citizen_161 entered the queue
[D1 15:15:08 floor_1] citizen_161 found an empty queue and will be served immediately
[D1 15:15:08 elevator_1] Summoned to floor 1 from floor 4
[D1 15:15:08 elevator_2] Summoned to floor 1 from floor 4
[D1 15:15:12 elevator_1] At floor 5
[D1 15:15:12 elevator_1] Stopped at floor 5
[D1 15:15:12 elevator_1] Opening doors
[D1 15:15:15 elevator_2] At floor 5
[D1 15:15:15 elevator_2] Stopped at floor 5
[D1 15:15:15 elevator_2] Opening doors
[D1 15:15:15 elevator_1] Opened doors
[D1 15:15:15 citizen_184] Left elevator_1, arrived at floor 5
[D1 15:15:15 citizen_140] Left elevator_1, arrived at floor 5
[D1 15:15:15 citizen_123] Entered elevator_1, going to floor 0
[D1 15:15:15 floor_5] citizen_123 is leaving the queue
[D1 15:15:15 floor_5] The queue is now empty
[D1 15:15:18 elevator_2] Opened doors
[D1 15:15:25 citizen_147] Time to go to floor 1 and stay there for 00:36:49
[D1 15:15:25 floor_4] citizen_147 entered the queue
[D1 15:15:25 floor_4] citizen_147 found an empty queue and will be served immediately
[D1 15:15:25 elevator_1] Summoned to floor 4 from floor 5
[D1 15:15:25 elevator_2] Summoned to floor 4 from floor 5
[D1 15:15:27 elevator_1] Closing doors
[D1 15:15:30 elevator_2] Closing doors
[D1 15:15:30 elevator_1] Closed doors
[D1 15:15:30 elevator_1] Changing direction to Down
[D1 15:15:33 elevator_2] Closed doors
[D1 15:15:33 elevator_2] Changing direction to Down
[D1 15:15:40 elevator_1] At floor 4
[D1 15:15:40 elevator_1] Stopped at floor 4
[D1 15:15:40 elevator_1] Opening doors
[D1 15:15:43 elevator_2] At floor 4
[D1 15:15:43 elevator_2] Stopped at floor 4
[D1 15:15:43 elevator_2] Opening doors
[D1 15:15:43 elevator_1] Opened doors
[D1 15:15:43 citizen_147] Entered elevator_1, going to floor 1
[D1 15:15:43 floor_4] citizen_147 is leaving the queue
[D1 15:15:43 floor_4] The queue is now empty
[D1 15:15:46 elevator_2] Opened doors
[D1 15:15:55 elevator_1] Closing doors
[D1 15:15:58 elevator_2] Closing doors
[D1 15:15:58 elevator_1] Closed doors
[D1 15:16:01 elevator_2] Closed doors
[D1 15:16:08 elevator_1] At floor 3
[D1 15:16:11 elevator_2] At floor 3
[D1 15:16:18 elevator_1] At floor 2
[D1 15:16:21 elevator_2] At floor 2
[D1 15:16:27 citizen_148] Time to go to floor 4 and stay there for 00:31:15
[D1 15:16:27 floor_5] citizen_148 entered the queue
[D1 15:16:27 floor_5] citizen_148 found an empty queue and will be served immediately
[D1 15:16:27 elevator_1] Summoned to floor 5 from floor 2
[D1 15:16:27 elevator_2] Summoned to floor 5 from floor 2
[D1 15:16:28 elevator_1] At floor 1
[D1 15:16:28 elevator_1] Stopped at floor 1
[D1 15:16:28 elevator_1] Opening doors
[D1 15:16:31 elevator_2] At floor 1
[D1 15:16:31 elevator_2] Stopped at floor 1
[D1 15:16:31 elevator_2] Opening doors
[D1 15:16:31 elevator_1] Opened doors
[D1 15:16:31 citizen_158] Left elevator_1, arrived at floor 1
[D1 15:16:31 citizen_147] Left elevator_1, arrived at floor 1
[D1 15:16:31 citizen_161] Entered elevator_1, going to floor 5
[D1 15:16:31 floor_1] citizen_161 is leaving the queue
[D1 15:16:31 floor_1] The queue is now empty
[D1 15:16:34 elevator_2] Opened doors
[D1 15:16:41 citizen_185] Entered the building, will visit 4 floors in total
[D1 15:16:41 citizen_185] Time to go to floor 3 and stay there for 00:34:06
[D1 15:16:41 floor_0] citizen_185 entered the queue
[D1 15:16:41 floor_0] citizen_185 found an empty queue and will be served immediately
[D1 15:16:41 elevator_1] Summoned to floor 0 from floor 1
[D1 15:16:41 elevator_2] Summoned to floor 0 from floor 1
[D1 15:16:43 elevator_1] Closing doors
[D1 15:16:46 elevator_2] Closing doors
[D1 15:16:46 elevator_1] Closed doors
[D1 15:16:49 elevator_2] Closed doors
[D1 15:16:56 elevator_1] At floor 0
[D1 15:16:56 elevator_1] Stopped at floor 0
[D1 15:16:56 elevator_1] Opening doors
[D1 15:16:59 elevator_2] At floor 0
[D1 15:16:59 elevator_2] Stopped at floor 0
[D1 15:16:59 elevator_2] Opening doors
[D1 15:16:59 elevator_1] Opened doors
[D1 15:16:59 citizen_160] Left elevator_1, arrived at floor 0
[D1 15:16:59 citizen_123] Left elevator_1, arrived at floor 0
[D1 15:16:59 citizen_160] Left the building
[D1 15:16:59 citizen_123] Left the building
[D1 15:16:59 citizen_185] Entered elevator_1, going to floor 3
[D1 15:16:59 floor_0] citizen_185 is leaving the queue
[D1 15:16:59 floor_0] The queue is now empty
[D1 15:17:02 elevator_2] Opened doors
[D1 15:17:11 elevator_1] Closing doors
[D1 15:17:14 elevator_2] Closing doors
[D1 15:17:14 elevator_1] Closed doors
[D1 15:17:14 elevator_1] Changing direction to Up
[D1 15:17:17 elevator_2] Closed doors
[D1 15:17:17 elevator_2] Changing direction to Up
[D1 15:17:24 elevator_1] At floor 1
[D1 15:17:27 elevator_2] At floor 1
[D1 15:17:31 citizen_134] Time to go to floor 5 and stay there for 00:19:48
[D1 15:17:31 floor_4] citizen_134 entered the queue
[D1 15:17:31 floor_4] citizen_134 found an empty queue and will be served immediately
[D1 15:17:31 elevator_1] Summoned to floor 4 from floor 1
[D1 15:17:31 elevator_2] Summoned to floor 4 from floor 1
[D1 15:17:34 elevator_1] At floor 2
[D1 15:17:37 elevator_2] At floor 2
[D1 15:17:44 elevator_1] At floor 3
[D1 15:17:44 elevator_1] Stopped at floor 3
[D1 15:17:44 elevator_1] Opening doors
[D1 15:17:47 elevator_2] At floor 3
[D1 15:17:47 elevator_1] Opened doors
[D1 15:17:47 citizen_185] Left elevator_1, arrived at floor 3
[D1 15:17:53 citizen_186] Entered the building, will visit 5 floors in total
[D1 15:17:53 citizen_186] Time to go to floor 3 and stay there for 00:24:09
[D1 15:17:53 floor_0] citizen_186 entered the queue
[D1 15:17:53 floor_0] citizen_186 found an empty queue and will be served immediately
[D1 15:17:53 elevator_1] Summoned to floor 0 from floor 3
[D1 15:17:53 elevator_2] Summoned to floor 0 from floor 3
[D1 15:17:54 citizen_146] Time to go to floor 3 and stay there for 00:30:48
[D1 15:17:54 floor_5] citizen_146 entered the queue
[D1 15:17:54 floor_5] citizen_146 is queued along with 0 other arrivals in front of it
[D1 15:17:57 elevator_2] At floor 4
[D1 15:17:57 elevator_2] Stopped at floor 4
[D1 15:17:57 elevator_2] Opening doors
[D1 15:17:59 elevator_1] Closing doors
[D1 15:18:00 elevator_2] Opened doors
[D1 15:18:00 citizen_134] Entered elevator_2, going to floor 5
[D1 15:18:00 floor_4] citizen_134 is leaving the queue
[D1 15:18:00 floor_4] The queue is now empty
[D1 15:18:02 elevator_1] Closed doors
[D1 15:18:07 citizen_172] Time to go to floor 3 and stay there for 00:24:08
[D1 15:18:07 floor_2] citizen_172 entered the queue
[D1 15:18:07 floor_2] citizen_172 found an empty queue and will be served immediately
[D1 15:18:07 elevator_1] Summoned to floor 2 from floor 3
[D1 15:18:12 elevator_2] Closing doors
[D1 15:18:12 elevator_1] At floor 4
[D1 15:18:12 elevator_1] Stopped at floor 4
[D1 15:18:12 elevator_1] Opening doors
[D1 15:18:15 elevator_2] Closed doors
[D1 15:18:15 elevator_1] Opened doors
[D1 15:18:25 elevator_2] At floor 5
[D1 15:18:25 elevator_2] Stopped at floor 5
[D1 15:18:25 elevator_2] Opening doors
[D1 15:18:27 elevator_1] Closing doors
[D1 15:18:28 elevator_2] Opened doors
[D1 15:18:28 citizen_134] Left elevator_2, arrived at floor 5
[D1 15:18:28 citizen_148] Entered elevator_2, going to floor 4
[D1 15:18:28 floor_5] citizen_148 is leaving the queue
[D1 15:18:28 floor_5] citizen_146 was served
[D1 15:18:28 elevator_2] Summoned to floor 5 from floor 5
[D1 15:18:28 citizen_146] Entered elevator_2, going to floor 3
[D1 15:18:28 floor_5] citizen_146 is leaving the queue
[D1 15:18:28 floor_5] The queue is now empty
[D1 15:18:30 elevator_1] Closed doors
[D1 15:18:40 elevator_2] Closing doors
[D1 15:18:40 elevator_1] At floor 5
[D1 15:18:40 elevator_1] Stopped at floor 5
[D1 15:18:40 elevator_1] Opening doors
[D1 15:18:43 elevator_2] Closed doors
[D1 15:18:43 elevator_1] Opened doors
[D1 15:18:43 elevator_2] Changing direction to Down
[D1 15:18:43 citizen_161] Left elevator_1, arrived at floor 5
[D1 15:18:53 elevator_2] At floor 4
[D1 15:18:53 elevator_2] Stopped at floor 4
[D1 15:18:53 elevator_2] Opening doors
[D1 15:18:55 elevator_1] Closing doors
[D1 15:18:56 elevator_2] Opened doors
[D1 15:18:56 citizen_148] Left elevator_2, arrived at floor 4
[D1 15:18:58 elevator_1] Closed doors
[D1 15:18:58 elevator_1] Changing direction to Down
[D1 15:19:08 elevator_2] Closing doors
[D1 15:19:08 elevator_1] At floor 4
[D1 15:19:09 citizen_151] Time to go to the ground floor and leave
[D1 15:19:09 floor_4] citizen_151 entered the queue
[D1 15:19:09 floor_4] citizen_151 found an empty queue and will be served immediately
[D1 15:19:09 elevator_1] Summoned to floor 4 from floor 4
[D1 15:19:09 elevator_2] Summoned to floor 4 from floor 4
[D1 15:19:09 citizen_157] Time to go to floor 2 and stay there for 00:35:02
[D1 15:19:09 floor_3] citizen_157 entered the queue
[D1 15:19:09 floor_3] citizen_157 found an empty queue and will be served immediately
[D1 15:19:09 elevator_1] Summoned to floor 3 from floor 4
[D1 15:19:09 elevator_2] Summoned to floor 3 from floor 4
[D1 15:19:11 elevator_2] Reopening doors
[D1 15:19:11 citizen_151] Entered elevator_2, going to floor 0
[D1 15:19:11 floor_4] citizen_151 is leaving the queue
[D1 15:19:11 floor_4] The queue is now empty
[D1 15:19:18 elevator_1] At floor 3
[D1 15:19:18 elevator_1] Stopped at floor 3
[D1 15:19:18 elevator_1] Opening doors
[D1 15:19:21 citizen_127] Time to go to floor 2 and stay there for 00:17:47
[D1 15:19:21 floor_3] citizen_127 entered the queue
[D1 15:19:21 floor_3] citizen_127 is queued along with 0 other arrivals in front of it
[D1 15:19:21 elevator_1] Opened doors
[D1 15:19:21 citizen_157] Entered elevator_1, going to floor 2
[D1 15:19:21 floor_3] citizen_157 is leaving the queue
[D1 15:19:21 floor_3] citizen_127 was served
[D1 15:19:21 elevator_1] Summoned to floor 3 from floor 3
[D1 15:19:21 citizen_127] Entered elevator_1, going to floor 2
[D1 15:19:21 floor_3] citizen_127 is leaving the queue
[D1 15:19:21 floor_3] The queue is now empty
[D1 15:19:23 elevator_2] Closing doors
[D1 15:19:26 elevator_2] Closed doors
[D1 15:19:33 elevator_1] Closing doors
[D1 15:19:33 citizen_187] Entered the building, will visit 4 floors in total
[D1 15:19:33 citizen_187] Time to go to floor 4 and stay there for 00:19:42
[D1 15:19:33 floor_0] citizen_187 entered the queue
[D1 15:19:33 floor_0] citizen_187 is queued along with 0 other arrivals in front of it
[D1 15:19:36 elevator_2] At floor 3
[D1 15:19:36 elevator_2] Stopped at floor 3
[D1 15:19:36 elevator_2] Opening doors
[D1 15:19:36 elevator_1] Closed doors
[D1 15:19:39 elevator_2] Opened doors
[D1 15:19:39 citizen_146] Left elevator_2, arrived at floor 3
[D1 15:19:46 elevator_1] At floor 2
[D1 15:19:46 elevator_1] Stopped at floor 2
[D1 15:19:46 elevator_1] Opening doors
[D1 15:19:49 elevator_1] Opened doors
[D1 15:19:49 citizen_157] Left elevator_1, arrived at floor 2
[D1 15:19:49 citizen_127] Left elevator_1, arrived at floor 2
[D1 15:19:49 citizen_172] Entered elevator_1, going to floor 3
[D1 15:19:49 floor_2] citizen_172 is leaving the queue
[D1 15:19:49 floor_2] The queue is now empty
[D1 15:19:51 elevator_2] Closing doors
[D1 15:19:54 elevator_2] Closed doors
[D1 15:20:01 elevator_1] Closing doors
[D1 15:20:04 elevator_2] At floor 2
[D1 15:20:04 elevator_1] Closed doors
[D1 15:20:14 elevator_2] At floor 1
[D1 15:20:14 elevator_1] At floor 1
[D1 15:20:24 elevator_2] At floor 0
[D1 15:20:24 elevator_2] Stopped at floor 0
[D1 15:20:24 elevator_2] Opening doors
[D1 15:20:24 elevator_1] At floor 0
[D1 15:20:24 elevator_1] Stopped at floor 0
[D1 15:20:24 elevator_1] Opening doors
[D1 15:20:25 citizen_139] Time to go to floor 4 and stay there for 00:23:14
[D1 15:20:25 floor_2] citizen_139 entered the queue
[D1 15:20:25 floor_2] citizen_139 found an empty queue and will be served immediately
[D1 15:20:25 elevator_1] Summoned to floor 2 from floor 0
[D1 15:20:25 elevator_2] Summoned to floor 2 from floor 0
[D1 15:20:27 elevator_2] Opened doors
[D1 15:20:27 elevator_1] Opened doors
[D1 15:20:27 citizen_151] Left elevator_2, arrived at floor 0
[D1 15:20:27 citizen_151] Left the building
[D1 15:20:27 citizen_186] Entered elevator_2, going to floor 3
[D1 15:20:27 floor_0] citizen_186 is leaving the queue
[D1 15:20:27 floor_0] citizen_187 was served
[D1 15:20:27 elevator_1] Summoned to floor 0 from floor 0
[D1 15:20:27 elevator_2] Summoned to floor 0 from floor 0
[D1 15:20:27 citizen_187] Entered elevator_1, going to floor 4
[D1 15:20:27 floor_0] citizen_187 is leaving the queue
[D1 15:20:27 floor_0] The queue is now empty
[D1 15:20:39 elevator_2] Closing doors
[D1 15:20:39 elevator_1] Closing doors
[D1 15:20:42 elevator_2] Closed doors
[D1 15:20:42 elevator_1] Closed doors
[D1 15:20:42 elevator_2] Changing direction to Up
[D1 15:20:42 elevator_1] Changing direction to Up
[D1 15:20:48 citizen_188] Entered the building, will visit 4 floors in total
[D1 15:20:48 citizen_188] Time to go to floor 4 and stay there for 00:19:07
[D1 15:20:48 floor_0] citizen_188 entered the queue
[D1 15:20:48 floor_0] citizen_188 found an empty queue and will be served immediately
[D1 15:20:48 elevator_1] Summoned to floor 0 from floor 0
[D1 15:20:48 elevator_2] Summoned to floor 0 from floor 0
[D1 15:20:52 elevator_2] At floor 1
[D1 15:20:52 elevator_1] At floor 1
[D1 15:21:02 elevator_2] At floor 2
[D1 15:21:02 elevator_2] Stopped at floor 2
[D1 15:21:02 elevator_2] Opening doors
[D1 15:21:02 elevator_1] At floor 2
[D1 15:21:02 elevator_1] Stopped at floor 2
[D1 15:21:02 elevator_1] Opening doors
[D1 15:21:05 elevator_2] Opened doors
[D1 15:21:05 elevator_1] Opened doors
[D1 15:21:05 citizen_139] Entered elevator_2, going to floor 4
[D1 15:21:05 floor_2] citizen_139 is leaving the queue
[D1 15:21:05 floor_2] The queue is now empty
[D1 15:21:17 elevator_2] Closing doors
[D1 15:21:17 elevator_1] Closing doors
[D1 15:21:20 elevator_2] Closed doors
[D1 15:21:20 elevator_1] Closed doors
[D1 15:21:30 elevator_2] At floor 3
[D1 15:21:30 elevator_2] Stopped at floor 3
[D1 15:21:30 elevator_2] Opening doors
[D1 15:21:30 elevator_1] At floor 3
[D1 15:21:30 elevator_1] Stopped at floor 3
[D1 15:21:30 elevator_1] Opening doors
[D1 15:21:33 elevator_2] Opened doors
[D1 15:21:33 elevator_1] Opened doors
[D1 15:21:33 citizen_186] Left elevator_2, arrived at floor 3
[D1 15:21:33 citizen_172] Left elevator_1, arrived at floor 3
[D1 15:21:45 elevator_2] Closing doors
[D1 15:21:45 elevator_1] Closing doors
[D1 15:21:48 elevator_2] Closed doors
[D1 15:21:48 elevator_1] Closed doors
[D1 15:21:56 citizen_145] Time to go to the ground floor and leave
[D1 15:21:56 floor_3] citizen_145 entered the queue
[D1 15:21:56 floor_3] citizen_145 found an empty queue and will be served immediately
[D1 15:21:56 elevator_1] Summoned to floor 3 from floor 3
[D1 15:21:56 elevator_2] Summoned to floor 3 from floor 3
[D1 15:21:58 elevator_2] At floor 4
[D1 15:21:58 elevator_2] Stopped at floor 4
[D1 15:21:58 elevator_2] Opening doors
[D1 15:21:58 elevator_1] At floor 4
[D1 15:21:58 elevator_1] Stopped at floor 4
[D1 15:21:58 elevator_1] Opening doors
[D1 15:22:01 elevator_2] Opened doors
[D1 15:22:01 elevator_1] Opened doors
[D1 15:22:01 citizen_139] Left elevator_2, arrived at floor 4
[D1 15:22:01 citizen_187] Left elevator_1, arrived at floor 4
[D1 15:22:13 elevator_1] Closing doors
[D1 15:22:13 elevator_2] Closing doors
[D1 15:22:14 citizen_189] Entered the building, will visit 5 floors in total
[D1 15:22:14 citizen_189] Time to go to floor 5 and stay there for 00:41:06
[D1 15:22:14 floor_0] citizen_189 entered the queue
[D1 15:22:14 floor_0] citizen_189 is queued along with 0 other arrivals in front of it
[D1 15:22:16 elevator_1] Closed doors
[D1 15:22:16 elevator_2] Closed doors
[D1 15:22:16 elevator_1] Changing direction to Down
[D1 15:22:16 elevator_2] Changing direction to Down
[D1 15:22:26 elevator_1] At floor 3
[D1 15:22:26 elevator_1] Stopped at floor 3
[D1 15:22:26 elevator_1] Opening doors
[D1 15:22:26 elevator_2] At floor 3
[D1 15:22:26 elevator_2] Stopped at floor 3
[D1 15:22:26 elevator_2] Opening doors
[D1 15:22:29 elevator_1] Opened doors
[D1 15:22:29 elevator_2] Opened doors
[D1 15:22:29 citizen_145] Entered elevator_1, going to floor 0
[D1 15:22:29 floor_3] citizen_145 is leaving the queue
[D1 15:22:29 floor_3] The queue is now empty
[D1 15:22:41 elevator_1] Closing doors
[D1 15:22:41 elevator_2] Closing doors
[D1 15:22:44 elevator_1] Closed doors
[D1 15:22:44 elevator_2] Closed doors
[D1 15:22:46 citizen_133] Time to go to floor 2 and stay there for 00:19:15
[D1 15:22:46 floor_1] citizen_133 entered the queue
[D1 15:22:46 floor_1] citizen_133 found an empty queue and will be served immediately
[D1 15:22:46 elevator_1] Summoned to floor 1 from floor 3
[D1 15:22:46 elevator_2] Summoned to floor 1 from floor 3
[D1 15:22:54 elevator_1] At floor 2
[D1 15:22:54 elevator_2] At floor 2
[D1 15:23:01 citizen_130] Time to go to the ground floor and leave
[D1 15:23:01 floor_2] citizen_130 entered the queue
[D1 15:23:01 floor_2] citizen_130 found an empty queue and will be served immediately
[D1 15:23:01 elevator_1] Summoned to floor 2 from floor 2
[D1 15:23:01 elevator_2] Summoned to floor 2 from floor 2
[D1 15:23:04 elevator_1] At floor 1
[D1 15:23:04 elevator_1] Stopped at floor 1
[D1 15:23:04 elevator_1] Opening doors
[D1 15:23:04 elevator_2] At floor 1
[D1 15:23:04 elevator_2] Stopped at floor 1
[D1 15:23:04 elevator_2] Opening doors
[D1 15:23:07 elevator_1] Opened doors
[D1 15:23:07 elevator_2] Opened doors
[D1 15:23:07 citizen_133] Entered elevator_1, going to floor 2
[D1 15:23:07 floor_1] citizen_133 is leaving the queue
[D1 15:23:07 floor_1] The queue is now empty
[D1 15:23:19 elevator_1] Closing doors
[D1 15:23:19 elevator_2] Closing doors
[D1 15:23:22 elevator_1] Closed doors
[D1 15:23:22 elevator_2] Closed doors
[D1 15:23:32 elevator_1] At floor 0
[D1 15:23:32 elevator_1] Stopped at floor 0
[D1 15:23:32 elevator_1] Opening doors
[D1 15:23:32 elevator_2] At floor 0
[D1 15:23:32 elevator_2] Stopped at floor 0
[D1 15:23:32 elevator_2] Opening doors
[D1 15:23:35 elevator_1] Opened doors
[D1 15:23:35 elevator_2] Opened doors
[D1 15:23:35 citizen_145] Left elevator_1, arrived at floor 0
[D1 15:23:35 citizen_145] Left the building
[D1 15:23:35 citizen_188] Entered elevator_1, going to floor 4
[D1 15:23:35 floor_0] citizen_188 is leaving the queue
[D1 15:23:35 floor_0] citizen_189 was served
[D1 15:23:35 elevator_1] Summoned to floor 0 from floor 0
[D1 15:23:35 elevator_2] Summoned to floor 0 from floor 0
[D1 15:23:35 citizen_189] Entered elevator_1, going to floor 5
[D1 15:23:35 floor_0] citizen_189 is leaving the queue
[D1 15:23:35 floor_0] The queue is now empty
[D1 15:23:36 citizen_154] Time to go to floor 4 and stay there for 00:33:02
[D1 15:23:36 floor_5] citizen_154 entered the queue
[D1 15:23:36 floor_5] citizen_154 found an empty queue and will be served immediately
[D1 15:23:36 elevator_1] Summoned to floor 5 from floor 0
[D1 15:23:36 elevator_2] Summoned to floor 5 from floor 0
[D1 15:23:47 elevator_1] Closing doors
[D1 15:23:47 elevator_2] Closing doors
[D1 15:23:50 elevator_1] Closed doors
[D1 15:23:50 elevator_2] Closed doors
[D1 15:23:50 elevator_1] Changing direction to Up
[D1 15:23:50 elevator_2] Changing direction to Up
[D1 15:24:00 elevator_1] At floor 1
[D1 15:24:00 elevator_2] At floor 1
[D1 15:24:10 elevator_1] At floor 2
[D1 15:24:10 elevator_1] Stopped at floor 2
[D1 15:24:10 elevator_1] Opening doors
[D1 15:24:10 elevator_2] At floor 2
[D1 15:24:10 elevator_2] Stopped at floor 2
[D1 15:24:10 elevator_2] Opening doors
[D1 15:24:13 elevator_1] Opened doors
[D1 15:24:13 elevator_2] Opened doors
[D1 15:24:13 citizen_133] Left elevator_1, arrived at floor 2
[D1 15:24:13 citizen_130] Entered elevator_1, going to floor 0
[D1 15:24:13 floor_2] citizen_130 is leaving the queue
[D1 15:24:13 floor_2] The queue is now empty
[D1 15:24:14 citizen_152] Time to go to floor 5 and stay there for 00:17:31
[D1 15:24:14 floor_2] citizen_152 entered the queue
[D1 15:24:14 floor_2] citizen_152 found an empty queue and will be served immediately
[D1 15:24:14 elevator_1] Summoned to floor 2 from floor 2
[D1 15:24:14 elevator_2] Summoned to floor 2 from floor 2
[D1 15:24:14 citizen_152] Entered elevator_1, going to floor 5
[D1 15:24:14 floor_2] citizen_152 is leaving the queue
[D1 15:24:14 floor_2] The queue is now empty
[D1 15:24:25 elevator_1] Closing doors
[D1 15:24:25 elevator_2] Closing doors
[D1 15:24:28 elevator_1] Closed doors
[D1 15:24:28 elevator_2] Closed doors
[D1 15:24:37 citizen_125] Time to go to the ground floor and leave
[D1 15:24:37 floor_4] citizen_125 entered the queue
[D1 15:24:37 floor_4] citizen_125 found an empty queue and will be served immediately
[D1 15:24:37 elevator_1] Summoned to floor 4 from floor 2
[D1 15:24:37 elevator_2] Summoned to floor 4 from floor 2
[D1 15:24:38 elevator_1] At floor 3
[D1 15:24:38 elevator_2] At floor 3
[D1 15:24:48 elevator_1] At floor 4
[D1 15:24:48 elevator_1] Stopped at floor 4
[D1 15:24:48 elevator_1] Opening doors
[D1 15:24:48 elevator_2] At floor 4
[D1 15:24:48 elevator_2] Stopped at floor 4
[D1 15:24:48 elevator_2] Opening doors
[D1 15:24:51 elevator_1] Opened doors
[D1 15:24:51 elevator_2] Opened doors
[D1 15:24:51 citizen_188] Left elevator_1, arrived at floor 4
[D1 15:24:51 citizen_125] Entered elevator_1, going to floor 0
[D1 15:24:51 floor_4] citizen_125 is leaving the queue
[D1 15:24:51 floor_4] The queue is now empty
[D1 15:25:03 elevator_2] Closing doors
[D1 15:25:03 elevator_1] Closing doors
[D1 15:25:06 elevator_2] Closed doors
[D1 15:25:06 elevator_1] Closed doors
[D1 15:25:16 elevator_2] At floor 5
[D1 15:25:16 elevator_2] Stopped at floor 5
[D1 15:25:16 elevator_2] Opening doors
[D1 15:25:16 elevator_1] At floor 5
[D1 15:25:16 elevator_1] Stopped at floor 5
[D1 15:25:16 elevator_1] Opening doors
[D1 15:25:19 elevator_2] Opened doors
[D1 15:25:19 elevator_1] Opened doors
[D1 15:25:19 citizen_189] Left elevator_1, arrived at floor 5
[D1 15:25:19 citizen_152] Left elevator_1, arrived at floor 5
[D1 15:25:19 citizen_154] Entered elevator_2, going to floor 4
[D1 15:25:19 floor_5] citizen_154 is leaving the queue
[D1 15:25:19 floor_5] The queue is now empty
[D1 15:25:31 elevator_2] Closing doors
[D1 15:25:31 elevator_1] Closing doors
[D1 15:25:34 elevator_2] Closed doors
[D1 15:25:34 elevator_1] Closed doors
[D1 15:25:34 elevator_2] Changing direction to Down
[D1 15:25:34 elevator_1] Changing direction to Down
[D1 15:25:44 elevator_2] At floor 4
[D1 15:25:44 elevator_2] Stopped at floor 4
[D1 15:25:44 elevator_2] Opening doors
[D1 15:25:44 elevator_1] At floor 4
[D1 15:25:47 elevator_2] Opened doors
[D1 15:25:47 citizen_154] Left elevator_2, arrived at floor 4
[D1 15:25:54 elevator_1] At floor 3
[D1 15:25:59 citizen_190] Entered the building, will visit 3 floors in total
[D1 15:25:59 citizen_190] Time to go to floor 2 and stay there for 00:35:53
[D1 15:25:59 floor_0] citizen_190 entered the queue
[D1 15:25:59 floor_0] citizen_190 found an empty queue and will be served immediately
[D1 15:25:59 elevator_1] Summoned to floor 0 from floor 3
[D1 15:25:59 elevator_2] Closing doors
[D1 15:26:02 elevator_2] Closed doors
[D1 15:26:02 elevator_2] Resting at floor 4
[D1 15:26:04 elevator_1] At floor 2
[D1 15:26:14 citizen_141] Time to go to the ground floor and leave
[D1 15:26:14 floor_2] citizen_141 entered the queue
[D1 15:26:14 floor_2] citizen_141 found an empty queue and will be served immediately
[D1 15:26:14 elevator_1] Summoned to floor 2 from floor 2
[D1 15:26:14 elevator_1] At floor 1
[D1 15:26:24 elevator_1] At floor 0
[D1 15:26:24 elevator_1] Stopped at floor 0
[D1 15:26:24 elevator_1] Opening doors
[D1 15:26:27 elevator_1] Opened doors
[D1 15:26:27 citizen_130] Left elevator_1, arrived at floor 0
[D1 15:26:27 citizen_125] Left elevator_1, arrived at floor 0
[D1 15:26:27 citizen_130] Left the building
[D1 15:26:27 citizen_125] Left the building
[D1 15:26:27 citizen_190] Entered elevator_1, going to floor 2
[D1 15:26:27 floor_0] citizen_190 is leaving the queue
[D1 15:26:27 floor_0] The queue is now empty
[D1 15:26:28 citizen_178] Time to go to floor 5 and stay there for 00:28:37
[D1 15:26:28 floor_2] citizen_178 entered the queue
[D1 15:26:28 floor_2] citizen_178 is queued along with 0 other arrivals in front of it
[D1 15:26:39 elevator_1] Closing doors
[D1 15:26:42 elevator_1] Closed doors
[D1 15:26:42 elevator_1] Changing direction to Up
[D1 15:26:49 citizen_128] Time to go to floor 2 and stay there for 00:15:44
[D1 15:26:49 floor_3] citizen_128 entered the queue
[D1 15:26:49 floor_3] citizen_128 found an empty queue and will be served immediately
[D1 15:26:49 elevator_2] Summoned to floor 3 from floor 4
[D1 15:26:49 elevator_2] Sprung into motion, heading Down
[D1 15:26:52 elevator_1] At floor 1
[D1 15:26:59 elevator_2] At floor 3
[D1 15:26:59 elevator_2] Stopped at floor 3
[D1 15:26:59 elevator_2] Opening doors
[D1 15:27:02 elevator_1] At floor 2
[D1 15:27:02 elevator_1] Stopped at floor 2
[D1 15:27:02 elevator_1] Opening doors
[D1 15:27:02 elevator_2] Opened doors
[D1 15:27:02 citizen_128] Entered elevator_2, going to floor 2
[D1 15:27:02 floor_3] citizen_128 is leaving the queue
[D1 15:27:02 floor_3] The queue is now empty
[D1 15:27:05 elevator_1] Opened doors
[D1 15:27:05 citizen_190] Left elevator_1, arrived at floor 2
[D1 15:27:05 citizen_141] Entered elevator_1, going to floor 0
[D1 15:27:05 floor_2] citizen_141 is leaving the queue
[D1 15:27:05 floor_2] citizen_178 was served
[D1 15:27:05 elevator_1] Summoned to floor 2 from floor 2
[D1 15:27:05 citizen_178] Entered elevator_1, going to floor 5
[D1 15:27:05 floor_2] citizen_178 is leaving the queue
[D1 15:27:05 floor_2] The queue is now empty
[D1 15:27:14 elevator_2] Closing doors
[D1 15:27:17 elevator_1] Closing doors
[D1 15:27:17 elevator_2] Closed doors
[D1 15:27:20 elevator_1] Closed doors
[D1 15:27:27 elevator_2] At floor 2
[D1 15:27:27 elevator_2] Stopped at floor 2
[D1 15:27:27 elevator_2] Opening doors
[D1 15:27:30 elevator_1] At floor 3
[D1 15:27:30 elevator_2] Opened doors
[D1 15:27:30 citizen_128] Left elevator_2, arrived at floor 2
[D1 15:27:40 citizen_177] Time to go to floor 1 and stay there for 00:37:06
[D1 15:27:40 floor_5] citizen_177 entered the queue
[D1 15:27:40 floor_5] citizen_177 found an empty queue and will be served immediately
[D1 15:27:40 elevator_1] Summoned to floor 5 from floor 3
[D1 15:27:40 elevator_1] At floor 4
[D1 15:27:42 elevator_2] Closing doors
[D1 15:27:45 elevator_2] Closed doors
[D1 15:27:45 elevator_2] Resting at floor 2
[D1 15:27:46 citizen_191] Entered the building, will visit 4 floors in total
[D1 15:27:46 citizen_191] Time to go to floor 3 and stay there for 00:29:08
[D1 15:27:46 floor_0] citizen_191 entered the queue
[D1 15:27:46 floor_0] citizen_191 found an empty queue and will be served immediately
[D1 15:27:46 elevator_2] Summoned to floor 0 from floor 2
[D1 15:27:46 elevator_2] Sprung into motion, heading Down
[D1 15:27:50 elevator_1] At floor 5
[D1 15:27:50 elevator_1] Stopped at floor 5
[D1 15:27:50 elevator_1] Opening doors
[D1 15:27:53 elevator_1] Opened doors
[D1 15:27:53 citizen_178] Left elevator_1, arrived at floor 5
[D1 15:27:53 citizen_177] Entered elevator_1, going to floor 1
[D1 15:27:53 floor_5] citizen_177 is leaving the queue
[D1 15:27:53 floor_5] The queue is now empty
[D1 15:27:56 elevator_2] At floor 1
[D1 15:28:05 elevator_1] Closing doors
[D1 15:28:06 elevator_2] At floor 0
[D1 15:28:06 elevator_2] Stopped at floor 0
[D1 15:28:06 elevator_2] Opening doors
[D1 15:28:08 elevator_1] Closed doors
[D1 15:28:08 elevator_1] Changing direction to Down
[D1 15:28:09 elevator_2] Opened doors
[D1 15:28:09 citizen_191] Entered elevator_2, going to floor 3
[D1 15:28:09 floor_0] citizen_191 is leaving the queue
[D1 15:28:09 floor_0] The queue is now empty
[D1 15:28:13 citizen_163] Time to go to floor 2 and stay there for 00:19:41
[D1 15:28:13 floor_1] citizen_163 entered the queue
[D1 15:28:13 floor_1] citizen_163 found an empty queue and will be served immediately
[D1 15:28:13 elevator_2] Summoned to floor 1 from floor 0
[D1 15:28:18 elevator_1] At floor 4
[D1 15:28:21 elevator_2] Closing doors
[D1 15:28:24 elevator_2] Closed doors
[D1 15:28:24 elevator_2] Changing direction to Up
[D1 15:28:28 elevator_1] At floor 3
[D1 15:28:34 elevator_2] At floor 1
[D1 15:28:34 elevator_2] Stopped at floor 1
[D1 15:28:34 elevator_2] Opening doors
[D1 15:28:37 citizen_149] Time to go to floor 3 and stay there for 00:31:06
[D1 15:28:37 floor_4] citizen_149 entered the queue
[D1 15:28:37 floor_4] citizen_149 found an empty queue and will be served immediately
[D1 15:28:37 elevator_1] Summoned to floor 4 from floor 3
[D1 15:28:37 elevator_2] Opened doors
[D1 15:28:37 citizen_163] Entered elevator_2, going to floor 2
[D1 15:28:37 floor_1] citizen_163 is leaving the queue
[D1 15:28:37 floor_1] The queue is now empty
[D1 15:28:38 elevator_1] At floor 2
[D1 15:28:47 citizen_165] Time to go to floor 3 and stay there for 00:30:06
[D1 15:28:47 floor_4] citizen_165 entered the queue
[D1 15:28:47 floor_4] citizen_165 is queued along with 0 other arrivals in front of it
[D1 15:28:48 elevator_1] At floor 1
[D1 15:28:48 elevator_1] Stopped at floor 1
[D1 15:28:48 elevator_1] Opening doors
[D1 15:28:49 elevator_2] Closing doors
[D1 15:28:50 citizen_192] Entered the building, will visit 4 floors in total
[D1 15:28:50 citizen_192] Time to go to floor 2 and stay there for 00:26:04
[D1 15:28:50 floor_0] citizen_192 entered the queue
[D1 15:28:50 floor_0] citizen_192 found an empty queue and will be served immediately
[D1 15:28:50 elevator_1] Summoned to floor 0 from floor 1
[D1 15:28:50 elevator_2] Summoned to floor 0 from floor 1
[D1 15:28:51 elevator_1] Opened doors
[D1 15:28:51 citizen_177] Left elevator_1, arrived at floor 1
[D1 15:28:52 elevator_2] Closed doors
[D1 15:29:02 elevator_2] At floor 2
[D1 15:29:02 elevator_2] Stopped at floor 2
[D1 15:29:02 elevator_2] Opening doors
[D1 15:29:03 elevator_1] Closing doors
[D1 15:29:05 elevator_2] Opened doors
[D1 15:29:05 citizen_163] Left elevator_2, arrived at floor 2
[D1 15:29:06 elevator_1] Closed doors
[D1 15:29:16 elevator_1] At floor 0
[D1 15:29:16 elevator_1] Stopped at floor 0
[D1 15:29:16 elevator_1] Opening doors
[D1 15:29:17 elevator_2] Closing doors
[D1 15:29:19 elevator_1] Opened doors
[D1 15:29:19 citizen_141] Left elevator_1, arrived at floor 0
[D1 15:29:19 citizen_141] Left the building
[D1 15:29:19 citizen_192] Entered elevator_1, going to floor 2
[D1 15:29:19 floor_0] citizen_192 is leaving the queue
[D1 15:29:19 floor_0] The queue is now empty
[D1 15:29:20 elevator_2] Closed doors
[D1 15:29:30 elevator_2] At floor 3
[D1 15:29:30 elevator_2] Stopped at floor 3
[D1 15:29:30 elevator_2] Opening doors
[D1 15:29:31 elevator_1] Closing doors
[D1 15:29:33 elevator_2] Opened doors
[D1 15:29:33 citizen_191] Left elevator_2, arrived at floor 3
[D1 15:29:34 elevator_1] Closed doors
[D1 15:29:34 elevator_1] Changing direction to Up
[D1 15:29:44 elevator_1] At floor 1
[D1 15:29:45 elevator_2] Closing doors
[D1 15:29:46 citizen_171] Time to go to floor 2 and stay there for 00:28:25
[D1 15:29:46 floor_1] citizen_171 entered the queue
[D1 15:29:46 floor_1] citizen_171 found an empty queue and will be served immediately
[D1 15:29:46 elevator_1] Summoned to floor 1 from floor 1
[D1 15:29:48 elevator_2] Closed doors
[D1 15:29:48 elevator_2] Changing direction to Down
[D1 15:29:54 elevator_1] At floor 2
[D1 15:29:54 elevator_1] Stopped at floor 2
[D1 15:29:54 elevator_1] Opening doors
[D1 15:29:57 elevator_1] Opened doors
[D1 15:29:57 citizen_192] Left elevator_1, arrived at floor 2
[D1 15:29:58 elevator_2] At floor 2
[D1 15:30:08 elevator_2] At floor 1
[D1 15:30:09 elevator_1] Closing doors
[D1 15:30:12 elevator_1] Closed doors
[D1 15:30:18 citizen_162] Time to go to floor 2 and stay there for 00:32:27
[D1 15:30:18 floor_3] citizen_162 entered the queue
[D1 15:30:18 floor_3] citizen_162 found an empty queue and will be served immediately
[D1 15:30:18 elevator_1] Summoned to floor 3 from floor 2
[D1 15:30:18 elevator_2] At floor 0
[D1 15:30:18 elevator_2] Stopped at floor 0
[D1 15:30:18 elevator_2] Opening doors
[D1 15:30:21 elevator_2] Opened doors
[D1 15:30:22 elevator_1] At floor 3
[D1 15:30:22 elevator_1] Stopped at floor 3
[D1 15:30:22 elevator_1] Opening doors
[D1 15:30:25 elevator_1] Opened doors
[D1 15:30:25 citizen_162] Entered elevator_1, going to floor 2
[D1 15:30:25 floor_3] citizen_162 is leaving the queue
[D1 15:30:25 floor_3] The queue is now empty
[D1 15:30:33 elevator_2] Closing doors
[D1 15:30:36 citizen_169] Time to go to floor 3 and stay there for 00:33:00
[D1 15:30:36 floor_2] citizen_169 entered the queue
[D1 15:30:36 floor_2] citizen_169 found an empty queue and will be served immediately
[D1 15:30:36 elevator_1] Summoned to floor 2 from floor 3
[D1 15:30:36 elevator_2] Closed doors
[D1 15:30:36 elevator_2] Resting at floor 0
[D1 15:30:37 elevator_1] Closing doors
[D1 15:30:40 elevator_1] Closed doors
[D1 15:30:50 elevator_1] At floor 4
[D1 15:30:50 elevator_1] Stopped at floor 4
[D1 15:30:50 elevator_1] Opening doors
[D1 15:30:53 elevator_1] Opened doors
[D1 15:30:53 citizen_149] Entered elevator_1, going to floor 3
[D1 15:30:53 floor_4] citizen_149 is leaving the queue
[D1 15:30:53 floor_4] citizen_165 was served
[D1 15:30:53 elevator_1] Summoned to floor 4 from floor 4
[D1 15:30:53 citizen_165] Entered elevator_1, going to floor 3
[D1 15:30:53 floor_4] citizen_165 is leaving the queue
[D1 15:30:53 floor_4] The queue is now empty
[D1 15:30:54 citizen_193] Entered the building, will visit 4 floors in total
[D1 15:30:54 citizen_193] Time to go to floor 1 and stay there for 00:47:23
[D1 15:30:54 floor_0] citizen_193 entered the queue
[D1 15:30:54 floor_0] citizen_193 found an empty queue and will be served immediately
[D1 15:30:54 elevator_2] Summoned to floor 0 from floor 0
[D1 15:30:54 elevator_2] Opening doors
[D1 15:30:57 elevator_2] Opened doors
[D1 15:30:57 citizen_193] Entered elevator_2, going to floor 1
[D1 15:30:57 floor_0] citizen_193 is leaving the queue
[D1 15:30:57 floor_0] The queue is now empty
[D1 15:31:05 elevator_1] Closing doors
[D1 15:31:08 elevator_1] Closed doors
[D1 15:31:08 elevator_1] Changing direction to Down
[D1 15:31:09 elevator_2] Closing doors
[D1 15:31:12 elevator_2] Closed doors
[D1 15:31:12 elevator_2] Sprung into motion, heading Up
[D1 15:31:18 elevator_1] At floor 3
[D1 15:31:18 elevator_1] Stopped at floor 3
[D1 15:31:18 elevator_1] Opening doors
[D1 15:31:21 elevator_1] Opened doors
[D1 15:31:21 citizen_149] Left elevator_1, arrived at floor 3
[D1 15:31:21 citizen_165] Left elevator_1, arrived at floor 3
[D1 15:31:22 elevator_2] At floor 1
[D1 15:31:22 elevator_2] Stopped at floor 1
[D1 15:31:22 elevator_2] Opening doors
[D1 15:31:25 elevator_2] Opened doors
[D1 15:31:25 citizen_193] Left elevator_2, arrived at floor 1
[D1 15:31:32 citizen_167] Time to go to floor 4 and stay there for 00:23:42
[D1 15:31:32 floor_5] citizen_167 entered the queue
[D1 15:31:32 floor_5] citizen_167 found an empty queue and will be served immediately
[D1 15:31:32 elevator_1] Summoned to floor 5 from floor 3
[D1 15:31:33 elevator_1] Closing doors
[D1 15:31:36 elevator_1] Closed doors
[D1 15:31:37 elevator_2] Closing doors
[D1 15:31:40 elevator_2] Closed doors
[D1 15:31:40 elevator_2] Resting at floor 1
[D1 15:31:46 elevator_1] At floor 2
[D1 15:31:46 elevator_1] Stopped at floor 2
[D1 15:31:46 elevator_1] Opening doors
[D1 15:31:49 elevator_1] Opened doors
[D1 15:31:49 citizen_162] Left elevator_1, arrived at floor 2
[D1 15:31:49 citizen_169] Entered elevator_1, going to floor 3
[D1 15:31:49 floor_2] citizen_169 is leaving the queue
[D1 15:31:49 floor_2] The queue is now empty
[D1 15:32:01 elevator_1] Closing doors
[D1 15:32:04 elevator_1] Closed doors
[D1 15:32:11 citizen_194] Entered the building, will visit 5 floors in total
[D1 15:32:11 citizen_194] Time to go to floor 4 and stay there for 00:41:10
[D1 15:32:11 floor_0] citizen_194 entered the queue
[D1 15:32:11 floor_0] citizen_194 found an empty queue and will be served immediately
[D1 15:32:11 elevator_2] Summoned to floor 0 from floor 1
[D1 15:32:11 elevator_2] Sprung into motion, heading Down
[D1 15:32:14 elevator_1] At floor 1
[D1 15:32:14 elevator_1] Stopped at floor 1
[D1 15:32:14 elevator_1] Opening doors
[D1 15:32:17 elevator_1] Opened doors
[D1 15:32:17 citizen_171] Entered elevator_1, going to floor 2
[D1 15:32:17 floor_1] citizen_171 is leaving the queue
[D1 15:32:17 floor_1] The queue is now empty
[D1 15:32:21 elevator_2] At floor 0
[D1 15:32:21 elevator_2] Stopped at floor 0
[D1 15:32:21 elevator_2] Opening doors
[D1 15:32:24 elevator_2] Opened doors
[D1 15:32:24 citizen_194] Entered elevator_2, going to floor 4
[D1 15:32:24 floor_0] citizen_194 is leaving the queue
[D1 15:32:24 floor_0] The queue is now empty
[D1 15:32:29 elevator_1] Closing doors
[D1 15:32:32 elevator_1] Closed doors
[D1 15:32:32 elevator_1] Changing direction to Up
[D1 15:32:36 elevator_2] Closing doors
[D1 15:32:39 elevator_2] Closed doors
[D1 15:32:39 elevator_2] Changing direction to Up
[D1 15:32:42 elevator_1] At floor 2
[D1 15:32:42 elevator_1] Stopped at floor 2
[D1 15:32:42 elevator_1] Opening doors
[D1 15:32:45 elevator_1] Opened doors
[D1 15:32:45 citizen_171] Left elevator_1, arrived at floor 2
[D1 15:32:49 citizen_175] Time to go to floor 1 and stay there for 00:42:32
[D1 15:32:49 floor_2] citizen_175 entered the queue
[D1 15:32:49 floor_2] citizen_175 found an empty queue and will be served immediately
[D1 15:32:49 elevator_1] Summoned to floor 2 from floor 2
[D1 15:32:49 citizen_175] Entered elevator_1, going to floor 1
[D1 15:32:49 floor_2] citizen_175 is leaving the queue
[D1 15:32:49 floor_2] The queue is now empty
[D1 15:32:49 elevator_2] At floor 1
[D1 15:32:57 elevator_1] Closing doors
[D1 15:32:59 elevator_2] At floor 2
[D1 15:33:00 elevator_1] Closed doors
[D1 15:33:09 citizen_170] Time to go to floor 3 and stay there for 00:15:41
[D1 15:33:09 floor_2] citizen_170 entered the queue
[D1 15:33:09 floor_2] citizen_170 found an empty queue and will be served immediately
[D1 15:33:09 elevator_1] Summoned to floor 2 from floor 2
[D1 15:33:09 elevator_2] Summoned to floor 2 from floor 2
[D1 15:33:09 elevator_2] At floor 3
[D1 15:33:10 elevator_1] At floor 3
[D1 15:33:10 elevator_1] Stopped at floor 3
[D1 15:33:10 elevator_1] Opening doors
[D1 15:33:13 elevator_1] Opened doors
[D1 15:33:13 citizen_169] Left elevator_1, arrived at floor 3
[D1 15:33:19 elevator_2] At floor 4
[D1 15:33:19 elevator_2] Stopped at floor 4
[D1 15:33:19 elevator_2] Opening doors
[D1 15:33:22 elevator_2] Opened doors
[D1 15:33:22 citizen_194] Left elevator_2, arrived at floor 4
[D1 15:33:23 citizen_195] Entered the building, will visit 4 floors in total
[D1 15:33:23 citizen_195] Time to go to floor 3 and stay there for 00:26:01
[D1 15:33:23 floor_0] citizen_195 entered the queue
[D1 15:33:23 floor_0] citizen_195 found an empty queue and will be served immediately
[D1 15:33:23 elevator_1] Summoned to floor 0 from floor 3
[D1 15:33:25 elevator_1] Closing doors
[D1 15:33:28 elevator_1] Closed doors
[D1 15:33:33 citizen_140] Time to go to the ground floor and leave
[D1 15:33:33 floor_5] citizen_140 entered the queue
[D1 15:33:33 floor_5] citizen_140 is queued along with 0 other arrivals in front of it
[D1 15:33:34 elevator_2] Closing doors
[D1 15:33:37 elevator_2] Closed doors
[D1 15:33:37 elevator_2] Changing direction to Down
[D1 15:33:38 elevator_1] At floor 4
[D1 15:33:47 elevator_2] At floor 3
[D1 15:33:48 elevator_1] At floor 5
[D1 15:33:48 elevator_1] Stopped at floor 5
[D1 15:33:48 elevator_1] Opening doors
[D1 15:33:51 elevator_1] Opened doors
[D1 15:33:51 citizen_167] Entered elevator_1, going to floor 4
[D1 15:33:51 floor_5] citizen_167 is leaving the queue
[D1 15:33:51 floor_5] citizen_140 was served
[D1 15:33:51 elevator_1] Summoned to floor 5 from floor 5
[D1 15:33:51 citizen_140] Entered elevator_1, going to floor 0
[D1 15:33:51 floor_5] citizen_140 is leaving the queue
[D1 15:33:51 floor_5] The queue is now empty
[D1 15:33:57 elevator_2] At floor 2
[D1 15:33:57 elevator_2] Stopped at floor 2
[D1 15:33:57 elevator_2] Opening doors
[D1 15:34:00 elevator_2] Opened doors
[D1 15:34:00 citizen_170] Entered elevator_2, going to floor 3
[D1 15:34:00 floor_2] citizen_170 is leaving the queue
[D1 15:34:00 floor_2] The queue is now empty
[D1 15:34:01 citizen_166] Time to go to the ground floor and leave
[D1 15:34:01 floor_1] citizen_166 entered the queue
[D1 15:34:01 floor_1] citizen_166 found an empty queue and will be served immediately
[D1 15:34:01 elevator_2] Summoned to floor 1 from floor 2
[D1 15:34:03 elevator_1] Closing doors
[D1 15:34:06 elevator_1] Closed doors
[D1 15:34:06 elevator_1] Changing direction to Down
[D1 15:34:12 elevator_2] Closing doors
[D1 15:34:14 citizen_174] Time to go to floor 2 and stay there for 00:31:20
[D1 15:34:14 floor_4] citizen_174 entered the queue
[D1 15:34:14 floor_4] citizen_174 found an empty queue and will be served immediately
[D1 15:34:14 elevator_1] Summoned to floor 4 from floor 5
[D1 15:34:15 elevator_2] Closed doors
[D1 15:34:16 elevator_1] At floor 4
[D1 15:34:16 elevator_1] Stopped at floor 4
[D1 15:34:16 elevator_1] Opening doors
[D1 15:34:19 elevator_1] Opened doors
[D1 15:34:19 citizen_167] Left elevator_1, arrived at floor 4
[D1 15:34:19 citizen_174] Entered elevator_1, going to floor 2
[D1 15:34:19 floor_4] citizen_174 is leaving the queue
[D1 15:34:19 floor_4] The queue is now empty
[D1 15:34:25 elevator_2] At floor 1
[D1 15:34:25 elevator_2] Stopped at floor 1
[D1 15:34:25 elevator_2] Opening doors
[D1 15:34:28 elevator_2] Opened doors
[D1 15:34:28 citizen_166] Entered elevator_2, going to floor 0
[D1 15:34:28 floor_1] citizen_166 is leaving the queue
[D1 15:34:28 floor_1] The queue is now empty
[D1 15:34:31 elevator_1] Closing doors
[D1 15:34:34 elevator_1] Closed doors
[D1 15:34:40 elevator_2] Closing doors
[D1 15:34:43 elevator_2] Closed doors
[D1 15:34:44 elevator_1] At floor 3
[D1 15:34:53 elevator_2] At floor 0
[D1 15:34:53 elevator_2] Stopped at floor 0
[D1 15:34:53 elevator_2] Opening doors
[D1 15:34:54 elevator_1] At floor 2
[D1 15:34:54 elevator_1] Stopped at floor 2
[D1 15:34:54 elevator_1] Opening doors
[D1 15:34:56 elevator_2] Opened doors
[D1 15:34:56 citizen_166] Left elevator_2, arrived at floor 0
[D1 15:34:56 citizen_166] Left the building
[D1 15:34:57 elevator_1] Opened doors
[D1 15:34:57 citizen_174] Left elevator_1, arrived at floor 2
[D1 15:35:03 citizen_155] Time to go to floor 2 and stay there for 00:24:20
[D1 15:35:03 floor_4] citizen_155 entered the queue
[D1 15:35:03 floor_4] citizen_155 found an empty queue and will be served immediately
[D1 15:35:03 elevator_1] Summoned to floor 4 from floor 2
[D1 15:35:04 citizen_196] Entered the building, will visit 3 floors in total
[D1 15:35:04 citizen_196] Time to go to floor 1 and stay there for 00:33:33
[D1 15:35:04 floor_0] citizen_196 entered the queue
[D1 15:35:04 floor_0] citizen_196 is queued along with 0 other arrivals in front of it
[D1 15:35:08 elevator_2] Closing doors
[D1 15:35:09 elevator_1] Closing doors
[D1 15:35:11 elevator_2] Closed doors
[D1 15:35:11 elevator_2] Changing direction to Up
[D1 15:35:12 elevator_1] Closed doors
[D1 15:35:21 elevator_2] At floor 1
[D1 15:35:22 elevator_1] At floor 1
[D1 15:35:22 elevator_1] Stopped at floor 1
[D1 15:35:22 elevator_1] Opening doors
[D1 15:35:25 elevator_1] Opened doors
[D1 15:35:25 citizen_175] Left elevator_1, arrived at floor 1
[D1 15:35:31 elevator_2] At floor 2
[D1 15:35:32 citizen_129] Time to go to floor 1 and stay there for 00:16:10
[D1 15:35:32 floor_4] citizen_129 entered the queue
[D1 15:35:32 floor_4] citizen_129 is queued along with 0 other arrivals in front of it
[D1 15:35:37 elevator_1] Closing doors
[D1 15:35:40 elevator_1] Closed doors
[D1 15:35:41 elevator_2] At floor 3
[D1 15:35:41 elevator_2] Stopped at floor 3
[D1 15:35:41 elevator_2] Opening doors
[D1 15:35:44 elevator_2] Opened doors
[D1 15:35:44 citizen_170] Left elevator_2, arrived at floor 3
[D1 15:35:50 elevator_1] At floor 0
[D1 15:35:50 elevator_1] Stopped at floor 0
[D1 15:35:50 elevator_1] Opening doors
[D1 15:35:53 elevator_1] Opened doors
[D1 15:35:53 citizen_140] Left elevator_1, arrived at floor 0
[D1 15:35:53 citizen_140] Left the building
[D1 15:35:53 citizen_195] Entered elevator_1, going to floor 3
[D1 15:35:53 floor_0] citizen_195 is leaving the queue
[D1 15:35:53 floor_0] citizen_196 was served
[D1 15:35:53 elevator_1] Summoned to floor 0 from floor 0
[D1 15:35:53 citizen_196] Entered elevator_1, going to floor 1
[D1 15:35:53 floor_0] citizen_196 is leaving the queue
[D1 15:35:53 floor_0] The queue is now empty
[D1 15:35:56 elevator_2] Closing doors
[D1 15:35:59 elevator_2] Closed doors
[D1 15:35:59 elevator_2] Resting at floor 3
[D1 15:36:05 elevator_1] Closing doors
[D1 15:36:08 citizen_153] Time to go to floor 3 and stay there for 00:28:23
[D1 15:36:08 floor_5] citizen_153 entered the queue
[D1 15:36:08 floor_5] citizen_153 found an empty queue and will be served immediately
[D1 15:36:08 elevator_2] Summoned to floor 5 from floor 3
[D1 15:36:08 elevator_2] Sprung into motion, heading Up
[D1 15:36:08 elevator_1] Closed doors
[D1 15:36:08 elevator_1] Changing direction to Up
[D1 15:36:18 elevator_2] At floor 4
[D1 15:36:18 elevator_1] At floor 1
[D1 15:36:18 elevator_1] Stopped at floor 1
[D1 15:36:18 elevator_1] Opening doors
[D1 15:36:21 elevator_1] Opened doors
[D1 15:36:21 citizen_196] Left elevator_1, arrived at floor 1
[D1 15:36:28 elevator_2] At floor 5
[D1 15:36:28 elevator_2] Stopped at floor 5
[D1 15:36:28 elevator_2] Opening doors
[D1 15:36:31 elevator_2] Opened doors
[D1 15:36:31 citizen_153] Entered elevator_2, going to floor 3
[D1 15:36:31 floor_5] citizen_153 is leaving the queue
[D1 15:36:31 floor_5] The queue is now empty
[D1 15:36:33 elevator_1] Closing doors
[D1 15:36:36 elevator_1] Closed doors
[D1 15:36:43 elevator_2] Closing doors
[D1 15:36:46 elevator_1] At floor 2
[D1 15:36:46 elevator_2] Closed doors
[D1 15:36:46 elevator_2] Changing direction to Down
[D1 15:36:56 elevator_1] At floor 3
[D1 15:36:56 elevator_1] Stopped at floor 3
[D1 15:36:56 elevator_1] Opening doors
[D1 15:36:56 elevator_2] At floor 4
[D1 15:36:59 elevator_1] Opened doors
[D1 15:36:59 citizen_195] Left elevator_1, arrived at floor 3
[D1 15:37:06 elevator_2] At floor 3
[D1 15:37:06 elevator_2] Stopped at floor 3
[D1 15:37:06 elevator_2] Opening doors
[D1 15:37:09 elevator_2] Opened doors
[D1 15:37:09 citizen_153] Left elevator_2, arrived at floor 3
[D1 15:37:11 elevator_1] Closing doors
[D1 15:37:14 elevator_1] Closed doors
[D1 15:37:21 elevator_2] Closing doors
[D1 15:37:24 citizen_159] Time to go to floor 3 and stay there for 00:38:57
[D1 15:37:24 floor_5] citizen_159 entered the queue
[D1 15:37:24 floor_5] citizen_159 found an empty queue and will be served immediately
[D1 15:37:24 elevator_1] Summoned to floor 5 from floor 3
[D1 15:37:24 elevator_2] Summoned to floor 5 from floor 3
[D1 15:37:24 elevator_1] At floor 4
[D1 15:37:24 elevator_1] Stopped at floor 4
[D1 15:37:24 elevator_1] Opening doors
[D1 15:37:24 elevator_2] Closed doors
[D1 15:37:24 elevator_2] Changing direction to Up
[D1 15:37:25 citizen_120] Time to go to the ground floor and leave
[D1 15:37:25 floor_4] citizen_120 entered the queue
[D1 15:37:25 floor_4] citizen_120 is queued along with 1 other arrivals in front of it
[D1 15:37:27 elevator_1] Opened doors
[D1 15:37:27 citizen_155] Entered elevator_1, going to floor 2
[D1 15:37:27 floor_4] citizen_155 is leaving the queue
[D1 15:37:27 floor_4] citizen_129 was served
[D1 15:37:27 elevator_1] Summoned to floor 4 from floor 4
[D1 15:37:27 citizen_129] Entered elevator_1, going to floor 1
[D1 15:37:27 floor_4] citizen_129 is leaving the queue
[D1 15:37:27 floor_4] citizen_120 was served
[D1 15:37:27 elevator_1] Summoned to floor 4 from floor 4
[D1 15:37:27 citizen_120] Entered elevator_1, going to floor 0
[D1 15:37:27 floor_4] citizen_120 is leaving the queue
[D1 15:37:27 floor_4] The queue is now empty
[D1 15:37:34 elevator_2] At floor 4
[D1 15:37:36 citizen_127] Time to go to the ground floor and leave
[D1 15:37:36 floor_2] citizen_127 entered the queue
[D1 15:37:36 floor_2] citizen_127 found an empty queue and will be served immediately
[D1 15:37:36 elevator_1] Summoned to floor 2 from floor 4
[D1 15:37:36 elevator_2] Summoned to floor 2 from floor 4
[D1 15:37:39 elevator_1] Closing doors
[D1 15:37:42 elevator_1] Closed doors
[D1 15:37:44 elevator_2] At floor 5
[D1 15:37:44 elevator_2] Stopped at floor 5
[D1 15:37:44 elevator_2] Opening doors
[D1 15:37:47 elevator_2] Opened doors
[D1 15:37:47 citizen_159] Entered elevator_2, going to floor 3
[D1 15:37:47 floor_5] citizen_159 is leaving the queue
[D1 15:37:47 floor_5] The queue is now empty
[D1 15:37:52 elevator_1] At floor 5
[D1 15:37:52 elevator_1] Stopped at floor 5
[D1 15:37:52 elevator_1] Opening doors
[D1 15:37:55 elevator_1] Opened doors
[D1 15:37:56 citizen_181] Time to go to floor 2 and stay there for 00:25:37
[D1 15:37:56 floor_5] citizen_181 entered the queue
[D1 15:37:56 floor_5] citizen_181 found an empty queue and will be served immediately
[D1 15:37:56 elevator_1] Summoned to floor 5 from floor 5
[D1 15:37:56 elevator_2] Summoned to floor 5 from floor 5
[D1 15:37:56 citizen_181] Entered elevator_1, going to floor 2
[D1 15:37:56 floor_5] citizen_181 is leaving the queue
[D1 15:37:56 floor_5] The queue is now empty
[D1 15:37:59 elevator_2] Closing doors
[D1 15:38:02 elevator_2] Closed doors
[D1 15:38:02 elevator_2] Changing direction to Down
[D1 15:38:07 elevator_1] Closing doors
[D1 15:38:10 elevator_1] Closed doors
[D1 15:38:10 elevator_1] Changing direction to Down
[D1 15:38:12 elevator_2] At floor 4
[D1 15:38:16 citizen_134] Time to go to the ground floor and leave
[D1 15:38:16 floor_5] citizen_134 entered the queue
[D1 15:38:16 floor_5] citizen_134 found an empty queue and will be served immediately
[D1 15:38:16 elevator_1] Summoned to floor 5 from floor 5
[D1 15:38:20 elevator_1] At floor 4
[D1 15:38:22 elevator_2] At floor 3
[D1 15:38:22 elevator_2] Stopped at floor 3
[D1 15:38:22 elevator_2] Opening doors
[D1 15:38:25 elevator_2] Opened doors
[D1 15:38:25 citizen_159] Left elevator_2, arrived at floor 3
[D1 15:38:30 elevator_1] At floor 3
[D1 15:38:37 elevator_2] Closing doors
[D1 15:38:40 elevator_1] At floor 2
[D1 15:38:40 elevator_1] Stopped at floor 2
[D1 15:38:40 elevator_1] Opening doors
[D1 15:38:40 elevator_2] Closed doors
[D1 15:38:43 elevator_1] Opened doors
[D1 15:38:43 citizen_155] Left elevator_1, arrived at floor 2
[D1 15:38:43 citizen_181] Left elevator_1, arrived at floor 2
[D1 15:38:43 citizen_127] Entered elevator_1, going to floor 0
[D1 15:38:43 floor_2] citizen_127 is leaving the queue
[D1 15:38:43 floor_2] The queue is now empty
[D1 15:38:47 citizen_180] Time to go to floor 1 and stay there for 00:45:32
[D1 15:38:47 floor_3] citizen_180 entered the queue
[D1 15:38:47 floor_3] citizen_180 found an empty queue and will be served immediately
[D1 15:38:47 elevator_2] Summoned to floor 3 from floor 3
[D1 15:38:50 elevator_2] At floor 2
[D1 15:38:50 elevator_2] Stopped at floor 2
[D1 15:38:50 elevator_2] Opening doors
[D1 15:38:53 elevator_2] Opened doors
[D1 15:38:55 elevator_1] Closing doors
[D1 15:38:58 elevator_1] Closed doors
[D1 15:39:05 elevator_2] Closing doors
[D1 15:39:08 elevator_1] At floor 1
[D1 15:39:08 elevator_1] Stopped at floor 1
[D1 15:39:08 elevator_1] Opening doors
[D1 15:39:08 elevator_2] Closed doors
[D1 15:39:08 elevator_2] Changing direction to Up
[D1 15:39:09 citizen_197] Entered the building, will visit 4 floors in total
[D1 15:39:09 citizen_197] Time to go to floor 2 and stay there for 00:29:04
[D1 15:39:09 floor_0] citizen_197 entered the queue
[D1 15:39:09 floor_0] citizen_197 found an empty queue and will be served immediately
[D1 15:39:09 elevator_1] Summoned to floor 0 from floor 1
[D1 15:39:11 elevator_1] Opened doors
[D1 15:39:11 citizen_129] Left elevator_1, arrived at floor 1
[D1 15:39:18 elevator_2] At floor 3
[D1 15:39:18 elevator_2] Stopped at floor 3
[D1 15:39:18 elevator_2] Opening doors
[D1 15:39:21 elevator_2] Opened doors
[D1 15:39:21 citizen_180] Entered elevator_2, going to floor 1
[D1 15:39:21 floor_3] citizen_180 is leaving the queue
[D1 15:39:21 floor_3] The queue is now empty
[D1 15:39:23 elevator_1] Closing doors
[D1 15:39:26 elevator_1] Closed doors
[D1 15:39:33 elevator_2] Closing doors
[D1 15:39:36 elevator_1] At floor 0
[D1 15:39:36 elevator_1] Stopped at floor 0
[D1 15:39:36 elevator_1] Opening doors
[D1 15:39:36 elevator_2] Closed doors
[D1 15:39:36 elevator_2] Changing direction to Down
[D1 15:39:39 elevator_1] Opened doors
[D1 15:39:39 citizen_120] Left elevator_1, arrived at floor 0
[D1 15:39:39 citizen_127] Left elevator_1, arrived at floor 0
[D1 15:39:39 citizen_120] Left the building
[D1 15:39:39 citizen_127] Left the building
[D1 15:39:39 citizen_197] Entered elevator_1, going to floor 2
[D1 15:39:39 floor_0] citizen_197 is leaving the queue
[D1 15:39:39 floor_0] The queue is now empty
[D1 15:39:45 citizen_182] Time to go to floor 2 and stay there for 00:50:07
[D1 15:39:45 floor_3] citizen_182 entered the queue
[D1 15:39:45 floor_3] citizen_182 found an empty queue and will be served immediately
[D1 15:39:45 elevator_2] Summoned to floor 3 from floor 3
[D1 15:39:46 elevator_2] At floor 2
[D1 15:39:51 elevator_1] Closing doors
[D1 15:39:54 elevator_1] Closed doors
[D1 15:39:54 elevator_1] Changing direction to Up
[D1 15:39:56 elevator_2] At floor 1
[D1 15:39:56 elevator_2] Stopped at floor 1
[D1 15:39:56 elevator_2] Opening doors
[D1 15:39:59 elevator_2] Opened doors
[D1 15:39:59 citizen_180] Left elevator_2, arrived at floor 1
[D1 15:40:04 elevator_1] At floor 1
[D1 15:40:07 citizen_176] Time to go to floor 3 and stay there for 00:41:59
[D1 15:40:07 floor_1] citizen_176 entered the queue
[D1 15:40:07 floor_1] citizen_176 found an empty queue and will be served immediately
[D1 15:40:07 elevator_1] Summoned to floor 1 from floor 1
[D1 15:40:07 elevator_2] Summoned to floor 1 from floor 1
[D1 15:40:07 citizen_176] Entered elevator_2, going to floor 3
[D1 15:40:07 floor_1] citizen_176 is leaving the queue
[D1 15:40:07 floor_1] The queue is now empty
[D1 15:40:11 elevator_2] Closing doors
[D1 15:40:14 elevator_1] At floor 2
[D1 15:40:14 elevator_1] Stopped at floor 2
[D1 15:40:14 elevator_1] Opening doors
[D1 15:40:14 elevator_2] Closed doors
[D1 15:40:14 elevator_2] Changing direction to Up
[D1 15:40:17 elevator_1] Opened doors
[D1 15:40:17 citizen_197] Left elevator_1, arrived at floor 2
[D1 15:40:24 elevator_2] At floor 2
[D1 15:40:25 citizen_184] Time to go to floor 2 and stay there for 00:30:08
[D1 15:40:25 floor_5] citizen_184 entered the queue
[D1 15:40:25 floor_5] citizen_184 is queued along with 0 other arrivals in front of it
[D1 15:40:29 elevator_1] Closing doors
[D1 15:40:32 elevator_1] Closed doors
[D1 15:40:34 elevator_2] At floor 3
[D1 15:40:34 elevator_2] Stopped at floor 3
[D1 15:40:34 elevator_2] Opening doors
[D1 15:40:37 elevator_2] Opened doors
[D1 15:40:37 citizen_176] Left elevator_2, arrived at floor 3
[D1 15:40:37 citizen_182] Entered elevator_2, going to floor 2
[D1 15:40:37 floor_3] citizen_182 is leaving the queue
[D1 15:40:37 floor_3] The queue is now empty
[D1 15:40:42 elevator_1] At floor 3
[D1 15:40:46 citizen_179] Time to go to floor 1 and stay there for 00:43:17
[D1 15:40:46 floor_5] citizen_179 entered the queue
[D1 15:40:46 floor_5] citizen_179 is queued along with 1 other arrivals in front of it
[D1 15:40:49 elevator_2] Closing doors
[D1 15:40:52 elevator_1] At floor 4
[D1 15:40:52 elevator_2] Closed doors
[D1 15:40:52 elevator_2] Changing direction to Down
[D1 15:40:59 citizen_198] Entered the building, will visit 5 floors in total
[D1 15:40:59 citizen_198] Time to go to floor 4 and stay there for 00:38:56
[D1 15:40:59 floor_0] citizen_198 entered the queue
[D1 15:40:59 floor_0] citizen_198 found an empty queue and will be served immediately
[D1 15:40:59 elevator_2] Summoned to floor 0 from floor 3
[D1 15:41:02 elevator_1] At floor 5
[D1 15:41:02 elevator_1] Stopped at floor 5
[D1 15:41:02 elevator_1] Opening doors
[D1 15:41:02 elevator_2] At floor 2
[D1 15:41:02 elevator_2] Stopped at floor 2
[D1 15:41:02 elevator_2] Opening doors
[D1 15:41:05 elevator_1] Opened doors
[D1 15:41:05 elevator_2] Opened doors
[D1 15:41:05 citizen_182] Left elevator_2, arrived at floor 2
[D1 15:41:05 citizen_134] Entered elevator_1, going to floor 0
[D1 15:41:05 floor_5] citizen_134 is leaving the queue
[D1 15:41:05 floor_5] citizen_184 was served
[D1 15:41:05 elevator_1] Summoned to floor 5 from floor 5
[D1 15:41:05 citizen_184] Entered elevator_1, going to floor 2
[D1 15:41:05 floor_5] citizen_184 is leaving the queue
[D1 15:41:05 floor_5] citizen_179 was served
[D1 15:41:05 elevator_1] Summoned to floor 5 from floor 5
[D1 15:41:05 citizen_179] Entered elevator_1, going to floor 1
[D1 15:41:05 floor_5] citizen_179 is leaving the queue
[D1 15:41:05 floor_5] The queue is now empty
[D1 15:41:17 elevator_1] Closing doors
[D1 15:41:17 elevator_2] Closing doors
[D1 15:41:20 citizen_173] Time to go to floor 4 and stay there for 00:29:05
[D1 15:41:20 floor_3] citizen_173 entered the queue
[D1 15:41:20 floor_3] citizen_173 found an empty queue and will be served immediately
[D1 15:41:20 elevator_2] Summoned to floor 3 from floor 2
[D1 15:41:20 elevator_1] Closed doors
[D1 15:41:20 elevator_2] Closed doors
[D1 15:41:20 elevator_1] Changing direction to Down
[D1 15:41:30 elevator_1] At floor 4
[D1 15:41:30 elevator_2] At floor 1
[D1 15:41:40 elevator_1] At floor 3
[D1 15:41:40 elevator_2] At floor 0
[D1 15:41:40 elevator_2] Stopped at floor 0
[D1 15:41:40 elevator_2] Opening doors
[D1 15:41:43 citizen_187] Time to go to floor 3 and stay there for 00:26:14
[D1 15:41:43 floor_4] citizen_187 entered the queue
[D1 15:41:43 floor_4] citizen_187 found an empty queue and will be served immediately
[D1 15:41:43 elevator_1] Summoned to floor 4 from floor 3
[D1 15:41:43 elevator_2] Opened doors
[D1 15:41:43 citizen_198] Entered elevator_2, going to floor 4
[D1 15:41:43 floor_0] citizen_198 is leaving the queue
[D1 15:41:43 floor_0] The queue is now empty
[D1 15:41:50 elevator_1] At floor 2
[D1 15:41:50 elevator_1] Stopped at floor 2
[D1 15:41:50 elevator_1] Opening doors
[D1 15:41:53 elevator_1] Opened doors
[D1 15:41:53 citizen_184] Left elevator_1, arrived at floor 2
[D1 15:41:55 elevator_2] Closing doors
[D1 15:41:58 elevator_2] Closed doors
[D1 15:41:58 elevator_2] Changing direction to Up
[D1 15:42:05 elevator_1] Closing doors
[D1 15:42:08 elevator_2] At floor 1
[D1 15:42:08 elevator_1] Closed doors
[D1 15:42:18 elevator_2] At floor 2
[D1 15:42:18 elevator_1] At floor 1
[D1 15:42:18 elevator_1] Stopped at floor 1
[D1 15:42:18 elevator_1] Opening doors
[D1 15:42:21 elevator_1] Opened doors
[D1 15:42:21 citizen_179] Left elevator_1, arrived at floor 1
[D1 15:42:28 elevator_2] At floor 3
[D1 15:42:28 elevator_2] Stopped at floor 3
[D1 15:42:28 elevator_2] Opening doors
[D1 15:42:31 elevator_2] Opened doors
[D1 15:42:31 citizen_173] Entered elevator_2, going to floor 4
[D1 15:42:31 floor_3] citizen_173 is leaving the queue
[D1 15:42:31 floor_3] The queue is now empty
[D1 15:42:33 elevator_1] Closing doors
[D1 15:42:36 elevator_1] Closed doors
[D1 15:42:43 elevator_2] Closing doors
[D1 15:42:46 elevator_1] At floor 0
[D1 15:42:46 elevator_1] Stopped at floor 0
[D1 15:42:46 elevator_1] Opening doors
[D1 15:42:46 elevator_2] Closed doors
[D1 15:42:49 elevator_1] Opened doors
[D1 15:42:49 citizen_134] Left elevator_1, arrived at floor 0
[D1 15:42:49 citizen_134] Left the building
[D1 15:42:50 citizen_152] Time to go to floor 3 and stay there for 00:26:44
[D1 15:42:50 floor_5] citizen_152 entered the queue
[D1 15:42:50 floor_5] citizen_152 found an empty queue and will be served immediately
[D1 15:42:50 elevator_2] Summoned to floor 5 from floor 3
[D1 15:42:56 elevator_2] At floor 4
[D1 15:42:56 elevator_2] Stopped at floor 4
[D1 15:42:56 elevator_2] Opening doors
[D1 15:42:59 elevator_2] Opened doors
[D1 15:42:59 citizen_198] Left elevator_2, arrived at floor 4
[D1 15:42:59 citizen_173] Left elevator_2, arrived at floor 4
[D1 15:43:01 elevator_1] Closing doors
[D1 15:43:04 elevator_1] Closed doors
[D1 15:43:04 elevator_1] Changing direction to Up
[D1 15:43:11 elevator_2] Closing doors
[D1 15:43:14 citizen_128] Time to go to the ground floor and leave
[D1 15:43:14 floor_2] citizen_128 entered the queue
[D1 15:43:14 floor_2] citizen_128 found an empty queue and will be served immediately
[D1 15:43:14 elevator_1] Summoned to floor 2 from floor 0
[D1 15:43:14 elevator_2] Summoned to floor 2 from floor 4
[D1 15:43:14 elevator_1] At floor 1
[D1 15:43:14 elevator_2] Closed doors
[D1 15:43:18 citizen_199] Entered the building, will visit 3 floors in total
[D1 15:43:18 citizen_199] Time to go to floor 5 and stay there for 00:22:50
[D1 15:43:18 floor_0] citizen_199 entered the queue
[D1 15:43:18 floor_0] citizen_199 found an empty queue and will be served immediately
[D1 15:43:18 elevator_1] Summoned to floor 0 from floor 1
[D1 15:43:24 elevator_1] At floor 2
[D1 15:43:24 elevator_1] Stopped at floor 2
[D1 15:43:24 elevator_1] Opening doors
[D1 15:43:24 elevator_2] At floor 5
[D1 15:43:24 elevator_2] Stopped at floor 5
[D1 15:43:24 elevator_2] Opening doors
[D1 15:43:27 elevator_1] Opened doors
[D1 15:43:27 elevator_2] Opened doors
[D1 15:43:27 citizen_128] Entered elevator_1, going to floor 0
[D1 15:43:27 citizen_152] Entered elevator_2, going to floor 3
[D1 15:43:27 floor_2] citizen_128 is leaving the queue
[D1 15:43:27 floor_2] The queue is now empty
[D1 15:43:27 floor_5] citizen_152 is leaving the queue
[D1 15:43:27 floor_5] The queue is now empty
[D1 15:43:28 citizen_133] Time to go to the ground floor and leave
[D1 15:43:28 floor_2] citizen_133 entered the queue
[D1 15:43:28 floor_2] citizen_133 found an empty queue and will be served immediately
[D1 15:43:28 elevator_1] Summoned to floor 2 from floor 2
[D1 15:43:28 citizen_133] Entered elevator_1, going to floor 0
[D1 15:43:28 floor_2] citizen_133 is leaving the queue
[D1 15:43:28 floor_2] The queue is now empty
[D1 15:43:29 citizen_156] Time to go to floor 4 and stay there for 00:36:49
[D1 15:43:29 floor_5] citizen_156 entered the queue
[D1 15:43:29 floor_5] citizen_156 found an empty queue and will be served immediately
[D1 15:43:29 elevator_2] Summoned to floor 5 from floor 5
[D1 15:43:29 citizen_156] Entered elevator_2, going to floor 4
[D1 15:43:29 floor_5] citizen_156 is leaving the queue
[D1 15:43:29 floor_5] The queue is now empty
[D1 15:43:39 elevator_2] Closing doors
[D1 15:43:39 elevator_1] Closing doors
[D1 15:43:42 elevator_2] Closed doors
[D1 15:43:42 elevator_1] Closed doors
[D1 15:43:42 elevator_2] Changing direction to Down
[D1 15:43:52 elevator_2] At floor 4
[D1 15:43:52 elevator_2] Stopped at floor 4
[D1 15:43:52 elevator_2] Opening doors
[D1 15:43:52 elevator_1] At floor 3
[D1 15:43:55 elevator_2] Opened doors
[D1 15:43:55 citizen_156] Left elevator_2, arrived at floor 4
[D1 15:43:58 citizen_188] Time to go to floor 1 and stay there for 00:26:11
[D1 15:43:58 floor_4] citizen_188 entered the queue
[D1 15:43:58 floor_4] citizen_188 is queued along with 0 other arrivals in front of it
[D1 15:44:02 elevator_1] At floor 4
[D1 15:44:02 elevator_1] Stopped at floor 4
[D1 15:44:02 elevator_1] Opening doors
[D1 15:44:05 elevator_1] Opened doors
[D1 15:44:05 citizen_187] Entered elevator_1, going to floor 3
[D1 15:44:05 floor_4] citizen_187 is leaving the queue
[D1 15:44:05 floor_4] citizen_188 was served
[D1 15:44:05 elevator_1] Summoned to floor 4 from floor 4
[D1 15:44:05 elevator_2] Summoned to floor 4 from floor 4
[D1 15:44:05 citizen_188] Entered elevator_1, going to floor 1
[D1 15:44:05 floor_4] citizen_188 is leaving the queue
[D1 15:44:05 floor_4] The queue is now empty
[D1 15:44:06 citizen_143] Time to go to floor 2 and stay there for 00:23:18
[D1 15:44:06 floor_5] citizen_143 entered the queue
[D1 15:44:06 floor_5] citizen_143 found an empty queue and will be served immediately
[D1 15:44:06 elevator_1] Summoned to floor 5 from floor 4
[D1 15:44:06 elevator_2] Summoned to floor 5 from floor 4
[D1 15:44:07 elevator_2] Closing doors
[D1 15:44:10 elevator_2] Closed doors
[D1 15:44:17 elevator_1] Closing doors
[D1 15:44:20 elevator_2] At floor 3
[D1 15:44:20 elevator_2] Stopped at floor 3
[D1 15:44:20 elevator_2] Opening doors
[D1 15:44:20 elevator_1] Closed doors
[D1 15:44:23 elevator_2] Opened doors
[D1 15:44:23 citizen_152] Left elevator_2, arrived at floor 3
[D1 15:44:30 elevator_1] At floor 5
[D1 15:44:30 elevator_1] Stopped at floor 5
[D1 15:44:30 elevator_1] Opening doors
[D1 15:44:33 elevator_1] Opened doors
[D1 15:44:33 citizen_143] Cannot enter elevator_1, it is full
[D1 15:44:35 elevator_2] Closing doors
[D1 15:44:38 elevator_2] Closed doors
[D1 15:44:45 elevator_1] Closing doors
[D1 15:44:48 elevator_2] At floor 2
[D1 15:44:48 elevator_2] Stopped at floor 2
[D1 15:44:48 elevator_2] Opening doors
[D1 15:44:48 elevator_1] Closed doors
[D1 15:44:48 elevator_1] Changing direction to Down
[D1 15:44:51 elevator_2] Opened doors
[D1 15:44:58 elevator_1] At floor 4
[D1 15:45:03 elevator_2] Closing doors
[D1 15:45:06 elevator_2] Closed doors
[D1 15:45:06 elevator_2] Changing direction to Up
[D1 15:45:08 elevator_1] At floor 3
[D1 15:45:08 elevator_1] Stopped at floor 3
[D1 15:45:08 elevator_1] Opening doors
[D1 15:45:11 elevator_1] Opened doors
[D1 15:45:11 citizen_187] Left elevator_1, arrived at floor 3
[D1 15:45:15 citizen_139] Time to go to the ground floor and leave
[D1 15:45:15 floor_4] citizen_139 entered the queue
[D1 15:45:15 floor_4] citizen_139 found an empty queue and will be served immediately
[D1 15:45:15 elevator_1] Summoned to floor 4 from floor 3
[D1 15:45:16 elevator_2] At floor 3
[D1 15:45:23 elevator_1] Closing doors
[D1 15:45:26 elevator_2] At floor 4
[D1 15:45:26 elevator_1] Closed doors
[D1 15:45:27 citizen_200] Entered the building, will visit 4 floors in total
[D1 15:45:27 citizen_200] Time to go to floor 1 and stay there for 00:30:11
[D1 15:45:27 floor_0] citizen_200 entered the queue
[D1 15:45:27 floor_0] citizen_200 is queued along with 0 other arrivals in front of it
[D1 15:45:36 elevator_2] At floor 5
[D1 15:45:36 elevator_2] Stopped at floor 5
[D1 15:45:36 elevator_2] Opening doors
[D1 15:45:36 elevator_1] At floor 2
[D1 15:45:39 elevator_2] Opened doors
[D1 15:45:39 citizen_143] Entered elevator_2, going to floor 2
[D1 15:45:39 floor_5] citizen_143 is leaving the queue
[D1 15:45:39 floor_5] The queue is now empty
[D1 15:45:41 citizen_172] Time to go to floor 5 and stay there for 00:19:04
[D1 15:45:41 floor_3] citizen_172 entered the queue
[D1 15:45:41 floor_3] citizen_172 found an empty queue and will be served immediately
[D1 15:45:41 elevator_1] Summoned to floor 3 from floor 2
[D1 15:45:42 citizen_186] Time to go to floor 2 and stay there for 00:26:17
[D1 15:45:42 floor_3] citizen_186 entered the queue
[D1 15:45:42 floor_3] citizen_186 is queued along with 0 other arrivals in front of it
[D1 15:45:46 elevator_1] At floor 1
[D1 15:45:46 elevator_1] Stopped at floor 1
[D1 15:45:46 elevator_1] Opening doors
[D1 15:45:49 elevator_1] Opened doors
[D1 15:45:49 citizen_188] Left elevator_1, arrived at floor 1
[D1 15:45:51 elevator_2] Closing doors
[D1 15:45:54 elevator_2] Closed doors
[D1 15:45:54 elevator_2] Changing direction to Down
[D1 15:46:01 elevator_1] Closing doors
[D1 15:46:04 elevator_2] At floor 4
[D1 15:46:04 elevator_1] Closed doors
[D1 15:46:14 elevator_2] At floor 3
[D1 15:46:14 elevator_1] At floor 0
[D1 15:46:14 elevator_1] Stopped at floor 0
[D1 15:46:14 elevator_1] Opening doors
[D1 15:46:17 elevator_1] Opened doors
[D1 15:46:17 citizen_128] Left elevator_1, arrived at floor 0
[D1 15:46:17 citizen_133] Left elevator_1, arrived at floor 0
[D1 15:46:17 citizen_128] Left the building
[D1 15:46:17 citizen_133] Left the building
[D1 15:46:17 citizen_199] Entered elevator_1, going to floor 5
[D1 15:46:17 floor_0] citizen_199 is leaving the queue
[D1 15:46:17 floor_0] citizen_200 was served
[D1 15:46:17 elevator_1] Summoned to floor 0 from floor 0
[D1 15:46:17 citizen_200] Entered elevator_1, going to floor 1
[D1 15:46:17 floor_0] citizen_200 is leaving the queue
[D1 15:46:17 floor_0] The queue is now empty
[D1 15:46:24 elevator_2] At floor 2
[D1 15:46:24 elevator_2] Stopped at floor 2
[D1 15:46:24 elevator_2] Opening doors
[D1 15:46:27 elevator_2] Opened doors
[D1 15:46:27 citizen_143] Left elevator_2, arrived at floor 2
[D1 15:46:29 elevator_1] Closing doors
[D1 15:46:32 elevator_1] Closed doors
[D1 15:46:32 elevator_1] Changing direction to Up
[D1 15:46:35 citizen_164] Time to go to floor 2 and stay there for 00:23:51
[D1 15:46:35 floor_1] citizen_164 entered the queue
[D1 15:46:35 floor_1] citizen_164 found an empty queue and will be served immediately
[D1 15:46:35 elevator_1] Summoned to floor 1 from floor 0
[D1 15:46:35 elevator_2] Summoned to floor 1 from floor 2
[D1 15:46:39 elevator_2] Closing doors
[D1 15:46:42 elevator_1] At floor 1
[D1 15:46:42 elevator_1] Stopped at floor 1
[D1 15:46:42 elevator_1] Opening doors
[D1 15:46:42 elevator_2] Closed doors
[D1 15:46:45 elevator_1] Opened doors
[D1 15:46:45 citizen_200] Left elevator_1, arrived at floor 1
[D1 15:46:45 citizen_164] Entered elevator_1, going to floor 2
[D1 15:46:45 floor_1] citizen_164 is leaving the queue
[D1 15:46:45 floor_1] The queue is now empty
[D1 15:46:52 elevator_2] At floor 1
[D1 15:46:52 elevator_2] Stopped at floor 1
[D1 15:46:52 elevator_2] Opening doors
[D1 15:46:55 elevator_2] Opened doors
[D1 15:46:57 elevator_1] Closing doors
[D1 15:47:00 elevator_1] Closed doors
[D1 15:47:07 citizen_144] Time to go to the ground floor and leave
[D1 15:47:07 floor_3] citizen_144 entered the queue
[D1 15:47:07 floor_3] citizen_144 is queued along with 1 other arrivals in front of it
[D1 15:47:07 elevator_2] Closing doors
[D1 15:47:10 elevator_1] At floor 2
[D1 15:47:10 elevator_1] Stopped at floor 2
[D1 15:47:10 elevator_1] Opening doors
[D1 15:47:10 elevator_2] Closed doors
[D1 15:47:10 elevator_2] Resting at floor 1
[D1 15:47:13 elevator_1] Opened doors
[D1 15:47:13 citizen_164] Left elevator_1, arrived at floor 2
[D1 15:47:17 citizen_158] Time to go to the ground floor and leave
[D1 15:47:17 floor_1] citizen_158 entered the queue
[D1 15:47:17 floor_1] citizen_158 found an empty queue and will be served immediately
[D1 15:47:17 elevator_2] Summoned to floor 1 from floor 1
[D1 15:47:17 elevator_2] Opening doors
[D1 15:47:20 elevator_2] Opened doors
[D1 15:47:20 citizen_158] Entered elevator_2, going to floor 0
[D1 15:47:20 floor_1] citizen_158 is leaving the queue
[D1 15:47:20 floor_1] The queue is now empty
[D1 15:47:23 citizen_183] Time to go to floor 4 and stay there for 00:29:54
[D1 15:47:23 floor_3] citizen_183 entered the queue
[D1 15:47:23 floor_3] citizen_183 is queued along with 2 other arrivals in front of it
[D1 15:47:25 elevator_1] Closing doors
[D1 15:47:28 elevator_1] Closed doors
[D1 15:47:32 elevator_2] Closing doors
[D1 15:47:35 elevator_2] Closed doors
[D1 15:47:35 elevator_2] Sprung into motion, heading Down
[D1 15:47:38 elevator_1] At floor 3
[D1 15:47:38 elevator_1] Stopped at floor 3
[D1 15:47:38 elevator_1] Opening doors
[D1 15:47:41 elevator_1] Opened doors
[D1 15:47:41 citizen_172] Entered elevator_1, going to floor 5
[D1 15:47:41 floor_3] citizen_172 is leaving the queue
[D1 15:47:41 floor_3] citizen_186 was served
[D1 15:47:41 elevator_1] Summoned to floor 3 from floor 3
[D1 15:47:41 citizen_186] Entered elevator_1, going to floor 2
[D1 15:47:41 floor_3] citizen_186 is leaving the queue
[D1 15:47:41 floor_3] citizen_144 was served
[D1 15:47:41 elevator_1] Summoned to floor 3 from floor 3
[D1 15:47:41 citizen_144] Entered elevator_1, going to floor 0
[D1 15:47:41 floor_3] citizen_144 is leaving the queue
[D1 15:47:41 floor_3] citizen_183 was served
[D1 15:47:41 elevator_1] Summoned to floor 3 from floor 3
[D1 15:47:41 citizen_183] Cannot enter elevator_1, it is full
[D1 15:47:41 citizen_183] All elevators were full, trying to summon them again
[D1 15:47:45 elevator_2] At floor 0
[D1 15:47:45 elevator_2] Stopped at floor 0
[D1 15:47:45 elevator_2] Opening doors
[D1 15:47:48 elevator_2] Opened doors
[D1 15:47:48 citizen_158] Left elevator_2, arrived at floor 0
[D1 15:47:48 citizen_158] Left the building
[D1 15:47:53 elevator_1] Closing doors
[D1 15:47:56 elevator_1] Closed doors
[D1 15:47:57 elevator_1] Summoned to floor 3 from floor 3
[D1 15:48:00 elevator_2] Closing doors
[D1 15:48:03 elevator_2] Closed doors
[D1 15:48:03 elevator_2] Resting at floor 0
[D1 15:48:06 elevator_1] At floor 4
[D1 15:48:06 elevator_1] Stopped at floor 4
[D1 15:48:06 elevator_1] Opening doors
[D1 15:48:09 elevator_1] Opened doors
[D1 15:48:09 citizen_139] Cannot enter elevator_1, it is full
[D1 15:48:09 citizen_139] All elevators were full, trying to summon them again
[D1 15:48:21 elevator_1] Closing doors
[D1 15:48:24 elevator_1] Closed doors
[D1 15:48:25 elevator_1] Summoned to floor 4 from floor 4
[D1 15:48:34 elevator_1] At floor 5
[D1 15:48:34 elevator_1] Stopped at floor 5
[D1 15:48:34 elevator_1] Opening doors
[D1 15:48:37 elevator_1] Opened doors
[D1 15:48:37 citizen_199] Left elevator_1, arrived at floor 5
[D1 15:48:37 citizen_172] Left elevator_1, arrived at floor 5
[D1 15:48:46 citizen_163] Time to go to the ground floor and leave
[D1 15:48:46 floor_2] citizen_163 entered the queue
[D1 15:48:46 floor_2] citizen_163 found an empty queue and will be served immediately
[D1 15:48:46 elevator_2] Summoned to floor 2 from floor 0
[D1 15:48:46 elevator_2] Sprung into motion, heading Up
[D1 15:48:49 elevator_1] Closing doors
[D1 15:48:52 elevator_1] Closed doors
[D1 15:48:52 elevator_1] Changing direction to Down
[D1 15:48:56 elevator_2] At floor 1
[D1 15:48:58 citizen_124] Time to go to the ground floor and leave
[D1 15:48:58 floor_3] citizen_124 entered the queue
[D1 15:48:58 floor_3] citizen_124 is queued along with 0 other arrivals in front of it
[D1 15:49:02 elevator_1] At floor 4
[D1 15:49:02 elevator_1] Stopped at floor 4
[D1 15:49:02 elevator_1] Opening doors
[D1 15:49:05 elevator_1] Opened doors
[D1 15:49:05 citizen_139] Entered elevator_1, going to floor 0
[D1 15:49:05 floor_4] citizen_139 is leaving the queue
[D1 15:49:05 floor_4] The queue is now empty
[D1 15:49:06 elevator_2] At floor 2
[D1 15:49:06 elevator_2] Stopped at floor 2
[D1 15:49:06 elevator_2] Opening doors
[D1 15:49:09 elevator_2] Opened doors
[D1 15:49:09 citizen_163] Entered elevator_2, going to floor 0
[D1 15:49:09 floor_2] citizen_163 is leaving the queue
[D1 15:49:09 floor_2] The queue is now empty
[D1 15:49:17 elevator_1] Closing doors
[D1 15:49:20 elevator_1] Closed doors
[D1 15:49:21 elevator_2] Closing doors
[D1 15:49:24 elevator_2] Closed doors
[D1 15:49:24 elevator_2] Changing direction to Down
[D1 15:49:30 elevator_1] At floor 3
[D1 15:49:30 elevator_1] Stopped at floor 3
[D1 15:49:30 elevator_1] Opening doors
[D1 15:49:33 elevator_1] Opened doors
[D1 15:49:33 citizen_183] Entered elevator_1, going to floor 4
[D1 15:49:33 floor_3] citizen_183 is leaving the queue
[D1 15:49:33 floor_3] citizen_124 was served
[D1 15:49:33 elevator_1] Summoned to floor 3 from floor 3
[D1 15:49:33 citizen_124] Cannot enter elevator_1, it is full
[D1 15:49:33 citizen_124] All elevators were full, trying to summon them again
[D1 15:49:34 elevator_2] At floor 1
[D1 15:49:44 elevator_2] At floor 0
[D1 15:49:44 elevator_2] Stopped at floor 0
[D1 15:49:44 elevator_2] Opening doors
[D1 15:49:45 elevator_1] Closing doors
[D1 15:49:47 elevator_2] Opened doors
[D1 15:49:47 citizen_163] Left elevator_2, arrived at floor 0
[D1 15:49:47 citizen_163] Left the building
[D1 15:49:48 elevator_1] Closed doors
[D1 15:49:49 elevator_1] Summoned to floor 3 from floor 3
[D1 15:49:58 elevator_1] At floor 2
[D1 15:49:58 elevator_1] Stopped at floor 2
[D1 15:49:58 elevator_1] Opening doors
[D1 15:49:59 elevator_2] Closing doors
[D1 15:50:01 elevator_1] Opened doors
[D1 15:50:01 citizen_186] Left elevator_1, arrived at floor 2
[D1 15:50:02 elevator_2] Closed doors
[D1 15:50:02 elevator_2] Resting at floor 0
[D1 15:50:11 citizen_148] Time to go to the ground floor and leave
[D1 15:50:11 floor_4] citizen_148 entered the queue
[D1 15:50:11 floor_4] citizen_148 found an empty queue and will be served immediately
[D1 15:50:11 elevator_1] Summoned to floor 4 from floor 2
[D1 15:50:13 elevator_1] Closing doors
[D1 15:50:16 elevator_1] Closed doors
[D1 15:50:26 elevator_1] At floor 1
[D1 15:50:27 citizen_146] Time to go to floor 4 and stay there for 00:20:35
[D1 15:50:27 floor_3] citizen_146 entered the queue
[D1 15:50:27 floor_3] citizen_146 is queued along with 0 other arrivals in front of it
[D1 15:50:36 elevator_1] At floor 0
[D1 15:50:36 elevator_1] Stopped at floor 0
[D1 15:50:36 elevator_1] Opening doors
[D1 15:50:39 elevator_1] Opened doors
[D1 15:50:39 citizen_144] Left elevator_1, arrived at floor 0
[D1 15:50:39 citizen_139] Left elevator_1, arrived at floor 0
[D1 15:50:39 citizen_144] Left the building
[D1 15:50:39 citizen_139] Left the building
[D1 15:50:51 elevator_1] Closing doors
[D1 15:50:54 elevator_1] Closed doors
[D1 15:50:54 elevator_1] Changing direction to Up
[D1 15:51:04 elevator_1] At floor 1
[D1 15:51:14 elevator_1] At floor 2
[D1 15:51:24 elevator_1] At floor 3
[D1 15:51:24 elevator_1] Stopped at floor 3
[D1 15:51:24 elevator_1] Opening doors
[D1 15:51:25 citizen_170] Time to go to floor 1 and stay there for 00:35:10
[D1 15:51:25 floor_3] citizen_170 entered the queue
[D1 15:51:25 floor_3] citizen_170 is queued along with 1 other arrivals in front of it
[D1 15:51:25 citizen_168] Time to go to floor 2 and stay there for 00:38:35
[D1 15:51:25 floor_1] citizen_168 entered the queue
[D1 15:51:25 floor_1] citizen_168 found an empty queue and will be served immediately
[D1 15:51:25 elevator_2] Summoned to floor 1 from floor 0
[D1 15:51:25 elevator_2] Sprung into motion, heading Up
[D1 15:51:27 elevator_1] Opened doors
[D1 15:51:27 citizen_124] Entered elevator_1, going to floor 0
[D1 15:51:27 floor_3] citizen_124 is leaving the queue
[D1 15:51:27 floor_3] citizen_146 was served
[D1 15:51:27 elevator_1] Summoned to floor 3 from floor 3
[D1 15:51:27 citizen_146] Entered elevator_1, going to floor 4
[D1 15:51:27 floor_3] citizen_146 is leaving the queue
[D1 15:51:27 floor_3] citizen_170 was served
[D1 15:51:27 elevator_1] Summoned to floor 3 from floor 3
[D1 15:51:27 citizen_170] Entered elevator_1, going to floor 1
[D1 15:51:27 floor_3] citizen_170 is leaving the queue
[D1 15:51:27 floor_3] The queue is now empty
[D1 15:51:35 elevator_2] At floor 1
[D1 15:51:35 elevator_2] Stopped at floor 1
[D1 15:51:35 elevator_2] Opening doors
[D1 15:51:38 elevator_2] Opened doors
[D1 15:51:38 citizen_168] Entered elevator_2, going to floor 2
[D1 15:51:38 floor_1] citizen_168 is leaving the queue
[D1 15:51:38 floor_1] The queue is now empty
[D1 15:51:39 elevator_1] Closing doors
[D1 15:51:42 elevator_1] Closed doors
[D1 15:51:50 elevator_2] Closing doors
[D1 15:51:52 elevator_1] At floor 4
[D1 15:51:52 elevator_1] Stopped at floor 4
[D1 15:51:52 elevator_1] Opening doors
[D1 15:51:53 citizen_185] Time to go to floor 2 and stay there for 00:37:10
[D1 15:51:53 floor_3] citizen_185 entered the queue
[D1 15:51:53 floor_3] citizen_185 found an empty queue and will be served immediately
[D1 15:51:53 elevator_1] Summoned to floor 3 from floor 4
[D1 15:51:53 elevator_2] Closed doors
[D1 15:51:55 elevator_1] Opened doors
[D1 15:51:55 citizen_183] Left elevator_1, arrived at floor 4
[D1 15:51:55 citizen_146] Left elevator_1, arrived at floor 4
[D1 15:51:55 citizen_148] Entered elevator_1, going to floor 0
[D1 15:51:55 floor_4] citizen_148 is leaving the queue
[D1 15:51:55 floor_4] The queue is now empty
[D1 15:52:03 elevator_2] At floor 2
[D1 15:52:03 elevator_2] Stopped at floor 2
[D1 15:52:03 elevator_2] Opening doors
[D1 15:52:06 elevator_2] Opened doors
[D1 15:52:06 citizen_168] Left elevator_2, arrived at floor 2
[D1 15:52:07 elevator_1] Closing doors
[D1 15:52:10 elevator_1] Closed doors
[D1 15:52:10 elevator_1] Changing direction to Down
[D1 15:52:18 elevator_2] Closing doors
[D1 15:52:20 elevator_1] At floor 3
[D1 15:52:20 elevator_1] Stopped at floor 3
[D1 15:52:20 elevator_1] Opening doors
[D1 15:52:21 elevator_2] Closed doors
[D1 15:52:21 elevator_2] Resting at floor 2
[D1 15:52:23 elevator_1] Opened doors
[D1 15:52:23 citizen_185] Entered elevator_1, going to floor 2
[D1 15:52:23 floor_3] citizen_185 is leaving the queue
[D1 15:52:23 floor_3] The queue is now empty
[D1 15:52:35 elevator_1] Closing doors
[D1 15:52:38 elevator_1] Closed doors
[D1 15:52:48 elevator_1] At floor 2
[D1 15:52:48 elevator_1] Stopped at floor 2
[D1 15:52:48 elevator_1] Opening doors
[D1 15:52:51 elevator_1] Opened doors
[D1 15:52:51 citizen_185] Left elevator_1, arrived at floor 2
[D1 15:53:03 elevator_1] Closing doors
[D1 15:53:06 elevator_1] Closed doors
[D1 15:53:16 elevator_1] At floor 1
[D1 15:53:16 elevator_1] Stopped at floor 1
[D1 15:53:16 elevator_1] Opening doors
[D1 15:53:19 elevator_1] Opened doors
[D1 15:53:19 citizen_170] Left elevator_1, arrived at floor 1
[D1 15:53:20 citizen_147] Time to go to the ground floor and leave
[D1 15:53:20 floor_1] citizen_147 entered the queue
[D1 15:53:20 floor_1] citizen_147 found an empty queue and will be served immediately
[D1 15:53:20 elevator_1] Summoned to floor 1 from floor 1
[D1 15:53:20 citizen_147] Entered elevator_1, going to floor 0
[D1 15:53:20 floor_1] citizen_147 is leaving the queue
[D1 15:53:20 floor_1] The queue is now empty
[D1 15:53:31 elevator_1] Closing doors
[D1 15:53:34 elevator_1] Closed doors
[D1 15:53:44 elevator_1] At floor 0
[D1 15:53:44 elevator_1] Stopped at floor 0
[D1 15:53:44 elevator_1] Opening doors
[D1 15:53:47 elevator_1] Opened doors
[D1 15:53:47 citizen_124] Left elevator_1, arrived at floor 0
[D1 15:53:47 citizen_148] Left elevator_1, arrived at floor 0
[D1 15:53:47 citizen_147] Left elevator_1, arrived at floor 0
[D1 15:53:47 citizen_124] Left the building
[D1 15:53:47 citizen_148] Left the building
[D1 15:53:47 citizen_147] Left the building
[D1 15:53:59 elevator_1] Closing doors
[D1 15:54:02 elevator_1] Closed doors
[D1 15:54:02 elevator_1] Resting at floor 0
[D1 15:54:51 citizen_157] Time to go to floor 5 and stay there for 00:37:43
[D1 15:54:51 floor_2] citizen_157 entered the queue
[D1 15:54:51 floor_2] citizen_157 found an empty queue and will be served immediately
[D1 15:54:51 elevator_2] Summoned to floor 2 from floor 2
[D1 15:54:51 elevator_2] Opening doors
[D1 15:54:54 elevator_2] Opened doors
[D1 15:54:54 citizen_157] Entered elevator_2, going to floor 5
[D1 15:54:54 floor_2] citizen_157 is leaving the queue
[D1 15:54:54 floor_2] The queue is now empty
[D1 15:55:06 elevator_2] Closing doors
[D1 15:55:09 elevator_2] Closed doors
[D1 15:55:09 elevator_2] Sprung into motion, heading Up
[D1 15:55:19 elevator_2] At floor 3
[D1 15:55:21 citizen_129] Time to go to floor 3 and stay there for 00:31:00
[D1 15:55:21 floor_1] citizen_129 entered the queue
[D1 15:55:21 floor_1] citizen_129 found an empty queue and will be served immediately
[D1 15:55:21 elevator_1] Summoned to floor 1 from floor 0
[D1 15:55:21 elevator_1] Sprung into motion, heading Up
[D1 15:55:29 elevator_2] At floor 4
[D1 15:55:31 elevator_1] At floor 1
[D1 15:55:31 elevator_1] Stopped at floor 1
[D1 15:55:31 elevator_1] Opening doors
[D1 15:55:34 elevator_1] Opened doors
[D1 15:55:34 citizen_129] Entered elevator_1, going to floor 3
[D1 15:55:34 floor_1] citizen_129 is leaving the queue
[D1 15:55:34 floor_1] The queue is now empty
[D1 15:55:39 elevator_2] At floor 5
[D1 15:55:39 elevator_2] Stopped at floor 5
[D1 15:55:39 elevator_2] Opening doors
[D1 15:55:42 elevator_2] Opened doors
[D1 15:55:42 citizen_157] Left elevator_2, arrived at floor 5
[D1 15:55:46 elevator_1] Closing doors
[D1 15:55:49 elevator_1] Closed doors
[D1 15:55:54 elevator_2] Closing doors
[D1 15:55:57 elevator_2] Closed doors
[D1 15:55:57 elevator_2] Resting at floor 5
[D1 15:55:59 elevator_1] At floor 2
[D1 15:56:01 citizen_192] Time to go to floor 1 and stay there for 00:30:45
[D1 15:56:01 floor_2] citizen_192 entered the queue
[D1 15:56:01 floor_2] citizen_192 found an empty queue and will be served immediately
[D1 15:56:01 elevator_1] Summoned to floor 2 from floor 2
[D1 15:56:09 elevator_1] At floor 3
[D1 15:56:09 elevator_1] Stopped at floor 3
[D1 15:56:09 elevator_1] Opening doors
[D1 15:56:12 elevator_1] Opened doors
[D1 15:56:12 citizen_129] Left elevator_1, arrived at floor 3
[D1 15:56:24 elevator_1] Closing doors
[D1 15:56:27 elevator_1] Closed doors
[D1 15:56:27 elevator_1] Changing direction to Down
[D1 15:56:30 citizen_178] Time to go to floor 3 and stay there for 00:23:12
[D1 15:56:30 floor_5] citizen_178 entered the queue
[D1 15:56:30 floor_5] citizen_178 found an empty queue and will be served immediately
[D1 15:56:30 elevator_2] Summoned to floor 5 from floor 5
[D1 15:56:30 elevator_2] Opening doors
[D1 15:56:33 elevator_2] Opened doors
[D1 15:56:33 citizen_178] Entered elevator_2, going to floor 3
[D1 15:56:33 floor_5] citizen_178 is leaving the queue
[D1 15:56:33 floor_5] The queue is now empty
[D1 15:56:37 elevator_1] At floor 2
[D1 15:56:37 elevator_1] Stopped at floor 2
[D1 15:56:37 elevator_1] Opening doors
[D1 15:56:40 elevator_1] Opened doors
[D1 15:56:40 citizen_192] Entered elevator_1, going to floor 1
[D1 15:56:40 floor_2] citizen_192 is leaving the queue
[D1 15:56:40 floor_2] The queue is now empty
[D1 15:56:45 elevator_2] Closing doors
[D1 15:56:48 elevator_2] Closed doors
[D1 15:56:48 elevator_2] Sprung into motion, heading Down
[D1 15:56:52 elevator_1] Closing doors
[D1 15:56:55 elevator_1] Closed doors
[D1 15:56:58 elevator_2] At floor 4
[D1 15:57:05 elevator_1] At floor 1
[D1 15:57:05 elevator_1] Stopped at floor 1
[D1 15:57:05 elevator_1] Opening doors
[D1 15:57:08 elevator_2] At floor 3
[D1 15:57:08 elevator_2] Stopped at floor 3
[D1 15:57:08 elevator_2] Opening doors
[D1 15:57:08 elevator_1] Opened doors
[D1 15:57:08 citizen_192] Left elevator_1, arrived at floor 1
[D1 15:57:11 elevator_2] Opened doors
[D1 15:57:11 citizen_178] Left elevator_2, arrived at floor 3
[D1 15:57:20 elevator_1] Closing doors
[D1 15:57:23 elevator_2] Closing doors
[D1 15:57:23 elevator_1] Closed doors
[D1 15:57:23 elevator_1] Resting at floor 1
[D1 15:57:26 elevator_2] Closed doors
[D1 15:57:26 elevator_2] Resting at floor 3
[D1 15:57:31 citizen_161] Time to go to the ground floor and leave
[D1 15:57:31 floor_5] citizen_161 entered the queue
[D1 15:57:31 floor_5] citizen_161 found an empty queue and will be served immediately
[D1 15:57:31 elevator_2] Summoned to floor 5 from floor 3
[D1 15:57:31 elevator_2] Sprung into motion, heading Up
[D1 15:57:41 elevator_2] At floor 4
[D1 15:57:51 elevator_2] At floor 5
[D1 15:57:51 elevator_2] Stopped at floor 5
[D1 15:57:51 elevator_2] Opening doors
[D1 15:57:54 elevator_2] Opened doors
[D1 15:57:54 citizen_161] Entered elevator_2, going to floor 0
[D1 15:57:54 floor_5] citizen_161 is leaving the queue
[D1 15:57:54 floor_5] The queue is now empty
[D1 15:58:01 citizen_167] Time to go to floor 1 and stay there for 00:29:18
[D1 15:58:01 floor_4] citizen_167 entered the queue
[D1 15:58:01 floor_4] citizen_167 found an empty queue and will be served immediately
[D1 15:58:01 elevator_2] Summoned to floor 4 from floor 5
[D1 15:58:06 elevator_2] Closing doors
[D1 15:58:09 elevator_2] Closed doors
[D1 15:58:09 elevator_2] Changing direction to Down
[D1 15:58:19 elevator_2] At floor 4
[D1 15:58:19 elevator_2] Stopped at floor 4
[D1 15:58:19 elevator_2] Opening doors
[D1 15:58:22 elevator_2] Opened doors
[D1 15:58:22 citizen_167] Entered elevator_2, going to floor 1
[D1 15:58:22 floor_4] citizen_167 is leaving the queue
[D1 15:58:22 floor_4] The queue is now empty
[D1 15:58:34 elevator_2] Closing doors
[D1 15:58:37 elevator_2] Closed doors
[D1 15:58:41 citizen_191] Time to go to floor 1 and stay there for 00:32:59
[D1 15:58:41 floor_3] citizen_191 entered the queue
[D1 15:58:41 floor_3] citizen_191 found an empty queue and will be served immediately
[D1 15:58:41 elevator_2] Summoned to floor 3 from floor 4
[D1 15:58:47 elevator_2] At floor 3
[D1 15:58:47 elevator_2] Stopped at floor 3
[D1 15:58:47 elevator_2] Opening doors
[D1 15:58:49 citizen_154] Time to go to the ground floor and leave
[D1 15:58:49 floor_4] citizen_154 entered the queue
[D1 15:58:49 floor_4] citizen_154 found an empty queue and will be served immediately
[D1 15:58:49 elevator_2] Summoned to floor 4 from floor 3
[D1 15:58:50 elevator_2] Opened doors
[D1 15:58:50 citizen_191] Entered elevator_2, going to floor 1
[D1 15:58:50 floor_3] citizen_191 is leaving the queue
[D1 15:58:50 floor_3] The queue is now empty
[D1 15:59:02 elevator_2] Closing doors
[D1 15:59:05 elevator_2] Closed doors
[D1 15:59:15 elevator_2] At floor 2
[D1 15:59:25 elevator_2] At floor 1
[D1 15:59:25 elevator_2] Stopped at floor 1
[D1 15:59:25 elevator_2] Opening doors
[D1 15:59:28 elevator_2] Opened doors
[D1 15:59:28 citizen_167] Left elevator_2, arrived at floor 1
[D1 15:59:28 citizen_191] Left elevator_2, arrived at floor 1
[D1 15:59:40 elevator_2] Closing doors
[D1 15:59:43 elevator_2] Closed doors
[D1 15:59:53 elevator_2] At floor 0
[D1 15:59:53 elevator_2] Stopped at floor 0
[D1 15:59:53 elevator_2] Opening doors
[D1 15:59:56 elevator_2] Opened doors
[D1 15:59:56 citizen_161] Left elevator_2, arrived at floor 0
[D1 15:59:56 citizen_161] Left the building
[D1 16:00:08 elevator_2] Closing doors
[D1 16:00:11 elevator_2] Closed doors
[D1 16:00:11 elevator_2] Changing direction to Up
[D1 16:00:21 elevator_2] At floor 1
[D1 16:00:31 elevator_2] At floor 2
[D1 16:00:41 elevator_2] At floor 3
[D1 16:00:51 elevator_2] At floor 4
[D1 16:00:51 elevator_2] Stopped at floor 4
[D1 16:00:51 elevator_2] Opening doors
[D1 16:00:54 elevator_2] Opened doors
[D1 16:00:54 citizen_154] Entered elevator_2, going to floor 0
[D1 16:00:54 floor_4] citizen_154 is leaving the queue
[D1 16:00:54 floor_4] The queue is now empty
[D1 16:01:06 elevator_2] Closing doors
[D1 16:01:09 elevator_2] Closed doors
[D1 16:01:09 elevator_2] Changing direction to Down
[D1 16:01:10 citizen_171] Time to go to floor 1 and stay there for 00:52:35
[D1 16:01:10 floor_2] citizen_171 entered the queue
[D1 16:01:10 floor_2] citizen_171 found an empty queue and will be served immediately
[D1 16:01:10 elevator_1] Summoned to floor 2 from floor 1
[D1 16:01:10 elevator_1] Sprung into motion, heading Up
[D1 16:01:19 elevator_2] At floor 3
[D1 16:01:20 elevator_1] At floor 2
[D1 16:01:20 elevator_1] Stopped at floor 2
[D1 16:01:20 elevator_1] Opening doors
[D1 16:01:23 elevator_1] Opened doors
[D1 16:01:23 citizen_171] Entered elevator_1, going to floor 1
[D1 16:01:23 floor_2] citizen_171 is leaving the queue
[D1 16:01:23 floor_2] The queue is now empty
[D1 16:01:27 citizen_165] Time to go to the ground floor and leave
[D1 16:01:27 floor_3] citizen_165 entered the queue
[D1 16:01:27 floor_3] citizen_165 found an empty queue and will be served immediately
[D1 16:01:27 elevator_2] Summoned to floor 3 from floor 3
[D1 16:01:29 elevator_2] At floor 2
[D1 16:01:35 elevator_1] Closing doors
[D1 16:01:38 elevator_1] Closed doors
[D1 16:01:38 elevator_1] Changing direction to Down
[D1 16:01:39 elevator_2] At floor 1
[D1 16:01:48 elevator_1] At floor 1
[D1 16:01:48 elevator_1] Stopped at floor 1
[D1 16:01:48 elevator_1] Opening doors
[D1 16:01:49 elevator_2] At floor 0
[D1 16:01:49 elevator_2] Stopped at floor 0
[D1 16:01:49 elevator_2] Opening doors
[D1 16:01:51 elevator_1] Opened doors
[D1 16:01:51 citizen_171] Left elevator_1, arrived at floor 1
[D1 16:01:52 elevator_2] Opened doors
[D1 16:01:52 citizen_154] Left elevator_2, arrived at floor 0
[D1 16:01:52 citizen_154] Left the building
[D1 16:02:03 elevator_1] Closing doors
[D1 16:02:04 elevator_2] Closing doors
[D1 16:02:06 elevator_1] Closed doors
[D1 16:02:06 elevator_1] Resting at floor 1
[D1 16:02:07 elevator_2] Closed doors
[D1 16:02:07 elevator_2] Changing direction to Up
[D1 16:02:17 elevator_2] At floor 1
[D1 16:02:27 citizen_149] Time to go to floor 4 and stay there for 00:47:52
[D1 16:02:27 floor_3] citizen_149 entered the queue
[D1 16:02:27 floor_3] citizen_149 is queued along with 0 other arrivals in front of it
[D1 16:02:27 elevator_2] At floor 2
[D1 16:02:37 elevator_2] At floor 3
[D1 16:02:37 elevator_2] Stopped at floor 3
[D1 16:02:37 elevator_2] Opening doors
[D1 16:02:40 elevator_2] Opened doors
[D1 16:02:40 citizen_165] Entered elevator_2, going to floor 0
[D1 16:02:40 floor_3] citizen_165 is leaving the queue
[D1 16:02:40 floor_3] citizen_149 was served
[D1 16:02:40 elevator_2] Summoned to floor 3 from floor 3
[D1 16:02:40 citizen_149] Entered elevator_2, going to floor 4
[D1 16:02:40 floor_3] citizen_149 is leaving the queue
[D1 16:02:40 floor_3] The queue is now empty
[D1 16:02:52 elevator_2] Closing doors
[D1 16:02:55 elevator_2] Closed doors
[D1 16:02:58 citizen_190] Time to go to floor 4 and stay there for 00:13:07
[D1 16:02:58 floor_2] citizen_190 entered the queue
[D1 16:02:58 floor_2] citizen_190 found an empty queue and will be served immediately
[D1 16:02:58 elevator_1] Summoned to floor 2 from floor 1
[D1 16:02:58 elevator_1] Sprung into motion, heading Up
[D1 16:02:58 elevator_2] Summoned to floor 2 from floor 3
[D1 16:03:00 citizen_195] Time to go to floor 5 and stay there for 00:19:04
[D1 16:03:00 floor_3] citizen_195 entered the queue
[D1 16:03:00 floor_3] citizen_195 found an empty queue and will be served immediately
[D1 16:03:00 elevator_2] Summoned to floor 3 from floor 3
[D1 16:03:03 citizen_155] Time to go to floor 3 and stay there for 00:30:04
[D1 16:03:03 floor_2] citizen_155 entered the queue
[D1 16:03:03 floor_2] citizen_155 is queued along with 0 other arrivals in front of it
[D1 16:03:05 elevator_2] At floor 4
[D1 16:03:05 elevator_2] Stopped at floor 4
[D1 16:03:05 elevator_2] Opening doors
[D1 16:03:08 elevator_1] At floor 2
[D1 16:03:08 elevator_1] Stopped at floor 2
[D1 16:03:08 elevator_1] Opening doors
[D1 16:03:08 elevator_2] Opened doors
[D1 16:03:08 citizen_149] Left elevator_2, arrived at floor 4
[D1 16:03:11 elevator_1] Opened doors
[D1 16:03:11 citizen_190] Entered elevator_1, going to floor 4
[D1 16:03:11 floor_2] citizen_190 is leaving the queue
[D1 16:03:11 floor_2] citizen_155 was served
[D1 16:03:11 elevator_1] Summoned to floor 2 from floor 2
[D1 16:03:11 citizen_155] Entered elevator_1, going to floor 3
[D1 16:03:11 floor_2] citizen_155 is leaving the queue
[D1 16:03:11 floor_2] The queue is now empty
[D1 16:03:20 elevator_2] Closing doors
[D1 16:03:23 elevator_1] Closing doors
[D1 16:03:23 elevator_2] Closed doors
[D1 16:03:23 elevator_2] Changing direction to Down
[D1 16:03:26 elevator_1] Closed doors
[D1 16:03:33 elevator_2] At floor 3
[D1 16:03:33 elevator_2] Stopped at floor 3
[D1 16:03:33 elevator_2] Opening doors
[D1 16:03:36 elevator_1] At floor 3
[D1 16:03:36 elevator_1] Stopped at floor 3
[D1 16:03:36 elevator_1] Opening doors
[D1 16:03:36 elevator_2] Opened doors
[D1 16:03:36 citizen_195] Entered elevator_2, going to floor 5
[D1 16:03:36 floor_3] citizen_195 is leaving the queue
[D1 16:03:36 floor_3] The queue is now empty
[D1 16:03:39 elevator_1] Opened doors
[D1 16:03:39 citizen_155] Left elevator_1, arrived at floor 3
[D1 16:03:48 elevator_2] Closing doors
[D1 16:03:51 elevator_1] Closing doors
[D1 16:03:51 elevator_2] Closed doors
[D1 16:03:54 elevator_1] Closed doors
[D1 16:04:01 elevator_2] At floor 2
[D1 16:04:01 elevator_2] Stopped at floor 2
[D1 16:04:01 elevator_2] Opening doors
[D1 16:04:04 elevator_1] At floor 4
[D1 16:04:04 elevator_1] Stopped at floor 4
[D1 16:04:04 elevator_1] Opening doors
[D1 16:04:04 elevator_2] Opened doors
[D1 16:04:07 elevator_1] Opened doors
[D1 16:04:07 citizen_190] Left elevator_1, arrived at floor 4
[D1 16:04:16 citizen_162] Time to go to floor 5 and stay there for 00:25:16
[D1 16:04:16 floor_2] citizen_162 entered the queue
[D1 16:04:16 floor_2] citizen_162 found an empty queue and will be served immediately
[D1 16:04:16 elevator_2] Summoned to floor 2 from floor 2
[D1 16:04:16 citizen_162] Entered elevator_2, going to floor 5
[D1 16:04:16 floor_2] citizen_162 is leaving the queue
[D1 16:04:16 floor_2] The queue is now empty
[D1 16:04:16 elevator_2] Closing doors
[D1 16:04:19 elevator_1] Closing doors
[D1 16:04:19 elevator_2] Closed doors
[D1 16:04:20 citizen_181] Time to go to floor 4 and stay there for 00:36:55
[D1 16:04:20 floor_2] citizen_181 entered the queue
[D1 16:04:20 floor_2] citizen_181 found an empty queue and will be served immediately
[D1 16:04:20 elevator_2] Summoned to floor 2 from floor 2
[D1 16:04:22 elevator_1] Closed doors
[D1 16:04:22 elevator_1] Resting at floor 4
[D1 16:04:29 elevator_2] At floor 1
[D1 16:04:39 elevator_2] At floor 0
[D1 16:04:39 elevator_2] Stopped at floor 0
[D1 16:04:39 elevator_2] Opening doors
[D1 16:04:42 elevator_2] Opened doors
[D1 16:04:42 citizen_165] Left elevator_2, arrived at floor 0
[D1 16:04:42 citizen_165] Left the building
[D1 16:04:54 elevator_2] Closing doors
[D1 16:04:57 elevator_2] Closed doors
[D1 16:04:57 elevator_2] Changing direction to Up
[D1 16:05:07 elevator_2] At floor 1
[D1 16:05:17 elevator_2] At floor 2
[D1 16:05:17 elevator_2] Stopped at floor 2
[D1 16:05:17 elevator_2] Opening doors
[D1 16:05:20 elevator_2] Opened doors
[D1 16:05:20 citizen_181] Entered elevator_2, going to floor 4
[D1 16:05:20 floor_2] citizen_181 is leaving the queue
[D1 16:05:20 floor_2] The queue is now empty
[D1 16:05:32 citizen_153] Time to go to the ground floor and leave
[D1 16:05:32 floor_3] citizen_153 entered the queue
[D1 16:05:32 floor_3] citizen_153 found an empty queue and will be served immediately
[D1 16:05:32 elevator_1] Summoned to floor 3 from floor 4
[D1 16:05:32 elevator_1] Sprung into motion, heading Down
[D1 16:05:32 elevator_2] Summoned to floor 3 from floor 2
[D1 16:05:32 elevator_2] Closing doors
[D1 16:05:35 elevator_2] Closed doors
[D1 16:05:42 elevator_1] At floor 3
[D1 16:05:42 elevator_1] Stopped at floor 3
[D1 16:05:42 elevator_1] Opening doors
[D1 16:05:45 elevator_2] At floor 3
[D1 16:05:45 elevator_2] Stopped at floor 3
[D1 16:05:45 elevator_2] Opening doors
[D1 16:05:45 elevator_1] Opened doors
[D1 16:05:45 citizen_153] Entered elevator_1, going to floor 0
[D1 16:05:45 floor_3] citizen_153 is leaving the queue
[D1 16:05:45 floor_3] The queue is now empty
[D1 16:05:48 elevator_2] Opened doors
[D1 16:05:57 elevator_1] Closing doors
[D1 16:05:57 citizen_177] Time to go to floor 5 and stay there for 00:32:13
[D1 16:05:57 floor_1] citizen_177 entered the queue
[D1 16:05:57 floor_1] citizen_177 found an empty queue and will be served immediately
[D1 16:05:57 elevator_1] Summoned to floor 1 from floor 3
[D1 16:05:57 elevator_2] Summoned to floor 1 from floor 3
[D1 16:06:00 elevator_2] Closing doors
[D1 16:06:00 elevator_1] Closed doors
[D1 16:06:03 elevator_2] Closed doors
[D1 16:06:10 elevator_1] At floor 2
[D1 16:06:13 elevator_2] At floor 4
[D1 16:06:13 elevator_2] Stopped at floor 4
[D1 16:06:13 elevator_2] Opening doors
[D1 16:06:13 citizen_169] Time to go to floor 1 and stay there for 00:34:49
[D1 16:06:13 floor_3] citizen_169 entered the queue
[D1 16:06:13 floor_3] citizen_169 found an empty queue and will be served immediately
[D1 16:06:13 elevator_1] Summoned to floor 3 from floor 2
[D1 16:06:13 elevator_2] Summoned to floor 3 from floor 4
[D1 16:06:16 elevator_2] Opened doors
[D1 16:06:16 citizen_181] Left elevator_2, arrived at floor 4
[D1 16:06:17 citizen_174] Time to go to floor 1 and stay there for 00:21:04
[D1 16:06:17 floor_2] citizen_174 entered the queue
[D1 16:06:17 floor_2] citizen_174 found an empty queue and will be served immediately
[D1 16:06:17 elevator_1] Summoned to floor 2 from floor 2
[D1 16:06:20 elevator_1] At floor 1
[D1 16:06:20 elevator_1] Stopped at floor 1
[D1 16:06:20 elevator_1] Opening doors
[D1 16:06:23 elevator_1] Opened doors
[D1 16:06:23 citizen_177] Entered elevator_1, going to floor 5
[D1 16:06:23 floor_1] citizen_177 is leaving the queue
[D1 16:06:23 floor_1] The queue is now empty
[D1 16:06:25 citizen_189] Time to go to floor 4 and stay there for 00:23:36
[D1 16:06:25 floor_5] citizen_189 entered the queue
[D1 16:06:25 floor_5] citizen_189 found an empty queue and will be served immediately
[D1 16:06:25 elevator_2] Summoned to floor 5 from floor 4
[D1 16:06:28 elevator_2] Closing doors
[D1 16:06:31 elevator_2] Closed doors
[D1 16:06:35 elevator_1] Closing doors
[D1 16:06:38 elevator_1] Closed doors
[D1 16:06:41 elevator_2] At floor 5
[D1 16:06:41 elevator_2] Stopped at floor 5
[D1 16:06:41 elevator_2] Opening doors
[D1 16:06:44 elevator_2] Opened doors
[D1 16:06:44 citizen_195] Left elevator_2, arrived at floor 5
[D1 16:06:44 citizen_162] Left elevator_2, arrived at floor 5
[D1 16:06:44 citizen_189] Entered elevator_2, going to floor 4
[D1 16:06:44 floor_5] citizen_189 is leaving the queue
[D1 16:06:44 floor_5] The queue is now empty
[D1 16:06:48 elevator_1] At floor 0
[D1 16:06:48 elevator_1] Stopped at floor 0
[D1 16:06:48 elevator_1] Opening doors
[D1 16:06:51 elevator_1] Opened doors
[D1 16:06:51 citizen_153] Left elevator_1, arrived at floor 0
[D1 16:06:51 citizen_153] Left the building
[D1 16:06:56 elevator_2] Closing doors
[D1 16:06:59 elevator_2] Closed doors
[D1 16:06:59 elevator_2] Changing direction to Down
[D1 16:07:03 elevator_1] Closing doors
[D1 16:07:06 elevator_1] Closed doors
[D1 16:07:06 elevator_1] Changing direction to Up
[D1 16:07:09 elevator_2] At floor 4
[D1 16:07:09 elevator_2] Stopped at floor 4
[D1 16:07:09 elevator_2] Opening doors
[D1 16:07:12 elevator_2] Opened doors
[D1 16:07:12 citizen_189] Left elevator_2, arrived at floor 4
[D1 16:07:16 elevator_1] At floor 1
[D1 16:07:24 elevator_2] Closing doors
[D1 16:07:26 elevator_1] At floor 2
[D1 16:07:26 elevator_1] Stopped at floor 2
[D1 16:07:26 elevator_1] Opening doors
[D1 16:07:27 elevator_2] Closed doors
[D1 16:07:29 elevator_1] Opened doors
[D1 16:07:29 citizen_174] Entered elevator_1, going to floor 1
[D1 16:07:29 floor_2] citizen_174 is leaving the queue
[D1 16:07:29 floor_2] The queue is now empty
[D1 16:07:37 elevator_2] At floor 3
[D1 16:07:37 elevator_2] Stopped at floor 3
[D1 16:07:37 elevator_2] Opening doors
[D1 16:07:40 elevator_2] Opened doors
[D1 16:07:40 citizen_169] Entered elevator_2, going to floor 1
[D1 16:07:40 floor_3] citizen_169 is leaving the queue
[D1 16:07:40 floor_3] The queue is now empty
[D1 16:07:41 citizen_172] Time to go to the ground floor and leave
[D1 16:07:41 floor_5] citizen_172 entered the queue
[D1 16:07:41 floor_5] citizen_172 found an empty queue and will be served immediately
[D1 16:07:41 elevator_2] Summoned to floor 5 from floor 3
[D1 16:07:41 elevator_1] Closing doors
[D1 16:07:44 elevator_1] Closed doors
[D1 16:07:52 elevator_2] Closing doors
[D1 16:07:54 elevator_1] At floor 3
[D1 16:07:54 elevator_1] Stopped at floor 3
[D1 16:07:54 elevator_1] Opening doors
[D1 16:07:55 elevator_2] Closed doors
[D1 16:07:57 elevator_1] Opened doors
[D1 16:08:05 elevator_2] At floor 2
[D1 16:08:09 elevator_1] Closing doors
[D1 16:08:12 elevator_1] Closed doors
[D1 16:08:15 elevator_2] At floor 1
[D1 16:08:15 elevator_2] Stopped at floor 1
[D1 16:08:15 elevator_2] Opening doors
[D1 16:08:18 elevator_2] Opened doors
[D1 16:08:18 citizen_169] Left elevator_2, arrived at floor 1
[D1 16:08:22 elevator_1] At floor 4
[D1 16:08:30 elevator_2] Closing doors
[D1 16:08:32 elevator_1] At floor 5
[D1 16:08:32 elevator_1] Stopped at floor 5
[D1 16:08:32 elevator_1] Opening doors
[D1 16:08:33 elevator_2] Closed doors
[D1 16:08:33 elevator_2] Changing direction to Up
[D1 16:08:35 elevator_1] Opened doors
[D1 16:08:35 citizen_177] Left elevator_1, arrived at floor 5
[D1 16:08:43 elevator_2] At floor 2
[D1 16:08:47 elevator_1] Closing doors
[D1 16:08:50 elevator_1] Closed doors
[D1 16:08:50 elevator_1] Changing direction to Down
[D1 16:08:53 elevator_2] At floor 3
[D1 16:09:00 elevator_1] At floor 4
[D1 16:09:03 elevator_2] At floor 4
[D1 16:09:10 elevator_1] At floor 3
[D1 16:09:13 elevator_2] At floor 5
[D1 16:09:13 elevator_2] Stopped at floor 5
[D1 16:09:13 elevator_2] Opening doors
[D1 16:09:16 elevator_2] Opened doors
[D1 16:09:16 citizen_172] Entered elevator_2, going to floor 0
[D1 16:09:16 floor_5] citizen_172 is leaving the queue
[D1 16:09:16 floor_5] The queue is now empty
[D1 16:09:20 elevator_1] At floor 2
[D1 16:09:21 citizen_197] Time to go to floor 5 and stay there for 00:24:32
[D1 16:09:21 floor_2] citizen_197 entered the queue
[D1 16:09:21 floor_2] citizen_197 found an empty queue and will be served immediately
[D1 16:09:21 elevator_1] Summoned to floor 2 from floor 2
[D1 16:09:28 elevator_2] Closing doors
[D1 16:09:30 elevator_1] At floor 1
[D1 16:09:30 elevator_1] Stopped at floor 1
[D1 16:09:30 elevator_1] Opening doors
[D1 16:09:31 elevator_2] Closed doors
[D1 16:09:31 elevator_2] Changing direction to Down
[D1 16:09:33 elevator_1] Opened doors
[D1 16:09:33 citizen_174] Left elevator_1, arrived at floor 1
[D1 16:09:41 elevator_2] At floor 4
[D1 16:09:45 citizen_143] Time to go to floor 1 and stay there for 00:22:27
[D1 16:09:45 floor_2] citizen_143 entered the queue
[D1 16:09:45 floor_2] citizen_143 is queued along with 0 other arrivals in front of it
[D1 16:09:45 elevator_1] Closing doors
[D1 16:09:48 elevator_1] Closed doors
[D1 16:09:48 elevator_1] Changing direction to Up
[D1 16:09:51 elevator_2] At floor 3
[D1 16:09:54 citizen_196] Time to go to floor 5 and stay there for 00:13:26
[D1 16:09:54 floor_1] citizen_196 entered the queue
[D1 16:09:54 floor_1] citizen_196 found an empty queue and will be served immediately
[D1 16:09:54 elevator_1] Summoned to floor 1 from floor 1
[D1 16:09:58 elevator_1] At floor 2
[D1 16:09:58 elevator_1] Stopped at floor 2
[D1 16:09:58 elevator_1] Opening doors
[D1 16:10:01 elevator_2] At floor 2
[D1 16:10:01 elevator_1] Opened doors
[D1 16:10:01 citizen_197] Entered elevator_1, going to floor 5
[D1 16:10:01 floor_2] citizen_197 is leaving the queue
[D1 16:10:01 floor_2] citizen_143 was served
[D1 16:10:01 elevator_1] Summoned to floor 2 from floor 2
[D1 16:10:01 elevator_2] Summoned to floor 2 from floor 2
[D1 16:10:01 citizen_143] Entered elevator_1, going to floor 1
[D1 16:10:01 floor_2] citizen_143 is leaving the queue
[D1 16:10:01 floor_2] The queue is now empty
[D1 16:10:11 elevator_2] At floor 1
[D1 16:10:13 elevator_1] Closing doors
[D1 16:10:16 elevator_1] Closed doors
[D1 16:10:21 elevator_2] At floor 0
[D1 16:10:21 elevator_2] Stopped at floor 0
[D1 16:10:21 elevator_2] Opening doors
[D1 16:10:24 elevator_2] Opened doors
[D1 16:10:24 citizen_172] Left elevator_2, arrived at floor 0
[D1 16:10:24 citizen_172] Left the building
[D1 16:10:26 elevator_1] At floor 3
[D1 16:10:36 elevator_2] Closing doors
[D1 16:10:36 elevator_1] At floor 4
[D1 16:10:39 elevator_2] Closed doors
[D1 16:10:39 elevator_2] Changing direction to Up
[D1 16:10:46 elevator_1] At floor 5
[D1 16:10:46 elevator_1] Stopped at floor 5
[D1 16:10:46 elevator_1] Opening doors
[D1 16:10:49 elevator_2] At floor 1
[D1 16:10:49 elevator_1] Opened doors
[D1 16:10:49 citizen_197] Left elevator_1, arrived at floor 5
[D1 16:10:59 elevator_2] At floor 2
[D1 16:10:59 elevator_2] Stopped at floor 2
[D1 16:10:59 elevator_2] Opening doors
[D1 16:11:01 elevator_1] Closing doors
[D1 16:11:02 elevator_2] Opened doors
[D1 16:11:04 citizen_164] Time to go to the ground floor and leave
[D1 16:11:04 floor_2] citizen_164 entered the queue
[D1 16:11:04 floor_2] citizen_164 found an empty queue and will be served immediately
[D1 16:11:04 elevator_2] Summoned to floor 2 from floor 2
[D1 16:11:04 citizen_164] Entered elevator_2, going to floor 0
[D1 16:11:04 floor_2] citizen_164 is leaving the queue
[D1 16:11:04 floor_2] The queue is now empty
[D1 16:11:04 elevator_1] Closed doors
[D1 16:11:04 elevator_1] Changing direction to Down
[D1 16:11:07 citizen_152] Time to go to floor 5 and stay there for 00:41:37
[D1 16:11:07 floor_3] citizen_152 entered the queue
[D1 16:11:07 floor_3] citizen_152 found an empty queue and will be served immediately
[D1 16:11:07 elevator_2] Summoned to floor 3 from floor 2
[D1 16:11:14 elevator_2] Closing doors
[D1 16:11:14 elevator_1] At floor 4
[D1 16:11:17 elevator_2] Closed doors
[D1 16:11:24 elevator_1] At floor 3
[D1 16:11:25 citizen_187] Time to go to floor 5 and stay there for 00:25:58
[D1 16:11:25 floor_3] citizen_187 entered the queue
[D1 16:11:25 floor_3] citizen_187 is queued along with 0 other arrivals in front of it
[D1 16:11:27 citizen_199] Time to go to floor 4 and stay there for 00:27:57
[D1 16:11:27 floor_5] citizen_199 entered the queue
[D1 16:11:27 floor_5] citizen_199 found an empty queue and will be served immediately
[D1 16:11:27 elevator_1] Summoned to floor 5 from floor 3
[D1 16:11:27 elevator_2] At floor 3
[D1 16:11:27 elevator_2] Stopped at floor 3
[D1 16:11:27 elevator_2] Opening doors
[D1 16:11:30 elevator_2] Opened doors
[D1 16:11:30 citizen_152] Entered elevator_2, going to floor 5
[D1 16:11:30 floor_3] citizen_152 is leaving the queue
[D1 16:11:30 floor_3] citizen_187 was served
[D1 16:11:30 elevator_1] Summoned to floor 3 from floor 3
[D1 16:11:30 elevator_2] Summoned to floor 3 from floor 3
[D1 16:11:30 citizen_187] Entered elevator_2, going to floor 5
[D1 16:11:30 floor_3] citizen_187 is leaving the queue
[D1 16:11:30 floor_3] The queue is now empty
[D1 16:11:34 elevator_1] At floor 2
[D1 16:11:42 elevator_2] Closing doors
[D1 16:11:44 elevator_1] At floor 1
[D1 16:11:44 elevator_1] Stopped at floor 1
[D1 16:11:44 elevator_1] Opening doors
[D1 16:11:45 elevator_2] Closed doors
[D1 16:11:47 elevator_1] Opened doors
[D1 16:11:47 citizen_143] Left elevator_1, arrived at floor 1
[D1 16:11:47 citizen_196] Entered elevator_1, going to floor 5
[D1 16:11:47 floor_1] citizen_196 is leaving the queue
[D1 16:11:47 floor_1] The queue is now empty
[D1 16:11:55 elevator_2] At floor 4
[D1 16:11:59 elevator_1] Closing doors
[D1 16:12:00 citizen_188] Time to go to floor 4 and stay there for 00:28:36
[D1 16:12:00 floor_1] citizen_188 entered the queue
[D1 16:12:00 floor_1] citizen_188 found an empty queue and will be served immediately
[D1 16:12:00 elevator_1] Summoned to floor 1 from floor 1
[D1 16:12:01 citizen_184] Time to go to floor 5 and stay there for 00:38:48
[D1 16:12:01 floor_2] citizen_184 entered the queue
[D1 16:12:01 floor_2] citizen_184 found an empty queue and will be served immediately
[D1 16:12:01 elevator_1] Summoned to floor 2 from floor 1
[D1 16:12:02 elevator_1] Reopening doors
[D1 16:12:02 citizen_188] Entered elevator_1, going to floor 4
[D1 16:12:02 floor_1] citizen_188 is leaving the queue
[D1 16:12:02 floor_1] The queue is now empty
[D1 16:12:04 citizen_173] Time to go to floor 2 and stay there for 00:33:23
[D1 16:12:04 floor_4] citizen_173 entered the queue
[D1 16:12:04 floor_4] citizen_173 found an empty queue and will be served immediately
[D1 16:12:04 elevator_2] Summoned to floor 4 from floor 4
[D1 16:12:05 elevator_2] At floor 5
[D1 16:12:05 elevator_2] Stopped at floor 5
[D1 16:12:05 elevator_2] Opening doors
[D1 16:12:08 elevator_2] Opened doors
[D1 16:12:08 citizen_152] Left elevator_2, arrived at floor 5
[D1 16:12:08 citizen_187] Left elevator_2, arrived at floor 5
[D1 16:12:14 elevator_1] Closing doors
[D1 16:12:17 elevator_1] Closed doors
[D1 16:12:17 elevator_1] Changing direction to Up
[D1 16:12:20 elevator_2] Closing doors
[D1 16:12:23 elevator_2] Closed doors
[D1 16:12:23 elevator_2] Changing direction to Down
[D1 16:12:27 elevator_1] At floor 2
[D1 16:12:27 elevator_1] Stopped at floor 2
[D1 16:12:27 elevator_1] Opening doors
[D1 16:12:30 citizen_146] Time to go to the ground floor and leave
[D1 16:12:30 floor_4] citizen_146 entered the queue
[D1 16:12:30 floor_4] citizen_146 is queued along with 0 other arrivals in front of it
[D1 16:12:30 elevator_1] Opened doors
[D1 16:12:30 citizen_184] Entered elevator_1, going to floor 5
[D1 16:12:30 floor_2] citizen_184 is leaving the queue
[D1 16:12:30 floor_2] The queue is now empty
[D1 16:12:33 elevator_2] At floor 4
[D1 16:12:33 elevator_2] Stopped at floor 4
[D1 16:12:33 elevator_2] Opening doors
[D1 16:12:36 elevator_2] Opened doors
[D1 16:12:36 citizen_173] Entered elevator_2, going to floor 2
[D1 16:12:36 floor_4] citizen_173 is leaving the queue
[D1 16:12:36 floor_4] citizen_146 was served
[D1 16:12:36 elevator_2] Summoned to floor 4 from floor 4
[D1 16:12:36 citizen_146] Entered elevator_2, going to floor 0
[D1 16:12:36 floor_4] citizen_146 is leaving the queue
[D1 16:12:36 floor_4] The queue is now empty
[D1 16:12:42 elevator_1] Closing doors
[D1 16:12:45 elevator_1] Closed doors
[D1 16:12:48 elevator_2] Closing doors
[D1 16:12:51 elevator_2] Closed doors
[D1 16:12:55 elevator_1] At floor 3
[D1 16:12:55 elevator_1] Stopped at floor 3
[D1 16:12:55 elevator_1] Opening doors
[D1 16:12:58 elevator_1] Opened doors
[D1 16:13:01 elevator_2] At floor 3
[D1 16:13:10 elevator_1] Closing doors
[D1 16:13:11 elevator_2] At floor 2
[D1 16:13:11 elevator_2] Stopped at floor 2
[D1 16:13:11 elevator_2] Opening doors
[D1 16:13:13 elevator_1] Closed doors
[D1 16:13:14 elevator_2] Opened doors
[D1 16:13:14 citizen_173] Left elevator_2, arrived at floor 2
[D1 16:13:23 elevator_1] At floor 4
[D1 16:13:23 elevator_1] Stopped at floor 4
[D1 16:13:23 elevator_1] Opening doors
[D1 16:13:26 elevator_2] Closing doors
[D1 16:13:26 elevator_1] Opened doors
[D1 16:13:26 citizen_188] Left elevator_1, arrived at floor 4
[D1 16:13:29 elevator_2] Closed doors
[D1 16:13:38 elevator_1] Closing doors
[D1 16:13:39 elevator_2] At floor 1
[D1 16:13:41 elevator_1] Closed doors
[D1 16:13:49 elevator_2] At floor 0
[D1 16:13:49 elevator_2] Stopped at floor 0
[D1 16:13:49 elevator_2] Opening doors
[D1 16:13:51 elevator_1] At floor 5
[D1 16:13:51 elevator_1] Stopped at floor 5
[D1 16:13:51 elevator_1] Opening doors
[D1 16:13:52 elevator_2] Opened doors
[D1 16:13:52 citizen_164] Left elevator_2, arrived at floor 0
[D1 16:13:52 citizen_146] Left elevator_2, arrived at floor 0
[D1 16:13:52 citizen_164] Left the building
[D1 16:13:52 citizen_146] Left the building
[D1 16:13:54 elevator_1] Opened doors
[D1 16:13:54 citizen_196] Left elevator_1, arrived at floor 5
[D1 16:13:54 citizen_184] Left elevator_1, arrived at floor 5
[D1 16:13:54 citizen_199] Entered elevator_1, going to floor 4
[D1 16:13:54 floor_5] citizen_199 is leaving the queue
[D1 16:13:54 floor_5] The queue is now empty
[D1 16:14:04 elevator_2] Closing doors
[D1 16:14:06 elevator_1] Closing doors
[D1 16:14:07 elevator_2] Closed doors
[D1 16:14:07 elevator_2] Resting at floor 0
[D1 16:14:09 elevator_1] Closed doors
[D1 16:14:09 elevator_1] Changing direction to Down
[D1 16:14:19 elevator_1] At floor 4
[D1 16:14:19 elevator_1] Stopped at floor 4
[D1 16:14:19 elevator_1] Opening doors
[D1 16:14:22 elevator_1] Opened doors
[D1 16:14:22 citizen_199] Left elevator_1, arrived at floor 4
[D1 16:14:32 citizen_194] Time to go to floor 1 and stay there for 00:14:42
[D1 16:14:32 floor_4] citizen_194 entered the queue
[D1 16:14:32 floor_4] citizen_194 found an empty queue and will be served immediately
[D1 16:14:32 elevator_1] Summoned to floor 4 from floor 4
[D1 16:14:32 citizen_194] Entered elevator_1, going to floor 1
[D1 16:14:32 floor_4] citizen_194 is leaving the queue
[D1 16:14:32 floor_4] The queue is now empty
[D1 16:14:34 elevator_1] Closing doors
[D1 16:14:37 elevator_1] Closed doors
[D1 16:14:47 elevator_1] At floor 3
[D1 16:14:57 elevator_1] At floor 2
[D1 16:15:07 elevator_1] At floor 1
[D1 16:15:07 elevator_1] Stopped at floor 1
[D1 16:15:07 elevator_1] Opening doors
[D1 16:15:10 elevator_1] Opened doors
[D1 16:15:10 citizen_194] Left elevator_1, arrived at floor 1
[D1 16:15:22 elevator_1] Closing doors
[D1 16:15:25 elevator_1] Closed doors
[D1 16:15:25 elevator_1] Resting at floor 1
[D1 16:16:18 citizen_186] Time to go to floor 4 and stay there for 00:27:31
[D1 16:16:18 floor_2] citizen_186 entered the queue
[D1 16:16:18 floor_2] citizen_186 found an empty queue and will be served immediately
[D1 16:16:18 elevator_1] Summoned to floor 2 from floor 1
[D1 16:16:18 elevator_1] Sprung into motion, heading Up
[D1 16:16:28 elevator_1] At floor 2
[D1 16:16:28 elevator_1] Stopped at floor 2
[D1 16:16:28 elevator_1] Opening doors
[D1 16:16:31 elevator_1] Opened doors
[D1 16:16:31 citizen_186] Entered elevator_1, going to floor 4
[D1 16:16:31 floor_2] citizen_186 is leaving the queue
[D1 16:16:31 floor_2] The queue is now empty
[D1 16:16:43 elevator_1] Closing doors
[D1 16:16:46 elevator_1] Closed doors
[D1 16:16:56 citizen_200] Time to go to floor 4 and stay there for 00:31:53
[D1 16:16:56 floor_1] citizen_200 entered the queue
[D1 16:16:56 floor_1] citizen_200 found an empty queue and will be served immediately
[D1 16:16:56 elevator_1] Summoned to floor 1 from floor 2
[D1 16:16:56 elevator_2] Summoned to floor 1 from floor 0
[D1 16:16:56 elevator_2] Sprung into motion, heading Up
[D1 16:16:56 elevator_1] At floor 3
[D1 16:17:06 elevator_2] At floor 1
[D1 16:17:06 elevator_2] Stopped at floor 1
[D1 16:17:06 elevator_2] Opening doors
[D1 16:17:06 elevator_1] At floor 4
[D1 16:17:06 elevator_1] Stopped at floor 4
[D1 16:17:06 elevator_1] Opening doors
[D1 16:17:09 elevator_2] Opened doors
[D1 16:17:09 elevator_1] Opened doors
[D1 16:17:09 citizen_186] Left elevator_1, arrived at floor 4
[D1 16:17:09 citizen_200] Entered elevator_2, going to floor 4
[D1 16:17:09 floor_1] citizen_200 is leaving the queue
[D1 16:17:09 floor_1] The queue is now empty
[D1 16:17:14 citizen_190] Time to go to floor 1 and stay there for 00:33:27
[D1 16:17:14 floor_4] citizen_190 entered the queue
[D1 16:17:14 floor_4] citizen_190 found an empty queue and will be served immediately
[D1 16:17:14 elevator_1] Summoned to floor 4 from floor 4
[D1 16:17:14 citizen_190] Entered elevator_1, going to floor 1
[D1 16:17:14 floor_4] citizen_190 is leaving the queue
[D1 16:17:14 floor_4] The queue is now empty
[D1 16:17:21 elevator_2] Closing doors
[D1 16:17:21 elevator_1] Closing doors
[D1 16:17:22 citizen_159] Time to go to floor 2 and stay there for 00:32:50
[D1 16:17:22 floor_3] citizen_159 entered the queue
[D1 16:17:22 floor_3] citizen_159 found an empty queue and will be served immediately
[D1 16:17:22 elevator_1] Summoned to floor 3 from floor 4
[D1 16:17:24 elevator_2] Closed doors
[D1 16:17:24 elevator_1] Closed doors
[D1 16:17:24 elevator_1] Changing direction to Down
[D1 16:17:34 elevator_2] At floor 2
[D1 16:17:34 elevator_1] At floor 3
[D1 16:17:34 elevator_1] Stopped at floor 3
[D1 16:17:34 elevator_1] Opening doors
[D1 16:17:37 elevator_1] Opened doors
[D1 16:17:37 citizen_159] Entered elevator_1, going to floor 2
[D1 16:17:37 floor_3] citizen_159 is leaving the queue
[D1 16:17:37 floor_3] The queue is now empty
[D1 16:17:44 elevator_2] At floor 3
[D1 16:17:49 elevator_1] Closing doors
[D1 16:17:52 elevator_1] Closed doors
[D1 16:17:54 elevator_2] At floor 4
[D1 16:17:54 elevator_2] Stopped at floor 4
[D1 16:17:54 elevator_2] Opening doors
[D1 16:17:57 citizen_175] Time to go to floor 4 and stay there for 00:20:00
[D1 16:17:57 floor_1] citizen_175 entered the queue
[D1 16:17:57 floor_1] citizen_175 found an empty queue and will be served immediately
[D1 16:17:57 elevator_1] Summoned to floor 1 from floor 3
[D1 16:17:57 elevator_2] Opened doors
[D1 16:17:57 citizen_200] Left elevator_2, arrived at floor 4
[D1 16:18:02 elevator_1] At floor 2
[D1 16:18:02 elevator_1] Stopped at floor 2
[D1 16:18:02 elevator_1] Opening doors
[D1 16:18:05 elevator_1] Opened doors
[D1 16:18:05 citizen_159] Left elevator_1, arrived at floor 2
[D1 16:18:09 elevator_2] Closing doors
[D1 16:18:12 elevator_2] Closed doors
[D1 16:18:12 elevator_2] Resting at floor 4
[D1 16:18:17 elevator_1] Closing doors
[D1 16:18:20 elevator_1] Closed doors
[D1 16:18:30 elevator_1] At floor 1
[D1 16:18:30 elevator_1] Stopped at floor 1
[D1 16:18:30 elevator_1] Opening doors
[D1 16:18:33 elevator_1] Opened doors
[D1 16:18:33 citizen_190] Left elevator_1, arrived at floor 1
[D1 16:18:33 citizen_175] Entered elevator_1, going to floor 4
[D1 16:18:33 floor_1] citizen_175 is leaving the queue
[D1 16:18:33 floor_1] The queue is now empty
[D1 16:18:45 elevator_1] Closing doors
[D1 16:18:48 citizen_193] Time to go to floor 2 and stay there for 00:41:03
[D1 16:18:48 floor_1] citizen_193 entered the queue
[D1 16:18:48 floor_1] citizen_193 found an empty queue and will be served immediately
[D1 16:18:48 elevator_1] Summoned to floor 1 from floor 1
[D1 16:18:48 elevator_1] Reopening doors
[D1 16:18:48 citizen_193] Entered elevator_1, going to floor 2
[D1 16:18:48 floor_1] citizen_193 is leaving the queue
[D1 16:18:48 floor_1] The queue is now empty
[D1 16:19:00 elevator_1] Closing doors
[D1 16:19:03 elevator_1] Closed doors
[D1 16:19:03 elevator_1] Changing direction to Up
[D1 16:19:13 elevator_1] At floor 2
[D1 16:19:13 elevator_1] Stopped at floor 2
[D1 16:19:13 elevator_1] Opening doors
[D1 16:19:16 elevator_1] Opened doors
[D1 16:19:16 citizen_193] Left elevator_1, arrived at floor 2
[D1 16:19:28 elevator_1] Closing doors
[D1 16:19:31 elevator_1] Closed doors
[D1 16:19:41 elevator_1] At floor 3
[D1 16:19:51 elevator_1] At floor 4
[D1 16:19:51 elevator_1] Stopped at floor 4
[D1 16:19:51 elevator_1] Opening doors
[D1 16:19:54 elevator_1] Opened doors
[D1 16:19:54 citizen_175] Left elevator_1, arrived at floor 4
[D1 16:20:06 elevator_1] Closing doors
[D1 16:20:09 elevator_1] Closed doors
[D1 16:20:09 elevator_1] Resting at floor 4
[D1 16:20:23 citizen_178] Time to go to floor 4 and stay there for 00:27:34
[D1 16:20:23 floor_3] citizen_178 entered the queue
[D1 16:20:23 floor_3] citizen_178 found an empty queue and will be served immediately
[D1 16:20:23 elevator_1] Summoned to floor 3 from floor 4
[D1 16:20:23 elevator_1] Sprung into motion, heading Down
[D1 16:20:23 elevator_2] Summoned to floor 3 from floor 4
[D1 16:20:23 elevator_2] Sprung into motion, heading Down
[D1 16:20:33 elevator_1] At floor 3
[D1 16:20:33 elevator_1] Stopped at floor 3
[D1 16:20:33 elevator_1] Opening doors
[D1 16:20:33 elevator_2] At floor 3
[D1 16:20:33 elevator_2] Stopped at floor 3
[D1 16:20:33 elevator_2] Opening doors
[D1 16:20:36 elevator_1] Opened doors
[D1 16:20:36 elevator_2] Opened doors
[D1 16:20:36 citizen_178] Entered elevator_1, going to floor 4
[D1 16:20:36 floor_3] citizen_178 is leaving the queue
[D1 16:20:36 floor_3] The queue is now empty
[D1 16:20:44 citizen_156] Time to go to the ground floor and leave
[D1 16:20:44 floor_4] citizen_156 entered the queue
[D1 16:20:44 floor_4] citizen_156 found an empty queue and will be served immediately
[D1 16:20:44 elevator_1] Summoned to floor 4 from floor 3
[D1 16:20:44 elevator_2] Summoned to floor 4 from floor 3
[D1 16:20:48 elevator_1] Closing doors
[D1 16:20:48 elevator_2] Closing doors
[D1 16:20:51 elevator_1] Closed doors
[D1 16:20:51 elevator_2] Closed doors
[D1 16:20:51 elevator_1] Changing direction to Up
[D1 16:20:51 elevator_2] Changing direction to Up
[D1 16:21:01 elevator_1] At floor 4
[D1 16:21:01 elevator_1] Stopped at floor 4
[D1 16:21:01 elevator_1] Opening doors
[D1 16:21:01 elevator_2] At floor 4
[D1 16:21:01 elevator_2] Stopped at floor 4
[D1 16:21:01 elevator_2] Opening doors
[D1 16:21:04 elevator_1] Opened doors
[D1 16:21:04 elevator_2] Opened doors
[D1 16:21:04 citizen_178] Left elevator_1, arrived at floor 4
[D1 16:21:04 citizen_156] Entered elevator_1, going to floor 0
[D1 16:21:04 floor_4] citizen_156 is leaving the queue
[D1 16:21:04 floor_4] The queue is now empty
[D1 16:21:16 elevator_1] Closing doors
[D1 16:21:16 elevator_2] Closing doors
[D1 16:21:19 elevator_1] Closed doors
[D1 16:21:19 elevator_2] Closed doors
[D1 16:21:19 elevator_1] Changing direction to Down
[D1 16:21:19 elevator_2] Resting at floor 4
[D1 16:21:29 elevator_1] At floor 3
[D1 16:21:39 elevator_1] At floor 2
[D1 16:21:49 citizen_183] Time to go to floor 3 and stay there for 00:32:42
[D1 16:21:49 floor_4] citizen_183 entered the queue
[D1 16:21:49 floor_4] citizen_183 found an empty queue and will be served immediately
[D1 16:21:49 elevator_2] Summoned to floor 4 from floor 4
[D1 16:21:49 elevator_2] Opening doors
[D1 16:21:49 elevator_1] At floor 1
[D1 16:21:52 elevator_2] Opened doors
[D1 16:21:52 citizen_183] Entered elevator_2, going to floor 3
[D1 16:21:52 floor_4] citizen_183 is leaving the queue
[D1 16:21:52 floor_4] The queue is now empty
[D1 16:21:55 citizen_198] Time to go to floor 3 and stay there for 00:33:56
[D1 16:21:55 floor_4] citizen_198 entered the queue
[D1 16:21:55 floor_4] citizen_198 found an empty queue and will be served immediately
[D1 16:21:55 elevator_2] Summoned to floor 4 from floor 4
[D1 16:21:55 citizen_198] Entered elevator_2, going to floor 3
[D1 16:21:55 floor_4] citizen_198 is leaving the queue
[D1 16:21:55 floor_4] The queue is now empty
[D1 16:21:59 elevator_1] At floor 0
[D1 16:21:59 elevator_1] Stopped at floor 0
[D1 16:21:59 elevator_1] Opening doors
[D1 16:22:02 elevator_1] Opened doors
[D1 16:22:02 citizen_156] Left elevator_1, arrived at floor 0
[D1 16:22:02 citizen_156] Left the building
[D1 16:22:04 elevator_2] Closing doors
[D1 16:22:07 elevator_2] Closed doors
[D1 16:22:07 elevator_2] Sprung into motion, heading Down
[D1 16:22:14 elevator_1] Closing doors
[D1 16:22:17 elevator_2] At floor 3
[D1 16:22:17 elevator_2] Stopped at floor 3
[D1 16:22:17 elevator_2] Opening doors
[D1 16:22:17 elevator_1] Closed doors
[D1 16:22:17 elevator_1] Resting at floor 0
[D1 16:22:20 elevator_2] Opened doors
[D1 16:22:20 citizen_183] Left elevator_2, arrived at floor 3
[D1 16:22:20 citizen_198] Left elevator_2, arrived at floor 3
[D1 16:22:32 elevator_2] Closing doors
[D1 16:22:35 elevator_2] Closed doors
[D1 16:22:35 elevator_2] Resting at floor 3
[D1 16:22:36 citizen_176] Time to go to floor 5 and stay there for 00:38:36
[D1 16:22:36 floor_3] citizen_176 entered the queue
[D1 16:22:36 floor_3] citizen_176 found an empty queue and will be served immediately
[D1 16:22:36 elevator_2] Summoned to floor 3 from floor 3
[D1 16:22:36 elevator_2] Opening doors
[D1 16:22:39 elevator_2] Opened doors
[D1 16:22:39 citizen_176] Entered elevator_2, going to floor 5
[D1 16:22:39 floor_3] citizen_176 is leaving the queue
[D1 16:22:39 floor_3] The queue is now empty
[D1 16:22:51 elevator_2] Closing doors
[D1 16:22:54 elevator_2] Closed doors
[D1 16:22:54 elevator_2] Sprung into motion, heading Up
[D1 16:23:04 elevator_2] At floor 4
[D1 16:23:14 elevator_2] At floor 5
[D1 16:23:14 elevator_2] Stopped at floor 5
[D1 16:23:14 elevator_2] Opening doors
[D1 16:23:17 elevator_2] Opened doors
[D1 16:23:17 citizen_176] Left elevator_2, arrived at floor 5
[D1 16:23:29 elevator_2] Closing doors
[D1 16:23:32 elevator_2] Closed doors
[D1 16:23:32 elevator_2] Resting at floor 5
[D1 16:25:31 citizen_180] Time to go to floor 2 and stay there for 00:28:42
[D1 16:25:31 floor_1] citizen_180 entered the queue
[D1 16:25:31 floor_1] citizen_180 found an empty queue and will be served immediately
[D1 16:25:31 elevator_1] Summoned to floor 1 from floor 0
[D1 16:25:31 elevator_1] Sprung into motion, heading Up
[D1 16:25:38 citizen_179] Time to go to floor 3 and stay there for 00:17:39
[D1 16:25:38 floor_1] citizen_179 entered the queue
[D1 16:25:38 floor_1] citizen_179 is queued along with 0 other arrivals in front of it
[D1 16:25:41 elevator_1] At floor 1
[D1 16:25:41 elevator_1] Stopped at floor 1
[D1 16:25:41 elevator_1] Opening doors
[D1 16:25:44 elevator_1] Opened doors
[D1 16:25:44 citizen_180] Entered elevator_1, going to floor 2
[D1 16:25:44 floor_1] citizen_180 is leaving the queue
[D1 16:25:44 floor_1] citizen_179 was served
[D1 16:25:44 elevator_1] Summoned to floor 1 from floor 1
[D1 16:25:44 citizen_179] Entered elevator_1, going to floor 3
[D1 16:25:44 floor_1] citizen_179 is leaving the queue
[D1 16:25:44 floor_1] The queue is now empty
[D1 16:25:48 citizen_195] Time to go to floor 2 and stay there for 00:40:28
[D1 16:25:48 floor_5] citizen_195 entered the queue
[D1 16:25:48 floor_5] citizen_195 found an empty queue and will be served immediately
[D1 16:25:48 elevator_2] Summoned to floor 5 from floor 5
[D1 16:25:48 elevator_2] Opening doors
[D1 16:25:51 elevator_2] Opened doors
[D1 16:25:51 citizen_195] Entered elevator_2, going to floor 2
[D1 16:25:51 floor_5] citizen_195 is leaving the queue
[D1 16:25:51 floor_5] The queue is now empty
[D1 16:25:56 elevator_1] Closing doors
[D1 16:25:59 elevator_1] Closed doors
[D1 16:26:03 elevator_2] Closing doors
[D1 16:26:06 elevator_2] Closed doors
[D1 16:26:06 elevator_2] Sprung into motion, heading Down
[D1 16:26:09 elevator_1] At floor 2
[D1 16:26:09 elevator_1] Stopped at floor 2
[D1 16:26:09 elevator_1] Opening doors
[D1 16:26:12 elevator_1] Opened doors
[D1 16:26:12 citizen_180] Left elevator_1, arrived at floor 2
[D1 16:26:16 elevator_2] At floor 4
[D1 16:26:24 elevator_1] Closing doors
[D1 16:26:26 elevator_2] At floor 3
[D1 16:26:27 elevator_1] Closed doors
[D1 16:26:36 elevator_2] At floor 2
[D1 16:26:36 elevator_2] Stopped at floor 2
[D1 16:26:36 elevator_2] Opening doors
[D1 16:26:37 elevator_1] At floor 3
[D1 16:26:37 elevator_1] Stopped at floor 3
[D1 16:26:37 elevator_1] Opening doors
[D1 16:26:39 elevator_2] Opened doors
[D1 16:26:39 citizen_195] Left elevator_2, arrived at floor 2
[D1 16:26:40 elevator_1] Opened doors
[D1 16:26:40 citizen_179] Left elevator_1, arrived at floor 3
[D1 16:26:51 elevator_2] Closing doors
[D1 16:26:52 elevator_1] Closing doors
[D1 16:26:54 elevator_2] Closed doors
[D1 16:26:54 elevator_2] Resting at floor 2
[D1 16:26:55 elevator_1] Closed doors
[D1 16:26:55 elevator_1] Resting at floor 3
[D1 16:27:12 citizen_129] Time to go to the ground floor and leave
[D1 16:27:12 floor_3] citizen_129 entered the queue
[D1 16:27:12 floor_3] citizen_129 found an empty queue and will be served immediately
[D1 16:27:12 elevator_1] Summoned to floor 3 from floor 3
[D1 16:27:12 elevator_1] Opening doors
[D1 16:27:15 elevator_1] Opened doors
[D1 16:27:15 citizen_129] Entered elevator_1, going to floor 0
[D1 16:27:15 floor_3] citizen_129 is leaving the queue
[D1 16:27:15 floor_3] The queue is now empty
[D1 16:27:20 citizen_196] Time to go to floor 1 and stay there for 00:30:35
[D1 16:27:20 floor_5] citizen_196 entered the queue
[D1 16:27:20 floor_5] citizen_196 found an empty queue and will be served immediately
[D1 16:27:20 elevator_1] Summoned to floor 5 from floor 3
[D1 16:27:27 elevator_1] Closing doors
[D1 16:27:30 elevator_1] Closed doors
[D1 16:27:30 elevator_1] Sprung into motion, heading Down
[D1 16:27:40 elevator_1] At floor 2
[D1 16:27:50 elevator_1] At floor 1
[D1 16:27:53 citizen_192] Time to go to floor 2 and stay there for 00:17:48
[D1 16:27:53 floor_1] citizen_192 entered the queue
[D1 16:27:53 floor_1] citizen_192 found an empty queue and will be served immediately
[D1 16:27:53 elevator_1] Summoned to floor 1 from floor 1
[D1 16:28:00 elevator_1] At floor 0
[D1 16:28:00 elevator_1] Stopped at floor 0
[D1 16:28:00 elevator_1] Opening doors
[D1 16:28:03 elevator_1] Opened doors
[D1 16:28:03 citizen_129] Left elevator_1, arrived at floor 0
[D1 16:28:03 citizen_129] Left the building
[D1 16:28:15 elevator_1] Closing doors
[D1 16:28:18 elevator_1] Closed doors
[D1 16:28:18 elevator_1] Changing direction to Up
[D1 16:28:28 elevator_1] At floor 1
[D1 16:28:28 elevator_1] Stopped at floor 1
[D1 16:28:28 elevator_1] Opening doors
[D1 16:28:29 citizen_170] Time to go to the ground floor and leave
[D1 16:28:29 floor_1] citizen_170 entered the queue
[D1 16:28:29 floor_1] citizen_170 is queued along with 0 other arrivals in front of it
[D1 16:28:31 elevator_1] Opened doors
[D1 16:28:31 citizen_192] Entered elevator_1, going to floor 2
[D1 16:28:31 floor_1] citizen_192 is leaving the queue
[D1 16:28:31 floor_1] citizen_170 was served
[D1 16:28:31 elevator_1] Summoned to floor 1 from floor 1
[D1 16:28:31 citizen_170] Entered elevator_1, going to floor 0
[D1 16:28:31 floor_1] citizen_170 is leaving the queue
[D1 16:28:31 floor_1] The queue is now empty
[D1 16:28:43 elevator_1] Closing doors
[D1 16:28:46 citizen_167] Time to go to the ground floor and leave
[D1 16:28:46 floor_1] citizen_167 entered the queue
[D1 16:28:46 floor_1] citizen_167 found an empty queue and will be served immediately
[D1 16:28:46 elevator_1] Summoned to floor 1 from floor 1
[D1 16:28:46 elevator_1] Reopening doors
[D1 16:28:46 citizen_167] Entered elevator_1, going to floor 0
[D1 16:28:46 floor_1] citizen_167 is leaving the queue
[D1 16:28:46 floor_1] The queue is now empty
[D1 16:28:58 elevator_1] Closing doors
[D1 16:29:01 elevator_1] Closed doors
[D1 16:29:11 elevator_1] At floor 2
[D1 16:29:11 elevator_1] Stopped at floor 2
[D1 16:29:11 elevator_1] Opening doors
[D1 16:29:14 elevator_1] Opened doors
[D1 16:29:14 citizen_192] Left elevator_1, arrived at floor 2
[D1 16:29:26 elevator_1] Closing doors
[D1 16:29:29 elevator_1] Closed doors
[D1 16:29:39 elevator_1] At floor 3
[D1 16:29:49 elevator_1] At floor 4
[D1 16:29:52 citizen_194] Time to go to floor 4 and stay there for 00:42:49
[D1 16:29:52 floor_1] citizen_194 entered the queue
[D1 16:29:52 floor_1] citizen_194 found an empty queue and will be served immediately
[D1 16:29:52 elevator_2] Summoned to floor 1 from floor 2
[D1 16:29:52 elevator_2] Sprung into motion, heading Down
[D1 16:29:59 elevator_1] At floor 5
[D1 16:29:59 elevator_1] Stopped at floor 5
[D1 16:29:59 elevator_1] Opening doors
[D1 16:30:01 citizen_185] Time to go to floor 4 and stay there for 00:36:38
[D1 16:30:01 floor_2] citizen_185 entered the queue
[D1 16:30:01 floor_2] citizen_185 found an empty queue and will be served immediately
[D1 16:30:01 elevator_2] Summoned to floor 2 from floor 2
[D1 16:30:02 elevator_2] At floor 1
[D1 16:30:02 elevator_2] Stopped at floor 1
[D1 16:30:02 elevator_2] Opening doors
[D1 16:30:02 elevator_1] Opened doors
[D1 16:30:02 citizen_196] Entered elevator_1, going to floor 1
[D1 16:30:02 floor_5] citizen_196 is leaving the queue
[D1 16:30:02 floor_5] The queue is now empty
[D1 16:30:05 elevator_2] Opened doors
[D1 16:30:05 citizen_194] Entered elevator_2, going to floor 4
[D1 16:30:05 floor_1] citizen_194 is leaving the queue
[D1 16:30:05 floor_1] The queue is now empty
[D1 16:30:14 elevator_1] Closing doors
[D1 16:30:17 elevator_2] Closing doors
[D1 16:30:17 elevator_1] Closed doors
[D1 16:30:17 elevator_1] Changing direction to Down
[D1 16:30:20 elevator_2] Closed doors
[D1 16:30:20 elevator_2] Changing direction to Up
[D1 16:30:27 elevator_1] At floor 4
[D1 16:30:30 elevator_2] At floor 2
[D1 16:30:30 elevator_2] Stopped at floor 2
[D1 16:30:30 elevator_2] Opening doors
[D1 16:30:33 elevator_2] Opened doors
[D1 16:30:33 citizen_185] Entered elevator_2, going to floor 4
[D1 16:30:33 floor_2] citizen_185 is leaving the queue
[D1 16:30:33 floor_2] The queue is now empty
[D1 16:30:37 elevator_1] At floor 3
[D1 16:30:37 citizen_174] Time to go to floor 2 and stay there for 00:14:39
[D1 16:30:37 floor_1] citizen_174 entered the queue
[D1 16:30:37 floor_1] citizen_174 found an empty queue and will be served immediately
[D1 16:30:37 elevator_2] Summoned to floor 1 from floor 2
[D1 16:30:41 citizen_168] Time to go to the ground floor and leave
[D1 16:30:41 floor_2] citizen_168 entered the queue
[D1 16:30:41 floor_2] citizen_168 found an empty queue and will be served immediately
[D1 16:30:41 elevator_2] Summoned to floor 2 from floor 2
[D1 16:30:41 citizen_168] Entered elevator_2, going to floor 0
[D1 16:30:41 floor_2] citizen_168 is leaving the queue
[D1 16:30:41 floor_2] The queue is now empty
[D1 16:30:45 elevator_2] Closing doors
[D1 16:30:47 elevator_1] At floor 2
[D1 16:30:48 citizen_189] Time to go to floor 5 and stay there for 00:28:59
[D1 16:30:48 floor_4] citizen_189 entered the queue
[D1 16:30:48 floor_4] citizen_189 found an empty queue and will be served immediately
[D1 16:30:48 elevator_1] Summoned to floor 4 from floor 2
[D1 16:30:48 elevator_2] Summoned to floor 4 from floor 2
[D1 16:30:48 elevator_2] Closed doors
[D1 16:30:57 elevator_1] At floor 1
[D1 16:30:57 elevator_1] Stopped at floor 1
[D1 16:30:57 elevator_1] Opening doors
[D1 16:30:58 elevator_2] At floor 3
[D1 16:31:00 elevator_1] Opened doors
[D1 16:31:00 citizen_196] Left elevator_1, arrived at floor 1
[D1 16:31:08 elevator_2] At floor 4
[D1 16:31:08 elevator_2] Stopped at floor 4
[D1 16:31:08 elevator_2] Opening doors
[D1 16:31:11 elevator_2] Opened doors
[D1 16:31:11 citizen_194] Left elevator_2, arrived at floor 4
[D1 16:31:11 citizen_185] Left elevator_2, arrived at floor 4
[D1 16:31:11 citizen_189] Entered elevator_2, going to floor 5
[D1 16:31:11 floor_4] citizen_189 is leaving the queue
[D1 16:31:11 floor_4] The queue is now empty
[D1 16:31:12 elevator_1] Closing doors
[D1 16:31:12 citizen_182] Time to go to floor 1 and stay there for 00:26:15
[D1 16:31:12 floor_2] citizen_182 entered the queue
[D1 16:31:12 floor_2] citizen_182 found an empty queue and will be served immediately
[D1 16:31:12 elevator_1] Summoned to floor 2 from floor 1
[D1 16:31:15 elevator_1] Closed doors
[D1 16:31:23 elevator_2] Closing doors
[D1 16:31:25 elevator_1] At floor 0
[D1 16:31:25 elevator_1] Stopped at floor 0
[D1 16:31:25 elevator_1] Opening doors
[D1 16:31:26 elevator_2] Closed doors
[D1 16:31:28 elevator_1] Opened doors
[D1 16:31:28 citizen_170] Left elevator_1, arrived at floor 0
[D1 16:31:28 citizen_167] Left elevator_1, arrived at floor 0
[D1 16:31:28 citizen_170] Left the building
[D1 16:31:28 citizen_167] Left the building
[D1 16:31:36 elevator_2] At floor 5
[D1 16:31:36 elevator_2] Stopped at floor 5
[D1 16:31:36 elevator_2] Opening doors
[D1 16:31:39 elevator_2] Opened doors
[D1 16:31:39 citizen_189] Left elevator_2, arrived at floor 5
[D1 16:31:40 elevator_1] Closing doors
[D1 16:31:43 elevator_1] Closed doors
[D1 16:31:43 elevator_1] Changing direction to Up
[D1 16:31:51 elevator_2] Closing doors
[D1 16:31:53 elevator_1] At floor 1
[D1 16:31:54 elevator_2] Closed doors
[D1 16:31:54 elevator_2] Changing direction to Down
[D1 16:32:00 citizen_162] Time to go to the ground floor and leave
[D1 16:32:00 floor_5] citizen_162 entered the queue
[D1 16:32:00 floor_5] citizen_162 found an empty queue and will be served immediately
[D1 16:32:00 elevator_2] Summoned to floor 5 from floor 5
[D1 16:32:03 elevator_1] At floor 2
[D1 16:32:03 elevator_1] Stopped at floor 2
[D1 16:32:03 elevator_1] Opening doors
[D1 16:32:04 elevator_2] At floor 4
[D1 16:32:06 elevator_1] Opened doors
[D1 16:32:06 citizen_182] Entered elevator_1, going to floor 1
[D1 16:32:06 floor_2] citizen_182 is leaving the queue
[D1 16:32:06 floor_2] The queue is now empty
[D1 16:32:14 elevator_2] At floor 3
[D1 16:32:18 elevator_1] Closing doors
[D1 16:32:21 elevator_1] Closed doors
[D1 16:32:24 elevator_2] At floor 2
[D1 16:32:27 citizen_191] Time to go to floor 4 and stay there for 00:22:04
[D1 16:32:27 floor_1] citizen_191 entered the queue
[D1 16:32:27 floor_1] citizen_191 is queued along with 0 other arrivals in front of it
[D1 16:32:31 elevator_1] At floor 3
[D1 16:32:34 elevator_2] At floor 1
[D1 16:32:34 elevator_2] Stopped at floor 1
[D1 16:32:34 elevator_2] Opening doors
[D1 16:32:37 elevator_2] Opened doors
[D1 16:32:37 citizen_174] Entered elevator_2, going to floor 2
[D1 16:32:37 floor_1] citizen_174 is leaving the queue
[D1 16:32:37 floor_1] citizen_191 was served
[D1 16:32:37 elevator_2] Summoned to floor 1 from floor 1
[D1 16:32:37 citizen_191] Entered elevator_2, going to floor 4
[D1 16:32:37 floor_1] citizen_191 is leaving the queue
[D1 16:32:37 floor_1] The queue is now empty
[D1 16:32:41 elevator_1] At floor 4
[D1 16:32:41 elevator_1] Stopped at floor 4
[D1 16:32:41 elevator_1] Opening doors
[D1 16:32:44 elevator_1] Opened doors
[D1 16:32:49 elevator_2] Closing doors
[D1 16:32:52 elevator_2] Closed doors
[D1 16:32:56 elevator_1] Closing doors
[D1 16:32:59 elevator_1] Closed doors
[D1 16:32:59 elevator_1] Changing direction to Down
[D1 16:33:02 elevator_2] At floor 0
[D1 16:33:02 elevator_2] Stopped at floor 0
[D1 16:33:02 elevator_2] Opening doors
[D1 16:33:05 elevator_2] Opened doors
[D1 16:33:05 citizen_168] Left elevator_2, arrived at floor 0
[D1 16:33:05 citizen_168] Left the building
[D1 16:33:09 elevator_1] At floor 3
[D1 16:33:17 elevator_2] Closing doors
[D1 16:33:19 elevator_1] At floor 2
[D1 16:33:20 elevator_2] Closed doors
[D1 16:33:20 elevator_2] Changing direction to Up
[D1 16:33:25 citizen_157] Time to go to the ground floor and leave
[D1 16:33:25 floor_5] citizen_157 entered the queue
[D1 16:33:25 floor_5] citizen_157 is queued along with 0 other arrivals in front of it
[D1 16:33:29 elevator_1] At floor 1
[D1 16:33:29 elevator_1] Stopped at floor 1
[D1 16:33:29 elevator_1] Opening doors
[D1 16:33:30 elevator_2] At floor 1
[D1 16:33:32 elevator_1] Opened doors
[D1 16:33:32 citizen_182] Left elevator_1, arrived at floor 1
[D1 16:33:40 elevator_2] At floor 2
[D1 16:33:40 elevator_2] Stopped at floor 2
[D1 16:33:40 elevator_2] Opening doors
[D1 16:33:43 citizen_155] Time to go to the ground floor and leave
[D1 16:33:43 floor_3] citizen_155 entered the queue
[D1 16:33:43 floor_3] citizen_155 found an empty queue and will be served immediately
[D1 16:33:43 elevator_2] Summoned to floor 3 from floor 2
[D1 16:33:43 elevator_2] Opened doors
[D1 16:33:43 citizen_174] Left elevator_2, arrived at floor 2
[D1 16:33:44 elevator_1] Closing doors
[D1 16:33:47 elevator_1] Closed doors
[D1 16:33:47 elevator_1] Resting at floor 1
[D1 16:33:55 elevator_2] Closing doors
[D1 16:33:58 elevator_2] Closed doors
[D1 16:34:08 elevator_2] At floor 3
[D1 16:34:08 elevator_2] Stopped at floor 3
[D1 16:34:08 elevator_2] Opening doors
[D1 16:34:11 elevator_2] Opened doors
[D1 16:34:11 citizen_155] Entered elevator_2, going to floor 0
[D1 16:34:11 floor_3] citizen_155 is leaving the queue
[D1 16:34:11 floor_3] The queue is now empty
[D1 16:34:14 citizen_143] Time to go to the ground floor and leave
[D1 16:34:14 floor_1] citizen_143 entered the queue
[D1 16:34:14 floor_1] citizen_143 found an empty queue and will be served immediately
[D1 16:34:14 elevator_1] Summoned to floor 1 from floor 1
[D1 16:34:14 elevator_1] Opening doors
[D1 16:34:17 elevator_1] Opened doors
[D1 16:34:17 citizen_143] Entered elevator_1, going to floor 0
[D1 16:34:17 floor_1] citizen_143 is leaving the queue
[D1 16:34:17 floor_1] The queue is now empty
[D1 16:34:23 elevator_2] Closing doors
[D1 16:34:26 elevator_2] Closed doors
[D1 16:34:29 elevator_1] Closing doors
[D1 16:34:32 elevator_1] Closed doors
[D1 16:34:32 elevator_1] Sprung into motion, heading Down
[D1 16:34:36 elevator_2] At floor 4
[D1 16:34:36 elevator_2] Stopped at floor 4
[D1 16:34:36 elevator_2] Opening doors
[D1 16:34:39 elevator_2] Opened doors
[D1 16:34:39 citizen_191] Left elevator_2, arrived at floor 4
[D1 16:34:42 elevator_1] At floor 0
[D1 16:34:42 elevator_1] Stopped at floor 0
[D1 16:34:42 elevator_1] Opening doors
[D1 16:34:45 elevator_1] Opened doors
[D1 16:34:45 citizen_143] Left elevator_1, arrived at floor 0
[D1 16:34:45 citizen_143] Left the building
[D1 16:34:51 elevator_2] Closing doors
[D1 16:34:54 elevator_2] Closed doors
[D1 16:34:57 elevator_1] Closing doors
[D1 16:35:00 elevator_1] Closed doors
[D1 16:35:00 elevator_1] Resting at floor 0
[D1 16:35:04 elevator_2] At floor 5
[D1 16:35:04 elevator_2] Stopped at floor 5
[D1 16:35:04 elevator_2] Opening doors
[D1 16:35:07 elevator_2] Opened doors
[D1 16:35:07 citizen_162] Entered elevator_2, going to floor 0
[D1 16:35:07 floor_5] citizen_162 is leaving the queue
[D1 16:35:07 floor_5] citizen_157 was served
[D1 16:35:07 elevator_2] Summoned to floor 5 from floor 5
[D1 16:35:07 citizen_157] Entered elevator_2, going to floor 0
[D1 16:35:07 floor_5] citizen_157 is leaving the queue
[D1 16:35:07 floor_5] The queue is now empty
[D1 16:35:19 elevator_2] Closing doors
[D1 16:35:21 citizen_197] Time to go to floor 2 and stay there for 00:32:05
[D1 16:35:21 floor_5] citizen_197 entered the queue
[D1 16:35:21 floor_5] citizen_197 found an empty queue and will be served immediately
[D1 16:35:21 elevator_2] Summoned to floor 5 from floor 5
[D1 16:35:22 elevator_2] Reopening doors
[D1 16:35:22 citizen_197] Entered elevator_2, going to floor 2
[D1 16:35:22 floor_5] citizen_197 is leaving the queue
[D1 16:35:22 floor_5] The queue is now empty
[D1 16:35:34 elevator_2] Closing doors
[D1 16:35:37 elevator_2] Closed doors
[D1 16:35:37 elevator_2] Changing direction to Down
[D1 16:35:47 elevator_2] At floor 4
[D1 16:35:57 elevator_2] At floor 3
[D1 16:36:07 elevator_2] At floor 2
[D1 16:36:07 elevator_2] Stopped at floor 2
[D1 16:36:07 elevator_2] Opening doors
[D1 16:36:10 elevator_2] Opened doors
[D1 16:36:10 citizen_197] Left elevator_2, arrived at floor 2
[D1 16:36:22 elevator_2] Closing doors
[D1 16:36:25 elevator_2] Closed doors
[D1 16:36:35 elevator_2] At floor 1
[D1 16:36:45 elevator_2] At floor 0
[D1 16:36:45 elevator_2] Stopped at floor 0
[D1 16:36:45 elevator_2] Opening doors
[D1 16:36:48 elevator_2] Opened doors
[D1 16:36:48 citizen_155] Left elevator_2, arrived at floor 0
[D1 16:36:48 citizen_162] Left elevator_2, arrived at floor 0
[D1 16:36:48 citizen_157] Left elevator_2, arrived at floor 0
[D1 16:36:48 citizen_155] Left the building
[D1 16:36:48 citizen_162] Left the building
[D1 16:36:48 citizen_157] Left the building
[D1 16:37:00 elevator_2] Closing doors
[D1 16:37:03 elevator_2] Closed doors
[D1 16:37:03 elevator_2] Resting at floor 0
[D1 16:38:06 citizen_187] Time to go to floor 2 and stay there for 00:39:32
[D1 16:38:06 floor_5] citizen_187 entered the queue
[D1 16:38:06 floor_5] citizen_187 found an empty queue and will be served immediately
[D1 16:38:06 elevator_1] Summoned to floor 5 from floor 0
[D1 16:38:06 elevator_1] Sprung into motion, heading Up
[D1 16:38:06 elevator_2] Summoned to floor 5 from floor 0
[D1 16:38:06 elevator_2] Sprung into motion, heading Up
[D1 16:38:16 elevator_1] At floor 1
[D1 16:38:16 elevator_2] At floor 1
[D1 16:38:26 elevator_1] At floor 2
[D1 16:38:26 elevator_2] At floor 2
[D1 16:38:36 elevator_1] At floor 3
[D1 16:38:36 elevator_2] At floor 3
[D1 16:38:46 elevator_1] At floor 4
[D1 16:38:46 elevator_2] At floor 4
[D1 16:38:56 elevator_1] At floor 5
[D1 16:38:56 elevator_1] Stopped at floor 5
[D1 16:38:56 elevator_1] Opening doors
[D1 16:38:56 elevator_2] At floor 5
[D1 16:38:56 elevator_2] Stopped at floor 5
[D1 16:38:56 elevator_2] Opening doors
[D1 16:38:59 elevator_1] Opened doors
[D1 16:38:59 elevator_2] Opened doors
[D1 16:38:59 citizen_187] Entered elevator_1, going to floor 2
[D1 16:38:59 floor_5] citizen_187 is leaving the queue
[D1 16:38:59 floor_5] The queue is now empty
[D1 16:39:11 elevator_1] Closing doors
[D1 16:39:11 elevator_2] Closing doors
[D1 16:39:14 elevator_1] Closed doors
[D1 16:39:14 elevator_2] Closed doors
[D1 16:39:14 elevator_1] Changing direction to Down
[D1 16:39:14 elevator_2] Resting at floor 5
[D1 16:39:24 elevator_1] At floor 4
[D1 16:39:34 elevator_1] At floor 3
[D1 16:39:44 elevator_1] At floor 2
[D1 16:39:44 elevator_1] Stopped at floor 2
[D1 16:39:44 elevator_1] Opening doors
[D1 16:39:47 elevator_1] Opened doors
[D1 16:39:47 citizen_187] Left elevator_1, arrived at floor 2
[D1 16:39:54 citizen_175] Time to go to floor 5 and stay there for 00:30:13
[D1 16:39:54 floor_4] citizen_175 entered the queue
[D1 16:39:54 floor_4] citizen_175 found an empty queue and will be served immediately
[D1 16:39:54 elevator_2] Summoned to floor 4 from floor 5
[D1 16:39:54 elevator_2] Sprung into motion, heading Down
[D1 16:39:59 elevator_1] Closing doors
[D1 16:40:02 elevator_1] Closed doors
[D1 16:40:02 elevator_1] Resting at floor 2
[D1 16:40:04 elevator_2] At floor 4
[D1 16:40:04 elevator_2] Stopped at floor 4
[D1 16:40:04 elevator_2] Opening doors
[D1 16:40:07 elevator_2] Opened doors
[D1 16:40:07 citizen_175] Entered elevator_2, going to floor 5
[D1 16:40:07 floor_4] citizen_175 is leaving the queue
[D1 16:40:07 floor_4] The queue is now empty
[D1 16:40:19 elevator_2] Closing doors
[D1 16:40:22 elevator_2] Closed doors
[D1 16:40:22 elevator_2] Changing direction to Up
[D1 16:40:32 elevator_2] At floor 5
[D1 16:40:32 elevator_2] Stopped at floor 5
[D1 16:40:32 elevator_2] Opening doors
[D1 16:40:35 elevator_2] Opened doors
[D1 16:40:35 citizen_175] Left elevator_2, arrived at floor 5
[D1 16:40:47 elevator_2] Closing doors
[D1 16:40:48 citizen_177] Time to go to the ground floor and leave
[D1 16:40:48 floor_5] citizen_177 entered the queue
[D1 16:40:48 floor_5] citizen_177 found an empty queue and will be served immediately
[D1 16:40:48 elevator_2] Summoned to floor 5 from floor 5
[D1 16:40:50 elevator_2] Reopening doors
[D1 16:40:50 citizen_177] Entered elevator_2, going to floor 0
[D1 16:40:50 floor_5] citizen_177 is leaving the queue
[D1 16:40:50 floor_5] The queue is now empty
[D1 16:41:02 elevator_2] Closing doors
[D1 16:41:05 elevator_2] Closed doors
[D1 16:41:05 elevator_2] Changing direction to Down
[D1 16:41:15 elevator_2] At floor 4
[D1 16:41:25 elevator_2] At floor 3
[D1 16:41:35 elevator_2] At floor 2
[D1 16:41:45 elevator_2] At floor 1
[D1 16:41:55 elevator_2] At floor 0
[D1 16:41:55 elevator_2] Stopped at floor 0
[D1 16:41:55 elevator_2] Opening doors
[D1 16:41:58 elevator_2] Opened doors
[D1 16:41:58 citizen_177] Left elevator_2, arrived at floor 0
[D1 16:41:58 citizen_177] Left the building
[D1 16:42:02 citizen_188] Time to go to floor 1 and stay there for 00:28:17
[D1 16:42:02 floor_4] citizen_188 entered the queue
[D1 16:42:02 floor_4] citizen_188 found an empty queue and will be served immediately
[D1 16:42:02 elevator_1] Summoned to floor 4 from floor 2
[D1 16:42:02 elevator_1] Sprung into motion, heading Up
[D1 16:42:10 elevator_2] Closing doors
[D1 16:42:12 elevator_1] At floor 3
[D1 16:42:13 elevator_2] Closed doors
[D1 16:42:13 elevator_2] Resting at floor 0
[D1 16:42:19 citizen_199] Time to go to floor 1 and stay there for 00:39:48
[D1 16:42:19 floor_4] citizen_199 entered the queue
[D1 16:42:19 floor_4] citizen_199 is queued along with 0 other arrivals in front of it
[D1 16:42:22 elevator_1] At floor 4
[D1 16:42:22 elevator_1] Stopped at floor 4
[D1 16:42:22 elevator_1] Opening doors
[D1 16:42:25 elevator_1] Opened doors
[D1 16:42:25 citizen_188] Entered elevator_1, going to floor 1
[D1 16:42:25 floor_4] citizen_188 is leaving the queue
[D1 16:42:25 floor_4] citizen_199 was served
[D1 16:42:25 elevator_1] Summoned to floor 4 from floor 4
[D1 16:42:25 citizen_199] Entered elevator_1, going to floor 1
[D1 16:42:25 floor_4] citizen_199 is leaving the queue
[D1 16:42:25 floor_4] The queue is now empty
[D1 16:42:37 elevator_1] Closing doors
[D1 16:42:40 elevator_1] Closed doors
[D1 16:42:40 elevator_1] Changing direction to Down
[D1 16:42:50 elevator_1] At floor 3
[D1 16:43:00 elevator_1] At floor 2
[D1 16:43:07 citizen_169] Time to go to floor 4 and stay there for 00:37:04
[D1 16:43:07 floor_1] citizen_169 entered the queue
[D1 16:43:07 floor_1] citizen_169 found an empty queue and will be served immediately
[D1 16:43:07 elevator_1] Summoned to floor 1 from floor 2
[D1 16:43:07 elevator_2] Summoned to floor 1 from floor 0
[D1 16:43:07 elevator_2] Sprung into motion, heading Up
[D1 16:43:10 elevator_1] At floor 1
[D1 16:43:10 elevator_1] Stopped at floor 1
[D1 16:43:10 elevator_1] Opening doors
[D1 16:43:11 citizen_181] Time to go to the ground floor and leave
[D1 16:43:11 floor_4] citizen_181 entered the queue
[D1 16:43:11 floor_4] citizen_181 found an empty queue and will be served immediately
[D1 16:43:11 elevator_1] Summoned to floor 4 from floor 1
[D1 16:43:13 elevator_1] Opened doors
[D1 16:43:13 citizen_188] Left elevator_1, arrived at floor 1
[D1 16:43:13 citizen_199] Left elevator_1, arrived at floor 1
[D1 16:43:13 citizen_169] Entered elevator_1, going to floor 4
[D1 16:43:13 floor_1] citizen_169 is leaving the queue
[D1 16:43:13 floor_1] The queue is now empty
[D1 16:43:17 elevator_2] At floor 1
[D1 16:43:17 elevator_2] Stopped at floor 1
[D1 16:43:17 elevator_2] Opening doors
[D1 16:43:20 elevator_2] Opened doors
[D1 16:43:25 elevator_1] Closing doors
[D1 16:43:28 elevator_1] Closed doors
[D1 16:43:28 elevator_1] Changing direction to Up
[D1 16:43:32 elevator_2] Closing doors
[D1 16:43:35 elevator_2] Closed doors
[D1 16:43:35 elevator_2] Resting at floor 1
[D1 16:43:38 elevator_1] At floor 2
[D1 16:43:48 elevator_1] At floor 3
[D1 16:43:58 elevator_1] At floor 4
[D1 16:43:58 elevator_1] Stopped at floor 4
[D1 16:43:58 elevator_1] Opening doors
[D1 16:44:01 elevator_1] Opened doors
[D1 16:44:01 citizen_169] Left elevator_1, arrived at floor 4
[D1 16:44:01 citizen_181] Entered elevator_1, going to floor 0
[D1 16:44:01 floor_4] citizen_181 is leaving the queue
[D1 16:44:01 floor_4] The queue is now empty
[D1 16:44:13 elevator_1] Closing doors
[D1 16:44:16 elevator_1] Closed doors
[D1 16:44:16 elevator_1] Changing direction to Down
[D1 16:44:19 citizen_179] Time to go to floor 4 and stay there for 00:24:23
[D1 16:44:19 floor_3] citizen_179 entered the queue
[D1 16:44:19 floor_3] citizen_179 found an empty queue and will be served immediately
[D1 16:44:19 elevator_1] Summoned to floor 3 from floor 4
[D1 16:44:26 elevator_1] At floor 3
[D1 16:44:26 elevator_1] Stopped at floor 3
[D1 16:44:26 elevator_1] Opening doors
[D1 16:44:29 elevator_1] Opened doors
[D1 16:44:29 citizen_179] Entered elevator_1, going to floor 4
[D1 16:44:29 floor_3] citizen_179 is leaving the queue
[D1 16:44:29 floor_3] The queue is now empty
[D1 16:44:40 citizen_186] Time to go to floor 2 and stay there for 00:22:26
[D1 16:44:40 floor_4] citizen_186 entered the queue
[D1 16:44:40 floor_4] citizen_186 found an empty queue and will be served immediately
[D1 16:44:40 elevator_1] Summoned to floor 4 from floor 3
[D1 16:44:41 elevator_1] Closing doors
[D1 16:44:44 elevator_1] Closed doors
[D1 16:44:54 elevator_1] At floor 2
[D1 16:45:04 elevator_1] At floor 1
[D1 16:45:14 elevator_1] At floor 0
[D1 16:45:14 elevator_1] Stopped at floor 0
[D1 16:45:14 elevator_1] Opening doors
[D1 16:45:17 elevator_1] Opened doors
[D1 16:45:17 citizen_181] Left elevator_1, arrived at floor 0
[D1 16:45:17 citizen_181] Left the building
[D1 16:45:29 elevator_1] Closing doors
[D1 16:45:32 elevator_1] Closed doors
[D1 16:45:32 elevator_1] Changing direction to Up
[D1 16:45:42 elevator_1] At floor 1
[D1 16:45:52 elevator_1] At floor 2
[D1 16:46:02 elevator_1] At floor 3
[D1 16:46:12 elevator_1] At floor 4
[D1 16:46:12 elevator_1] Stopped at floor 4
[D1 16:46:12 elevator_1] Opening doors
[D1 16:46:15 elevator_1] Opened doors
[D1 16:46:15 citizen_179] Left elevator_1, arrived at floor 4
[D1 16:46:15 citizen_186] Entered elevator_1, going to floor 2
[D1 16:46:15 floor_4] citizen_186 is leaving the queue
[D1 16:46:15 floor_4] The queue is now empty
[D1 16:46:27 elevator_1] Closing doors
[D1 16:46:30 elevator_1] Closed doors
[D1 16:46:30 elevator_1] Changing direction to Down
[D1 16:46:37 citizen_173] Time to go to floor 3 and stay there for 00:39:22
[D1 16:46:37 floor_2] citizen_173 entered the queue
[D1 16:46:37 floor_2] citizen_173 found an empty queue and will be served immediately
[D1 16:46:37 elevator_2] Summoned to floor 2 from floor 1
[D1 16:46:37 elevator_2] Sprung into motion, heading Up
[D1 16:46:40 elevator_1] At floor 3
[D1 16:46:47 elevator_2] At floor 2
[D1 16:46:47 elevator_2] Stopped at floor 2
[D1 16:46:47 elevator_2] Opening doors
[D1 16:46:50 elevator_1] At floor 2
[D1 16:46:50 elevator_1] Stopped at floor 2
[D1 16:46:50 elevator_1] Opening doors
[D1 16:46:50 elevator_2] Opened doors
[D1 16:46:50 citizen_173] Entered elevator_2, going to floor 3
[D1 16:46:50 floor_2] citizen_173 is leaving the queue
[D1 16:46:50 floor_2] The queue is now empty
[D1 16:46:53 elevator_1] Opened doors
[D1 16:46:53 citizen_186] Left elevator_1, arrived at floor 2
[D1 16:47:02 citizen_192] Time to go to floor 3 and stay there for 00:20:52
[D1 16:47:02 floor_2] citizen_192 entered the queue
[D1 16:47:02 floor_2] citizen_192 found an empty queue and will be served immediately
[D1 16:47:02 elevator_1] Summoned to floor 2 from floor 2
[D1 16:47:02 elevator_2] Summoned to floor 2 from floor 2
[D1 16:47:02 citizen_192] Entered elevator_1, going to floor 3
[D1 16:47:02 floor_2] citizen_192 is leaving the queue
[D1 16:47:02 floor_2] The queue is now empty
[D1 16:47:02 elevator_2] Closing doors
[D1 16:47:05 elevator_1] Closing doors
[D1 16:47:05 elevator_2] Closed doors
[D1 16:47:08 elevator_1] Closed doors
[D1 16:47:08 elevator_1] Changing direction to Up
[D1 16:47:15 elevator_2] At floor 3
[D1 16:47:15 elevator_2] Stopped at floor 3
[D1 16:47:15 elevator_2] Opening doors
[D1 16:47:18 elevator_1] At floor 3
[D1 16:47:18 elevator_1] Stopped at floor 3
[D1 16:47:18 elevator_1] Opening doors
[D1 16:47:18 elevator_2] Opened doors
[D1 16:47:18 citizen_173] Left elevator_2, arrived at floor 3
[D1 16:47:21 elevator_1] Opened doors
[D1 16:47:21 citizen_192] Left elevator_1, arrived at floor 3
[D1 16:47:30 elevator_2] Closing doors
[D1 16:47:33 elevator_1] Closing doors
[D1 16:47:33 elevator_2] Closed doors
[D1 16:47:33 elevator_2] Resting at floor 3
[D1 16:47:36 elevator_1] Closed doors
[D1 16:47:36 elevator_1] Resting at floor 3
[D1 16:48:22 citizen_174] Time to go to the ground floor and leave
[D1 16:48:22 floor_2] citizen_174 entered the queue
[D1 16:48:22 floor_2] citizen_174 found an empty queue and will be served immediately
[D1 16:48:22 elevator_1] Summoned to floor 2 from floor 3
[D1 16:48:22 elevator_1] Sprung into motion, heading Down
[D1 16:48:22 elevator_2] Summoned to floor 2 from floor 3
[D1 16:48:22 elevator_2] Sprung into motion, heading Down
[D1 16:48:32 elevator_1] At floor 2
[D1 16:48:32 elevator_1] Stopped at floor 2
[D1 16:48:32 elevator_1] Opening doors
[D1 16:48:32 elevator_2] At floor 2
[D1 16:48:32 elevator_2] Stopped at floor 2
[D1 16:48:32 elevator_2] Opening doors
[D1 16:48:35 elevator_1] Opened doors
[D1 16:48:35 elevator_2] Opened doors
[D1 16:48:35 citizen_174] Entered elevator_1, going to floor 0
[D1 16:48:35 floor_2] citizen_174 is leaving the queue
[D1 16:48:35 floor_2] The queue is now empty
[D1 16:48:38 citizen_178] Time to go to the ground floor and leave
[D1 16:48:38 floor_4] citizen_178 entered the queue
[D1 16:48:38 floor_4] citizen_178 found an empty queue and will be served immediately
[D1 16:48:38 elevator_1] Summoned to floor 4 from floor 2
[D1 16:48:38 elevator_2] Summoned to floor 4 from floor 2
[D1 16:48:47 elevator_1] Closing doors
[D1 16:48:47 elevator_2] Closing doors
[D1 16:48:50 elevator_1] Closed doors
[D1 16:48:50 elevator_2] Closed doors
[D1 16:48:50 elevator_2] Changing direction to Up
[D1 16:49:00 elevator_1] At floor 1
[D1 16:49:00 elevator_2] At floor 3
[D1 16:49:10 elevator_1] At floor 0
[D1 16:49:10 elevator_1] Stopped at floor 0
[D1 16:49:10 elevator_1] Opening doors
[D1 16:49:10 elevator_2] At floor 4
[D1 16:49:10 elevator_2] Stopped at floor 4
[D1 16:49:10 elevator_2] Opening doors
[D1 16:49:13 elevator_1] Opened doors
[D1 16:49:13 elevator_2] Opened doors
[D1 16:49:13 citizen_174] Left elevator_1, arrived at floor 0
[D1 16:49:13 citizen_174] Left the building
[D1 16:49:13 citizen_178] Entered elevator_2, going to floor 0
[D1 16:49:13 floor_4] citizen_178 is leaving the queue
[D1 16:49:13 floor_4] The queue is now empty
[D1 16:49:25 elevator_2] Closing doors
[D1 16:49:25 elevator_1] Closing doors
[D1 16:49:28 elevator_2] Closed doors
[D1 16:49:28 elevator_1] Closed doors
[D1 16:49:28 elevator_2] Changing direction to Down
[D1 16:49:28 elevator_1] Changing direction to Up
[D1 16:49:38 elevator_2] At floor 3
[D1 16:49:38 elevator_1] At floor 1
[D1 16:49:48 elevator_2] At floor 2
[D1 16:49:48 elevator_1] At floor 2
[D1 16:49:50 citizen_200] Time to go to floor 3 and stay there for 00:44:44
[D1 16:49:50 floor_4] citizen_200 entered the queue
[D1 16:49:50 floor_4] citizen_200 found an empty queue and will be served immediately
[D1 16:49:50 elevator_1] Summoned to floor 4 from floor 2
[D1 16:49:50 elevator_2] Summoned to floor 4 from floor 2
[D1 16:49:58 elevator_2] At floor 1
[D1 16:49:58 elevator_1] At floor 3
[D1 16:50:08 elevator_2] At floor 0
[D1 16:50:08 elevator_2] Stopped at floor 0
[D1 16:50:08 elevator_2] Opening doors
[D1 16:50:08 elevator_1] At floor 4
[D1 16:50:08 elevator_1] Stopped at floor 4
[D1 16:50:08 elevator_1] Opening doors
[D1 16:50:11 elevator_2] Opened doors
[D1 16:50:11 elevator_1] Opened doors
[D1 16:50:11 citizen_178] Left elevator_2, arrived at floor 0
[D1 16:50:11 citizen_178] Left the building
[D1 16:50:11 citizen_200] Entered elevator_1, going to floor 3
[D1 16:50:11 floor_4] citizen_200 is leaving the queue
[D1 16:50:11 floor_4] The queue is now empty
[D1 16:50:23 elevator_1] Closing doors
[D1 16:50:23 elevator_2] Closing doors
[D1 16:50:26 elevator_1] Closed doors
[D1 16:50:26 elevator_2] Closed doors
[D1 16:50:26 elevator_1] Changing direction to Down
[D1 16:50:26 elevator_2] Changing direction to Up
[D1 16:50:36 elevator_1] At floor 3
[D1 16:50:36 elevator_1] Stopped at floor 3
[D1 16:50:36 elevator_1] Opening doors
[D1 16:50:36 elevator_2] At floor 1
[D1 16:50:39 elevator_1] Opened doors
[D1 16:50:39 citizen_200] Left elevator_1, arrived at floor 3
[D1 16:50:46 elevator_2] At floor 2
[D1 16:50:51 elevator_1] Closing doors
[D1 16:50:54 elevator_1] Closed doors
[D1 16:50:54 elevator_1] Resting at floor 3
[D1 16:50:55 citizen_159] Time to go to the ground floor and leave
[D1 16:50:55 floor_2] citizen_159 entered the queue
[D1 16:50:55 floor_2] citizen_159 found an empty queue and will be served immediately
[D1 16:50:55 elevator_2] Summoned to floor 2 from floor 2
[D1 16:50:56 elevator_2] At floor 3
[D1 16:51:00 citizen_149] Time to go to the ground floor and leave
[D1 16:51:00 floor_4] citizen_149 entered the queue
[D1 16:51:00 floor_4] citizen_149 found an empty queue and will be served immediately
[D1 16:51:00 elevator_1] Summoned to floor 4 from floor 3
[D1 16:51:00 elevator_1] Sprung into motion, heading Up
[D1 16:51:00 elevator_2] Summoned to floor 4 from floor 3
[D1 16:51:06 elevator_2] At floor 4
[D1 16:51:06 elevator_2] Stopped at floor 4
[D1 16:51:06 elevator_2] Opening doors
[D1 16:51:09 elevator_2] Opened doors
[D1 16:51:09 citizen_149] Entered elevator_2, going to floor 0
[D1 16:51:09 floor_4] citizen_149 is leaving the queue
[D1 16:51:09 floor_4] The queue is now empty
[D1 16:51:10 elevator_1] At floor 4
[D1 16:51:10 elevator_1] Stopped at floor 4
[D1 16:51:10 elevator_1] Opening doors
[D1 16:51:13 elevator_1] Opened doors
[D1 16:51:21 elevator_2] Closing doors
[D1 16:51:24 elevator_2] Closed doors
[D1 16:51:24 elevator_2] Changing direction to Down
[D1 16:51:25 elevator_1] Closing doors
[D1 16:51:28 elevator_1] Closed doors
[D1 16:51:28 elevator_1] Resting at floor 4
[D1 16:51:34 elevator_2] At floor 3
[D1 16:51:44 elevator_2] At floor 2
[D1 16:51:44 elevator_2] Stopped at floor 2
[D1 16:51:44 elevator_2] Opening doors
[D1 16:51:47 elevator_2] Opened doors
[D1 16:51:47 citizen_159] Entered elevator_2, going to floor 0
[D1 16:51:47 floor_2] citizen_159 is leaving the queue
[D1 16:51:47 floor_2] The queue is now empty
[D1 16:51:59 elevator_2] Closing doors
[D1 16:52:00 citizen_190] Time to go to the ground floor and leave
[D1 16:52:00 floor_1] citizen_190 entered the queue
[D1 16:52:00 floor_1] citizen_190 found an empty queue and will be served immediately
[D1 16:52:00 elevator_2] Summoned to floor 1 from floor 2
[D1 16:52:02 elevator_2] Closed doors
[D1 16:52:12 elevator_2] At floor 1
[D1 16:52:12 elevator_2] Stopped at floor 1
[D1 16:52:12 elevator_2] Opening doors
[D1 16:52:15 elevator_2] Opened doors
[D1 16:52:15 citizen_190] Entered elevator_2, going to floor 0
[D1 16:52:15 floor_1] citizen_190 is leaving the queue
[D1 16:52:15 floor_1] The queue is now empty
[D1 16:52:27 elevator_2] Closing doors
[D1 16:52:30 elevator_2] Closed doors
[D1 16:52:40 elevator_2] At floor 0
[D1 16:52:40 elevator_2] Stopped at floor 0
[D1 16:52:40 elevator_2] Opening doors
[D1 16:52:42 citizen_184] Time to go to floor 4 and stay there for 00:38:34
[D1 16:52:42 floor_5] citizen_184 entered the queue
[D1 16:52:42 floor_5] citizen_184 found an empty queue and will be served immediately
[D1 16:52:42 elevator_1] Summoned to floor 5 from floor 4
[D1 16:52:42 elevator_1] Sprung into motion, heading Up
[D1 16:52:43 elevator_2] Opened doors
[D1 16:52:43 citizen_149] Left elevator_2, arrived at floor 0
[D1 16:52:43 citizen_159] Left elevator_2, arrived at floor 0
[D1 16:52:43 citizen_190] Left elevator_2, arrived at floor 0
[D1 16:52:43 citizen_149] Left the building
[D1 16:52:43 citizen_159] Left the building
[D1 16:52:43 citizen_190] Left the building
[D1 16:52:52 elevator_1] At floor 5
[D1 16:52:52 elevator_1] Stopped at floor 5
[D1 16:52:52 elevator_1] Opening doors
[D1 16:52:55 elevator_2] Closing doors
[D1 16:52:55 elevator_1] Opened doors
[D1 16:52:55 citizen_184] Entered elevator_1, going to floor 4
[D1 16:52:55 floor_5] citizen_184 is leaving the queue
[D1 16:52:55 floor_5] The queue is now empty
[D1 16:52:58 elevator_2] Closed doors
[D1 16:52:58 elevator_2] Resting at floor 0
[D1 16:53:07 elevator_1] Closing doors
[D1 16:53:10 elevator_1] Closed doors
[D1 16:53:10 elevator_1] Changing direction to Down
[D1 16:53:20 elevator_1] At floor 4
[D1 16:53:20 elevator_1] Stopped at floor 4
[D1 16:53:20 elevator_1] Opening doors
[D1 16:53:23 elevator_1] Opened doors
[D1 16:53:23 citizen_184] Left elevator_1, arrived at floor 4
[D1 16:53:35 elevator_1] Closing doors
[D1 16:53:38 elevator_1] Closed doors
[D1 16:53:38 elevator_1] Resting at floor 4
[D1 16:53:45 citizen_152] Time to go to the ground floor and leave
[D1 16:53:45 floor_5] citizen_152 entered the queue
[D1 16:53:45 floor_5] citizen_152 found an empty queue and will be served immediately
[D1 16:53:45 elevator_1] Summoned to floor 5 from floor 4
[D1 16:53:45 elevator_1] Sprung into motion, heading Up
[D1 16:53:55 elevator_1] At floor 5
[D1 16:53:55 elevator_1] Stopped at floor 5
[D1 16:53:55 elevator_1] Opening doors
[D1 16:53:58 elevator_1] Opened doors
[D1 16:53:58 citizen_152] Entered elevator_1, going to floor 0
[D1 16:53:58 floor_5] citizen_152 is leaving the queue
[D1 16:53:58 floor_5] The queue is now empty
[D1 16:54:10 elevator_1] Closing doors
[D1 16:54:13 elevator_1] Closed doors
[D1 16:54:13 elevator_1] Changing direction to Down
[D1 16:54:23 elevator_1] At floor 4
[D1 16:54:26 citizen_171] Time to go to floor 3 and stay there for 00:31:00
[D1 16:54:26 floor_1] citizen_171 entered the queue
[D1 16:54:26 floor_1] citizen_171 found an empty queue and will be served immediately
[D1 16:54:26 elevator_2] Summoned to floor 1 from floor 0
[D1 16:54:26 elevator_2] Sprung into motion, heading Up
[D1 16:54:33 elevator_1] At floor 3
[D1 16:54:36 elevator_2] At floor 1
[D1 16:54:36 elevator_2] Stopped at floor 1
[D1 16:54:36 elevator_2] Opening doors
[D1 16:54:39 elevator_2] Opened doors
[D1 16:54:39 citizen_171] Entered elevator_2, going to floor 3
[D1 16:54:39 floor_1] citizen_171 is leaving the queue
[D1 16:54:39 floor_1] The queue is now empty
[D1 16:54:43 elevator_1] At floor 2
[D1 16:54:51 elevator_2] Closing doors
[D1 16:54:53 elevator_1] At floor 1
[D1 16:54:54 citizen_180] Time to go to floor 5 and stay there for 00:33:03
[D1 16:54:54 floor_2] citizen_180 entered the queue
[D1 16:54:54 floor_2] citizen_180 found an empty queue and will be served immediately
[D1 16:54:54 elevator_1] Summoned to floor 2 from floor 1
[D1 16:54:54 elevator_2] Summoned to floor 2 from floor 1
[D1 16:54:54 elevator_2] Closed doors
[D1 16:55:02 citizen_183] Time to go to the ground floor and leave
[D1 16:55:02 floor_3] citizen_183 entered the queue
[D1 16:55:02 floor_3] citizen_183 found an empty queue and will be served immediately
[D1 16:55:02 elevator_1] Summoned to floor 3 from floor 1
[D1 16:55:02 elevator_2] Summoned to floor 3 from floor 1
[D1 16:55:03 elevator_1] At floor 0
[D1 16:55:03 elevator_1] Stopped at floor 0
[D1 16:55:03 elevator_1] Opening doors
[D1 16:55:04 elevator_2] At floor 2
[D1 16:55:04 elevator_2] Stopped at floor 2
[D1 16:55:04 elevator_2] Opening doors
[D1 16:55:06 elevator_1] Opened doors
[D1 16:55:06 citizen_152] Left elevator_1, arrived at floor 0
[D1 16:55:06 citizen_152] Left the building
[D1 16:55:07 elevator_2] Opened doors
[D1 16:55:07 citizen_180] Entered elevator_2, going to floor 5
[D1 16:55:07 floor_2] citizen_180 is leaving the queue
[D1 16:55:07 floor_2] The queue is now empty
[D1 16:55:18 elevator_1] Closing doors
[D1 16:55:19 elevator_2] Closing doors
[D1 16:55:21 elevator_1] Closed doors
[D1 16:55:21 elevator_1] Changing direction to Up
[D1 16:55:22 elevator_2] Closed doors
[D1 16:55:31 elevator_1] At floor 1
[D1 16:55:32 elevator_2] At floor 3
[D1 16:55:32 elevator_2] Stopped at floor 3
[D1 16:55:32 elevator_2] Opening doors
[D1 16:55:35 elevator_2] Opened doors
[D1 16:55:35 citizen_171] Left elevator_2, arrived at floor 3
[D1 16:55:35 citizen_183] Entered elevator_2, going to floor 0
[D1 16:55:35 floor_3] citizen_183 is leaving the queue
[D1 16:55:35 floor_3] The queue is now empty
[D1 16:55:41 elevator_1] At floor 2
[D1 16:55:41 elevator_1] Stopped at floor 2
[D1 16:55:41 elevator_1] Opening doors
[D1 16:55:44 elevator_1] Opened doors
[D1 16:55:47 elevator_2] Closing doors
[D1 16:55:50 elevator_2] Closed doors
[D1 16:55:56 elevator_1] Closing doors
[D1 16:55:59 elevator_1] Closed doors
[D1 16:56:00 elevator_2] At floor 4
[D1 16:56:09 elevator_1] At floor 3
[D1 16:56:09 elevator_1] Stopped at floor 3
[D1 16:56:09 elevator_1] Opening doors
[D1 16:56:10 elevator_2] At floor 5
[D1 16:56:10 elevator_2] Stopped at floor 5
[D1 16:56:10 elevator_2] Opening doors
[D1 16:56:12 elevator_1] Opened doors
[D1 16:56:13 elevator_2] Opened doors
[D1 16:56:13 citizen_180] Left elevator_2, arrived at floor 5
[D1 16:56:16 citizen_198] Time to go to floor 2 and stay there for 00:23:23
[D1 16:56:16 floor_3] citizen_198 entered the queue
[D1 16:56:16 floor_3] citizen_198 found an empty queue and will be served immediately
[D1 16:56:16 elevator_1] Summoned to floor 3 from floor 3
[D1 16:56:16 citizen_198] Entered elevator_1, going to floor 2
[D1 16:56:16 floor_3] citizen_198 is leaving the queue
[D1 16:56:16 floor_3] The queue is now empty
[D1 16:56:24 elevator_1] Closing doors
[D1 16:56:25 elevator_2] Closing doors
[D1 16:56:27 elevator_1] Closed doors
[D1 16:56:27 elevator_1] Changing direction to Down
[D1 16:56:28 elevator_2] Closed doors
[D1 16:56:28 elevator_2] Changing direction to Down
[D1 16:56:37 elevator_1] At floor 2
[D1 16:56:37 elevator_1] Stopped at floor 2
[D1 16:56:37 elevator_1] Opening doors
[D1 16:56:38 elevator_2] At floor 4
[D1 16:56:40 elevator_1] Opened doors
[D1 16:56:40 citizen_198] Left elevator_1, arrived at floor 2
[D1 16:56:43 citizen_191] Time to go to floor 1 and stay there for 00:32:24
[D1 16:56:43 floor_4] citizen_191 entered the queue
[D1 16:56:43 floor_4] citizen_191 found an empty queue and will be served immediately
[D1 16:56:43 elevator_2] Summoned to floor 4 from floor 4
[D1 16:56:48 elevator_2] At floor 3
[D1 16:56:52 elevator_1] Closing doors
[D1 16:56:55 elevator_1] Closed doors
[D1 16:56:55 elevator_1] Resting at floor 2
[D1 16:56:58 elevator_2] At floor 2
[D1 16:57:08 elevator_2] At floor 1
[D1 16:57:18 elevator_2] At floor 0
[D1 16:57:18 elevator_2] Stopped at floor 0
[D1 16:57:18 elevator_2] Opening doors
[D1 16:57:21 elevator_2] Opened doors
[D1 16:57:21 citizen_183] Left elevator_2, arrived at floor 0
[D1 16:57:21 citizen_183] Left the building
[D1 16:57:33 elevator_2] Closing doors
[D1 16:57:36 elevator_2] Closed doors
[D1 16:57:36 elevator_2] Changing direction to Up
[D1 16:57:46 elevator_2] At floor 1
[D1 16:57:56 elevator_2] At floor 2
[D1 16:58:06 elevator_2] At floor 3
[D1 16:58:16 elevator_2] At floor 4
[D1 16:58:16 elevator_2] Stopped at floor 4
[D1 16:58:16 elevator_2] Opening doors
[D1 16:58:19 elevator_2] Opened doors
[D1 16:58:19 citizen_191] Entered elevator_2, going to floor 1
[D1 16:58:19 floor_4] citizen_191 is leaving the queue
[D1 16:58:19 floor_4] The queue is now empty
[D1 16:58:31 elevator_2] Closing doors
[D1 16:58:34 elevator_2] Closed doors
[D1 16:58:34 elevator_2] Changing direction to Down
[D1 16:58:44 elevator_2] At floor 3
[D1 16:58:54 elevator_2] At floor 2
[D1 16:59:04 elevator_2] At floor 1
[D1 16:59:04 elevator_2] Stopped at floor 1
[D1 16:59:04 elevator_2] Opening doors
[D1 16:59:07 elevator_2] Opened doors
[D1 16:59:07 citizen_191] Left elevator_2, arrived at floor 1
[D1 16:59:19 elevator_2] Closing doors
[D1 16:59:22 elevator_2] Closed doors
[D1 16:59:22 elevator_2] Resting at floor 1
[D1 16:59:47 citizen_182] Time to go to floor 3 and stay there for 00:33:22
[D1 16:59:47 floor_1] citizen_182 entered the queue
[D1 16:59:47 floor_1] citizen_182 found an empty queue and will be served immediately
[D1 16:59:47 elevator_2] Summoned to floor 1 from floor 1
[D1 16:59:47 elevator_2] Opening doors
[D1 16:59:50 elevator_2] Opened doors
[D1 16:59:50 citizen_182] Entered elevator_2, going to floor 3
[D1 16:59:50 floor_1] citizen_182 is leaving the queue
[D1 16:59:50 floor_1] The queue is now empty
[D1 17:00:02 elevator_2] Closing doors
[D1 17:00:05 elevator_2] Closed doors
[D1 17:00:05 elevator_2] Sprung into motion, heading Up
[D1 17:00:15 elevator_2] At floor 2
[D1 17:00:19 citizen_193] Time to go to floor 4 and stay there for 00:36:14
[D1 17:00:19 floor_2] citizen_193 entered the queue
[D1 17:00:19 floor_2] citizen_193 found an empty queue and will be served immediately
[D1 17:00:19 elevator_1] Summoned to floor 2 from floor 2
[D1 17:00:19 elevator_1] Opening doors
[D1 17:00:19 elevator_2] Summoned to floor 2 from floor 2
[D1 17:00:22 elevator_1] Opened doors
[D1 17:00:22 citizen_193] Entered elevator_1, going to floor 4
[D1 17:00:22 floor_2] citizen_193 is leaving the queue
[D1 17:00:22 floor_2] The queue is now empty
[D1 17:00:25 elevator_2] At floor 3
[D1 17:00:25 elevator_2] Stopped at floor 3
[D1 17:00:25 elevator_2] Opening doors
[D1 17:00:28 elevator_2] Opened doors
[D1 17:00:28 citizen_182] Left elevator_2, arrived at floor 3
[D1 17:00:34 elevator_1] Closing doors
[D1 17:00:37 elevator_1] Closed doors
[D1 17:00:37 elevator_1] Sprung into motion, heading Up
[D1 17:00:38 citizen_189] Time to go to floor 2 and stay there for 00:25:54
[D1 17:00:38 floor_5] citizen_189 entered the queue
[D1 17:00:38 floor_5] citizen_189 found an empty queue and will be served immediately
[D1 17:00:38 elevator_2] Summoned to floor 5 from floor 3
[D1 17:00:40 elevator_2] Closing doors
[D1 17:00:43 elevator_2] Closed doors
[D1 17:00:47 elevator_1] At floor 3
[D1 17:00:53 elevator_2] At floor 4
[D1 17:00:57 elevator_1] At floor 4
[D1 17:00:57 elevator_1] Stopped at floor 4
[D1 17:00:57 elevator_1] Opening doors
[D1 17:01:00 elevator_1] Opened doors
[D1 17:01:00 citizen_193] Left elevator_1, arrived at floor 4
[D1 17:01:03 elevator_2] At floor 5
[D1 17:01:03 elevator_2] Stopped at floor 5
[D1 17:01:03 elevator_2] Opening doors
[D1 17:01:06 elevator_2] Opened doors
[D1 17:01:06 citizen_189] Entered elevator_2, going to floor 2
[D1 17:01:06 floor_5] citizen_189 is leaving the queue
[D1 17:01:06 floor_5] The queue is now empty
[D1 17:01:12 elevator_1] Closing doors
[D1 17:01:15 elevator_1] Closed doors
[D1 17:01:15 elevator_1] Resting at floor 4
[D1 17:01:18 elevator_2] Closing doors
[D1 17:01:21 elevator_2] Closed doors
[D1 17:01:21 elevator_2] Changing direction to Down
[D1 17:01:31 elevator_2] At floor 4
[D1 17:01:35 citizen_196] Time to go to the ground floor and leave
[D1 17:01:35 floor_1] citizen_196 entered the queue
[D1 17:01:35 floor_1] citizen_196 found an empty queue and will be served immediately
[D1 17:01:35 elevator_1] Summoned to floor 1 from floor 4
[D1 17:01:35 elevator_1] Sprung into motion, heading Down
[D1 17:01:35 elevator_2] Summoned to floor 1 from floor 4
[D1 17:01:41 elevator_2] At floor 3
[D1 17:01:45 elevator_1] At floor 3
[D1 17:01:51 elevator_2] At floor 2
[D1 17:01:51 elevator_2] Stopped at floor 2
[D1 17:01:51 elevator_2] Opening doors
[D1 17:01:53 citizen_176] Time to go to the ground floor and leave
[D1 17:01:53 floor_5] citizen_176 entered the queue
[D1 17:01:53 floor_5] citizen_176 found an empty queue and will be served immediately
[D1 17:01:53 elevator_1] Summoned to floor 5 from floor 3
[D1 17:01:54 elevator_2] Opened doors
[D1 17:01:54 citizen_189] Left elevator_2, arrived at floor 2
[D1 17:01:55 elevator_1] At floor 2
[D1 17:02:05 elevator_1] At floor 1
[D1 17:02:05 elevator_1] Stopped at floor 1
[D1 17:02:05 elevator_1] Opening doors
[D1 17:02:06 elevator_2] Closing doors
[D1 17:02:08 elevator_1] Opened doors
[D1 17:02:08 citizen_196] Entered elevator_1, going to floor 0
[D1 17:02:08 floor_1] citizen_196 is leaving the queue
[D1 17:02:08 floor_1] The queue is now empty
[D1 17:02:09 elevator_2] Closed doors
[D1 17:02:19 elevator_2] At floor 1
[D1 17:02:19 elevator_2] Stopped at floor 1
[D1 17:02:19 elevator_2] Opening doors
[D1 17:02:20 elevator_1] Closing doors
[D1 17:02:22 elevator_2] Opened doors
[D1 17:02:23 elevator_1] Closed doors
[D1 17:02:33 elevator_1] At floor 0
[D1 17:02:33 elevator_1] Stopped at floor 0
[D1 17:02:33 elevator_1] Opening doors
[D1 17:02:34 elevator_2] Closing doors
[D1 17:02:36 elevator_1] Opened doors
[D1 17:02:36 citizen_196] Left elevator_1, arrived at floor 0
[D1 17:02:36 citizen_196] Left the building
[D1 17:02:37 elevator_2] Closed doors
[D1 17:02:37 elevator_2] Resting at floor 1
[D1 17:02:48 elevator_1] Closing doors
[D1 17:02:51 elevator_1] Closed doors
[D1 17:02:51 elevator_1] Changing direction to Up
[D1 17:03:01 elevator_1] At floor 1
[D1 17:03:11 elevator_1] At floor 2
[D1 17:03:21 elevator_1] At floor 3
[D1 17:03:31 elevator_1] At floor 4
[D1 17:03:41 elevator_1] At floor 5
[D1 17:03:41 elevator_1] Stopped at floor 5
[D1 17:03:41 elevator_1] Opening doors
[D1 17:03:44 elevator_1] Opened doors
[D1 17:03:44 citizen_176] Entered elevator_1, going to floor 0
[D1 17:03:44 floor_5] citizen_176 is leaving the queue
[D1 17:03:44 floor_5] The queue is now empty
[D1 17:03:56 elevator_1] Closing doors
[D1 17:03:59 elevator_1] Closed doors
[D1 17:03:59 elevator_1] Changing direction to Down
[D1 17:04:09 elevator_1] At floor 4
[D1 17:04:19 elevator_1] At floor 3
[D1 17:04:29 elevator_1] At floor 2
[D1 17:04:39 elevator_1] At floor 1
[D1 17:04:49 elevator_1] At floor 0
[D1 17:04:49 elevator_1] Stopped at floor 0
[D1 17:04:49 elevator_1] Opening doors
[D1 17:04:52 elevator_1] Opened doors
[D1 17:04:52 citizen_176] Left elevator_1, arrived at floor 0
[D1 17:04:52 citizen_176] Left the building
[D1 17:05:04 elevator_1] Closing doors
[D1 17:05:07 elevator_1] Closed doors
[D1 17:05:07 elevator_1] Resting at floor 0
[D1 17:07:07 citizen_195] Time to go to floor 5 and stay there for 00:34:25
[D1 17:07:07 floor_2] citizen_195 entered the queue
[D1 17:07:07 floor_2] citizen_195 found an empty queue and will be served immediately
[D1 17:07:07 elevator_2] Summoned to floor 2 from floor 1
[D1 17:07:07 elevator_2] Sprung into motion, heading Up
[D1 17:07:17 elevator_2] At floor 2
[D1 17:07:17 elevator_2] Stopped at floor 2
[D1 17:07:17 elevator_2] Opening doors
[D1 17:07:20 elevator_2] Opened doors
[D1 17:07:20 citizen_195] Entered elevator_2, going to floor 5
[D1 17:07:20 floor_2] citizen_195 is leaving the queue
[D1 17:07:20 floor_2] The queue is now empty
[D1 17:07:32 elevator_2] Closing doors
[D1 17:07:35 elevator_2] Closed doors
[D1 17:07:45 elevator_2] At floor 3
[D1 17:07:49 citizen_185] Time to go to floor 3 and stay there for 00:27:43
[D1 17:07:49 floor_4] citizen_185 entered the queue
[D1 17:07:49 floor_4] citizen_185 found an empty queue and will be served immediately
[D1 17:07:49 elevator_2] Summoned to floor 4 from floor 3
[D1 17:07:55 elevator_2] At floor 4
[D1 17:07:55 elevator_2] Stopped at floor 4
[D1 17:07:55 elevator_2] Opening doors
[D1 17:07:58 elevator_2] Opened doors
[D1 17:07:58 citizen_185] Entered elevator_2, going to floor 3
[D1 17:07:58 floor_4] citizen_185 is leaving the queue
[D1 17:07:58 floor_4] The queue is now empty
[D1 17:08:10 elevator_2] Closing doors
[D1 17:08:13 citizen_192] Time to go to the ground floor and leave
[D1 17:08:13 floor_3] citizen_192 entered the queue
[D1 17:08:13 floor_3] citizen_192 found an empty queue and will be served immediately
[D1 17:08:13 elevator_2] Summoned to floor 3 from floor 4
[D1 17:08:13 elevator_2] Closed doors
[D1 17:08:15 citizen_197] Time to go to floor 4 and stay there for 00:17:22
[D1 17:08:15 floor_2] citizen_197 entered the queue
[D1 17:08:15 floor_2] citizen_197 found an empty queue and will be served immediately
[D1 17:08:15 elevator_1] Summoned to floor 2 from floor 0
[D1 17:08:15 elevator_1] Sprung into motion, heading Up
[D1 17:08:15 elevator_2] Summoned to floor 2 from floor 4
[D1 17:08:23 elevator_2] At floor 5
[D1 17:08:23 elevator_2] Stopped at floor 5
[D1 17:08:23 elevator_2] Opening doors
[D1 17:08:25 elevator_1] At floor 1
[D1 17:08:26 elevator_2] Opened doors
[D1 17:08:26 citizen_195] Left elevator_2, arrived at floor 5
[D1 17:08:35 elevator_1] At floor 2
[D1 17:08:35 elevator_1] Stopped at floor 2
[D1 17:08:35 elevator_1] Opening doors
[D1 17:08:38 elevator_2] Closing doors
[D1 17:08:38 elevator_1] Opened doors
[D1 17:08:38 citizen_197] Entered elevator_1, going to floor 4
[D1 17:08:38 floor_2] citizen_197 is leaving the queue
[D1 17:08:38 floor_2] The queue is now empty
[D1 17:08:41 elevator_2] Closed doors
[D1 17:08:41 elevator_2] Changing direction to Down
[D1 17:08:50 elevator_1] Closing doors
[D1 17:08:51 elevator_2] At floor 4
[D1 17:08:53 elevator_1] Closed doors
[D1 17:09:01 elevator_2] At floor 3
[D1 17:09:01 elevator_2] Stopped at floor 3
[D1 17:09:01 elevator_2] Opening doors
[D1 17:09:03 elevator_1] At floor 3
[D1 17:09:04 elevator_2] Opened doors
[D1 17:09:04 citizen_185] Left elevator_2, arrived at floor 3
[D1 17:09:04 citizen_192] Entered elevator_2, going to floor 0
[D1 17:09:04 floor_3] citizen_192 is leaving the queue
[D1 17:09:04 floor_3] The queue is now empty
[D1 17:09:13 elevator_1] At floor 4
[D1 17:09:13 elevator_1] Stopped at floor 4
[D1 17:09:13 elevator_1] Opening doors
[D1 17:09:16 elevator_2] Closing doors
[D1 17:09:16 elevator_1] Opened doors
[D1 17:09:16 citizen_197] Left elevator_1, arrived at floor 4
[D1 17:09:19 citizen_186] Time to go to floor 1 and stay there for 00:34:53
[D1 17:09:19 floor_2] citizen_186 entered the queue
[D1 17:09:19 floor_2] citizen_186 found an empty queue and will be served immediately
[D1 17:09:19 elevator_2] Summoned to floor 2 from floor 3
[D1 17:09:19 elevator_2] Closed doors
[D1 17:09:28 elevator_1] Closing doors
[D1 17:09:29 elevator_2] At floor 2
[D1 17:09:29 elevator_2] Stopped at floor 2
[D1 17:09:29 elevator_2] Opening doors
[D1 17:09:31 elevator_1] Closed doors
[D1 17:09:31 elevator_1] Resting at floor 4
[D1 17:09:32 elevator_2] Opened doors
[D1 17:09:32 citizen_186] Entered elevator_2, going to floor 1
[D1 17:09:32 floor_2] citizen_186 is leaving the queue
[D1 17:09:32 floor_2] The queue is now empty
[D1 17:09:44 elevator_2] Closing doors
[D1 17:09:47 elevator_2] Closed doors
[D1 17:09:57 elevator_2] At floor 1
[D1 17:09:57 elevator_2] Stopped at floor 1
[D1 17:09:57 elevator_2] Opening doors
[D1 17:10:00 elevator_2] Opened doors
[D1 17:10:00 citizen_186] Left elevator_2, arrived at floor 1
[D1 17:10:12 elevator_2] Closing doors
[D1 17:10:15 elevator_2] Closed doors
[D1 17:10:25 elevator_2] At floor 0
[D1 17:10:25 elevator_2] Stopped at floor 0
[D1 17:10:25 elevator_2] Opening doors
[D1 17:10:28 elevator_2] Opened doors
[D1 17:10:28 citizen_192] Left elevator_2, arrived at floor 0
[D1 17:10:28 citizen_192] Left the building
[D1 17:10:38 citizen_179] Time to go to the ground floor and leave
[D1 17:10:38 floor_4] citizen_179 entered the queue
[D1 17:10:38 floor_4] citizen_179 found an empty queue and will be served immediately
[D1 17:10:38 elevator_1] Summoned to floor 4 from floor 4
[D1 17:10:38 elevator_1] Opening doors
[D1 17:10:40 elevator_2] Closing doors
[D1 17:10:41 elevator_1] Opened doors
[D1 17:10:41 citizen_179] Entered elevator_1, going to floor 0
[D1 17:10:41 floor_4] citizen_179 is leaving the queue
[D1 17:10:41 floor_4] The queue is now empty
[D1 17:10:43 elevator_2] Closed doors
[D1 17:10:43 elevator_2] Resting at floor 0
[D1 17:10:48 citizen_175] Time to go to the ground floor and leave
[D1 17:10:48 floor_5] citizen_175 entered the queue
[D1 17:10:48 floor_5] citizen_175 found an empty queue and will be served immediately
[D1 17:10:48 elevator_1] Summoned to floor 5 from floor 4
[D1 17:10:53 elevator_1] Closing doors
[D1 17:10:56 elevator_1] Closed doors
[D1 17:10:56 elevator_1] Sprung into motion, heading Down
[D1 17:11:06 elevator_1] At floor 3
[D1 17:11:16 elevator_1] At floor 2
[D1 17:11:26 elevator_1] At floor 1
[D1 17:11:30 citizen_188] Time to go to the ground floor and leave
[D1 17:11:30 floor_1] citizen_188 entered the queue
[D1 17:11:30 floor_1] citizen_188 found an empty queue and will be served immediately
[D1 17:11:30 elevator_1] Summoned to floor 1 from floor 1
[D1 17:11:36 elevator_1] At floor 0
[D1 17:11:36 elevator_1] Stopped at floor 0
[D1 17:11:36 elevator_1] Opening doors
[D1 17:11:39 elevator_1] Opened doors
[D1 17:11:39 citizen_179] Left elevator_1, arrived at floor 0
[D1 17:11:39 citizen_179] Left the building
[D1 17:11:51 elevator_1] Closing doors
[D1 17:11:54 elevator_1] Closed doors
[D1 17:11:54 elevator_1] Changing direction to Up
[D1 17:12:04 elevator_1] At floor 1
[D1 17:12:04 elevator_1] Stopped at floor 1
[D1 17:12:04 elevator_1] Opening doors
[D1 17:12:07 elevator_1] Opened doors
[D1 17:12:07 citizen_188] Entered elevator_1, going to floor 0
[D1 17:12:07 floor_1] citizen_188 is leaving the queue
[D1 17:12:07 floor_1] The queue is now empty
[D1 17:12:19 elevator_1] Closing doors
[D1 17:12:22 elevator_1] Closed doors
[D1 17:12:32 elevator_1] At floor 2
[D1 17:12:42 elevator_1] At floor 3
[D1 17:12:52 elevator_1] At floor 4
[D1 17:13:02 elevator_1] At floor 5
[D1 17:13:02 elevator_1] Stopped at floor 5
[D1 17:13:02 elevator_1] Opening doors
[D1 17:13:05 elevator_1] Opened doors
[D1 17:13:05 citizen_175] Entered elevator_1, going to floor 0
[D1 17:13:05 floor_5] citizen_175 is leaving the queue
[D1 17:13:05 floor_5] The queue is now empty
[D1 17:13:17 elevator_1] Closing doors
[D1 17:13:20 elevator_1] Closed doors
[D1 17:13:20 elevator_1] Changing direction to Down
[D1 17:13:30 elevator_1] At floor 4
[D1 17:13:40 elevator_1] At floor 3
[D1 17:13:50 elevator_1] At floor 2
[D1 17:14:00 citizen_194] Time to go to floor 1 and stay there for 00:18:10
[D1 17:14:00 floor_4] citizen_194 entered the queue
[D1 17:14:00 floor_4] citizen_194 found an empty queue and will be served immediately
[D1 17:14:00 elevator_1] Summoned to floor 4 from floor 2
[D1 17:14:00 elevator_1] At floor 1
[D1 17:14:10 elevator_1] At floor 0
[D1 17:14:10 elevator_1] Stopped at floor 0
[D1 17:14:10 elevator_1] Opening doors
[D1 17:14:13 elevator_1] Opened doors
[D1 17:14:13 citizen_188] Left elevator_1, arrived at floor 0
[D1 17:14:13 citizen_175] Left elevator_1, arrived at floor 0
[D1 17:14:13 citizen_188] Left the building
[D1 17:14:13 citizen_175] Left the building
[D1 17:14:25 elevator_1] Closing doors
[D1 17:14:28 elevator_1] Closed doors
[D1 17:14:28 elevator_1] Changing direction to Up
[D1 17:14:38 elevator_1] At floor 1
[D1 17:14:48 elevator_1] At floor 2
[D1 17:14:58 elevator_1] At floor 3
[D1 17:15:08 elevator_1] At floor 4
[D1 17:15:08 elevator_1] Stopped at floor 4
[D1 17:15:08 elevator_1] Opening doors
[D1 17:15:11 elevator_1] Opened doors
[D1 17:15:11 citizen_194] Entered elevator_1, going to floor 1
[D1 17:15:11 floor_4] citizen_194 is leaving the queue
[D1 17:15:11 floor_4] The queue is now empty
[D1 17:15:23 elevator_1] Closing doors
[D1 17:15:26 elevator_1] Closed doors
[D1 17:15:26 elevator_1] Changing direction to Down
[D1 17:15:36 elevator_1] At floor 3
[D1 17:15:46 elevator_1] At floor 2
[D1 17:15:56 elevator_1] At floor 1
[D1 17:15:56 elevator_1] Stopped at floor 1
[D1 17:15:56 elevator_1] Opening doors
[D1 17:15:59 elevator_1] Opened doors
[D1 17:15:59 citizen_194] Left elevator_1, arrived at floor 1
[D1 17:16:11 elevator_1] Closing doors
[D1 17:16:14 elevator_1] Closed doors
[D1 17:16:14 elevator_1] Resting at floor 1
[D1 17:19:19 citizen_187] Time to go to the ground floor and leave
[D1 17:19:19 floor_2] citizen_187 entered the queue
[D1 17:19:19 floor_2] citizen_187 found an empty queue and will be served immediately
[D1 17:19:19 elevator_1] Summoned to floor 2 from floor 1
[D1 17:19:19 elevator_1] Sprung into motion, heading Up
[D1 17:19:29 elevator_1] At floor 2
[D1 17:19:29 elevator_1] Stopped at floor 2
[D1 17:19:29 elevator_1] Opening doors
[D1 17:19:32 elevator_1] Opened doors
[D1 17:19:32 citizen_187] Entered elevator_1, going to floor 0
[D1 17:19:32 floor_2] citizen_187 is leaving the queue
[D1 17:19:32 floor_2] The queue is now empty
[D1 17:19:44 elevator_1] Closing doors
[D1 17:19:47 elevator_1] Closed doors
[D1 17:19:47 elevator_1] Changing direction to Down
[D1 17:19:57 elevator_1] At floor 1
[D1 17:20:03 citizen_198] Time to go to floor 1 and stay there for 00:32:59
[D1 17:20:03 floor_2] citizen_198 entered the queue
[D1 17:20:03 floor_2] citizen_198 found an empty queue and will be served immediately
[D1 17:20:03 elevator_1] Summoned to floor 2 from floor 1
[D1 17:20:07 elevator_1] At floor 0
[D1 17:20:07 elevator_1] Stopped at floor 0
[D1 17:20:07 elevator_1] Opening doors
[D1 17:20:10 elevator_1] Opened doors
[D1 17:20:10 citizen_187] Left elevator_1, arrived at floor 0
[D1 17:20:10 citizen_187] Left the building
[D1 17:20:22 elevator_1] Closing doors
[D1 17:20:25 elevator_1] Closed doors
[D1 17:20:25 elevator_1] Changing direction to Up
[D1 17:20:35 elevator_1] At floor 1
[D1 17:20:45 elevator_1] At floor 2
[D1 17:20:45 elevator_1] Stopped at floor 2
[D1 17:20:45 elevator_1] Opening doors
[D1 17:20:48 elevator_1] Opened doors
[D1 17:20:48 citizen_198] Entered elevator_1, going to floor 1
[D1 17:20:48 floor_2] citizen_198 is leaving the queue
[D1 17:20:48 floor_2] The queue is now empty
[D1 17:21:00 elevator_1] Closing doors
[D1 17:21:03 elevator_1] Closed doors
[D1 17:21:03 elevator_1] Changing direction to Down
[D1 17:21:05 citizen_169] Time to go to the ground floor and leave
[D1 17:21:05 floor_4] citizen_169 entered the queue
[D1 17:21:05 floor_4] citizen_169 found an empty queue and will be served immediately
[D1 17:21:05 elevator_1] Summoned to floor 4 from floor 2
[D1 17:21:13 elevator_1] At floor 1
[D1 17:21:13 elevator_1] Stopped at floor 1
[D1 17:21:13 elevator_1] Opening doors
[D1 17:21:16 elevator_1] Opened doors
[D1 17:21:16 citizen_198] Left elevator_1, arrived at floor 1
[D1 17:21:28 elevator_1] Closing doors
[D1 17:21:31 elevator_1] Closed doors
[D1 17:21:31 elevator_1] Changing direction to Up
[D1 17:21:41 elevator_1] At floor 2
[D1 17:21:51 elevator_1] At floor 3
[D1 17:22:01 elevator_1] At floor 4
[D1 17:22:01 elevator_1] Stopped at floor 4
[D1 17:22:01 elevator_1] Opening doors
[D1 17:22:04 elevator_1] Opened doors
[D1 17:22:04 citizen_169] Entered elevator_1, going to floor 0
[D1 17:22:04 floor_4] citizen_169 is leaving the queue
[D1 17:22:04 floor_4] The queue is now empty
[D1 17:22:16 elevator_1] Closing doors
[D1 17:22:19 elevator_1] Closed doors
[D1 17:22:19 elevator_1] Changing direction to Down
[D1 17:22:29 elevator_1] At floor 3
[D1 17:22:39 elevator_1] At floor 2
[D1 17:22:49 elevator_1] At floor 1
[D1 17:22:59 elevator_1] At floor 0
[D1 17:22:59 elevator_1] Stopped at floor 0
[D1 17:22:59 elevator_1] Opening doors
[D1 17:23:01 citizen_199] Time to go to the ground floor and leave
[D1 17:23:01 floor_1] citizen_199 entered the queue
[D1 17:23:01 floor_1] citizen_199 found an empty queue and will be served immediately
[D1 17:23:01 elevator_1] Summoned to floor 1 from floor 0
[D1 17:23:01 elevator_2] Summoned to floor 1 from floor 0
[D1 17:23:01 elevator_2] Sprung into motion, heading Up
[D1 17:23:02 elevator_1] Opened doors
[D1 17:23:02 citizen_169] Left elevator_1, arrived at floor 0
[D1 17:23:02 citizen_169] Left the building
[D1 17:23:11 elevator_2] At floor 1
[D1 17:23:11 elevator_2] Stopped at floor 1
[D1 17:23:11 elevator_2] Opening doors
[D1 17:23:14 elevator_1] Closing doors
[D1 17:23:14 elevator_2] Opened doors
[D1 17:23:14 citizen_199] Entered elevator_2, going to floor 0
[D1 17:23:14 floor_1] citizen_199 is leaving the queue
[D1 17:23:14 floor_1] The queue is now empty
[D1 17:23:17 elevator_1] Closed doors
[D1 17:23:17 elevator_1] Changing direction to Up
[D1 17:23:26 elevator_2] Closing doors
[D1 17:23:27 elevator_1] At floor 1
[D1 17:23:27 elevator_1] Stopped at floor 1
[D1 17:23:27 elevator_1] Opening doors
[D1 17:23:29 elevator_2] Closed doors
[D1 17:23:29 elevator_2] Changing direction to Down
[D1 17:23:30 elevator_1] Opened doors
[D1 17:23:39 elevator_2] At floor 0
[D1 17:23:39 elevator_2] Stopped at floor 0
[D1 17:23:39 elevator_2] Opening doors
[D1 17:23:42 elevator_1] Closing doors
[D1 17:23:42 elevator_2] Opened doors
[D1 17:23:42 citizen_199] Left elevator_2, arrived at floor 0
[D1 17:23:42 citizen_199] Left the building
[D1 17:23:45 elevator_1] Closed doors
[D1 17:23:45 elevator_1] Resting at floor 1
[D1 17:23:54 elevator_2] Closing doors
[D1 17:23:57 elevator_2] Closed doors
[D1 17:23:57 elevator_2] Resting at floor 0
[D1 17:26:35 citizen_171] Time to go to the ground floor and leave
[D1 17:26:35 floor_3] citizen_171 entered the queue
[D1 17:26:35 floor_3] citizen_171 found an empty queue and will be served immediately
[D1 17:26:35 elevator_1] Summoned to floor 3 from floor 1
[D1 17:26:35 elevator_1] Sprung into motion, heading Up
[D1 17:26:38 citizen_197] Time to go to the ground floor and leave
[D1 17:26:38 floor_4] citizen_197 entered the queue
[D1 17:26:38 floor_4] citizen_197 found an empty queue and will be served immediately
[D1 17:26:38 elevator_1] Summoned to floor 4 from floor 1
[D1 17:26:40 citizen_173] Time to go to the ground floor and leave
[D1 17:26:40 floor_3] citizen_173 entered the queue
[D1 17:26:40 floor_3] citizen_173 is queued along with 0 other arrivals in front of it
[D1 17:26:45 elevator_1] At floor 2
[D1 17:26:55 elevator_1] At floor 3
[D1 17:26:55 elevator_1] Stopped at floor 3
[D1 17:26:55 elevator_1] Opening doors
[D1 17:26:58 elevator_1] Opened doors
[D1 17:26:58 citizen_171] Entered elevator_1, going to floor 0
[D1 17:26:58 floor_3] citizen_171 is leaving the queue
[D1 17:26:58 floor_3] citizen_173 was served
[D1 17:26:58 elevator_1] Summoned to floor 3 from floor 3
[D1 17:26:58 citizen_173] Entered elevator_1, going to floor 0
[D1 17:26:58 floor_3] citizen_173 is leaving the queue
[D1 17:26:58 floor_3] The queue is now empty
[D1 17:27:10 elevator_1] Closing doors
[D1 17:27:13 elevator_1] Closed doors
[D1 17:27:23 elevator_1] At floor 4
[D1 17:27:23 elevator_1] Stopped at floor 4
[D1 17:27:23 elevator_1] Opening doors
[D1 17:27:26 elevator_1] Opened doors
[D1 17:27:26 citizen_197] Entered elevator_1, going to floor 0
[D1 17:27:26 floor_4] citizen_197 is leaving the queue
[D1 17:27:26 floor_4] The queue is now empty
[D1 17:27:38 elevator_1] Closing doors
[D1 17:27:41 elevator_1] Closed doors
[D1 17:27:41 elevator_1] Changing direction to Down
[D1 17:27:48 citizen_189] Time to go to floor 5 and stay there for 00:23:33
[D1 17:27:48 floor_2] citizen_189 entered the queue
[D1 17:27:48 floor_2] citizen_189 found an empty queue and will be served immediately
[D1 17:27:48 elevator_1] Summoned to floor 2 from floor 4
[D1 17:27:48 elevator_2] Summoned to floor 2 from floor 0
[D1 17:27:48 elevator_2] Sprung into motion, heading Up
[D1 17:27:51 elevator_1] At floor 3
[D1 17:27:58 elevator_2] At floor 1
[D1 17:28:01 elevator_1] At floor 2
[D1 17:28:01 elevator_1] Stopped at floor 2
[D1 17:28:01 elevator_1] Opening doors
[D1 17:28:04 elevator_1] Opened doors
[D1 17:28:04 citizen_189] Entered elevator_1, going to floor 5
[D1 17:28:04 floor_2] citizen_189 is leaving the queue
[D1 17:28:04 floor_2] The queue is now empty
[D1 17:28:08 elevator_2] At floor 2
[D1 17:28:08 elevator_2] Stopped at floor 2
[D1 17:28:08 elevator_2] Opening doors
[D1 17:28:11 elevator_2] Opened doors
[D1 17:28:16 elevator_1] Closing doors
[D1 17:28:19 elevator_1] Closed doors
[D1 17:28:23 elevator_2] Closing doors
[D1 17:28:26 elevator_2] Closed doors
[D1 17:28:26 elevator_2] Resting at floor 2
[D1 17:28:29 elevator_1] At floor 1
[D1 17:28:39 elevator_1] At floor 0
[D1 17:28:39 elevator_1] Stopped at floor 0
[D1 17:28:39 elevator_1] Opening doors
[D1 17:28:42 elevator_1] Opened doors
[D1 17:28:42 citizen_171] Left elevator_1, arrived at floor 0
[D1 17:28:42 citizen_173] Left elevator_1, arrived at floor 0
[D1 17:28:42 citizen_197] Left elevator_1, arrived at floor 0
[D1 17:28:42 citizen_171] Left the building
[D1 17:28:42 citizen_197] Left the building
[D1 17:28:42 citizen_173] Left the building
[D1 17:28:54 elevator_1] Closing doors
[D1 17:28:57 elevator_1] Closed doors
[D1 17:28:57 elevator_1] Changing direction to Up
[D1 17:29:07 elevator_1] At floor 1
[D1 17:29:16 citizen_180] Time to go to the ground floor and leave
[D1 17:29:16 floor_5] citizen_180 entered the queue
[D1 17:29:16 floor_5] citizen_180 found an empty queue and will be served immediately
[D1 17:29:16 elevator_2] Summoned to floor 5 from floor 2
[D1 17:29:16 elevator_2] Sprung into motion, heading Up
[D1 17:29:17 elevator_1] At floor 2
[D1 17:29:26 elevator_2] At floor 3
[D1 17:29:27 elevator_1] At floor 3
[D1 17:29:36 elevator_2] At floor 4
[D1 17:29:37 elevator_1] At floor 4
[D1 17:29:46 elevator_2] At floor 5
[D1 17:29:46 elevator_2] Stopped at floor 5
[D1 17:29:46 elevator_2] Opening doors
[D1 17:29:47 elevator_1] At floor 5
[D1 17:29:47 elevator_1] Stopped at floor 5
[D1 17:29:47 elevator_1] Opening doors
[D1 17:29:49 elevator_2] Opened doors
[D1 17:29:49 citizen_180] Entered elevator_2, going to floor 0
[D1 17:29:49 floor_5] citizen_180 is leaving the queue
[D1 17:29:49 floor_5] The queue is now empty
[D1 17:29:50 elevator_1] Opened doors
[D1 17:29:50 citizen_189] Left elevator_1, arrived at floor 5
[D1 17:30:01 elevator_2] Closing doors
[D1 17:30:02 elevator_1] Closing doors
[D1 17:30:04 elevator_2] Closed doors
[D1 17:30:04 elevator_2] Changing direction to Down
[D1 17:30:05 elevator_1] Closed doors
[D1 17:30:05 elevator_1] Resting at floor 5
[D1 17:30:14 elevator_2] At floor 4
[D1 17:30:24 elevator_2] At floor 3
[D1 17:30:34 elevator_2] At floor 2
[D1 17:30:44 elevator_2] At floor 1
[D1 17:30:54 elevator_2] At floor 0
[D1 17:30:54 elevator_2] Stopped at floor 0
[D1 17:30:54 elevator_2] Opening doors
[D1 17:30:57 elevator_2] Opened doors
[D1 17:30:57 citizen_180] Left elevator_2, arrived at floor 0
[D1 17:30:57 citizen_180] Left the building
[D1 17:31:09 elevator_2] Closing doors
[D1 17:31:12 elevator_2] Closed doors
[D1 17:31:12 elevator_2] Resting at floor 0
[D1 17:31:31 citizen_191] Time to go to the ground floor and leave
[D1 17:31:31 floor_1] citizen_191 entered the queue
[D1 17:31:31 floor_1] citizen_191 found an empty queue and will be served immediately
[D1 17:31:31 elevator_2] Summoned to floor 1 from floor 0
[D1 17:31:31 elevator_2] Sprung into motion, heading Up
[D1 17:31:41 elevator_2] At floor 1
[D1 17:31:41 elevator_2] Stopped at floor 1
[D1 17:31:41 elevator_2] Opening doors
[D1 17:31:44 elevator_2] Opened doors
[D1 17:31:44 citizen_191] Entered elevator_2, going to floor 0
[D1 17:31:44 floor_1] citizen_191 is leaving the queue
[D1 17:31:44 floor_1] The queue is now empty
[D1 17:31:56 elevator_2] Closing doors
[D1 17:31:57 citizen_184] Time to go to the ground floor and leave
[D1 17:31:57 floor_4] citizen_184 entered the queue
[D1 17:31:57 floor_4] citizen_184 found an empty queue and will be served immediately
[D1 17:31:57 elevator_1] Summoned to floor 4 from floor 5
[D1 17:31:57 elevator_1] Sprung into motion, heading Down
[D1 17:31:59 elevator_2] Closed doors
[D1 17:31:59 elevator_2] Changing direction to Down
[D1 17:32:07 elevator_1] At floor 4
[D1 17:32:07 elevator_1] Stopped at floor 4
[D1 17:32:07 elevator_1] Opening doors
[D1 17:32:09 elevator_2] At floor 0
[D1 17:32:09 elevator_2] Stopped at floor 0
[D1 17:32:09 elevator_2] Opening doors
[D1 17:32:10 elevator_1] Opened doors
[D1 17:32:10 citizen_184] Entered elevator_1, going to floor 0
[D1 17:32:10 floor_4] citizen_184 is leaving the queue
[D1 17:32:10 floor_4] The queue is now empty
[D1 17:32:12 elevator_2] Opened doors
[D1 17:32:12 citizen_191] Left elevator_2, arrived at floor 0
[D1 17:32:12 citizen_191] Left the building
[D1 17:32:22 elevator_1] Closing doors
[D1 17:32:24 elevator_2] Closing doors
[D1 17:32:25 elevator_1] Closed doors
[D1 17:32:27 elevator_2] Closed doors
[D1 17:32:27 elevator_2] Resting at floor 0
[D1 17:32:35 elevator_1] At floor 3
[D1 17:32:45 elevator_1] At floor 2
[D1 17:32:55 elevator_1] At floor 1
[D1 17:33:05 elevator_1] At floor 0
[D1 17:33:05 elevator_1] Stopped at floor 0
[D1 17:33:05 elevator_1] Opening doors
[D1 17:33:08 elevator_1] Opened doors
[D1 17:33:08 citizen_184] Left elevator_1, arrived at floor 0
[D1 17:33:08 citizen_184] Left the building
[D1 17:33:20 elevator_1] Closing doors
[D1 17:33:23 elevator_1] Closed doors
[D1 17:33:23 elevator_1] Resting at floor 0
[D1 17:33:50 citizen_182] Time to go to the ground floor and leave
[D1 17:33:50 floor_3] citizen_182 entered the queue
[D1 17:33:50 floor_3] citizen_182 found an empty queue and will be served immediately
[D1 17:33:50 elevator_1] Summoned to floor 3 from floor 0
[D1 17:33:50 elevator_1] Sprung into motion, heading Up
[D1 17:33:50 elevator_2] Summoned to floor 3 from floor 0
[D1 17:33:50 elevator_2] Sprung into motion, heading Up
[D1 17:34:00 elevator_1] At floor 1
[D1 17:34:00 elevator_2] At floor 1
[D1 17:34:09 citizen_194] Time to go to floor 5 and stay there for 00:30:23
[D1 17:34:09 floor_1] citizen_194 entered the queue
[D1 17:34:09 floor_1] citizen_194 found an empty queue and will be served immediately
[D1 17:34:09 elevator_1] Summoned to floor 1 from floor 1
[D1 17:34:09 elevator_2] Summoned to floor 1 from floor 1
[D1 17:34:10 elevator_2] At floor 2
[D1 17:34:10 elevator_1] At floor 2
[D1 17:34:20 elevator_2] At floor 3
[D1 17:34:20 elevator_2] Stopped at floor 3
[D1 17:34:20 elevator_2] Opening doors
[D1 17:34:20 elevator_1] At floor 3
[D1 17:34:20 elevator_1] Stopped at floor 3
[D1 17:34:20 elevator_1] Opening doors
[D1 17:34:23 elevator_2] Opened doors
[D1 17:34:23 elevator_1] Opened doors
[D1 17:34:23 citizen_182] Entered elevator_2, going to floor 0
[D1 17:34:23 floor_3] citizen_182 is leaving the queue
[D1 17:34:23 floor_3] The queue is now empty
[D1 17:34:35 elevator_1] Closing doors
[D1 17:34:35 elevator_2] Closing doors
[D1 17:34:38 elevator_1] Closed doors
[D1 17:34:38 elevator_2] Closed doors
[D1 17:34:38 elevator_1] Changing direction to Down
[D1 17:34:38 elevator_2] Changing direction to Down
[D1 17:34:48 elevator_1] At floor 2
[D1 17:34:48 elevator_2] At floor 2
[D1 17:34:58 elevator_1] At floor 1
[D1 17:34:58 elevator_1] Stopped at floor 1
[D1 17:34:58 elevator_1] Opening doors
[D1 17:34:58 elevator_2] At floor 1
[D1 17:34:58 elevator_2] Stopped at floor 1
[D1 17:34:58 elevator_2] Opening doors
[D1 17:35:01 elevator_1] Opened doors
[D1 17:35:01 elevator_2] Opened doors
[D1 17:35:01 citizen_194] Entered elevator_1, going to floor 5
[D1 17:35:01 floor_1] citizen_194 is leaving the queue
[D1 17:35:01 floor_1] The queue is now empty
[D1 17:35:13 elevator_2] Closing doors
[D1 17:35:13 elevator_1] Closing doors
[D1 17:35:16 elevator_2] Closed doors
[D1 17:35:16 elevator_1] Closed doors
[D1 17:35:16 elevator_1] Changing direction to Up
[D1 17:35:23 citizen_200] Time to go to floor 5 and stay there for 00:44:43
[D1 17:35:23 floor_3] citizen_200 entered the queue
[D1 17:35:23 floor_3] citizen_200 found an empty queue and will be served immediately
[D1 17:35:23 elevator_1] Summoned to floor 3 from floor 1
[D1 17:35:23 elevator_2] Summoned to floor 3 from floor 1
[D1 17:35:26 elevator_1] At floor 2
[D1 17:35:26 elevator_2] At floor 0
[D1 17:35:26 elevator_2] Stopped at floor 0
[D1 17:35:26 elevator_2] Opening doors
[D1 17:35:29 elevator_2] Opened doors
[D1 17:35:29 citizen_182] Left elevator_2, arrived at floor 0
[D1 17:35:29 citizen_182] Left the building
[D1 17:35:36 elevator_1] At floor 3
[D1 17:35:36 elevator_1] Stopped at floor 3
[D1 17:35:36 elevator_1] Opening doors
[D1 17:35:39 elevator_1] Opened doors
[D1 17:35:39 citizen_200] Entered elevator_1, going to floor 5
[D1 17:35:39 floor_3] citizen_200 is leaving the queue
[D1 17:35:39 floor_3] The queue is now empty
[D1 17:35:41 elevator_2] Closing doors
[D1 17:35:44 elevator_2] Closed doors
[D1 17:35:44 elevator_2] Changing direction to Up
[D1 17:35:51 elevator_1] Closing doors
[D1 17:35:54 elevator_2] At floor 1
[D1 17:35:54 elevator_1] Closed doors
[D1 17:36:04 elevator_2] At floor 2
[D1 17:36:04 elevator_1] At floor 4
[D1 17:36:14 elevator_2] At floor 3
[D1 17:36:14 elevator_2] Stopped at floor 3
[D1 17:36:14 elevator_2] Opening doors
[D1 17:36:14 elevator_1] At floor 5
[D1 17:36:14 elevator_1] Stopped at floor 5
[D1 17:36:14 elevator_1] Opening doors
[D1 17:36:17 elevator_2] Opened doors
[D1 17:36:17 elevator_1] Opened doors
[D1 17:36:17 citizen_194] Left elevator_1, arrived at floor 5
[D1 17:36:17 citizen_200] Left elevator_1, arrived at floor 5
[D1 17:36:29 elevator_1] Closing doors
[D1 17:36:29 elevator_2] Closing doors
[D1 17:36:32 elevator_1] Closed doors
[D1 17:36:32 elevator_2] Closed doors
[D1 17:36:32 elevator_1] Resting at floor 5
[D1 17:36:32 elevator_2] Resting at floor 3
[D1 17:36:47 citizen_185] Time to go to the ground floor and leave
[D1 17:36:47 floor_3] citizen_185 entered the queue
[D1 17:36:47 floor_3] citizen_185 found an empty queue and will be served immediately
[D1 17:36:47 elevator_2] Summoned to floor 3 from floor 3
[D1 17:36:47 elevator_2] Opening doors
[D1 17:36:50 elevator_2] Opened doors
[D1 17:36:50 citizen_185] Entered elevator_2, going to floor 0
[D1 17:36:50 floor_3] citizen_185 is leaving the queue
[D1 17:36:50 floor_3] The queue is now empty
[D1 17:37:02 elevator_2] Closing doors
[D1 17:37:05 elevator_2] Closed doors
[D1 17:37:05 elevator_2] Sprung into motion, heading Down
[D1 17:37:14 citizen_193] Time to go to floor 2 and stay there for 00:28:53
[D1 17:37:14 floor_4] citizen_193 entered the queue
[D1 17:37:14 floor_4] citizen_193 found an empty queue and will be served immediately
[D1 17:37:14 elevator_1] Summoned to floor 4 from floor 5
[D1 17:37:14 elevator_1] Sprung into motion, heading Down
[D1 17:37:14 elevator_2] Summoned to floor 4 from floor 3
[D1 17:37:15 elevator_2] At floor 2
[D1 17:37:24 elevator_1] At floor 4
[D1 17:37:24 elevator_1] Stopped at floor 4
[D1 17:37:24 elevator_1] Opening doors
[D1 17:37:25 elevator_2] At floor 1
[D1 17:37:27 elevator_1] Opened doors
[D1 17:37:27 citizen_193] Entered elevator_1, going to floor 2
[D1 17:37:27 floor_4] citizen_193 is leaving the queue
[D1 17:37:27 floor_4] The queue is now empty
[D1 17:37:35 elevator_2] At floor 0
[D1 17:37:35 elevator_2] Stopped at floor 0
[D1 17:37:35 elevator_2] Opening doors
[D1 17:37:38 elevator_2] Opened doors
[D1 17:37:38 citizen_185] Left elevator_2, arrived at floor 0
[D1 17:37:38 citizen_185] Left the building
[D1 17:37:39 elevator_1] Closing doors
[D1 17:37:42 elevator_1] Closed doors
[D1 17:37:50 elevator_2] Closing doors
[D1 17:37:52 elevator_1] At floor 3
[D1 17:37:53 elevator_2] Closed doors
[D1 17:37:53 elevator_2] Changing direction to Up
[D1 17:38:02 elevator_1] At floor 2
[D1 17:38:02 elevator_1] Stopped at floor 2
[D1 17:38:02 elevator_1] Opening doors
[D1 17:38:03 elevator_2] At floor 1
[D1 17:38:05 elevator_1] Opened doors
[D1 17:38:05 citizen_193] Left elevator_1, arrived at floor 2
[D1 17:38:13 elevator_2] At floor 2
[D1 17:38:17 elevator_1] Closing doors
[D1 17:38:20 elevator_1] Closed doors
[D1 17:38:20 elevator_1] Resting at floor 2
[D1 17:38:23 elevator_2] At floor 3
[D1 17:38:33 elevator_2] At floor 4
[D1 17:38:33 elevator_2] Stopped at floor 4
[D1 17:38:33 elevator_2] Opening doors
[D1 17:38:36 elevator_2] Opened doors
[D1 17:38:48 elevator_2] Closing doors
[D1 17:38:51 elevator_2] Closed doors
[D1 17:38:51 elevator_2] Resting at floor 4
[D1 17:42:51 citizen_195] Time to go to the ground floor and leave
[D1 17:42:51 floor_5] citizen_195 entered the queue
[D1 17:42:51 floor_5] citizen_195 found an empty queue and will be served immediately
[D1 17:42:51 elevator_2] Summoned to floor 5 from floor 4
[D1 17:42:51 elevator_2] Sprung into motion, heading Up
[D1 17:43:01 elevator_2] At floor 5
[D1 17:43:01 elevator_2] Stopped at floor 5
[D1 17:43:01 elevator_2] Opening doors
[D1 17:43:04 elevator_2] Opened doors
[D1 17:43:04 citizen_195] Entered elevator_2, going to floor 0
[D1 17:43:04 floor_5] citizen_195 is leaving the queue
[D1 17:43:04 floor_5] The queue is now empty
[D1 17:43:16 elevator_2] Closing doors
[D1 17:43:19 elevator_2] Closed doors
[D1 17:43:19 elevator_2] Changing direction to Down
[D1 17:43:29 elevator_2] At floor 4
[D1 17:43:39 elevator_2] At floor 3
[D1 17:43:49 elevator_2] At floor 2
[D1 17:43:59 elevator_2] At floor 1
[D1 17:44:09 elevator_2] At floor 0
[D1 17:44:09 elevator_2] Stopped at floor 0
[D1 17:44:09 elevator_2] Opening doors
[D1 17:44:12 elevator_2] Opened doors
[D1 17:44:12 citizen_195] Left elevator_2, arrived at floor 0
[D1 17:44:12 citizen_195] Left the building
[D1 17:44:24 elevator_2] Closing doors
[D1 17:44:27 elevator_2] Closed doors
[D1 17:44:27 elevator_2] Resting at floor 0
[D1 17:44:53 citizen_186] Time to go to the ground floor and leave
[D1 17:44:53 floor_1] citizen_186 entered the queue
[D1 17:44:53 floor_1] citizen_186 found an empty queue and will be served immediately
[D1 17:44:53 elevator_1] Summoned to floor 1 from floor 2
[D1 17:44:53 elevator_1] Sprung into motion, heading Down
[D1 17:44:53 elevator_2] Summoned to floor 1 from floor 0
[D1 17:44:53 elevator_2] Sprung into motion, heading Up
[D1 17:45:03 elevator_1] At floor 1
[D1 17:45:03 elevator_1] Stopped at floor 1
[D1 17:45:03 elevator_1] Opening doors
[D1 17:45:03 elevator_2] At floor 1
[D1 17:45:03 elevator_2] Stopped at floor 1
[D1 17:45:03 elevator_2] Opening doors
[D1 17:45:06 elevator_1] Opened doors
[D1 17:45:06 elevator_2] Opened doors
[D1 17:45:06 citizen_186] Entered elevator_1, going to floor 0
[D1 17:45:06 floor_1] citizen_186 is leaving the queue
[D1 17:45:06 floor_1] The queue is now empty
[D1 17:45:18 elevator_1] Closing doors
[D1 17:45:18 elevator_2] Closing doors
[D1 17:45:21 elevator_1] Closed doors
[D1 17:45:21 elevator_2] Closed doors
[D1 17:45:21 elevator_2] Resting at floor 1
[D1 17:45:31 elevator_1] At floor 0
[D1 17:45:31 elevator_1] Stopped at floor 0
[D1 17:45:31 elevator_1] Opening doors
[D1 17:45:34 elevator_1] Opened doors
[D1 17:45:34 citizen_186] Left elevator_1, arrived at floor 0
[D1 17:45:34 citizen_186] Left the building
[D1 17:45:46 elevator_1] Closing doors
[D1 17:45:49 elevator_1] Closed doors
[D1 17:45:49 elevator_1] Resting at floor 0
[D1 17:53:23 citizen_189] Time to go to the ground floor and leave
[D1 17:53:23 floor_5] citizen_189 entered the queue
[D1 17:53:23 floor_5] citizen_189 found an empty queue and will be served immediately
[D1 17:53:23 elevator_2] Summoned to floor 5 from floor 1
[D1 17:53:23 elevator_2] Sprung into motion, heading Up
[D1 17:53:33 elevator_2] At floor 2
[D1 17:53:43 elevator_2] At floor 3
[D1 17:53:53 elevator_2] At floor 4
[D1 17:54:03 elevator_2] At floor 5
[D1 17:54:03 elevator_2] Stopped at floor 5
[D1 17:54:03 elevator_2] Opening doors
[D1 17:54:06 elevator_2] Opened doors
[D1 17:54:06 citizen_189] Entered elevator_2, going to floor 0
[D1 17:54:06 floor_5] citizen_189 is leaving the queue
[D1 17:54:06 floor_5] The queue is now empty
[D1 17:54:15 citizen_198] Time to go to floor 3 and stay there for 00:38:02
[D1 17:54:15 floor_1] citizen_198 entered the queue
[D1 17:54:15 floor_1] citizen_198 found an empty queue and will be served immediately
[D1 17:54:15 elevator_1] Summoned to floor 1 from floor 0
[D1 17:54:15 elevator_1] Sprung into motion, heading Up
[D1 17:54:18 elevator_2] Closing doors
[D1 17:54:21 elevator_2] Closed doors
[D1 17:54:21 elevator_2] Changing direction to Down
[D1 17:54:25 elevator_1] At floor 1
[D1 17:54:25 elevator_1] Stopped at floor 1
[D1 17:54:25 elevator_1] Opening doors
[D1 17:54:28 elevator_1] Opened doors
[D1 17:54:28 citizen_198] Entered elevator_1, going to floor 3
[D1 17:54:28 floor_1] citizen_198 is leaving the queue
[D1 17:54:28 floor_1] The queue is now empty
[D1 17:54:31 elevator_2] At floor 4
[D1 17:54:40 elevator_1] Closing doors
[D1 17:54:41 elevator_2] At floor 3
[D1 17:54:43 elevator_1] Closed doors
[D1 17:54:51 elevator_2] At floor 2
[D1 17:54:53 elevator_1] At floor 2
[D1 17:55:01 elevator_2] At floor 1
[D1 17:55:03 elevator_1] At floor 3
[D1 17:55:03 elevator_1] Stopped at floor 3
[D1 17:55:03 elevator_1] Opening doors
[D1 17:55:06 elevator_1] Opened doors
[D1 17:55:06 citizen_198] Left elevator_1, arrived at floor 3
[D1 17:55:11 elevator_2] At floor 0
[D1 17:55:11 elevator_2] Stopped at floor 0
[D1 17:55:11 elevator_2] Opening doors
[D1 17:55:14 elevator_2] Opened doors
[D1 17:55:14 citizen_189] Left elevator_2, arrived at floor 0
[D1 17:55:14 citizen_189] Left the building
[D1 17:55:18 elevator_1] Closing doors
[D1 17:55:21 elevator_1] Closed doors
[D1 17:55:21 elevator_1] Resting at floor 3
[D1 17:55:26 elevator_2] Closing doors
[D1 17:55:29 elevator_2] Closed doors
[D1 17:55:29 elevator_2] Resting at floor 0
[D1 18:06:40 citizen_194] Time to go to the ground floor and leave
[D1 18:06:40 floor_5] citizen_194 entered the queue
[D1 18:06:40 floor_5] citizen_194 found an empty queue and will be served immediately
[D1 18:06:40 elevator_1] Summoned to floor 5 from floor 3
[D1 18:06:40 elevator_1] Sprung into motion, heading Up
[D1 18:06:50 elevator_1] At floor 4
[D1 18:06:58 citizen_193] Time to go to the ground floor and leave
[D1 18:06:58 floor_2] citizen_193 entered the queue
[D1 18:06:58 floor_2] citizen_193 found an empty queue and will be served immediately
[D1 18:06:58 elevator_1] Summoned to floor 2 from floor 4
[D1 18:06:58 elevator_2] Summoned to floor 2 from floor 0
[D1 18:06:58 elevator_2] Sprung into motion, heading Up
[D1 18:07:00 elevator_1] At floor 5
[D1 18:07:00 elevator_1] Stopped at floor 5
[D1 18:07:00 elevator_1] Opening doors
[D1 18:07:03 elevator_1] Opened doors
[D1 18:07:03 citizen_194] Entered elevator_1, going to floor 0
[D1 18:07:03 floor_5] citizen_194 is leaving the queue
[D1 18:07:03 floor_5] The queue is now empty
[D1 18:07:08 elevator_2] At floor 1
[D1 18:07:15 elevator_1] Closing doors
[D1 18:07:18 elevator_2] At floor 2
[D1 18:07:18 elevator_2] Stopped at floor 2
[D1 18:07:18 elevator_2] Opening doors
[D1 18:07:18 elevator_1] Closed doors
[D1 18:07:18 elevator_1] Changing direction to Down
[D1 18:07:21 elevator_2] Opened doors
[D1 18:07:21 citizen_193] Entered elevator_2, going to floor 0
[D1 18:07:21 floor_2] citizen_193 is leaving the queue
[D1 18:07:21 floor_2] The queue is now empty
[D1 18:07:28 elevator_1] At floor 4
[D1 18:07:33 elevator_2] Closing doors
[D1 18:07:36 elevator_2] Closed doors
[D1 18:07:36 elevator_2] Changing direction to Down
[D1 18:07:38 elevator_1] At floor 3
[D1 18:07:46 elevator_2] At floor 1
[D1 18:07:48 elevator_1] At floor 2
[D1 18:07:48 elevator_1] Stopped at floor 2
[D1 18:07:48 elevator_1] Opening doors
[D1 18:07:51 elevator_1] Opened doors
[D1 18:07:56 elevator_2] At floor 0
[D1 18:07:56 elevator_2] Stopped at floor 0
[D1 18:07:56 elevator_2] Opening doors
[D1 18:07:59 elevator_2] Opened doors
[D1 18:07:59 citizen_193] Left elevator_2, arrived at floor 0
[D1 18:07:59 citizen_193] Left the building
[D1 18:08:03 elevator_1] Closing doors
[D1 18:08:06 elevator_1] Closed doors
[D1 18:08:11 elevator_2] Closing doors
[D1 18:08:14 elevator_2] Closed doors
[D1 18:08:14 elevator_2] Resting at floor 0
[D1 18:08:16 elevator_1] At floor 1
[D1 18:08:26 elevator_1] At floor 0
[D1 18:08:26 elevator_1] Stopped at floor 0
[D1 18:08:26 elevator_1] Opening doors
[D1 18:08:29 elevator_1] Opened doors
[D1 18:08:29 citizen_194] Left elevator_1, arrived at floor 0
[D1 18:08:29 citizen_194] Left the building
[D1 18:08:41 elevator_1] Closing doors
[D1 18:08:44 elevator_1] Closed doors
[D1 18:08:44 elevator_1] Resting at floor 0
[D1 18:21:00 citizen_200] Time to go to the ground floor and leave
[D1 18:21:00 floor_5] citizen_200 entered the queue
[D1 18:21:00 floor_5] citizen_200 found an empty queue and will be served immediately
[D1 18:21:00 elevator_1] Summoned to floor 5 from floor 0
[D1 18:21:00 elevator_1] Sprung into motion, heading Up
[D1 18:21:00 elevator_2] Summoned to floor 5 from floor 0
[D1 18:21:00 elevator_2] Sprung into motion, heading Up
[D1 18:21:10 elevator_1] At floor 1
[D1 18:21:10 elevator_2] At floor 1
[D1 18:21:20 elevator_1] At floor 2
[D1 18:21:20 elevator_2] At floor 2
[D1 18:21:30 elevator_1] At floor 3
[D1 18:21:30 elevator_2] At floor 3
[D1 18:21:40 elevator_1] At floor 4
[D1 18:21:40 elevator_2] At floor 4
[D1 18:21:50 elevator_1] At floor 5
[D1 18:21:50 elevator_1] Stopped at floor 5
[D1 18:21:50 elevator_1] Opening doors
[D1 18:21:50 elevator_2] At floor 5
[D1 18:21:50 elevator_2] Stopped at floor 5
[D1 18:21:50 elevator_2] Opening doors
[D1 18:21:53 elevator_1] Opened doors
[D1 18:21:53 elevator_2] Opened doors
[D1 18:21:53 citizen_200] Entered elevator_1, going to floor 0
[D1 18:21:53 floor_5] citizen_200 is leaving the queue
[D1 18:21:53 floor_5] The queue is now empty
[D1 18:22:05 elevator_2] Closing doors
[D1 18:22:05 elevator_1] Closing doors
[D1 18:22:08 elevator_2] Closed doors
[D1 18:22:08 elevator_1] Closed doors
[D1 18:22:08 elevator_2] Resting at floor 5
[D1 18:22:08 elevator_1] Changing direction to Down
[D1 18:22:18 elevator_1] At floor 4
[D1 18:22:28 elevator_1] At floor 3
[D1 18:22:38 elevator_1] At floor 2
[D1 18:22:48 elevator_1] At floor 1
[D1 18:22:58 elevator_1] At floor 0
[D1 18:22:58 elevator_1] Stopped at floor 0
[D1 18:22:58 elevator_1] Opening doors
[D1 18:23:01 elevator_1] Opened doors
[D1 18:23:01 citizen_200] Left elevator_1, arrived at floor 0
[D1 18:23:01 citizen_200] Left the building
[D1 18:23:13 elevator_1] Closing doors
[D1 18:23:16 elevator_1] Closed doors
[D1 18:23:16 elevator_1] Resting at floor 0
[D1 18:33:08 citizen_198] Time to go to the ground floor and leave
[D1 18:33:08 floor_3] citizen_198 entered the queue
[D1 18:33:08 floor_3] citizen_198 found an empty queue and will be served immediately
[D1 18:33:08 elevator_2] Summoned to floor 3 from floor 5
[D1 18:33:08 elevator_2] Sprung into motion, heading Down
[D1 18:33:18 elevator_2] At floor 4
[D1 18:33:28 elevator_2] At floor 3
[D1 18:33:28 elevator_2] Stopped at floor 3
[D1 18:33:28 elevator_2] Opening doors
[D1 18:33:31 elevator_2] Opened doors
[D1 18:33:31 citizen_198] Entered elevator_2, going to floor 0
[D1 18:33:31 floor_3] citizen_198 is leaving the queue
[D1 18:33:31 floor_3] The queue is now empty
[D1 18:33:43 elevator_2] Closing doors
[D1 18:33:46 elevator_2] Closed doors
[D1 18:33:56 elevator_2] At floor 2
[D1 18:34:06 elevator_2] At floor 1
[D1 18:34:16 elevator_2] At floor 0
[D1 18:34:16 elevator_2] Stopped at floor 0
[D1 18:34:16 elevator_2] Opening doors
[D1 18:34:19 elevator_2] Opened doors
[D1 18:34:19 citizen_198] Left elevator_2, arrived at floor 0
[D1 18:34:19 citizen_198] Left the building
[D1 18:34:31 elevator_2] Closing doors
[D1 18:34:34 elevator_2] Closed doors
[D1 18:34:34 elevator_2] Resting at floor 0
```
</details>
