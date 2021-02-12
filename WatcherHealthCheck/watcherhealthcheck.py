class WatcherHealthCheck(object):
    def __init__(self, Hostname, IP, CPU_Temp, GPU_Temp, Disk_Total, Disk_Used, Disk_Free, Timestamp):
        self.Hostname = Hostname
        self.IP = IP
        self.CPU_Temp = CPU_Temp
        self.GPU_Temp = GPU_Temp
        self.Disk_Total = Disk_Total
        self.Disk_Used = Disk_Used
        self.Disk_Free = Disk_Free
        self.Timestamp = Timestamp