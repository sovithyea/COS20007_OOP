import time
import psutil
import os

# Counter class
class Counter:
    def __init__(self, name):
        self.name = name
        self.count = 0

    def increment(self):
        self.count += 1

    def reset(self):
        self.count = 0

    def get_ticks(self):
        return self.count

# Clock class
class Clock:
    def __init__(self):
        self.hours = Counter("Hours")
        self.minutes = Counter("Minutes")
        self.seconds = Counter("Seconds")
        self.is_am = True

    def tick(self):
        self.seconds.increment()
        if self.seconds.get_ticks() == 60:
            self.seconds.reset()
            self.minutes.increment()
            if self.minutes.get_ticks() == 60:
                self.minutes.reset()
                self.hours.increment()
                if self.hours.get_ticks() == 12:
                    self.is_am = not self.is_am
                elif self.hours.get_ticks() == 13:
                    self.hours.reset()
                    self.hours.increment()

    def get_time(self):
        if self.hours.get_ticks() == 0:
            h = 12
        else:
            h = self.hours.get_ticks()
        m = self.minutes.get_ticks()
        s = self.seconds.get_ticks()
        if self.is_am:
            period = "AM"
        else:
            period = "PM"
        return f"{h:02d}:{m:02d}:{s:02d} {period}"

    def restart(self):
        self.hours.reset()
        self.minutes.reset()
        self.seconds.reset()
        self.is_am = True

# Benchmark function
def benchmark_clock(ticks_to_run):
    process = psutil.Process(os.getpid())

    clock = Clock()
    start_time = time.time()

    for _ in range(ticks_to_run):
        clock.tick()

    end_time = time.time()

    print("Time after {} ticks: {}".format(ticks_to_run, clock.get_time()))
    clock.restart()
    print("Time after reset:", clock.get_time())

    print(f"Execution Time: {(end_time - start_time) * 1000:.3f} ms")
    print(f"Memory Usage: {process.memory_info().rss} bytes")

# Run benchmark
if __name__ == "__main__":
    benchmark_clock(50000)
