package be.pxl.spring.service;

import java.sql.Timestamp;
import java.util.List;

import be.pxl.spring.domain.User;

public interface UserService {

	public abstract User save(User u);

	public abstract User findOne(int id);

	public abstract List<User> findByName(String name);

	public abstract List<User> findByDepartment(String department);

	public abstract void flush();

	public abstract void delete(User u);
	
	// The following methods return a User with a list of Sessions
	public abstract User findById(int id);

	public abstract User findByDate(int id, Timestamp timeStamp);

	public abstract User findByGreaterStartTime(int id,
			Timestamp timeStamp);

	public abstract User findByLesserEndTime(int id,
			Timestamp timeStamp);

	public abstract User findByGreaterActualTime(int id, int time);

	public abstract User findByLesserActualTime(int id, int time);

	public abstract User findBetween(int id, Timestamp startTime,
			Timestamp endTime);

	public abstract double getAverageActualTime(int id, Timestamp startTime,
			Timestamp endTime);

	public abstract double getAverageActualTime(int id);

	public abstract int getMinimalActualTime(int id);

	public abstract int getMinimalActualTime(int id, Timestamp startTime,
			Timestamp endTime);

	public abstract int getMaximalActualTime(int id);

	public abstract int getMaximalActualTime(int id, Timestamp startTime,
			Timestamp endTime);

	public abstract int getTotalActualTime(int id);

	
	

}