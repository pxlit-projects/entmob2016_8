package be.pxl.spring.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.spring.domain.User;
import be.pxl.spring.repository.UserRepository;

@Service
@Transactional(readOnly = true)
public class UserServiceImpl implements UserService {
	@Autowired
	  private UserRepository repository;
	  
	  /* (non-Javadoc)
	 * @see be.pxl.spring.service.UserService#save(be.pxl.spring.domain.User)
	 */
	@Override
	@Transactional
	  public User save(User u) {
	    return repository.save(u);
	  }
	  
	  /* (non-Javadoc)
	 * @see be.pxl.spring.service.UserService#findOne(int)
	 */
	@Override
	@Transactional 
	  public User findOne(int id){
		  return repository.findOne(id);
	  }
	  
	  /* (non-Javadoc)
	 * @see be.pxl.spring.service.UserService#findByName(java.lang.String)
	 */
	@Override
	@Transactional 
	public List<User> findByName(String name) {
		// TODO Auto-generated method stub
		return repository.findByName(name);
	}
	  /* (non-Javadoc)
	 * @see be.pxl.spring.service.UserService#findByDepartment(java.lang.String)
	 */
	@Override
	@Transactional
	  public List<User> findByDepartment(String department){
		  return repository.findByDepartment(department);
	  }

	@Override
	public void flush() {
		// TODO Auto-generated method stub
		repository.flush();
	}
}
