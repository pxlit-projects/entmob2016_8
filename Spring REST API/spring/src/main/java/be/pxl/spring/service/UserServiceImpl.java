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
	private AverageSessionLengthUtility averageUtil;
	
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
		return averageUtil.Calculate(sessions);
	}

	
}
