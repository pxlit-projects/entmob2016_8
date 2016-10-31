package be.pxl.spring.service;

import java.sql.Timestamp;
import java.util.List;
import java.util.Set;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.spring.domain.Session;
import be.pxl.spring.domain.User;
import be.pxl.spring.repository.UserRepository;

@Service
@Transactional(readOnly = true)
public class UserServiceImpl implements UserService {
	@Autowired
	  private UserRepository repository;
	  
	@Autowired
	private SessionUtility sessionUtil;
	
	@Override
	@Transactional
	  public User save(User u) {
	    return repository.save(u);
	  }
	  
	
	@Override
	@Transactional 
	  public User findOne(int id){
		  return repository.findOne(id);
	  }
	  
	
	@Override
	@Transactional 
	public List<User> findByName(String name) {
		
		return repository.findByName(name);
	}
	 
	@Override
	@Transactional
	  public List<User> findByDepartment(String department){
		  return repository.findByDepartment(department);
	  }

	@Override
	public void flush() {
		
		repository.flush();
	}

	@Override
	public void delete(User u) {
		
		repository.delete(u);
	}

	// The following methods return a User with a list of Sessions
	@Override
	public User findById(int id) {
		
		return repository.findById(id);
	}


	@Override
	public User findByDate(int id, Timestamp timeStamp) {
		
		return repository.findByDate(id, timeStamp);
	}


	@Override
	public User findByGreaterStartTime(int id, Timestamp timeStamp) {
		
		return repository.findByGreaterStartTime(id, timeStamp);
	}


	@Override
	public User findByLesserEndTime(int id, Timestamp timeStamp) {
		
		return repository.findByLesserEndTime(id, timeStamp);
	}


	@Override
	public User findByGreaterActualTime(int id, int time) {
		
		return repository.findByGreaterActualTime(id, time);
	}


	@Override
	public User findByLesserActualTime(int id, int time) {
		
		return repository.findByLesserActualTime(id, time);
	}


	@Override
	public User findBetween(int id, Timestamp startTime,
			Timestamp endTime) {
		
		return repository.findBetween(id, startTime, endTime);
	}


	@Override
	public double getAverageActualTime(int id, Timestamp startTime,
			Timestamp endTime) {
		
		Set<Session> sessions = (this.findBetween(id, startTime, endTime)).getSessions();		
		return sessionUtil.AverageActual(sessions);
	}


	@Override
	public double getAverageActualTime(int id) {
		Set<Session> sessions = repository.findById(id).getSessions();
		return sessionUtil.AverageActual(sessions);
		
	}


	@Override
	public int getMinimalActualTime(int id) {
		Set<Session> sessions = repository.findById(id).getSessions();		
		return sessionUtil.MinimalActual(sessions);
	}


	@Override
	public int getMinimalActualTime(int id, Timestamp startTime,
			Timestamp endTime) {
		Set<Session> sessions = (this.findBetween(id, startTime, endTime)).getSessions();
		return sessionUtil.MinimalActual(sessions);
	}


	@Override
	public int getMaximalActualTime(int id) {
		Set<Session> sessions = repository.findById(id).getSessions();
		return sessionUtil.MaximalActual(sessions);
	}


	@Override
	public int getMaximalActualTime(int id, Timestamp startTime,
			Timestamp endTime) {
		Set<Session> sessions = (this.findBetween(id, startTime, endTime)).getSessions();
		return sessionUtil.MaximalActual(sessions);
	}


	@Override
	public int getTotalActualTime(int id) {		
		return repository.findTotalActualTime(id);
	}


	@Override
	public List<User> findAll() {		
		return repository.findAll();
	}


	@Override
	public List<User> findByRole(String role) {
		// TODO Auto-generated method stub
		return repository.findByRole(role);
	}


	@Override
	public int getTotalSessionLength(int userId) {
		Set<Session> sessions = this.findById(userId).getSessions();
		return sessionUtil.TotalLength(sessions);
		
	}


	@Override
	public double getAverageSessionLength(int userId) {
		Set<Session> sessions = this.findById(userId).getSessions();
		return sessionUtil.AverageLength(sessions);
	}


	@Override
	public int getMinimalSessionLength(int userId) {
		Set<Session> sessions = this.findById(userId).getSessions();
		return sessionUtil.MinimalLength(sessions);
	}


	@Override
	public int getMaximalSessionLength(int userId) {
		Set<Session> sessions = this.findById(userId).getSessions();
		return sessionUtil.MaximalLength(sessions);
	}
	
	

	
}
